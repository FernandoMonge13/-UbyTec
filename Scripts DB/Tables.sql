CREATE TABLE REPARTIDOR_TELEFONOS(
	usuarioRep VARCHAR(20) not null,
	telefono int not null
);

CREATE TABLE REPARTIDOR(
	usuario VARCHAR(20) not null,
	pass VARCHAR(20) not null,
	nombre VARCHAR(20) not null,
	apellidos VARCHAR(30) not null,
	disponible BOOLEAN not null,
	provincia VARCHAR(20) not null,
	canton VARCHAR(20) not null,
	distrito VARCHAR(20) not null,
	correo VARCHAR(40) NOT NULL
);

CREATE TABLE EMPLEADO_TELEFONOS(
	idEmpleado int not null,
	telefono int not null
);

CREATE TABLE EMPLEADO(
	idEmpleado int not null,
	usuario VARCHAR(20) not null,
	pass VARCHAR(20) not null,
	nombre VARCHAR(20) not null,
	apellidos VARCHAR(30) not null,
	provincia VARCHAR(20) not null,
	canton VARCHAR(20) not null,
	distrito VARCHAR(20) not null
);

CREATE TABLE ADMIN_COMER_TELEFONOS(
	idAdmin int not null,
	telefono int not null
);

CREATE TABLE ADMIN_COMERCIO(
	idAdmin int not null,
	idComercio int not null,
	usuario VARCHAR(20) not null,
	pass VARCHAR(20) not null,
	nombre VARCHAR(20) not null,
	apellidos VARCHAR(30) not null,
	correo VARCHAR(20) not null,
	provincia VARCHAR(20) not null,
	canton VARCHAR(20) not null,
	distrito VARCHAR(20) not null
);

CREATE TABLE COMERCIO(
	idComercio int not null,
	pass VARCHAR(20) not null,
	tipo VARCHAR(20) not null,
	nombre VARCHAR(20) not null,
	correo VARCHAR(20) not null,
	sinpe int not null,
	solicitud BOOLEAN not null,
	provincia VARCHAR(20) not null,
	canton VARCHAR(20) not null,
	distrito VARCHAR(20) not null
);

CREATE TABLE COMERCIO_TELEFONOS(
	idComercio int not null,
	telefono int not null
);

CREATE TABLE PRODUCTO_FOTOS(
	producto VARCHAR(20) not null,
	foto TEXT not null
);

CREATE TABLE PRODUCTO(
	nombre VARCHAR(20) not null,
	precio int not null,
	categoria VARCHAR(20) not null,
	idComercio int not null
);

CREATE TABLE PRODUCTO_PEDIDO(
	idPedido int not null,
	producto VARCHAR(20) not null,
	cantidad int not null
);

CREATE TABLE PEDIDO(
	idPedido int not null,
	direccion VARCHAR(20) not null,
	finalizado VARCHAR(20) not null,
	repartidor VARCHAR(20) not null,
	idCliente int not null,
	comprobante VARCHAR(40) not null,
);



CREATE TABLE CLIENTE_TELEFONOS(
	idCliente int not null,
	telefono int not null
);

CREATE TABLE CLIENTE(
	idCliente int not null,
	usuario VARCHAR(20) not null,
	pass VARCHAR(20) not null,
	nombre VARCHAR(20) not null,
	apellidos VARCHAR(30) not null,
	fechaNac VARCHAR(20) not null,
	provincia VARCHAR(20) not null,
	canton VARCHAR(20) not null,
	distrito VARCHAR(20) not null
);

CREATE TABLE DIRECCIONES(
	provincia varchar(20),
	canton varchar(30),
	distrito varchar(40),
	lat float4,
	lon float4
);

CREATE TABLE DISTANCIAS_REPARTIDORES(
	usuario VARCHAR not null,
	distancia FLOAT4
);

ALTER TABLE DIRECCIONES
ADD PRIMARY KEY(provincia,canton,distrito);

ALTER TABLE REPARTIDOR_TELEFONOS
ADD PRIMARY KEY (usuarioRep, telefono);

ALTER TABLE REPARTIDOR
ADD PRIMARY KEY (usuario);

ALTER TABLE EMPLEADO_TELEFONOS
ADD PRIMARY KEY (idEmpleado, telefono);

ALTER TABLE EMPLEADO
ADD PRIMARY KEY (idEmpleado);

ALTER TABLE ADMIN_COMER_TELEFONOS
ADD PRIMARY KEY (idAdmin,telefono);

ALTER TABLE ADMIN_COMERCIO
ADD PRIMARY KEY (idAdmin);

ALTER TABLE COMERCIO_TELEFONOS
ADD PRIMARY KEY (idComercio,telefono);

ALTER TABLE COMERCIO
ADD PRIMARY KEY (idComercio);

ALTER TABLE PRODUCTO_FOTOS
ADD PRIMARY KEY (producto, foto);

ALTER TABLE PRODUCTO
ADD PRIMARY KEY (nombre);

ALTER TABLE PRODUCTO_PEDIDO
ADD PRIMARY KEY (idPedido, producto);

ALTER TABLE PEDIDO
ADD PRIMARY KEY (idPedido);

ALTER TABLE CLIENTE_TELEFONOS
ADD PRIMARY KEY (idCliente,telefono);

ALTER TABLE CLIENTE
ADD PRIMARY KEY (idCliente);



ALTER TABLE REPARTIDOR_TELEFONOS
ADD FOREIGN KEY (usuarioRep) REFERENCES REPARTIDOR(usuario);

ALTER TABLE EMPLEADO_TELEFONOS
ADD FOREIGN KEY (idEmpleado) REFERENCES EMPLEADO(idEmpleado);

ALTER TABLE ADMIN_COMERCIO
ADD FOREIGN KEY(idComercio) REFERENCES COMERCIO(idComercio)

ALTER TABLE ADMIN_COMER_TELEFONOS
ADD FOREIGN KEY (idAdmin) REFERENCES ADMIN_COMERCIO(idAdmin);

ALTER TABLE COMERCIO_TELEFONOS
ADD FOREIGN KEY (idComercio) REFERENCES COMERCIO(idComercio);

ALTER TABLE PRODUCTO_FOTOS
ADD FOREIGN KEY (producto) REFERENCES PRODUCTO(nombre);

ALTER TABLE PRODUCTO
ADD FOREIGN KEY (idComercio) REFERENCES COMERCIO(idComercio);

ALTER TABLE PRODUCTO_PEDIDO
ADD FOREIGN KEY (producto) REFERENCES PRODUCTO(nombre),
ADD FOREIGN KEY (idPedido) REFERENCES PEDIDO(idPedido);

ALTER TABLE PEDIDO
ADD FOREIGN KEY (repartidor) REFERENCES REPARTIDOR(usuario),
ADD FOREIGN KEY (idCliente) REFERENCES CLIENTE(idCliente);

ALTER TABLE CLIENTE_TELEFONOS
ADD FOREIGN KEY (idCliente) REFERENCES CLIENTE(idCliente);
