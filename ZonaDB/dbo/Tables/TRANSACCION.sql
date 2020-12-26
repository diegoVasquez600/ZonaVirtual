------------------------------------------------ESTRUCTURA PARA LA TABLA TRANSACCION---------------------------------------
CREATE TABLE TRANSACCION
(
    Trans_codigo INT NOT NULL PRIMARY KEY,
    Trans_medio_pago INT NOT NULL,
    Trans_estado INT NOT NULL,
    Trans_fecha DATE,
    Trans_concepto TEXT,
    idUsuario INT,
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
ADD FOREIGN KEY (idUsuario)
REFERENCES USUARIO (idUsuario)
GO
ALTER TABLE TRANSACCION
ADD FOREIGN KEY (comercio_codigo)
REFERENCES COMERCIO (comercio_codigo)