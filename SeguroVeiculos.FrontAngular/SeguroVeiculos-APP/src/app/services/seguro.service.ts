import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {
  baseURL = 'http://localhost:54274/api/Seguro';

  constructor(private http: HttpClient) { }

  getSeguros(param?: string){

    if(param === null || param === ''){
      return this.http.get(this.baseURL + '/lista');
    }
    return this.http.get(this.baseURL + '?nomeOuDocumento=' + param);
  }
}
