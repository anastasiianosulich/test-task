import { NgModule } from '@angular/core';
import { CommonModule, DatePipe, DecimalPipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomersComponent } from './customers.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';

@NgModule({
  declarations: [CustomersComponent, AddCustomerComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    DecimalPipe,
    DatePipe,
  ],
  exports: [
    CustomersComponent,
    AddCustomerComponent,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class CustomersModule {}
