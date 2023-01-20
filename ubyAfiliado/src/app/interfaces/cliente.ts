import { PersonalInterface } from "./genericas";

export interface ClienteInterface extends PersonalInterface {
    idCliente:number,
    fechaNac:string
}


export class Cliente implements ClienteInterface{
    idCliente!: number;
    fechaNac!: string;
    usuario!: string;
    pass!: string;
    nombre!: string;
    apellidos!: string;
    provincia!: string;
    canton!: string;
    distrito!: string;
    
}