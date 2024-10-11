import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-upload-form',
  templateUrl: './UploadFormComponent.html'
})
export class UploadFormComponent {
  uploadForm: FormGroup;
  selectedFile: File | null = null;
  imageUrl: SafeUrl | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient,private sanitizer: DomSanitizer) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      image: [null, Validators.required]
    });
  }

  // Método para capturar o arquivo de imagem
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      this.uploadForm.patchValue({ image: file });
    }
  }

  // Método para submeter o formulário
  onSubmit() {
    if (this.uploadForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('IdOrdem', "3");
      formData.append('ImgForm', this.selectedFile);

      this.http.post('http://localhost:5150/api/OrdemServico/assinatura', formData,{ headers: this.getAuthHeaders() }).subscribe(
        (response) => console.log('Upload bem-sucedido!', response),
        (error) => console.error('Erro no upload', error)
      );
    }
  }

  loadImage() {
    this.http.get("http://localhost:5150/api/OrdemServico/assinatura/3",{  headers: this.getAuthHeaders(),responseType: 'blob' }).subscribe(
      (blob) => {
        const objectURL = URL.createObjectURL(blob);
        this.imageUrl = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      },
      (error) => console.error('Erro ao carregar imagem', error)
    );
  }

  getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }
}
