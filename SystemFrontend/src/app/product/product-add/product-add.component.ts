import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from 'src/app/model/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  productAdd:FormGroup;
  
  constructor(
    private formBuilder:FormBuilder,
    private productService:ProductService,
    private router:Router
  ) { }

  ngOnInit() {
    this.productAdd = this.formBuilder.group({
      Productname: ['', Validators.required],
      Brandname: ['', Validators.required],
      Label: ['', Validators.required],
      Startinventory: ['', Validators.required],
      Minimuminventory: ['', Validators.required],
      Unitprice: ['', Validators.required],
      Sellprice: ['', Validators.required]
    });
  }

  onSubmit(){
    const product = this.productAdd.value;
    this.addProductDetails(product);
  }

  addProductDetails(value : Product){
    this.productService.addProduct(value)
      .subscribe( res => {
        alert(res.toString());
        this.router.navigate(['/product']);
      });
  }


}
