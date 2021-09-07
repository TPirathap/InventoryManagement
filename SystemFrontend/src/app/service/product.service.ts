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
    return this.http.get<Product[]>(this.APIUrl + '/Product');    
  }

  getProductById(ProductID: any):Observable<Product>{
    return this.http.get<Product>(this.APIUrl + '/Product/GetProductDetails/' + ProductID);
  }

  addProduct(product: Product):Observable<Product>{
    return this.http.post<Product>(this.APIUrl + '/Product', product);
  }

  editProduct(productDetails: Product):Observable<Product>{
    return this.http.put<Product>(this.APIUrl + '/Product', productDetails);
  }

  deleteProduct(ProductID: any){
    return this.http.delete(this.APIUrl + '/Product/' + ProductID);
  }
}
