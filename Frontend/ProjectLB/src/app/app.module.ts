import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CategoryListComponent } from './features/categories/category-list/category-list.component';
import { AddUpdateCategoryComponent } from './features/categories/add-update-category/add-update-category.component';
import { ProductListComponent } from './features/products/product-list/product-list.component';
import { AddUpdateProductComponent } from './features/products/add-update-product/add-update-product.component';
import { SharedModule } from "./shared/shared.module";
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './features/home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    CategoryListComponent,
    AddUpdateCategoryComponent,
    ProductListComponent,
    AddUpdateProductComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,
    NgbModule,
    FormsModule  
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
