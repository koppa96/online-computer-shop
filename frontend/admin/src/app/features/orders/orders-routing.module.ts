import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';


const routes: Routes = [
  { path: '', component: OrderListPageComponent },
  { path: ':orderId', component: OrderDetailsPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
