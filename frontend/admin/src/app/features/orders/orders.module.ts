import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';

import { OrderDetailsPageComponent } from './pages/order-details-page/order-details-page.component';
import { OrderListPageComponent } from './pages/order-list-page/order-list-page.component';
import { NbButtonModule, NbCardModule, NbDialogModule, NbIconModule, NbInputModule, NbListModule, NbSelectModule, NbTooltipModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { OrderStateToStringPipe } from './pipes/order-state-to-string.pipe';


@NgModule({
  declarations: [OrderDetailsPageComponent, OrderListPageComponent, OrderStateToStringPipe],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    NbCardModule,
    NbButtonModule,
    NbListModule,
    NbDialogModule.forChild(),
    NbInputModule,
    NbIconModule,
    FormsModule,
    NbTooltipModule,
    NbSelectModule
  ]
})
export class OrdersModule { }
