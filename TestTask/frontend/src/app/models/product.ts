export interface ProductItem {
  id: number;
  productName: string;
  sizeId: number;
  size: string | undefined;
  categoryId: number;
  category: string | undefined;
  availableQuantity: number;
  createdDate: string;
  description: string;
  price: string;
}

export interface ProductSize {
  id: number;
  name: string;
}

export interface ProductCategory {
  id: number;
  name: string;
}

export interface Product {
  id: number;
  name: string;
  category: string;
  description: string;
  createdDate: string;
}
