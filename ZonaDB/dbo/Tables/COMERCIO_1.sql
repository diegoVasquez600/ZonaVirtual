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