import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
CrearCuenta() {
throw new Error('Method not implemented.');
}

  id!:number
  password!:string
  constructor(private route:Router, private aoth:UserService, private cookie: CookieService, private router: Router, private httpClient:HttpClient) {
    if (cookie.get("tokenAdministrador")!=""){
      this.route.navigate(["gestion/empleado"])
    }
  }

  ngOnInit(): void {
  }

  /*
  Al hacer click en el boton de login, se envia una peticion al servidor para verificar si el usuario existe
   */
  onSubmit(){
    this.aoth.get(this.id,this.password).subscribe({
      next:(data) => {
        if(data){
          this.cookie.set("tokenAdministrador", this.id.toString());
          window.location.reload()
        }
      },
      error:(err) => {
        this.aoth.avisoError("Credenciales inválidas")
      }
      })
  }

}
