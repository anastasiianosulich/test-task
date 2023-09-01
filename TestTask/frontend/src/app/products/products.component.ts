import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { formatDateWithoutTime } from '../helpers/dateFormatter';
import { reloadComponent } from '../helpers/componentReload';
import { ProductsService } from '../services/products.service';
import { ProductCategory, ProductItem, ProductSize } from '../models/product';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  productItems: ProductItem[] = [];

  productSizes: ProductSize[] = [];
  productCategories: ProductCategory[] = [];

  constructor(
    private router: Router,
    private productsService: ProductsService,
    private dialogService: DialogService
  ) {}

  ngOnInit(): void {
    this.setProductCategories();
    this.setProductSizes();

    this.productsService.getAllProductItems().subscribe({
      next: (productItems) => {
        productItems.forEach((p) => {
          p.size = this.productSizes.find((s) => s.id === p.sizeId)?.name;
          p.category = this.productCategories.find(
            (c) => c.id === p.categoryId
          )?.name;
        });

        this.productItems = productItems;
      },
      error: (error) => console.log(error),
    });
  }

  deleteProduct(id: number) {
    this.dialogService
      .openConfirmDialog('Are you sure you want to delete this item?')
      .afterClosed()
      .subscribe((res) => {
        if (res) {
          this.productsService.deleteProductItem(id).subscribe({
            next: () => {
              this.router.navigate(['/products']);
            },
          });
        }
      });
  }

  private setProductCategories() {
    this.productsService.getProductCategories().subscribe({
      next: (productCategories) => {
        this.productCategories = productCategories;
      },
    });
  }

  private setProductSizes() {
    this.productsService.getProductSizes().subscribe({
      next: (productSizes) => {
        this.productSizes = productSizes;
      },
    });
  }
}
