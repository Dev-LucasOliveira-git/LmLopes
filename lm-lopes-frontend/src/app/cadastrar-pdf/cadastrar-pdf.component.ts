import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ServiceService } from '../shared/service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

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

  constructor(
    private fb: FormBuilder, 
    private serviceService: ServiceService, 
    private router: Router
  ) {
    const navigation = this.router.getCurrentNavigation();
    this.pdfData = navigation?.extras?.state?.['pdfData'] || null;
  }

  ngOnInit(): void {
    this.cadastroForm = this.fb.group({
      dataHora: [{ value: '', disabled: false }],
      numero: ['',],
      numeroPrisma: ['',],
      contato: [{ value: '', disabled: false }],
      telefone: ['',],
      colp: ['',],
      equipamento: ['',],
      endereco: ['',],
      numSerie: ['',],
      horaInicio: [{ value: '', disabled: false }],
      horaFim: [{ value: '', disabled: false }],
      atividade: [{ value: '', disabled: false }],
      defeito: [{ value: '', disabled: false }],
      complementoAtividade: [{ value: '', disabled: false }],
      complementoDefeito: [{ value: '', disabled: false }],
      limpeza: [{ value: false, disabled: false }],
      ajuste: [{ value: false, disabled: false }],
      lubrificacao: [{ value: false, disabled: false }],
      obs: [{ value: '', disabled: false }],
      nomeEngenheiro: ['',],
      nomeCliente: [{ value: '', disabled: false }],
      rgCliente: [{ value: '', disabled: false }],
      cargoCliente: [{ value: '', disabled: false }],
      rg_Crea: ['',],
      trabalhoConcluido: ['',],
      materiaisUtilizados: this.fb.array([])
    });

    if (this.pdfData) {
      const data = this.pdfData.data;
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
      data.materiaisUtilizados.forEach((material: any) => {
        materiaisUtilizadosArray.push(this.fb.group({
          descricao: [{ value: material.descricao, disabled: true }, Validators.required],
          quantidade: [{ value: material.quantidade, disabled: true }, Validators.required]
        }));
      });

      this.cadastroForm.get('dataHora')?.disable();
      this.cadastroForm.get('horaInicio')?.disable();
      this.cadastroForm.get('horaFim')?.disable();
      this.cadastroForm.get('atividade')?.disable();
      this.cadastroForm.get('defeito')?.disable();
      this.cadastroForm.get('complementoAtividade')?.disable();
      this.cadastroForm.get('complementoDefeito')?.disable();
      this.cadastroForm.get('limpeza')?.disable();
      this.cadastroForm.get('ajuste')?.disable();
      this.cadastroForm.get('lubrificacao')?.disable();
      this.cadastroForm.get('obs')?.disable();
      this.cadastroForm.get('nomeCliente')?.disable();
      this.cadastroForm.get('rgCliente')?.disable();
      this.cadastroForm.get('cargoCliente')?.disable();
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
        const updatedFormValue = { ...this.cadastroForm.value, idOrdem: this.pdfData.data.idOrdem };
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
  
  }

