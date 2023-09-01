export interface OrderItem {
  productId: number;
  productName: string;
  size: string;
  category: string;
  price: number;
  quantity: number;
}

export interface Order {
  id: number;
  creationDate: string;
  customerName: string;
  customerAddress: string;
  status: string;
  comment: string;
  total: number;
  orderItems: OrderItem[];
}

export interface OrderToSend {
  customerId: number;
  status: string;
  comment: string;
  orderItems: OrderItem[];
}

export interface OrderItemToSend {
  productId: number;
  size: string;
  quantity: number;
}

export const TaskStatusValues = [
  { displayName: 'To Do', value: 0 },
  { displayName: 'In Progress', value: 1 },
  { displayName: 'Done', value: 2 },
  { displayName: 'Canceled', value: 3 },
];
