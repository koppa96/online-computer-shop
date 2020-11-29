import { AfterViewInit, Component } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { BasketItemEditCommand, BasketItemListResponse, BasketItemsClient, OrderCreateCommand, OrdersClient } from 'src/app/shared/clients';
import { OrderMetadata } from '../../models/order-metadata.model';

@Component({
  selector: 'app-basket-page',
  templateUrl: './basket-page.component.html',
  styleUrls: ['./basket-page.component.scss']
})
export class BasketPageComponent implements AfterViewInit {
  sum = 0;
  flipped = false;
  loadItems$ = new Subject<void>();
  validate$ = new Subject<void>();
  basketItems$: Observable<BasketItemListResponse[]>;
  orderMetadata: OrderMetadata = {
    name: '',
    address: {
      cityName: '',
      door: '',
      floor: '',
      houseNumber: '',
      publicPlaceName: '',
      stairCaseNumber: '',
      zipCode: ''
    },
    phoneNumber: ''
  };

  constructor(
    private basketClient: BasketItemsClient,
    private ordersClient: OrdersClient,
    private toastrService: NbToastrService
  ) {
    this.basketItems$ = this.loadItems$.pipe(
      switchMap(() => this.basketClient.listItems()),
      tap(items => this.calculateSumValue(items))
    );
  }

  ngAfterViewInit() {
    this.loadItems$.next();
  }

  calculateSumValue(items: BasketItemListResponse[]) {
    this.sum = items.reduce((prev, curr) => prev + curr.quantity * curr.pricePerPiece, 0);
  }

  deleteItem(item: BasketItemListResponse) {
    this.basketClient.removeItem(item.id).subscribe(() => {
      this.loadItems$.next();
    });
  }

  changeQuantity(item: BasketItemListResponse, amount: number) {
    this.basketClient.editItem(item.id, new BasketItemEditCommand({
      id: item.id,
      productId: item.productId,
      quantity: item.quantity + amount
    })).subscribe(
      () => this.loadItems$.next(),
      () => this.toastrService.danger('Nem lehetett módosítani a termékmennyiséget. Lehetséges, hogy a termékből nincs elég készleten.', 'Hiba'));
  }

  deleteItems() {
    this.basketClient.removeItems().subscribe(() => this.loadItems$.next());
  }

  validityResult(result: boolean) {
    if (result) {
      this.createOrder();
    }
  }

  createOrder() {
    let addressStr = `${this.orderMetadata.address.zipCode} ${this.orderMetadata.address.cityName}, ${this.orderMetadata.address.publicPlaceName} ${this.orderMetadata.address.houseNumber}.`;
    if (this.orderMetadata.address.stairCaseNumber) {
      addressStr = addressStr.concat(` ${this.orderMetadata.address.stairCaseNumber} lépcsőház`);
    }
    if (this.orderMetadata.address.floor) {
      addressStr = addressStr.concat(` ${this.orderMetadata.address.floor}. emelet`);
    }
    if (this.orderMetadata.address.door) {
      addressStr = addressStr.concat(` ${this.orderMetadata.address.door}. ajtó`);
    }

    this.ordersClient.createOrder(new OrderCreateCommand({
      name: this.orderMetadata.name,
      phoneNumber: this.orderMetadata.phoneNumber,
      address: addressStr
    })).subscribe(() => {
      this.loadItems$.next();
      this.flipped = false;
      this.toastrService.success('Sikeresen megkaptuk a rendelést! Hamarosan e-mailben jelentkezünk a szállítási részletekkel.', 'Siker');
    });
  }
}
