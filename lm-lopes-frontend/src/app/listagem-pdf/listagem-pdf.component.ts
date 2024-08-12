import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ServiceService } from '../shared/service.service';
import { catchError, map, of } from 'rxjs';
import { faDownload } from '@fortawesome/free-solid-svg-icons';
import jsPDF from 'jspdf';

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
        this.dataSource.data = data.data; 
        this.dataSource.paginator = this.paginator; 
        this.dataSource.sort = this.sort; 
      }),
      catchError(err => {
        console.error("Error occurred:", err);
        this.dataSource.data = []; 
        return of([]);
      })
    ).subscribe(); 
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  async onRowClicked(pdf: any) {
    const doc = new jsPDF();
    const img = new Image();
    img.src = 'assets/logo/logo-lm.png';
    img.onload = () => {
      const imgWidth = img.width;
      const imgHeight = img.height;
      const imgRatio = imgHeight / imgWidth;
      const imgDisplayWidth = 40;  
      const imgDisplayHeight = imgDisplayWidth * imgRatio;  

      doc.addImage(img, 'PNG', 10, 10, imgDisplayWidth, imgDisplayHeight);

      const textX = 190;
      doc.setFontSize(10);
      doc.text('Rua Marco Palmezzano, 231 - Americanópolis / SP – Cep: 04337-160', textX, 15, { align: 'right' });
      doc.text('Fone: (11) 5594-1075 / (11) 5199-6014 (11) 9.4172-7631', textX, 20, { align: 'right' });
      doc.text('E-mail: atendimento@lmlopes.net / www.lmlopes.net', textX, 25, { align: 'right' });
      doc.text('CNPJ: 23.030.998/0001-72 / I.E 144.891.861.113', textX, 30, { align: 'right' });

      const blueColor = '#366183';
      doc.setDrawColor(blueColor);
      doc.setLineWidth(1);
      doc.line(10, 35, 200, 35);


      doc.setFontSize(12);
      doc.text(`Manutenção Preventiva Nº ${pdf.numero} - Número Prisma: ${pdf.numeroPrisma}`, 10, 85);
      
      doc.setFont('bold');
      doc.text(`colp ${pdf.colp}`, 10, 95);
      doc.setFont('normal');
      
      doc.text(`Equipamento: ${pdf.equipamento}`, 10, 105);
      
      doc.setFont('bold');
      doc.text(`Contato: ${pdf.contato}`, 10, 115);
      doc.setFont('normal');

      doc.save('ordem_de_servico.pdf');
    };
  }
}
