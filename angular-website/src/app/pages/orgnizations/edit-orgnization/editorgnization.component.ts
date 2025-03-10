import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';
import { CreateUpdateOrgnizationDTO } from 'src/app/dtos/orgnizations/CreateUpdateOrgnizationDTO';
import { OrgnizationDTO } from 'src/app/dtos/orgnizations/OrgnizationDTO';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-createblog',
  templateUrl: './editorgnization.component.html',
  styleUrls: ['./editorgnization.component.css']
})
export class EditOrgnizationComponent {
  input: OrgnizationForEditDTO = new OrgnizationForEditDTO()
  selectedCountryId: number | null = null; // Holds the ID of the selected country
  selectedCountryName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  date = new Date()
  updatingDate = new Date()
  constructor(public dialogRef: MatDialogRef<EditOrgnizationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: OrgnizationForEditDTO,
    public backend: MainServiceService,
    public dialog: MatDialog,
    public tostr: ToastrService, public spinner: NgxSpinnerService
  ) { }
  ngOnInit() {
    this.input = this.data
    if (this.input.countryId != undefined)
      this.selectedCountryId = this.input.countryId
    if (this.input.country != undefined)
      this.selectedCountryName = this.input.country
  }
  GetCountries() {
    this.spinner.show()
    this.backend.GetCountries(1).subscribe((res) => {
      this.countries = res.items
      this.filteredCountries = this.countries;
      this.spinner.hide()
    }, (err) => {
      this.spinner.hide()
    })
  } onSave(): void {
    
    this.spinner.show()
    if (this.input.name && this.input.code && this.input.countryId && this.input.phone && this.input.address) {
      let inputDto = new CreateUpdateOrgnizationDTO()
      inputDto.id = this.input.id;
      inputDto.name = this.input.name;
      inputDto.address = this.input.address
      inputDto.countryId = this.input.countryId
      inputDto.code = this.input.code
      inputDto.phone = this.input.phone
      this.backend.UpdateOrgnization(inputDto).subscribe((res)=>{
        this.spinner.hide()
        this.tostr.success(res.message)
        this.selectedCountryId = null
        this.selectedCountryName = ''
        this.dialog.closeAll()
        
      },(err)=>{
        this.spinner.hide()
        this.tostr.error('Some thing Went Wrong While Save New Orgnizaition')
      })
    } else {
      this.spinner.hide()
      this.tostr.warning('Please fill all required fields');
    }
  }

  onCancel(): void {
   this.dialog.closeAll()
  }
  onBack(): void {
    let info = new ConfirmDialogData(
      'Back to Organization"  ?',
      'You haven\'t saved your changes yet. Do you want to leave without saving',
      'Stay on this page',
      'Leave this page'
    );

    const dialogres = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: info,
    });

    dialogres.afterClosed().subscribe((result) => {
      if (!result) {

      }
    });
  }

  filterCountries(event: Event): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.filteredCountries = this.countries.filter((country) =>
      country.name.toLowerCase().includes(inputValue.toLowerCase())
    );
  }

  // Handle country selection
  onCountrySelected(countryId: number): void {
    debugger
    this.selectedCountryId = countryId;
    this.input.countryId = this.selectedCountryId
    const selectedCountry = this.countries.find((c) => c.id === countryId);
    if (selectedCountry) {
      this.selectedCountryName = selectedCountry.name; // Update the input field with the selected name
    }
  }
}
