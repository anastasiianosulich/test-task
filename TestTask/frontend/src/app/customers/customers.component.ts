import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer';
import { CustomersService } from '../services/customers.service';
import { Router } from '@angular/router';
import { reloadComponent } from '../helpers/componentReload';
import { OrdersService } from '../services/orders.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  customers: Customer[] = [];

  constructor(
    private customersService: CustomersService,
    private ordersService: OrdersService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.customersService.getAllCustomers().subscribe({
      next: (customers) => {
        this.customers = customers;

        this.customers.forEach((c) => {
          this.ordersService.getCustomerOrders(c.id).subscribe({
            next: (orders) => {
              c.ordersCount = orders.length;
              c.ordersTotal = orders.reduce(
                (total, order) => total + order.total,
                0
              );
            },
          });
        });
      },
      error: (error) => console.log(error),
    });
  }

  deleteUser(id: number) {
    this.customersService.deleteCustomer(id).subscribe({
      next: () => {
        reloadComponent(this.router);
      },
    });
  }
}
