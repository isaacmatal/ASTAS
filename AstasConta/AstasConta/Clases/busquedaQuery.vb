Public Class busquedaQuery
    Public query As String
    Public Function generarQueryBusqueda(ByVal cia, ByVal lc, ByVal td, ByVal sinofecha, ByVal fDesde, ByVal fHasta, ByVal cInicial, ByVal cFinal, ByVal documento, ByVal Transaccion)

        'declaración de variables
        Dim condicion As String = ""

        'declaración de consulta principal
        query = "SELECT TRANSACCION, DOCUMENTO, PARTIDA, FECHA_CONTABLE, CONCEPTO, ESTADO, DESCRIPCION_TIPO_DOCUMENTO, USUARIO_CREACION, FECHA_CREACION FROM ("
        query &= "SELECT DISTINCT VCPE.TRANSACCION," & vbCrLf
        query &= "       VCPE.DOCUMENTO," & vbCrLf
        query &= "       CONVERT(VARCHAR, VCPE.PARTIDA) AS PARTIDA," & vbCrLf
        query &= "       CONVERT(NVARCHAR, VCPE.FECHA_CONTABLE, 103) AS FECHA_CONTABLE," & vbCrLf
        query &= "       VCPE.CONCEPTO, " & vbCrLf
        query &= "       (CASE ANULADA WHEN 1 THEN 'ANULADA' ELSE CASE PROCESADO WHEN 1 THEN 'PROCESADA' ELSE 'NO PROCESADA' END END) AS [ESTADO], " & vbCrLf
        query &= "       VCPE.IDENTIFICADOR + ' - ' + VCPE.DESCRIPCION_TIPO_DOCUMENTO AS DESCRIPCION_TIPO_DOCUMENTO," & vbCrLf
        query &= "       VCPE.USUARIO_CREACION," & vbCrLf
        query &= "       CONVERT(NVARCHAR, VCPE.USUARIO_CREACION_FECHA, 103) AS FECHA_CREACION  " & vbCrLf
        query &= "  FROM VISTA_CONTABILIDAD_PARTIDAS_ENCABEZADO VCPE "

        'Eliminar espacios en blanco
        'fDesde = Trim(fDesde)
        'fHasta = Trim(fHasta)
        cInicial = Trim(cInicial)
        cFinal = Trim(cFinal)
        documento = Trim(documento)

        'creación de condición

        'condición de cuentas
        If cInicial <> Nothing And cFinal <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " VCPE.TRANSACCION IN(select distinct TRANSACCION from VISTA_CONTABILIDAD_PARTIDAS_DETALLE"
            condicion &= " where CUENTA_COMPLETA between '" & cInicial & "' and '" & cFinal & "' and COMPAÑIA = VCPE.COMPAÑIA) "
        End If

        'condición de documentos
        If documento <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " DOCUMENTO like '%" & documento & "%' "
        End If

        'Condicion de fechas
        If sinofecha = 0 Then
            If fDesde <> Nothing And fHasta <> Nothing Then
                If fDesde <= fHasta Then
                    If condicion = "" Then
                        condicion = " WHERE "
                    Else
                        condicion &= " AND "
                    End If
                    condicion &= " CONVERT(DATE, FECHA_CONTABLE) > = CONVERT(DATE, '" & Format(fDesde, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, FECHA_CONTABLE) <= CONVERT(DATE, '" & Format(fHasta, "dd/MM/yyyy") & "',103) "
                Else
                    MsgBox("La fecha inicial no puede ser menor a la fecha final", MsgBoxStyle.Critical, "Mensaje")
                End If
            End If
        End If

        'Condicion para compañia
        If cia <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " VCPE.COMPAÑIA = " & cia
        End If

        'Condicion para libro contable
        If lc <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " VCPE.LIBRO_CONTABLE= " & lc
        End If

        'Condicion para tipo documento
        If td <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " VCPE.TIPO_DOCUMENTO = " & td
        End If

        'Condicion para tipo documento
        If Transaccion <> Nothing Then
            If condicion = "" Then
                condicion = " WHERE "
            Else
                condicion &= " AND "
            End If
            condicion &= " VCPE.TRANSACCION= " & Transaccion
        End If

        query &= condicion & ") A ORDER BY CONVERT(INT, A.PARTIDA)"

        Return query
    End Function
End Class