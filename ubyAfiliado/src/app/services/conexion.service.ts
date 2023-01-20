import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export abstract class ConexionService<T> {

  /**Ruta a conectarse con el API REST */
 //private readonly RUTA_API = "https://localhost:7035/api" + this.getResourceURL();
 constructor(protected httpClient:HttpClient, protected route:Router) {
 }

 getRuta(){
  return "https://ubytecdbapi.azurewebsites.net/api" + this.getResourceURL();
 }

 abstract getResourceURL(): string;
 abstract getHomePage(id?: string|number, id2?: string|number): string;
 abstract getNombre(): string;
 
 temp:T[]=[]
 listaAll:T[]=[]
  getList(){
    return this.httpClient.get<T[]>(this.getRuta());
  }
  
  get(id: string | number, marca?:string | number){
    console.log(this.getRuta())
    if (marca){
      return this.httpClient.get<T[]>(this.getRuta()+"/"+id+ "/"+ marca);
    }
    return this.httpClient.get<T[]>(this.getRuta()+"/"+id);
  }

  add(resource:T): Observable<T>{
    return this.httpClient.post<T>(this.getRuta(),resource);
  }

  update(resource:T): Observable<T> {
    return this.httpClient.put<T>(this.getRuta(),resource);
  }

  private delete(id: string | number){
    return this.httpClient.delete<T[]>(this.getRuta()+"/"+id);
  }


  onEliminar(id:string | number, id2?: string|number, recargar?:boolean){
    if (id2){
      id = id + "/" + id2
    }
    this.delete(id).subscribe({
      next:(data)=>{
        this.avisoSuccess("eliminado", id);
        if (recargar==undefined){
        this.route.navigate([this.getHomePage()])}},
        error: (err) =>{
          this.avisoError(err.error)} 
    })
  }

  onActualizar(objeto:T, nombre:string | number, recargar?:boolean){
    console.log(objeto)
    /**Solicitud HTTP para el PUT en el API */
    this.update(objeto).subscribe({
      /*Mensaje emergente de exito*/
      
      next: (data) => {
        if (recargar==undefined){
          this.avisoSuccess("actualizado", nombre);
          this.route.navigate([this.getHomePage()])}
      },

        /*Mensaje emergente de error*/
      error: (err) =>{
        this.avisoError(err.error)
        }
    })
  }

  onNuevo(objeto:T, nombre:string | number,  recargar?:boolean){
    console.log(objeto)
    /**Solicitud HTTP para el PUT en el API */
    this.add(objeto).subscribe({
      /*Mensaje emergente de exito*/
      
      next: (data) => {
        this.avisoSuccess("añadido", nombre);
        if (recargar==undefined){
          this.route.navigate([this.getHomePage()])}
      },
        /*Mensaje emergente de error*/
      error: (err) =>{
        this.avisoError(err.error)
        }
    })
  }

  onCancelar(){
    this.route.navigate([this.getHomePage()])
  }

  avisoError(mensaje:string){
    Swal.fire({
      icon: 'error',
      title: '¡Algo ha salido mal!',
      text: mensaje
    })
  }    

  avisoSuccess(tipo:string, id:string | number){
    Swal.fire({
      icon: 'success',
      title: '¡Has ' + tipo + ' a '+ id +' como ' + this.getNombre() + ' exitosamente!'
    })
  } 

  aviso(mensaje:string){
    Swal.fire({
      icon: 'success',
      title: mensaje
    })
  }

  
}