import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/restaurants']);
    }
  }

  onLogin(): void {
    if (this.authService.login(this.username, this.password)) {
      this.router.navigate(['/restaurants']);
    } else {
      this.errorMessage = 'Please enter valid credentials';
    }
  }
}