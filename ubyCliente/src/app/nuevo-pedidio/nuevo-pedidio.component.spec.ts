import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoPedidioComponent } from './nuevo-pedidio.component';

describe('NuevoPedidioComponent', () => {
  let component: NuevoPedidioComponent;
  let fixture: ComponentFixture<NuevoPedidioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NuevoPedidioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoPedidioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
