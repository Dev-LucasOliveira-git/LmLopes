import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../shared/service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { catchError, map, of } from 'rxjs';


@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrl: './cadastrar-usuario.component.css'
})
export class CadastrarUsuarioComponent implements OnInit {

  cadastroForm!: FormGroup;
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['nome', 'email', 'senha'];


  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private fb: FormBuilder, private serviceService: ServiceService, private router: Router) { }

  ngOnInit(): void {
    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
      tipoUsuario: ['', Validators.required]
    });
    this.carregar();
  }
  public carregar() {
    this.serviceService.listarUsuarios().pipe(
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

  onRowClicked(row: any) {
    console.log("Row clicked:", row);
  }
  onSubmit(): void {
    if (this.cadastroForm.valid) {
      this.serviceService.cadastrarUsuario(this.cadastroForm.value).subscribe(
        response => {
          console.log('Form submitted successfully', response);
          this.router.navigate(['/listagem-pdf']);
        },
        error => {
          console.log('Error occurred while submitting the form', error);
        }
      );
    } else {
      Swal.fire('Erro!', 'Erro ao cadastrar usuario.', 'error');
    }
  }

}
