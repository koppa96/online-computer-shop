import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoryListPageComponent } from './pages/category-list-page/category-list-page.component';
import { EditCategoryPageComponent } from './pages/edit-category-page/edit-category-page.component';
import { EditProductPageComponent } from './pages/edit-product-page/edit-product-page.component';
import { NewCategoryPageComponent } from './pages/new-category-page/new-category-page.component';
import { NewProductPageComponent } from './pages/new-product-page/new-product-page.component';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';

const routes: Routes = [
  { path: 'new-category', component: NewCategoryPageComponent },
  { path: ':categoryId/products/new-product', component: NewProductPageComponent },
  { path: ':categoryId/products/edit-product/:productId', component: EditProductPageComponent },
  { path: 'edit-category/:id', component: EditCategoryPageComponent },
  { path: ':categoryId/products', component: ProductListPageComponent },
  { path: '', component: CategoryListPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
