import { ChangeDetectorRef, Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { MainServiceService } from 'src/app/backend/main-service.service';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { OrgnizationDTO } from 'src/app/dtos/orgnizations/OrgnizationDTO';
import { DatePaginationRequest } from 'src/app/dtos/apis/DatePaginationRequest';
import { SearchOrgnizationDTO } from 'src/app/dtos/orgnizations/SearchOrgnizationDTO';
import { ConfirmDialogComponent } from 'src/app/sharedcomponent/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogData } from 'src/app/dtos/confirmDialog/conifrmdialog';
import { EditOrgnizationComponent } from '../edit-orgnization/editorgnization.component';
import { OrgnizationForEditDTO } from 'src/app/dtos/orgnizations/OrgnizationForEditDTO';
import { LookupItemDto } from 'src/app/dtos/lookups/LookupItemDto';

@Component({
  selector: 'app-manage-orgnization',
  templateUrl: './manage-orgnization.component.html',
  styleUrls: ['./manage-orgnization.component.css'],
})
export class ManageOrgnizationComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['code', 'orgnizationName','phone','Actions'];
  searchParams = {
    orgName: '',
    orgCode: '',
    country: ''
  };
  selectedCountryId: number | null | undefined = null; // Holds the ID of the selected country
  selectedCountryName: string = '';
  countries: LookupItemDto[] = []
  filteredCountries: LookupItemDto[] = [];
  inputDTO : SearchOrgnizationDTO = new SearchOrgnizationDTO()
  input: DatePaginationRequest<SearchOrgnizationDTO> = new DatePaginationRequest<SearchOrgnizationDTO>();
  dataSource: MatTableDataSource<OrgnizationDTO> = new MatTableDataSource();
  orgnizationDTOArray: OrgnizationDTO[] = [];

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
    const selectedCountry = this.countries.find((c) => c.id === countryId);
    if (selectedCountry) {
      this.searchParams.country = selectedCountry.name;
      this.selectedCountryName = selectedCountry.name; // Update the input field with the selected name
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


  loadOriginal(){
    this.spinner.show();
    this.searchParams = {
      orgName: '',
      orgCode: '',
      country: ''
    };
    this.inputDTO = new SearchOrgnizationDTO()
    this.selectedCountryId = null
    this.selectedCountryName = ''
    this.input = new DatePaginationRequest<SearchOrgnizationDTO>()
    this.input.index = 0;
    this.input.size = this.pageSize;
    this.backend.SearchOrgnization(this.input).subscribe(
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
        this.toastr.error('Failed to load organizations');
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
    if(this.searchParams.country != '' && this.searchParams.country != undefined){
      if(this.selectedCountryId != undefined){
        this.inputDTO.countryId = this.selectedCountryId
      }
    }
    if(this.searchParams.orgName != '' && this.searchParams.orgName != undefined){
      this.inputDTO.name = this.searchParams.orgName
    }
    if(this.searchParams.orgCode != '' && this.searchParams.orgCode != undefined){
      this.inputDTO.code = this.searchParams.orgCode
    }
    this.input.input = this.inputDTO
    // Make the backend request with the updated pagination parameters
    this.backend.SearchOrgnization(this.input).subscribe(
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
        this.toastr.error('Failed to load organizations');
      }
    );
  }

  // This method is called when the user applies a filter
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    // Reset to first page if the filter is applied
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  // Logout function
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

  // Navigate back to home page
  backToHome(): void {
    this.router.navigate(['']);
  }

  // Create a new blog
  CreateNewBlog(): void {
    this.router.navigate(['/create-blog']);
  }

  EditOrgnization(Id: number): void {
    this.spinner.show();
    this.backend.GetOrgnizationById(Id).subscribe(
      (res) => {
        this.spinner.hide();
        if (res.entity != undefined) {
          const updateref = this.dialog.open(EditOrgnizationComponent, {
            width: '900px',
            height: '450px',
            data: res.entity, 
          });
  
          updateref.afterClosed().subscribe(() => {
            this.loadData();
          });
        } else {
          this.toastr.error('Organization not found.');
        }
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Load Organization failed');
      }
    );
  }
  

  // Delete an organization
  DeleteOrgnization(Id: number): void {
    let info = new ConfirmDialogData(
      'Are You Sure ?',
      'Are You Want To Delete This Orgnization',
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
        this.backend.DeleteOrgnization(Id).subscribe(
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
