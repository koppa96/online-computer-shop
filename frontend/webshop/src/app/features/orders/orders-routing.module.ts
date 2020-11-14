import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full'
  },
  {
    path: 'list',
    component: OrderListPageComponent
  },
  {
    path: ':id',
    component: OrderDetailsPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }