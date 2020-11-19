import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbMenuModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { OAuthModule, OAuthService } from 'angular-oauth2-oidc';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { API_BASE_URL } from './shared/clients';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';

export function initializeAuthentication(oauthService: OAuthService) {
  return () => {
    oauthService.configure({
      clientId: 'admin',
      issuer: 'https://localhost:5101',
      postLogoutRedirectUri: window.location.origin,
      redirectUri: window.location.origin,
      requireHttps: false,
      responseType: 'code',
      scope: 'openid profile adminapi.readwrite',
      useSilentRefresh: true
    });
    return oauthService.loadDiscoveryDocumentAndTryLogin();
  };
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    CoreModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbSidebarModule.forRoot(),
    NbThemeModule.forRoot({ name: 'default' }),
    NbMenuModule.forRoot(),
    NbLayoutModule,
    NbEvaIconsModule,
    OAuthModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: 'https://localhost:5001'
    },
    {
      provide: APP_INITIALIZER,
      useFactory: initializeAuthentication,
      deps: [OAuthService],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
