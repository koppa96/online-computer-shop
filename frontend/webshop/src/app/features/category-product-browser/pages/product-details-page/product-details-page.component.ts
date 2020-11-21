import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { map, switchMap, take } from 'rxjs/operators';
import { CommentCreateCommand, CommentResponse, ProductGetResponse, ProductsClient, PropertyValueResponse } from 'src/app/shared/clients';

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

  constructor(
    private client: ProductsClient,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngAfterViewInit(): void {
    this.loadProduct$.next();
  }

  ngOnInit(): void {
    this.productId = this.activatedRoute.snapshot.params.productId;
    this.product$ = this.loadProduct$.pipe(
      switchMap(() => this.client.getProduct(this.productId))
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
}
