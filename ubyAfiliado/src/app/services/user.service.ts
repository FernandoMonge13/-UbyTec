import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends ConexionService<boolean>{
  getResourceURL(): string {
    return "/Login/comercio"
  }
  getHomePage(): string {
    return ''
  }
  getNombre(): string {
    return "Usuario"
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router){
    super(httpClient, route)
  }
}
