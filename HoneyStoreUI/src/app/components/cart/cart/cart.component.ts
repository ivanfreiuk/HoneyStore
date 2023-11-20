import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AuthenticationService, CartItemService } from '../../../services';
import { CartItem } from '../../../models';
import { CounterComponent } from '../../common/counter/counter.component';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,
    CounterComponent,
    MatDividerModule,
    MatIconModule,
    MatButtonModule, 
    MatToolbarModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  totalSum: number = 0;

  constructor(private authSvc: AuthenticationService,
    public cartSvc: CartItemService) {
  }

  onValueChange(value: number, item: CartItem) {
    item.quantity = value;

    this.cartSvc.update(item).subscribe();
    this.computeSum();
  }

  deleteItem(itemId: number) {
    this.cartSvc.delete(itemId).subscribe(() => {
      this.cartSvc.getItemsByUserId(this.authSvc.currentUserValue?.id).subscribe(data => {
        this.cartSvc.cartItemsValue = data;
        this.computeSum();
      });
    });
  }

  computeSum() {
    this.cartSvc.cartItemsValue.forEach((ci: CartItem) => this.totalSum += ci.quantity * ci.product.price);
  }
}
