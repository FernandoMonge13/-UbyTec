import { Component, OnInit } from '@angular/core';
import {TelefonoInterface, Telefono} from '../interfaces/genericas';
import {Empleado } from '../interfaces/empleado';
import { EmpleadosService } from '../services/empleados.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DireccionesService, TelefonosService } from '../services/telefonos.service';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-nuevo-empleado',
  templateUrl: './nuevo-empleado.component.html',
  styleUrls: ['./nuevo-empleado.component.css']
})
export class NuevoEmpleadoComponent implements OnInit {


  objeto:Empleado = new Empleado();
  editMode:boolean = true;

  telefonoNuevo:Telefono = new Telefono();
  listaTelefonos:Telefono[] = [];

  provincias:string[] = [];
  cantones:string[] = [];
  distritos:string[] = [];
  provincia: any;
  canton: any;



  constructor(private service:EmpleadosService, private route:Router, private rou:ActivatedRoute, protected telefonosService:TelefonosService, protected direccionesService:DireccionesService) {
    this.telefonosService.url = "EmpleadoTelefonos";
    this.telefonosService.nombre = "Telefono de Empleado";
  }

  ngOnInit(): void {
    this.telefonosService.url = "EmpleadoTelefonos";
    this.telefonosService.nombre = "Telefono de Empleado";
    if(this.rou.snapshot.params['id']==undefined){
      this.getProvincia();
      this.editMode = false;
      this.telefonosService.homePage = "nuevo/empleado";
    } else {
      this.telefonosService.homePage = "actualizar/empleado/"+this.rou.snapshot.params['id'];
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
   * Funcion que realiza la accion de guardar
   * @param recargar recarga la pagina
   */
  onGuardar(recargar?:boolean){
    if (this.editMode){
      this.service.onActualizar(this.objeto,this.objeto.nombre, recargar)
    } else {
      this.service.onNuevo(this.objeto,this.objeto.nombre, recargar)
    }
  }
  /**
   * Funcion que agrega un telefono a la lista de telefonos
   */
  onAddTelefono(){
    this.telefonoNuevo.id = this.objeto.idEmpleado
    this.telefonosService.onNuevo(this.telefonoNuevo,this.telefonoNuevo.telefono)
    this.route.navigate(['actualizar/empleados/'+this.objeto.idEmpleado])
  }
  /**
   * Funcion que elimina un telefono de la lista de telefonos
   * @param tel
   */
  onDeleteTelefono(tel:TelefonoInterface){
    this.telefonosService.onEliminar(this.objeto.idEmpleado, tel.telefono)
    //mcsjhfnjednf
  }
  /**
   * Funcion que actualiza la lista de telefonos
   */
  onTelefonos(){
    if (!this.editMode){
      this.onGuardar(false)
      this.editMode = true
    }
    this.telefonosService.get(this.objeto.idEmpleado).subscribe({
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
   * Funcion que cancela el servicio
   */
  onCancelar(){
    this.service.onCancelar()
  }
  /**
   * Funcion que elimina un empleado
   */
  onEliminar(){
    this.service.onEliminar(this.objeto.idEmpleado)
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
  /**
   * Funcion que obtiene el canton
   */
selected(){
  this.getCanton();
}
  /**
   * Funcion que obtiene el distrito
   */
selectedcant(){
  this.getDistrito();
}

}
