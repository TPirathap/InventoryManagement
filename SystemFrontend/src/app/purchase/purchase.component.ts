import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Purchase } from '../model/purchase';
import { PurchaseService } from '../service/purchase.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {

  purchasesList: any;
  searchPurch:string;
  constructor(
    private purchaseService:PurchaseService,
    private router:Router
  ) { }

  deleteClick(purchase: Purchase){
    if (confirm("Are you sure you want to delete this?")) {   
      this.purchaseService.deletePurchase(purchase)
      .subscribe( res => {
        alert(res.toString());
        this.ngOnInit();
      });
      this.router.navigate(['/purchase']);
    }
  }

  ngOnInit() {
    this.purchaseService.getPurchaseDetails().subscribe((data:any)=>{this.purchasesList = data;});
  }

}
