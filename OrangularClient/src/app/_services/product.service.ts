import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://localhost:5001/api/Product';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
  constructor(private http:HttpClient) { }

  getAllProduct(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProduct(productId: string): Observable<Product>{
    return this.http.get<Product>(`${this.apiUrl}/${productId}`);
   }

   setImage(productId: number): string {
     let thisImage;
    switch (productId) {
      case 1: thisImage = "Schaeferhund.jpg"; break;
      case 2: thisImage = "Corgi.jpg"; break;
      case 3: thisImage = "JackRussellTerrier.jpg"; break;
      case 4: thisImage = "Siamese.jpg"; break;
      case 5: thisImage = "SnowShoe.jpg"; break;
      case 6: thisImage = "Persian.jpg"; break;
      default: thisImage = 'DefaultImage.jpg';
    }
    return thisImage;
   }
}
