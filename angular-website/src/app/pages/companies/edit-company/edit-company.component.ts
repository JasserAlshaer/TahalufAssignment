import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { CompanyForEditDTO } from 'src/app/dtos/companies/CompanyForEditDTO';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent {
  input:CompanyForEditDTO = new CompanyForEditDTO()
  constructor(public dialogRef: MatDialogRef<EditCompanyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CompanyForEditDTO,
    public backend:MainServiceService,
    public tostr:ToastrService,public spinner:NgxSpinnerService
  ) {}
  ngOnInit(){
    this.input = this.data
  }
  SaveInfo(){
    
  }
}
