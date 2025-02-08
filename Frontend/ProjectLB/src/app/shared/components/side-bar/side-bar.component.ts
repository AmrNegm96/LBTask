import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/core/models/category.model';
import { categoryService } from 'src/app/core/services/category.service';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {
  constructor(
    private categoryService: categoryService,
    private productService:ProductService
  ) {}

  categories: Category[] = [];

  ngOnInit(): void {
    this.categoryService.categories$.subscribe((categories) => {
      this.categories = categories;
    });
  }

  emitCategoryId(categoryId:number){
    this.productService.setSelectedCategory(categoryId);
  }
  
}
