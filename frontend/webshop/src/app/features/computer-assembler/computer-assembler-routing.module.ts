import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComputerAssemblerPageComponent } from './pages/computer-assembler-page/computer-assembler-page.component';

export const routes: Routes = [
  {
    path: '',
    component: ComputerAssemblerPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComputerAssemblerRoutingModule { }