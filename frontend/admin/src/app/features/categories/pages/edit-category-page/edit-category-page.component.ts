import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CategoriesClient, CategoryEditCommand, CategoryGetResponse, CategorySocketEditCommand, PropertyTypeEditCommand, SocketListResponse, SocketsClient } from 'src/app/shared/clients';
import { CategoryEditCreateModel, PropertyModel } from '../../models/category-create-edit.model';

@Component({
  selector: 'app-edit-category-page',
  templateUrl: './edit-category-page.component.html',
  styleUrls: ['./edit-category-page.component.scss']
})
export class EditCategoryPageComponent implements AfterViewInit {

  category: CategoryEditCreateModel = {
    name: '',
    properties: [],
    socketIds: []
  };

  loadItems$: Subject<void>;
  socketItems$: Observable<SocketListResponse[]>;
  categoryItem$: Observable<CategoryGetResponse>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private categoriesClient: CategoriesClient,
    private socketsClient: SocketsClient
  ) {
    const categoryId = this.activatedRoute.snapshot.paramMap.get('id');
    this.loadItems$ = new Subject<void>();
    this.socketItems$ = this.loadItems$.pipe(
      switchMap(() => this.socketsClient.listSockets())
    );
    this.categoryItem$ = this.loadItems$.pipe(
      switchMap(() => this.categoriesClient.getCategory(categoryId))
    );
    this.categoryItem$.subscribe(x => {
      if (x) {
        this.category = {
          id: x.id ? x.id : null,
          name: x.name ? x.name : null,
          properties: x.propertyTypes.map(p => {
            return { id: p.id, name: p.name } as PropertyModel;
          }),
          socketIds: x.categorySockets.map(p => p.socketId)
        };
      }
    });
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }

  onSave() {
    this.categoriesClient.editCategory(
      this.category.id,
      new CategoryEditCommand({
        id: this.category.id,
        name: this.category.name,
        categorySockets: this.category.socketIds.map(x => new CategorySocketEditCommand({
          socketId: x
        })),
        propertyTypes: this.category.properties.map(x => new PropertyTypeEditCommand({
          id: x.id,
          name: x.name
        })
        )
      })
    ).subscribe(x => this.router.navigate(['../..'], { relativeTo: this.activatedRoute }));

  }

}
