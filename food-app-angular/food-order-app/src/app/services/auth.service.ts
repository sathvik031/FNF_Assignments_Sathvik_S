import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(this.hasToken());
  public isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor() {}

  private hasToken(): boolean {
    return !!localStorage.getItem('currentUser');
  }

  login(username: string, password: string): boolean {
    // Simple validation - in real app, validate against backend
    if (username && password) {
      localStorage.setItem('currentUser', JSON.stringify({ username, loginTime: new Date() }));
      this.isLoggedInSubject.next(true);
      return true;
    }
    return false;
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.isLoggedInSubject.next(false);
  }

  isAuthenticated(): boolean {
    return this.hasToken();
  }

  getCurrentUser(): string | null {
    const user = localStorage.getItem('currentUser');
    return user ? JSON.parse(user).username : null;
  }
}