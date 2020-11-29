import { Injectable } from '@angular/core';
import { Config } from '.';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  config: Config;
}
