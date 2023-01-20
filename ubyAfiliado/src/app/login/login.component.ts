import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import {Comercio} from '../interfaces/comercio';
import { ComerciosService } from '../services/comercios.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  id!:string
  password!:string
  editMode:boolean = false;

  objeto:Comercio = new Comercio();

  constructor(private route:Router, private aoth:UserService, private cookie: CookieService, private router: Router, private httpClient:HttpClient, private comercioService:ComerciosService) {
    if (cookie.get("tokenAfiliado")!=""){
      this.route.navigate([cookie.get("tokenAfiliado") + "/gestion-perfil"])
    }
  }
  ngOnInit(): void {
  }
  /**
   * Al hacer click en el boton de login, se envia una peticion al servidor para verificar si el usuario existe
   */
  onSubmit(){
    this.aoth.get(this.id,this.password).subscribe({
      next:(data) => {
        if(data){
          this.cookie.set("tokenAfiliado", this.id.toString(), 4, "/");
          window.location.reload()
        }
      },
      error:(err) => {
        this.aoth.avisoError("Credenciales inválidas")
      }
      })
  }

  onEliminar(){
    console.log("Eliminar")

  }

  onCancelar(){
    console.log("Cancelar")
  }
  /**
   * Funcion que se ejecuta al hacer click en el boton de crear cuenta
   */
  onGuardar(){
    this.objeto.canton="";
    this.objeto.provincia="";
    this.objeto.distrito="";
    this.objeto.solicitud="no enviada"
    console.log(this.objeto)
    this.comercioService.onNuevo(this.objeto, this.objeto.nombre)
  }
}

