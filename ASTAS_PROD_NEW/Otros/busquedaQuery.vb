Public Class busquedaQuery
    Public query As String
    Public Function generarQueryBusqueda(ByVal cia, ByVal lc, ByVal td, ByVal sinofecha, ByVal fDesde, ByVal fHasta, ByVal cInicial, ByVal cFinal, ByVal documento, ByVal Transaccion)

        'declaración de variables
        Dim condicion As String = ""

        'declaración de consulta principal
        query = "  select distinct VCPE.TRANSACCION, CONVERT(NVARCHAR, VCPE.FECHA_CONTABLE, 107) + ' ' + CONVERT(NVARCHAR, VCPE.FECHA_CONTABLE, 108),"
        query &= " VCPE.IDENTIFICADOR, VCPE.DOCUMENTO, VCPE.PARTIDA, VCPE.CONCEPTO, (CASE VCPE.ANULADA WHEN 1 THEN 'ANULADA' ELSE '' END) AS Anulada, VCPE.TRANSACCION_ANULA,VCPE.USUARIO_CREACION, "
        query &= "CONVERT(NVARCHAR, VCPE.USUARIO_CREACION_FECHA, 107) + ' ' + CONVERT(NVARCHAR, VCPE.USUARIO_CREACION_FECHA, 108)  "
        query &= " FROM VISTA_CONTABILIDAD_PARTIDAS_ENCABEZADO as VCPE "

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
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " VCPE.TRANSACCION in(select distinct TRANSACCION from VISTA_CONTABILIDAD_PARTIDAS_DETALLE"
            condicion &= " where CUENTA_COMPLETA between '" & cInicial & "' and '" & cFinal & "' and COMPAÑIA = VCPE.COMPAÑIA) "
        End If

        'condición de documentos
        If documento <> Nothing Then
            If condicion = "" Then
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " DOCUMENTO like '%" & documento & "%' "
        End If

        'Condicion de fechas
        If sinofecha = 0 Then
            If fDesde <> Nothing And fHasta <> Nothing Then
                If fDesde <= fHasta Then
                    If condicion = "" Then
                        condicion = " where "
                    Else
                        condicion &= " and "
                    End If
                    condicion &= " FECHA_CONTABLE > = '" & Format(fDesde, "dd-MM-yyyy 00:00:01") & "' and FECHA_CONTABLE <= '" & Format(fHasta, "dd-MM-yyyy 23:59:59") & "' "
                Else
                    MsgBox("La fecha inicial no puede ser menor a la fecha final", MsgBoxStyle.Critical, "Mensaje")
                End If
            End If
        End If

        'Condicion para compañia
        If cia <> Nothing Then
            If condicion = "" Then
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " VCPE.COMPAÑIA = " & cia
        End If

        'Condicion para libro contable
        If lc <> Nothing Then
            If condicion = "" Then
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " VCPE.LIBRO_CONTABLE= " & lc
        End If

        'Condicion para tipo documento
        If td <> Nothing Then
            If condicion = "" Then
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " VCPE.TIPO_DOCUMENTO = " & td
        End If

        'Condicion para tipo documento
        If Transaccion <> Nothing Then
            If condicion = "" Then
                condicion = " where "
            Else
                condicion &= " and "
            End If
            condicion &= " VCPE.TRANSACCION= " & Transaccion
        End If

        query &= condicion

        Return query
    End Function
End Class