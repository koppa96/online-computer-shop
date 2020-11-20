import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductGetResponse, ProductsClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-details-page',
  templateUrl: './product-details-page.component.html',
  styleUrls: ['./product-details-page.component.scss']
})
export class ProductDetailsPageComponent implements OnInit {
  product$: Observable<ProductGetResponse>;

  constructor(
    private client: ProductsClient,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const productId = this.activatedRoute.snapshot.params.productId;
    this.product$ = this.client.getProduct(productId);
  }
}
