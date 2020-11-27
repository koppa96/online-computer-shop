import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserManagementRoutingModule } from './user-management-routing.module';
import { UserManagementComponent } from './user-management.component';
import { NbButtonModule, NbCardModule, NbIconModule, NbListModule, NbToggleModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [UserManagementComponent],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    NbCardModule,
    NbToggleModule,
    NbIconModule,
    NbButtonModule,
    FormsModule,
    NbListModule
  ]
})
export class UserManagementModule { }
