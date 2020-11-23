import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComputerAssemblerPageComponent } from './pages/computer-assembler-page/computer-assembler-page.component';
import { AssemblerSlotComponent } from './components/assembler-slot/assembler-slot.component';
import { ComputerAssemblerRoutingModule } from './computer-assembler-routing.module';
import { NbCardModule, NbListModule, NbSelectModule } from '@nebular/theme';

@NgModule({
  declarations: [
    ComputerAssemblerPageComponent,
    AssemblerSlotComponent
  ],
  imports: [
    CommonModule,
    ComputerAssemblerRoutingModule,
    NbCardModule,
    NbSelectModule,
    NbListModule
  ]
})
export class ComputerAssemblerModule { }
