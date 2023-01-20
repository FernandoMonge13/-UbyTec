import { PersonalInterface } from "./genericas";

export interface RepartidorInterface extends PersonalInterface{
    disponible: boolean;
}

class Repartidor implements RepartidorInterface{
    disponible: boolean = false;
    usuario!: string;
    pass!: string;
    nombre!: string;
    apellidos!: string;
    provincia!: string;
    canton!: string;
    distrito!: string;
}