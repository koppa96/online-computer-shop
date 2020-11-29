import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbMenuModule, NbDialogModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { OAuthModule, OAuthService } from 'angular-oauth2-oidc';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { API_BASE_URL } from './shared/clients';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { Config } from './core/config';
import { ConfigService } from './core/config/config.service';

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
      useSilentRefresh: true
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
    AppRoutingModule,
    BrowserAnimationsModule,
    NbSidebarModule.forRoot(),
    NbThemeModule.forRoot({ name: 'default' }),
    NbMenuModule.forRoot(),
    NbDialogModule.forRoot(),
    NbLayoutModule,
    NbEvaIconsModule,
    OAuthModule.forRoot(),
    HttpClientModule
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
