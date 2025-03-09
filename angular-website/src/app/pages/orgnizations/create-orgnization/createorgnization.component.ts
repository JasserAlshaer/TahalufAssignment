import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { CreateUpdateOrgnizationDTO } from 'src/app/dtos/orgnizations/CreateUpdateOrgnizationDTO';


@Component({
  selector: 'app-createorgnization',
  templateUrl: './createorgnization.component.html',
  styleUrls: ['./createorgnization.component.css'],
})
export class CreateOrgnizationComponent {
  input: CreateUpdateOrgnizationDTO = new CreateUpdateOrgnizationDTO();
  attachement: File | undefined;
  constructor(
    public backend: MainServiceService,
    public tostr: ToastrService,
    public spinner: NgxSpinnerService,
    public router: Router
  ) {}
  onFileSelected(event: any) {
    if (event.target.files && event.target.files[0]) {
      this.attachement = event.target.files[0];
    }
  }
  SaveInfo() {
    /*if (this.input.title == undefined || this.input.title == '') {
      this.tostr.warning('Title Is Required');
      return;
    }
    if (this.input.article == undefined || this.input.article == '') {
      this.tostr.warning('Article Is Required');
      return;
    }
    let userId = localStorage.getItem('userId');
    if (userId == null) {
      this.tostr.warning('Must Logged In as Client');
      return;
    } else {
      this.input.userId = parseInt(userId);
      if (this.attachement == undefined) {
        this.input.imagePath = '';
      }else{
        this.spinner.show()
        this.backend.uploadImage(this.attachement).subscribe(res=>{
          this.spinner.hide();
          this.input.imagePath = res
        },err=>{
          this.spinner.hide();
          return;
        })
      }

      this.spinner.show();
      this.backend.createorgnization(this.input).subscribe(
        (res) => {
          this.spinner.hide();
          this.tostr.success('Created Successfully');
          this.router.navigate(['/manage-blog-client']);
        },
        (err) => {
          this.spinner.hide();
          this.tostr.error('Failed To Creat Blog');
        }
      );
    }*/
  }
}
