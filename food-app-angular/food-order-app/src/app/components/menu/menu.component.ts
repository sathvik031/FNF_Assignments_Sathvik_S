import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaurantService } from '../../services/restaurant.service';
import { CartService } from '../../services/cart.service';
import { Restaurant, MenuItem } from '../../models/restaurant';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit {
  restaurant: Restaurant | null = null;
  quantities: { [key: number]: number } = {};
  loading = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private restaurantService: RestaurantService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.loadRestaurant(id);
    }
  }

  loadRestaurant(id: number): void {
    this.loading = true;
    this.restaurantService.getRestaurants().subscribe({
      next: (data) => {
        this.restaurant = data.find(r => r.restaurant_id === id) || null;
        this.initializeQuantities();
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading restaurant:', error);
        this.loading = false;
      }
    });
  }

  initializeQuantities(): void {
    if (this.restaurant) {
      this.restaurant.menu.forEach(item => {
        this.quantities[item.item_id] = 1;
      });
    }
  }

  updateQuantity(itemId: number, change: number): void {
    const currentQuantity = this.quantities[itemId] || 1;
    const newQuantity = Math.max(1, currentQuantity + change);
    this.quantities[itemId] = newQuantity;
  }

  addToCart(item: MenuItem): void {
    const quantity = this.quantities[item.item_id] || 1;
    this.cartService.addToCart(item, quantity);
    alert(`${item.item_name} added to cart!`);
  }

  goToCart(): void {
    this.router.navigate(['/cart']);
  }

  goBack(): void {
    this.router.navigate(['/restaurants']);
  }
}