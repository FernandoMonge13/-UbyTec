export interface ProductoInterface {
    nombre:string,
    precio:number,
    categoria:string,
    idComercio:number
}

export interface ProductoFotosInterface {
    producto:string,
    foto:string,
}

class Producto implements ProductoInterface{
    nombre!: string;
    precio!: number;
    categoria!: string;
    idComercio!: number;
}

class ProductoFotos implements ProductoFotosInterface{
    producto!: string;
    foto!: string;
    
}