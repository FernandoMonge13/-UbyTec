import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminComercio, AdminComercioInterface, Comercio } from '../interfaces/comercio';
import { Telefono } from '../interfaces/genericas';
import { ComerciosAdminService, ComerciosRechazadoService, ComerciosService } from '../services/comercios.service';

@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html',
  styleUrls: ['./solicitud.component.css']
})
export class SolicitudComponent implements OnInit {

  objeto:Comercio = new Comercio();
  editMode:boolean = true;
  listaTelefonos:Telefono[]=[]
  telefonoNuevo:Telefono = new Telefono();
  adminComercio:AdminComercio = new AdminComercio();

  constructor(private service:ComerciosService, private adminService: ComerciosAdminService,private route:Router,private comerciosRechazadosSservice:ComerciosRechazadoService, private rou:ActivatedRoute) { 
  }

  ngOnInit(): void {
    if(this.rou.snapshot.params['id']==undefined){
      this.editMode = false;
    } else {
      this.adminService.get(this.rou.snapshot.params['id']).subscribe({
        /*Mensaje emergente de exito*/
        next: (data) => {
          console.log(data)
          if (data[0]==undefined){
            idComercio: this.objeto.idComercio;
            idAdmin: 0;
            correo:"";
            usuario: "";
            pass: "";
            nombre: "";
            apellidos: "";
            provincia: "";
            canton: "";
            distrito: ""
          } else {
            this.adminComercio = data[0];
          }
        },
        /*Mensaje emergente de error*/
        error: (err) =>{
          this.adminService.avisoError(err.error)}
      });
      this.service.get(this.rou.snapshot.params['id']).subscribe({
        /*Mensaje emergente de exito*/
        next: (data) => {
          this.objeto = data[0];
        },
        /*Mensaje emergente de error*/
        error: (err) =>{
          this.service.avisoError(err.error)}
      });
    }
  }
  /**
   * Funcion que se encarga de enviar la solicitud de registro de un comercio
   */
  onGuardar(){
    if (this.editMode){
      this.objeto.solicitud = "aceptada"
      this.service.onActualizar(this.objeto,this.objeto.nombre)
    } else {

      this.adminComercio.idComercio = this.objeto.idComercio
      console.log(this.adminComercio)
      this.service.add(this.objeto).subscribe({
        next: (data) => {
          this.adminService.add(this.adminComercio).subscribe({
            /*Mensaje emergente de exito*/
            next: (data) => {
              this.adminService.avisoSuccess("añadido", this.adminComercio.nombre);
              this.route.navigate([this.service.getHomePage()])
            },
              /*Mensaje emergente de error*/
            error: (err) =>{
              this.adminService.avisoError(err.error)
              }
          })
        },
        error: (err) => {
          this.service.avisoError(err.error)
        }
      })

    }
  }
  /**
   * Funcion que devuelve a la pagina anterior
   */
  onCancelar(){
    this.service.onCancelar()
  }
  /**
   * Funcion que rechaza solicitud de registro de un comercio
   */
  onRechazar(){
    this.objeto.solicitud = "rechazada"
    this.service.onActualizar(this.objeto,this.objeto.nombre)
    const input = document.getElementById('message') as HTMLInputElement | null;
    if (input != null) {
      this.comerciosRechazadosSservice.add({
        idComercio:this.objeto.idComercio,
        comentario:input.value
      }).subscribe({
        next: (data) =>{
          console.log(data)
          console.log("añadido")
        }
      })
    }

  }
}
