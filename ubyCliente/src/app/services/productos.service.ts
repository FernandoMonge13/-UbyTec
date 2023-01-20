import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { ProductoFotos, ProductoFotosInterface, ProductoInterface, ProductoPedidoInterface } from '../interfaces/producto';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class ProductosService extends ConexionService<ProductoInterface>{
  listaG:Gestion[]=[]
  id!:number
  getResourceURL(): string {
    return "/Producto"
    //api producto
  }
  getHomePage(): string {
    return this.id+'/gestion/productos'
  }
  getNombre(): string {
    return "Producto"
  }

  getAsInterface(): Gestion[]{
    this.listaG=[];
    this.getList().subscribe((data) =>{
      for (let i =0; i<data.length;i++){
        this.listaG.push(
          {nombre: data[i].nombre,
            id: data[i].nombre,
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


@Injectable({
  providedIn: 'root'
})
export class ProductosFotosService extends ConexionService<ProductoFotosInterface>{
  id!:number
  url!:string
  getResourceURL(): string {
    return "/ProductoFotos"
  }
  getHomePage(): string {
    return this.url
  }
  getNombre(): string {
    return "Foto"
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }

}

@Injectable({
  providedIn: 'root'
})
export class ProductosPedidoService extends ConexionService<ProductoPedidoInterface>{
  id!:number
  url!:string
  getResourceURL(): string {
    return "/ProductosPedido"
  }
  getHomePage(): string {
    return this.url
  }
  getNombre(): string {
    return "Prodcuto de Pedido"
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }

}
