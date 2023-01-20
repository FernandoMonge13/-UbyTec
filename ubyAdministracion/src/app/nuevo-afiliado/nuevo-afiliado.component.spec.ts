import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoAfiliadoComponent } from './nuevo-afiliado.component';

describe('NuevoAfiliadoComponent', () => {
  let component: NuevoAfiliadoComponent;
  let fixture: ComponentFixture<NuevoAfiliadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NuevoAfiliadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoAfiliadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
