import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './_model/user.ts';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private endPoint = 'https://localhost:5001/api/User';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type':'application/json'})
  }

  constructor() {  }
}
