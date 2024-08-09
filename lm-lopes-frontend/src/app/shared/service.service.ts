import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  host = `${environment.API_GATEWAY}`

  public endpoint = {
    listar: `${this.host}/`,
    cadastrar: `${this.host}/`,
  }

  constructor(private http: HttpClient) { }

  listarOrdemServico(): Observable<any> {
    return this.http.get<any>(`${this.endpoint.listar}`);
  }

  cadastrarOrdemServico(dados: any): Observable<any> {
    return this.http.post<any>(`${this.endpoint.cadastrar}`, dados )
  }
}