import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';
import { ProductDetailsPageComponent } from './pages/product-details-page/product-details-page.component';
import { CategoryProductBrowserRoutingModule } from './category-product-browser-routing.module';

@NgModule({
  declarations: [ProductListPageComponent, ProductDetailsPageComponent],
  imports: [
    CommonModule,
    CategoryProductBrowserRoutingModule
  ]
})
export class CategoryProductBrowserModule { }
