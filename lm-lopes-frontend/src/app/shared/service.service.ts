import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }

  host = `${environment.API_GATEWAY}`;

  public endpoint = {
    listar: `${this.host}/OrdemServico`,
    cadastrar: `${this.host}/OrdemServico`,
    listarUsuarios: `${this.host}/Usuario`,
    listarUsuariosPorId: `${this.host}/OrdemServico/consulta/`,
    cadastrarUsuarios: `${this.host}/Usuario/Add`,
  };

  constructor(private http: HttpClient) { }

  listarOrdemServico(): Observable<any> {
    return this.http.get<any>(this.endpoint.listar, { headers: this.getAuthHeaders() });
  }

  cadastrarOrdemServico(dados: any): Observable<any> {
    return this.http.post<any>(this.endpoint.cadastrar, dados, { headers: this.getAuthHeaders() });
  }

  editarOrdemServico(dados: any): Observable<any> {
    return this.http.put<any>(this.endpoint.cadastrar, dados, { headers: this.getAuthHeaders() });
  }

  listarUsuarios(): Observable<any> {
    return this.http.get<any>(this.endpoint.listarUsuarios, { headers: this.getAuthHeaders() });
  }

  getPdfById(id:any){
    return this.http.get<any>(this.endpoint.listarUsuariosPorId + id, { headers: this.getAuthHeaders() });
  }

  cadastrarUsuario(dados: any): Observable<any> {
    return this.http.post<any>(this.endpoint.cadastrarUsuarios, dados, { headers: this.getAuthHeaders() });
  }
}
