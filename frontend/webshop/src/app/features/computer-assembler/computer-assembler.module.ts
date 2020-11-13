import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComputerAssemblerPageComponent } from './pages/computer-assembler-page/computer-assembler-page.component';
import { AssemblerSlotComponent } from './components/assembler-slot/assembler-slot.component';
import { ComputerAssemblerRoutingModule } from './computer-assembler-routing.module';

@NgModule({
  declarations: [
    ComputerAssemblerPageComponent,
    AssemblerSlotComponent
  ],
  imports: [
    CommonModule,
    ComputerAssemblerRoutingModule
  ]
})
export class ComputerAssemblerModule { }
