import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { merge, Observable, of } from 'rxjs';
import { startWith } from 'rxjs/operators';
import { BasketItemAddCommand, BasketItemsClient, CategoriesClient, ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-list-page',
  templateUrl: './product-list-page.component.html',
  styleUrls: ['./product-list-page.component.scss']
})
export class ProductListPageComponent implements OnInit {
  isLoggedIn = false;
  products$: Observable<ProductListResponse[]>;

  constructor(
    private categoriesClient: CategoriesClient,
    private basketItemsClient: BasketItemsClient,
    private route: ActivatedRoute,
    private oauthService: OAuthService
  ) { }

  ngOnInit(): void {
    this.isLoggedIn = this.oauthService.hasValidAccessToken();
    const categoryId = this.route.snapshot.params.categoryId;
    this.products$ = this.categoriesClient.listProducts(categoryId, []);
  }

  addToCart(product: ProductListResponse) {
    this.basketItemsClient.addItem(new BasketItemAddCommand({
      productId: product.id,
      quantity: 1
    }));
  }
}
