import { ReportService } from './../service/report.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  reportDate:FormGroup;
  StartDate:string;
  purchaseDetailsList:any;
  constructor(
    private reportService:ReportService,
    private formBuilder:FormBuilder,
  ) { }

  selectDate(StartDate){
    this.reportService.getAllPurchase(StartDate)
        .subscribe((data:any)=>{
        this.purchaseDetailsList=data;
        this.ngOnInit();
      });
  }

  ngOnInit() {
    this.reportDate = this.formBuilder.group({
      StartDate: ['', Validators.required]
    });
  }

}
