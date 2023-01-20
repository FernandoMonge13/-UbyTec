import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadoInterface } from '../interfaces/empleado';
import { ConexionService } from './conexion.service';
import { Gestion } from '../interfaces/gestion';
import { TelefonoInterface } from '../interfaces/genericas';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService extends ConexionService<EmpleadoInterface> {
  listaG:Gestion[]=[]
  getResourceURL(): string {
    return "/Empleado"
  }
  getHomePage(): string {
    return 'gestion/empleado'
  }
  getNombre(): string {
    return "Empleado"
  }

  getAsInterface(): Gestion[]{
    this.listaG = []
    this.getList().subscribe((data) =>{
      for (let i =0; i<data.length;i++){
        this.listaG.push(
          {nombre: data[i].nombre,
            id: data[i].idEmpleado,
            route:data[i].nombre}
          )
      }
    })
    return this.listaG;
  }
  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }
}

