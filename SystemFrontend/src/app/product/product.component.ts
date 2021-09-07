import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../model/product';
import { ProductService } from '../service/product.service';
import { Pipe, PipeTransform } from '@angular/core';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  ProductsList: any;
  searchValue:string;
  constructor(
    private productService:ProductService,
    private router:Router
  ) { }

  filter(item) {
    return item;
  }

  //delete product details
  deleteClick(ProductID:number){
    if (confirm("Are you sure you want to delete this?")) {   
      this.productService.deleteProduct(ProductID)
      .subscribe( res => {
        alert(res.toString());
        this.ngOnInit();
      });
      this.router.navigate(['/product']);
    }
  }

  ngOnInit() {
    this.productService.getProductDetails().subscribe((data:any)=>{this.ProductsList = data;});
  }

  //call product edit page
  editClick(product : Product) : void{
    this.router.navigate(['productEdit/' + product.ProductID]);
  }

  //call product fullview page
  viewClick(product : Product) : void{
    this.router.navigate(['productView/' + product.ProductID]);
  }

}
