import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { RepartidorInterface } from '../interfaces/repartidor';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class RepartidoresService extends ConexionService<RepartidorInterface>{
  listaG:Gestion[]=[]
  getResourceURL(): string {
    return "/Repartidor"
    //api repartidor
  }
  getHomePage(): string {
    return 'gestion/repartidores'
  }
  getNombre(): string {
    return "Repartidor"
  }

  getAsInterface(): Gestion[]{
    this.listaG=[];
    this.getList().subscribe((data) =>{
      for (let i =0; i<data.length;i++){
        this.listaG.push(
          {nombre: data[i].nombre,
            id: data[i].usuario,
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
