import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NbButtonModule, NbCardModule, NbDialogModule } from '@nebular/theme';
import { RemoveConfirmDialogComponent } from './remove-confirm-dialog/remove-confirm-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    NbDialogModule.forChild(),
    NbCardModule,
    NbButtonModule
  ],
  declarations: [RemoveConfirmDialogComponent]
})
export class SharedModule { }