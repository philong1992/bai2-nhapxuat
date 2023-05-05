import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { NhapXuat } from '../_models/nhap-xuat';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HomeService {
  apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  
  getData(searchStr: string) {
    let params = new HttpParams().set('searchStr', searchStr)
    return this.http.get<NhapXuat[]>(this.apiUrl + 'Home/getData', {params});
  }

  add(model: NhapXuat) {
    return this.http.post<boolean>(this.apiUrl + 'Home/add', model);
  }
  delete(model: NhapXuat) {
    return this.http.post<boolean>(this.apiUrl + 'home/delete', model);
  }

  deleteSP(sophieu: string) {
    let params = new HttpParams().set('sophieu', sophieu)
    return this.http.get<boolean>(this.apiUrl + 'Home/deleteSP', {params})
  }
}
