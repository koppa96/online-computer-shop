import { Component } from '@angular/core';
import { NbMenuItem, NbThemeService } from '@nebular/theme';
import { merge, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CategoriesClient, CategoryListResponse } from './shared/clients';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  menuItems$: Observable<NbMenuItem[]>;
  topMenuItems: NbMenuItem[] = [
    {
      title: 'Kezdőlap',
      icon: 'home-outline',
      link: '/'
    },
    {
      title: "Számítógép összerakó",
      icon: 'settings-2-outline',
      link: '/computer-assembler'
    },
    {
      title: 'TERMÉKEINK',
      group: true
    }
  ];
  bottomMenuItems: NbMenuItem[] = [
    {
      title: "EGYÉB",
      group: true
    },
    {
      title: 'Elérhetőségek',
      icon: 'email-outline'
    },
    {
      title: 'Garancia',
      icon: 'file-text-outline'
    }
  ];

  constructor(categoriesClient: CategoriesClient) {
    this.menuItems$ = merge(of([]), categoriesClient.listCategories().pipe(
      map(categories => this.topMenuItems.concat(categories.map(x => ({
        title: x.name,
        icon: 'hard-drive-outline',
        data: {
          categoryId: x.id
        }
      }))).concat(this.bottomMenuItems))
    ));
  }
}
