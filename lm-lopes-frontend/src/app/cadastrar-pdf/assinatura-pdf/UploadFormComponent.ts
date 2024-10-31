import { Component, ElementRef, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import SignaturePad from 'signature_pad';
import { BsModalService } from 'ngx-bootstrap/modal';

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

  @ViewChild('engineerCanvas') engineerCanvasEl!: ElementRef;
@ViewChild('clientCanvas', { static: false }) clientCanvasEl!: ElementRef;
  
  signatureImg!: string;
  step: 'ENG' | 'CLI' = 'ENG';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private sanitizer: DomSanitizer,
    public modalService: BsModalService
  ) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      image: [null, Validators.required]
    });
  }

  ngOnInit() {
    this.loadImage(); // Load existing image on component initialization
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
    const signaturePad = this.step === 'ENG' ? this.engineerSignaturePad : this.clientSignaturePad;
    if (signaturePad.isEmpty()) {
      this.signatureNeeded = true;
      console.warn('A assinatura é necessária antes de salvar.');
      return;
    }
    
    this.signatureNeeded = false;
    const blob = this.getSignatureBlob(signaturePad);
    this.uploadSignature(blob);

    this.step = this.step === 'ENG' ? 'CLI' : 'ENG';
  }

  private getSignatureBlob(signaturePad: SignaturePad): Blob {
    const base64Data = signaturePad.toDataURL().split(',')[1];
    const byteCharacters = atob(base64Data);
    const byteNumbers = Array.from(byteCharacters, char => char.charCodeAt(0));
    const byteArray = new Uint8Array(byteNumbers);
    return new Blob([byteArray], { type: 'image/png' });
  }

  private uploadSignature(blob: Blob) {
    const formData = new FormData();
    formData.append('IdOrdem', '3');
    formData.append('ImgForm', blob, 'signature.png');
    
    this.http.post('http://localhost:5150/api/OrdemServico/assinatura', formData, { headers: this.getAuthHeaders() }).subscribe(
      (response) => console.log('Upload bem-sucedido!', response),
      (error) => console.error('Erro no upload', error)
    );
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      const validImageTypes = ['image/jpeg', 'image/png', 'image/gif'];
      if (!validImageTypes.includes(file.type)) {
        console.error('Arquivo inválido. Selecione uma imagem (JPEG, PNG, GIF).');
        return;
      }
      this.selectedFile = file;
      this.uploadForm.patchValue({ image: file });
    }
  }

  onSubmit() {
    if (this.uploadForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('IdOrdem', "3");
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
