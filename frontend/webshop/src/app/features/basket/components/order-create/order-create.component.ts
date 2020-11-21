import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BasketItemListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.scss']
})
export class OrderCreateComponent {
  @Input() items: BasketItemListResponse[];
  @Input() sum: number;

  @Input() name: string;
  @Output() nameChanged = new EventEmitter<string>();

  @Input() address: string;
  @Output() addressChanged = new EventEmitter<string>();

  @Input() phoneNumber: string;
  @Output() phoneNumberChanged = new EventEmitter<string>();
}
