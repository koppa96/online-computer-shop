import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryCreateCommand, SocketListResponse, SocketsClient } from 'src/app/shared/clients';
import { CategoryEditCreateModel } from '../../models/category-create-edit.model';

@Component({
  selector: 'app-new-category-page',
  templateUrl: './new-category-page.component.html',
  styleUrls: ['./new-category-page.component.scss']
})
export class NewCategoryPageComponent implements AfterViewInit {

  category: CategoryEditCreateModel = {
    name: '',
    socketIds: [],
    properties: []
  };

  loadItems$: Subject<void>;
  socketItems$: Observable<SocketListResponse[]>;

  constructor(
    private socketsClient: SocketsClient,
    private categoriesClient: CategoriesClient,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.loadItems$ = new Subject<void>();
    this.socketItems$ = this.loadItems$.pipe(
      switchMap(() => this.socketsClient.listSockets())
    );
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }


  onSave() {
    this.categoriesClient.createCategory(
      new CategoryCreateCommand({
        name: this.category.name,
        propertyTypes: this.category.properties.map(x => x.name),
        socketIds: this.category.socketIds
      })
    ).subscribe(x => this.router.navigate(['..'], { relativeTo: this.activatedRoute }));
  }

}
