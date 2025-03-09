import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { SigninComponent } from './pages/shared/signin/signin.component';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { FormsModule, NgForm } from '@angular/forms';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatSortModule} from '@angular/material/sort';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from 'ngx-toastr';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { ManageOrgnizationComponent } from './pages/orgnizations/manage-orgnization/manage-orgnization.component';
import { EditOrgnizationComponent } from './pages/orgnizations/edit-orgnization/editorgnization.component';
import { OrgnizationDetailsComponent } from './pages/orgnizations/orgnization-details/orgnization-details.component';
import { CreateOrgnizationComponent } from './pages/orgnizations/create-orgnization/createorgnization.component';
import { NavComponent } from './sharedcomponent/nav/nav.component';
import { FooterComponent } from './sharedcomponent/footer/footer.component';
import { ConfirmDialogComponent } from './sharedcomponent/confirm-dialog/confirm-dialog.component';
import { ErrorComponent } from './pages/shared/error/error.component';
import { AppComponent } from './app.component';
import { ManageCompainesComponent } from './pages/companies/manage-compaines/manage-compaines.component';
import { CreateCompanyComponent } from './pages/companies/create-company/create-company.component';
import { EditCompanyComponent } from './pages/companies/edit-company/edit-company.component';
import { CompanyDetailsComponent } from './pages/companies/company-details/company-details.component';
import { MaindashboardComponent } from './pages/dashboard/maindashboard/maindashboard.component';
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, '../../../assets/languages/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    ManageOrgnizationComponent,
    EditOrgnizationComponent,
    OrgnizationDetailsComponent,
    CreateOrgnizationComponent,
    ErrorComponent,
    NavComponent,
    FooterComponent,
    ConfirmDialogComponent,
    ManageCompainesComponent,
    CreateCompanyComponent,
    EditCompanyComponent,
    CompanyDetailsComponent,
    MaindashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CarouselModule.forRoot(),
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatTabsModule,
    MatTableModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    MatDialogModule,
    NgxSpinnerModule,
    ToastrModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: createTranslateLoader,
          deps: [HttpClient] // Dependencies
      }
  }),
    FormsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(private translate: TranslateService) {
    const savedLanguage = localStorage.getItem('selectedLanguage') || 'en';
    translate.setDefaultLang(savedLanguage);
    translate.use(savedLanguage);
  }

}
