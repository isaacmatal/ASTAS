Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class cmbFill

    'Herencia
    Inherits Contabilidad_Procesos

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader

    'Declaracion de variables
    Dim sql As String
    Dim Iniciando As Boolean

    'Constructores
    Dim NL As New NumeroLetras

    Public Function devuelveCadenaConexion()
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos        
        Return New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
    End Function

    'Llena ComboBox de Compañia
    Public Sub CargaCompañia(ByVal cmbCOMPAÑIA As ComboBox)
        Conexion_ = devuelveCadenaConexion()        
        Try
            Conexion_.Open()
            sql = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "' ," & Compañia
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCOMPAÑIA.DataSource = Table
            cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            cmbCOMPAÑIA.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el combobox de bancos
    Public Sub CargaBancos(ByVal Compañia As Integer, ByVal cmbBANCO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            sql &= Compañia
            sql &= ", 0"
            sql &= ", 0"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbBANCO.DataSource = Table
            cmbBANCO.ValueMember = "Banco"
            cmbBANCO.DisplayMember = "Nombre Banco"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el combobox de las cuentas bancarias
    Public Sub CargaCuentasBancarias(ByVal Compañia As Integer, ByVal Banco As Integer, ByVal Flag As Integer, ByVal cmbCUENTA_BANCARIA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            sql &= Compañia
            sql &= ", " & Banco
            sql &= ", " & Flag
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCUENTA_BANCARIA.DataSource = Table
            cmbCUENTA_BANCARIA.ValueMember = "Cuenta"
            cmbCUENTA_BANCARIA.DisplayMember = "Descripción Cuenta"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena los campos de la cuenta contable
    Public Function CargaCuentaContable(ByVal Compañia As Integer, ByVal Banco As Integer, ByVal CuentaBancaria As String, ByVal Flag As Integer, ByVal Valor As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            sql &= Compañia
            sql &= ", " & Banco
            sql &= ", '" & CuentaBancaria & "'"
            sql &= ", " & Flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                If Valor = 1 Then
                    Return DataReader_.Item("CUENTA_COMPLETA")
                ElseIf Valor = 2 Then
                    Return DataReader_.Item("CUENTA")
                ElseIf Valor = 3 Then
                    Return DataReader_.Item("LIBRO_CONTABLE")
                End If
            Else
                If Valor = 1 Then
                    Return ""
                ElseIf Valor = 2 Then
                    Return "0"
                ElseIf Valor = 3 Then
                    Return "0"
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            If Valor = 1 Then
                Return ""
            ElseIf Valor = 2 Then
                Return "0"
            ElseIf Valor = 3 Then
                Return "0"
            End If
        End Try
        Return "0"
    End Function

    'Llena ComboBox del Libro Contable
    Public Sub CargaLibrosContables(ByVal Compañia As Integer, ByVal cmbLIBRO_CONTABLE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbLIBRO_CONTABLE.DataSource = Table
            cmbLIBRO_CONTABLE.ValueMember = "Código"
            cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox del Tipo de Documento Contable
    Public Sub CargaTipoDocumento(ByVal Compañia As Integer, ByVal cmbTIPO_DOCUMENTO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO " & Compañia & ", 1"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbTIPO_DOCUMENTO.DataSource = Table
            cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox del Tipo de Documento Facturación
    Public Sub CargaTipoDocumentoFact(ByVal Compañia As Integer, ByVal cmbTIPO_DOCUMENTO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO 2, " & Compañia
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbTIPO_DOCUMENTO.DataSource = Table
            cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox del Tipo de Documento Inventario
    Public Sub CargaTipoDocumentoInventario(ByVal Compañia As Integer, ByVal cmbTIPO_DOCUMENTO As ComboBox, ByVal Bandera As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_CATALOGO_TIPO_DOCUMENTO " & Compañia & "," & Bandera
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbTIPO_DOCUMENTO.DataSource = Table
            cmbTIPO_DOCUMENTO.ValueMember = "TipoDoc"
            cmbTIPO_DOCUMENTO.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox del Tipo de Partida
    Public Sub CargaTipoPartida(ByVal Compañia As Integer, ByVal cmbTIPO_PARTIDA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TIPO_PARTIDA " & Compañia & ", 0"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbTIPO_PARTIDA.DataSource = Table
            cmbTIPO_PARTIDA.ValueMember = "TIPO_PARTIDA"
            cmbTIPO_PARTIDA.DisplayMember = "DESCRIPCION_TIPO_PARTIDA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Centro de Costo
    Public Sub CargaCentroCosto(ByVal Compañia As Integer, ByVal cmbCENTRO_COSTO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO " & Compañia & ", 2"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCENTRO_COSTO.DataSource = Table
            cmbCENTRO_COSTO.ValueMember = "Centro Costo"
            cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Centro de Costo acorde a la Bodega
    Public Sub CargaCentroCostoBodega(ByVal cia As Integer, ByVal bodega As Integer, ByVal cmbCENTRO_COSTO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO_BODEGA " & cia & ", " & bodega & ", 2"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCENTRO_COSTO.DataSource = Table
            cmbCENTRO_COSTO.ValueMember = "Centro Costo"
            cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Centro de Costo para las notas de abono
    Public Sub CargaCentroNA(ByVal cia As Integer, ByVal cmbCENTRO_COSTO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO " & cia & ", 3"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCENTRO_COSTO.DataSource = Table
            cmbCENTRO_COSTO.ValueMember = "Centro Costo"
            cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Serie de Facturación
    Public Sub CargaSerieFact(ByVal Compañia As Integer, ByVal bodega As Integer, ByVal cmbSERIE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS " & 2 & ", " & Compañia & ", " & bodega
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbSERIE.DataSource = Table
            cmbSERIE.ValueMember = "Serie"
            cmbSERIE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Series de Facturación Libres
    Public Sub CargaSerieFactLibres(ByVal cia As Integer, ByVal bodega As Integer, ByVal cmbSERIE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS " & 3 & ", " & cia & ", " & bodega
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbSERIE.DataSource = Table
            cmbSERIE.ValueMember = "Serie"
            cmbSERIE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Series de Facturación Libres acorde a la bodega y el tipo de documento para la facturacion
    Public Sub CargaSerieFactLibres2(ByVal cia As Integer, ByVal bodega As Integer, ByVal tipoDoc As Integer, ByVal cmbSERIE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO_SERIES " & 1 & ", " & cia & ", " & bodega & ", " & tipoDoc
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbSERIE.DataSource = Table
            cmbSERIE.ValueMember = "Serie"
            cmbSERIE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Series de Facturación con todas las series registradas excepto las Libres acorde a la bodega y
    'el tipo de documento para la facturacion
    Public Sub CargaSerieFactLibres3(ByVal cia As Integer, ByVal bodega As Integer, ByVal tipoDoc As Integer, ByVal cmbSERIE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO_SERIES " & 2 & ", " & cia & ", " & bodega & ", " & tipoDoc
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbSERIE.DataSource = Table
            cmbSERIE.ValueMember = "Serie"
            cmbSERIE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Series de Facturación con todas las series registradas acorde a la bodega y
    'al tipo de documento para la facturacion
    Public Sub CargaSerieFactTodas(ByVal cia As Integer, ByVal bodega As Integer, ByVal tipoDoc As Integer, ByVal cmbSERIE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO_SERIES " & 3 & ", " & cia & ", " & bodega & ", " & tipoDoc
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbSERIE.DataSource = Table
            cmbSERIE.ValueMember = "Serie"
            cmbSERIE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Devuelve la tasa de todos los impuestos que se registren
    Public Function devuelveSiNoSerieLibre(ByVal cia As Integer, ByVal bodega As Integer, ByVal tipoDoc As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO_SERIES " & 4 & ", " & cia & ", " & bodega & ", " & tipoDoc
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                If DataReader_.Item("Valor") = False Then
                    Return "NO LIBRE"
                ElseIf DataReader_.Item("Valor") = True Then
                    Return "LIBRE"
                Else
                    Return ""
                End If
                Exit Function
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return ""
    End Function

    'Llena ComboBox de Deducciones
    Public Sub CargaDeducciones(ByVal Compañia As Integer, ByVal cmbDEDUCCIONES As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute [Coo].[sp_COOPERATIVA_DEDUCCIONES] " & Compañia & ", 0, 1"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbDEDUCCIONES.DataSource = Table
            cmbDEDUCCIONES.ValueMember = "Deducción"
            cmbDEDUCCIONES.DisplayMember = "Descripción Deducción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena ComboBox de Período de Cooperativa
    Public Sub CargaPeriodo(ByVal Compañia As Integer, ByVal cmbPERIODO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_PERIODOS " & Compañia & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbPERIODO.DataSource = Table
            cmbPERIODO.ValueMember = "PERIODO"
            cmbPERIODO.DisplayMember = "DESCRIPCION_PERIODO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Bodegas
    Public Sub CargaBodega(ByVal Compañia As Integer, ByVal cmbBODEGA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA = " & 1 & ", @COMPAÑIA = " & Compañia & ", @USUARIO = '" & Usuario & "'"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbBODEGA.DataSource = Table
            cmbBODEGA.ValueMember = "Bodega"
            cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Bodegas aplicando seguridad
    Public Sub CargaBodegaSeguridadUsuario(ByVal Compañia As Integer, ByVal cmbBODEGA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA = " & 3 & ", @COMPAÑIA = " & Compañia & ", @USUARIO = '" & Usuario & "'"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbBODEGA.DataSource = Table
            cmbBODEGA.ValueMember = "Bodega"
            cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llenar el ComboBox de Tipo de Cliente
    Public Sub CargaTipoCliente(ByVal cia As Integer, ByVal cmbTIPO_CLIENTE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TIPO_CLIENTE " & cia & ", " & 1 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbTIPO_CLIENTE.DataSource = Table
            cmbTIPO_CLIENTE.ValueMember = "TIPO_CLIENTE"
            cmbTIPO_CLIENTE.DisplayMember = "DESCRIPCION_TIPO_CLIENTE"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Contribuyente
    Public Sub CargaContribuyente(ByVal cia As Integer, ByVal cmbCONTRIBUYENTE As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR " & cia & ", " & 1 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCONTRIBUYENTE.DataSource = Table
            cmbCONTRIBUYENTE.ValueMember = "TIPO_PROVEEDOR"
            cmbCONTRIBUYENTE.DisplayMember = "DESCRIPCION_TIPO_PROVEEDOR"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Obtiene el porcentaje de la retencion o la percepcion
    Public Function cargaRetencionPercepcion(ByVal cia As Integer, ByVal contribuyente As Integer, ByVal flag As Integer)
        'Valor del Flag: 1 para retencion, 2 para percepcion
        Dim Valor As Double = 0
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR " & cia & ", " & 1 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            For i As Integer = 0 To (Table.Rows.Count - 1)
                If Table.Rows(i).Item("TIPO_PROVEEDOR") = contribuyente Then
                    If flag = 1 Then
                        Valor = Table.Rows(i).Item("PROCENTAJE_RETENCION") / 100
                    ElseIf flag = 2 Then
                        Valor = Table.Rows(i).Item("PORCENTAJE_PERCEPCION") / 100
                    End If
                    Return Valor
                    Exit Function
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
            Return -1
        End Try
        Return Valor
    End Function

    'Devuelve la tasa de todos los impuestos que se registren
    Public Function devuelveTasaImpuesto(ByVal cia As Integer, ByVal correlativo As Integer, ByVal flag As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_TASA_IMPUESTOS "
            sql &= cia
            sql &= "," & correlativo
            sql &= "," & flag
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            For i As Integer = 0 To (Table.Rows.Count - 1)
                Return Table.Rows(i).Item("Valor")
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return 0.0
    End Function

    'Llena el ComboBox de Forma de Pago
    Public Sub CargaFormaPago(ByVal cia As Integer, ByVal cmbFORMA_PAGO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_FORMA_PAGO " & 2 & ", " & cia & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbFORMA_PAGO.DataSource = Table
            cmbFORMA_PAGO.ValueMember = "Forma Pago"
            cmbFORMA_PAGO.DisplayMember = "Descripción Forma"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Forma de Pago
    Public Sub CargaFormaPagoDefaultCredito(ByVal cia As Integer, ByVal cmbFORMA_PAGO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_FORMA_PAGO " & 2 & ", " & cia & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbFORMA_PAGO.DataSource = Table
            cmbFORMA_PAGO.ValueMember = "Forma Pago"
            cmbFORMA_PAGO.DisplayMember = "Descripción Forma"
            cmbFORMA_PAGO.SelectedValue = 2
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Forma de Pago sin el valor de Crédito
    Public Sub CargaFormaPagoSinCredito(ByVal cia As Integer, ByVal cmbFORMA_PAGO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_FORMA_PAGO " & 3 & ", " & cia & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbFORMA_PAGO.DataSource = Table
            cmbFORMA_PAGO.ValueMember = "Forma Pago"
            cmbFORMA_PAGO.DisplayMember = "Descripción Forma"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Forma de Pago solo con los valores de credito y contado
    Public Sub CargaFormaPagoSoloContadoCredito(ByVal cia As Integer, ByVal cmbFORMA_PAGO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_FORMA_PAGO " & 4 & ", " & cia & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbFORMA_PAGO.DataSource = Table
            cmbFORMA_PAGO.ValueMember = "Forma Pago"
            cmbFORMA_PAGO.DisplayMember = "Descripción Forma"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Condición de Pago
    Public Sub CargaCondicionPago(ByVal cia As Integer, ByVal fp As Integer, ByVal cmbCONDICION_PAGO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO " & cia & ", " & fp & ", " & 2 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCONDICION_PAGO.DataSource = Table
            cmbCONDICION_PAGO.ValueMember = "Condición Pago"
            cmbCONDICION_PAGO.DisplayMember = "Descripción Pago"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Unidad de Medida
    Public Sub CargaUnidadMedida(ByVal cia As Integer, ByVal cmbUNIDAD_MEDIDA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA " & cia & ", " & 2 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbUNIDAD_MEDIDA.DataSource = Table
            cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            cmbUNIDAD_MEDIDA.DisplayMember = "Descripción Unidad"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Grupos
    Public Sub CargaGrupos(ByVal cia As Integer, ByVal cmbGRUPO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_CATALOGO_GRUPOS " & cia & ", " & 2 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbGRUPO.DataSource = Table
            cmbGRUPO.ValueMember = "Grupo"
            cmbGRUPO.DisplayMember = "Descripción_Grupo"
            cmbGRUPO.SelectedValue = 999
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de Caja Chica
    Public Sub CargaCajaChica(ByVal cia As Integer, ByVal libroCont As Integer, ByVal cmbCAJA_CHICA As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CAJA_CHICA " & cia & "," & libroCont & ", " & 2 & ""
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbCAJA_CHICA.DataSource = Table
            cmbCAJA_CHICA.ValueMember = "CC"
            cmbCAJA_CHICA.DisplayMember = "Caja Chica"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de los Rubros de Caja Chica
    Public Sub CargaRubroCC(ByVal cia As Integer, ByVal libroCont As Integer, ByVal cc As Integer, ByVal cmbRUBRO_CC As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CAJA_CHICA_RUBROS "
            sql &= cia
            sql &= "," & libroCont
            sql &= ", " & cc
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", ''"
            sql &= ", 0" 'PERIODO, No se ocupa acá
            sql &= ", " & 4
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbRUBRO_CC.DataSource = Table
            cmbRUBRO_CC.ValueMember = "Rubro"
            cmbRUBRO_CC.DisplayMember = "Descripción Rubro"
            If Table.Rows.Count <> 0 Then
                RubroRetencion = Table.Rows(0).Item("Rubro Retención").ToString
                RubroPrestamo = Table.Rows(0).Item("Rubro Préstamo").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el ComboBox de los Periodos de Liquidación de Caja Chica
    Public Sub CargaPeriodosCC(ByVal cia As Integer, ByVal lc As Integer, ByVal cc As Integer, ByVal cmbPERIODO_CC As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CAJA_CHICA_LIQUIDACION "
            sql &= cia
            sql &= "," & lc
            sql &= ", " & cc
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", '" & Format(Now, "Short Date") & "'"
            sql &= ", '" & Format(Now, "Short Date") & "'"
            sql &= ", " & 1
            sql &= ", " & 3
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbPERIODO_CC.DataSource = Table
            cmbPERIODO_CC.ValueMember = "Período"
            cmbPERIODO_CC.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Llena el combobox del catalogo de usuarios de la base de datos
    Public Sub CargaUsuarios(ByVal cia As Integer, ByVal cmbUSUARIO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CATALOGO_USUARIOS " & cia & ", '', '', 0 "
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbUSUARIO.DataSource = Table
            cmbUSUARIO.ValueMember = "USUARIO"
            cmbUSUARIO.DisplayMember = "USUARIO_COMPLETO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Carga los origines
    Public Sub CargaOrigenes(ByVal cia As Integer, ByVal cmbORIGENES As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_COOPERATIVA_CATALOGO_ORIGENES " & cia & ", 1 "
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbORIGENES.DataSource = Table
            cmbORIGENES.ValueMember = "ORIGEN"
            cmbORIGENES.DisplayMember = "DESCRIPCION_ORIGEN"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Carga los origines sólo terceros
    Public Sub CargaOrigenesTerceros(ByVal cia As Integer, ByVal cmbORIGENES As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_COOPERATIVA_CATALOGO_ORIGENES " & cia & ", 1 "
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbORIGENES.DataSource = Table
            cmbORIGENES.ValueMember = "ORIGEN"
            cmbORIGENES.DisplayMember = "DESCRIPCION_ORIGEN"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Carga los paises, los departamentos y los municipios
    Public Sub cargaPaisDptosMunicipios(ByVal pais As Integer, ByVal dpto As Integer, ByVal flag As Integer, ByVal cmb As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_PAISES_MUNICIPIOS_DEPARTAMENTOS "
            sql &= pais
            sql &= ", " & dpto
            sql &= ", " & flag
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmb.DataSource = Table
            cmb.ValueMember = "Código"
            cmb.DisplayMember = "Nombre"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Funcion para llenar el datatable
    Public Function LlenaDT(ByVal con, ByVal da, ByVal cmd, ByVal sql, ByVal table)
        cmd = New SqlCommand(sql, con)
        cmd.CommandTimeout = 7200
        da = New SqlDataAdapter(cmd)
        table = New DataTable("Datos")
        da.Fill(table)
        Return table
    End Function

    'Funcion para llenar el dataset
    Public Function LlenaDS(ByVal con, ByVal da, ByVal cmd, ByVal sql, ByVal ds)
        cmd = New SqlCommand(sql, con)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "Datos")
        Return ds
    End Function

    'Ajusta automaticamente el ancho de cada columna de un datagridview
    Public Sub ajustarGrid(ByVal numcolumns As Integer, ByVal dgv As DataGridView)
        'AJUSTE DE COLUMNAS - INICIO
        For i As Integer = 1 To numcolumns
            dgv.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        'AJUSTE DE COLUMNAS - FIN
        'Asignación de nombre de columnas para datagridview's con el nombre de dgPartidas y con 10 columnas
        If dgv.Name = "dgvPartidas" And numcolumns = 10 Then
            dgv.Columns.Item(0).HeaderText = "Transacción"
            dgv.Columns.Item(1).HeaderText = "Fecha"
            dgv.Columns.Item(2).HeaderText = "Tipo Documento"
            dgv.Columns.Item(3).HeaderText = "Nº Documento"
            dgv.Columns.Item(4).HeaderText = "Nº Partida"
            dgv.Columns.Item(5).HeaderText = "Concepto"
            dgv.Columns.Item(6).HeaderText = "Anulada"
            dgv.Columns.Item(7).HeaderText = "Anulada por"
            dgv.Columns.Item(8).HeaderText = "Usuario Creación"
            dgv.Columns.Item(9).HeaderText = "Fecha Creación"
        End If
    End Sub

    Public Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            sql &= ",@AÑO            = " & Año & vbCrLf
            sql &= ",@MES            = " & Mes & vbCrLf
            sql &= ",@ULTIMO         = 0"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("ULTIMO")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Public Sub anulacionPartida(ByVal Compañia, ByVal Transaccion, ByVal TransaccionAnulada, ByVal PartidaAnulada, ByVal FechaAnulacion)
        Dim res As Integer = 0
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_PARTIDAS_ANULACION "
            sql &= Compañia
            sql &= ", " & Transaccion
            sql &= ", " & TransaccionAnulada
            sql &= ", " & PartidaAnulada
            sql &= ", '" & FechaAnulacion & "'"
            sql &= ", '" & Usuario & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res > 0 Then
                MsgBox("Anulación partida realizada con exito", MsgBoxStyle.Information, "Mensaje")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Valida que en un textbox solo ingresen numeros
    Function soloNumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If InStr("0123456789" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return e
    End Function

    'Valida que en un textbox solo ingresen numeros
    Function soloNumerosPuntos(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If InStr("0123456789." & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return e
    End Function

    'Valida que en un textbox solo ingresen letras
    Function soloLetras(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8) & Chr(32), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return e
    End Function

    'Valida que en un textbox solo ingresen letras
    Function noComillaSimple(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If InStr("'", e.KeyChar) <> 0 Then
                e.KeyChar = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return e
    End Function

    'Limpia datagridview's
    Public Sub limpiargrid(ByVal dgv As DataGridView)
        Try
            dgv.Focus()
            For i As Integer = 0 To dgv.Rows.Count - 1
                'dgv.Rows.Remove(dgv.CurrentRow)
                dgv.Rows.Remove(dgv.Rows.Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Public Sub validarChk(ByVal i As Integer, ByVal chk As CheckBox, ByVal dgv As DataGridView)
        If dgv.CurrentRow.Cells.Item(i).Value = True Then
            chk.CheckState = CheckState.Checked
        Else
            chk.CheckState = CheckState.Unchecked
        End If
    End Sub

    'Metodo que devuelve o el banco o el origen
    Public Function devuelveBcoOrigen(ByVal cia As Integer, ByVal buxis As Integer, ByVal codAS As String, ByVal flag As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_VALORES_REMESAS "
            sql &= cia
            sql &= ", " & buxis
            sql &= ", '" & codAS & "'"
            sql &= ", 0"
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                Return DataReader_.Item("Valor")
            Else
                Return 0
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
        Return 0
    End Function

    Public Sub mttoChequesProgSolicitudes(ByVal cia As Integer, ByVal cheque As Integer, ByVal interes As Double, ByVal seguro As Double _
                                          , ByVal total As Double, ByVal fecha As Date, ByVal solicitud As Integer, ByVal codBuxis As Integer _
                                          , ByVal codAS As String, ByVal periodo As String, ByVal bco As Integer, ByVal cta As Integer _
                                          , ByVal ctaBco As String, ByVal chequera As Integer, ByVal lc As Integer, ByVal flag As String, ByVal nombre As String, ByVal papel As Double)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES_IUD "
            sql &= "  @COMPAÑIA = " & cia
            sql &= ", @CHEQUE = " & cheque
            sql &= ", @INTERES = " & interes
            sql &= ", @SEGURO = " & seguro
            sql &= ", @TOTAL = " & total
            sql &= ", @FECHA_CONTABLE = '" & Format(fecha, "dd-MM-yyyy HH:mm:ss") & "'"
            sql &= ", @SOLICITUD = " & solicitud
            sql &= ", @CODIGO_EMPLEADO = " & codBuxis
            sql &= ", @CODIGO_EMPLEADO_AS = '" & codAS & "'"
            sql &= ", @PERIODO = '" & periodo & "'"
            sql &= ", @BANCO = " & bco
            sql &= ", @CUENTA = " & cta
            sql &= ", @CUENTA_BANCARIA = '" & ctaBco & "'"
            sql &= ", @CHEQUERA = " & chequera
            sql &= ", @LIBRO_CONTABLE = " & lc
            sql &= ", @USUARIO = '" & Usuario & "'"
            sql &= ", @TOTAL_FORMATO = '" & MontoFin & "'"
            sql &= ", @TOTAL_LETRAS_L1 = '" & Linea1 & "'"
            sql &= ", @TOTAL_LETRAS_L2 = '" & Linea2 & "'"
            sql &= ", @BANDERA = '" & flag & "'"
            sql &= ", @A_NOMBRE_DE = '" & nombre & "'"
            sql &= ", @PAPELERIA = '" & papel & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Public Sub mttoRemesasProgSolicitudes(ByVal cia As Integer, ByVal remesa As Integer, ByVal solicitud As Integer, ByVal codBuxis As Integer _
                                          , ByVal codAS As String, ByVal monto As Double, ByVal bco As Integer, ByVal ctaBco As String _
                                          , ByVal fecha As Date, ByVal ubicacion As Integer, ByVal flag As String, ByVal Bloque As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS_IUD "
            sql &= cia
            sql &= ", " & remesa
            sql &= ", " & solicitud
            sql &= ", " & codBuxis
            sql &= ", '" & codAS & "'"
            sql &= ", " & monto
            sql &= ", " & bco
            sql &= ", '" & ctaBco & "'"
            sql &= ", '" & Format(fecha, "dd-MM-yyyy HH:mm:ss") & "'"
            sql &= ", " & ubicacion
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & flag & "'"
            sql &= ", " & Bloque
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Carga los bancos bajo otros parametros
    Public Sub CargaBancos2(ByVal Compañia As Integer, ByVal cmbBANCO As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            sql &= Compañia
            sql &= ", 0"
            sql &= ", 3"
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbBANCO.DataSource = Table
            cmbBANCO.ValueMember = "Banco"
            cmbBANCO.DisplayMember = "Nombre Banco"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Carga los meses del año, numero y descripción respectivamente
    Public Sub CargaMeses(ByVal cmbMESES As ComboBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_MESES "
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            cmbMESES.DataSource = Table
            cmbMESES.ValueMember = "Mes"
            cmbMESES.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'LOS SIGUIENTES METODOS SE UTILIZAN PARA LOS REPORTES PARA GENERAR CHEQUES O REMESAS POR PAGO DE PRESTAMOS
    'Carga el reporte
    Public Function cargaRPT_RCR(ByVal Company_Value As Integer, ByVal Documento As Integer, ByVal Banco As Integer, ByVal CondicionFecha As Integer _
                         , ByVal FechaDoc As Date, ByVal NumChequeRem As Integer, ByVal Negociable As Integer, ByVal Bandera As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES_REMESAS "
            sql &= Company_Value
            sql &= ", " & Documento
            sql &= ", " & Banco
            sql &= ", " & CondicionFecha
            sql &= ", '" & Format(FechaDoc, "dd-MM-yyyy HH:mm:ss") & "'"
            sql &= ", " & NumChequeRem
            sql &= ", " & Negociable
            'sql &= ", '" & Linea1 & "'"
            'sql &= ", '" & Linea2 & "'"
            'sql &= ", '" & MontoFin & "'"
            sql &= ", " & Bandera
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            Return Table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Table
    End Function

    'Metodo que hace las lineas del monto en concepto de letras
    Public Sub creaLineas_RCR()
        'Llama al metodo Letras de la clase NumeroLetras instanciada como NL, luego con replace
        'quita la palabra DÓLARES ya que ésta misma clase se usa para el concepto de las facturas
        'y ahi se utiliza esa palabra pero en caso de los cheques no es necesario
        Dim cadena As String = Trim(Regex.Replace(NL.Letras(Monto.ToString), "US DOLARES", ""))
        'Se usa esta variable para indicar donde esta un espacio antes de que se divida en dos
        'el concepto en letras del monto
        Dim espacio As String = "-1"
        'Obtenemos el largo de la cadena
        Dim largoCadena As Integer = cadena.Length
        'Cada línea es de 50 caracteres, con esta variable sacamos la diferencia para la 2da linea
        Dim diferencia50 As Integer = 0
        'Comprobammos si a cadena mide exactamente 50 caracteres
        If largoCadena = 50 Then
            'Si es asì le agregamos un par de asteriscos para legalizar el concepto a modo que
            'no alteren el concepto
            Linea1 = cadena & "**"
            'Dejamos en blanco la linea 2
            Linea2 = ""
            'Caso contrario comprobamos si la cadena mide menos de 50 caracteres
        ElseIf largoCadena < 50 Then
            'Sacamos la diferencia
            diferencia50 = 50 - largoCadena
            'Guardamos la cadena entera en la linea1
            Linea1 = cadena
            'Agregamos los asteriscos necesarios a la linea1
            For i As Integer = 0 To diferencia50 - 1
                Linea1 &= "*"
            Next
            'Dejamos la linea2 en blanco
            Linea2 = ""
            'Caso contrario comprobamos si la cadena es mayor de 50 caracteres
        ElseIf largoCadena > 50 Then
            'Comprobamos si la ultima letra es un espacio
            If Mid(cadena, 50, 1) = " " Then
                'Si es así guardamos en la 1era linea la cadena hasta el espacio 49
                Linea1 = Mid(cadena, 1, 49)
                'Guardamos en la linea dos el resto de a cadena la cadena
                Linea2 = Mid(cadena, 51, largoCadena - 50)
                'Caso contrario qu no sea un espacio el caracter de la posicion 50
            Else
                'Buscamos el espacio más proximo
                For i As Integer = 50 To 1 Step -1
                    If Mid(cadena, i, 1) = " " Then
                        'Si encuentra el espacio guarda la posicion y se sale del for
                        espacio = i
                        Exit For
                    End If
                Next
                'Hala para la primera linea toda la cadena hasta el ultimo espacio encontrado
                Linea1 = Mid(cadena, 1, espacio)
                'Luego hala para la linea2 el resto de la cadena
                Linea2 = Mid(cadena, espacio + 1, largoCadena - espacio)
            End If
            'Procedemos a agragar los * que sean necesarios a la linea2
            diferencia50 = 50 - Linea2.Length
            'Si es menor de 50 agrega los asteriscos necesarios
            If Linea2.Length < 50 Then
                For i As Integer = 0 To diferencia50 - 1
                    Linea2 &= "*"
                Next
                'Caso contrario es igual a 50 entonces agrega 2 asteriscos por seguridad
            ElseIf Linea2.Length = 50 Then
                Linea2 &= "**"
            End If
        End If
        Linea1 = Linea1.Replace("*", "").Trim
        Linea2 = Linea2.Replace("*", "").Trim
    End Sub

    'Metodo que le da el formato al monto
    Public Sub daFormatoMonto_RCR()
        'Guarda el largo de la cadena, obteniendo solo el largo de la cifra entera no la decimal
        Dim largo As Integer = Mid(Format(Monto, "0.00"), 1, Format(Monto, "0.00").Length - 3).Length
        'Iguala a nada la variable que almacenara e monto con formato
        MontoFin = Nothing
        'Dependiendo del largo que tenga y los espacios libres es que agregara los *
        For i As Integer = 0 To ((6 - largo) - 1)
            MontoFin &= "*"
        Next
        'Si el largo de la cadena es menor o igual 3
        If largo <= 3 Then
            'Agrega un asterisco más que es el de la coma de los miles
            MontoFin &= "*"
            'Agrega el monto ya con formato de 2 decimales
            MontoFin &= Format(Monto, "0.00")
        ElseIf largo > 3 And largo <= 6 Then
            'Si el largo de la cadena es mayor a 3 pero menor o igual a 6 entonces
            'Le aplica el formato de los miles
            MontoFin &= Format(Monto, "0,000.00")
        End If
    End Sub

    'Metodo que permite el autocomplete para los productos
    Public Sub autocomplete(ByVal cia As Integer, ByVal grupo As Integer, ByVal descripcion As String _
                            , ByVal flag As Integer, ByVal txt As TextBox)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            'Creamos la consulta
            sql = "Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS "
            sql &= cia
            sql &= "," & grupo
            sql &= ", '" & descripcion & "'"
            sql &= "," & flag
            'Llenamos el datatable
            DS = LlenaDS(Conexion_, DataAdapter_, Comando_, sql, DS)
            Conexion_.Close()
            'Creamos el objeto para autocompletar
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            'Asignamos los valores al dataset
            For i = 0 To DS.Tables(0).Rows.Count - 1
                col.Add(DS.Tables(0).Rows(i)("Valor").ToString())
            Next
            'Asignamos el autocomplete
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt.AutoCompleteCustomSource = col
            txt.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

End Class