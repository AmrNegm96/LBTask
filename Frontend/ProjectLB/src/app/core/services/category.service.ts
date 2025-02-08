import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from "rxjs";
import { Category } from "../models/category.model";

@Injectable({
    providedIn: 'root'
})
export class categoryService{
    private apiUrl = 'https://localhost:7120/api/categories';
    constructor(private http: HttpClient) {
        this.loadCategories();
    }

    private categoriesSubject = new BehaviorSubject<Category[]>([]);
    categories$ = this.categoriesSubject.asObservable();

    private loadCategories(): void {
        var url = this.apiUrl+'/GetAllCategories'; 
        this.http.get<any>(url).subscribe(

          (categories) => {
            console.log('Categories fetched:', categories)
            this.categoriesSubject.next(categories.data);
          },
          (error) => {
            console.error('Error loading categories:', error);
          }
        );
    }

    getCategories(): Observable<Category[]> {
      return this.categoriesSubject.asObservable();
    }

    refreshCategories(): void {
        this.loadCategories();
    }
}