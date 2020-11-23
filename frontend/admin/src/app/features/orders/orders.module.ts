import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';

import { OrderDetailsPageComponent } from './order-details-page/order-details-page.component';
import { OrderListPageComponent } from './order-list-page/order-list-page.component';


@NgModule({
  declarations: [OrderDetailsPageComponent, OrderListPageComponent],
  imports: [
    CommonModule,
    OrdersRoutingModule
  ]
})
export class OrdersModule { }
