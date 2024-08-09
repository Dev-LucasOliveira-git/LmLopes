import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../shared/service.service';
import { catchError, map, throwError } from 'rxjs';

@Component({
  selector: 'app-listagem-pdf',
  templateUrl: './listagem-pdf.component.html',
  styleUrl: './listagem-pdf.component.css'
})
export class ListagemPdfComponent implements OnInit {

  pdf$: any

  constructor(private service: ServiceService) {

  }

  ngOnInit(): void {
    this.carregar()
  }

  public carregar() {
    this.pdf$ = this.service.listarOrdemServico().pipe(
      map((data: any) => {
        return data
      }), catchError(err => {
        return throwError(err)
      })
    )
  }



}
