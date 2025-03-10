import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { DatePaginationRequest } from 'src/app/dtos/apis/DatePaginationRequest';
import { CompanyDTO } from 'src/app/dtos/companies/CompanyDTO';
import { SearchCompanyDTO } from 'src/app/dtos/companies/SearchCompanyDTO';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';
import { EditCompanyComponent } from '../edit-company/edit-company.component';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';
import { OrgnizationDTO } from 'src/app/dtos/orgnizations/OrgnizationDTO';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';

@Component({
  selector: 'app-manage-compaines',
  templateUrl: './manage-compaines.component.html',
  styleUrls: ['./manage-compaines.component.css']
})
export class ManageCompainesComponent {
  displayedColumns: string[] = ['orgnizationName', 'code', 'name', 'phone', 'Actions'];
  searchParams = {
    orgName: '',
    compName: '',
    compCode: '',
    country: ''
  };
  selectedCountryId: number | null | undefined = null; // Holds the ID of the selected country
  selectedCountryName: string = '';
  selectedOrgnizationId: number | null | undefined = null; // Holds the ID of the selected country
  selectedOrgnizationName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  inputDTO: SearchCompanyDTO = new SearchCompanyDTO()
  input: DatePaginationRequest<SearchCompanyDTO> = new DatePaginationRequest<SearchCompanyDTO>();
  dataSource: MatTableDataSource<CompanyDTO> = new MatTableDataSource();
  orgnizationDTOArray: CompanyDTO[] = [];
  filteredOrganizations: OrgnizationForEditDTO[] = [];
  allOrganizations: OrgnizationForEditDTO[] = [];
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  @ViewChild(MatSort) sort: MatSort | null = null;
  pageEvent: PageEvent = new PageEvent;
  paginatorLength: number = 0;
  pageSize: number = 3;
  pageIndex: number = 0;

  constructor(
    public dialog: MatDialog,
    public router: Router,
    public backend: MainServiceService,
    public spinner: NgxSpinnerService,
    public toastr: ToastrService
  ) {
    this.input.index = 0;
    this.input.size = this.pageSize;
  }

  ngOnInit(): void {
    this.loadData();
    this.GetCountries()
    this.GetOrgnizations()
  }
  GetOrgnizations(){
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

  filterOrganizations(): void {
    const filterValue = this.searchParams.orgName?.toLowerCase() || '';
    this.filteredOrganizations = this.allOrganizations.filter(org => {
      if (org != undefined)
        org.name.toLowerCase().includes(filterValue)
    }
    );
  }
  filterCountries(event: Event): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.filteredCountries = this.countries.filter((country) =>
      country.name.toLowerCase().includes(inputValue.toLowerCase())
    );
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
      this.toastr.error('Logout Failed')
    });
  }

  // Handle country selection
  onCountrySelected(countryId: number): void {
    debugger
    this.selectedCountryId = countryId;
    const selectedCountry = this.countries.find((c) => c.id === countryId);
    if (selectedCountry) {
      this.searchParams.country = selectedCountry.name;
      this.selectedCountryName = selectedCountry.name; // Update the input field with the selected name
    }
  }
  onOrganizationSelected(organizationId: number): void {

    this.selectedOrgnizationId = organizationId
    const selectedOrganization = this.allOrganizations.find(org => org.id === organizationId);
    if (selectedOrganization) {
      this.searchParams.orgName = selectedOrganization.name;
      this.selectedOrgnizationName = selectedOrganization.name;
    }
  }

  ngAfterViewInit(): void {
    this.loadData();
    this.dataSource.sort = this.sort;
  }

  // This method gets called when the page is changed in the paginator
  onPageChange(e: PageEvent): void {
    debugger
    this.pageEvent = e;
    this.paginatorLength = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;

    this.loadData()
  }


  loadOriginal() {
    this.spinner.show();
    this.searchParams = {
      orgName: '',
      compName: '',
      compCode: '',
      country: ''
    };
    this.inputDTO = new SearchCompanyDTO()
    this.selectedCountryId = null
    this.selectedCountryName = ''
    this.selectedOrgnizationId = null
    this.selectedOrgnizationName = ''
    this.input = new DatePaginationRequest<SearchCompanyDTO>()
    this.input.index = 0;
    this.input.size = this.pageSize;
    this.backend.SearchCompany(this.input).subscribe(
      (res) => {
        debugger
        this.spinner.hide();
        this.dataSource.data = res.items;  // Update the table with the new data
        if (res.itemsCount != undefined)
          this.paginatorLength = res.itemsCount;  // Update the paginator length (total items)

        // Safely update the paginator state
        if (this.paginator) {
          this.paginator.pageIndex = this.pageIndex;  // Make sure the pageIndex stays in sync
          this.paginator.length = this.paginatorLength;
        }
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Failed to load compaines');
      }
    );
  }
  // This method loads the data from the backend
  loadData(): void {
    debugger
    this.spinner.show();
    this.input.index = this.pageIndex;
    this.input.size = this.pageSize;
    debugger
    if (this.searchParams.country != '' && this.searchParams.country != undefined) {
      if (this.selectedCountryId != undefined) {
        this.inputDTO.countryId = this.selectedCountryId
      }
    }
    if (this.searchParams.orgName != '' && this.searchParams.orgName != undefined) {
      if (this.selectedOrgnizationId != undefined) {
        this.inputDTO.organizationId = this.selectedOrgnizationId
      }
    }
    if (this.searchParams.compCode != '' && this.searchParams.compCode != undefined) {
      this.inputDTO.code = this.searchParams.compCode
    }
    if (this.searchParams.compName != '' && this.searchParams.compName != undefined) {
      this.inputDTO.name = this.searchParams.compName
    }
    this.input.input = this.inputDTO
    debugger
    // Make the backend request with the updated pagination parameters
    this.backend.SearchCompany(this.input).subscribe(
      (res) => {
        debugger
        this.spinner.hide();
        this.dataSource.data = res.items;  // Update the table with the new data
        if (res.itemsCount != undefined)
          this.paginatorLength = res.itemsCount;  // Update the paginator length (total items)

        // Safely update the paginator state
        if (this.paginator) {
          this.paginator.pageIndex = this.pageIndex;  // Make sure the pageIndex stays in sync
          this.paginator.length = this.paginatorLength;
        }
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Failed to load compaines');
      }
    );
  }
  // Open the edit dialog for a blog
  EditCompany(Id: number): void {
    this.spinner.show();
    this.backend.GetCompanyById(Id).subscribe(
      (res) => {
        this.spinner.hide();
        const updateref = this.dialog.open(EditCompanyComponent, {
          width: '900px',
          height: '450px',
          data: res.entity,
        });
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Load Company failed');
      }
    );

  }

  // Delete an organization
  DeleteCompany(Id: number): void {
    let info = new ConfirmDialogData(
      'Are You Sure ?',
      'Are You Want To Delete This Company',
      'Confirm',
      'Discard'
    );

    const dialogres = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: info,
    });

    dialogres.afterClosed().subscribe((result) => {
      if (result) {
        this.spinner.show();
        this.backend.DeleteCompany(Id).subscribe(
          (res) => {
            this.spinner.hide();
            this.toastr.success('Deleted successfully');
            this.loadData();  // Reload data after deletion
          },
          (err) => {
            this.spinner.hide();
            this.toastr.error('Delete failed');
          }
        );
      }
    });
  }
}
