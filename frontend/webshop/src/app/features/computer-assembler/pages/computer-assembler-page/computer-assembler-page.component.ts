import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesClient, CategoryListResponse, ProvidedSocketQuery } from 'src/app/shared/clients';
import { ComputerAssemblerItem } from '../../models/computer-assembler.model';

@Component({
  selector: 'app-computer-assembler-page',
  templateUrl: './computer-assembler-page.component.html',
  styleUrls: ['./computer-assembler-page.component.scss']
})
export class ComputerAssemblerPageComponent implements OnInit {
  categories$: Observable<CategoryListResponse[]>;
  availableSockets: ProvidedSocketQuery[] = [];

  constructor(private client: CategoriesClient) {
    this.categories$ = this.client.listCategories();
  }

  ngOnInit(): void {
  }

}
