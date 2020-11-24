import { AfterViewInit, Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { OrderListResponse, OrdersClient } from 'src/app/shared/clients';
import { RemoveConfirmDialogComponent } from 'src/app/shared/remove-confirm-dialog/remove-confirm-dialog.component';

@Component({
  selector: 'app-order-list-page',
  templateUrl: './order-list-page.component.html',
  styleUrls: ['./order-list-page.component.scss']
})
export class OrderListPageComponent implements AfterViewInit {

  loadItems$: Subject<void>;
  orderItems$: Observable<OrderListResponse[]>;

  userName: string;

  constructor(
    private ordersClient: OrdersClient,
    private dialogService: NbDialogService
  ) {
    this.userName = 'hulye_kocsog_vagyok';
    this.loadItems$ = new Subject<void>();
    this.orderItems$ = this.loadItems$.pipe(
      switchMap(() => this.ordersClient.listOrders(this.userName))
    );

  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }

  onRemoveItem(item: OrderListResponse) {
    this.dialogService.open(RemoveConfirmDialogComponent)
      .onClose.subscribe(x => {
        if (x) {
          this.ordersClient.removeOrder(item.id)
            .subscribe(() => {
              this.loadItems$.next();
            });
        }
      });
  }


}
