import { Component, OnInit } from '@angular/core';
import { Pedido } from '../interfaces/pedido';

@Component({
  selector: 'app-nuevo-pedidio',
  templateUrl: './nuevo-pedidio.component.html',
  styleUrls: ['./nuevo-pedidio.component.css']
})
export class NuevoPedidioComponent implements OnInit {


  pedido:Pedido = new Pedido();
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
