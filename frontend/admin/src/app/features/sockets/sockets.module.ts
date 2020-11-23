import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SocketsRoutingModule } from './sockets-routing.module';
import { SocketsComponent } from './pages/sockets.component';
import { NbButtonModule, NbCardModule, NbDialogModule, NbIconModule, NbInputModule, NbListModule } from '@nebular/theme';
import { SocketDialogComponent } from './components/socket-dialog/socket-dialog.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [SocketsComponent, SocketDialogComponent],
  imports: [
    CommonModule,
    SocketsRoutingModule,
    NbCardModule,
    NbButtonModule,
    NbListModule,
    NbDialogModule.forChild(),
    NbInputModule,
    NbIconModule,
    FormsModule
  ]
})
export class SocketsModule { }
