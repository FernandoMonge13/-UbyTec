export interface PedidoInterface {
    idPedido: number;
    direccion: string;
    finalizado: string;
    repartidor: string;
    idCliente:number;
    comprobante:string
}

export interface ProductoPedidoInterface {
    idPedido:number,
    producto:string,
    cantidad:number
}

export class Pedido implements PedidoInterface{
    idPedido!: number;
    direccion!: string;
    finalizado = "Solicitado";
    repartidor!: string;
    idCliente!: number;
    comprobante!:string
}

class ProductoPedido implements ProductoPedidoInterface{
    idPedido!: number;
    producto!: string;
    cantidad!: number;
    
}