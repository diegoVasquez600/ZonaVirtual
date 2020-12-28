 ----------------------CREACION DE LA BASE DE DATOS----------------------------------
CREATE DATABASE ZonaDB

GO
USE ZonaDB;
GO

------------------------------------------------ESTRUCTURA PARA LA TABLA COMERCIO---------------------------------------
CREATE TABLE COMERCIO
(
	comercio_codigo INT NOT NULL PRIMARY KEY, 
    comerico_nombre VARCHAR(150) NULL, 
    comercio_nit VARCHAR(30) NOT NULL, 
    comercio_direccion VARCHAR(100) NULL, 
    comercio_password VARCHAR(250) NULL, 
    comercio_salt VARCHAR(250) NULL,
)

GO

------------------------------------------------ESTRUCTURA PARA LA TABLA USUARIO---------------------------------------
CREATE TABLE USUARIO
(
    idUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    usuario_nombre VARCHAR(100) NULL,
    usuario_identificacion VARCHAR(30) NOT NULL UNIQUE,
    usuario_email VARCHAR(30) NULL,
    usuario_password VARCHAR(250) NULL,
    usuario_salt VARCHAR(250) NULL
)
GO

------------------------------------------------ESTRUCTURA PARA LA TABLA TRANSACCION---------------------------------------
CREATE TABLE TRANSACCION
(
    TransId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Trans_codigo VARCHAR(50),
    Trans_medio_pago INT NOT NULL,
    Trans_estado INT NOT NULL,
    Trans_fecha VARCHAR(50),
    Trans_concepto TEXT,
    usuario_identificacion VARCHAR(30),
    comercio_codigo INT,
    Trans_total FLOAT
)
GO

------------------------------------------------ESTRUCTURA PARA LA TABLA TRANS_MEDIO_PAGO---------------------------------------
CREATE TABLE TRANS_MEDIO_PAGO
(
    medio_pago_codigo INT PRIMARY KEY,
    nombre_medio_pago VARCHAR(20)
)
GO

------------------------------------------------ESTRUCTURA PARA LA TABLA TRANS_ESTADO---------------------------------------
CREATE TABLE TRANS_ESTADO
(
    estado_codigo INT PRIMARY KEY,
    estado VARCHAR(20)
)
GO

------------------------------------------------FILTROS PARA LA TABLA TRANSACCION---------------------------------------

ALTER TABLE TRANSACCION
ADD FOREIGN KEY(Trans_medio_pago)
REFERENCES TRANS_MEDIO_PAGO (medio_pago_codigo)
GO
ALTER TABLE TRANSACCION 
ADD FOREIGN KEY (Trans_estado)
REFERENCES TRANS_ESTADO (estado_codigo)
GO
ALTER TABLE TRANSACCION
ADD FOREIGN KEY (comercio_codigo)
REFERENCES COMERCIO (comercio_codigo)
GO


CREATE PROC PagosUsuario
@usuarioIdentificacion VARCHAR(30)
AS
    SELECT TRANSACCION.Trans_codigo, TRANSACCION.Trans_fecha, TRANSACCION.Trans_concepto, TRANSACCION.Trans_total, TRANSACCION.usuario_identificacion, TRANS_MEDIO_PAGO.nombre_medio_pago, TRANS_ESTADO.estado
    FROM TRANSACCION
    INNER JOIN TRANS_MEDIO_PAGO ON TRANSACCION.Trans_medio_pago = TRANS_MEDIO_PAGO.medio_pago_codigo
    INNER JOIN TRANS_ESTADO ON TRANSACCION.Trans_estado = TRANS_ESTADO.estado_codigo
    WHERE TRANSACCION.usuario_identificacion = @usuarioIdentificacion
GO
-------------------INSERTAR DATOS ESTATICOS-----------------------------
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(0, 'Ninguno')
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(29, 'PSE')
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(32, 'Tarjeta de Credito')
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(41, 'Gana')
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(42, 'Caja')


INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1, 'Aprobada')
INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(999, 'Pendiente')
INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1000, 'Rechazada')
INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1001, 'Rechazada SR')
