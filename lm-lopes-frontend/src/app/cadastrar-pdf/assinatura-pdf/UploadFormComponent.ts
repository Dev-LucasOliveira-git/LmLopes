import { Component, ElementRef, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import SignaturePad from 'signature_pad';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { environment } from '../../../environments/enviroment';

@Component({
  selector: 'app-upload-form',
  templateUrl: './UploadFormComponent.html',
  styleUrls: ['./UploadFormComponent.css']
})
export class UploadFormComponent implements OnInit, AfterViewInit {
  uploadForm: FormGroup;
  selectedFile: File | null = null;
  imageUrl: SafeUrl | null = null;
  signatureNeeded!: boolean;
  engineerSignaturePad!: SignaturePad;
  clientSignaturePad!: SignaturePad;
  idOrdem!: string;


  @ViewChild('engineerCanvas') engineerCanvasEl!: ElementRef;
@ViewChild('clientCanvas', { static: false }) clientCanvasEl!: ElementRef;
  
  signatureImg!: string;
  step: 'ENG' | 'CLI' = 'ENG';

  host = `${environment.API_GATEWAY}`

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private sanitizer: DomSanitizer,
    public bsModalRef: BsModalRef,
    public modalService: BsModalService,
    private router: Router,
  ) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      image: [null, Validators.required]
    });
  }

  ngOnInit() {
    if (this.bsModalRef.content) {
      this.idOrdem = this.bsModalRef.content.idOrdem;
    }
    console.log("aqui", this.idOrdem)
  }

  ngAfterViewInit() {
    this.engineerSignaturePad = new SignaturePad(this.engineerCanvasEl.nativeElement);
    this.clientSignaturePad = new SignaturePad(this.clientCanvasEl.nativeElement);
  }

  resizeSignaturePad(signaturePad: SignaturePad, canvasElement: ElementRef) {
    const canvas = canvasElement.nativeElement;
    canvas.width = canvas.offsetWidth;
    canvas.height = canvas.offsetHeight;
    signaturePad.clear();
  }

  clearPad(step: 'ENG' | 'CLI') {
    if (step === 'ENG') {
      this.engineerSignaturePad.clear();
    } else if (step === 'CLI') {
      this.clientSignaturePad.clear();
    }
  }
  errorMessages: string[] = [];

  savePad() {
    this.errorMessages = [];
    let engineerBlob: Blob | null = null;
    let clientBlob: Blob | null = null;
  
    if (!this.engineerSignaturePad.isEmpty()) {
      engineerBlob = this.getSignatureBlob(this.engineerSignaturePad);
      if (engineerBlob.size === 0) {
        this.errorMessages.push('Falha ao criar o blob para a assinatura do engenheiro.');
        engineerBlob = null;
      }
    } else {
      this.errorMessages.push('A assinatura do engenheiro é necessária antes de salvar.');
    }
  
    if (!this.clientSignaturePad.isEmpty()) {
      clientBlob = this.getSignatureBlob(this.clientSignaturePad);
      if (clientBlob.size === 0) {
        this.errorMessages.push('Falha ao criar o blob para a assinatura do cliente.');
        clientBlob = null;
      }
    } else {
      this.errorMessages.push('A assinatura do cliente é necessária antes de salvar.');
    }
  
    if (engineerBlob && clientBlob) {
      this.uploadCombinedSignatures(engineerBlob, clientBlob);
      Swal.fire('Sucesso!', 'Assinatura Cadastrada com sucesso.', 'success');
      this.router.navigate(['/cadastrar-pdf']);
      this.modalService.hide();
    } else {
      console.warn('Assinatura(s) faltando. Certifique-se de que ambas as assinaturas estão presentes antes de salvar.');
    }
  }
  
  
  private uploadCombinedSignatures(engineerBlob: Blob, clientBlob: Blob) {
    const formData = new FormData();
    formData.append('IdOrdem', this.idOrdem);
    formData.append('ImgAssinaturaCliente', engineerBlob, 'signature_engenheiro.png');
    formData.append('ImgAssinaturaEngenheiro', clientBlob, 'signature_cliente.png');
  
    this.http.post(`${this.host}/OrdemServico/assinaturas`, formData, { headers: this.getAuthHeaders() }).subscribe(
      (response) => console.log('Upload bem-sucedido!', response),
      (error) => console.error('Erro no upload', error)
    );
  }
  
  private getSignatureBlob(signaturePad: SignaturePad): Blob {
    const dataUrl = signaturePad.toDataURL();
    
    if (!dataUrl.startsWith('data:image/png;base64,')) {
      console.error('Formato de URL de dados inválido para a assinatura.');
      return new Blob();
    }
  
    const base64Data = dataUrl.split(',')[1];
    const byteCharacters = atob(base64Data);
    const byteNumbers = Array.from(byteCharacters, char => char.charCodeAt(0));
    const byteArray = new Uint8Array(byteNumbers);
    return new Blob([byteArray], { type: 'image/png' });
  }
  
  
  selectedFileCliente: File | null = null;
  selectedFileEngenheiro: File | null = null;
  
  onFileSelectedCliente(event: any) {
    this.selectedFileCliente = event.target.files[0];
  }
  
  onFileSelectedEngenheiro(event: any) {
    this.selectedFileEngenheiro = event.target.files[0];
  }
  
  onSubmit() {
    if (this.uploadForm.valid && this.selectedFileCliente && this.selectedFileEngenheiro) {
      const formData = new FormData();
      formData.append('IdOrdem', this.idOrdem);
      formData.append('ImgAssinaturaCliente', this.selectedFileCliente);
      formData.append('ImgAssinaturaEngenheiro', this.selectedFileEngenheiro);
  
      this.http.post(`${this.host}/OrdemServico/assinatura`, formData, { headers: this.getAuthHeaders() }).subscribe(
        (response) => {
          console.log('Upload bem-sucedido!', response);
        },
        (error) => console.error('Erro no upload', error)
      );
    } else {
      console.warn('Formulário inválido ou arquivos não selecionados.');
    }
  }

  getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }
}
