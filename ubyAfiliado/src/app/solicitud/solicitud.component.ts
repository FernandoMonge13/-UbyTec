import { ConditionalExpr } from '@angular/compiler';
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
  listaTelefonos:Telefono[]=[]
  telefonoNuevo:Telefono = new Telefono();
  adminComercio:AdminComercio = new AdminComercio();
  solicitudEnviada:boolean=false;
  razon=""

  constructor(private service:ComerciosService, private razonService:ComerciosRechazadoService, private adminService: ComerciosAdminService,private route:Router, private rou:ActivatedRoute) { 
  }

  ngOnInit(): void {
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
          if(this.objeto.solicitud=="en proceso" || this.objeto.solicitud=="aceptada"){
            this.solicitudEnviada=true;
          }
          if (this.objeto.solicitud=="rechazada"){
            this.razonService.get(this.objeto.idComercio).subscribe({
              next: (data) => {
                this.razon = data[0].comentario
              }
            })
          }
        },
        /*Mensaje emergente de error*/
        error: (err) =>{
          this.service.avisoError(err.error)}
      });

  }
  /**
   * Funcion auxiliar para enviar la solicitud
   */
  aux(){
    this.service.update(this.objeto).subscribe({
      /*Mensaje emergente de exito*/

      next: (data) => {
        window.location.reload()
      },

        /*Mensaje emergente de error*/
      error: (err) =>{
        this.service.avisoError(err.error)
        }
    })
  }
  /**
   * Funcion para enviar la solicitud
   */
  onEnviar(){
    this.objeto.solicitud = "en proceso"
    this.aux()
  }
  /**
   * Funcion que cancela la solicitud
   */
  onCancelar(){
    this.objeto.solicitud = "no enviada"
    this.aux()
  }
  /**
   * Funcion que rechaza la solicitud
   */
  onRechazar(){
    this.objeto.solicitud = "rechazada"
    this.service.onActualizar(this.objeto,this.objeto.nombre)
    const input = document.getElementById('message') as HTMLInputElement | null;
    if (input != null) {
      console.log(
        {id: this.objeto.idComercio,
        message: input.value}
        );
    }
    this.service.aviso("Pedido completado Exitosamente, ¡Gracias por tu compra!")
  }
}
