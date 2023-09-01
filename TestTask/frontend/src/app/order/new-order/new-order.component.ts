import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Customer } from 'src/app/models/customer';
import { OrderItem, OrderToSend } from 'src/app/models/order';
import { CustomersService } from 'src/app/services/customers.service';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss'],
})
export class NewOrderComponent implements OnInit, OnDestroy {
  totalCost = 0;
  statuses: string[] = [];
  customers: Customer[] = [];
  items: OrderItem[] = [];
  private orderItemsSubscription: Subscription | undefined;

  addOrderForm = new FormGroup({
    customerId: new FormControl('', Validators.required),
    orderStatus: new FormControl('', Validators.required),
    comment: new FormControl(''),
  });

  constructor(
    private ordersService: OrdersService,
    private customersService: CustomersService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.orderItemsSubscription = this.ordersService.itemsArray$.subscribe(
      (orderItems) => {
        this.items = orderItems;
        this.calculateOrderTotal();
      }
    );

    this.items = this.ordersService.getOrderItemsFromLocalStorage();
    this.calculateOrderTotal();

    this.setStatuses();
    this.setCustomers();
  }

  ngOnDestroy() {
    this.orderItemsSubscription?.unsubscribe();
  }

  addOrder() {
    const formValues = this.addOrderForm.value;
    let orderItems = this.ordersService.getOrderItemsFromLocalStorage();

    let order = {
      customerId: formValues.customerId,
      status: formValues.orderStatus,
      comment: formValues.comment,
      orderItems: orderItems,
    } as unknown as OrderToSend;

    this.ordersService.addOrder(order).subscribe({});

    this.ordersService.clearOrderItems();
    this.router.navigate(['/orders']);
  }

  private setStatuses() {
    this.ordersService.getOrderStatuses().subscribe({
      next: (statuses) => {
        this.statuses = statuses;
      },
    });
  }

  private setCustomers() {
    this.customersService.getAllCustomers().subscribe({
      next: (customers) => {
        this.customers = customers;
      },
    });
  }

  private calculateOrderTotal() {
    this.totalCost = this.items.reduce(
      (accumulator, currentValue) =>
        accumulator + currentValue.quantity * currentValue.price,
      0
    );
  }

  onCancel() {
    this.ordersService.clearOrderItems();
  }
}
