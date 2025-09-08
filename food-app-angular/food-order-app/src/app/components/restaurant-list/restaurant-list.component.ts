import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestaurantService } from '../../services/restaurant.service';
import { Restaurant } from '../../models/restaurant';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html'
})
export class RestaurantListComponent implements OnInit {
  restaurants: Restaurant[] = [];
  loading = false;

  constructor(
    private restaurantService: RestaurantService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadRestaurants();
  }

  loadRestaurants(): void {
    this.loading = true;
    this.restaurantService.getRestaurants().subscribe({
      next: (data) => {
        this.restaurants = data;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading restaurants:', error);
        this.loading = false;
      }
    });
  }

  selectRestaurant(restaurantId: number): void {
    this.router.navigate(['/menu', restaurantId]);
  }
}