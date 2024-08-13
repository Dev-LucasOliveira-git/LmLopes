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
        const startY = 15; 
        const lineSpacing = 5;

        doc.setFontSize(8);
        doc.text('Rua Marco Palmezzano, 231 - Americanópolis / SP – Cep: 04337-160', textX, startY, { align: 'right' });
        doc.text('Fone: (11) 5594-1075 / (11) 5199-6014 (11) 9.4172-7631', textX, startY + lineSpacing, { align: 'right' });
        doc.text('E-mail: atendimento@lmlopes.net / www.lmlopes.net', textX, startY + lineSpacing * 2, { align: 'right' });
        doc.text('CNPJ: 23.030.998/0001-72 / I.E 144.891.861.113', textX, startY + lineSpacing * 3, { align: 'right' });

        const blueColor = '#366183';
        const blackColor = '#000';

        doc.setDrawColor(blueColor);
        doc.setLineWidth(1);
        doc.line(10, 40, 200, 40); 

        const textStartY = 45; 
        const textLineSpacing = 8; 
        const rightTextX = 125;

        doc.setFontSize(10);
        doc.text(`Número de OS ${pdf.numero} - Número Prisma: ${pdf.numeroPrisma}`, 10, textStartY);
        doc.text(`Colp: ${pdf.colp}`, 10, textStartY + textLineSpacing);
        doc.text(`Data: ${pdf.dataHora}`, rightTextX, textStartY + textLineSpacing);
        doc.text(`Equipamento: ${pdf.equipamento}`, 10, textStartY + textLineSpacing * 2);
        doc.text(`Nº Série: ${pdf.numSerie}`, rightTextX, textStartY + textLineSpacing * 2);
        doc.text(`Endereço: ${pdf.endereco}`, 10, textStartY + textLineSpacing * 3);
        doc.text(`Telefone: ${pdf.telefone}`, rightTextX, textStartY + textLineSpacing * 3);
        doc.text(`Contato: ${pdf.contato}`, 10, textStartY + textLineSpacing * 4);

        doc.setDrawColor(blueColor);
        doc.setLineWidth(1);
        doc.line(10, textStartY + textLineSpacing * 5, 200, textStartY + textLineSpacing * 5); 

        const tableStartY = textStartY + textLineSpacing * 6; 
        const tableLineSpacing = 7; 
        const tableX1 = 10; 
        const tableX2 = 200; 
        const col1X = 10; 
        const col2X = 80; 
        const col3X = 130;

        doc.setTextColor(blackColor);
        doc.text('Data', col1X + 2, tableStartY);
        doc.text('Início', col2X + 2, tableStartY);
        doc.text('Término', col3X + 2, tableStartY);

        doc.text(pdf.dataHora, col1X + 2, tableStartY + tableLineSpacing);
        doc.text(pdf.horaInicio, col2X + 2, tableStartY + tableLineSpacing);
        doc.text(pdf.horaFim, col3X + 2, tableStartY + tableLineSpacing);

        doc.setLineWidth(0.5);
        doc.line(tableX1, tableStartY - 4, tableX2, tableStartY - 4); 
        doc.line(tableX1, tableStartY + tableLineSpacing + 2, tableX2, tableStartY + tableLineSpacing + 2);
        doc.line(tableX1, tableStartY - 4, tableX1, tableStartY + tableLineSpacing + 2); 
        doc.line(tableX2, tableStartY - 4, tableX2, tableStartY + tableLineSpacing + 2); 
        doc.line(col2X, tableStartY - 4, col2X, tableStartY + tableLineSpacing + 2); 
        doc.line(col3X, tableStartY - 4, col3X, tableStartY + tableLineSpacing + 2); 


        const activityTableStartY = tableStartY + tableLineSpacing * 3; // Start Y position for the new section
        const activityLineSpacing = 6; // Line spacing for the activity rows
        const activityTableX1 = 10; // X coordinate for the left table border
        const activityTableX2 = 200; // X coordinate for the right table border
        const activityCol1X = 10; // X coordinate for the first column
        const activityCol2X = 110; // X coordinate for the second column

        // Activity table header
        doc.setTextColor(blackColor);
        doc.text('Atividade', activityCol1X + 2, activityTableStartY);
        doc.text('Defeito', activityCol2X + 2, activityTableStartY);

        // Activity rows
        const markX = (condition: boolean) => condition ? 'X' : '';

        doc.text(`( ${markX(pdf.atividade === 'Preventiva')} ) Preventiva`, activityCol1X + 2, activityTableStartY + activityLineSpacing);
        doc.text(`( ${markX(pdf.defeito === 'Elétrico')} ) Elétrico`, activityCol2X + 2, activityTableStartY + activityLineSpacing);

        doc.text(`( ${markX(pdf.atividade === 'Corretiva')} ) Corretiva`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 2);
        doc.text(`( ${markX(pdf.defeito === 'Mecânico')} ) Mecânico`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 2);

        doc.text(`( ${markX(pdf.atividade === 'Instalação')} ) Instalação`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 3);
        doc.text(`( ${markX(pdf.defeito === 'Óptico')} ) Óptico`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 3);

        doc.text(`( ${markX(pdf.atividade === 'Movimentação')} ) Movimentação`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 4);
        doc.text(`( ${markX(pdf.defeito === 'Outros')} ) Outros`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 4);

        doc.text(`( ${markX(pdf.atividade === 'Outros')} ) Outros`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 5);

        // Complement fields
        const complementStartY = activityTableStartY + activityLineSpacing * 6; // Start Y position for the complement fields
        doc.text(`${pdf.complementoAtividade || ''}`, activityCol1X + 2, complementStartY);
        doc.text(`${pdf.complementoDefeito || ''}`, activityCol2X + 2, complementStartY);

        // Activity and defect table borders
        doc.setLineWidth(0.5);
        doc.line(activityTableX1, activityTableStartY - 4, activityTableX2, activityTableStartY - 4); // Top border
        doc.line(activityTableX1, complementStartY + 2, activityTableX2, complementStartY + 2); // Bottom border
        doc.line(activityTableX1, activityTableStartY - 4, activityTableX1, complementStartY + 2); // Left border
        doc.line(activityTableX2, activityTableStartY - 4, activityTableX2, complementStartY + 2); // Right border
        doc.line(activityCol2X - 1, activityTableStartY - 4, activityCol2X - 1, complementStartY + 2); // Column 1-2 divider

        const servicesStartY = activityTableStartY + activityLineSpacing * 6 + 15; 
        const servicesLineSpacing = 8; 
        doc.setFontSize(10);
        doc.setTextColor(blackColor);
        doc.text('Descrição dos Serviços Executados:', 10, servicesStartY);

        doc.setFontSize(9);
        const descriptionTextWidth = 190; 

        doc.text(`( ${markX(pdf.limpeza)} ) Limpeza: Oculares, Prismas, Binocular, Objetiva, Diafragma do sistema de desvio óptico, sistema do coletor, fonte de iluminação, câmera de vídeo.`, 10, servicesStartY + servicesLineSpacing, { maxWidth: descriptionTextWidth });
        doc.text(`( ${markX(pdf.ajuste)} ) Ajuste: Prismas, Divisor de imagem, Adaptador da Câmera, botão de movimento macrométrico, sistema de fricção de movimento macrométrico, fricção do movimento de ângulo (vertical), movimentos articulados do braço articulados, elétricos, mecânicos e iluminação.`, 10, servicesStartY + servicesLineSpacing * 2.3, { maxWidth: descriptionTextWidth });
        doc.text(`( ${markX(pdf.lubrificacao)} ) Lubrificação: Sistema de refrigeração da fonte de iluminação, movimentos articulados, substituição de lubrificantes especiais.`, 10, servicesStartY + servicesLineSpacing * 4, { maxWidth: descriptionTextWidth });

        const observationsStartY = servicesStartY + servicesLineSpacing * 3 + 15; 
        const observationsLineSpacing = 8; 

        doc.setFontSize(10);
        doc.setTextColor(blackColor);
        doc.text('Observações:', 10, observationsStartY);

        doc.setFontSize(9);
        doc.text(pdf.obs || '', 10, observationsStartY + observationsLineSpacing, { maxWidth: descriptionTextWidth });

        doc.setDrawColor(blackColor);
        doc.setLineWidth(0.5);
        doc.line(10, observationsStartY + observationsLineSpacing * 1, 200, observationsStartY + observationsLineSpacing * 1); // Line 1
        doc.line(10, observationsStartY + observationsLineSpacing * 2, 200, observationsStartY + observationsLineSpacing * 2); // Line 2

        doc.save('ordem_de_servico.pdf');
    };
}






  
  
  
  }