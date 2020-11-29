import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { BasketItemAddCommand, BasketItemsClient, CommentCreateCommand, ProductGetResponse, ProductsClient } from 'src/app/shared/clients';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product-details-page',
  templateUrl: './product-details-page.component.html',
  styleUrls: ['./product-details-page.component.scss']
})
export class ProductDetailsPageComponent implements OnInit, AfterViewInit {
  loadProduct$ = new Subject<void>();
  product$: Observable<ProductGetResponse>;
  commentText: string;
  productId: string;
  product: ProductGetResponse;
  tooltip: string;

  constructor(
    private client: ProductsClient,
    private activatedRoute: ActivatedRoute,
    private basketItemsClient: BasketItemsClient,
    private toastrService: NbToastrService,
    private location: Location
  ) { }

  ngAfterViewInit(): void {
    this.loadProduct$.next();
  }

  ngOnInit(): void {
    this.productId = this.activatedRoute.snapshot.params.productId;
    this.product$ = this.loadProduct$.pipe(
      switchMap(() => this.client.getProduct(this.productId)),
      tap(product => this.product = product),
      tap(product => this.tooltip = product.quantity === 0 ? 'A termék nincs készleten' : 'Kosárba tétel')
    );
  }

  sendComment() {
    this.client.createComment(this.productId, new CommentCreateCommand({
      productId: this.productId,
      text: this.commentText
    })).subscribe(() => {
      this.commentText = '';
      this.loadProduct$.next();
    });
  }

  addToCart() {
    this.basketItemsClient.addItem(new BasketItemAddCommand({
      productId: this.product.id,
      quantity: 1
    })).subscribe(
      () => this.toastrService.success(`A termék: ${this.product.name} sikeresen hozzá lett adva a kosaradhoz.`, 'Siker'),
      () => this.toastrService.danger('Nem sikerült a terméket kosárba helyezni. Lehetséges hogy már nincs készleten.', 'Hiba'));
  }

  navigateBack() {
    this.location.back();
  }
}
