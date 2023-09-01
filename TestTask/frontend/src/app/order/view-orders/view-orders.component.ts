import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from 'src/app/models/order';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-view-orders',
  templateUrl: './view-orders.component.html',
  styleUrls: ['./view-orders.component.scss'],
})
export class ViewOrdersComponent {
  orders: Order[] = [];

  constructor(private router: Router, private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.ordersService.getAllOrders().subscribe({
      next: (orders) => {
        orders.forEach((o) => {});

        this.orders = orders;
      },
      error: (error) => console.log(error),
    });
  }
}
