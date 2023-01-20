import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {Empleado} from '../interfaces/empleado';
import { Telefono, TelefonoInterface } from '../interfaces/genericas';
import {Repartidor} from '../interfaces/repartidor';
import { RepartidoresService } from '../services/repartidores.service';
import { DireccionesService, TelefonosService } from '../services/telefonos.service';

@Component({
  selector: 'app-nuevo-repartidor',
  templateUrl: './nuevo-repartidor.component.html',
  styleUrls: ['./nuevo-repartidor.component.css']
})
export class NuevoRepartidorComponent implements OnInit {

  objeto: Repartidor = new Repartidor();
  editMode:boolean = true;

  telefonoNuevo:Telefono = new Telefono();
  listaTelefonos:Telefono[] = [];

  provincias:string[] = [];
  cantones:string[] = [];
  distritos:string[] = [];
  provincia: any;
  canton: any;

  constructor(private service:RepartidoresService, private telefonosService:TelefonosService ,private direccionesService:DireccionesService, private route:Router, private rou:ActivatedRoute) {
    this.telefonosService.url = "RepartidorTelefonos";
    this.telefonosService.nombre = "Telefono de Repartidor";
  }

  ngOnInit(): void {
    this.telefonosService.url = "RepartidorTelefonos";
    this.telefonosService.nombre = "Telefono de Repartidor";
    if(this.rou.snapshot.params['id']==undefined){
      this.getProvincia();
      this.editMode = false;
      this.telefonosService.homePage = "nuevo/repartidores";
    } else {
      this.telefonosService.homePage = "actualizar/repartidores/"+this.rou.snapshot.params['id'];
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
  }
  /**
   * Metodo que se encarga de guardar un nuevo repartidor
   */
  onGuardar(){
    if (this.editMode){
      this.service.onActualizar(this.objeto,this.objeto.nombre)
    } else {
      this.service.onNuevo(this.objeto,this.objeto.nombre)
    }
  }
  /**
   * Metodo que se encarga de regresar a la pagina anterior
   */
  onCancelar(){
    this.service.onCancelar()
  }
  /**
   * Funcion que elimua un repartidor
   */
  onEliminar(){
    this.service.onEliminar(this.objeto.usuario)
  }


  /**
   * Metodo que se encarga de obtener los telefonos de un repartidor
   */
  onTelefonos(){
    this.telefonosService.get(this.objeto.usuario).subscribe({
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
   * Metodo que se encarga de agregar un nuevo telefono
   */
  onAddTelefono(){
    this.telefonoNuevo.id = this.objeto.usuario
    this.telefonosService.onNuevo(this.telefonoNuevo,this.telefonoNuevo.telefono)
  }
  /**
   * Metodo que se encarga de eliminar un telefono
   * @param tel
   */
  onDeleteTelefono(tel:TelefonoInterface){
    this.telefonosService.onEliminar(tel.id, tel.telefono)

  }
  /**
   * Metodo que se encarga de obtener las provincias
   */
  getProvincia(){
    this.direccionesService.get("Provincia").subscribe({
      next: (data) => {
        this.provincias = data;
      }
    })
  }
  /**
   * Metodo que se encarga de obtener los cantones
   */
  getCanton(){
    this.direccionesService.get(this.objeto.provincia).subscribe({
      next: (data) => {
        this.cantones = data;
      }
  })
}
  /**
   * Metodo que se encarga de obtener los distritos
   */
  getDistrito(){
    this.direccionesService.get(this.objeto.provincia,this.objeto.canton).subscribe({
      next: (data) => {
        this.distritos = data;
      }
  })
}
  /**
   * Metodo que se encarga de obtener los datos de canton un repartidor
   */
selected(){
  this.getCanton();
}
  /*
   * Metodo que se encarga de obtener los datos de distrito de un repartidor
   */
selectedcant(){
  this.getDistrito();
}

}

