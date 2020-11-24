import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { merge, Observable, Subject } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse, ComputerAssemblerProductListResponse, ProductListResponse, ProvidedSocketQuery } from 'src/app/shared/clients';

@Component({
  selector: 'app-assembler-slot',
  templateUrl: './assembler-slot.component.html',
  styleUrls: ['./assembler-slot.component.scss']
})
export class AssemblerSlotComponent implements OnInit {
  @Input() categories: CategoryListResponse[];
  @Input() availableSockets: ProvidedSocketQuery[];

  @Output() productSelected = new EventEmitter<ComputerAssemblerProductListResponse>();

  selectedProduct: ComputerAssemblerProductListResponse;
  selectedCategoryId: string;
  loadProducts$ = new Subject<void>();
  products$: Observable<ComputerAssemblerProductListResponse[]>;

  constructor(private client: CategoriesClient) {
    this.products$ = this.loadProducts$.pipe(
      switchMap(() => this.client.listProductsForComputerAssembler(this.selectedCategoryId, this.availableSockets))
    );
  }

  ngOnInit() {

  }
}
