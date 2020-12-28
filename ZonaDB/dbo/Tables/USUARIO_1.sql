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