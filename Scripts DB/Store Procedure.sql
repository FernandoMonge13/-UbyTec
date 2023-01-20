-- REPARTIDOR TELEFONOS
CREATE OR REPLACE PROCEDURE AddRepartidor_Telefonos(
	usuarioRep_ VARCHAR,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO repartidor_telefonos(usuarioRep,telefono)
	VALUES (usuarioRep_,telefono_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetRepartidor_Telefonos()
RETURNS setof repartidor_telefonos
language sql
AS
$$
	select usuarioRep,telefono from public.repartidor_telefonos
	ORDER BY usuarioRep ASC;
$$;


CREATE OR REPLACE FUNCTION GetRepartidor_TelefonosByID(
	usuarioRep_ varchar
)
RETURNS setof repartidor_telefonos
language sql
AS $$
	select usuarioRep,telefono from public.repartidor_telefonos
	where repartidor_telefonos.usuarioRep = usuarioRep_;
$$;


CREATE OR REPLACE PROCEDURE DeleteRepartidor_Telefonos(
	usuarioRep_ VARCHAR,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM repartidor_telefonos WHERE usuarioRep=usuarioRep_ and telefono = telefono_;
	commit;
END
$$;


-- REPARTIDOR
CREATE OR REPLACE PROCEDURE AddRepartidor(
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	disponible_ BOOLEAN,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR,
	correo_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO repartidor(usuario,pass,nombre,apellidos,disponible,provincia,canton,distrito,correo)
	VALUES (usuario_,pass_,nombre_,apellidos_,disponible_,provincia_,canton_,distrito_,correo_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetRepartidor()
RETURNS setof repartidor
language sql
AS
$$
	select usuario,pass,nombre,apellidos,disponible,provincia,canton,distrito,correo from public.repartidor
	ORDER BY usuario ASC;
$$;

--drop function GetRepartidores()
CREATE OR REPLACE FUNCTION GetRepartidorByID(
	usuario_ varchar
)
RETURNS setof repartidor
language sql
AS $$
	select usuario,pass,nombre,apellidos,disponible,provincia,canton,distrito,correo from repartidor
	where repartidor.usuario = usuario_;
$$;


CREATE OR REPLACE PROCEDURE UpdateRepartidor(
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	disponible_ BOOLEAN,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR,
	correo_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	UPDATE repartidor SET pass=pass_,nombre=nombre_,apellidos=apellidos_,disponible=disponible,
	provincia=provincia_,canton=canton_,distrito=distrito_,correo=correo_ WHERE usuario=usuario_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteRepartidor(
	usuario_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	DELETE FROM repartidor WHERE usuario=usuario_;
	commit;
END
$$;


-- EMPLEADO TELEFONOS
CREATE OR REPLACE PROCEDURE AddEmpleado_Telefonos(
	idEmpleado_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO empleado_telefonos(idEmpleado,telefono)
	VALUES (idEmpleado_,telefono_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetEmpleado_Telefonos()
RETURNS setof empleado_telefonos
language sql
AS
$$
	select idEmpleado,telefono from public.empleado_telefonos
	ORDER BY idEmpleado ASC;
$$;


CREATE OR REPLACE FUNCTION GetEmpleado_TelefonosByID(
	idEmpleado_ int
)
RETURNS setof empleado_telefonos
language sql
AS $$
	select idEmpleado,telefono from public.empleado_telefonos
	where empleado_telefonos.idEmpleado = idEmpleado_;
$$;


CREATE OR REPLACE PROCEDURE DeleteEmpleado_Telefonos(
	idEmpleado_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM empleado_telefonos WHERE idEmpleado=idEmpleado_ and telefono = telefono_;
	commit;
END
$$;



--EMPLEADO

CREATE OR REPLACE PROCEDURE AddEmpleado(
	idEmpleado_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO empleado(idEmpleado,usuario,pass,nombre,apellidos,provincia,canton,distrito)
	VALUES (idEmpleado_,usuario_,pass_,nombre_,apellidos_,provincia_,canton_,distrito_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetEmpleado()
RETURNS setof empleado
language sql
AS
$$
	select idEmpleado,usuario,pass,nombre,apellidos,provincia,canton,distrito from public.empleado
	ORDER BY idEmpleado ASC;
$$;

CREATE OR REPLACE FUNCTION GetEmpleadoByID(
	idEmpleado_ int
)
RETURNS setof empleado
language sql
AS $$
	select idEmpleado,usuario,pass,nombre,apellidos,provincia,canton,distrito from empleado
	where empleado.idEmpleado = idEmpleado_;
$$;


CREATE OR REPLACE PROCEDURE UpdateEmpleado(
	idEmpleado_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	UPDATE empleado SET usuario=usuario_, pass=pass_,nombre=nombre_,apellidos=apellidos_,
	provincia=provincia_,canton=canton_,distrito=distrito_ WHERE idEmpleado=idEmpleado_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteEmpleado(
	idEmpleado_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM empleado WHERE idEmpleado=idEmpleado_;
	commit;
END
$$;


-- ADMIN COMER TELEFONOS
CREATE OR REPLACE PROCEDURE AddAdmin_Comer_Telefonos(
	idAdmin_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO admin_comer_telefonos(idAdmin,telefono)
	VALUES (idAdmin_,telefono_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetAdmin_Comer_Telefonos()
RETURNS setof admin_comer_telefonos
language sql
AS
$$
	select idAdmin,telefono from public.admin_comer_telefonos
	ORDER BY idAdmin ASC;
$$;


CREATE OR REPLACE FUNCTION GetAdmin_Comer_TelefonosByID(
	idAdmin_ int
)
RETURNS setof admin_comer_telefonos
language sql
AS $$
	select idAdmin,telefono from public.admin_comer_telefonos
	where admin_comer_telefonos.idAdmin = idAdmin_;
$$;


CREATE OR REPLACE PROCEDURE DeleteAdmin_Comer_Telefonos(
	idAdmin_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM admin_comer_telefonos WHERE idAdmin=idAdmin_ and telefono = telefono_;
	commit;
END
$$;



--ADMIN COMERCIO

CREATE OR REPLACE PROCEDURE AddAdmin_Comercio(
	idAdmin_ int,
	idComercio_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	correo_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO admin_comercio(idAdmin,usuario,pass,nombre,apellidos,correo,provincia,canton,distrito,idComercio)
	VALUES (idAdmin_,usuario_,pass_,nombre_,apellidos_,correo_,provincia_,canton_,distrito_,idComercio_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetAdmin_Comercio()
RETURNS setof admin_comercio
language sql
AS
$$
	select idAdmin,usuario,pass,nombre,apellidos,correo,provincia,canton,distrito,idComercio from public.admin_comercio
$$;

CREATE OR REPLACE FUNCTION GetAdmin_ComercioByID(
	idAdmin_ int
)
RETURNS setof admin_comercio
language sql
AS $$
	select idAdmin,usuario,pass,nombre,apellidos,correo,provincia,canton,distrito,idComercio from admin_comercio
	where admin_comercio.idAdmin = idAdmin_;
$$;


CREATE OR REPLACE PROCEDURE UpdateAdmin_Comercio(
	idAdmin_ int,
	idComercio_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	correo_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	UPDATE admin_comercio SET usuario=usuario_, pass=pass_,nombre=nombre_,apellidos=apellidos_,
	correo=correo_,provincia=provincia_,canton=canton_,distrito=distrito_,idComercio=idComercio_
	WHERE idAdmin=idAdmin_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteAdmin_Comercio(
	idAdmin_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM admin_comercio WHERE idAdmin=idAdmin_;
	commit;
END
$$;


--COMERCIO

CREATE OR REPLACE PROCEDURE AddComercio(
	idComercio_ int,
	pass_ VARCHAR,
	tipo_ VARCHAR,
	nombre_ VARCHAR,
	correo_ VARCHAR,
	sinpe_ int,
	solicitud_ BOOLEAN,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO comercio(idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito)
	VALUES (idComercio_,pass_,tipo_,nombre_,correo_,sinpe_,solicitud_,provincia_,canton_,distrito_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetComercio()
RETURNS setof comercio
language sql
AS
$$
	select idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito from public.comercio
	ORDER BY idComercio ASC;
$$;


CREATE OR REPLACE FUNCTION GetComercioCercanoACliente(
	idCliente_ int
)
RETURNS setof comercio
language SQL
AS
$$
	select idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito from Comercio 
	where provincia = (Select provincia from Cliente where idCliente = idCliente_) AND solicitud='aceptada';

$$;

CREATE OR REPLACE FUNCTION GetComercioByID(
	idComercio_ int
)
RETURNS setof comercio
language sql
AS $$
	select idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito from comercio
	where comercio.idComercio = idComercio_;
$$;

CREATE OR REPLACE PROCEDURE UpdateComercio(
	idComercio_ int,
	pass_ VARCHAR,
	tipo_ VARCHAR,
	nombre_ VARCHAR,
	correo_ VARCHAR,
	sinpe_ int,
	solicitud_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	UPDATE comercio SET pass=pass_,tipo=tipo_,nombre=nombre_,correo=correo_,sinpe=sinpe_,solicitud=solicitud_,
	provincia=provincia_,canton=canton_,distrito=distrito_ WHERE idComercio = idComercio_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteComercio(
	idComercio_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM comercio WHERE idComercio=idComercio_;
	commit;
END
$$;



-- COMERCIO TELEFONOS
CREATE OR REPLACE PROCEDURE AddComercio_Telefonos(
	idComercio_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO comercio_telefonos(idComercio,telefono)
	VALUES (idComercio_,telefono_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetComercio_Telefonos()
RETURNS setof comercio_telefonos
language sql
AS
$$
	select idComercio,telefono from public.comercio_telefonos
	ORDER BY idComercio ASC;
$$;


CREATE OR REPLACE FUNCTION GetComercio_TelefonosByID(
	idComercio_ int
)
RETURNS setof comercio_telefonos
language sql
AS $$
	select idComercio,telefono from public.comercio_telefonos
	where comercio_telefonos.idComercio = idComercio_;
$$;


CREATE OR REPLACE PROCEDURE DeleteComercio_Telefonos(
	idComercio_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM comercio_telefonos WHERE idComercio=idComercio_ and telefono = telefono_;
	commit;
END
$$;


-- PRODUCTO FOTOS
CREATE OR REPLACE PROCEDURE AddProducto_Fotos(
	producto_ VARCHAR,
	foto_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO producto_fotos(producto,foto)
	VALUES (producto_,foto_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetProducto_Fotos()
RETURNS setof producto_fotos
language sql
AS
$$
	select producto,foto from public.producto_fotos
	ORDER BY producto ASC;
$$;


CREATE OR REPLACE FUNCTION GetProducto_FotosByID(
	producto_ VARCHAR
)
RETURNS setof producto_fotos
language sql
AS $$
	select producto,foto from public.producto_fotos
	where producto_fotos.producto = producto_;
$$;


CREATE OR REPLACE PROCEDURE DeleteProducto_Fotos(
	producto_ VARCHAR,
	foto_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	DELETE FROM producto_fotos WHERE producto=producto_ and foto = foto_;
	commit;
END
$$;



--PRODUCTO

CREATE OR REPLACE PROCEDURE AddProducto(
	nombre_ VARCHAR,
	precio_ int,
	categoria_ VARCHAR,
	idComercio_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO producto(nombre,precio,categoria,idComercio)
	VALUES (nombre_,precio_,categoria_,idComercio_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetProducto()
RETURNS setof producto
language sql
AS
$$
	select nombre,precio,categoria,idComercio from public.producto
	ORDER BY nombre ASC;
$$;

CREATE OR REPLACE FUNCTION GetProductoByID(
	nombre_ varchar
)
RETURNS setof producto
language sql
AS $$
	select nombre,precio,categoria,idComercio from producto
	where producto.nombre = nombre_;
$$;

CREATE OR REPLACE FUNCTION GetProducto()
RETURNS setof producto
language sql
AS
$$
	select nombre,precio,categoria,idComercio from public.producto
	ORDER BY nombre ASC;
$$;

CREATE OR REPLACE FUNCTION GetProductoByIdComercio(
	idComercio_ int
)
RETURNS setof producto
language sql
AS $$
	select nombre,precio,categoria,idComercio from producto
	where producto.idComercio = idComercio_;
$$;

CREATE OR REPLACE PROCEDURE UpdateProducto(
	nombre_ VARCHAR,
	precio_ int,
	categoria_ VARCHAR,
	idComercio_ int
)
language plpgsql
AS $$
BEGIN
	UPDATE producto SET precio=precio_,categoria=categoria_,idComercio=idComercio_
	WHERE nombre = nombre_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteProducto(
	nombre_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	DELETE FROM producto WHERE nombre=nombre_;
	commit;
END
$$;



--PRODUCTOS PEDIDOS

CREATE OR REPLACE PROCEDURE AddProducto_Pedido(
	idPedido_ int,
	producto_ VARCHAR,
	cantidad_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO producto_pedido(idPedido,producto,cantidad)
	VALUES (idPedido_,producto_,cantidad_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetProducto_Pedido()
RETURNS setof producto_pedido
language sql
AS
$$
	select idPedido,producto,cantidad from public.producto_pedido
	ORDER BY idPedido ASC;
$$;

CREATE OR REPLACE FUNCTION GetProducto_PedidoByID(
	idPedido_ int
)
RETURNS setof producto_pedido
language sql
AS $$
	select idPedido,producto,cantidad from producto_pedido
	where producto_pedido.idPedido = idPedido_;
$$;


CREATE OR REPLACE PROCEDURE UpdateProducto_Pedido(
	idPedido_ int,
	producto_ VARCHAR,
	cantidad_ int
)
language plpgsql
AS $$
BEGIN
	UPDATE producto_pedido SET cantidad=cantidad_
	WHERE idPedido=idPedido_ and producto=producto_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteProducto_Pedido(
	idPedido_ int,
	producto_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	DELETE FROM producto_pedido WHERE idPedido=idPedido_ and producto=producto_;
	commit;
END
$$;


--PEDIDO
CREATE OR REPLACE PROCEDURE AddPedido(
	
	idPedido_ int,
	direccion_ VARCHAR,
	finalizado_ VARCHAR,
	repartidor VARCHAR,
	idCliente_ int,
	comprobante_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO pedido(idPedido,direccion,finalizado,repartidor,idCliente,comprobante)
	VALUES (idPedido_,direccion_,finalizado_,null,idCliente_,comprobante_);
	commit;
END
$$;

CREATE OR REPLACE FUNCTION getNewIDPedido()
RETURNS INT
language sql
AS $$
	select Max(idPedido)+1 from pedido;
$$;

CREATE OR REPLACE FUNCTION GetPedido()
RETURNS setof pedido
language sql
AS
$$
	select idPedido,direccion,finalizado,repartidor,idCliente,comprobante from public.pedido
	ORDER BY idPedido ASC;
$$;

CREATE OR REPLACE FUNCTION GetPedidoEnCurso(
	idCliente_ int
)
returns setof pedido
language sql
AS
$$
	select idPedido,direccion,finalizado,repartidor,idCliente,comprobante from pedido
	where finalizado = 'En Curso' AND idCliente = idCliente_;
$$;

CREATE OR REPLACE FUNCTION GetPedidoByID(
	idPedido_ int
)
RETURNS setof pedido
language sql
AS $$
	select idPedido,direccion,finalizado,repartidor,idCliente,comprobante from pedido
	where pedido.idPedido = idPedido_;
$$;

CREATE OR REPLACE FUNCTION GetPedidoByIDComercio(
	idComercio_ int
)
RETURNS setof pedido
language sql
AS $$
	select idPedido,direccion,finalizado,repartidor,idCliente,comprobante from pedido
	Where exists
	(select idComercio,idPedido from (producto_pedido join producto on producto_pedido.producto = producto.nombre) where idComercio=idComercio_ AND pedido.idPedido = idPedido );
$$;

CREATE OR REPLACE FUNCTION GetPedidoByIDCliente(
	idCliente_ int
) RETURNS SETOF pedido
LANGUAGE SQL
AS $$
	select idPedido,direccion,finalizado,repartidor,idCliente,comprobante 
	from pedido where idCliente = idCliente_ AND finalizado = 'En Curso';
$$;

CREATE OR REPLACE PROCEDURE UpdatePedido(
	idPedido_ int,
	direccion_ VARCHAR,
	finalizado_ VARCHAR,
	repartidor_ VARCHAR,
	idCliente_ int,
	comprobante_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	UPDATE pedido SET direccion=direccion_,finalizado=finalizado_,repartidor=repartidor_,idCliente=idCliente_,comprobante=comprobante_
	WHERE idPedido = idPedido_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeletePedido(
	idPedido_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM pedido WHERE idPedido = idPedido_;
	commit;
END
$$;


-- CLIENTE TELEFONOS
CREATE OR REPLACE PROCEDURE AddCliente_Telefonos(
	idCliente_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	INSERT INTO cliente_telefonos(idCliente,telefono)
	VALUES (idCliente_,telefono_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetCliente_Telefonos()
RETURNS setof cliente_telefonos
language sql
AS
$$
	select idCliente,telefono from public.cliente_telefonos
	ORDER BY idCliente ASC;
$$;


CREATE OR REPLACE FUNCTION GetCliente_TelefonosByID(
	idCliente_ int
)
RETURNS setof cliente_telefonos
language sql
AS $$
	select idCliente,telefono from public.cliente_telefonos
	where cliente_telefonos.idCliente = idCliente_;
$$;


CREATE OR REPLACE PROCEDURE DeleteCliente_Telefonos(
	idCliente_ int,
	telefono_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM cliente_telefonos WHERE idCliente=idCliente_ and telefono = telefono_;
	commit;
END
$$;


--CLIENTE

CREATE OR REPLACE PROCEDURE AddCliente(
	idCliente_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	fechaNac_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
)
language plpgsql
AS $$
BEGIN
	INSERT INTO cliente(idCliente,usuario,pass,nombre,apellidos,fechaNac,provincia,canton,distrito)
	VALUES (idCliente_,usuario_,pass_,nombre_,apellidos_,fechaNac_,provincia_,canton_,distrito_);
	commit;
END
$$;


CREATE OR REPLACE FUNCTION GetCliente()
RETURNS setof cliente
language sql
AS
$$
	select idCliente,usuario,pass,nombre,apellidos,fechaNac,provincia,canton,distrito from public.cliente
	ORDER BY idCliente ASC;
$$;

CREATE OR REPLACE FUNCTION GetClienteByID(
	idCliente_ int
)
RETURNS setof cliente
language sql
AS $$
	select idCliente,usuario,pass,nombre,apellidos,fechaNac,provincia,canton,distrito from cliente
	where cliente.idCliente = idCliente_;
$$;


CREATE OR REPLACE PROCEDURE UpdateCliente(
	idCliente_ int,
	usuario_ VARCHAR,
	pass_ VARCHAR,
	nombre_ VARCHAR,
	apellidos_ VARCHAR,
	fechaNac_ VARCHAR,
	provincia_ VARCHAR,
	canton_ VARCHAR,
	distrito_ VARCHAR
	)
language plpgsql
AS $$
BEGIN
	UPDATE cliente SET usuario=usuario_,pass=pass_,nombre=nombre_,apellidos=apellidos_,fechaNac=fechaNac_,
	provincia=provincia_,canton=canton_,distrito=distrito_ 
	WHERE idCliente=idCliente_;
	commit;
END
$$;


CREATE OR REPLACE PROCEDURE DeleteCliente(
	idCliente_ int
)
language plpgsql
AS $$
BEGIN
	DELETE FROM cliente WHERE idCliente=idCliente_;
	commit;
END
$$;


--Valida empleado

CREATE OR REPLACE FUNCTION ValidaEmpleado(
	idEmpleado_ int,
	pass_ VARCHAR
)
RETURNS setof empleado
language sql
AS $$
	select idEmpleado,usuario,pass,nombre,apellidos,provincia,canton,distrito from empleado
	where empleado.idEmpleado = idEmpleado_ and empleado.pass = pass_;
$$;


--Valida comercio

CREATE OR REPLACE FUNCTION ValidaComercio(
	idComercio_ int,
	pass_ VARCHAR
)
RETURNS setof comercio
language sql
AS $$
	select idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito from comercio
	where comercio.idComercio = idComercio_ and comercio.pass = pass_;
$$;


--Valida cliente
CREATE OR REPLACE FUNCTION ValidaCliente(
	idCliente_ int,
	pass_ VARCHAR
)
RETURNS setof cliente
language sql
AS $$
	select idCliente,usuario,pass,nombre,apellidos,fechaNac,provincia,canton,distrito from cliente
	where cliente.idCliente = idCliente_ and cliente.pass = pass_;
$$;


-- PRODUCTO, FOTO Y PRECIO
CREATE OR REPLACE FUNCTION Comercio_producto(
	idComercio_ int
)
RETURNS table (Producto VARCHAR, Foto VARCHAR, Precio int)
language sql
AS $$
	select producto, foto, precio from ((Comercio JOIN Producto On Comercio.idComercio = Producto.idComercio) JOIN Producto_Fotos on Producto.nombre = Producto_Fotos.producto)
	where Comercio.idComercio = idComercio_;
$$;

--COMPRAS AFILIADO

CREATE OR REPLACE FUNCTION Comercio_pedidos(
	idComercio_ int
)
RETURNS table (idPedido int, direccion VARCHAR, finalizado BOOLEAN, repartidor VARCHAR, idCliente int)
language sql
AS $$
	select Pedido.idPedido, Pedido.direccion,Pedido.finalizado, Pedido.repartidor,Pedido.idCliente from (((Comercio JOIN Producto On Comercio.idComercio = Producto.idComercio) JOIN Producto_Pedido on Producto.nombre = Producto_Pedido.producto) JOIN Pedido ON Producto_Pedido.idPedido = Pedido.idPedido)
	where Comercio.idComercio = idComercio_ and Pedido.finalizado = FALSE;
$$;



--CALCULA DISTANCIA
CREATE OR REPLACE FUNCTION calcDistancia(
	provincia1 varchar,
	canton1 varchar,
	distrito1 varchar,
	provincia2 varchar,
	canton2 varchar,
	distrito2 varchar
)
RETURNS float4
LANGUAGE plpgsql
AS $$
Declare lat1 float4 := (select lat from direcciones where provincia=provincia1 and canton=canton1 and distrito = distrito1);
Declare lat2 float4 := (select lat from direcciones where provincia=provincia2 and canton=canton2 and distrito = distrito2);
Declare long1 float4 := (select lon from direcciones where provincia=provincia1 and canton=canton1 and distrito = distrito1);
Declare long2 float4 := (select lon from direcciones where provincia=provincia2 and canton=canton2 and distrito = distrito2);
BEGIN
	return (acos((sin(lat1 * 0.01745329) * sin(lat2 * 0.01745329)) + (cos(lat1 * 0.01745329) * cos(lat2 * 0.01745329) * cos((long1 - long2) * 0.01745329)))) * 57.29577951 * 111.302;
END
$$;


--CALCULA REPARTIDORES
CREATE OR REPLACE PROCEDURE Distancia_Repartidores(
	provincia_ varchar,
	canton_ varchar,
	distrito_ varchar	
)
language plpgsql
AS $$
--DECLARE rep repartidor:=(SELECT calcDistancia from calcDistancia(i.provincia,i.canton,i.distrito,provincia_,canton_,distrito_));
--DECLARE rep repartidor:=(SELECT usuario from repartidor where repartidor.disponible=TRUE);

declare i record;
BEGIN
	FOR i IN (SELECT * FROM getrepartidor() WHERE disponible = true) LOOP
			INSERT INTO distancias_repartidores(usuario, distancia)
			VALUES (i.usuario, (SELECT calcDistancia from calcDistancia(i.provincia,i.canton,i.distrito,provincia_,canton_,distrito_))); 
		END LOOP;
	commit;
END
$$;



--ASIGNA REPARTIDORES
CREATE OR REPLACE PROCEDURE Asigna_Repartidor(
	idComercio_ int,
	idPedido_ int
)
language plpgsql
AS $$
	DECLARE provincia_ varchar = (SELECT Provincia FROM Comercio WHERE idComercio = idComercio_);
	DECLARE canton_ varchar = (SELECT Canton FROM Comercio WHERE idComercio = idComercio_);
	DECLARE distrito_ varchar = (SELECT Distrito FROM Comercio WHERE idComercio = idComercio_);
BEGIN
	DELETE FROM distancias_repartidores;
	CALL Distancia_Repartidores(provincia_,canton_,distrito_);
	UPDATE Pedido SET finalizado = 'En Curso', repartidor =(SELECT usuario FROM distancias_repartidores ORDER BY distancias_repartidores.distancia ASC LIMIT 1) WHERE idPedido=idPedido_;
	UPDATE repartidor SET disponible = False WHERE usuario = (SELECT usuario FROM distancias_repartidores ORDER BY distancias_repartidores.distancia ASC LIMIT 1);
	
	commit;
END
$$;




SELECT * from repartidor;
SELECT * from getcomercio();
SELECT * from getpedido();

CALL Asigna_Repartidor(123, 3);


DELETE FROM distancias_repartidores;

SELECT usuario, min(distancia) FROM distancias_repartidores GROUP BY usuario, distancia;

SELECT * FROM distancias_repartidores ORDER BY distancias_repartidores.distancia ASC LIMIT 1;

CALL addrepartidor('pedri','123','PEDRO','Montero',True,'Guanacaste','Santa Cruz','Tempate')






--AUX


-- SELECT * FROM getCliente_telefonos();
SELECT * FROM getCliente();
-- CALL DeleteCliente(4555);

CALL AddCliente(5555,'MongeF','123','pEDRITO','MR','2001-12-13','Cartago','Guarco','Tobosi');

-- CALL AddCliente_Telefonos(4555,7777);



-- SELECT * FROM getRepartidor_telefonos();

-- CALL AddRepartidor('fmonge','123','fer','monge',TRUE, 'c','c','t');
-- CALL AddRepartidor_Telefonos('fmonge', 133548);
-- CALL DeleteRepartidor('fmonge');

-- CALL AddEmpleado(333,'123','fer','monge','fer', 'c','c','t');
-- CALL AddEmpleado_Telefonos(333, 505050);
-- SELECT * FROM getEmpleado_telefonos();
-- CALL DeleteEmpleado(333);


-- SELECT * FROM getAdmin_Comercio();
-- CALL AddAdmin_Comercio(333,'fer','13','monge','fer','@', 'c','c','t',58);

call AddComercio(999,'sfs','1','KFC','gdgerg',52545,TRUE,'cartago','central','centro')
call AddComercio(888,'sfs','1','BK','gdgerg',52545,TRUE,'cartago','central','centro')

CALL AddProducto('papasfritas',1000,'a',999);

-- CALL AddProducto_Fotos('arroz','aaaa');
CALL AddProducto_Pedido(8,'bur',68);

-- CALL DeleteProducto('arroz');

-- SELECT * FROM GetProducto();
-- SELECT * FROM GetProducto_Pedido();
-- SELECT * FROM GetProducto_Fotos();


CALL AddPedido(8,'cartago',True,'fmonge', 5555);

Select * from getadmin_comercio();

Call deletecomercio(7687);



