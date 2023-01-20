import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoProductoPedidoComponent } from './nuevo-producto-pedido.component';

describe('NuevoProductoPedidoComponent', () => {
  let component: NuevoProductoPedidoComponent;
  let fixture: ComponentFixture<NuevoProductoPedidoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NuevoProductoPedidoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoProductoPedidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
