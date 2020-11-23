import { Component, Input } from '@angular/core';
import { SocketListResponse } from 'src/app/shared/clients';
import { CategoryEditCreateModel, PropertyModel } from '../../models/category-create-edit.model';

@Component({
  selector: 'app-create-edit-category',
  templateUrl: './create-edit-category.component.html',
  styleUrls: ['./create-edit-category.component.scss']
})
export class CreateEditCategoryComponent {

  @Input() category: CategoryEditCreateModel;
  @Input() sockets: SocketListResponse[];

  constructor() {

  }

  onAddProperty() {
    this.category.properties.push({ name: '' });
  }

  onDeleteProperty(property: PropertyModel) {
    this.category.properties = this.category.properties.filter(
      x => x !== property
    );
  }

}
