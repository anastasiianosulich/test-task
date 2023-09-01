import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Customer, CustomerToSend } from '../models/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + 'api/customers');
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl + `api/customers/${id}`);
  }

  addCustomer(customer: CustomerToSend): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl + 'api/customers', customer);
  }

  updateCustomer(id: number, customer: CustomerToSend): Observable<Customer> {
    return this.http.put<Customer>(
      this.baseUrl + 'api/customers/' + id,
      customer
    );
  }

  deleteCustomer(id: number) {
    return this.http.delete(this.baseUrl + 'api/customers/' + id);
  }
}
