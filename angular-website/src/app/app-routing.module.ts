import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './pages/shared/error/error.component';
import { SigninComponent } from './pages/shared/signin/signin.component';
import { ManageOrgnizationComponent } from './pages/orgnizations/manage-orgnization/manage-orgnization.component';
import { CreateOrgnizationComponent } from './pages/orgnizations/create-orgnization/createorgnization.component';
import { ManageCompainesComponent } from './pages/companies/manage-compaines/manage-compaines.component';
import { CreateCompanyComponent } from './pages/companies/create-company/create-company.component';
import { MaindashboardComponent } from './pages/dashboard/maindashboard/maindashboard.component';

const routes: Routes = [
  {
    path:'',
    component:SigninComponent
  },
  {
    path:'manage-orgnization',
    component:ManageOrgnizationComponent
  },
  {
    path:'create-orgnization',
    component:CreateOrgnizationComponent
  },{
    path:'manage-compaines',
    component:ManageCompainesComponent
  },
  {
    path:'create-company',
    component:CreateCompanyComponent
  },
  {
    path:'error',
    component:ErrorComponent
  },
  {
    path:'dashboard',
    component:MaindashboardComponent
  },
  {
    path:'**',
    component:ErrorComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
