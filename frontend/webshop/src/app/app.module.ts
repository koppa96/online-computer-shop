import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbMenuModule, NbToastrModule, NbDialogModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { API_BASE_URL } from './shared/clients';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OAuthModule, OAuthService } from 'angular-oauth2-oidc';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';

export function initializeAuthentication(oauthService: OAuthService) {
  return () => {
    oauthService.configure({
      clientId: 'webshop',
      issuer: 'https://localhost:5101',
      postLogoutRedirectUri: window.location.origin,
      redirectUri: window.location.origin,
      requireHttps: false,
      responseType: 'code',
      scope: 'openid profile webshopapi.readwrite',
      useSilentRefresh: true
    });
    return oauthService.loadDiscoveryDocumentAndTryLogin();
  };
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CoreModule,
    SharedModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule.forRoot(),
    NbThemeModule.forRoot({ name: 'default' }),
    NbMenuModule.forRoot(),
    OAuthModule.forRoot(),
    NbToastrModule.forRoot(),
    NbDialogModule.forRoot()
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
