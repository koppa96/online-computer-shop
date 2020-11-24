import { Component, Input } from '@angular/core';
import { CategorySocketGetResponse } from 'src/app/shared/clients';
import { ProductEditCreateModel, ProductSocketEditCreateModel } from '../../models/product-create-edit.model';

@Component({
  selector: 'app-create-edit-product',
  templateUrl: './create-edit-product.component.html',
  styleUrls: ['./create-edit-product.component.scss']
})
export class CreateEditProductComponent {

  @Input() product: ProductEditCreateModel;
  @Input() sockets: CategorySocketGetResponse[];

  constructor() { }

  onDeleteProductSocket(productSocket: ProductSocketEditCreateModel) {
    this.product.productSockets = this.product.productSockets.filter(x => x !== productSocket);
  }

  onAddProductSocket() {
    this.product.productSockets.push({
      socketId: '',
      name: '',
      numberOfSocket: 0,
      providesUses: 0
    });
  }



}
