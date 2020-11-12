import { Component } from '@angular/core';
import { NbMenuItem, NbThemeService } from '@nebular/theme';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  menuItems: NbMenuItem[] = [
    {
      title: 'Kezdőlap',
      icon: 'home-outline'
    },
    {
      title: "Számítógép összerakó",
      icon: 'settings-2-outline'
    },
    {
      title: 'TERMÉKEINK',
      group: true
    },
    {
      title: 'Alaplapok',
      icon: 'hard-drive-outline'
    },
    {
      title: 'Processzorok',
      icon: 'hard-drive-outline'
    },
    {
      title: 'Memóriák',
      icon: 'hard-drive-outline'
    },
    {
      title: 'Videókártyák',
      icon: 'hard-drive-outline'
    },
    {
      title: 'Tápegységek',
      icon: 'hard-drive-outline'
    },
    {
      title: 'Gépházak',
      icon: 'hard-drive-outline'
    },
    {
      title: "Monitorok",
      icon: 'hard-drive-outline'
    },
    {
      title: "Billentyűzetek",
      icon: 'hard-drive-outline'
    },
    {
      title: "Egerek",
      icon: 'hard-drive-outline'
    },
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
  ]

  constructor() {
  }
}
