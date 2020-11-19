import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { merge, Observable, of } from 'rxjs';
import { startWith } from 'rxjs/operators';
import { CategoriesClient, ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-list-page',
  templateUrl: './product-list-page.component.html',
  styleUrls: ['./product-list-page.component.scss']
})
export class ProductListPageComponent implements OnInit {
  products$: Observable<ProductListResponse[]>;

  constructor(
    private client: CategoriesClient,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const categoryId = this.route.snapshot.params.categoryId;
    this.products$ = this.client.listProducts(categoryId, []).pipe(
      startWith([] as ProductListResponse[])
    );
  }
}
