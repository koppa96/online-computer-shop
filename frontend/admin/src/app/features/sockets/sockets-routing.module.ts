import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SocketsComponent } from './pages/sockets.component';

const routes: Routes = [{ path: '', component: SocketsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SocketsRoutingModule { }
