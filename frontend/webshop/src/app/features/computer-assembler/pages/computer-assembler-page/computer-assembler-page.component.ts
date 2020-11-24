import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesClient, CategoryListResponse, ComputerAssemblerProductListResponse, ProductSocketResponse, ProvidedSocketQuery, ProvidesUses } from 'src/app/shared/clients';
import { SocketModel } from '../../models/socket.model';
import 'linq-extensions';

@Component({
  selector: 'app-computer-assembler-page',
  templateUrl: './computer-assembler-page.component.html',
  styleUrls: ['./computer-assembler-page.component.scss']
})
export class ComputerAssemblerPageComponent implements OnInit {
  categories$: Observable<CategoryListResponse[]>;
  sockets: SocketModel[] = [];

  products: { index: number; selectedProduct: ComputerAssemblerProductListResponse }[] = [];

  constructor(private client: CategoriesClient) {
    this.categories$ = this.client.listCategories();
  }

  ngOnInit(): void {
  }

  addSlot() {
    this.products.push({
      index: this.products.length,
      selectedProduct: null
    });
  }

  deleteSlot(index: number) {
    this.products.splice(index, 1);
    this.calculateSockets();
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
}
