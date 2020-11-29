import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryGetResponse, CategoryListResponse, CategorySocketGetResponse, ProductCreateCommand, ProductSocketCreateCommand, PropertyValueCreateCommand, SocketListResponse, SocketsClient } from 'src/app/shared/clients';
import { PropertyModel } from '../../models/category-create-edit.model';
import { ProductEditCreateModel, PropertyValueEditCreateModel } from '../../models/product-create-edit.model';

@Component({
  selector: 'app-new-product-page',
  templateUrl: './new-product-page.component.html',
  styleUrls: ['./new-product-page.component.scss']
})
export class NewProductPageComponent {

  categoryId: string;
  product: ProductEditCreateModel = {
    name: '',
    description: '',
    price: 0,
    quantity: 0,
    categoryId: '',
    properties: [],
    productSockets: []
  };
  categorySockets: CategorySocketGetResponse[] = [];
  loadItems$: Subject<void>;
  categoryItem$: Observable<CategoryGetResponse>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private categoriesClient: CategoriesClient
  ) {
    this.categoryId = this.activatedRoute.snapshot.paramMap.get('categoryId');
    this.loadItems$ = new Subject<void>();
    this.categoryItem$ = this.loadItems$.pipe(
      switchMap(() => this.categoriesClient.getCategory(this.categoryId))
    );
    this.categoryItem$.subscribe(x => {
      if (x) {
        this.categorySockets = x.categorySockets;
        this.product = {
          name: '',
          description: '',
          price: 0,
          quantity: 0,
          categoryId: this.categoryId,
          properties: x.propertyTypes.map(p => (
            {
              propertyTypeId: p.id,
              propertyTypeName: p.name,
              value: ''
            }
          )),
          productSockets: []
        };
      }
    });

    this.loadItems$.next();

  }

  onSave() {

    this.categoriesClient.createProduct(
      this.categoryId,
      new ProductCreateCommand({
        categoryId: this.categoryId,
        name: this.product.name,
        description: this.product.description,
        price: this.product.price,
        quantity: this.product.quantity,
        productSockets: this.product.productSockets.map(x => new ProductSocketCreateCommand({
          socketId: x.socketId,
          numberOfSocket: x.numberOfSocket,
          providesUses: x.providesUses
        })),
        propertyValues: this.product.properties.map(x => new PropertyValueCreateCommand({
          propertyTypeId: x.propertyTypeId,
          value: x.value
        }))
      })
    ).subscribe(x => this.router.navigate(['..'], { relativeTo: this.activatedRoute }));
    console.log(this.product);
  }

}
