import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { OAuthService } from 'angular-oauth2-oidc';
import { title } from 'process';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isLoggedIn = false;

  menuItems: NbMenuItem[] = [
    {
      title: 'Kategóriák',
      icon: 'grid-outline',
      link: '/categories'
    },
    {
      title: 'Csatlakozók',
      icon: 'swap-outline',
      link: '/sockets'
    },
    {
      title: 'Rendelések',
      icon: 'car-outline',
      link: '/orders'
    },
    {
      title: 'Felhasználókezelés',
      icon: 'people-outline',
      link: '/user-management'
    },
  ];
  constructor(
    private oauthService: OAuthService
  ) { }

  ngOnInit(): void {
    this.isLoggedIn = this.oauthService.hasValidAccessToken();
    console.log(this.isLoggedIn);
    if (!this.isLoggedIn) {
      this.oauthService.initCodeFlow();
    }
  }

}
