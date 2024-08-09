import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) { }

  login(email: string, senha: string): Observable<any> {
    const url = 'http://lmlopesordermanager.online/api/Login';
    const body = { email, senha };
    return this.http.post<any>(url, body);
  }
}