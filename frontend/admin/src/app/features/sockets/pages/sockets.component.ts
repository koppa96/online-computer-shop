import { AfterViewInit, Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { SocketCreateCommand, SocketListResponse, SocketsClient, SocketEditCommand } from 'src/app/shared/clients';
import { SocketDialogComponent } from '../components/socket-dialog/socket-dialog.component';
import { RemoveConfirmDialogComponent } from 'src/app/shared/remove-confirm-dialog/remove-confirm-dialog.component';

@Component({
  selector: 'app-sockets',
  templateUrl: './sockets.component.html',
  styleUrls: ['./sockets.component.scss']
})
export class SocketsComponent implements AfterViewInit {
  loadItems$: Subject<void>;
  socketListItems$: Observable<SocketListResponse[]>;


  constructor(
    private client: SocketsClient,
    private dialogService: NbDialogService
  ) {
    this.loadItems$ = new Subject<void>();
    this.socketListItems$ = this.loadItems$.pipe(
      switchMap(() => this.client.listSockets())
    );
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }

  onNewSocketItem() {
    this.dialogService.open(SocketDialogComponent, {
      context: {
        isNewElement: true
      }
    }).onClose.subscribe(x => {
      if (x) {
        this.client.createSocket(new SocketCreateCommand({
          name: x
        })).subscribe(() => {
          this.loadItems$.next();
        });
      }
    });
  }

  onRemoveSocketItem(socketListItem: SocketListResponse) {
    this.dialogService.open(RemoveConfirmDialogComponent)
      .onClose.subscribe(x => {
        if (x) {
          this.client.removeSocket(socketListItem.id)
            .subscribe(() => {
              this.loadItems$.next();
            });
        }
      });
  }

  onEditSocketItem(socketListItem: SocketListResponse) {
    this.dialogService.open(SocketDialogComponent, {
      context: {
        isNewElement: false
      }
    }).onClose.subscribe(x => {
      if (x) {
        this.client.editSocket(socketListItem.id, new SocketEditCommand({
          id: socketListItem.id,
          name: x
        }))
          .subscribe(() => {
            this.loadItems$.next();
          });
      }
    });
  }


}
