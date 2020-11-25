import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { NbButtonModule, NbCardModule, NbIconModule, NbListModule } from '@nebular/theme';
import { OrderStatePipe } from './pipes/order-state.pipe';



@NgModule({
  declarations: [
    OrderDetailsPageComponent,
    OrderListPageComponent,
    OrderStatePipe
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    NbCardModule,
    NbListModule,
    NbButtonModule,
    NbIconModule
  ]
})
export class OrdersModule { }
