import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';
import { CreateUpdateOrgnizationDTO } from 'src/app/dtos/orgnizations/CreateUpdateOrgnizationDTO';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';


@Component({
  selector: 'app-createorgnization',
  templateUrl: './createorgnization.component.html',
  styleUrls: ['./createorgnization.component.css'],
})
export class CreateOrgnizationComponent {
  input: CreateUpdateOrgnizationDTO = new CreateUpdateOrgnizationDTO();
  attachement: File | undefined;
  currentRoute: string = '';
  selectedCountryId: number | null = null; // Holds the ID of the selected country
  selectedCountryName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  date = new Date() 
  updatingDate = new Date() 
  constructor(
    public backend: MainServiceService,
    public tostr: ToastrService,
    public spinner: NgxSpinnerService,
    public router: Router,
    public dialog: MatDialog,
  ) { }

  ngOnInit() {
    this.GetCountries()
  }
  onFileSelected(event: any) {
    if (event.target.files && event.target.files[0]) {
      this.attachement = event.target.files[0];
    }
  }
  isActive(route: string): boolean {
    return this.currentRoute === route;
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
  }
  LogoutFuncationaity(): void {
    this.spinner.show();
    this.backend.Logout().subscribe((res) => {
      localStorage.removeItem('isLoggedIn')
      localStorage.removeItem('token')
      localStorage.removeItem('userId')
      this.spinner.hide()
      this.router.navigate([''])
    }, (err) => {
      this.spinner.hide()
      this.tostr.error('Logout Failed')
    });
  }
  onSave(): void {
    this.spinner.show()
    debugger
    if (this.input.name && this.input.code && this.input.countryId && this.input.phone && this.input.address) {
      this.backend.CreateOrgnization(this.input).subscribe((res)=>{
        this.spinner.hide()
        this.tostr.success(res.message)
        this.input = new CreateUpdateOrgnizationDTO()
        this.selectedCountryId = null
        this.selectedCountryName = ''
      },(err)=>{
        this.spinner.hide()
        
        this.tostr.error(err.error?.message || "An unknown error occurred.");
      })
    } else {
      this.spinner.hide()
      this.tostr.warning('Please fill all required fields');
      
    }
  }

  onCancel(): void {
    this.onBack();
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
        this.router.navigate(['/manage-orgnization'])
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
