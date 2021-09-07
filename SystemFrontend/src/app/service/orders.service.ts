import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Orders } from '../model/orders';
import { Product } from '../model/product';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  readonly APIUrl = "http://localhost:64570/api";
  constructor(private http:HttpClient) { }

  getProduct():Observable<Product[]>{
    return this.http.get<Product[]>(this.APIUrl + '/Product/GetProduct');    
  }

  getOrderDetails():Observable<Orders[]>{
    return this.http.get<Orders[]>(this.APIUrl + '/Order');    
  }

  addOrder(order: Orders):Observable<Orders>{
    return this.http.post<Orders>(this.APIUrl + '/Order', order);
  }

  deleteOrder(order: Orders):Observable<Orders>{
    return this.http.put<Orders>(this.APIUrl + '/Order/', order);
  }
}
