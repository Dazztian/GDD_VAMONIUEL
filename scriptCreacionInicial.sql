USE [GD1C2019]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'VAMONIUEL')
BEGIN
EXEC ('CREATE SCHEMA [VAMONIUEL] AUTHORIZATION [gdCrucero2019]')
END



CREATE TABLE VAMONIUEL.[Rol](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Habilitado] [bit] default 1
);	


CREATE TABLE VAMONIUEL.[Funcion](
	[ID] [int] NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](50) NOT NULL,
);

CREATE TABLE VAMONIUEL.[Rol_X_Funcion](
	[ID_Rol] [int],
	[ID_Funcion] [int],
	PRIMARY KEY(ID_ROL, ID_Funcion),
	CONSTRAINT FK_Rol FOREIGN KEY (ID_Rol) REFERENCES VAMONIUEL.[Rol](ID),
	CONSTRAINT FK_Funcion FOREIGN KEY (ID_Funcion) REFERENCES VAMONIUEL.[Funcion](ID)
);

CREATE TABLE VAMONIUEL.[Usuario](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [binary](32) NOT NULL,
	[cant_accesos_fallidos] int default 0,
	[habilitado] [bit] default 1,
	[contrasena_autogenerada] [bit] default 0,
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

CREATE TABLE [VAMONIUEL].[VIAJE]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	Origen [nvarchar](255) not null,
	Destino [nvarchar](255) not null,
	FechaInicio [datetime2](3) not null,
	FechaFin [datetime2](3) not null,
	ID_Pasaje int not null,
	ID_Crucero	 int not null,
	CONSTRAINT FK_Viaje_Pasaje FOREIGN KEY (ID_Pasaje) REFERENCES VAMONIUEL.[Pasaje](ID),			
	CONSTRAINT FK_Viaje_Crucero FOREIGN KEY (ID_Crucero) REFERENCES VAMONIUEL.[Crucero](ID)			
);

CREATE TABLE [VAMONIUEL].[RECORRIDO]
(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RECORRIDO_CODIGO] [decimal](18, 0) NULL,
	[RECORRIDO_PRECIO_BASE] [decimal](18, 2) NULL,
	[PUERTO_DESDE] [nvarchar](255) NULL,
	[PUERTO_HASTA] [nvarchar](255) NULL,
	ID_Viaje int not null,
	CONSTRAINT FK_Recorrido_Viaje FOREIGN KEY (ID_Viaje) REFERENCES VAMONIUEL.[Viaje](ID)		
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


CREATE TABLE [VAMONIUEL].[CABINA]
(
	[CABINA_NRO] [decimal](18, 0) NULL,
	[CABINA_PISO] [decimal](18, 0) NULL,
	[CABINA_TIPO] [nvarchar](255) NULL,
	[CABINA_TIPO_PORC_RECARGO] [decimal](18, 2) NULL,	
	ID_Crucero int not null,
	CONSTRAINT FK_Cabina_Crucero FOREIGN KEY (ID_Crucero) REFERENCES VAMONIUEL.[Crucero](ID)		
);

CREATE TABLE [VAMONIUEL].[RESERVA]
(
	[RESERVA_CODIGO] [decimal](18, 0) NULL,
	[RESERVA_FECHA] [datetime2](3) NULL,
	ID_Pasaje int not null,
	CONSTRAINT FK_Reserva_Pasaje FOREIGN KEY (ID_Pasaje) REFERENCES VAMONIUEL.[Pasaje](ID)	
);

--------------------------------------------- MIGRACION ----------------------------------------------------------------------------------------------------
 INSERT INTO VAMONIUEL.[Cliente]
(	[CLI_NOMBRE],[CLI_APELLIDO],[CLI_DNI],[CLI_DIRECCION],[CLI_TELEFONO],[CLI_MAIL],[CLI_FECHA_NAC])--, [ID_Usuario])
select  distinct[CLI_NOMBRE],[CLI_APELLIDO],[CLI_DNI],[CLI_DIRECCION] ,[CLI_TELEFONO],[CLI_MAIL],[CLI_FECHA_NAC]
-- ,(select ID from ESKHERE.Usuario where CAST([Cli_Dni] as nvarchar(50)) = Usuario)
from gd_esquema.Maestra
where [Cli_Dni]  IS NOT NULL

INSERT INTO [VAMONIUEL].[CRUCERO]
 ([CRU_FABRICANTE],[CRUCERO_MODELO],[CRUCERO_IDENTIFICADOR])
 select  distinct [CRUCERO_MODELO],[CRUCERO_IDENTIFICADOR],[CRU_FABRICANTE] 
from gd_esquema.Maestra

INSERT INTO [VAMONIUEL].[CABINA]
([CABINA_NRO],[CABINA_PISO],[CABINA_TIPO],[CABINA_TIPO_PORC_RECARGO],[ID_Crucero])
select  distinct [CABINA_NRO],[CABINA_PISO],[CABINA_TIPO],[CABINA_TIPO_PORC_RECARGO],
(SELECT ID FROM VAMONIUEL.CRUCERO C WHERE  C.CRU_FABRICANTE = M.CRU_FABRICANTE
								   /* AND C.CRUCERO_IDENTIFICADOR = M.CRU_FABRICANTE
									AND C.CRUCERO_MODELO = M.CRUCERO_MODELO*/ )
from gd_esquema.Maestra M 


INSERT INTO [VAMONIUEL].[Tramo]
 ([PUERTO_DESDE] ,[PUERTO_HASTA],[RECORRIDO_PRECIO_BASE])
select  distinct [PUERTO_DESDE],[PUERTO_HASTA], [RECORRIDO_PRECIO_BASE]
from gd_esquema.Maestra

INSERT INTO [VAMONIUEL].[Puerto]([Nombre])
select  distinct [PUERTO_DESDE]
from gd_esquema.Maestra
--Pareceria que no hace falta esto, pero x las dudas...
INSERT INTO [VAMONIUEL].[Puerto]([Nombre])
select  distinct [PUERTO_HASTA]
from gd_esquema.Maestra
WHERE [PUERTO_HASTA] NOT IN (select  distinct [PUERTO_DESDE] from gd_esquema.Maestra)


INSERT INTO [VAMONIUEL].[TramoXPuerto]
 ([id_tramo],[id_puerto])
select distinct  T.ID,P.ID from gd_esquema.Maestra M 
JOIN  VAMONIUEL.Puerto P  ON M.PUERTO_DESDE= P.Nombre  
JOIN VAMONIUEL.Tramo T ON  M.PUERTO_DESDE = T.PUERTO_DESDE  AND   M.PUERTO_HASTA=T.PUERTO_HASTA
