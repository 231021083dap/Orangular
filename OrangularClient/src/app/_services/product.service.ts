import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  apiUrl: string = "https://localhost:5001/api/";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(
    private http: HttpClient
  ) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + "products").pipe(
      catchError(this.handleError<Product[]>("getProducts"))
    )
  }

  getProductsByCategoryId(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}products/by_category/${categoryId}`).pipe(
      catchError(this.handleError<Product[]>("getProductsByCategoryId"))
    )
  }

  getProduct(id: number): Observable<Product>{
    return this.http.get<Product>(`${this.apiUrl}products/${id}`).pipe(
      catchError(this.handleError<Product>("getProductById"))
    )
  }

  deleteProduct(id: number): Observable<Product>{
    return this.http.delete<Product>(`${this.apiUrl}products/${id}`).pipe(
      catchError(this.handleError<Product>("deleteProduct"))
    )
  }

  updateProduct(id: number, product: Product): Observable<Product>{
    return this.http.put<Product>(`${this.apiUrl}products/${id}`,product,this.httpOptions).pipe(
      catchError(this.handleError<Product>("updateProduct"))
    )
  }

  addProduct(product: Product): Observable<Product>{
    return this.http.post<Product>(`${this.apiUrl}products`,product,this.httpOptions).pipe(
      catchError(this.handleError<Product>("addProduct"))
    )
  }


  /**
    * Handle Http operation that failed.
    * Let the app continue.
    * @param operation - name of the operation that failed
    * @param result - optional value to return as the observable result
    */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}