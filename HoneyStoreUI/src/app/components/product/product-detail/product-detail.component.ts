import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentComponent } from '../../comment/comment/comment.component';
import { AuthenticationService, CartItemService, CommentService, ProductService } from '../../../services';
import { CartItem, Product, Comment } from '../../../models';
import { ActivatedRoute } from '@angular/router';
import { CounterComponent } from '../../common/counter/counter.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatTabsModule } from '@angular/material/tabs';
import { MatBadgeModule } from '@angular/material/badge';
import { FileHelper } from '../../../helpers';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule,
    CounterComponent,
    CommentComponent,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatDividerModule,
    MatTabsModule,
    MatBadgeModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent {
  currentProduct: Product = new Product();
  productId: number = 0;
  productComments: Comment[] = [];
  cartItem: CartItem = new CartItem();
  quantity: number = 1;
  imageURL: any = null;

  constructor(private productSvc: ProductService,
    private authSvc: AuthenticationService,
    private cartSvc: CartItemService,
    private commentSvc: CommentService,
    private fileHelper: FileHelper,
    private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.productId = params['id'];
    });

    this.commentSvc.getCommentsByProductId(this.productId).subscribe(data => {
      this.productComments = data;
    });

    this.productSvc.getById(this.productId).subscribe(
      data => {
        this.currentProduct = data;        
        this.imageURL = this.fileHelper.getImageSafeURL(this.currentProduct.productPhoto.fileBytes, this.currentProduct.productPhoto.fileName);
      },
      error => {
        if (error.status == 401) {
          // TODO
          this.productComments.length
        }
      });
  }

  onQuantityChanged(value: number) {
    this.quantity = value;
  }

  onCommentsChanged(event: Event) {
    this.commentSvc.getCommentsByProductId(this.productId).subscribe(data => {
      this.productComments = data;
    });
  }

  addToCart(productId: number) {
    this.cartSvc.getItemsByUserId(this.authSvc.currentUserValue?.id).subscribe(data => {
      let cartItems: CartItem[] = data;
      let cartItem: CartItem = cartItems.filter(i => i.productId === productId)[0];
      if (cartItem) {
        cartItem.quantity+=this.quantity;
        this.cartSvc.update(cartItem).subscribe();
      } else {
        cartItem = this.createCartItem(productId);
        this.cartSvc.post(cartItem).subscribe();
      }
    })
  }

  private createCartItem(productId: number): CartItem {
    const cartItem = new CartItem();
    cartItem.productId = productId;
    cartItem.userId = this.authSvc.currentUserValue?.id;
    cartItem.isOrdered = false;
    cartItem.createdOn = new Date(Date.now());
    cartItem.quantity = this.quantity;
    return cartItem;
  }
}
