import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { OrgnizationDTO } from 'src/app/dtos/orgnizations/OrgnizationDTO';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';

@Component({
  selector: 'app-createblog',
  templateUrl: './editorgnization.component.html',
  styleUrls: ['./editorgnization.component.css']
})
export class EditOrgnizationComponent {
  input:OrgnizationForEditDTO = new OrgnizationForEditDTO()
  constructor(public dialogRef: MatDialogRef<EditOrgnizationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: OrgnizationForEditDTO,
    public backend:MainServiceService,
    public tostr:ToastrService,public spinner:NgxSpinnerService
  ) {}
  ngOnInit(){
    this.input = this.data
  }
  SaveInfo(){
    /*this.input.id  = this.data.id
    this.input.imagePath = ''
    this.input.article = this.data.article
    this.input.title=this.data.title
    if(this.input.title == undefined || this.input.title ==''){
      this.tostr.warning('Title Is Required')
      return;
    }
    if(this.input.article == undefined || this.input.article ==''){
      this.tostr.warning('Article Is Required')
      return;
    }
    let userId = localStorage.getItem('userId')
    if(userId == null){
      this.tostr.warning('Must Logged In as Client')
      return;
    }else{
      this.spinner.show()
      this.backend.editorgnization(this.input).subscribe(res=>{
        this.spinner.hide()
        this.tostr.success('Update Successfully')
        this.dialogRef.close()
        //this.router.navigate(['/manage-blog-client'])
      },err=>{
        this.spinner.hide()
        this.tostr.error('Failed To Creat Blog')
        this.dialogRef.close()
      })
    }*/
  }
}
