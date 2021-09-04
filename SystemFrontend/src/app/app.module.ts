import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { InventoryComponent } from './inventory/inventory.component';
import { ProductComponent } from './product/product.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { PurchaseAddComponent } from './purchase/purchase-add/purchase-add.component';
import { ProductViewComponent } from './product/product-view/product-view.component';
import { OrderComponent } from './order/order.component';
import { OrderAddComponent } from './order/order-add/order-add.component';
import { ReportComponent } from './report/report.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    InventoryComponent,
    ProductComponent,
    ProductAddComponent,
    ProductEditComponent,
    PurchaseComponent,
    PurchaseAddComponent,
    ProductViewComponent,
    OrderComponent,
    OrderAddComponent,
    ReportComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
