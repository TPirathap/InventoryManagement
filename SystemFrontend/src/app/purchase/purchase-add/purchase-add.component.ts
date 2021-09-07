import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Purchase } from 'src/app/model/purchase';
import { PurchaseService } from 'src/app/service/purchase.service';

@Component({
  selector: 'app-purchase-add',
  templateUrl: './purchase-add.component.html',
  styleUrls: ['./purchase-add.component.css']
})
export class PurchaseAddComponent implements OnInit {

  purchaseAdd:FormGroup;
  productsList:any;
  constructor(
    private purchaseService:PurchaseService,
    private router:Router,
    private formBuilder:FormBuilder,
  ) { }

  ngOnInit() {
    this.purchaseService.getProduct().subscribe((data:any)=>{this.productsList = data;});

    this.purchaseAdd = this.formBuilder.group({
      ProductID: ['', Validators.required],
      Purchasedate: ['', Validators.required],
      Receivequantity: ['', Validators.required],
      Supplierfirstname: ['', Validators.required],
      Supplierlastname: ['', Validators.required]
    })
  }

  onSubmit(){
    const purchase = this.purchaseAdd.value;
    this.addPurchaseDetails(purchase);
  }

  addPurchaseDetails(purchase : Purchase){
    this.purchaseService.addPurchase(purchase)
      .subscribe( res => {
        alert(res.toString());
        this.router.navigate(['/purchase']);
      });
  }

}
