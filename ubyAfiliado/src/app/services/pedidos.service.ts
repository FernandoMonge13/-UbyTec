import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { PedidoInterface } from '../interfaces/pedido';
import { ClientesService } from './clientes.service';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class PedidosService extends ConexionService<PedidoInterface> {
    listaG:Gestion[]=[]
    id!:number
    getResourceURL(): string {
      return "/Pedido"
    }
    getHomePage(): string {
      return this.id + '/gestion/pedidos'
    }
    getNombre(): string {
      return "Pedido"
    }

    getAsInterface(): Gestion[]{
      this.listaG = []
      console.log(this.id)
      this.get("Comercio",this.id).subscribe((data) =>{
        for (let i =0; i<data.length;i++){
          this.service.get(data[i].idCliente).subscribe({
            next: (info) => {
              this.listaG.push(
                {nombre: info[0].nombre,
                  id: data[i].idPedido,
                  route:data[i].repartidor}
                )
            }
          })
          
        }
      })
      return this.listaG;
    }
    constructor(protected override httpClient: HttpClient, protected override route:Router, private service:ClientesService) {
      super(httpClient, route);
    }
}
