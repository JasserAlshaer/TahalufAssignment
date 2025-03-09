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

@Component({
  selector: 'app-manage-compaines',
  templateUrl: './manage-compaines.component.html',
  styleUrls: ['./manage-compaines.component.css']
})
export class ManageCompainesComponent {
displayedColumns: string[] = ['id', 'CompanyName', 'code', 'countryName', 'creationDate', 'Actions'];

  input: DatePaginationRequest<SearchCompanyDTO> = new DatePaginationRequest<SearchCompanyDTO>();
  dataSource: MatTableDataSource<CompanyDTO> = new MatTableDataSource();
  CompanyDTOArray: CompanyDTO[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  @ViewChild(MatSort) sort: MatSort | undefined;
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
  }

  ngAfterViewInit(): void {
    this.loadData();
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

  // This method loads the data from the backend
  loadData(): void {
    debugger
    this.spinner.show();
    this.input.index = this.pageIndex;
    this.input.size = this.pageSize;

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
    this.backend.Logout();
  }

  // Navigate back to home page
  backToHome(): void {
    this.router.navigate(['']);
  }

  // Create a new blog
  CreateNewBlog(): void {
    this.router.navigate(['/create-blog']);
  }

  // Open the edit dialog for a blog
  EditCompany(Id: number): void {
    this.spinner.show();
        this.backend.GetCompanyById(Id).subscribe(
          (res) => {
            this.spinner.hide();
            const updateref = this.dialog.open(EditCompanyComponent, {
              width: '700px',
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
