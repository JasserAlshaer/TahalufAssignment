import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { CompanyForEditDTO } from 'src/app/dtos/companies/CompanyForEditDTO';
import { CreateUpdateCompanyDTO } from 'src/app/dtos/companies/CreateUpdateCompanyDTO';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent {
  input: CompanyForEditDTO = new CompanyForEditDTO()
  selectedCountryId: number | null = null; // Holds the ID of the selected country
  selectedCountryName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  filteredOrganizations: OrgnizationForEditDTO[] = [];
  allOrganizations: OrgnizationForEditDTO[] = [];
  selectedOrgnizationId: number | null | undefined = null;
  selectedOrgnizationName: string = '';
  getOrgnizationDetailsButton: boolean = false
  date = new Date()
  updatingDate = new Date()
  constructor(public dialogRef: MatDialogRef<EditCompanyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CompanyForEditDTO,
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
    if (this.input.organizationId != undefined)
      this.selectedOrgnizationId = this.input.organizationId
    if (this.input.orgnizationName != undefined)
      this.selectedOrgnizationName = this.input.orgnizationName
  }
  GetOrgnizationDetails() {
    const selectedOrg = this.allOrganizations.find((c) => c.id === this.selectedOrgnizationId);
    if (selectedOrg) {
      if (this.input.countryId || this.input.phone && this.input.address) {
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
            if (this.input.countryId != undefined) {
              this.selectedCountryId = this.input.countryId

            }
            if (selectedOrg.country != undefined) {
              this.selectedCountryName = selectedOrg.country
            }

            this.input.phone = selectedOrg.phone
            this.input.address = selectedOrg.address
          }
        });
      } else {
        this.input.countryId = selectedOrg.countryId
        if (this.input.countryId != undefined) {
          this.selectedCountryId = this.input.countryId

        }
        if (selectedOrg.country != undefined) {
          this.selectedCountryName = selectedOrg.country
        }

        this.input.phone = selectedOrg.phone
        this.input.address = selectedOrg.address
      }
    }
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
      let inputDto = new CreateUpdateCompanyDTO()
      inputDto.id = this.input.id;
      inputDto.name = this.input.name;
      inputDto.address = this.input.address
      inputDto.countryId = this.input.countryId
      inputDto.organizationId = this.input.organizationId
      inputDto.code = this.input.code
      inputDto.phone = this.input.phone
      this.backend.UpdateOrgnization(inputDto).subscribe((res) => {
        this.spinner.hide()
        this.tostr.success(res.message)
        this.selectedCountryId = null
        this.selectedCountryName = ''
        this.dialog.closeAll()

      }, (err) => {
        this.spinner.hide()
        this.tostr.error('Some thing Went Wrong While Save New Orgnizaition')
      })
    } else {
      this.spinner.hide()
      this.tostr.warning('Please fill all required fields');
    }
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
