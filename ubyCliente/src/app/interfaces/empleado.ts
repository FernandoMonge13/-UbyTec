import { PersonalInterface } from "./genericas";

export interface EmpleadoInterface extends PersonalInterface {
    idEmpleado:number
}

class Empleado implements EmpleadoInterface{
    idEmpleado!: number;
    usuario!: string;
    pass!: string;
    nombre!: string;
    apellidos!: string;
    provincia!: string;
    canton!: string;
    distrito!: string;

}