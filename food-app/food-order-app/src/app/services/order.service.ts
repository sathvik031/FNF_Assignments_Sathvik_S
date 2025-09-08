import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Order } from '../models/order';
import { CartItem } from '../models/cart-item';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private orders: Order[] = [];
  private ordersSubject = new BehaviorSubject<Order[]>([]);
  public orders$ = this.ordersSubject.asObservable();

  constructor() {
    this.loadOrdersFromStorage();
  }

  createOrder(userName: string, cartItems: CartItem[], totalAmount: number): void {
    const order: Order = {
      order_id: this.generateOrderId(),
      user_name: userName,
      items: [...cartItems],
      total_amount: totalAmount,
      order_date: new Date(),
      status: 'Confirmed'
    };

    this.orders.push(order);
    this.saveOrdersToStorage();
    this.ordersSubject.next([...this.orders]);
  }

  getOrders(): Order[] {
    return this.orders;
  }

  private generateOrderId(): string {
    return 'ORD-' + Date.now().toString();
  }

  private saveOrdersToStorage(): void {
    localStorage.setItem('orders', JSON.stringify(this.orders));
  }

  private loadOrdersFromStorage(): void {
    const savedOrders = localStorage.getItem('orders');
    if (savedOrders) {
      this.orders = JSON.parse(savedOrders);
      this.ordersSubject.next([...this.orders]);
    }
  }
}