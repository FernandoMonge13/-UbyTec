import { PersonalInterface } from "./genericas";

export interface RepartidorInterface extends PersonalInterface{
    disponible: boolean;
}

export class Repartidor implements RepartidorInterface{
    disponible: boolean = true;
    usuario!: string;
    pass = "null"
    nombre!: string;
    apellidos!: string;
    provincia!: string;
    canton!: string;
    distrito!: string;
}
