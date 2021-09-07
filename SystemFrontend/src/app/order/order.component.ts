import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Orders } from '../model/orders';
import { OrdersService } from '../service/orders.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  ordersList: any;
  searchOrders:string;
  constructor(
    private orderService:OrdersService,
    private router:Router
  ) { }

  deleteClick(order: Orders){
    if (confirm("Are you sure you want to delete this?")) {   
      this.orderService.deleteOrder(order)
      .subscribe( res => {
        alert(res.toString());
        this.ngOnInit();
      });
      this.router.navigate(['/order']);
    }
  }


  ngOnInit() {
    this.orderService.getOrderDetails().subscribe((data:any)=>{this.ordersList = data;});
  }

}
