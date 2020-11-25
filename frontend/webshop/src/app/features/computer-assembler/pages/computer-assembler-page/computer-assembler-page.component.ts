import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketItemAddCommand, BasketItemsClient, CategoriesClient, CategoryListResponse, ComputerAssemblerProductListResponse, ProductSocketResponse, ProvidedSocketQuery, ProvidesUses } from 'src/app/shared/clients';
import { SocketModel } from '../../models/socket.model';
import 'linq-extensions';
import { NbToastrService } from '@nebular/theme';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-computer-assembler-page',
  templateUrl: './computer-assembler-page.component.html',
  styleUrls: ['./computer-assembler-page.component.scss']
})
export class ComputerAssemblerPageComponent implements OnInit {
  isLoggedIn = false;
  categories$: Observable<CategoryListResponse[]>;
  sockets: SocketModel[] = [];

  products: {
    index: number;
    selectedCategoryId: string;
    selectedProduct: ComputerAssemblerProductListResponse
  }[] = [];

  constructor(
    private client: CategoriesClient,
    private toastrService: NbToastrService,
    private basketClient: BasketItemsClient,
    private oauthService: OAuthService
  ) {
    this.categories$ = this.client.listCategories();
  }

  ngOnInit(): void {
    this.isLoggedIn = this.oauthService.hasValidAccessToken();
    this.products = JSON.parse(sessionStorage.getItem('selectedProducts')) || [];
    this.calculateSockets();
  }

  addSlot() {
    this.products.push({
      index: this.products.length,
      selectedCategoryId: null,
      selectedProduct: null
    });
    this.saveProducts();
  }

  deleteSlot(index: number) {
    this.products.splice(index, 1);
    this.calculateSockets();
    this.saveProducts();
  }

  calculateSockets() {
    this.sockets = this.products.where(x => !!x.selectedProduct)
      .selectMany(x => x.selectedProduct.productSockets || [])
      .groupBy(x => x.socketId)
      .select(x => ({
        id: x.key,
        name: x.first().socketName,
        freeCount: x.aggregate(0, (acc, ps) => ps.providesUses === ProvidesUses.Provides ? acc += ps.numberOfSocket : acc -= ps.numberOfSocket)
      }))
      .toArray();
  }

  categorySelectionChange() {
    this.saveProducts();
  }

  productSelectonChange() {
    this.calculateSockets();
    this.saveProducts();
  }

  saveProducts() {
    sessionStorage.setItem('selectedProducts', JSON.stringify(this.products));
  }

  addItemsToCart() {
    if (this.sockets.some(x => x.freeCount < 0)) {
      this.toastrService.danger('A konfiguráció hiányos! Legalább egy olyan alkatrész van kiválasztva, amelyet nem lehet elhelyezni sehova.', 'Hiba', {
        duration: 5000
      });
      return;
    }

    this.basketClient.addItems(this.products.where(x => !!x.selectedProduct)
      .select(x => new BasketItemAddCommand({
        productId: x.selectedProduct.id,
        quantity: 1
      }))
      .toArray())
      .subscribe(() => {
        this.toastrService.success('Az alkatrészek sikeresen hozzá lettek adva a kosárhoz!', 'Siker');
        this.products = [];
        this.sockets = [];
        this.saveProducts();
      });
  }
}
