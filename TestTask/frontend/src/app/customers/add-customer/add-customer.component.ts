import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerToSend } from 'src/app/models/customer';
import { CustomersService } from 'src/app/services/customers.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.scss'],
})
export class AddCustomerComponent implements OnInit {
  addCustomerForm = new FormGroup({
    name: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
  });

  constructor(
    private customersService: CustomersService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  addCustomer() {
    const formValues = this.addCustomerForm.value;

    this.customersService
      .addCustomer({
        ...formValues,
      } as unknown as CustomerToSend)
      .subscribe({
        next: () => {
          this.router.navigate(['/customers']);
        },
      });
  }

  getCurrentDate() {
    return new Date();
  }
}
