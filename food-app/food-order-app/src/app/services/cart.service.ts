import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartItem } from '../models/cart-item';
import { MenuItem } from '../models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems: CartItem[] = [];
  private cartSubject = new BehaviorSubject<CartItem[]>([]);
  public cart$ = this.cartSubject.asObservable();

  constructor() {}

  addToCart(menuItem: MenuItem, quantity: number): void {
    const existingItem = this.cartItems.find(item => item.item_id === menuItem.item_id);
    
    if (existingItem) {
      existingItem.quantity += quantity;
      existingItem.subtotal = existingItem.quantity * existingItem.item_price;
    } else {
      const cartItem: CartItem = {
        item_id: menuItem.item_id,
        item_name: menuItem.item_name,
        item_price: menuItem.item_price,
        quantity: quantity,
        subtotal: menuItem.item_price * quantity
      };
      this.cartItems.push(cartItem);
    }
    
    this.cartSubject.next([...this.cartItems]);
  }

  updateQuantity(itemId: number, quantity: number): void {
    const item = this.cartItems.find(item => item.item_id === itemId);
    if (item) {
      if (quantity <= 0) {
        this.removeFromCart(itemId);
      } else {
        item.quantity = quantity;
        item.subtotal = item.quantity * item.item_price;
        this.cartSubject.next([...this.cartItems]);
      }
    }
  }

  removeFromCart(itemId: number): void {
    this.cartItems = this.cartItems.filter(item => item.item_id !== itemId);
    this.cartSubject.next([...this.cartItems]);
  }

  getCartItems(): CartItem[] {
    return this.cartItems;
  }

  getTotalPrice(): number {
    return this.cartItems.reduce((total, item) => total + item.subtotal, 0);
  }

  clearCart(): void {
    this.cartItems = [];
    this.cartSubject.next([]);
  }

  getCartItemCount(): number {
    return this.cartItems.reduce((total, item) => total + item.quantity, 0);
  }
}