import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { CustomersModule } from './customers/customers.module';
import { ProductsModule } from './products/products.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatConfirmDialogComponent } from './shared/mat-confirm-dialog/mat-confirm-dialog.component';
import { AddProductToOrderComponent } from './order/add-product-to-order/add-product-to-order.component';
import { NewOrderComponent } from './order/new-order/new-order.component';
import { ViewOrdersComponent } from './order/view-orders/view-orders.component';
import { ViewOrderComponent } from './order/view-order/view-order.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    MatConfirmDialogComponent,
    AddProductToOrderComponent,
    NewOrderComponent,
    ViewOrdersComponent,
    ViewOrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DatePipe,
    CustomersModule,
    ProductsModule,
    MatDialogModule,
    MatIconModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
