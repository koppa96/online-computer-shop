export interface OAuthConfig {
  clientId: string;
  issuer: string;
  responseType: string;
  scope: string;
}

export interface Config {
  apiBaseUrl: string;
  oauth: OAuthConfig;
}
