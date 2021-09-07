import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReportService } from 'src/app/service/report.service';

@Component({
  selector: 'app-daily-orders',
  templateUrl: './daily-orders.component.html',
  styleUrls: ['./daily-orders.component.css']
})
export class DailyOrdersComponent implements OnInit {

  reportDate:FormGroup;
  StartDate:string;
  orderDetailsList:any;
  constructor(
    private reportService:ReportService,
    private formBuilder:FormBuilder,
  ) { }

  selectDate(StartDate){
    this.reportService.getAllOrders(StartDate)
        .subscribe((data:any)=>{
        this.orderDetailsList=data;
        this.ngOnInit();
      });
  }

  ngOnInit() {
    this.reportDate = this.formBuilder.group({
      StartDate: ['', Validators.required]
    });
  }

}
