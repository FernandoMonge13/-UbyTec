import { PersonalInterface } from "./genericas"

export interface ComercioInterface {
    idComercio:number,
    pass:string,
    idAdmin:number,
    tipo:string,
    nombre:string,
    correo:string,
    sinpe:number,
    solicitud:string,
    provincia:string,
    canton:string,
    distrito:string
}


export interface AdminComercioInterface extends PersonalInterface {
    idAdmin:number,
    idComercio:number,
    correo:string
}

export class Comercio implements ComercioInterface{
    pass = "null"
    idComercio!: number
    idAdmin!: number
    tipo!: string
    nombre!: string
    correo!: string
    sinpe!: number
    solicitud = "en proceso" 
    provincia!: string
    canton!: string
    distrito!: string
}

export  class AdminComercio implements AdminComercioInterface{
    idComercio!: number
    idAdmin!: number
    correo!: string
    usuario!: string
    pass = "null"
    nombre!: string
    apellidos!: string
    provincia!: string
    canton!: string
    distrito!: string
    
}