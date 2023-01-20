import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoCursoComponent } from './pedido-curso.component';

describe('PedidoCursoComponent', () => {
  let component: PedidoCursoComponent;
  let fixture: ComponentFixture<PedidoCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PedidoCursoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PedidoCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
