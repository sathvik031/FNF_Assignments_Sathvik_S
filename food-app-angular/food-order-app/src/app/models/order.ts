import { CartItem } from './cart-item';

export interface Order {
  order_id: string;
  user_name: string;
  items: CartItem[];
  total_amount: number;
  order_date: Date;
  status: string;
}