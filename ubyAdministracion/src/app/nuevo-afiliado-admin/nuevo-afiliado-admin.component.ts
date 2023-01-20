import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {Comercio,AdminComercio} from '../interfaces/comercio'
import { Telefono, TelefonoInterface } from '../interfaces/genericas';
import { ComerciosAdminService } from '../services/comercios.service';
import { DireccionesService, TelefonosService } from '../services/telefonos.service';


@Component({
  selector: 'app-nuevo-afiliado-admin',
  templateUrl: './nuevo-afiliado-admin.component.html',
  styleUrls: ['./nuevo-afiliado-admin.component.css']
})
export class NuevoAfiliadoAdminComponent implements OnInit {



  objeto:AdminComercio = new AdminComercio();

  editMode:boolean = true;
  listaTelefonos:Telefono[]=[]
  telefonoNuevo:Telefono = new Telefono();
  idComercio:number=0;

  provincias:string[] = [];
  cantones:string[] = [];
  distritos:string[] = [];

  constructor(private service:ComerciosAdminService, private telefonosService:TelefonosService, private direccionesService:DireccionesService, private route:Router, private rou:ActivatedRoute) {
    this.telefonosService.url = "AdminComerTelefonos";
    this.telefonosService.nombre = "Telefono de Administrador";
    this.telefonosService.homePage = "actualizar/administrador/" + this.rou.snapshot.params['id'];
    this.idComercio = this.rou.snapshot.params['id']
    this.service.id = this.rou.snapshot.params['id']
    this.objeto.idComercio = this.rou.snapshot.params['id']
    this.service.get(this.rou.snapshot.params['id']).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        if (data[0]== undefined){
          this.getProvincia();
          this.editMode = false
        } else {
          this.objeto = data[0]
          this.getProvincia();
          this.getCanton();
          this.getDistrito();
        }
      },
      /*Mensaje emergente de error*/
      error: (err) =>{
        this.service.avisoError(err.error)}
    });
    console.log(this.objeto)
  }

  ngOnInit(): void {

  }
  /*
  Funcion que al guardar carga el objeto con los datos del formulario
   */
  onGuardar(recargar?:boolean){
    console.log(this.objeto)
    if (this.editMode){
      this.service.onActualizar(this.objeto,this.objeto.nombre,recargar)
    } else {
      this.service.onNuevo(this.objeto,this.objeto.nombre, recargar)
    }
  }
  /*
  Funcion que cancela el servicio del objeto
   */
  onCancelar(){
    this.service.onCancelar()
  }
  /*
  Funcion que elimina el objeto
  */
  onEliminar(){
    this.service.onEliminar(this.objeto.idAdmin)
  }

  /*
  Funcion que carga los telefonos del objeto
   */
  onTelefonos(){
    if (!this.editMode){
      this.onGuardar(false)
      this.editMode = true
    }
    this.telefonosService.get(this.objeto.idAdmin).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        this.listaTelefonos = data;
      },
      /*Mensaje emergente de error*/
      error: (err) =>{
        this.service.avisoError(err.error)}
    })
  }
  /*
  Funcion que agrega un telefono al objeto
   */
  onAddTelefono(){
    this.telefonoNuevo.id = this.objeto.idAdmin
    this.telefonosService.onNuevo(this.telefonoNuevo,this.telefonoNuevo.telefono)
  }
  /*
  Funcion que elimina un telefono del objeto
   */
  onDeleteTelefono(tel:TelefonoInterface){
    this.telefonosService.onEliminar(tel.id, tel.telefono)
  }
  /**
   * Funcion que carga las provincias
   */
  getProvincia(){
    this.direccionesService.get("Provincia").subscribe({
      next: (data) => {
        this.provincias = data;
      }
    })
  }
  /**
   * Funcion que carga los cantones
   */
  getCanton(){
    this.direccionesService.get(this.objeto.provincia).subscribe({
      next: (data) => {
        this.cantones = data;
      }
  })
}
  /**
   * Funcion que carga los distritos
   */
  getDistrito(){
    this.direccionesService.get(this.objeto.provincia,this.objeto.canton).subscribe({
      next: (data) => {
        this.distritos = data;
      }
  })
}
  /**
   * Funcion que carga los cantones
   */
selected(){
  this.getCanton();
}
/**
 * Funcion que carga los distritos
 */
selectedcant(){
  this.getDistrito();
}
}
