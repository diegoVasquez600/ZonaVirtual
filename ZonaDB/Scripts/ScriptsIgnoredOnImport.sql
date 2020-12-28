
----------------------CREACION DE LA BASE DE DATOS----------------------------------
CREATE DATABASE ZonaDB
GO

USE ZonaDB;
GO

-------------------INSERTAR DATOS ESTATICOS-----------------------------
INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(0, 'Ninguno')
GO

INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(29, 'PSE')
GO

INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(32, 'Tarjeta de Credito')
GO

INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(41, 'Gana')
GO

INSERT INTO TRANS_MEDIO_PAGO (medio_pago_codigo, nombre_medio_pago) VALUES(42, 'Caja')
GO

INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1, 'Aprobada')
GO

INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(999, 'Pendiente')
GO

INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1000, 'Rechazada')
GO

INSERT INTO TRANS_ESTADO (estado_codigo, estado) VALUES(1001, 'Rechazada SR')
GO
