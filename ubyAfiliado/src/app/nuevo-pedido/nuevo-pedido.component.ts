import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pedido } from '../interfaces/pedido';
import { ProductoPedido } from '../interfaces/producto';
import { PedidosService } from '../services/pedidos.service';
import { ProductosPedidoService, ProductosService } from '../services/productos.service';

@Component({
  selector: 'app-nuevo-pedido',
  templateUrl: './nuevo-pedido.component.html',
  styleUrls: ['./nuevo-pedido.component.css']
})
export class NuevoPedidoComponent implements OnInit {

  objeto:Pedido = new Pedido()
  listaProductos:ProductoPedido[] = []
  total:number = 0;
  totalServicio:number = 0;


  constructor(private service:PedidosService, private rou:ActivatedRoute, private route:Router, private productosService:ProductosService, private productosPedidosService:ProductosPedidoService) {
    let servicio = 0;
    let tot = 0;
    this.service.get(this.rou.snapshot.params['pedido']).subscribe({
      next: (data) => {
        this. objeto = data[0]
        this.productosPedidosService.get(this.objeto.idPedido).subscribe({
          next: (productos) =>{
            this.listaProductos = productos
            for(let i = 0; i<this.listaProductos.length; i++){
              this.productosService.get(this.listaProductos[i].producto).subscribe({
                next: (info) => {
                  this.listaProductos[i].precio = info[0].precio
                  tot = info[0].precio * this.listaProductos[i].cantidad
                  servicio = (tot * 0.05);
                  this.total = this.total + tot+ servicio
                  this.totalServicio = this.totalServicio + servicio
                }
              })
            }
          }
        })
      }
    })
  }

  ngOnInit(): void {
  }
  /**
   * Funcion que actualiza el objeto
   */
  onEnviar(){
    console.log(this.objeto)
    this.service.update(this.objeto).subscribe({
      next: (data) => {
        this.service.aviso("¡Has enviado el pedido de exitosamente!")
        this.onCancelar()
        console.log(this.objeto)
      }
    })
  }
  /**
   * Funcion que cancela la edicion de objeto
   */
  onCancelar(){
    this.service.onCancelar()
  }

}
