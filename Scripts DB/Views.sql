CREATE VIEW Ventas_Afiliado 
AS
SELECT comercio.nombre AS Afiliado, count(pedido.idPedido) AS Compras, SUM(producto.precio * producto_pedido.cantidad) AS Monto_Total, SUM(producto.precio * producto_pedido.cantidad) * 0.05 AS Monto_Servicio
FROM (((pedido JOIN producto_pedido  ON pedido.idPedido=producto_pedido.idPedido) 
JOIN Producto ON producto=producto.nombre) 
			   JOIN comercio ON producto.idComercio = comercio.idComercio )
			   WHERE Pedido.finalizado = 'Finalizado'  GROUP BY comercio.idComercio;


CREATE VIEW Consolidado_Ventas
AS
SELECT Cliente.nombre AS Cliente, comercio.nombre AS Afiliado, count(pedido.idPedido) AS Compras, Pedido.repartidor AS Repartidor, SUM(producto.precio * producto_pedido.cantidad) AS Monto_Total, SUM(producto.precio * producto_pedido.cantidad) * 0.05 AS Monto_Servicio
FROM ((((pedido JOIN producto_pedido  ON pedido.idPedido=producto_pedido.idPedido) 
JOIN Producto ON producto_pedido.producto=producto.nombre) 
			   JOIN comercio ON producto.idComercio = comercio.idComercio ) JOIN Cliente ON pedido.idCliente = Cliente.idCliente)
			   WHERE Pedido.finalizado = 'Finalizado' GROUP BY Pedido.repartidor, Comercio.nombre, Cliente.nombre
			   ORDER BY Cliente.nombre ASC;

CREATE VIEW Comercio_Solicitud
AS
SELECT nombre, solicitud FROM Comercio
ORDER BY solicitud ASC;
