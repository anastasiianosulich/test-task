import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OrderItem } from 'src/app/models/order';
import { Product, ProductItem, ProductSize } from 'src/app/models/product';
import { OrdersService } from 'src/app/services/orders.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product-to-order',
  templateUrl: './add-product-to-order.component.html',
  styleUrls: ['./add-product-to-order.component.scss'],
})
export class AddProductToOrderComponent {
  productSizes: ProductSize[] = [];
  productCategory: string | undefined;
  products: Product[] = [];
  productItems: ProductItem[] = [];
  selectedProductItem: ProductItem | undefined;
  selectedProduct: Product | undefined;

  addProductForm = new FormGroup({
    size: new FormControl('', Validators.required),
    quantity: new FormControl(1),
  });

  constructor(
    private productsService: ProductsService,
    private ordersService: OrdersService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getProducts();
  }

  addProduct() {
    const formValues = this.addProductForm.value;

    let orderItem = {
      productId: this.selectedProductItem?.id,
      productName: this.selectedProduct?.name,
      quantity: formValues.quantity,
      size: formValues.size,
      category: this.selectedProduct?.category,
      price: this.selectedProductItem?.price,
    } as unknown as OrderItem;

    console.log(this.selectedProductItem);
    this.ordersService.addOrderItem(orderItem);
    this.router.navigate(['/orders/new']);
  }

  onProductSelected(event: Event) {
    const selectedValue = (event.target as HTMLSelectElement).value;
    this.selectedProduct = this.products.find((p) => p.id === +selectedValue);

    this.getProductItems(
      this.selectedProduct!.name,
      this.selectedProduct!.category
    );

    this.setSelectedProductItem();
  }

  getProducts() {
    this.productsService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
      },
    });
  }

  getProductItems(productName: string, categoryId: string) {
    this.productsService.getProductItems(productName, categoryId).subscribe({
      next: (productItems) => {
        this.productItems = productItems;

        this.setAvailableSizes();
      },
    });
  }

  isCorrectQuantitySelected() {
    if (this.selectedProductItem?.availableQuantity === 0) return false;
    if (
      this.addProductForm.get('quantity')?.value !== null &&
      this.selectedProductItem?.availableQuantity
    ) {
      return (
        this.addProductForm.get('quantity')!.value! < 0 ||
        this.addProductForm.get('quantity')!.value! <=
          this.selectedProductItem!.availableQuantity
      );
    }

    return false;
  }

  onSizeChanged() {
    this.setSelectedProductItem();
  }

  setSelectedProductItem() {
    const formValues = this.addProductForm.value;

    if (formValues.size && this.selectedProduct) {
      this.selectedProductItem = this.productItems.find(
        (pi) =>
          pi.category === this.selectedProduct?.category &&
          pi.productName === this.selectedProduct?.name &&
          pi.size === formValues.size
      );
    }
  }

  setAvailableSizes() {
    const productSizes = this.productItems.map((pi) => pi.sizeId);

    this.productSizes = [];
    this.productsService.getProductSizes().subscribe({
      next: (allSizes) => {
        allSizes.forEach((size) => {
          if (productSizes.includes(size.id)) {
            this.productSizes.push({ name: size.name, id: size.id });
          }
        });
      },
    });
  }
}
