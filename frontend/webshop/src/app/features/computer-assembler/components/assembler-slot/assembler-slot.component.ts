import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { delay, switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse, ComputerAssemblerProductListResponse, ProvidedSocketQuery } from 'src/app/shared/clients';
import { SocketModel } from '../../models/socket.model';

@Component({
  selector: 'app-assembler-slot',
  templateUrl: './assembler-slot.component.html',
  styleUrls: ['./assembler-slot.component.scss']
})
export class AssemblerSlotComponent implements AfterViewInit {
  @Input() categories: CategoryListResponse[];
  @Input() sockets: SocketModel[];

  @Input() selectedCategoryId: string;
  @Input() selectedProduct: ComputerAssemblerProductListResponse;
  @Output() selectedProductChange = new EventEmitter<ComputerAssemblerProductListResponse>();
  @Output() selectedCategoryIdChange = new EventEmitter<string>();
  @Output() deleteThis = new EventEmitter<void>();

  loadProducts$ = new Subject<void>();
  products$: Observable<ComputerAssemblerProductListResponse[]>;

  constructor(private client: CategoriesClient) {
    this.products$ = this.loadProducts$.pipe(
      switchMap(() => this.client.listProductsForComputerAssembler(this.selectedCategoryId, this.sockets.filter(x => x.freeCount > 0)
        .map(x => new ProvidedSocketQuery({
          socketId: x.id,
          numberOfSocket: x.freeCount
        }))))
    );
  }

  ngAfterViewInit() {
    if (this.selectedCategoryId) {
      this.loadProducts$.next();
    }
  }

  selectCategory(categoryId: string) {
    this.loadProducts$.next();
    this.selectedCategoryIdChange.next(categoryId);
  }

  selectProduct(product: ComputerAssemblerProductListResponse) {
    this.selectedProduct = product;
    this.selectedProductChange.emit(product);
  }

  deselectProduct() {
    this.selectedProduct = null;
    this.selectedProductChange.emit(null);
    setTimeout(() => {
      this.loadProducts$.next();
    }, 1);
  }
}
