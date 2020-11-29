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
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OAuthModule, OAuthService } from 'angular-oauth2-oidc';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { ConfigService } from './core/config/config.service';
import { Config } from './core/config';

export function initializeApp(
  http: HttpClient,
  oauthService: OAuthService,
  configService: ConfigService
) {
  return async () => {
    configService.config = await http.get<Config>('assets/config.json').toPromise();

    oauthService.configure({
      clientId: configService.config.oauth.clientId,
      issuer: configService.config.oauth.issuer,
      postLogoutRedirectUri: window.location.origin,
      redirectUri: window.location.origin,
      requireHttps: true,
      responseType: configService.config.oauth.responseType,
      scope: configService.config.oauth.scope,
      useSilentRefresh: true,
      skipIssuerCheck: true
    });
    oauthService.setupAutomaticSilentRefresh();
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
      useFactory: (configService: ConfigService) => {
        return configService.config.apiBaseUrl;
      },
      deps: [ConfigService],
      multi: false
    },
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [HttpClient, OAuthService, ConfigService],
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
