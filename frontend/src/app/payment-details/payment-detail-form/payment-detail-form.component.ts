import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../../shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { PaymentDetail } from '../../shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styles: ``
})
export class PaymentDetailFormComponent {
  constructor(public service:PaymentDetailService,private toastr: ToastrService){}
  onSubmit(form:NgForm){
  if(this.service.formData.paymentDetailId!=0){
this.createFunction(form)
  }
  else{
  this.updateFunction(form)
  }
}
  createFunction(form:NgForm){
    this.service.isValidSubmit=true;
    if (form.valid) {
     this.service.formUpload()
     .subscribe({
       next: res => {
        this.service.list= res as PaymentDetail[]
        this.service.resetForm(form);
        this.toastr.success('Add Success');
       },
       error: err => {
         console.log(err)
         this.toastr.error('error '+err.message);
       }
     });
     
    }
    else{
     this.toastr.warning('Fill All Fields')
    }
  

  }
  updateFunction(form:NgForm){
    this.service.isValidSubmit=true;
    if (form.valid) {
     this.service.formUpdate()
     .subscribe({
       next: res => {
        this.service.list= res as PaymentDetail[]
        this.service.resetForm(form);
        this.toastr.success('Update Success');
       },
       error: err => {
         console.log(err)
         this.toastr.info('error '+err.message);
       }
     });
     
    }
    else{
     this.toastr.warning('Fill All Fields')
    }
  }
}
