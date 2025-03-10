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
import { DashboardInfoDTO } from '../dtos/dashboards/DashboardInfoDTO';
import { LookupItemDto } from '../dtos/lookups/LookupItemDto';
import { CreateUpdateOrgnizationDTO } from '../dtos/orgnizations/CreateUpdateOrgnizationDTO';
import { CreateUpdateCompanyDTO } from '../dtos/companies/CreateUpdateCompanyDTO';
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
  GetCountries(itemId: number): Observable<DatePaginationResponse<LookupItemDto>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DatePaginationResponse<LookupItemDto>>(`${this.baseURL}/api/LookupItem/GetLookupItem?ItemTypeId=${itemId}`, { headers: headers });
  }
  GetDashboard(): Observable<DashboardInfoDTO> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DashboardInfoDTO>(`${this.baseURL}/api/Dashboard/GetDashbaordStastics`, { headers: headers })
  }
  GetOrgnizations(): Observable<OrgnizationForEditDTO[]> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<OrgnizationForEditDTO[]>(`${this.baseURL}/api/Organization/All-Ogrnization`, { headers: headers })
  }
  SearchOrgnization(input: DatePaginationRequest<SearchOrgnizationDTO>): Observable<DatePaginationResponse<OrgnizationDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });

    let params = new HttpParams()
      .set('size', input.size?.toString() || '10')
      .set('index', input.index?.toString() || '0');

    if (input.input?.name) {
      params = params.set('name', input.input.name);  // Changed from 'Input.Name' to 'name'
    }
    if (input.input?.code) {
      params = params.set('code', input.input.code);  // Changed from 'Input.Code' to 'code'
    }
    if (input.input?.countryId) {
      params = params.set('countryId', input.input.countryId.toString());  // Changed from 'Input.CountryId' to 'countryId'
    }

    return this.http.get<DatePaginationResponse<OrgnizationDTO>>(
      `${this.baseURL}/api/Organization/Search-Orgnization`,
      { headers: headers, params: params }
    );
  }
  SearchCompany(input: DatePaginationRequest<SearchCompanyDTO>): Observable<DatePaginationResponse<CompanyDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });


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
      params = params.set('orgnizationId', input.input.organizationId.toString());
    }

    return this.http.get<DatePaginationResponse<CompanyDTO>>(`${this.baseURL}/api/Companies/Search-Company`, { headers: headers, params: params }
    );
  }
  GetOrgnizationById(orgnizationId: number): Observable<DataResponseDto<OrgnizationForEditDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DataResponseDto<OrgnizationForEditDTO>>(`${this.baseURL}/api/Organization/Get-Orgnization/${orgnizationId}`, { headers: headers })
  }
  CreateOrgnization(input: CreateUpdateOrgnizationDTO): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.post<DataResponseDto<string>>(`${this.baseURL}/api/Organization/Create-Orgnization`, input, { headers: headers })
  }
  CreateCompany(input: CreateUpdateCompanyDTO): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.post<DataResponseDto<string>>(`${this.baseURL}/api/Companies/Create-Company`, input, { headers: headers })
  }
  UpdateOrgnization(input: CreateUpdateOrgnizationDTO): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.put<DataResponseDto<string>>(`${this.baseURL}/api/Organization/Update-Orgnization`, input, { headers: headers })
  }
  UpdateCompany(input: CreateUpdateCompanyDTO): Observable<DataResponseDto<string>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.put<DataResponseDto<string>>(`${this.baseURL}/api/Companies/Update-Company`, input, { headers: headers })
  }
  GetCompanyById(companyId: number): Observable<DataResponseDto<CompanyForEditDTO>> {
    const headers = new HttpHeaders({
      'Accept': 'text/plain',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<DataResponseDto<CompanyForEditDTO>>(`${this.baseURL}/api/Companies/Get-Company/${companyId}`, { headers: headers })
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
    return this.http.delete<DataResponseDto<string>>(`${this.baseURL}/api/Companies/Delete-Company/${companyId}`, { headers: headers })
  }
  Logout() {
    let currentId = localStorage.getItem('userId')
    const headers = new HttpHeaders({
      'Accept': 'text/plain'
    });
    return this.http.put(`${this.baseURL}/api/Auth/Logout/${currentId}`, null, { headers, responseType: 'text' })

    //return this.http
  }




}
