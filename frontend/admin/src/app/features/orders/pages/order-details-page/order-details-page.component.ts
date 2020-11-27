import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { OrderGetResponse, OrderItemGetResponse, OrdersClient, OrderStateEditCommand } from 'src/app/shared/clients';

@Component({
  selector: 'app-order-details-page',
  templateUrl: './order-details-page.component.html',
  styleUrls: ['./order-details-page.component.scss']
})
export class OrderDetailsPageComponent implements AfterViewInit {

  orderId: string;
  orderDetails: OrderGetResponse;
  sum = 0;

  loadItems$: Subject<void>;
  orderDetailItems$: Observable<OrderGetResponse>;

  constructor(
    private ordersClient: OrdersClient,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.loadItems$ = new Subject<void>();

    this.orderId = this.activatedRoute.snapshot.paramMap.get('orderId');
    this.orderDetails = new OrderGetResponse({
      userName: '',
      address: '',
      dateTimeOfOrder: null,
      orderItems: [],
      state: 0
    });

    this.orderDetailItems$ = this.loadItems$.pipe(
      switchMap(() => this.ordersClient.getOrder(this.orderId))
    );


    this.orderDetailItems$.subscribe(x => {
      this.orderDetails = x;
      this.calculateSum(this.orderDetails.orderItems);
    }
    );
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }

  onStateSave() {
    this.ordersClient.editOrderState(
      this.orderId,
      new OrderStateEditCommand({ id: this.orderId, state: this.orderDetails.state })
    ).subscribe(() => this.loadItems$.next());
  }

  calculateSum(orderItems: OrderItemGetResponse[]) {
    this.sum = 0;
    orderItems.forEach(item => {
      this.sum += item.quantity * item.pricePerPiece;
    });
  }



}
