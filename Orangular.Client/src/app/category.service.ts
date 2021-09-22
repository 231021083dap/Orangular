import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from './models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CGategoryService {

  //Storing the url(C# Swagger)
  private apiUrl = 'https://localhost:5001/api/Categories';
  constructor(
    private http:HttpClient
  ) 
  { }

  
  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl);
  }
}
