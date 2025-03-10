import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { DashboardInfoDTO } from 'src/app/dtos/dashboards/DashboardInfoDTO';

@Component({
  selector: 'app-maindashboard',
  templateUrl: './maindashboard.component.html',
  styleUrls: ['./maindashboard.component.css']
})
export class MaindashboardComponent {
    data:DashboardInfoDTO = new DashboardInfoDTO()
    constructor(
      public backend: MainServiceService,
      public tostr: ToastrService,
      public spinner: NgxSpinnerService,
      public router: Router
    ) {}
    ngOnInit(){
      this.spinner.show();
      this.backend.GetDashboard().subscribe((res)=>{
        this.spinner.hide();
        this.data = res
      },(err)=>{
        this.spinner.hide();
        this.tostr.error('Colud Not Load Information From Back End ')
      })
    }
    LogoutFuncationaity(): void {
      this.spinner.show();
          this.backend.Logout().subscribe((res)=>{
            localStorage.removeItem('isLoggedIn')
            localStorage.removeItem('token')
            localStorage.removeItem('userId')
            this.spinner.hide()
            this.router.navigate([''])},(err)=>{
              this.spinner.hide()
              this.tostr.error('Logout Failed')});
    }
}
