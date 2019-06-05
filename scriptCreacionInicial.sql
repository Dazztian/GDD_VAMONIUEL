USE [GD1C2019]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'VAMONIUEL')
BEGIN
EXEC ('CREATE SCHEMA [VAMONIUEL] AUTHORIZATION [gdCruceros2019]')
END



CREATE TABLE VAMONIUEL.[Rol](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Habilitado] [bit] default 1
);	


CREATE TABLE VAMONIUEL.[Funcion](
	[ID] [int] NOT NULL PRIMARY KEY ,
	[nombre] [nvarchar](50) NOT NULL,
);

CREATE TABLE VAMONIUEL.[Rol_X_Funcion](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_Rol] [int] not null,
	[ID_Funcion] [int] not null,
	CONSTRAINT FK_RolXFuncion_Rol FOREIGN KEY (ID_Rol) REFERENCES VAMONIUEL.[Rol](ID),
	CONSTRAINT FK_RolXFuncion_Funcion FOREIGN KEY (ID_Funcion) REFERENCES VAMONIUEL.[Funcion](ID)
);

CREATE TABLE VAMONIUEL.[Usuario](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [binary](32) NOT NULL,
	[cant_accesos_fallidos] int default 0,
	[habilitado] [bit] default 1,
	[contrasena_autogenerada] [bit] default 0,
);


CREATE TABLE VAMONIUEL.[Rol_X_Usuario](
  	ID_ROL int,
  	ID_Usuario int,
	PRIMARY KEY(ID_ROL, ID_USUARIO),
  	CONSTRAINT FK_Rol_X_Usuario FOREIGN KEY (ID_Rol) REFERENCES VAMONIUEL.Rol(ID),
	CONSTRAINT FK_Usuario_X_Rol FOREIGN KEY(ID_Usuario) REFERENCES VAMONIUEL.Usuario(ID)
);

CREATE TABLE [VAMONIUEL].[CLIENTE]	
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CLI_NOMBRE] [nvarchar](255) NULL,
	[CLI_APELLIDO] [nvarchar](255) NULL,
	[CLI_DNI] [decimal](18, 0) NULL,
	[CLI_DIRECCION] [nvarchar](255) NULL,
	[CLI_TELEFONO] [int] NULL,
	[CLI_MAIL] [nvarchar](255) NULL,
	[CLI_FECHA_NAC] [datetime2](3) NULL,
	id_usuario int  null,
	CONSTRAINT FK_Cliente_usuario FOREIGN KEY (id_usuario) REFERENCES VAMONIUEL.Usuario(ID)
);

CREATE TABLE [VAMONIUEL].[PASAJE]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[PASAJE_CODIGO] [decimal](18, 0) NULL,
	[PASAJE_PRECIO] [decimal](18, 2) NULL,
	[PASAJE_FECHA_COMPRA] [datetime2](3) NULL,
	[FECHA_SALIDA] [datetime2](3) NULL,
	[FECHA_LLEGADA] [datetime2](3) NULL,
	[FECHA_LLEGADA_ESTIMADA] [datetime2](3) NULL,
	ID_Cliente int not null,
	CONSTRAINT FK_Pasaje_Cliente FOREIGN KEY (ID_Cliente) REFERENCES VAMONIUEL.[Cliente](ID)			
);

CREATE TABLE [VAMONIUEL].[CRUCERO]
(	
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CRU_FABRICANTE] [nvarchar](255) NULL,
	[CRUCERO_MODELO] [nvarchar](50) NULL,
	[CRUCERO_IDENTIFICADOR] [nvarchar](50) NULL	
);


CREATE TABLE [VAMONIUEL].[RECORRIDO]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RECORRIDO_CODIGO] [decimal](18, 0) NULL,
	[PUERTO_DESDE] [nvarchar](255) NULL,
	[PUERTO_HASTA] [nvarchar](255) NULL	
);

CREATE TABLE [VAMONIUEL].[VIAJE]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	Origen [nvarchar](255) not null,
	Destino [nvarchar](255) not null,
	FechaInicio [datetime2](3) not null,
	FechaFin [datetime2](3) not null,
	[CRUCERO_IDENTIFICADOR] [nvarchar](50)not NULL, -- Es como el id de crucero xq no se repite y no deberia
	ID_Pasaje int  null,
	ID_Crucero	 int  null,
	ID_Recorrido int  null,
	CONSTRAINT FK_Viaje_Recorrido FOREIGN KEY (ID_Recorrido) REFERENCES VAMONIUEL.[Recorrido](ID),	
	CONSTRAINT FK_Viaje_Pasaje FOREIGN KEY (ID_Pasaje) REFERENCES VAMONIUEL.[Pasaje](ID),			
	CONSTRAINT FK_Viaje_Crucero FOREIGN KEY (ID_Crucero) REFERENCES VAMONIUEL.[Crucero](ID)			
);


CREATE TABLE [VAMONIUEL].Tramo
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[PUERTO_DESDE] [nvarchar](255) NULL,
	[PUERTO_HASTA] [nvarchar](255) NULL,
	[RECORRIDO_PRECIO_BASE] [decimal](18, 2) NULL,
)

CREATE TABLE [VAMONIUEL].[ViajeXRecorrido]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Viaje int not null,
	ID_Recorrido int not null,
	orden int  not null,
	CONSTRAINT FK_ViajeXRecorrido_Viaje FOREIGN KEY (ID_Viaje) REFERENCES VAMONIUEL.[Viaje](ID),			
	CONSTRAINT FK_ViajeXRecorrido_Recorrido FOREIGN KEY (ID_Recorrido) REFERENCES VAMONIUEL.[RECORRIDO](ID)			
);


CREATE TABLE [VAMONIUEL].[Puerto]
(	
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](255) NULL,
	[Habilitado] bit DEFAULT 1
);

CREATE TABLE [VAMONIUEL].[TramoXPuerto]
(	
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	id_tramo int not null,
	id_puerto int not null,
	CONSTRAINT FK_tramoXPuerto_tramo FOREIGN KEY (id_tramo) REFERENCES VAMONIUEL.Tramo(ID),			
	CONSTRAINT FK_tramoXPuerto_puerto FOREIGN KEY (id_puerto) REFERENCES VAMONIUEL.Puerto(ID)	
)


CREATE TABLE [VAMONIUEL].[RecorridoXViaje]
(
	ID INT NOT NULL,
	ID_Recorrido int not null,
	ID_Puerto int not null,
	CONSTRAINT FK_RecorridoXViaje_Recorrido FOREIGN KEY (ID_Recorrido) REFERENCES VAMONIUEL.[Recorrido](ID),			
	CONSTRAINT FK_RecorridoXViaje_PuertoFOREIGN FOREIGN KEY (ID_Puerto) REFERENCES VAMONIUEL.[Puerto](ID)	
);

CREATE TABLE [VAMONIUEL].[TramoXRecorrido]
(	
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	id_recorrido int not null,
	id_tramo int not null,
	CONSTRAINT FK_tramoXRecorrido_tramo FOREIGN KEY (id_tramo) REFERENCES VAMONIUEL.Tramo(ID),			
	CONSTRAINT FK_tramoXRecorrido_recorrido FOREIGN KEY (id_recorrido) REFERENCES VAMONIUEL.Recorrido(ID)	
)

CREATE TABLE [VAMONIUEL].[CABINA]
(
	[CABINA_NRO] [decimal](18, 0) NULL,
	[CABINA_PISO] [decimal](18, 0) NULL,
	[CABINA_TIPO] [nvarchar](255) NULL,
	[CABINA_TIPO_PORC_RECARGO] [decimal](18, 2) NULL,	
	ID_Crucero int  null,
	CONSTRAINT FK_Cabina_Crucero FOREIGN KEY (ID_Crucero) REFERENCES VAMONIUEL.[Crucero](ID)		
);

CREATE TABLE [VAMONIUEL].[RESERVA]
(

	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RESERVA_CODIGO] [decimal](18, 0) NULL,
	[RESERVA_FECHA] [datetime2](3) NULL,
	ID_Pasaje int  null,
	CONSTRAINT FK_Reserva_Pasaje FOREIGN KEY (ID_Pasaje) REFERENCES VAMONIUEL.[Pasaje](ID)	
);
--------------------------------------------------------------------------- INSERTS DE VALORES GENERICOS ------------------------------------------------------------------------------------------------

INSERT INTO VAMONIUEL.[Usuario]([Usuario],[Contrasenia],habilitado) 
VALUES ('admin',HASHBYTES('SHA2_256', N'w23e'),1)

INSERT INTO VAMONIUEL.[Rol] ([Nombre])
VALUES ('Empresa'),('Administrativo'),('Cliente')

--Esto hay que actualizarlo segun este TP
INSERT INTO [VAMONIUEL].[Funcion] 
VALUES (1, 'ABM Cliente'),(2,'ABM Empresa Espectaculo'),
(3,'ABM Grado'),(4, 'Canje de Puntos'), (5, 'Comprar')
, (6, 'Editar Publicacion'), (7, 'Generar Publicacion')
, (8, 'Generar Rendicion de Comisiones'), (9, 'Historial de Compras de Cliente')
, (10, 'Listado Estadistico'), (11, 'ABM Rol')

INSERT INTO VAMONIUEL.[Rol_X_Funcion]   ([ID_ROL],ID_Funcion)
VALUES (2,3),(2,2),(2,1),(2,4),(2,5),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(3,5),(3,9),(3,4),(1,6),(1,7)

-------------------------------------------------------- TRIGGERS -------------------------------------------------------------------------------
go
CREATE TRIGGER tr_creacion_tramoxpuerto ON VAMONIUEL.TRAMO
AFTER INSERT
AS 
BEGIN	
	--VARIABLES RELACIONADAS AL TRAMO
	
DECLARE @PUERTO_DESDE nvarchar(255)
DECLARE @PUERTO_HASTA nvarchar(255)
DECLARE @RECORRIDO_PRECIO_BASE decimal(18,2)
	--VARIABLES RELACIONADAS AL TRAMOXPUERTO
	DECLARE @ID_Tramo int
	DECLARE @ID_PUERTO_DESDE int
	DECLARE @ID_PUERTO_HASTA int

	--VARIABLES RELACIONADAS AL PUERTO

	--OBTENGO LOS DATOS ASOCIADOS A CADA INSERCION DE TRAMO
	DECLARE obtenerDatos CURSOR FOR

  SELECT I.ID, P1.ID, P2.ID
	FROM VAMONIUEL.Tramo I
	LEFT JOIN VAMONIUEL.Puerto P1 ON I.PUERTO_DESDE= P1.Nombre --Origen
	LEFT JOIN VAMONIUEL.Puerto P2 ON I.PUERTO_HASTA = P2.Nombre --Destino

	OPEN obtenerDatos
	FETCH NEXT FROM obtenerDatos INTO @ID_Tramo, @ID_PUERTO_DESDE, @ID_PUERTO_HASTA

	WHILE @@FETCH_STATUS=0
	BEGIN
		--HAGO 2 INSERTS EN LA TABLA TRAMOXPUERTO,
		--UNO PARA INDICAR EL ORIGEN Y OTRA PARA DESTINO
		BEGIN
		INSERT INTO [VAMONIUEL].[TramoXPuerto] ([id_tramo],[id_puerto])
		VALUES   (@ID_Tramo, @ID_PUERTO_DESDE)
	
		INSERT INTO [VAMONIUEL].[TramoXPuerto] ([id_tramo],[id_puerto])
		VALUES   (@ID_Tramo,  @ID_PUERTO_HASTA)

		END
	
	FETCH NEXT FROM obtenerDatos INTO @ID_Tramo, @ID_PUERTO_DESDE, @ID_PUERTO_HASTA
	END
	CLOSE obtenerDatos
	DEALLOCATE obtenerDatos

END
GO	

------------------------------------------------ tr_creacion_recorridoxtramo ----------------------------------------------------
--ESTE TRIGGER TIENE SENTIDO SER INVOCADO SOLO EN LA MIGRACION, X ESO LO DESTRUYO TERMINADA LA MIGRACION
go
CREATE TRIGGER tr_creacion_recorridoxtramo ON VAMONIUEL.TRAMO
AFTER INSERT
AS 
BEGIN	
	--VARIABLES RELACIONADAS AL RECORRIDOXTRAMO
	DECLARE @ID_Tramo int
	DECLARE @ID_Recorrido int

	DECLARE obtenerDatos CURSOR FOR
	SELECT I.ID, R.ID
	FROM inserted I
	LEFT JOIN VAMONIUEL.RECORRIDO R ON ( I.PUERTO_DESDE= R.PUERTO_DESDE AND I.PUERTO_HASTA= R.PUERTO_HASTA )

	OPEN obtenerDatos
	FETCH NEXT FROM obtenerDatos INTO @ID_Tramo, @ID_Recorrido

	WHILE @@FETCH_STATUS=0
	BEGIN
		--INSERTO EN LA TABLA INTERMEDIA
		BEGIN	
		INSERT INTO [VAMONIUEL].[TramoXRecorrido] ([id_recorrido],[id_tramo])
		VALUES  (@ID_Tramo, @ID_Recorrido)

		END
	
	FETCH NEXT FROM obtenerDatos INTO @ID_Tramo, @ID_Recorrido
	END
	CLOSE obtenerDatos
	DEALLOCATE obtenerDatos

END
GO	

------------------------------------------------ tr_creacion_pasajeATravesDeCreacionReservas----------------------------------------------------

go--Creo los pasajes asociados a las reservas
CREATE TRIGGER tr_creacion_pasajeTemporalesATravesDeCreacionReservas ON VAMONIUEL.RESERVA
AFTER INSERT
AS 
BEGIN	
	--VARIABLES RELACIONADAS AL PASAJE Y LA RESERVA
	DECLARE @RESERVA_CODIGO decimal(18,0)
	DECLARE @RESERVA_FECHA datetime2(3)
	DECLARE @ID_Pasaje INT
	DECLARE @FECHA_SALIDA datetime2(3)
	DECLARE @FECHA_LLEGADA datetime2(3)
	DECLARE @FECHA_LLEGADA_ESTIMADA datetime2(3)
	DECLARE @PASAJE_CODIGO decimal(18,0)

	DECLARE obtenerDatos CURSOR FOR
	SELECT I.[RESERVA_CODIGO],I.[RESERVA_FECHA], I.ID_PASAJE, M.[FECHA_SALIDA],M.[FECHA_LLEGADA],M.[FECHA_LLEGADA_ESTIMADA]
	FROM inserted I
	LEFT JOIN gd_esquema.Maestra M ON ( I.RESERVA_CODIGO = M.[RESERVA_CODIGO] AND I.[RESERVA_FECHA]=  M.[RESERVA_FECHA])

	OPEN obtenerDatos
	FETCH NEXT FROM obtenerDatos INTO @RESERVA_CODIGO, @RESERVA_FECHA, @ID_Pasaje, @FECHA_SALIDA, @FECHA_LLEGADA, @FECHA_LLEGADA_ESTIMADA

	WHILE @@FETCH_STATUS=0
	BEGIN
		--1)INSERTO EN PASAJE
		--2)INSERTO EN RESERVA
		BEGIN	
		SET @PASAJE_CODIGO=@RESERVA_CODIGO+1

		if(@ID_Pasaje is null)
		begin

		INSERT INTO [VAMONIUEL].[PASAJE]([PASAJE_CODIGO],[FECHA_SALIDA],[FECHA_LLEGADA],[FECHA_LLEGADA_ESTIMADA],[ID_Cliente])
		VALUES (@PASAJE_CODIGO,@FECHA_SALIDA, @FECHA_LLEGADA, @FECHA_LLEGADA_ESTIMADA, 1)--ACA TIENE EL USER HARDCODEADO, TA MAL

		--insert into VAMONIUEL.RESERVA ([RESERVA_CODIGO],[RESERVA_FECHA],[ID_Pasaje])
		--VALUES (@RESERVA_CODIGO, @RESERVA_FECHA, 
		--(select top 1 id from VAMONIUEL.PASAJE where PASAJE_CODIGO=@PASAJE_CODIGO))
		end
		--UPDATE [VAMONIUEL].[RESERVA]
		--SET [ID_Pasaje] = 33333--@ID_Pasaje
		--WHERE [RESERVA_CODIGO] = @PASAJE_CODIGO-1
		--and RESERVA_CODIGO is not null
		
		END
		FETCH NEXT FROM obtenerDatos INTO @RESERVA_CODIGO, @RESERVA_FECHA, @ID_Pasaje, @FECHA_SALIDA, @FECHA_LLEGADA, @FECHA_LLEGADA_ESTIMADA
	
	END
	--UPDATE [VAMONIUEL].[RESERVA]
	--	SET [ID_Pasaje] = 33333--@ID_Pasaje
	CLOSE obtenerDatos
	DEALLOCATE obtenerDatos

END
GO	

--DROP PROCEDURE sp_vinculacion_pasajeTemporalConReservas
------------------------------------------------ sp_vinculacion_pasajeTemporalConReservas----------------------------------------------------
/*
go --Con este procedure pretendo a todas las reservas asociarle su id pasaje
CREATE PROCEDURE sp_vinculacion_pasajeTemporalConReservas 
AS 
BEGIN	
	--VARIABLES RELACIONADAS AL PASAJE Y LA RESERVA	
	DECLARE @PASAJE_CODIGO decimal(18,0)
	DECLARE @ID_Pasaje INT

	DECLARE obtenerDatosTR CURSOR FOR
	SELECT  I.ID, I.PASAJE_CODIGO
	FROM VAMONIUEL.PASAJE I
	LEFT JOIN VAMONIUEL.RESERVA R ON ( I.PASAJE_CODIGO = R.[RESERVA_CODIGO]-1)
	WHERE I.PASAJE_PRECIO IS NULL AND I.PASAJE_FECHA_COMPRA IS NULL

	OPEN obtenerDatosTR
	FETCH NEXT FROM obtenerDatosTR INTO @ID_Pasaje, @PASAJE_CODIGO

	WHILE @@FETCH_STATUS=0
	BEGIN
		--ESTA VERGA ME LOOPEA EL TRIGGER
		UPDATE [VAMONIUEL].[RESERVA]
		SET [ID_Pasaje] = @ID_Pasaje
		WHERE [RESERVA_CODIGO] = @PASAJE_CODIGO-1
		and RESERVA_CODIGO is not null
	
		FETCH NEXT FROM obtenerDatosTR INTO @ID_Pasaje, @PASAJE_CODIGO
	END
	CLOSE obtenerDatosTR
	DEALLOCATE obtenerDatosTR

END
GO	
*/
------------------------------------------- INICIO  MIGRACION ----------------------------------------------------------------------------------------------------
 INSERT INTO VAMONIUEL.[Cliente]
(	[CLI_NOMBRE],[CLI_APELLIDO],[CLI_DNI],[CLI_DIRECCION],[CLI_TELEFONO],[CLI_MAIL],[CLI_FECHA_NAC])--, [ID_Usuario])
select  distinct[CLI_NOMBRE],[CLI_APELLIDO],[CLI_DNI],[CLI_DIRECCION] ,[CLI_TELEFONO],[CLI_MAIL],[CLI_FECHA_NAC]
-- ,(select ID from ESKHERE.Usuario where CAST([Cli_Dni] as nvarchar(50)) = Usuario)
from gd_esquema.Maestra
where [Cli_Dni]  IS NOT NULL

INSERT INTO [VAMONIUEL].[CRUCERO]
 ([CRU_FABRICANTE],[CRUCERO_MODELO],[CRUCERO_IDENTIFICADOR])
 select  distinct [CRU_FABRICANTE] ,[CRUCERO_MODELO],[CRUCERO_IDENTIFICADOR]
from gd_esquema.Maestra

delete from VAMONIUEL.CABINA
/* ESTA EN EVALUACION AUN*/
INSERT INTO [VAMONIUEL].[CABINA] ([CABINA_NRO],[CABINA_PISO],[CABINA_TIPO],[CABINA_TIPO_PORC_RECARGO],[ID_Crucero])
select  distinct [CABINA_NRO],[CABINA_PISO],[CABINA_TIPO],[CABINA_TIPO_PORC_RECARGO],C.ID
from gd_esquema.Maestra M 
LEFT JOIN VAMONIUEL.CRUCERO C ON	(M.CRU_FABRICANTE= C.CRU_FABRICANTE 
						AND M.CRUCERO_IDENTIFICADOR = C.CRUCERO_IDENTIFICADOR 
						AND M.CRUCERO_MODELO = C.CRUCERO_MODELO)

--Devuelve correctamente
/*
SELECT id FROM VAMONIUEL.CRUCERO C LEFT JOIN gd_esquema.Maestra M ON  M.CRU_FABRICANTE= C.CRU_FABRICANTE 
								    AND M.CRUCERO_IDENTIFICADOR = C.CRUCERO_IDENTIFICADOR 
									AND M.CRUCERO_MODELO = C.CRUCERO_MODELO*/

INSERT INTO [VAMONIUEL].[Puerto]([Nombre])
select  distinct [PUERTO_DESDE]
from gd_esquema.Maestra
--Pareceria que no hace falta esto, pero x las dudas...
INSERT INTO [VAMONIUEL].[Puerto]([Nombre])
select  distinct [PUERTO_HASTA]
from gd_esquema.Maestra
WHERE [PUERTO_HASTA] NOT IN (select  distinct [PUERTO_DESDE] from gd_esquema.Maestra)

INSERT INTO [VAMONIUEL].[RECORRIDO]([RECORRIDO_CODIGO] ,[PUERTO_DESDE],[PUERTO_HASTA])
select  distinct [RECORRIDO_CODIGO],[PUERTO_DESDE],[PUERTO_HASTA]
from gd_esquema.Maestra


--Cada vez que inserto un tramo ejecuto un trigger que me insertara en la tabla intermedia TramoXPuerto, los puerto de origen y destino
--La insercion en tramoxpuerto esta solucionada x el trigger
INSERT INTO [VAMONIUEL].[Tramo]
 ([PUERTO_DESDE] ,[PUERTO_HASTA],[RECORRIDO_PRECIO_BASE])
select  distinct [PUERTO_DESDE],[PUERTO_HASTA], [RECORRIDO_PRECIO_BASE]
from gd_esquema.Maestra

INSERT INTO [VAMONIUEL].[PASAJE] 
([PASAJE_CODIGO],[PASAJE_PRECIO],[PASAJE_FECHA_COMPRA],[FECHA_SALIDA],[FECHA_LLEGADA],[FECHA_LLEGADA_ESTIMADA],[ID_Cliente])
SELECT DISTINCT[PASAJE_CODIGO],[PASAJE_PRECIO],[PASAJE_FECHA_COMPRA],[FECHA_SALIDA],[FECHA_LLEGADA],[FECHA_LLEGADA_ESTIMADA], C.ID
FROM gd_esquema.Maestra M
LEFT JOIN VAMONIUEL.CLIENTE C ON (M.[CLI_NOMBRE] = C.[CLI_NOMBRE]
      AND M.[CLI_APELLIDO] = c.[CLI_APELLIDO]
      AND M.[CLI_DNI] = c.[CLI_DNI]
      AND M.[CLI_DIRECCION] = c.[CLI_DIRECCION]
      AND M.[CLI_TELEFONO] = c.[CLI_TELEFONO]
      AND M.[CLI_MAIL] = c.[CLI_MAIL]
      AND M.[CLI_FECHA_NAC] = c.[CLI_FECHA_NAC])
--Sacandole esta condicion hago insercion incluso de aquellas que me representan las reservas
WHERE [PASAJE_CODIGO] IS NOT NULL
      AND [PASAJE_PRECIO] IS NOT NULL
      AND [PASAJE_FECHA_COMPRA] IS NOT NULL

--Cada vez que cargue una reserva se va a ejecutar un trigger que me va a generar un 'pasaje temporal'

--Esto funca sin insertar el id_pasaje
INSERT INTO [VAMONIUEL].[RESERVA]
([RESERVA_CODIGO],[RESERVA_FECHA])
SELECT DISTINCT M.[RESERVA_CODIGO],M.[RESERVA_FECHA]
FROM gd_esquema.Maestra M

--Esto NO funca queriendo insertar el id_pasaje
/*INSERT INTO [VAMONIUEL].[RESERVA]
([RESERVA_CODIGO],[RESERVA_FECHA], ID_Pasaje)
SELECT DISTINCT M.[RESERVA_CODIGO],M.[RESERVA_FECHA], P.ID
FROM gd_esquema.Maestra M JOIN VAMONIUEL.PASAJE P ON (
      M.[FECHA_SALIDA] = P.[FECHA_SALIDA] AND
      M.[FECHA_LLEGADA] = P.[FECHA_LLEGADA] AND
      M.[FECHA_LLEGADA_ESTIMADA] =P.[FECHA_LLEGADA_ESTIMADA] AND
	  P.ID_Cliente= (select  CLI.ID FROM VAMONIUEL.CLIENTE CLI WHERE M.CLI_APELLIDO=CLI.CLI_APELLIDO AND M.[CLI_DNI]=CLI.[CLI_DNI] AND M.[CLI_DIRECCION]= CLI.[CLI_DIRECCION] AND M.[CLI_TELEFONO]= CLI.[CLI_TELEFONO] AND M.[CLI_MAIL]= CLI.[CLI_MAIL] AND M.[CLI_FECHA_NAC]= CLI.[CLI_FECHA_NAC])
	  AND  M.PASAJE_CODIGO IS NULL)
WHERE [RESERVA_CODIGO] IS NOT NULL 
	AND [RESERVA_FECHA] IS NOT NULL
	*/

delete from VAMONIUEL.VIAJE
--Ultimo elemento a migrar ya que recibe las FK	de todas las demas tablas que necesitan estar ya creadas
INSERT INTO [VAMONIUEL].[VIAJE]([Origen],[Destino],[FechaInicio],[FechaFin],[CRUCERO_IDENTIFICADOR],[ID_Pasaje],[ID_Crucero],[ID_Recorrido])
SELECT  M.PUERTO_DESDE, M.PUERTO_HASTA, M.FECHA_SALIDA, M.FECHA_LLEGADA,M.[CRUCERO_IDENTIFICADOR],P.ID,
(SELECT TOP 1 CRU.ID FROM VAMONIUEL.CRUCERO CRU WHERE M.[CRUCERO_IDENTIFICADOR] = cru.[CRUCERO_IDENTIFICADOR]), 
(SELECT  R.ID FROM VAMONIUEL.RECORRIDO R  WHERE M.PUERTO_DESDE = R.PUERTO_DESDE AND M.PUERTO_HASTA = R.PUERTO_HASTA)
FROM gd_esquema.Maestra M
LEFT JOIN VAMONIUEL.PASAJE P ON 
(M.PASAJE_CODIGO = P.PASAJE_CODIGO  AND M.PASAJE_FECHA_COMPRA = P.PASAJE_FECHA_COMPRA AND M.PASAJE_PRECIO = P.PASAJE_PRECIO) 
	
----------BORRO ESTE TRIGGER YA QUE LUEGO DE LA MIGRACION NO ME SIRVE/ME TRAE PROBLEMAS----------------------------------
DROP TRIGGER VAMONIUEL.tr_creacion_recorridoxtramo
-------------------------------------------------------------------------------------------------------------------------

--execute sp_vinculacion_pasajeTemporalConReservas
------------------------------------------- FIN  MIGRACION ----------------------------------------------------------------------------------------------------