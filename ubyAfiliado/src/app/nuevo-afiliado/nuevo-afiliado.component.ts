import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Comercio} from '../interfaces/comercio'
import { Telefono, TelefonoInterface } from '../interfaces/genericas';
import { ComerciosService } from '../services/comercios.service';
import { DireccionesService, TelefonosService } from '../services/telefonos.service';

@Component({
  selector: 'app-nuevo-afiliado',
  templateUrl: './nuevo-afiliado.component.html',
  styleUrls: ['./nuevo-afiliado.component.css']
})
export class NuevoAfiliadoComponent implements OnInit {

  objeto:Comercio = new Comercio();
  listaTelefonos:Telefono[]=[]
  telefonoNuevo:Telefono = new Telefono();

  provincias:string[] = [];
  cantones:string[] = [];
  distritos:string[] = [];


  constructor(private service:ComerciosService, private telefonosService:TelefonosService, private direccionesService:DireccionesService, private route:Router, private rou:ActivatedRoute) {
  }

  ngOnInit(): void {
    this.telefonosService.url = "ComercioTelefonos";
    this.telefonosService.nombre = "Telefono de Comercio";
    this.telefonosService.homePage = this.rou.snapshot.params['id']+ "/gestion/perfil";
    this.service.get(this.rou.snapshot.params['id']).subscribe({
        /*Mensaje emergente de exito*/
        next: (data) => {
          this.objeto = data[0];
          this.getProvincia();
          this.getCanton();
          this.getDistrito();
        },
        /*Mensaje emergente de error*/
        error: (err) =>{
          this.service.avisoError(err.error)}
      });
  }
  /**
   * Guarda los cambios realizados en el objeto
   * @param recargar
   */
  onGuardar(recargar?:boolean){
    this.service.onActualizar(this.objeto,this.objeto.nombre, recargar)
  }
  /**
   * Funcion que llama a telefonosService para obtener los telefonos del comercio
   */
  onTelefonos(){
    this.onGuardar(false)
    this.telefonosService.get(this.objeto.idComercio).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        this.listaTelefonos = data;
      },
      /*Mensaje emergente de error*/
      error: (err) =>{
        this.service.avisoError(err.error)}
    })
  }
  /**
   * Funcion que redirige a la pagina de gestion de comercios
   */
  onAdministrador(){
    this.onGuardar(false)
    this.route.navigate([this.objeto.idComercio+'/nuevo-admin'])
  }
  /**
   * Funcion que llama a telefonosService para agregar un nuevo telefono al comercio
   */
  onAddTelefono(){
    this.telefonoNuevo.id = this.objeto.idComercio
    this.telefonosService.onNuevo(this.telefonoNuevo,this.telefonoNuevo.telefono)
  }
  /**
   * Funcion que eliminar un telefono del comercio
   * @param tel
   */
  onDeleteTelefono(tel:TelefonoInterface){
    this.telefonosService.onEliminar(tel.id, tel.telefono)
  }

  /**
   * Funcion que obtiene las provincia de comercios
   */
  getProvincia(){
    this.direccionesService.get("Provincia").subscribe({
      next: (data) => {
        this.provincias = data;
      }
    })
  }
  /**
   * Funcion que obtiene los cantones de comercios
   */
  getCanton(){
    this.direccionesService.get(this.objeto.provincia).subscribe({
      next: (data) => {
        this.cantones = data;
      }
  })
}
  /**
   * Funcion que obtiene los distritos de comercios
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
