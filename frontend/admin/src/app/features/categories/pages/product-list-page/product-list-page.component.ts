import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbDialogService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryGetResponse, CategoryListResponse, ProductListResponse, ProductsClient } from 'src/app/shared/clients';
import { RemoveConfirmDialogComponent } from 'src/app/shared/remove-confirm-dialog/remove-confirm-dialog.component';

@Component({
  selector: 'app-product-list-page',
  templateUrl: './product-list-page.component.html',
  styleUrls: ['./product-list-page.component.scss']
})
export class ProductListPageComponent implements AfterViewInit {

  loadItems$: Subject<void>;
  categoryItem$: Observable<CategoryGetResponse>;
  productListItems$: Observable<ProductListResponse[]>;

  constructor(
    private categoriesClient: CategoriesClient,
    private productsClient: ProductsClient,
    private dialogService: NbDialogService,
    private activatedRoute: ActivatedRoute
  ) {
    const categoryId = this.activatedRoute.snapshot.paramMap.get('categoryId');
    this.loadItems$ = new Subject<void>();
    this.productListItems$ = this.loadItems$.pipe(
      switchMap(() => this.categoriesClient.listProducts(categoryId))
    );

  }
  ngAfterViewInit(): void {
    this.loadItems$.next();
  }


  onRemoveProductItem(productListItem: ProductListResponse) {
    this.dialogService.open(RemoveConfirmDialogComponent)
      .onClose.subscribe(x => {
        if (x) {
          this.productsClient.removeProduct(productListItem.id)
            .subscribe(() => {
              this.loadItems$.next();
            });
        }
      });
  }



}
