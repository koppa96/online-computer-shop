import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderListResponse, OrdersClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-order-list-page',
  templateUrl: './order-list-page.component.html',
  styleUrls: ['./order-list-page.component.scss']
})
export class OrderListPageComponent {
  orders$: Observable<OrderListResponse[]>;

  constructor(private client: OrdersClient) {
    this.orders$ = this.client.listOrders();
  }
}
