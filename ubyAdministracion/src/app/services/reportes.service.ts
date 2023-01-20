import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { ReporteInterface } from '../interfaces/reporte';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class ReportesService extends ConexionService<ReporteInterface>{
  listaG:Gestion[]=[]
  getResourceURL(): string {
    return "/Reportes"
    //api repartidor
  }
  getHomePage(): string {
    return 'gestion/reportes'
  }
  getNombre(): string {
    return "Reporte"
  }

  getAsInterface(): Gestion[]{
    this.listaG=[];
    this.getList().subscribe((data) =>{
      for (let i =0; i<data.length;i++){
        this.listaG.push(
          {nombre: data[i].afiliado,
            id: data[i].afiliado,
            route:data[i].afiliado}
          )
      }
    })
    return this.listaG;
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }
}
