import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../service/orders.service';
import { ProductService } from '../service/product.service';
import { PurchaseService } from '../service/purchase.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  ProductsList: any;
  purchasesList: any;
  ordersList: any;
  searchValue:string;
  searchPurch:string;
  searchOrders:string;
  constructor(
    private productService:ProductService,
    private purchaseService:PurchaseService,
    private orderService:OrdersService
  ) { }

  ngOnInit() {
    this.getAllProducts();
    this.getAllPurchase();
    this.getAllOrders();
  }

  getAllProducts(){
    this.productService.getProductDetails().subscribe((data:any)=>{this.ProductsList = data;});
  }

  getAllPurchase(){
    this.purchaseService.getPurchaseDetails().subscribe((data:any)=>{this.purchasesList = data;});
  }

  getAllOrders(){
    this.orderService.getOrderDetails().subscribe((data:any)=>{this.ordersList = data;});
  }

}
