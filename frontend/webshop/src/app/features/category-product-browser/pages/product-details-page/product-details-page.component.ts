import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { CommentCreateCommand, ProductGetResponse, ProductsClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-product-details-page',
  templateUrl: './product-details-page.component.html',
  styleUrls: ['./product-details-page.component.scss']
})
export class ProductDetailsPageComponent implements OnInit {
  product: ProductGetResponse;
  commentText: string;

  constructor(
    private client: ProductsClient,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const productId = this.activatedRoute.snapshot.params.productId;
    this.client.getProduct(productId).subscribe(product => this.product = product);
  }

  sendComment() {
    this.client.createComment(this.product.id, new CommentCreateCommand({
      productId: this.product.id,
      text: this.commentText
    })).subscribe(() => {
      this.client.getProduct(this.product.id).subscribe(product => this.product = product);
    });
  }
}
