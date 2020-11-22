import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { ControlContainer, NgForm } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { BasketItemListResponse } from 'src/app/shared/clients';
import { OrderMetadata } from '../../models/order-metadata.model';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.scss']
})
export class OrderCreateComponent implements AfterViewInit, OnDestroy {
  @Input() items: BasketItemListResponse[];
  @Input() sum: number;
  @Input() data: OrderMetadata;
  @Input() submit$: Observable<void>;
  @Output() validityChange = new EventEmitter<boolean>();

  @ViewChild('submit') submitButton: ElementRef<HTMLButtonElement>;

  subscription: Subscription;

  ngAfterViewInit(): void {
    this.subscription = this.submit$.subscribe(() => this.submitButton.nativeElement.click());
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  onSubmit(form: NgForm) {
    this.validityChange.emit(form.status === 'VALID');
  }
}
