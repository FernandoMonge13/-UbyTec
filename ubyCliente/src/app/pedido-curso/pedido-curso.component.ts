import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pedido } from '../interfaces/pedido';
import { PedidosRecientesService, PedidosService } from '../services/pedidos.service';
import { RepartidoresService } from '../services/repartidores.service';

@Component({
  selector: 'app-pedido-curso',
  templateUrl: './pedido-curso.component.html',
  styleUrls: ['./pedido-curso.component.css']
})
export class PedidoCursoComponent implements OnInit {
  objeto:Pedido = new Pedido();
  repartidor = "";
  enCurso:boolean = false; 
  constructor(private service:PedidosService, private repartidorservice:RepartidoresService,private pedidosRecientesService:PedidosRecientesService, private rou:ActivatedRoute) {
    this.service.get("Cliente", this.rou.snapshot.params['id']).subscribe({
      next: (data) => {
        console.log(data)
        if (data.length !=0){
          this.enCurso = true;
        this.objeto = data[0]
        console.log(this.objeto)
        this.repartidorservice.get(this.objeto.repartidor).subscribe({
          next: (data) => {
            this.repartidor = data[0].nombre + " " + data[0].apellidos + " (" + data[0].usuario + ")" 
          }
        })
        }
        else {
          this.enCurso = false;
        }
      }
    })
   }

  ngOnInit(): void {
  }

  onFinalizarPedido(){
    const input = document.getElementById('message') as HTMLInputElement | null;
    console.log(this.objeto)
    this.service.update(this.objeto).subscribe({
      next: (data) =>{
        console.log(this.objeto)
        this.pedidosRecientesService.add(
          {comercio:"", total:0, idPedido:this.objeto.idPedido, feedback:input?.value }).subscribe({
            next: (data) => {
              console.log(data)
            }
          })
        window.location.reload()
      }
    })
  }

}
