import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoAfiliadoAdminComponent } from './nuevo-afiliado-admin.component';

describe('NuevoAfiliadoAdminComponent', () => {
  let component: NuevoAfiliadoAdminComponent;
  let fixture: ComponentFixture<NuevoAfiliadoAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NuevoAfiliadoAdminComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoAfiliadoAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
