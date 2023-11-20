import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CartItem } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class CartItemService {
  private apiUrl = `${environment.apiUrl}/api`;

  cartItemsValue: CartItem[] = [];
  totalSum: number = 0;

  constructor(private http: HttpClient) { }

  getAll(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(`${this.apiUrl}/cartitems`);
  }

  getItemsByUserId(userId: number | undefined): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(`${this.apiUrl}/cartitems/user/${userId}`);
  }

  getById(id: number): Observable<CartItem> {
    return this.http.get<CartItem>(`${this.apiUrl}/cartitems/` + id);
  }

  post(cartItem: CartItem): Observable<CartItem> {
    return this.http.post<CartItem>(`${this.apiUrl}/cartitems`, cartItem);
  }

  update(cartItem: CartItem) {
    return this.http.put(`${this.apiUrl}/cartitems/` + cartItem.id, cartItem);
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/cartitems/` + id);
  }
}
