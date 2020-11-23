import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NbActionsModule, NbButtonModule, NbIconModule, NbToggleModule } from '@nebular/theme';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  imports: [
    CommonModule,
    NbActionsModule,
    NbToggleModule,
    NbIconModule,
    NbButtonModule
  ],
  declarations: [HeaderComponent],
  exports: [HeaderComponent]
})
export class CoreModule { }
