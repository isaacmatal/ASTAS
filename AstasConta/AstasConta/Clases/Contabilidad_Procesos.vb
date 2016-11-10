Imports System.Data.SqlClient

Public Class Contabilidad_Procesos
    Dim Sql As String

    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataReader_ As SqlDataReader

    Public Function Contabiliza_Partida_Automatica_Standard(ByVal Compañia As Integer, _
                                                            ByVal CentroCosto As Integer, _
                                                            ByVal TipoDocumento As Integer, _
                                                            ByVal Origen As Integer, _
                                                            ByVal NumeroDocumento As Long, _
                                                            ByVal FechaContable As Date, _
                                                            ByVal CuentaBanco As Integer, _
                                                            ByVal DocumentoAsociado As Integer, _
                                                            ByVal Total As Double, _
                                                            ByVal Concepto As String) As Integer
        Dim res As Integer = 0
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Conexion_.Open()
        Try
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_STD "
            Sql &= Compañia
            Sql &= ", " & CentroCosto
            Sql &= ", " & TipoDocumento
            Sql &= ", " & Origen
            Sql &= ", " & NumeroDocumento
            Sql &= ", '" & FechaContable & "'"
            Sql &= ", " & CuentaBanco
            Sql &= ", " & DocumentoAsociado
            Sql &= ", " & Total
            Sql &= ", '" & Concepto & "'"
            Sql &= ", '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            'res = Comando_.ExecuteNonQuery()
            res = Comando_.ExecuteScalar()
            If res > 0 Then
                'MsgBox("¡Operación contabilizada con éxito!" & vbCrLf & "Partida No. " & res, MsgBoxStyle.Information, "Partidas Automáticas")
            Else
                MsgBox("Partida No. 0" & vbCrLf & "Partida Automática no definida." & vbCrLf & vbCrLf & "Favor, Revisar Catálogo Partidas Automáticas", MsgBoxStyle.Exclamation, "Partidas Automáticas")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Partidas Automáticas")
        End Try
        Conexion_.Close()
        Return res
    End Function

    Public Sub Contabiliza_Partida_Automatica(ByVal Compañia, ByVal CentroCosto, ByVal TipoDocumento, ByVal Origen, ByVal NumeroFactura, ByVal FechaContable, ByVal NumeroOC_OV_Solicitud, ByVal TipoDocumentoFacturacion)
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR "
            Sql &= Compañia
            Sql &= ", " & CentroCosto
            Sql &= ", " & TipoDocumento
            Sql &= ", " & Origen
            Sql &= ", " & NumeroFactura
            Sql &= ", '" & FechaContable & "'"
            Sql &= ", " & NumeroOC_OV_Solicitud
            Sql &= ", " & TipoDocumentoFacturacion
            Sql &= ", '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function Busca_TipoDocumento_Contable(ByVal Compañia, ByVal TipoDocumento) As String
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT * FROM FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE  "
            Sql &= "COMPAÑIA = " & Compañia
            Sql &= " AND TIPO_DOCUMENTO = " & TipoDocumento
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Return DataReader_.Item("TIPO_DOCUMENTO_CONTABLE").ToString
                Exit Function
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ""
    End Function

    Public Function FechaActual_Servidor() As Date
        Dim Fecha As Date
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_FECHA_ACTUAL_SERVIDOR  0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Fecha = DataReader_.Item("FECHA_ACTUAL")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Now 'Fecha
    End Function

    Public Sub Contabiliza_ChequesOC(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Cheque, ByVal FechaContable, ByVal OC, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_CHEQUES "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Cheque
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & OC
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Cheque Generado y Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_ChequesOC_VariasOC(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Cheque, ByVal FechaContable, ByVal TotalCheque, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_CHEQUES_VARIAS_OC "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Cheque
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & TotalCheque
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Cheque Generado y Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_Cheques_CooperativaOC(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Cheque, ByVal FechaContable, ByVal OC, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_CHEQUES_COOPERATIVA_OC "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Cheque
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & OC
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Cheque Generado y Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_NotaAbono(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Fact_Abono, ByVal FechaContable, ByVal OV, ByVal NotaAbono, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_NOTAS_ABONO "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ,'" & Fact_Abono & "'"
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & OV
            Sql &= ", " & NotaAbono
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Nota de Abono Contabilizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_ChequesSocios(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Cheque, ByVal FechaContable, ByVal Retiro, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_CHEQUES_COOPERATIVA "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Cheque
            Sql &= " ,'" & FechaContable & "'"
            Sql &= ", " & Retiro
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Cheque Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_Compras(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Documento, ByVal FechaContable, ByVal OC)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COMPRAS " & vbCrLf
            Sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
            Sql &= ",@CENTRO_COSTO     = " & CC & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO   = " & TipoDocumento & vbCrLf
            Sql &= ",@ORIGEN           = " & Origen & vbCrLf
            Sql &= ",@NUMERO_DOCUMENTO = " & Documento & vbCrLf
            Sql &= ",@FECHA_CONTABLE   = '" & FechaContable & "'" & vbCrLf
            Sql &= ",@OC_SOL           = " & OC & vbCrLf
            Sql &= ",@USUARIO          = '" & Usuario & "'" & vbCrLf
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Public Sub Contabiliza_Cooperativa_OC(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Documento, ByVal FechaContable, ByVal OC, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COOPERATIVA_OC "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Documento
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & OC
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Orden de Compra Contabilizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_Cooperativa_Solicitudes(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Documento, ByVal FechaContable, ByVal Solicitud, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COOPERATIVA_SOLICITUDES "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Documento
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & Solicitud
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Orden de Compra Contabilizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_Cheques_CooperativaOC_VariasOC(ByVal Compañia, ByVal CC, ByVal TipoDocumento, ByVal Origen, ByVal Cheque, ByVal FechaContable, ByVal OC, ByVal CuentaBanco, ByVal Concepto)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COOPERATIVA_VARIAS_OC "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Cheque
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & OC
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Cheque Generado y Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Contabiliza_Cooperativa_Prestamos(ByVal Compañia As Integer, ByVal CC As Integer, ByVal TipoDocumento As Integer, ByVal Origen As Integer, ByVal Documento As Integer, ByVal FechaContable As Date, ByVal Solicitud As Integer, ByVal Total As Double, ByVal Intereses As Double, ByVal Seguro As Double, ByVal CuentaBanco As String, ByVal Concepto As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COOPERATIVA_PRESTAMOS "
            Sql &= Compañia
            Sql &= " ," & CC
            Sql &= " ," & TipoDocumento
            Sql &= " ," & Origen
            Sql &= " ," & Documento
            Sql &= " ,'" & FechaContable & "'"
            Sql &= " ," & Solicitud
            Sql &= " ," & Total
            Sql &= " ," & Intereses
            Sql &= " ," & Seguro
            Sql &= " ," & CuentaBanco
            Sql &= " ,'" & Concepto & "'"
            Sql &= " ,'" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Préstamo Contabilizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Conexion_.Open()
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ",@LIBRO_CONTABLE = " & LC
            Sql &= ",@AÑO = " & Año
            Sql &= ",@MES = " & Mes
            Sql &= ",@PRE_CIERRE = 0"
            Sql &= ",@CIERRE_FINAL = 0"
            Sql &= ",@PROCESADO = 0"
            Sql &= ",@USUARIO = '" & Usuario & "'"
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            DataReader_ = Comando_.ExecuteReader()
            'Conexion_.Close()
            If DataReader_.Read = True Then
                'If DataReader_.Item("PROCESADO") = True Then
                '    MsgBox("¡El Período Contable ya esá CERRADO y PROCESADO!" & Chr(13) & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                '    Return False
                '    Exit Function
                'End If
                If DataReader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & Chr(13) & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If DataReader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & Chr(13) & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & Chr(13) & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Public Function ValidaCierreContablePermisos(ByVal Compañia, ByVal Año, ByVal Mes, ByVal IUD) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            Sql &= Compañia
            Sql &= ", " & Año
            Sql &= ", " & Mes
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            Conexion_.Close()
            If DataReader_.Read = True Then
                Return True
                Exit Function
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    'Método que verficia si el periodo contable está abierto
    Public Function ValidaCierreContable(ByVal Compañia, ByVal LC, ByVal Año, ByVal Mes, ByVal ifEvaluar, ByVal IUD) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            Sql &= Compañia
            Sql &= ", " & LC
            Sql &= ", " & Año
            Sql &= ", " & Mes
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If ifEvaluar = 0 Or ifEvaluar = 1 Then
                    If Datareader_.Item("PROCESADO") = True Then
                        MsgBox("¡El Período Contable ya esá CERRADO y PROCESADO!" & Chr(13) & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
                If ifEvaluar = 1 Then
                    If Datareader_.Item("CIERRE_FINAL") = True Then
                        MsgBox("¡El Período Contable ya esá en CIERRE FINAL!" & Chr(13) & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                    If Datareader_.Item("PRE_CIERRE") = True Then
                        If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                            MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & Chr(13) & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                            Return False
                            Exit Function
                        End If
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & Chr(13) & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    'Metodo que verifica si el usuario tiene permisos para operar en el periodo vigente
    Public Function ValidaCierreContablePermisos(ByVal Compañia, ByVal LC, ByVal Año, ByVal Mes, ByVal IUD) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            Sql &= Compañia
            Sql &= ", " & LC
            Sql &= ", " & Año
            Sql &= ", " & Mes
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
            MsgBox("¡No hay un período contable actual vigente!" & vbCrLf & "No podrá realizar ninguna operación hasta que sea aperturado.")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Public Sub DetallePartida(ByVal Transaccion As Integer, ByVal Linea As Integer, _
                                ByVal CentCost As String, ByVal Fecha As Date, ByVal Libro As Integer, _
                                ByVal Concepto As String, ByVal Cuenta As Integer, ByVal Cargo_Abono As String, _
                                ByVal Cargo As Double, ByVal Abono As Double, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As New SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_.Connection = Conexion_
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @TRANSACCION = " & Transaccion
            Sql &= ", @LIBRO_CONTABLE = " & Libro
            Sql &= ", @LINEA = " & Linea
            Sql &= ", @CENTRO_COSTO = " & CentCost
            Sql &= ", @CUENTA = " & Cuenta
            Sql &= ", @CONCEPTO = '" & Concepto & "'"
            Sql &= ", @CARGO_ABONO = '" & Cargo_Abono & "'"
            Sql &= ", @CARGO = " & Cargo
            Sql &= ", @ABONO = " & Abono
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Sql &= ", @IUD = '" & IUD & "'"
            Comando_.CommandText = Sql
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Detalle Partidas")
            Conexion_.Close()
        End Try
    End Sub

    Public Sub EncabezadoPartida(ByVal Transaccion As Integer, ByVal TipoPartida As Integer, _
                                 ByVal TipDoc As Integer, ByVal Docto As String, ByVal Fecha As DateTime, _
                                 ByVal Libro As Integer, ByVal Concepto As String, ByVal Anulada As Integer, _
                                 ByVal Transaccion_Anulada As Integer, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As New SqlCommand
        Dim Partida As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_.Connection = Conexion_
            Comando_.CommandText = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'PAR', @AÑO = " & Fecha.Year & ", @MES = " & Fecha.Month & ", @ULTIMO = 0"
            Partida = Comando_.ExecuteScalar()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @TRANSACCION = " & Transaccion
            Sql &= ", @LIBRO_CONTABLE = " & Libro
            Sql &= ", @TIPO_DOCUMENTO = " & TipDoc
            Sql &= ", @DOCUMENTO = " & Docto
            Sql &= ", @TIPO_PARTIDA = " & TipoPartida
            Sql &= ", @PARTIDA = " & Partida
            Sql &= ", @FECHA_CONTABLE = '" & Format(Fecha, "dd/MM/yyyy") & "'"
            Sql &= ", @CONCEPTO = '" & Concepto & "'"
            Sql &= ", @ANULADA = " & Anulada
            Sql &= ", @TRANSACCION_ANULA = " & Transaccion_Anulada
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Sql &= ", @IUD = '" & IUD & "'"
            Comando_.CommandText = Sql
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Encabezado Partidas")
            Conexion_.Close()
        End Try
    End Sub

    Public Sub EncabezadoPartida2(ByVal Transaccion As Integer, ByVal TipoPartida As Integer, _
                                 ByVal TipDoc As Integer, ByVal Docto As String, ByVal Fecha As DateTime, _
                                 ByVal Libro As Integer, ByVal Concepto As String, ByVal Anulada As Integer, _
                                 ByVal Transaccion_Anulada As Integer, ByVal IUD As String, ByVal Partida As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As New SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_.Connection = Conexion_
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @TRANSACCION = " & Transaccion
            Sql &= ", @LIBRO_CONTABLE = " & Libro
            Sql &= ", @TIPO_DOCUMENTO = " & TipDoc
            Sql &= ", @DOCUMENTO = " & Docto
            Sql &= ", @TIPO_PARTIDA = " & TipoPartida
            Sql &= ", @PARTIDA = " & Partida
            Sql &= ", @FECHA_CONTABLE = '" & Format(Fecha, "dd/MM/yyyy") & "'"
            Sql &= ", @CONCEPTO = '" & Concepto & "'"
            Sql &= ", @ANULADA = " & Anulada
            Sql &= ", @TRANSACCION_ANULA = " & Transaccion_Anulada
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Sql &= ", @IUD = '" & IUD & "'"
            Comando_.CommandText = Sql
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Encabezado Partidas")
            Conexion_.Close()
        End Try
    End Sub
End Class
