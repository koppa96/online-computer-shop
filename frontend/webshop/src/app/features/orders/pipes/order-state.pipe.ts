import { Pipe, PipeTransform } from '@angular/core';
import { OrderState } from 'src/app/shared/clients';

@Pipe({
  name: 'orderState',
  pure: true
})
export class OrderStatePipe implements PipeTransform {

  transform(value: OrderState): string {
    switch (value) {
      case OrderState.Unsent:
        return 'Nincs kiszállítva';
      case OrderState.Sent:
        return 'Kiszállítva';
      case OrderState.Paid:
        return 'Kifizetve';
    }
  }

}
