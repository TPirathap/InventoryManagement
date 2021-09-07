import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

  productFullDetails: any;
  constructor(
    private routes :ActivatedRoute,
    private productService:ProductService
  ) { }

  ngOnInit() {
    //get productid
    const product = this.routes.snapshot.params;

    this.productService.getProductById(product.ProductID)
      .subscribe((data:any)=>{
        this.productFullDetails=data;
      });
  }

}
