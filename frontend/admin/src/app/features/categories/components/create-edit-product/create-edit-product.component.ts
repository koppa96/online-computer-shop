import { Component, Input, OnInit } from '@angular/core';
import { CategorySocketGetResponse } from 'src/app/shared/clients';
import { ProductEditCreateModel } from '../../models/product-create-edit.model';

@Component({
  selector: 'app-create-edit-product',
  templateUrl: './create-edit-product.component.html',
  styleUrls: ['./create-edit-product.component.scss']
})
export class CreateEditProductComponent implements OnInit {

  @Input() product: ProductEditCreateModel;
  @Input() sockets: CategorySocketGetResponse[];

  constructor() { }

  ngOnInit(): void {
    console.log(this.product);
  }


}
