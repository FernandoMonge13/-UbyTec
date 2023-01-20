import { Component, OnInit } from '@angular/core';
import { ProductoPedido } from '../interfaces/pedido';

@Component({
  selector: 'app-nuevo-producto-pedido',
  templateUrl: './nuevo-producto-pedido.component.html',
  styleUrls: ['./nuevo-producto-pedido.component.css']
})
export class NuevoProductoPedidoComponent implements OnInit {

  productoPedido:ProductoPedido = new ProductoPedido();
  editMode:boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  onGuardar(){
    console.log("Guardar");
  }

  onAddTelefono(){
    console.log("Agregar telefono");
  }


  onTelefonos(){
    console.log("Telefonos");
  }

  onCancelar(){
    console.log("Cancelar");
  }

  onEliminar(){
    console.log("Eliminar");
  }

}
