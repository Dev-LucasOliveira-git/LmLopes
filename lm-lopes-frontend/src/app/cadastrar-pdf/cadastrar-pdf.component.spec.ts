import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarPdfComponent } from './cadastrar-pdf.component';

describe('CadastrarPdfComponent', () => {
  let component: CadastrarPdfComponent;
  let fixture: ComponentFixture<CadastrarPdfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadastrarPdfComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CadastrarPdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
