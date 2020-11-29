import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { OAuthService } from 'angular-oauth2-oidc';
import { merge, Observable, of, Subject } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';
import { BasketItemAddCommand, BasketItemsClient, CategoriesClient, ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-list-page',
  templateUrl: './product-list-page.component.html',
  styleUrls: ['./product-list-page.component.scss']
})
export class ProductListPageComponent implements OnInit {
  isLoggedIn = false;
  loadItems$ = new Subject<void>();
  products$: Observable<ProductListResponse[]>;

  constructor(
    private categoriesClient: CategoriesClient,
    private basketItemsClient: BasketItemsClient,
    private route: ActivatedRoute,
    private oauthService: OAuthService,
    private toastrService: NbToastrService
  ) {
    this.products$ = this.route.params.pipe(
      switchMap(params => this.categoriesClient.listProducts(params.categoryId))
    );
  }

  ngOnInit(): void {
    this.isLoggedIn = this.oauthService.hasValidAccessToken();
  }

  addToCart(product: ProductListResponse) {
    this.basketItemsClient.addItem(new BasketItemAddCommand({
      productId: product.id,
      quantity: 1
    })).subscribe(
      () => this.toastrService.success(`A termék: ${product.name} sikeresen hozzá lett adva a kosaradhoz.`, 'Siker'),
      () => this.toastrService.danger('Nem sikerült a terméket kosárba helyezni. Lehetséges hogy már nincs készleten.', 'Hiba'));
  }
}
