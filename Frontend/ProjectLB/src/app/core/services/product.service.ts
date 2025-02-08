import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {  
  private apiUrl = 'https://localhost:7120/api/products'; 

  constructor(private http: HttpClient) {}

  //share clicked category over all components
  private selectedCategorySubject = new BehaviorSubject(0);
  selectedCategory$ = this.selectedCategorySubject.asObservable();
  setSelectedCategory(categoryId: number) {
    this.selectedCategorySubject.next(categoryId);
  }

  //share clicked product over all components
  private selectedProductSubject = new BehaviorSubject<Product>(new Product(0,"",0,0,""));
  selectedProduct$ = this.selectedProductSubject.asObservable();
  setSelectedProduct(product:Product) {
    this.selectedProductSubject.next(product);
  }

  getProductByCategoryId(selectedCategoryId: number) {
    var url = this.apiUrl+"/GetProductsByCategoryId/"+selectedCategoryId;
    return this.http.get<any>(url);
  }

  addProduct(product:Product):any{
    var url = this.apiUrl+"/AddProduct"
    return this.http.post(url , product);
  }

  updateProduct(product:Product):any{
    var url = this.apiUrl+"/UpdateProduct"
    return this.http.post(url, product)
  }

  deleteProduct(proudctId:number){
    var url = this.apiUrl+"/DeleteProduct/"
    return this.http.delete(url+proudctId);
  }


}