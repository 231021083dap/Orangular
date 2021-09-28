import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../_models/user.ts';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private endPoint = 'https://localhost:5001/api/User';

  private httpOptions = {
    headers: new HttpHeaders({'Content-Type':'application/json'})
  }

  constructor(private http:HttpClient) {}

  // GET

  // POST
}
