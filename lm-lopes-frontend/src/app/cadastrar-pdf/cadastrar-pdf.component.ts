import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
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

  constructor(
    private fb: FormBuilder, 
    private serviceService: ServiceService, 
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cadastroForm = this.fb.group({
      dataHora: ['',],
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
      complementoAtividade: [''],
      complementoDefeito: [''],
      limpeza: [false],
      ajuste: [false],
      lubrificacao: [false],
      obs: [''],
      nomeEngenheiro: ['',],
      nomeCliente: [''],
      rgCliente: [''],
      cargoCliente:[''],
      rg_Crea: ['',],
      trabalhoConcluido: ['',],
      materiaisUtilizados: this.fb.array([])
    });
  
    this.cadastroForm.get('atividade')?.valueChanges.subscribe(value => {
      this.isComplementoAtividadeEnabled = value === 'Outros'; 
      this.toggleComplementoAtividade();
    });
  
    this.cadastroForm.get('defeito')?.valueChanges.subscribe(value => {
      this.isComplementoDefeitoEnabled = value === 'Outros'; 
      this.toggleComplementoDefeito();
    });
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
    } else {
      Swal.fire('Erro!', 'Erro ao cadastrar Ordem de serviço.', 'error');
    }
  }
}
