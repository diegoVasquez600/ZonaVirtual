CREATE PROC PagosUsuario
@usuarioIdentificacion VARCHAR(30)
AS
    SELECT TRANSACCION.Trans_codigo, TRANSACCION.Trans_fecha, TRANSACCION.Trans_concepto, TRANSACCION.Trans_total, TRANSACCION.usuario_identificacion, TRANS_MEDIO_PAGO.nombre_medio_pago, TRANS_ESTADO.estado
    FROM TRANSACCION
    INNER JOIN TRANS_MEDIO_PAGO ON TRANSACCION.Trans_medio_pago = TRANS_MEDIO_PAGO.medio_pago_codigo
    INNER JOIN TRANS_ESTADO ON TRANSACCION.Trans_estado = TRANS_ESTADO.estado_codigo
    WHERE TRANSACCION.usuario_identificacion = @usuarioIdentificacion