import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TelefonoInterface } from '../interfaces/genericas';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})

export class TelefonosService extends ConexionService<TelefonoInterface> {

  url:string = ""
  homePage:string  = ""
  nombre:string  = ""

  getResourceURL(): string {
    return "/"+this.url
  }

  getHomePage(): string {
    return '/'+this.homePage
  }

  getNombre(): string {
    return this.nombre
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }
}

@Injectable({
  providedIn: 'root'
})

export class DireccionesService extends ConexionService<string> {


  getResourceURL(): string {
    return "/Direccion"
  }

  getHomePage(): string {
    return ''
  }

  getNombre(): string {
    return ''
  }

  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }
}
