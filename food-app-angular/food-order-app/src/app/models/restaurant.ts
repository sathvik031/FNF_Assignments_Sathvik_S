export interface Restaurant {
  restaurant_id: number;
  restaurant_name: string;
  restaurant_address: string;
  restaurant_contact: string;
  menu: MenuItem[];
}

export interface MenuItem {
  item_id: number;
  item_name: string;
  item_price: number;
  item_photo: string;
}