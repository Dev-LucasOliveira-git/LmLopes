import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ServiceService } from '../shared/service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UploadFormComponent } from './assinatura-pdf/UploadFormComponent';


@Component({
  selector: 'app-cadastrar-pdf',
  templateUrl: './cadastrar-pdf.component.html',
  styleUrls: ['./cadastrar-pdf.component.css']
})
export class CadastrarPdfComponent implements OnInit {
  cadastroForm!: FormGroup;
  isComplementoAtividadeEnabled = false;
  isComplementoDefeitoEnabled = false;
  pdfData: any; 
  bsModalRef!: BsModalRef;


  constructor(
    private fb: FormBuilder, 
    private serviceService: ServiceService, 
    private router: Router,
    public modalService: BsModalService
  ) {
    const navigation = this.router.getCurrentNavigation();
    this.pdfData = navigation?.extras?.state?.['pdfData'] || null;
  }

  ngOnInit(): void {
    this.initializeForm();
  
    if (this.pdfData) {
      this.patchFormData(this.pdfData.data);
      this.setupFormForUserType();
    }
  }
  
  private initializeForm(): void {
    this.cadastroForm = this.fb.group({
      dataHora: [{ value: '', disabled: false }],
      numero: ['',],
      numeroPrisma: ['',],
      contato: ['',],
      telefone: ['',],
      colp: ['',],
      equipamento: ['',],
      endereco: ['',],
      numSerie: ['',],
      horaInicio: ['',],
      horaFim: ['',],
      atividade: ['',],
      defeito: ['',],
      complementoAtividade: ['',],
      complementoDefeito: ['',],
      limpeza: [false],
      ajuste: [false],
      lubrificacao: [false],
      obs: ['',],
      nomeEngenheiro: ['',],
      nomeCliente: ['',],
      rgCliente: ['',],
      cargoCliente: ['',],
      rg_Crea: ['',],
      trabalhoConcluido: ['',],
      materiaisUtilizados: this.fb.array([])
    });
  }
  
  private patchFormData(data: any): void {
    this.cadastroForm.patchValue({
      dataHora: data.dataHora,
      numero: data.numero,
      numeroPrisma: data.numeroPrisma,
      contato: data.contato,
      telefone: data.telefone,
      colp: data.colp,
      equipamento: data.equipamento,
      endereco: data.endereco,
      numSerie: data.numSerie,
      horaInicio: data.horaInicio,
      horaFim: data.horaFim,
      atividade: data.atividade,
      defeito: data.defeito,
      complementoAtividade: data.complementoAtividade,
      complementoDefeito: data.complementoDefeito,
      limpeza: data.limpeza,
      ajuste: data.ajuste,
      lubrificacao: data.lubrificacao,
      obs: data.obs,
      nomeEngenheiro: data.nomeEngenheiro,
      nomeCliente: data.nomeCliente,
      rgCliente: data.rgCliente,
      cargoCliente: data.cargoCliente,
      rg_Crea: data.rg_Crea,
      trabalhoConcluido: data.trabalhoConcluido
    });
  
    const materiaisUtilizadosArray = this.cadastroForm.get('materiaisUtilizados') as FormArray;
    data.materiaisUtilizados?.forEach((material: any) => {
      materiaisUtilizadosArray.push(this.fb.group({
        descricao: [material.descricao, Validators.required],
        quantidade: [material.quantidade, Validators.required]
      }));
    });
  }
  
  private setupFormForUserType(): void {
    if (localStorage.getItem('tipoUser') !== 'ADMIN') {
      const controlsToDisable = [
        'numero', 'dataHora', 'numeroPrisma', 'contato',
        'telefone', 'colp', 'equipamento', 'endereco', 'numSerie'
      ];
  
      controlsToDisable.forEach(control => {
        this.cadastroForm.get(control)?.disable();
      });
    }
  }
  

  get materiaisUtilizados(): FormArray {
    return this.cadastroForm.get('materiaisUtilizados') as FormArray;
  }

  addMaterial(): void {
    this.materiaisUtilizados.push(this.fb.group({
      descricao: ['', Validators.required],
      quantidade: [0, Validators.required]
    }));
  }

  removeMaterial(index: number): void {
    this.materiaisUtilizados.removeAt(index);
  }

  toggleComplementoAtividade(): void {
    const complementoAtividadeControl = this.cadastroForm.get('complementoAtividade');
    if (this.isComplementoAtividadeEnabled) {
      complementoAtividadeControl?.enable();
    } else {
      complementoAtividadeControl?.disable();
    }
  }

  toggleComplementoDefeito(): void {
    const complementoDefeitoControl = this.cadastroForm.get('complementoDefeito');
    if (this.isComplementoDefeitoEnabled) {
      complementoDefeitoControl?.enable();
    } else {
      complementoDefeitoControl?.disable();
    }
  }

  onSubmit(): void {
    if (this.cadastroForm.valid) {
      if (this.pdfData != null) {
        const updatedFormValue = { ...this.cadastroForm.getRawValue(), idOrdem: this.pdfData.data.idOrdem };
          this.serviceService.editarOrdemServico(updatedFormValue).subscribe(
          response => {
            console.log('Form submitted successfully', response);
            this.router.navigate(['/listagem-pdf']);
          },
          error => {
            console.log('Error occurred while submitting the form', error);
            Swal.fire('Erro!', 'Erro ao editar Ordem de serviço.', 'error');
          }
        );
      } else {
        this.serviceService.cadastrarOrdemServico(this.cadastroForm.value).subscribe(
          response => {
            console.log('Form submitted successfully', response);
            this.router.navigate(['/listagem-pdf']);
          },
          error => {
            console.log('Error occurred while submitting the form', error);
            Swal.fire('Erro!', 'Erro ao cadastrar Ordem de serviço.', 'error');
          }
        );
      }
    } else {
      Swal.fire('Erro!', 'Preencha todos os campos obrigatórios.', 'error');
    }
  }

  openModalAssinatura(idOrdem: string) {
    const initialState = { idOrdem };
    this.bsModalRef = this.modalService.show(UploadFormComponent, { initialState });
  }
  
  
  }

