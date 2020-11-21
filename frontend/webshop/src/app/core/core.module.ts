import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NbActionsModule, NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbToggleModule, NbTooltipModule, NbUserModule } from '@nebular/theme';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';

@NgModule({
  imports: [
    CommonModule,
    NbActionsModule,
    NbToggleModule,
    NbIconModule,
    NbButtonModule,
    NbCardModule,
    NbTooltipModule,
    NbUserModule,
    NbInputModule,
    FormsModule
  ],
  declarations: [HeaderComponent, HomeComponent],
  exports: [HeaderComponent, HomeComponent]
})
export class CoreModule { }
