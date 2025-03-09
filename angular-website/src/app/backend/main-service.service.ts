import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginDTO } from '../dtos/authantications/LoginDTO';
import { OrgnizationDTO } from '../dtos/orgnizations/OrgnizationDTO';
import { DatePaginationResponse } from '../dtos/apis/DatePaginationResponse';
import { DatePaginationRequest } from '../dtos/apis/DatePaginationRequest'
import { SearchOrgnizationDTO } from '../dtos/orgnizations/SearchOrgnizationDTO';
import { DataResponseDto } from '../dtos/apis/DataResponseDto';
import { OrgnizationForEditDTO } from '../dtos/orgnizations/OrgnizationForEditDTO';
import { SearchCompanyDTO } from '../dtos/companies/SearchCompanyDTO';
import { CompanyDTO } from '../dtos/companies/CompanyDTO';
import { CompanyForEditDTO } from '../dtos/companies/CompanyForEditDTO';
@Injectable({
  providedIn: 'root',
})
export class MainServiceService {
  //Service Will Containts of Many Fucation To Call Many Endpoint
  private baseURL: string = 'https://localhost:44300';

  constructor(private http: HttpClient, private router: Router) { }

  Login(input: LoginDTO): Observable<any> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain'
    });
    return this.http.post(`${this.baseURL}/api/Auth/Login`, input, { headers, responseType: 'text' })
  }
  SearchOrgnization(input: DatePaginationRequest<SearchOrgnizationDTO>): Observable<DatePaginationResponse<OrgnizationDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });

    const options = { headers: headers };

    let params = new HttpParams()
      .set('size', input.size?.toString() || '10')
      .set('index', input.index?.toString() || '0');

    if (input.input?.name) {
      params = params.set('name', input.input.name);
    }
    if (input.input?.code) {
      params = params.set('code', input.input.code);
    }
    if (input.input?.countryId) {
      params = params.set('countryId', input.input.countryId.toString());
    }

    return this.http.get<DatePaginationResponse<OrgnizationDTO>>(
      `${this.baseURL}/api/Organization/Search-Orgnization`,
      { headers: headers, params: params }
    );
  }
  SearchCompany(input: DatePaginationRequest<SearchCompanyDTO>): Observable<DatePaginationResponse<CompanyDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });

    const options = { headers: headers };

    let params = new HttpParams()
      .set('size', input.size?.toString() || '10')
      .set('index', input.index?.toString() || '0');

    if (input.input?.name) {
      params = params.set('name', input.input.name);
    }
    if (input.input?.code) {
      params = params.set('code', input.input.code);
    }
    if (input.input?.countryId) {
      params = params.set('countryId', input.input.countryId.toString());
    }
    if (input.input?.organizationId) {
      params = params.set('organizationId', input.input.organizationId.toString());
    }

    return this.http.get<DatePaginationResponse<CompanyDTO>>(
      `${this.baseURL}/api/Company/Search-Company`,
      { headers: headers, params: params }
    );
  }
  GetOrgnizationById(orgnizationId:number):Observable<DataResponseDto<OrgnizationForEditDTO>>{
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DataResponseDto<OrgnizationForEditDTO>>(`${this.baseURL}/api/Organization/Get-Orgnization/${orgnizationId}`, { headers: headers })
  }
  GetCompanyById(companyId:number):Observable<DataResponseDto<CompanyForEditDTO>>{
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DataResponseDto<CompanyForEditDTO>>(`${this.baseURL}/api/Company/Get-Company/${companyId}`, { headers: headers })
  }
  DeleteOrgnization(orgnizationId: number): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.delete<DataResponseDto<string>>(`${this.baseURL}/api/Organization/Delete-Orgnization/${orgnizationId}`, { headers: headers })
  }
  DeleteCompany(companyId: number): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.delete<DataResponseDto<string>>(`${this.baseURL}/api/Company/Delete-Company/${companyId}`, { headers: headers })
  }
  Logout() {
    localStorage.removeItem('isLoggedIn')
    localStorage.removeItem('token')
    localStorage.removeItem('userId')
    this.router.navigate([''])

    //return this.http
  }




}
