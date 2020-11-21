import { Component, OnInit } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isDarkTheme = false;
  isLoggedIn = false;
  userName: string;
  email: string;

  constructor(
    private themeService: NbThemeService,
    private oauthService: OAuthService
  ) { }

  ngOnInit() {
    this.isDarkTheme = localStorage.getItem('isDarkTheme') === 'true';
    this.onThemeSwitch();

    if (this.oauthService.hasValidAccessToken()) {
      this.isLoggedIn = true;
      const token = this.oauthService.getAccessToken();
      const content = JSON.parse(atob(token.split('.')[1]));

      this.userName = content.userName;
      this.email = content.email;
    }
  }

  onThemeSwitch() {
    if (!this.isDarkTheme) {
      this.themeService.changeTheme('default');
    } else {
      this.themeService.changeTheme('dark');
    }
    localStorage.setItem('isDarkTheme', this.isDarkTheme.toString());
  }

  onLogin() {
    this.oauthService.initCodeFlow();
  }

  onLogout() {
    this.oauthService.logOut();
  }
}
