import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';



@NgModule({
  declarations: [
    OrderDetailsPageComponent,
    OrderListPageComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrdersModule { }
