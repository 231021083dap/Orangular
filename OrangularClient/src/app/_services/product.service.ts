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

  //Get All Products
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

   // GET user by ID
  getById(id : number) : Observable<Product> {
    let x = this.http.get<Product>(`${this.apiUrl}/${id}`, this.httpOptions)
    console.log(x)

    return this.http.get<Product>(`${this.apiUrl}/${id}`, this.httpOptions)
  }

  // POST https://localhost:5001/api/User/Create
  create(product : Product) : Observable<any> {
    let x = {
      breedName: product.breedName, 
      Price: product.price,
      Weight: product.weight,
      Gender: product.gender,
      Description: product.description
    }
    return this.http.post(`${this.apiUrl}/Create`, x, this.httpOptions)
  }


  update(id : number, product : Product) : Observable<any> {

    let x = {
      breedName: product.breedName, 
      Price: product.price,
      Weight: product.weight,
      Gender: product.gender,
      Description: product.description
    }

    return this.http.put(`${this.apiUrl}/${id}`, x, this.httpOptions)
  }

  delete(id : number) : Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, this.httpOptions)
  }
}
