import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { CategoryListComponent } from './features/categories/category-list/category-list.component';
import { AddUpdateCategoryComponent } from './features/categories/add-update-category/add-update-category.component';
import { AddUpdateProductComponent } from './features/products/add-update-product/add-update-product.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'Product/addProducts', component: AddUpdateProductComponent },
  { path: 'Product/updateProducts', component: AddUpdateProductComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
