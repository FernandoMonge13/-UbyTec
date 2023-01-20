export interface ReporteInterface{
  //Reporte ventas afiliado
  afiliado: string,
  compras: number,
  monto_total: number,
  monto_servicio: number,
  //Reporte consolidiado de ventas
  cliente: string,
  repartidor: string,

  //Reporte solicitudes de afiliacion
  nombre: string,
  solicitud: boolean

}

export class Reporte implements ReporteInterface{
  afiliado!: string;
  compras!: number;
  monto_total!: number;
  monto_servicio!: number;
  cliente!: string;
  repartidor!: string;
  nombre!: string ;
  solicitud!: boolean;
}
