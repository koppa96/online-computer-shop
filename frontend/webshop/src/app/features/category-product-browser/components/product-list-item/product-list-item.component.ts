import { Component, Input, OnInit } from '@angular/core';
import { ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.scss']
})
export class ProductListItemComponent implements OnInit {
  @Input() item: ProductListResponse;

  constructor() { }

  ngOnInit(): void {
  }

}
