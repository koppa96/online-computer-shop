import { Component } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
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
      link: '/home'
    },
    {
      title: 'Számítógép összerakó',
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
      title: 'EGYÉB',
      group: true
    },
    {
      title: 'Elérhetőségek',
      icon: 'email-outline',
      link: '/contact'
    },
    {
      title: 'Garancia',
      icon: 'file-text-outline',
      link: '/warranty'
    }
  ];

  constructor(categoriesClient: CategoriesClient) {
    this.menuItems$ = categoriesClient.listCategories().pipe(
      startWith([] as CategoryListResponse[]),
      map(categories => this.topMenuItems.concat(categories.map(x => ({
        title: x.name,
        icon: 'hard-drive-outline',
        link: ['categories', x.id, 'products'] as any
      }))).concat(this.bottomMenuItems))
    );
  }
}
