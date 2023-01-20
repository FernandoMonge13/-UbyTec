export interface PedidoInterface {
    idPedido: number;
    direccion: string;
    finalizado: boolean;
    repartidor: string;
    idCliente:number;
}

export interface ProductoPedidoInterface {
    idPedido:number,
    producto:string,
    cantidad:number
}

export class Pedido implements PedidoInterface{
    idPedido!: number;
    direccion!: string;
    finalizado!: boolean;
    repartidor!: string;
    idCliente!: number;
}

class ProductoPedido implements ProductoPedidoInterface{
    idPedido!: number;
    producto!: string;
    cantidad!: number;
    
}