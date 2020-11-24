import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComputerAssemblerPageComponent } from './pages/computer-assembler-page/computer-assembler-page.component';
import { AssemblerSlotComponent } from './components/assembler-slot/assembler-slot.component';
import { ComputerAssemblerRoutingModule } from './computer-assembler-routing.module';
import { NbButtonModule, NbCardModule, NbListModule, NbSelectModule } from '@nebular/theme';

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
    NbListModule,
    NbButtonModule
  ]
})
export class ComputerAssemblerModule { }
