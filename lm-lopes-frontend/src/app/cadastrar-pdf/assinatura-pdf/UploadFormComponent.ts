import { Component, ElementRef, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import SignaturePad from 'signature_pad';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

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

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private sanitizer: DomSanitizer,
    public bsModalRef: BsModalRef,
    public modalService: BsModalService
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
    signaturePad.clear(); // Clear previous signature (optional)
  }

  clearPad(step: 'ENG' | 'CLI') {
    if (step === 'ENG') {
      this.engineerSignaturePad.clear();
    } else if (step === 'CLI') {
      this.clientSignaturePad.clear();
    }
  }

  savePad() {
    // Salva a assinatura do engenheiro
    if (!this.engineerSignaturePad.isEmpty()) {
      const engineerBlob = this.getSignatureBlob(this.engineerSignaturePad);
      if (engineerBlob.size > 0) {
        this.uploadSignature(engineerBlob, 'http://localhost:5150/api/OrdemServico/assinatura/engenheiro');
      } else {
        console.warn('Falha ao criar o blob para a assinatura do engenheiro.');
      }
    } else {
      console.warn('A assinatura do engenheiro é necessária antes de salvar.');
    }
  
    // Salva a assinatura do cliente
    if (!this.clientSignaturePad.isEmpty()) {
      const clientBlob = this.getSignatureBlob(this.clientSignaturePad);
      if (clientBlob.size > 0) { 
        this.uploadSignature(clientBlob, 'http://localhost:5150/api/OrdemServico/assinatura/cliente');
      } else {
        console.warn('Falha ao criar o blob para a assinatura do cliente.');
      }
    } else {
      console.warn('A assinatura do cliente é necessária antes de salvar.');
    }
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
  
  
  private uploadSignature(blob: Blob, url: string) {
    const formData = new FormData();
    formData.append('IdOrdem', this.idOrdem);
    formData.append('ImgForm', blob, 'signature.png');
  
    this.http.post(url, formData, { headers: this.getAuthHeaders() }).subscribe(
      (response) => console.log('Upload bem-sucedido!', response),
      (error) => console.error('Erro no upload', error)
    );
  }
  
  


  onSubmit() {
    if (this.uploadForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('IdOrdem', this.idOrdem);
      formData.append('ImgForm', this.selectedFile);

      this.http.post('http://localhost:5150/api/OrdemServico/assinatura', formData, { headers: this.getAuthHeaders() }).subscribe(
        (response) => console.log('Upload bem-sucedido!', response),
        (error) => console.error('Erro no upload', error)
      );
    }
  }

  loadImage() {
    this.http.get("http://localhost:5150/api/OrdemServico/assinatura/3", { headers: this.getAuthHeaders(), responseType: 'blob' }).subscribe(
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
