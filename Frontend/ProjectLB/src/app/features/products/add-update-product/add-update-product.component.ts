import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/core/models/category.model';
import { Product } from 'src/app/core/models/product.model';
import { categoryService } from 'src/app/core/services/category.service';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-add-update-product',
  templateUrl: './add-update-product.component.html',
  styleUrls: ['./add-update-product.component.css']
})
export class AddUpdateProductComponent implements OnInit {

  addedProduct:Product = new Product(0,"",0,0,"");
  categories:Category[]=[];
  editMode: boolean = false;
  productId: number = 0;

  constructor( private productService:ProductService , 
    private router:Router, 
    private categoryService: categoryService){
    this.categoryService.getCategories().subscribe({
      next:(res)=>{
        this.categories = res;
      }
    });
  }

  ngOnInit(): void {
    debugger;
    this.productService.selectedProduct$.subscribe((product)=>{
      if(product.id == 0){
        //add
      }else{
        this.addedProduct = product;
        this.editMode = true;
      }
      
    })
  }

  

  addProduct(product:Product){
    this.productService.addProduct(product).subscribe({
      next:()=>{
        this.productService.setSelectedProduct(new Product(0,"",0,0,""))
        this.router.navigate(['home']);
      },
      error:()=>{

      },
      complete:()=>{

      }
    }
    )
  }

  updateProduct(product:Product){
    this.productService.updateProduct(product).subscribe({
      next:()=>{
        this.productService.setSelectedProduct(new Product(0,"",0,0,""))
      },
      error:()=>{
        console.log("error happened while updating product");
      },
      complete:()=>{
        this.router.navigate(['']);
      }
    })
  }

}
