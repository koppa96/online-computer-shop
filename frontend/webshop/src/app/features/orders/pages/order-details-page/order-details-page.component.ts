import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { OrderGetResponse, OrdersClient } from 'src/app/shared/clients';
import 'linq-extensions';

@Component({
  selector: 'app-order-details-page',
  templateUrl: './order-details-page.component.html',
  styleUrls: ['./order-details-page.component.scss']
})
export class OrderDetailsPageComponent implements OnInit {
  order$: Observable<OrderGetResponse>;
  sum$: Observable<number>;

  constructor(
    private client: OrdersClient,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    const orderId = this.route.snapshot.params.id;
    this.order$ = this.client.getOrder(orderId);
    this.sum$ = this.order$.pipe(
      map(order => order.orderItems.sumOf(x => x.pricePerPiece * x.quantity))
    );
  }

}
