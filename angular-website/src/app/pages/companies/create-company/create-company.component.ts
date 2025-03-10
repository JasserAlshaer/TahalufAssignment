import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { CreateUpdateCompanyDTO } from 'src/app/dtos/companies/CreateUpdateCompanyDTO';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-create-company',
  templateUrl: './create-company.component.html',
  styleUrls: ['./create-company.component.css']
})
export class CreateCompanyComponent {
  input: CreateUpdateCompanyDTO = new CreateUpdateCompanyDTO();
  selectedCountryId: number | null = null;
  selectedCountryName: string = '';
  selectedOrgnizationId: number | null | undefined = null;
  selectedOrgnizationName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  filteredOrganizations: OrgnizationForEditDTO[] = [];
  allOrganizations: OrgnizationForEditDTO[] = [];
  date = new Date()
  updatingDate = new Date()
  getOrgnizationDetailsButton : boolean = false
  constructor(
    public backend: MainServiceService,
    public tostr: ToastrService,
    public spinner: NgxSpinnerService,
    public router: Router,
    public dialog: MatDialog
  ) { }
  ngOnInit() {
    this.GetCountries()
    this.GetOrgnizations()
  }
  GetOrgnizations() {
    this.spinner.show()
    this.backend.GetOrgnizations().subscribe((res) => {
      this.allOrganizations = res
      this.filteredOrganizations = this.allOrganizations;
      this.spinner.hide()
    }, (err) => {
      this.spinner.hide()
    })
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
  filterCountries(event: Event): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.filteredCountries = this.countries.filter((country) =>
      country.name.toLowerCase().includes(inputValue.toLowerCase())
    );
  }

  filterOrganization(event: Event): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.filteredOrganizations = this.allOrganizations.filter((org) =>
      org.name.toLowerCase().includes(inputValue.toLowerCase())
    );
  }

  onOrgnizationSelected(orgId: number): void {
    debugger
    this.selectedOrgnizationId = orgId;
    this.input.organizationId = this.selectedOrgnizationId
    const selectedOrg = this.allOrganizations.find((c) => c.id === orgId);
    if (selectedOrg) {
      this.selectedOrgnizationName = selectedOrg.name;
      this.getOrgnizationDetailsButton = true
      
    }
  }
  onCountrySelected(countryId: number): void {
    debugger
    this.selectedCountryId = countryId;
    this.input.countryId = this.selectedCountryId
    const selectedCountry = this.countries.find((c) => c.id === countryId);
    if (selectedCountry) {
      this.selectedCountryName = selectedCountry.name;
    }
  }
  GetOrgnizationDetails(){
    const selectedOrg = this.allOrganizations.find((c) => c.id === this.selectedOrgnizationId);
    if (selectedOrg) {
      if(this.input.countryId || this.input.phone && this.input.address){
        let info = new ConfirmDialogData(
          'Load Orgnization Information  ?',
          'The system will override all company details according to the predefined information on the organization level, Are you sure you want to continue ?',
          'Fill organization details',
          'Cancel'
        );
    
        const dialogres = this.dialog.open(ConfirmDialogComponent, {
          width: '350px',
          data: info,
        });
    
        dialogres.afterClosed().subscribe((result) => {
          if (result) {
            this.input.countryId = selectedOrg.countryId
            if(this.input.countryId != undefined){
              this.selectedCountryId = this.input.countryId
              
            }
            if(selectedOrg.country!= undefined){
              this.selectedCountryName = selectedOrg.country
            }
    
            this.input.phone = selectedOrg.phone
             this.input.address= selectedOrg.address
          }
        });
      }else{
        this.input.countryId = selectedOrg.countryId
        if(this.input.countryId != undefined){
          this.selectedCountryId = this.input.countryId
          
        }
        if(selectedOrg.country!= undefined){
          this.selectedCountryName = selectedOrg.country
        }

        this.input.phone = selectedOrg.phone
         this.input.address= selectedOrg.address
      }
    }
  }
  onSave(): void {
    this.spinner.show()
    debugger
    if (this.input.name && this.input.code && this.input.countryId && this.input.phone && this.input.address && this.input.organizationId) {
      this.backend.CreateCompany(this.input).subscribe((res) => {
        this.spinner.hide()
        this.tostr.success(res.message)
        this.input = new CreateUpdateCompanyDTO()
        this.selectedCountryId = null
        this.selectedCountryName = ''
        this.selectedOrgnizationId = null
        this.selectedOrgnizationName = ''
        this.getOrgnizationDetailsButton = false
      }, (err) => {
        this.spinner.hide()
        this.tostr.error('Some thing Went Wrong While Save New Company')
        this.tostr.error(err.err.message)
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
      'Back to Compaines"  ?',
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
        this.router.navigate(['/manage-companies'])
      }
    });
  }
}
