import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';
import { OrdersRoutingModule } from './orders-routing.module';



@NgModule({
  declarations: [
    OrderDetailsPageComponent,
    OrderListPageComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule
  ]
})
export class OrdersModule { }
