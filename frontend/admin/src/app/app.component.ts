import { Component } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { title } from 'process';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  menuItems: NbMenuItem[] = [
    {
      title: 'Kategóriák'
    },
    {
      title: 'Termékek'
    },
    {
      title: 'Socketek'
    },
    {
      title: 'Rendelések'
    },
    {
      title: 'Felhasználókezelés'
    },
  ]
}
