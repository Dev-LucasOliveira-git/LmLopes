import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemPdfComponent } from './listagem-pdf.component';

describe('ListagemPdfComponent', () => {
  let component: ListagemPdfComponent;
  let fixture: ComponentFixture<ListagemPdfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListagemPdfComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListagemPdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
