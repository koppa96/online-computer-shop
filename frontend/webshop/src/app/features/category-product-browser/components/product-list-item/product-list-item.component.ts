import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.scss']
})
export class ProductListItemComponent implements OnChanges {
  @Input() item: ProductListResponse;
  @Input() isLoggedIn: boolean;
  @Output() cartButtonClicked = new EventEmitter<void>();

  tooltip: string;

  ngOnChanges(changes: SimpleChanges) {
    if (changes.item && changes.item.currentValue) {
      this.tooltip = changes.item.currentValue.quantity ? 'Kosárba tétel' : 'A termék nincs készleten';
    }
  }
}
