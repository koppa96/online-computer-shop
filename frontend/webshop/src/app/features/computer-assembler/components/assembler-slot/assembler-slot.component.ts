import { AfterViewChecked, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { merge, Observable, Subject } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse, ComputerAssemblerProductListResponse, ProductListResponse, ProductSocketResponse, ProvidedSocketQuery } from 'src/app/shared/clients';
import { SocketModel } from '../../models/socket.model';

@Component({
  selector: 'app-assembler-slot',
  templateUrl: './assembler-slot.component.html',
  styleUrls: ['./assembler-slot.component.scss']
})
export class AssemblerSlotComponent implements OnInit {
  @Input() categories: CategoryListResponse[];
  @Input() sockets: SocketModel[];

  @Input() selectedProduct: ComputerAssemblerProductListResponse;
  @Output() selectedProductChange = new EventEmitter<ComputerAssemblerProductListResponse>();
  @Output() deleteThis = new EventEmitter<void>();

  selectedCategoryId: string;
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

  ngOnInit() {

  }

  selectProduct(product: ComputerAssemblerProductListResponse) {
    this.selectedProduct = product;
    this.selectedProductChange.emit(product);
  }

  deselectProduct() {
    this.selectedProduct = null;
    this.selectedProductChange.emit(null);
  }
}
