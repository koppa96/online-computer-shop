import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsPageComponent } from './pages/product-details-page/product-details-page.component';
import { ProductListPageComponent } from './pages/product-list-page/product-list-page.component';

export const routes: Routes = [
  {
    path: ':categoryId',
    children: [
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
      },
      {
        path: 'products',
        component: ProductListPageComponent
      },
      {
        path: 'products/:productId',
        component: ProductDetailsPageComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryProductBrowserRoutingModule { }
