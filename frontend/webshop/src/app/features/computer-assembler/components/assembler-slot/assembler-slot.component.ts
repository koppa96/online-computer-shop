import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { merge, Observable, Subject } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse, ProductListResponse } from 'src/app/shared/clients';

@Component({
  selector: 'app-assembler-slot',
  templateUrl: './assembler-slot.component.html',
  styleUrls: ['./assembler-slot.component.scss']
})
export class AssemblerSlotComponent implements OnInit {
  @Input() category: CategoryListResponse;
  @Input() selectedSockets: string[];
  @Input() refreshList$: Observable<void>;

  @Output() productSelected = new EventEmitter<ProductListResponse>();

  products$: Observable<ProductListResponse[]>;
  init$ = new Subject<void>();
  selectedProduct: ProductListResponse;

  constructor(private client: CategoriesClient) { }

  ngOnInit() {
    this.products$ = merge(this.refreshList$, this.init$).pipe(
      switchMap(() => this.client.listProducts(this.category.id, this.selectedSockets))
    );
  }
}
