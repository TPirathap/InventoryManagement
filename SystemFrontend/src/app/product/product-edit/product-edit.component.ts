import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/model/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  productUpdate:FormGroup;
  productEditDataList: any;
  constructor(
    private formBuilder:FormBuilder,
    private productService:ProductService,
    private router:Router,
    private routes :ActivatedRoute
  ) { }

  ngOnInit() {
    //get productid
    const product = this.routes.snapshot.params;

    this.productUpdate = this.formBuilder.group({
      ProductID: [''],
      Productname: ['', Validators.required],
      Brandname: ['', Validators.required],
      Label: ['', Validators.required],
      Startinventory: ['', Validators.required],
      Minimuminventory: ['', Validators.required],
      Unitprice: ['', Validators.required],
      Sellprice: ['', Validators.required]
    });

    //patch value to product edit form
    this.productService.getProductById(product.ProductID)
      .subscribe((data:any)=>{
        this.productUpdate.patchValue({
          ProductID:data[0].ProductID,
          Productname:data[0].ProductName,
          Brandname:data[0].BrandName,
          Label:data[0].Label,
          Startinventory:data[0].StartInventory,
          Minimuminventory:data[0].MinimumInventory,
          Unitprice:data[0].UnitPrice,
          Sellprice:data[0].SellPrice});
        // this.productEditDataList=data;
      });

  }

  onUpdate(){
    const productDetails = this.productUpdate.value;
    this.sendEditDetails(productDetails);
  }

  //send product details to service
  sendEditDetails(product : Product){
    this.productService.editProduct(product)
    .subscribe( res => {
      alert(res.toString());
      this.router.navigate(['/product']);
    });
  }

}
