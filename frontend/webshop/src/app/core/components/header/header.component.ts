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

  constructor(
    private themeService: NbThemeService,
    private oauthService: OAuthService
  ) { }

  ngOnInit() {
    this.isDarkTheme = localStorage.getItem('isDarkTheme') === 'true';
    this.onThemeSwitch();
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
}
