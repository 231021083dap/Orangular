import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OrderList } from '../_models/order-list';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderListService {
  private endPoint = 'https://localhost:5001/api/OrderList';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private http: HttpClient) { }

  getAll(): Observable<OrderList[]> {
    return this.http.get<OrderList[]>(this.endPoint, this.httpOptions);
  }
}
