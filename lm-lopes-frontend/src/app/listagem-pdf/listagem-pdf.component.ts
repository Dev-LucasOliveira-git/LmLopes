import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ServiceService } from '../shared/service.service';
import { catchError, map, of } from 'rxjs';
import { faDownload, faPen } from '@fortawesome/free-solid-svg-icons';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listagem-pdf',
  templateUrl: './listagem-pdf.component.html',
  styleUrls: ['./listagem-pdf.component.css']
})
export class ListagemPdfComponent implements OnInit {

  faDownload = faDownload;
  faPen = faPen

  displayedColumns: string[] = ['nomeEngenheiro', 'dataHora', 'equipamento', 'acao', 'editar'];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private service: ServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    console.log("Component initialized");
    this.carregar();
  }

  editar(id: any) {
    this.service.getPdfById(id).subscribe(
      (pdfData) => {
        this.router.navigate(['/cadastrar-pdf'], { state: { pdfData: pdfData } });
      },
      (error) => {
        console.error('Error retrieving PDF data:', error);
      }
    );
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

  formatDateTime(dateString: string | number | Date) {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');
    
    return `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;
  }

  async onRowClicked(pdf: any) {
    const doc = new jsPDF();
    const img = new Image();
    img.src = 'assets/logo/logo-lm.png';

    img.onload = () => {
        const imgWidth = img.width;
        const imgHeight = img.height;
        const imgRatio = imgHeight / imgWidth;
        const imgDisplayWidth = 70;
        const imgDisplayHeight = imgDisplayWidth * imgRatio;
        const blueColor = '#366183';
        const blackColor = '#000';

        doc.addImage(img, 'PNG', 10, 10, imgDisplayWidth, imgDisplayHeight);

        const textX = 190; 
        const startY = 15; 
        const lineSpacing = 5;

        doc.setFontSize(8);
        doc.text('Rua Marco Palmezzano, 231 - Americanópolis / SP – Cep: 04337-160', textX, startY, { align: 'right' });
        doc.text('Fone: (11) 5594-1075 / (11) 5199-6014 (11) 9.4172-7631', textX, startY + lineSpacing, { align: 'right' });

        doc.text('E-mail: ', textX - doc.getTextWidth("atendimento@lmlopes.net / www.lmlopes.net") - 1 , startY + lineSpacing * 2, { align: 'right' });
        doc.setTextColor(blueColor)
        doc.text('atendimento@lmlopes.net / www.lmlopes.net', textX , startY + lineSpacing * 2, { align: 'right' });

        doc.setTextColor(blackColor)
        doc.text('CNPJ: 23.030.998/0001-72 / I.E 144.891.861.113', textX, startY + lineSpacing * 3, { align: 'right' });

        doc.setDrawColor(blueColor);
        doc.setLineWidth(1);
        doc.line(10, 40, 200, 40); 

        const textStartY = 45; 
        const textLineSpacing = 8; 
        const rightTextX = 125;

        doc.setFontSize(10);
        doc.text(`Número de OS ${pdf.numero} - Número Prisma: ${pdf.numeroPrisma}`, 10, textStartY);

        doc.setFont('Helvetica', 'bold');
        doc.text(`Colp: ${pdf.colp}`, 10, textStartY + textLineSpacing);

        doc.setFont('Helvetica', 'normal');
        doc.text(`Data: ${pdf.dataHora}`, rightTextX, textStartY + textLineSpacing);
        doc.text(`Equipamento: ${pdf.equipamento}`, 10, textStartY + textLineSpacing * 2);
        doc.text(`Nº Série: ${pdf.numSerie}`, rightTextX, textStartY + textLineSpacing * 2);
        doc.text(`Endereço: ${pdf.endereco}`, 10, textStartY + textLineSpacing * 3);

        doc.setFont('Helvetica', 'bold');
        doc.text(`Telefone: ${pdf.telefone}`, rightTextX, textStartY + textLineSpacing * 3);

        doc.setFont('Helvetica', 'bold');
        doc.text(`Contato: ${pdf.contato}`, 10, textStartY + textLineSpacing * 4);

        doc.setFont('Helvetica', 'normal');
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

        const formattedDataHora = this.formatDateTime(pdf.dataHora);
        const formattedHoraInicio = this.formatDateTime(pdf.horaInicio);
        const formattedHoraFim = this.formatDateTime(pdf.horaFim);
        
        doc.text(formattedDataHora, col1X + 2, tableStartY + tableLineSpacing);
        doc.text(formattedHoraInicio, col2X + 2, tableStartY + tableLineSpacing);
        doc.text(formattedHoraFim, col3X + 2, tableStartY + tableLineSpacing);

        doc.setLineWidth(0.5);
        doc.line(tableX1, tableStartY - 4, tableX2, tableStartY - 4); 
        doc.line(tableX1, tableStartY + tableLineSpacing + 2, tableX2, tableStartY + tableLineSpacing + 2);
        doc.line(tableX1, tableStartY - 4, tableX1, tableStartY + tableLineSpacing + 2); 
        doc.line(tableX2, tableStartY - 4, tableX2, tableStartY + tableLineSpacing + 2); 
        doc.line(col2X, tableStartY - 4, col2X, tableStartY + tableLineSpacing + 2); 
        doc.line(col3X, tableStartY - 4, col3X, tableStartY + tableLineSpacing + 2); 


        const activityTableStartY = tableStartY + tableLineSpacing * 3; 
        const activityLineSpacing = 6; 
        const activityTableX1 = 10; 
        const activityTableX2 = 200; 
        const activityCol1X = 10; 
        const activityCol2X = 110; 

        doc.setTextColor(blackColor);
        doc.text('Atividade', activityCol1X + 2, activityTableStartY);
        doc.text('Defeito', activityCol2X + 2, activityTableStartY);

        const markX = (condition: boolean) => condition ? 'X' : '  ';

        doc.text(`(${markX(pdf.atividade === 'Preventiva')}) Preventiva`, activityCol1X + 2, activityTableStartY + activityLineSpacing);
        doc.text(`(${markX(pdf.defeito === 'Elétrico')}) Elétrico`, activityCol2X + 2, activityTableStartY + activityLineSpacing);

        doc.text(`(${markX(pdf.atividade === 'Corretiva')}) Corretiva`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 2);
        doc.text(`(${markX(pdf.defeito === 'Mecânico')}) Mecânico`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 2);
        doc.text(`(${markX(pdf.atividade === 'Instalação')}) Instalação`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 3);
        doc.text(`(${markX(pdf.defeito === 'Óptico')}) Óptico`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 3);
        doc.text(`(${markX(pdf.atividade === 'Movimentação')}) Movimentação`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 4);
        doc.text(`(${markX(pdf.defeito === 'Outros')}) Outros`, activityCol2X + 2, activityTableStartY + activityLineSpacing * 4);
        doc.text(`(${markX(pdf.atividade === 'Outros')}) Outros`, activityCol1X + 2, activityTableStartY + activityLineSpacing * 5);

        const complementStartY = activityTableStartY + activityLineSpacing * 6; 
        doc.text(`${pdf.complementoAtividade || ''}`, activityCol1X + 2, complementStartY);
        doc.text(`${pdf.complementoDefeito || ''}`, activityCol2X + 2, complementStartY);

        doc.setLineWidth(0.5);
        doc.line(activityTableX1, activityTableStartY - 4, activityTableX2, activityTableStartY - 4); 
        doc.line(activityTableX1, complementStartY + 2, activityTableX2, complementStartY + 2); 
        doc.line(activityTableX1, activityTableStartY - 4, activityTableX1, complementStartY + 2); 
        doc.line(activityTableX2, activityTableStartY - 4, activityTableX2, complementStartY + 2); 
        doc.line(activityCol2X - 1, activityTableStartY - 4, activityCol2X - 1, complementStartY + 2); 

        const servicesStartY = activityTableStartY + activityLineSpacing * 6 + 15; 
        const servicesLineSpacing = 6; 
        doc.setFontSize(10);
        doc.setTextColor(blackColor);
        doc.text('Descrição dos Serviços Executados:', 10, servicesStartY);

        doc.setFontSize(9);
        const descriptionTextWidth = 175; 

        var boldText = `(${markX(pdf.limpeza)}) Limpeza: `;
        var textAfterBold = 'Oculares, Prismas, Binocular, Objetiva, Diafragma do sistema de desvio óptico, sistema do coletor, fonte de iluminação, câmera de vídeo.';      
        
        doc.setFont('Helvetica', 'bold');
        doc.text(boldText, 10, servicesStartY + servicesLineSpacing, { maxWidth: descriptionTextWidth });
        
        var underlineThickness = 0.5; 
        var underlineOffset = 1;       
        doc.setDrawColor(0, 0, 0); 
        doc.setLineWidth(underlineThickness);
        doc.line(10 + doc.getTextWidth(`${markX(pdf.limpeza)}) `)+1, servicesStartY + servicesLineSpacing + underlineOffset, 10 + doc.getTextWidth(boldText), servicesStartY + servicesLineSpacing+ underlineOffset);

                
        doc.setFont('Helvetica', 'normal');
        doc.text(textAfterBold, 10 + doc.getTextWidth(boldText) + 1, servicesStartY + servicesLineSpacing, { maxWidth: descriptionTextWidth });

        boldText = `(${markX(pdf.ajuste)}) Ajuste: `;
        textAfterBold = 'Prismas, Divisor de imagem, Adaptador da Câmera, botão de movimento macrométrico, sistema de fricção de movimento macrométrico, fricção do movimento de ângulo (vertical), movimentos articulados do braço articulados, elétricos, mecânicos e iluminação.';    
        doc.setFont('Helvetica', 'bold');
        doc.text(boldText, 10, servicesStartY + servicesLineSpacing * 2.2, { maxWidth: descriptionTextWidth });
       
        var underlineThickness = 0.5; 
        var underlineOffset = 1;      
     
        doc.setDrawColor(0, 0, 0);
        doc.setLineWidth(underlineThickness);
        doc.line(10 + doc.getTextWidth(`${markX(pdf.ajuste)}) `)+1, (servicesStartY + servicesLineSpacing * 2.2 ) + underlineOffset, 10 + doc.getTextWidth(boldText), (servicesStartY + servicesLineSpacing * 2.2 )+ underlineOffset);

       
        doc.setFont('Helvetica', 'normal');
        doc.text(textAfterBold, 10 + doc.getTextWidth(boldText) + 1, servicesStartY + servicesLineSpacing * 2.2, { maxWidth: descriptionTextWidth });

        boldText = `(${markX(pdf.lubrificacao)}) Lubrificação: `;
        textAfterBold = 'Sistema de refrigeração da fonte de iluminação, movimentos articulados, substituição de lubrificantes especiais.';
        doc.setFont('Helvetica', 'bold');
        doc.text(boldText, 10, servicesStartY + servicesLineSpacing * 4, { maxWidth: descriptionTextWidth });
        
        var underlineThickness = 0.5; 
        var underlineOffset = 1;     
        doc.setDrawColor(0, 0, 0); 
        doc.setLineWidth(underlineThickness);
        doc.line(10 + doc.getTextWidth(`${markX(pdf.lubrificacao)}) `)+1, (servicesStartY + servicesLineSpacing * 4 ) + underlineOffset, 10 + doc.getTextWidth(boldText), (servicesStartY + servicesLineSpacing * 4 )+ underlineOffset);

        
        doc.setFont('Helvetica', 'normal');
        doc.text(textAfterBold, 10 + doc.getTextWidth(boldText) + 2, servicesStartY + servicesLineSpacing * 4, { maxWidth: descriptionTextWidth });

        const observationsStartY = servicesStartY + servicesLineSpacing * 3 + 15; 
        const observationsLineSpacing = 8; 

        doc.setFontSize(10);
        doc.setTextColor(blackColor);
        doc.setFont('Helvetica', 'bold');

        doc.text('Observações:', 10, observationsStartY);
        underlineThickness = 0.5;
        underlineOffset = 1;      

        doc.setDrawColor(0, 0, 0); 
        doc.setLineWidth(underlineThickness);
        doc.line(10, observationsStartY + underlineOffset, 10 + doc.getTextWidth("Observações:"), observationsStartY + underlineOffset);


        doc.setFontSize(9);
        doc.setFont('Helvetica', 'normal');
        doc.text(pdf.obs || '', 10, observationsStartY + observationsLineSpacing, { maxWidth: descriptionTextWidth });

        doc.setDrawColor(blackColor);
        doc.setLineWidth(0.5);
        doc.line(10, observationsStartY + observationsLineSpacing * 1.10, 200, observationsStartY + observationsLineSpacing * 1.10);
        doc.line(10, observationsStartY + observationsLineSpacing * 2, 200, observationsStartY + observationsLineSpacing * 2); 
        
        const materialsStartY = servicesStartY + servicesLineSpacing * 10; 
        const materialsLineSpacing = 6; 

        doc.setFont('Helvetica', 'bold');
        doc.text('Materiais Utilizados:', 10, materialsStartY);

        doc.setFont('Helvetica', 'normal');
        doc.text('Qtd', col1X + 2, materialsStartY + materialsLineSpacing);
        doc.text('Descrição', col2X + 2, materialsStartY + materialsLineSpacing);

        const drawMaterialRow = (y: number, material: any) => {
            doc.text(material.quantidade.toString(), col1X + 2, y);
            doc.text(material.descricao, col2X + 2, y);
        };

        pdf.materiaisUtilizados.forEach((material: any, index: number) => {
            drawMaterialRow(materialsStartY + materialsLineSpacing * (index + 2), material);
        });

        doc.setLineWidth(0.5);
        doc.line(activityTableX1, materialsStartY + materialsLineSpacing - 4, activityTableX2, materialsStartY + materialsLineSpacing - 4); 
        doc.line(activityTableX1, materialsStartY + materialsLineSpacing * (pdf.materiaisUtilizados.length + 2) - 4, activityTableX2, materialsStartY + materialsLineSpacing * (pdf.materiaisUtilizados.length + 2) - 4); 
        doc.line(activityTableX1, materialsStartY + materialsLineSpacing - 4, activityTableX1, materialsStartY + materialsLineSpacing * (pdf.materiaisUtilizados.length + 2) - 4); 
        doc.line(activityTableX2, materialsStartY + materialsLineSpacing - 4, activityTableX2, materialsStartY + materialsLineSpacing * (pdf.materiaisUtilizados.length + 2) - 4); 
        doc.line(col2X - 1, materialsStartY + materialsLineSpacing - 4, col2X - 1, materialsStartY + materialsLineSpacing * (pdf.materiaisUtilizados.length + 2) - 4); 

             const conclusionStartY = servicesStartY + servicesLineSpacing * 15;

             doc.setFontSize(8);
             const conclusionText = `( ${pdf.trabalhoConcluido === 'SIM' ? 'X' : ' '} ) Sim  ( ${pdf.trabalhoConcluido === 'NÃO' ? 'X' : ' '} ) Não  ( ${pdf.trabalhoConcluido === 'AGUARDANDO PEÇAS' ? 'X' : ' '} ) Aguardando Peças`;
             doc.setFontSize(10);
             doc.text(`Trabalho Concluído: ${conclusionText}`, 10, conclusionStartY);     
             const detailsStartY = conclusionStartY + servicesLineSpacing * 2;
             doc.setFontSize(10);
             doc.setFont('Helvetica', 'bold');
             doc.text('Dados do Engenheiro / Técnico', 10, detailsStartY);
             doc.text('Dados do Cliente', 110, detailsStartY);
     
             doc.setFont('Helvetica', 'normal');
             doc.text(`Nome: ${pdf.nomeEngenheiro}`, 10, detailsStartY + 7);
             doc.text(`RG / CREA: ${pdf.rg_Crea}`, 10, detailsStartY + 14);
             doc.text('Assinatura: _____________________________', 10, detailsStartY + 21);

     
             doc.text(`Nome: ${pdf.nomeCliente}`, 110, detailsStartY + 7);
             doc.text(`Cargo: ${pdf.cargoCliente}`, 110, detailsStartY + 14);
             doc.text('Assinatura: _____________________________', 110, detailsStartY + 21);
     
        doc.save(`OS_${pdf.numero}.pdf`);
    };
}






  
  
  
  }