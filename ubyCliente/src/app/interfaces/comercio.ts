import { PersonalInterface } from "./genericas"

export interface ComercioInterface {
    idComercio:number,
    pass:string,
    idAdmin:number,
    tipo:string,
    nombre:string,
    correo:string,
    sinpe:number,
    solicitud:boolean,
    provincia:string,
    canton:string,
    distrito:string
}


export interface AdminComercioInterface extends PersonalInterface {
    idAdmin:number,
    correo:string
}

export class Comercio implements ComercioInterface{
    pass!: string
    idComercio!: number
    idAdmin!: number
    tipo!: string
    nombre!: string
    correo!: string
    sinpe!: number
    solicitud= true
    provincia!: string
    canton!: string
    distrito!: string
}

class AdminComercio implements AdminComercioInterface{
    idAdmin!: number
    correo!: string
    usuario!: string
    pass!: string
    nombre!: string
    apellidos!: string
    provincia!: string
    canton!: string
    distrito!: string
    
}