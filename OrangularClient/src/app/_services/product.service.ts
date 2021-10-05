import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryComponent } from '../admin/category/category.component';
import { Product } from '../_models/product';
import { ProductPillItemService } from './product-pill-item.service';

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
      categoryId: product.id,
      breedName: product.breedName, 
      price: product.price,
      weight: product.weight,
      gender: product.gender,
      description: product.description
    }

    // {
    //   "categoryId": 2,
    //   "breedName": "string",
    //   "price": 2147483647,
    //   "weight": 2147483647,
    //   "gender": "string",
    //   "description": "string"
    // }
    return this.http.post(`${this.apiUrl}`, x, this.httpOptions)
  }


  update(id : number, product : Product) : Observable<any> {

    let x = {
      categoryId: product.id,
      breedName: product.breedName, 
      price: product.price,
      weight: product.weight,
      gender: product.gender,
      description: product.description
    }

    // let x = {
    //   categoryId: 2,
    //   breedName: "MathiasTest", 
    //   price: 123321123,
    //   weight: 42222,
    //   gender: "Male",
    //   description: "Vi tester her"
    // }

    return this.http.put(`${this.apiUrl}/${id}`, x, this.httpOptions)
  }

  delete(id : number) : Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, this.httpOptions)
  }
}
