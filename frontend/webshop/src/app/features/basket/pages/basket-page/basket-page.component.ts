import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { BasketItemEditCommand, BasketItemListResponse, BasketItemsClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-basket-page',
  templateUrl: './basket-page.component.html',
  styleUrls: ['./basket-page.component.scss']
})
export class BasketPageComponent {
  sum = 0;
  basketItems: BasketItemListResponse[] = [];

  constructor(private client: BasketItemsClient) {
    this.client.listItems().subscribe(res => {
      this.basketItems = res;
      this.calculateSumValue();
    });
  }

  calculateSumValue() {
    this.sum =  this.basketItems.reduce((prev, curr) => prev + curr.quantity * curr.pricePerPiece, 0);
  }

  deleteItem(item: BasketItemListResponse) {
    this.client.removeItem(item.id).subscribe(() => {
      this.basketItems = this.basketItems.filter(x => x !== item);
      this.calculateSumValue();
    });
  }

  changeQuantity(item: BasketItemListResponse, amount: number) {
    this.client.editItem(item.id, new BasketItemEditCommand({
      id: item.id,
      productId: item.productId,
      quantity: item.quantity + amount
    })).subscribe(() => {
      item.quantity += amount;
      if (item.quantity === 0) {
        this.basketItems = this.basketItems.filter(x => x !== item);
      }
      this.calculateSumValue();
    });
  }

  deleteItems() {
    this.client.removeItems().subscribe(() => this.basketItems = []);
  }
}
