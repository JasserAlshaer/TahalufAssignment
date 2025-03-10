import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { jwtDecode } from 'jwt-decode'; 
import { LoginDTO } from 'src/app/dtos/authantications/LoginDTO';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  @HostListener('document:keydown.enter', ['$event'])
  handleEnter(event: KeyboardEvent): void {
    this.Login();
  }
  input : LoginDTO = new LoginDTO()
  constructor(public router:Router,public backend:MainServiceService,
    public spinner: NgxSpinnerService,public toastr : ToastrService
  ){
    this.spinner.hide()
  }
  Login(){
    if(this.input.email == undefined){
      this.toastr.warning('Please Enter User name')
      return;
    }
    if(this.input.password == undefined){
      this.toastr.warning('Please Enter Password')
      return;
    }
    if(this.input.email == ''){
      this.toastr.warning('User name Colud not be empty')
      return;
    }
      this.spinner.show()
      this.backend.Login(this.input).subscribe(res=>{
        this.spinner.hide()
        localStorage.setItem('isLoggedIn','true')
        localStorage.setItem('token',res)
        let data: any = jwtDecode(res);
        localStorage.setItem('userId',data.UserId)
        this.router.navigate(['/dashboard'])
      },err=>{
        this.spinner.hide()
        this.toastr.error('Wrong User name / Password')
      })
    }
  
}
