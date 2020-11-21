import { AfterViewInit, Component } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { BasketItemEditCommand, BasketItemListResponse, BasketItemsClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-basket-page',
  templateUrl: './basket-page.component.html',
  styleUrls: ['./basket-page.component.scss']
})
export class BasketPageComponent implements AfterViewInit {
  sum = 0;
  loadItems$: Subject<void>;
  basketItems$: Observable<BasketItemListResponse[]>;

  constructor(private client: BasketItemsClient) {
    this.loadItems$ = new Subject<void>();
    this.basketItems$ = this.loadItems$.pipe(
      switchMap(() => this.client.listItems()),
      tap(items => this.calculateSumValue(items))
    );
  }

  ngAfterViewInit() {
    this.loadItems$.next();
  }

  calculateSumValue(items: BasketItemListResponse[]) {
    this.sum =  items.reduce((prev, curr) => prev + curr.quantity * curr.pricePerPiece, 0);
  }

  deleteItem(item: BasketItemListResponse) {
    this.client.removeItem(item.id).subscribe(() => {
      this.loadItems$.next();
    });
  }

  changeQuantity(item: BasketItemListResponse, amount: number) {
    this.client.editItem(item.id, new BasketItemEditCommand({
      id: item.id,
      productId: item.productId,
      quantity: item.quantity + amount
    })).subscribe(() => {
      this.loadItems$.next();
    });
  }

  deleteItems() {
    this.client.removeItems().subscribe(() => this.loadItems$.next());
  }
}
