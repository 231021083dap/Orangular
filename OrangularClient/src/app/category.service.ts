import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from './models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  //Storing the url(C# Swagger)
  private apiUrl = 'https://localhost:5001/api/Category';

  //adding http headers
  httpOptions = {
    headers: new HttpHeaders(
      { 'Content-Type': 'application/json'}
    )
  }

  constructor(
    private http:HttpClient
  ) 
  { }


  getCategory(): Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl);
  }
}
 
