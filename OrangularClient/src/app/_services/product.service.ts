import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://localhost:5001/api/Product';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
  constructor(private http:HttpHeaders) { }

  getAllProduct(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl);
  }
}
