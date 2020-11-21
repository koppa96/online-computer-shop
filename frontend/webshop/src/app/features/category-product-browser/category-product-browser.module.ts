import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';
import { ProductDetailsPageComponent } from './pages/product-details-page/product-details-page.component';
import { CategoryProductBrowserRoutingModule } from './category-product-browser-routing.module';
import { ProductListItemComponent } from './components/product-list-item/product-list-item.component';
import { NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbListModule, NbUserModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProductListPageComponent, ProductDetailsPageComponent, ProductListItemComponent],
  imports: [
    CommonModule,
    CategoryProductBrowserRoutingModule,
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    NbListModule,
    NbIconModule,
    NbUserModule,
    FormsModule
  ]
})
export class CategoryProductBrowserModule { }
