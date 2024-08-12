import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ListagemPdfComponent } from './listagem-pdf/listagem-pdf.component';
import { CadastrarPdfComponent } from './cadastrar-pdf/cadastrar-pdf.component';
import { CadastrarUsuarioComponent } from './cadastrar-usuario/cadastrar-usuario.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'listagem-pdf', component: ListagemPdfComponent },
  { path: 'cadastrar-pdf', component: CadastrarPdfComponent },
  { path: 'cadastrar-usuario', component: CadastrarUsuarioComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
