import { DailyOrdersComponent } from './report/daily-orders/daily-orders.component';
import { ReportComponent } from './report/report.component';
import { OrderComponent } from './order/order.component';
import { ProductViewComponent } from './product/product-view/product-view.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { ProductComponent } from './product/product.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InventoryComponent } from './inventory/inventory.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { PurchaseAddComponent } from './purchase/purchase-add/purchase-add.component';
import { OrderAddComponent } from './order/order-add/order-add.component';

const routes: Routes = [
  {path:"", component:InventoryComponent},
  {path:"inventory", component:InventoryComponent},
  {path:"product", component:ProductComponent},
  {path:"productAdd", component:ProductAddComponent},
  {path:"productEdit/:ProductID", component:ProductEditComponent},
  {path:"productView/:ProductID", component:ProductViewComponent},
  {path:"purchase", component:PurchaseComponent},
  {path:"purchaseAdd", component:PurchaseAddComponent},
  {path:"order", component:OrderComponent},
  {path:"orderAdd", component:OrderAddComponent},
  {path:"report", component:ReportComponent},
  {path:"dailyOrder", component:DailyOrdersComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
