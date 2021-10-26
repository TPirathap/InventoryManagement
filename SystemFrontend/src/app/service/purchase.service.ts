import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../model/product';
import { Purchase } from '../model/purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  readonly APIUrl = "http://localhost:64570/api";
  constructor(private http:HttpClient) { }

  getProduct():Observable<Product[]>{
    //return this.http.get<Product[]>(this.APIUrl + '/Product/GetProduct'); 
    return this.http.get<Product[]>(this.APIUrl + '/Product');   
  }

  getPurchaseDetails():Observable<Purchase[]>{
    return this.http.get<Purchase[]>(this.APIUrl + '/Purchase');    
  }

  addPurchase(purchase: Purchase):Observable<Purchase>{
    return this.http.post<Purchase>(this.APIUrl + '/Purchase', purchase);
  }

  deletePurchase(purchase: Purchase):Observable<Purchase>{
    return this.http.put<Purchase>(this.APIUrl + '/Purchase/', purchase);
  }
}
