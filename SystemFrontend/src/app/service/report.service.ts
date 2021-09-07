import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Report } from '../model/report';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  readonly APIUrl = "http://localhost:64570/api";
  constructor(private http:HttpClient) { }

  getAllPurchase(StartDate: any):Observable<Report>{
    return this.http.get<Report>(this.APIUrl + '/Report/GetPurchaseDetails/' + StartDate);
  }

  getAllOrders(StartDate: any):Observable<Report>{
    return this.http.get<Report>(this.APIUrl + '/Report/GetOrderDetails/' + StartDate);
  }
}
