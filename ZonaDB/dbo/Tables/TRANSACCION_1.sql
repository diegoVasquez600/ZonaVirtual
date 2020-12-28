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