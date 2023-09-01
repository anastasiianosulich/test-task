import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { formatDateWithoutTime } from 'src/app/helpers/dateFormatter';
import {
  ProductCategory,
  ProductItem,
  ProductSize,
} from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.scss'],
})
export class ViewProductComponent implements OnInit {
  productItem: ProductItem | undefined = undefined;
  productCategories: ProductCategory[] = [];
  productSizes: ProductSize[] = [];

  constructor(
    private route: ActivatedRoute,
    private productsService: ProductsService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.setProductItem(+id);
        }
      },
    });
  }

  setProductItem(id: number) {
    this.productsService.getProductSizes().subscribe({
      next: (productSizes) => {
        this.productSizes = productSizes;
      },
    });
    this.productsService.getProductCategories().subscribe({
      next: (productCategories) => {
        this.productCategories = productCategories;
      },
    });

    this.productsService.getProductItemById(+id).subscribe({
      next: (productItem) => {
        this.productItem = productItem;

        this.productItem.createdDate = formatDateWithoutTime(
          this.productItem.createdDate
        );
        this.productItem.size = this.productSizes.find(
          (s) => s.id === productItem.sizeId
        )?.name;
        this.productItem.category = this.productCategories.find(
          (c) => c.id === productItem.categoryId
        )?.name;
      },
      error: (error) => console.log(error),
    });
  }
}
