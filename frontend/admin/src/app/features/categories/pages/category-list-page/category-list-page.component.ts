import { AfterViewInit, Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse } from 'src/app/shared/clients';
import { RemoveConfirmDialogComponent } from 'src/app/shared/remove-confirm-dialog/remove-confirm-dialog.component';

@Component({
  selector: 'app-category-list-page',
  templateUrl: './category-list-page.component.html',
  styleUrls: ['./category-list-page.component.scss']
})
export class CategoryListPageComponent implements AfterViewInit {

  loadItems$: Subject<void>;
  categoryListItems$: Observable<CategoryListResponse[]>;


  constructor(
    private client: CategoriesClient,
    private dialogService: NbDialogService
  ) {
    this.loadItems$ = new Subject<void>();
    this.categoryListItems$ = this.loadItems$.pipe(
      switchMap(() => this.client.listCategories())
    );
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }

  onRemoveCategoryItem(categoryListItem: CategoryListResponse) {
    this.dialogService.open(RemoveConfirmDialogComponent)
      .onClose.subscribe(x => {
        if (x) {
          this.client.removeCategory(categoryListItem.id)
            .subscribe(() => {
              this.loadItems$.next();
            });
        }
      });
  }

}
