import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UtilService {

  constructor(private http: HttpClient) { }

  save(datos: any): Observable<any> {
    const url = 'http://localhost:9999'; // esto va en environments
    return this.http.post<any>(`${url}`, datos);
  }

}
