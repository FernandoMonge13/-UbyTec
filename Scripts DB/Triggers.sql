--TRIGGER REPARTIDOR TELEFONOS
CREATE OR REPLACE FUNCTION tr_repartidor()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM repartidor_telefonos WHERE usuarioRep=OLD.usuario;
	RETURN OLD;
END
$$;

CREATE TRIGGER trigger_repartidor BEFORE DELETE ON repartidor
FOR EACH ROW EXECUTE PROCEDURE tr_repartidor();


--TRIGGER EMPLEADO TELEFONOS
CREATE OR REPLACE FUNCTION tr_empleado()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM empleado_telefonos WHERE idEmpleado=OLD.idEmpleado;
	RETURN OLD;
END
$$;

CREATE TRIGGER trigger_empleado BEFORE DELETE ON empleado
FOR EACH ROW EXECUTE PROCEDURE tr_empleado();

--TRIGGER ADMIN COMER TELEFONOS
CREATE OR REPLACE FUNCTION tr_admin_comercio()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM admin_comer_telefonos WHERE idAdmin=OLD.idAdmin;
	RETURN OLD;
END
$$;

CREATE TRIGGER trigger_admin_comercio BEFORE DELETE ON admin_comercio
FOR EACH ROW EXECUTE PROCEDURE tr_admin_comercio();


--TRIGGER COMERCIO TELEFONOS
CREATE OR REPLACE FUNCTION tr_comercio()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM comercio_telefonos WHERE idComercio=OLD.idComercio;
	DELETE FROM producto WHERE idComercio=OLD.idComercio;
	DELETE FROM admin_comercio WHERE idComercio=OLD.idComercio;
	RETURN OLD;
END
$$;

CREATE TRIGGER trigger_comercio BEFORE DELETE ON comercio
FOR EACH ROW EXECUTE PROCEDURE tr_comercio();

--TRIGGER PRODUCTO FOTOS Y PRODUCTO PEDIDO
CREATE OR REPLACE FUNCTION tr_producto()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM producto_fotos WHERE producto=OLD.nombre;
	DELETE FROM producto_pedido WHERE producto=OLD.nombre;
	RETURN OLD;
	
END
$$;

CREATE TRIGGER trigger_producto BEFORE DELETE ON Producto
FOR EACH ROW EXECUTE PROCEDURE tr_producto();

--TRIGGER CLIENTE TELEFONOS, ADMIN COMERCIO
CREATE OR REPLACE FUNCTION tr_cliente()
RETURNS TRIGGER
language plpgsql
AS $$
BEGIN
	DELETE FROM cliente_telefonos WHERE idCliente=OLD.idCliente;
	RETURN OLD;
	
END
$$;
CREATE TRIGGER trigger_cliente BEFORE DELETE ON Cliente
FOR EACH ROW EXECUTE PROCEDURE tr_cliente();
