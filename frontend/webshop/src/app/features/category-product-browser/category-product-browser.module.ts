import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';
import { ProductDetailsPageComponent } from './pages/product-details-page/product-details-page.component';
import { CategoryProductBrowserRoutingModule } from './category-product-browser-routing.module';
import { ProductListItemComponent } from './components/product-list-item/product-list-item.component';
import { NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbListModule, NbTooltipModule, NbUserModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { ProvidesUsesPipe } from './pipes/provides-uses.pipe';

@NgModule({
  declarations: [ProductListPageComponent, ProductDetailsPageComponent, ProductListItemComponent, ProvidesUsesPipe],
  imports: [
    CommonModule,
    CategoryProductBrowserRoutingModule,
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    NbListModule,
    NbIconModule,
    NbUserModule,
    NbTooltipModule,
    FormsModule
  ]
})
export class CategoryProductBrowserModule { }
