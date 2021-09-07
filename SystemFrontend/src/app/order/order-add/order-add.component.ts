import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Orders } from 'src/app/model/orders';
import { OrdersService } from 'src/app/service/orders.service';
import { PurchaseService } from 'src/app/service/purchase.service';

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.css']
})
export class OrderAddComponent implements OnInit {

  orderAdd:FormGroup;
  productsList:any;
  constructor(
    private formBuilder:FormBuilder,
    private orderService:OrdersService,
    private router:Router,
    private purchaseService:PurchaseService,
  ) { }

  ngOnInit() {
    this.purchaseService.getProduct().subscribe((data:any)=>{this.productsList = data;});

    this.orderAdd = this.formBuilder.group({
      ProductID: ['', Validators.required],
      Invoiceno: ['', Validators.required],
      Orderdate: ['', Validators.required],
      Shippedquantity: ['', Validators.required],
      Totalamount: ['', Validators.required],
      Customerfirstname: ['', Validators.required],
      Customerlastname: ['', Validators.required]
    })
  }

  onSubmit(){
    const order = this.orderAdd.value;
    this.addorderDetails(order);
  }

  addorderDetails(value : Orders){
    this.orderService.addOrder(value)
      .subscribe( res => {
        alert(res.toString());
        this.router.navigate(['/order']);
      });
  }

}
