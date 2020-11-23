import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [

  {
    path: 'orders',
    loadChildren: () => import('./features/orders/orders.module')
      .then(m => m.OrdersModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./features/categories/categories.module')
    .then(m => m.CategoriesModule)
  },
  {
    path: 'sockets',
    loadChildren: () => import('./features/sockets/sockets.module')
    .then(m => m.SocketsModule) },
  {
    path: 'user-management',
    loadChildren: () => import('./features/user-management/user-management.module')
    .then(m => m.UserManagementModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
