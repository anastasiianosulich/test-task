import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './customers/add-customer/add-customer.component';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { ViewProductComponent } from './products/view-product/view-product.component';
import { AddProductComponent } from './products/add-product/add-product.component';
import { AddProductToOrderComponent } from './order/add-product-to-order/add-product-to-order.component';
import { NewOrderComponent } from './order/new-order/new-order.component';
import { ViewOrdersComponent } from './order/view-orders/view-orders.component';
import { ViewOrderComponent } from './order/view-order/view-order.component';

const routes: Routes = [
  { path: '', redirectTo: 'customers', pathMatch: 'full' },
  { path: 'products', component: ProductsComponent },
  { path: 'products/add', component: AddProductComponent },
  { path: 'product/view/:id', component: ViewProductComponent },

  { path: 'customers', component: CustomersComponent },
  { path: 'customer/add', component: AddCustomerComponent },

  { path: 'orders/new', component: NewOrderComponent },
  { path: 'order/add-product', component: AddProductToOrderComponent },
  { path: 'orders', component: ViewOrdersComponent },
  { path: 'order/view/:id', component: ViewOrderComponent },

  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
