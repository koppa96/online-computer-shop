import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-basket-footer',
  templateUrl: './basket-footer.component.html',
  styleUrls: ['./basket-footer.component.scss']
})
export class BasketFooterComponent implements OnInit {
  @Input() sum: number;
  @Output() orderClicked = new EventEmitter<void>();
  @Output() deleteItemsClicked = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

}
