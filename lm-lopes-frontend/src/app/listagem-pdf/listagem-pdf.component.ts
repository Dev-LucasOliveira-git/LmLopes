import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ServiceService } from '../shared/service.service';
import { catchError, map, of } from 'rxjs';
import { faDownload } from '@fortawesome/free-solid-svg-icons';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-listagem-pdf',
  templateUrl: './listagem-pdf.component.html',
  styleUrls: ['./listagem-pdf.component.css']
})
export class ListagemPdfComponent implements OnInit {

  faDownload = faDownload;

  displayedColumns: string[] = ['nomeEngenheiro', 'dataHora', 'equipamento', 'acao'];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private service: ServiceService) { }

  ngOnInit(): void {
    console.log("Component initialized");
    this.carregar();
  }

  public carregar() {
    this.service.listarOrdemServico().pipe(
      map((data: any) => {
        console.log("Received data:", data);
        this.dataSource.data = data.data; // Assign the received data to dataSource
        this.dataSource.paginator = this.paginator; // Assign paginator
        this.dataSource.sort = this.sort; // Assign sort
      }),
      catchError(err => {
        console.error("Error occurred:", err);
        this.dataSource.data = []; // Assign an empty array in case of error
        return of([]);
      })
    ).subscribe(); // Subscribe to the observable to trigger the request
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  async onRowClicked(pdf: any) {
    console.log('Row clicked:', pdf);
    
    const doc = new jsPDF();

    const content = `
      Nome do Engenheiro: ${pdf.nomeEngenheiro}
      Data e Hora: ${pdf.dataHora}
      Equipamento: ${pdf.equipamento}
    `;

    doc.text(content, 10, 10);
    doc.save('ordem_de_servico.pdf');
  }
}
