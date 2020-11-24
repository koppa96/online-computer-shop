import { Pipe, PipeTransform } from '@angular/core';
import { OrderState } from 'src/app/shared/clients';

@Pipe({
  name: 'orderStateToString'
})
export class OrderStateToStringPipe implements PipeTransform {

  transform(value: OrderState): string {
    switch (value) {
      case 0: {
        return 'Nincs kiszállítva';
      }
      case 1: {
        return 'Kiszállítva';
      }
      case 2: {
        return 'Kifizetve';
      }
    }
  }

}
