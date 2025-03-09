import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  IsloggedIn :boolean = false;
  IsloggedInAsAdmin :boolean = false;
  constructor(public router:Router,public trans:TranslateService){}
  translateToEnglish() {
    debugger
    this.trans.use('en');
  }
  translateToArabic() {
    debugger
    this.trans.use('ar');
  }
  ngOnInit(){
    let userId = localStorage.getItem('userId')
    let token = localStorage.getItem('token')
    if(userId != null && token!= null){
      if(userId == 'none' && token =='none'){
        this.IsloggedInAsAdmin= true;
        this.IsloggedIn=true;
      }else{
        this.IsloggedInAsAdmin= false;
        this.IsloggedIn=true;
      }
    }
  }
  NaivageteToLogin(){
    this.router.navigate(['/signin'])
  }
  NaivageteToClientDashboard(){
    this.router.navigate(['/manage-blog-client'])
  }
  NaivageteToAdminDashboard(){
    this.router.navigate(['/manage-blog-admin'])
  }
}
