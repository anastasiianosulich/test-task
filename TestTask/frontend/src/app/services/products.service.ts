import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {
  Product,
  ProductCategory,
  ProductItem,
  ProductSize,
} from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllProductItems(): Observable<ProductItem[]> {
    return this.http.get<ProductItem[]>(this.baseUrl + 'api/products/items');
  }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'api/products');
  }

  getProductItems(
    productName: string,
    categoryId: string
  ): Observable<ProductItem[]> {
    return this.http.get<ProductItem[]>(
      this.baseUrl +
        `api/products/items?productName=${productName}&categoryId${categoryId}`
    );
  }

  getProductItemById(id: number): Observable<ProductItem> {
    return this.http.get<ProductItem>(
      this.baseUrl + `api/products/items/${id}`
    );
  }

  addProduct(product: ProductItem): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'api/products', product);
  }

  deleteProductItem(id: number) {
    return this.http.delete(this.baseUrl + 'api/products/items/' + id);
  }

  getProductSizes(): Observable<ProductSize[]> {
    return this.http.get<ProductSize[]>(this.baseUrl + 'api/products/sizes');
  }

  getProductCategories(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(
      this.baseUrl + 'api/products/categories'
    );
  }
}
