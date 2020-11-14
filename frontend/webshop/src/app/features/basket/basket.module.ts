import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketPageComponent } from './pages/basket-page/basket-page.component';
import { BasketRoutingModule } from './basket-routing.module';

@NgModule({
  declarations: [BasketPageComponent],
  imports: [
    CommonModule,
    BasketRoutingModule
  ]
})
export class BasketModule { }
