import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { PaymentDetail } from './payment-detail.model';
import { NgForm } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
url:string = environment.apiUrl+'/Payment';
list:PaymentDetail[]=[];
isValidSubmit:boolean=false;
formData:PaymentDetail=new PaymentDetail();
  constructor(private http:HttpClient) { }

refreshList(){
  this.http.get(this.url).subscribe({
    next: res=>{
      this.list=res as PaymentDetail[];
console.log(res)
    },error:err=> {
      console.log(err)
    },
  })
}
formUpload()
{
 return this.http.post(this.url,this.formData)
}
formUpdate(){
  return this.http.put(this.url+'/'+this.formData.paymentDetailId,this.formData)
}
FormDelete(){
  return this.http.delete(this.url+'/'+this.formData.paymentDetailId).subscribe({
    next: res=>{
      this.list=res as PaymentDetail[];
console.log(res)
    },error:err=> {
      console.log(err)
    },
  })
}
resetForm(form:NgForm){
  form.form.reset();
  this.formData = new PaymentDetail();
  this.isValidSubmit=false;
}
}
