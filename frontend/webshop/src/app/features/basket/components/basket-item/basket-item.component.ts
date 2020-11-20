import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BasketItemListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-basket-item',
  templateUrl: './basket-item.component.html',
  styleUrls: ['./basket-item.component.scss']
})
export class BasketItemComponent implements OnInit {
  @Input() item: BasketItemListResponse;
  @Output() deleteClicked = new EventEmitter<void>();
  @Output() increaseClicked = new EventEmitter<void>();
  @Output() decreaseClicked = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

}
