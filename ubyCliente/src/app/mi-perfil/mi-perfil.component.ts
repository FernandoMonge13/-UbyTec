import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Cliente } from '../interfaces/cliente';
import { Telefono, TelefonoInterface } from '../interfaces/genericas';
import { ClientesService } from '../services/clientes.service';
import { TelefonosService, DireccionesService } from '../services/telefonos.service';

@Component({
  selector: 'app-mi-perfil',
  templateUrl: './mi-perfil.component.html',
  styleUrls: ['./mi-perfil.component.css']
})
export class MiPerfilComponent implements OnInit {

  objeto:Cliente = new Cliente();
  listaTelefonos:Telefono[]=[]
  telefonoNuevo:Telefono = new Telefono();

  provincias:string[] = [];
  cantones:string[] = [];
  distritos:string[] = [];


  constructor(private clientesservice:ClientesService, private telefonosService:TelefonosService, private direccionesService:DireccionesService, private route:Router, private rou:ActivatedRoute) {
  }

  ngOnInit(): void {
    this.telefonosService.url = "ClienteTelefonos";
    this.telefonosService.nombre = "Telefono de Cliente";
    this.telefonosService.homePage = this.rou.snapshot.params['id']+"mi-perfil";
    this.clientesservice.get(this.rou.snapshot.params['id']).subscribe({
        /*Mensaje emergente de exito*/
        next: (data) => {
          this.objeto = data[0];
          this.getProvincia();
          this.getCanton();
          this.getDistrito();
        },
        /*Mensaje emergente de error*/
        error: (err) =>{
          this.clientesservice.avisoError(err.error)}
      });
  }
  /**
   * Guarda los cambios realizados en el perfil del cliente
   * @param recargar
   */
  onGuardar(recargar?:boolean){
    this.clientesservice.onActualizar(this.objeto,this.objeto.nombre, recargar)
  }
  /**
   * Funcion que llama a telefonos
   */
  onTelefonos(){
    this.onGuardar(false)
    this.telefonosService.get(this.objeto.idCliente).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        this.listaTelefonos = data;
      },
      /*Mensaje emergente de error*/
      error: (err) =>{
        this.clientesservice.avisoError(err.error)}
    })
  }
  /**
   * Funcion que agrega un telefono a la lista de telefonos
   */
  onAddTelefono(){
    this.telefonoNuevo.id = this.objeto.idCliente
    this.telefonosService.onNuevo(this.telefonoNuevo,this.telefonoNuevo.telefono)
  }
  /**
   * Funcion que elimina un telefono de la lista de telefonos
   * @param tel
   */
  onDeleteTelefono(tel:TelefonoInterface){
    this.telefonosService.onEliminar(tel.id, tel.telefono)
  }

  /**
   * Funcion que obtiene las provincias
   */
  getProvincia(){
    this.direccionesService.get("Provincia").subscribe({
      next: (data) => {
        this.provincias = data;
      }
    })
  }
  /**
   * Funcion que obtiene los cantones
   */
  getCanton(){
    this.direccionesService.get(this.objeto.provincia).subscribe({
      next: (data) => {
        this.cantones = data;
      }
  })
}
  /**
   * Funcion que obtiene los distritos
   */
  getDistrito(){
    this.direccionesService.get(this.objeto.provincia,this.objeto.canton).subscribe({
      next: (data) => {
        this.distritos = data;
      }
  })
}

selected(){
  this.getCanton();
}

selectedcant(){
  this.getDistrito();
}

}
