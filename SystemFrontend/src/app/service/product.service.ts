import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly APIUrl = "http://localhost:64570/api";
  constructor(private http:HttpClient) { }
  
  getProductDetails():Observable<Product[]>{
    return this.http.get<Product[]>(this.APIUrl + '/Candidate');    
  }
}
