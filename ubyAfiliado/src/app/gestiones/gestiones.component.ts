import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { PedidosService } from '../services/pedidos.service';
@Component({
  selector: 'app-gestiones',
  templateUrl: './gestiones.component.html',
  styleUrls: ['./gestiones.component.css']
})

export class GestionesComponent implements OnInit {
  tipo:string="";
  lista:Gestion[]=[]
  id:number = 0;
  constructor(private pedidoService:PedidosService, private route:Router, private rou:ActivatedRoute) {
    this.id = this.rou.snapshot.params['id']
    this.pedidoService.id = this.id
    this.lista = pedidoService.getAsInterface()
   }

    /*Crea filas de 5 unidades a partir de índice
  valor:number
  return: boolean*/
  crearFila(valor:number){
    if (valor%5==0){
      return true;
    }
    return false;
  }
  /*Rellena la lista con elementos nulos para conservar el espaciado
  valor:number
  return: list*/
  subLista(valor:number){
    var sub=[];
    if(valor+5 > this.lista.length){
      sub = this.lista.slice(valor)
    } else {
      sub = this.lista.slice(valor, valor+5);
    }
    return sub;
  }

  completar(valor:number){
    var sub=[1,2,3,4,5];
    if(valor+5 > this.lista.length){
       return sub.slice(0,valor+5-this.lista.length)
    } else {
      return []
    }
  }
  ngOnInit(): void {
  }

}
