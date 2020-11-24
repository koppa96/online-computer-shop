import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryGetResponse, CategorySocketGetResponse, ProductEditCommand, ProductGetResponse, ProductsClient, ProductSocketEditCommand, PropertyValueEditCommand } from 'src/app/shared/clients';
import { ProductEditCreateModel } from '../../models/product-create-edit.model';

@Component({
  selector: 'app-edit-product-page',
  templateUrl: './edit-product-page.component.html',
  styleUrls: ['./edit-product-page.component.scss']
})
export class EditProductPageComponent {

  productId: string;
  categoryId: string;
  product: ProductEditCreateModel;

  categorySockets: CategorySocketGetResponse[] = [];
  loadItems$: Subject<void>;
  productItem$: Observable<ProductGetResponse>;
  categoryItem$: Observable<CategoryGetResponse>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private productsClient: ProductsClient,
    private categoriesClient: CategoriesClient
  ) {
    this.productId = this.activatedRoute.snapshot.paramMap.get('productId');
    this.categoryId = this.activatedRoute.snapshot.paramMap.get('categoryId');
    this.product = {
      id: this.productId,
      name: '',
      description: '',
      price: 0,
      categoryId: '',
      properties: [],
      productSockets: []
    };
    this.loadItems$ = new Subject<void>();
    this.productItem$ = this.loadItems$.pipe(
      switchMap(() => this.productsClient.getProduct(this.productId))
    );
    this.categoryItem$ = this.loadItems$.pipe(
      switchMap(() => this.categoriesClient.getCategory(this.categoryId))
    );

    this.productItem$.subscribe(x => {
      this.product = {
        id: x.id,
        name: x.name,
        description: x.description,
        price: x.price,
        categoryId: x.categoryId,
        properties: x.propertyValues.map(p => ({ propertyTypeId: p.propertyTypeId, propertyTypeName: p.name, value: p.value })),
        productSockets: x.productSockets.map(p => ({
          socketId: p.socketId,
          name: p.name,
          providesUses: p.providesUses,
          numberOfSocket: p.numberOfSocket
        }))
      };
      console.log(this.product);
    }
    );

    this.categoryItem$.subscribe(x =>
      this.categorySockets = x.categorySockets
    );

    this.loadItems$.next();

  }

  onSave() {

    this.productsClient.editProduct(
      this.productId,
      new ProductEditCommand({
        id: this.productId,
        categoryId: this.product.categoryId,
        name: this.product.name,
        description: this.product.description,
        price: this.product.price,
        productSockets: this.product.productSockets.map(x => new ProductSocketEditCommand({
          socketId: x.socketId,
          providesUses: x.providesUses,
          numberOfSocket: x.numberOfSocket
        })),
        propertyValues: this.product.properties.map(x => {
          console.log(x.value);
          return new PropertyValueEditCommand({
            propertyTypeId: x.propertyTypeId,
            value: x.value
          });
        })
      })
    ).subscribe(x => this.router.navigate(['../..'], { relativeTo: this.activatedRoute }));
    console.log(this.product);
  }




}
