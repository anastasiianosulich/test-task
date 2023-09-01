export interface Customer {
  id: number;
  name: string;
  address: string;
  ordersTotal: number;
  ordersCount: number;
}

export interface OrdersForCustomerRequest {}

export interface CustomerToSend {
  name: string;
  address: string;
}
