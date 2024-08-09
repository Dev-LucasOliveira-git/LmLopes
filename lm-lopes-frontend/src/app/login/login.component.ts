import {Component, ElementRef, HostListener, ViewChild} from '@angular/core';
import { LoginService } from '../shared/login.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  senha: string = '';
  show:boolean = false;
  @ViewChild('userInput') userInput!: ElementRef;
  @ViewChild('submitButton') submitButton!: ElementRef;

  constructor(private loginService: LoginService, private router: Router) { }

  ngAfterViewInit() {
    setTimeout(() => {
      this.userInput.nativeElement.focus();
  });  }

  @HostListener('document:keydown.enter', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      event.preventDefault(); 
      this.login(); 
    }
  }

  login() {
    console.log("chamei aquis")
    if (!this.email || !this.senha) {
      Swal.fire('Erro!', 'Por favor, preencha o email e a senha.', 'error');
      return;
    }
    this.loginService.login(this.email, this.senha).subscribe(response => {
      if (response && response.data.token) {
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('user', response.data.usuario.nome);
        if (response.data.usuario.tipoUsuario === 'ADMIN') {
          this.router.navigate(['/listagem-pdf']);
        } else if (response.data.usuario.tipoUsuario === 'FUNC') {
          this.router.navigate(['/listagem-pdf']);
        }
      } 
    }, error => {
      console.error(error);
      Swal.fire('Erro!', 'Usuário não encontrado.', 'error');
    });
  }
}