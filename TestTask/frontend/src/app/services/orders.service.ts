import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { Order, OrderItem, OrderToSend } from '../models/order';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  baseUrl = environment.apiUrl;
  orderItems: OrderItem[] = [];

  orderItemsKey = 'orderItems';
  private orderItemsSubject = new BehaviorSubject<OrderItem[]>(this.orderItems);

  itemsArray$ = this.orderItemsSubject.asObservable();

  constructor(private http: HttpClient) {}

  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.baseUrl + 'api/orders');
  }

  getCustomerOrders(customerId: number): Observable<Order[]> {
    return this.http.get<Order[]>(
      this.baseUrl + `api/orders/customerOrders/${customerId}`
    );
  }

  getOrderById(id: number): Observable<Order> {
    return this.http.get<Order>(this.baseUrl + `api/orders/${id}`);
  }

  getOrderStatuses(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + `api/orders/statuses`);
  }

  addOrder(order: OrderToSend): Observable<Order> {
    return this.http.post<Order>(this.baseUrl + 'api/orders', order);
  }

  deleteOrder(id: number) {
    return this.http.delete(this.baseUrl + 'api/orders/' + id);
  }

  addOrderItem(orderItem: OrderItem) {
    const items = this.getOrderItemsFromLocalStorage();
    items.push(orderItem);
    this.setOrdersToLocalStorage(items);

    this.orderItemsSubject.next(this.getOrderItemsFromLocalStorage());
  }

  getOrderItemsFromLocalStorage(): OrderItem[] {
    const data = localStorage.getItem(this.orderItemsKey);
    if (data) {
      const orderItems = JSON.parse(data);
      return orderItems;
    }
    return [];
  }

  setOrdersToLocalStorage(items: OrderItem[]) {
    localStorage.setItem(this.orderItemsKey, JSON.stringify(items));
  }

  clearOrderItems() {
    localStorage.removeItem(this.orderItemsKey);

    this.orderItemsSubject.next([]);
  }
}
