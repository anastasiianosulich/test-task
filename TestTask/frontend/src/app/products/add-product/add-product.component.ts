import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {
  ProductCategory,
  ProductItem,
  ProductSize,
} from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
})
export class AddProductComponent {
  productSizes: ProductSize[] = [];
  productCategories: ProductCategory[] = [];

  addProductForm = new FormGroup({
    productName: new FormControl('', Validators.required),
    categoryId: new FormControl('', Validators.required),
    sizeId: new FormControl('', Validators.required),
    availableQuantity: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    description: new FormControl('', Validators.required),
  });

  constructor(
    private productsService: ProductsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.productsService.getProductCategories().subscribe({
      next: (productCategories) => {
        this.productCategories = productCategories;
      },
    });

    this.productsService.getProductSizes().subscribe({
      next: (productSizes) => {
        this.productSizes = productSizes;
      },
    });
  }

  addProduct() {
    const formValues = this.addProductForm.value;

    this.productsService
      .addProduct({
        ...formValues,
        id: 0,
        createdAt: new Date().toISOString(),
      } as unknown as ProductItem)
      .subscribe({
        next: () => {
          this.router.navigate(['/products']);
        },
      });
  }
}
