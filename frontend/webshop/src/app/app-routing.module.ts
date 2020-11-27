import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/auth/auth.guard';
import { HomeComponent } from './core/components/home/home.component';
import { ContactComponent } from './core/pages/contact/contact.component';
import { WarrantyComponent } from './core/pages/warranty/warranty.component';

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
    path: 'contact',
    component: ContactComponent
  },
  {
    path: 'warranty',
    component: WarrantyComponent
  },
  {
    path: 'basket',
    loadChildren: () => import('./features/basket/basket.module').then(m => m.BasketModule),
    canActivate: [AuthGuard]
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
    loadChildren: () => import('./features/orders/orders.module').then(m => m.OrdersModule),
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
