import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesClient, CategoryListResponse } from 'src/app/shared/clients';
import { ComputerAssemblerItem } from '../../models/computer-assembler.model';

@Component({
  selector: 'app-computer-assembler-page',
  templateUrl: './computer-assembler-page.component.html',
  styleUrls: ['./computer-assembler-page.component.scss']
})
export class ComputerAssemblerPageComponent implements OnInit {
  mandatoryItems: ComputerAssemblerItem[] = [];
  optionalItems: ComputerAssemblerItem[] = [];
  selectedOrder: number;
  highestOrder: number;

  constructor(private client: CategoriesClient) {
    this.client.listCategories().subscribe(result => {
      this.mandatoryItems = result.filter(x => x.configuratorOrder)
        .map(x => ({
          category: x,
          chosenProduct: null
        })).sort((x, y) => x.category.configuratorOrder - y.category.configuratorOrder);

      this.selectedOrder = 0;
      this.highestOrder = this.mandatoryItems[this.mandatoryItems.length - 1]?.category.configuratorOrder || 0;

      this.optionalItems = result.filter(x => !x.configuratorOrder)
        .map(x => ({
          category: x,
          chosenProduct: null
        }));
    });
  }

  ngOnInit(): void {
  }

}
