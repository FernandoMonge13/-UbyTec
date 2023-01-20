import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gestion } from '../interfaces/gestion';
import { ComerciosService } from '../services/comercios.service';
import { EmpleadosService } from '../services/empleados.service';
import { RepartidoresService } from '../services/repartidores.service';

@Component({
  selector: 'app-gestiones',
  templateUrl: './gestiones.component.html',
  styleUrls: ['./gestiones.component.css']
})

/** Clase Gestion Componente
 * Visualiza los objetos dependiendo del tipo proporcionado en la ruta
 * se escoje entre: Empleado, Repartidores, Afiliado, Solicitudes
 *
 */
export class GestionesComponent implements OnInit {
  reporte:boolean=false;
  Tipo:string="";
  lista:Gestion[]=[]
  crear:boolean =true;
  constructor(private empleadoService:EmpleadosService, private repartidorService:RepartidoresService, private comercioService:ComerciosService,private route:Router, private rou:ActivatedRoute) {
    this.Tipo = this.rou.snapshot.params['Tipo']
    console.log(this.Tipo)
    this.reporte=false;
    if(this.rou.snapshot.params['Tipo'] == "empleado"){
      this.lista = empleadoService.getAsInterface()
    }
    else if(this.rou.snapshot.params['Tipo'] == "repartidores"){
      this.lista = repartidorService.getAsInterface()
    }
    else if(this.rou.snapshot.params['Tipo'] == "afiliados"){
      this.crear= false;
      this.lista = comercioService.getAsInterface()
    }
    else if(this.rou.snapshot.params['Tipo'] == "solicitudes"){
      this.lista = comercioService.getAsInterface(true)
    }
    else if(this.rou.snapshot.params['Tipo'] == "reportes"){
      this.crear= false;
    }
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
  /*Completa la lista de gestiones con los datos de la base de datos
  valor:number
  return: list
  */
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
