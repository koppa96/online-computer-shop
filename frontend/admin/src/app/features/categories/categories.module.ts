import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoryListPageComponent } from './pages/category-list-page/category-list-page.component';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';
import { NbButtonModule, NbCardModule, NbDialogModule, NbIconModule, NbInputModule, NbListModule, NbSelectModule, NbTooltipModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { NewCategoryPageComponent } from './pages/new-category-page/new-category-page.component';
import { CreateEditCategoryComponent } from './components/create-edit-category/create-edit-category.component';
import { EditCategoryPageComponent } from './pages/edit-category-page/edit-category-page.component';
import { NewProductPageComponent } from './pages/new-product-page/new-product-page.component';
import { CreateEditProductComponent } from './components/create-edit-product/create-edit-product.component';
import { EditProductPageComponent } from './pages/edit-product-page/edit-product-page.component';


@NgModule({
  declarations: [CategoryListPageComponent, ProductListPageComponent, NewCategoryPageComponent, CreateEditCategoryComponent, EditCategoryPageComponent, NewProductPageComponent, CreateEditProductComponent, EditProductPageComponent],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    NbCardModule,
    NbListModule,
    NbIconModule,
    NbButtonModule,
    NbTooltipModule,
    NbInputModule,
    FormsModule,
    NbDialogModule.forChild(),
    NbSelectModule
  ]
})
export class CategoriesModule { }
