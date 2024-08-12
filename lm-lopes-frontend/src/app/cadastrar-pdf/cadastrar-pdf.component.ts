import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../shared/service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cadastrar-pdf',
  templateUrl: './cadastrar-pdf.component.html',
  styleUrl: './cadastrar-pdf.component.css'
})
export class CadastrarPdfComponent {
  cadastroForm!: FormGroup;

  constructor(private fb: FormBuilder, private serviceService: ServiceService, private router: Router) { }

  ngOnInit(): void {
    this.cadastroForm = this.fb.group({
      dataHora: ['', Validators.required],
      numero: ['', Validators.required],
      numeroPrisma: ['', Validators.required],
      contato: ['', Validators.required],
      telefone: ['', Validators.required],
      colp: ['', Validators.required],
      equipamento: ['', Validators.required],
      numSerie: ['', Validators.required],
      horaInicio: ['', Validators.required],
      horaFim: ['', Validators.required],
      atividade: ['', Validators.required],
      defeito: ['', Validators.required],
      complementoAtividade: ['', Validators.required],
      complementoDefeito: ['', Validators.required],
      limpeza: [false],
      ajuste: [false],
      lubrificacao: [false],
      obs: [''],
      nomeEngenheiro: ['', Validators.required],
      rg_Crea: ['', Validators.required],
    });
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
        }
      );
    } else {
      Swal.fire('Erro!', 'Erro ao cadastrar Ordem de serviço.', 'error');
    }
  }
}