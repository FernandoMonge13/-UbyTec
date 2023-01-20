Drop  FUNCTION calcDistancia(
	lat1 float4,
	long1 float4,
	lat2 float4,
	long2 float4
);

DROP FUNCTION calcdistancia(character varying,character varying,character varying,character varying,character varying,character varying)

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
select * from producto_fotos;
select * from direcciones;
select * from calcDistancia('San Jose','Tarrazu','San Marcos','Cartago','Cartago','Oriental')