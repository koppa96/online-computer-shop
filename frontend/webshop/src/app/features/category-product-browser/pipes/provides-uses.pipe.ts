import { Pipe, PipeTransform } from '@angular/core';
import { ProvidesUses } from 'src/app/shared/clients';

@Pipe({
  name: 'providesUses',
  pure: true
})
export class ProvidesUsesPipe implements PipeTransform {
  transform(value: ProvidesUses): string {
    return value === ProvidesUses.Provides ? 'Nyújtja' : 'Használja';
  }
}
