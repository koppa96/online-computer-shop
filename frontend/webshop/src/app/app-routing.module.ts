import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'basket',
    loadChildren: () => import('./features/basket/basket.module').then(m => m.BasketModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./features/category-product-browser/category-product-browser.module')
      .then(m => m.CategoryProductBrowserModule)
  },
  {
    path: 'computer-assembler',
    loadChildren: () => import('./features/computer-assembler/computer-assembler.module').then(m => m.ComputerAssemblerModule)
  },
  {
    path: 'orders',
    loadChildren: () => import('./features/orders/orders.module').then(m => m.OrdersModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
