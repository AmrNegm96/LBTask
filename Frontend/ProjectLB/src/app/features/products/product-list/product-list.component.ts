import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/core/models/product.model';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  selectedCategoryId = 0;
  products:Product[] = [];
  
  constructor(private productService:ProductService ,private router:Router) {
    this.productService.selectedCategory$.subscribe((category) => {
      debugger;
      this.selectedCategoryId = category;

      if(this.selectedCategoryId != 0){
        this.productService.getProductByCategoryId(this.selectedCategoryId).subscribe({
          next:(res:any)=>{
            this.products = res.data;
          },
          error:()=>{
  
          },
          complete:()=>{
  
          }
        });
      }

    });
  }

  ngOnInit(): void {
    
  }

  addProduct(){
    this.router.navigate(['/Product/addProducts']);
  }

  deleteProduct(productId:number){
    this.productService.deleteProduct(productId).subscribe({
      next:()=>{
        this.productService.getProductByCategoryId(this.selectedCategoryId).subscribe({
          next:(res:any)=>{
            this.products = res.data;
          },
          error:()=>{
  
          },
          complete:()=>{
  
          }
        });
      }
    })
  }

  updateProduct(product:Product){
    this.productService.setSelectedProduct(product);
    this.router.navigate(['/Product/updateProducts']);
  }

}
