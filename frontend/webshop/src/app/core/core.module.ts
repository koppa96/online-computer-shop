import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NbActionsModule, NbButtonModule, NbCardModule, NbIconModule, NbToggleModule } from '@nebular/theme';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';

@NgModule({
  imports: [
    CommonModule,
    NbActionsModule,
    NbToggleModule,
    NbIconModule,
    NbButtonModule,
    NbCardModule
  ],
  declarations: [HeaderComponent, HomeComponent],
  exports: [HeaderComponent, HomeComponent]
})
export class CoreModule { }