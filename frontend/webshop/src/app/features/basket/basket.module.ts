import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketPageComponent } from './pages/basket-page/basket-page.component';
import { BasketRoutingModule } from './basket-routing.module';
import { NbButtonModule, NbCardModule, NbIconModule, NbListModule, NbTooltipModule } from '@nebular/theme';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import { BasketFooterComponent } from './components/basket-footer/basket-footer.component';

@NgModule({
  declarations: [BasketPageComponent, BasketItemComponent, BasketFooterComponent],
  imports: [
    CommonModule,
    BasketRoutingModule,
    NbCardModule,
    NbListModule,
    NbButtonModule,
    NbIconModule,
    NbTooltipModule
  ]
})
export class BasketModule { }
