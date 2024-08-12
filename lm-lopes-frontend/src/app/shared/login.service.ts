import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/enviroment';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) { }
  
  host = `${environment.API_GATEWAY}`

  public endpoint = {
    login: `${this.host}/Login`,
    }

  login(email: string, senha: string): Observable<any> {
    const body = { email, senha };
    return this.http.post<any>(`${this.endpoint.login}`, body);
  }
}