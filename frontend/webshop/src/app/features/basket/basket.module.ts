import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketPageComponent } from './pages/basket-page/basket-page.component';
import { BasketRoutingModule } from './basket-routing.module';
import { NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbListModule, NbTooltipModule } from '@nebular/theme';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import { BasketFooterComponent } from './components/basket-footer/basket-footer.component';
import { FormsModule } from '@angular/forms';
import { OrderCreateComponent } from './components/order-create/order-create.component';

@NgModule({
  declarations: [
    BasketPageComponent,
    BasketItemComponent,
    BasketFooterComponent,
    OrderCreateComponent
  ],
  imports: [
    CommonModule,
    BasketRoutingModule,
    NbCardModule,
    NbListModule,
    NbButtonModule,
    NbIconModule,
    NbTooltipModule,
    NbInputModule,
    FormsModule
  ]
})
export class BasketModule { }
