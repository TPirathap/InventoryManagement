import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(
    private router:Router
  ) { }

  ngOnInit() {
  }

  //call product edit page
  editClick() : void{
    this.router.navigate(['productEdit/']);
  }
  //call product fullview page
  viewClick() : void{
    this.router.navigate(['productView/']);
  }

}
