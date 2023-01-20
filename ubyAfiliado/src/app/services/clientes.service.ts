import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from '../interfaces/cliente';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class ClientesService extends ConexionService<Cliente>{

  getResourceURL(): string {
    return "/Cliente"
  }
  getHomePage(): string {
    return ""
  }
  getNombre(): string {
    return "Cliente"
  }
  constructor(protected override httpClient: HttpClient, protected override route:Router) {
    super(httpClient, route);
  }
}
