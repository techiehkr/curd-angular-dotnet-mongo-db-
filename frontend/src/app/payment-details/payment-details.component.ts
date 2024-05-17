import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { PaymentDetail } from '../shared/payment-detail.model';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: ``
})
export class PaymentDetailsComponent implements OnInit {
  constructor(public service:PaymentDetailService){}
    ngOnInit(): void {
     this.service.refreshList();
     
    }
    populateForm(selecedRecord:PaymentDetail){
      this.service.formData=Object.assign({},selecedRecord);
    }
    deleteData(id:number){
    this.service.FormDelete();
    }
  }