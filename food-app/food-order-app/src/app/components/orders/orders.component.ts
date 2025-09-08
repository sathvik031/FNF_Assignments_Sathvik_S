import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService } from '../../services/order.service';
import { AuthService } from '../../services/auth.service';
import { Order } from '../../models/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  currentUser: string | null = null;

  constructor(
    private orderService: OrderService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.currentUser = this.authService.getCurrentUser();
    this.loadOrders();
  }

  loadOrders(): void {
    this.orderService.orders$.subscribe(allOrders => {
      // Filter orders for current user
      this.orders = allOrders.filter(order => order.user_name === this.currentUser);
    });
  }

  continueShopping(): void {
    this.router.navigate(['/restaurants']);
  }
}