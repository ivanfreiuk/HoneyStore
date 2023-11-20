import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { CartItem, Product } from '../../../models';
import { AuthenticationService, CartItemService } from '../../../services';
import { Router } from '@angular/router';
import { FileHelper } from '../../../helpers';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [CommonModule, 
  MatCardModule,
  MatIconModule,
  MatButtonModule,
  MatDividerModule],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css'
})
export class ProductCardComponent implements OnInit {

  @Input() product: Product = new Product();
  public imageURL: any = null;

  constructor(private fileHelper: FileHelper,
    private cartSvc: CartItemService, 
    private authSvc: AuthenticationService, 
    private router: Router) { 
    
  }

  ngOnInit() {
    console.log(this.product);
    this.imageURL = this.fileHelper.getImageSafeURL(this.product.productPhoto.fileBytes, this.product.productPhoto.fileName);
  }

  showDetail(productId: number) {
    this.router.navigate([`/detail/${productId}`]);
  }

  addToCart(productId: number) {
    this.cartSvc.getItemsByUserId(this.authSvc.currentUserValue?.id).subscribe(data => {
      let cartItems: CartItem[] = data;
      let cartItem: CartItem = cartItems.filter(i => i.productId === productId)[0];
      if (cartItem) {
        cartItem.quantity++;
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
    cartItem.quantity = 1;
    return cartItem;
  }
}
