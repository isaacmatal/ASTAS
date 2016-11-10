Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Contabilidad_Partidas
    'Dim oExcelApp = CreateObject("ADODB.Connection")
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass
    Dim LineaMod As Integer
    Dim TipoCat As Integer
    Dim CuentaMod, DetalleMod As Integer

    Private Sub Contabilidad_Partidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compañia)
        CargaTipoDocumento(Compañia)
        CargaTipoPartida(Compañia)
        Iniciando = False
        'Valores iniciales para el cuadro de diálogo buscar archivo
        Me.dgvPartidas.AutoGenerateColumns = False
        Me.OpenFileDialogAbrir.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Me.cmbCARGO_ABONO.SelectedIndex = 0
        Me.txtPARTIDA.Focus()
        SendKeys.Send("{TAB}")

        If Me.txtPARTIDA.Text.Length > 0 Then
            Me.NotifyIcon1.BalloonTipText = "INGRESE LOS CARGOS PARA LA PARTIDA"
            Me.NotifyIcon1.Visible = True
            Me.NotifyIcon1.ShowBalloonTip(5)
        End If
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE @COMPAÑIA = " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoDocumento(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO @COMPAÑIA = " & Compañia & ", @BANDERA = 3"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_DOCUMENTO.DataSource = Table
            Me.cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoPartida(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_TIPO_PARTIDA @COMPAÑIA = " & Compañia & ", @BANDERA = 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_PARTIDA.DataSource = Table
            Me.cmbTIPO_PARTIDA.ValueMember = "TIPO_PARTIDA"
            Me.cmbTIPO_PARTIDA.DisplayMember = "DESCRIPCION_TIPO_PARTIDA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCuenta(ByVal Compañia, ByVal LC, ByVal CuentaCompleta, ByVal DescripcionCuenta, ByVal Bandera) As String
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim CodCuenta As String
        CodCuenta = ""
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CUENTAS_VALIDACION " & vbCrLf
            Sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE   = " & LC & vbCrLf
            Sql &= ",@CUENTA_COMPLETA  = '" & CuentaCompleta & "'" & vbCrLf
            Sql &= ",@DESCRIPCION_CUENTA = '" & DescripcionCuenta & "'" & vbCrLf
            Sql &= ",@BANDERA          = " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                If DataReader_.Item("Mayor") = False Then
                    CodCuenta = DataReader_.Item("Correlativo")
                    TipoCat = DataReader_.Item("CATALOGO")
                Else
                    MsgBox("¡La Cuenta " & CuentaCompleta & " es cuenta de Mayor en el Catálogo de Cuentas! Verifique" & vbCrLf & "No se ha cargado registro.", MsgBoxStyle.Critical, "Validación")
                End If
            Else
                MsgBox("¡La Cuenta " & CuentaCompleta & " no existe en el Catálogo de Cuentas! Verifique" & vbCrLf & "No se ha cargado registro.", MsgBoxStyle.Critical, "Validación")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return CodCuenta
    End Function

    Private Sub EliminaDetalleTransaccion(ByVal Compañia As Integer, ByVal Transaccion As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "DELETE CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION  = " & Transaccion
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("¡Error al eliminar líneas de detalle de la Transacción!", MsgBoxStyle.Critical, "Error")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LlenaGrid_Excel(ByVal Hoja_Excel)
        Dim Conexion_Excel As New OleDbConnection
        Dim Comando_Excel As New OleDbCommand
        Dim DataAdapter_Excel As New OleDbDataAdapter
        Dim Table As New DataTable
        Dim CadenaCnn, Codigo, CodCuenta, CuentaCompleta, Concepto As String
        Dim CarAbo As String = String.Empty
        Dim Valor As Decimal = 0
        Dim _error_ As Boolean = False
        Try
            'CadenaCnn = "Provider=Microsoft.Jet.Oledb.4.0; data source= " + Me.lblArchivoExcel.Text + " ;Extended properties=Excel 8.0;"
            CadenaCnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.lblArchivoExcel.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
            Conexion_Excel = New OleDbConnection(CadenaCnn)
            Conexion_Excel.Open()
            'Inserta Líneas de Partida en "CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO"
            Sql = "SELECT CUENTA"
            Sql &= ", CODIGO"
            Sql &= ", CONCEPTO"
            Sql &= ", CARGO"
            Sql &= ", ABONO"
            Sql &= " FROM [" & Hoja_Excel & "$]"
            Comando_Excel = New OleDbCommand(Sql, Conexion_Excel)
            DataAdapter_Excel.SelectCommand = Comando_Excel
            DataAdapter_Excel.Fill(Table)
            Conexion_Excel.Close()
            Conexion_Excel.Dispose()
            If Table.Rows.Count = 0 Then
                MsgBox("¡El archivo de Excel está vacío! Verifique...", MsgBoxStyle.Critical, "Archivo Excel")
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Carga Excel")
            _error_ = True
        Finally
            Conexion_Excel.Close()
            Conexion_Excel.Dispose()
        End Try
        If _error_ Then
            Return
        End If
        Try
            CodCuenta = ""
            Iniciando = True
            For i As Integer = 0 To Table.Rows.Count - 1
                If Iniciando = True Then
                    EliminaDetalleTransaccion(Compañia, Me.txtTRANSACCION.Text)
                    Iniciando = False
                End If
                If Not IsDBNull(Table.Rows(i).Item("CUENTA")) Then
                    CuentaCompleta = Table.Rows(i).Item("CUENTA").ToString.Trim
                    CodCuenta = ValidaCuenta(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, CuentaCompleta, "", 1)
                    If CodCuenta <> "" Then
                        If IsDBNull(Table.Rows(i).Item("CARGO")) Then
                            CarAbo = "A"
                            If IsDBNull(Table.Rows(i).Item("ABONO")) Then
                                Valor = 0
                            Else
                                Valor = Table.Rows(i).Item("ABONO")
                            End If
                        Else
                            If Table.Rows(i).Item("CARGO") = 0 Then
                                CarAbo = "A"
                                If IsDBNull(Table.Rows(i).Item("ABONO")) Then
                                    Valor = 0
                                Else
                                    Valor = Table.Rows(i).Item("ABONO")
                                End If
                            Else
                                CarAbo = "C"
                                Valor = Table.Rows(i).Item("CARGO")
                            End If
                        End If
                        If IsDBNull(Table.Rows(i).Item("CODIGO")) Then
                            Codigo = "0"
                        Else
                            Codigo = Table.Rows(i).Item("CODIGO")
                        End If
                        If Codigo = "0" And TipoCat > 0 Then
                            _error_ = True
                            MsgBox("Error en línea " & (i + 2).ToString() & vbCrLf & "La cuenta " & CuentaCompleta & " está asociada a un catálogo" & vbCrLf & "pero el codigo detalle es cero." & vbCrLf & vbCrLf & "La línea " & (i + 2).ToString() & " no se guardó.", MsgBoxStyle.Information, "Carga desde Excel")
                        End If
                        If IsDBNull(Table.Rows(i).Item("CONCEPTO")) Then
                            Concepto = "Sin Concepto"
                        Else
                            Concepto = Table.Rows(i).Item("CONCEPTO").ToString().Replace("'", "*")
                        End If
                        If Not _error_ Then
                            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 0, Codigo, _
                                CodCuenta, Concepto, CarAbo, Valor, "E")
                        End If
                    End If
                End If
                _error_ = False
            Next
            'Inserta Líneas de Partida en "CONTABILIDAD_PARTIDAS_DETALLE"
            'Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 0, 0, CodCuenta, Me.txtCONCEPTO.Text, CarAbo, Valor, "A")
            Hay_Datos = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Carga Archivo Excel")
        End Try
    End Sub

    Private Sub LimpiaCamposEncabezado()
        Me.txtTRANSACCION.Text = ""
        Me.txtPARTIDA.Text = ""
        Me.txtDOCUMENTO.Text = ""
        Me.txtCONCEPTO.Text = ""
        Me.dpFECHA_CONTABLE.MinDate = CDate("01/01/1900")
        Me.dpFECHA_CONTABLE.MaxDate = CDate("01/01/9998")
        Me.dpFECHA_CONTABLE.Value = Now
        Me.lblAnulada.Visible = False
        Me.lblTransaccionAnula.Visible = False
        Me.lblTransaccionAnula.Text = ""
    End Sub

    Private Sub LimpiaCamposLinea()
        LineaMod = 0
        DetalleMod = 0
        CuentaMod = 0
        Me.lblCuenta.Text = "0"
        Me.txtCUENTA_COMPLETA.Clear()
        Me.txtCodDetalle.Clear()
        Me.txtMONTO.Clear()
        Me.txtCONCEPTO_L.Clear()
        TipoCat = 0
    End Sub

    Private Sub LimpiaCamposTotales()
        Me.txtCARGOS.Text = ""
        Me.txtABONOS.Text = ""
        Me.txtDIFERENCIA.Text = ""
    End Sub

    Private Function ValidaCampos_Encabezado() As Boolean
        If Me.txtDOCUMENTO.Text.Length = 0 Then
            Me.txtDOCUMENTO.Text = "0"
        End If
        If Trim(Me.txtCONCEPTO.Text) = "" Then
            MsgBox("¡Debe ingresar un Concepto General válido! Verifique", MsgBoxStyle.Critical, "Concepto Vacío")
            Return False
        End If
        Return True
    End Function

    Private Function ValidaCampos_Linea() As Boolean
        If Trim(Me.txtTRANSACCION.Text) = "" Or Trim(Me.txtTRANSACCION.Text) = " 0" Then
            MsgBox("¡Debe seleccionar una partida contable válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.txtCUENTA_COMPLETA.Text) = "" Then
            MsgBox("¡Debe seleccionar una Cuenta Contable válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.txtCONCEPTO_L.Text) = "" Then
            MsgBox("¡Debe ingresar uiun Concepto válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.txtMONTO.Text) = "" Or Val(Me.txtMONTO.Text) <= 0 Then
            MsgBox("¡Debe ingresar un Monto válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.cmbCARGO_ABONO.Text) = "" Then
            MsgBox("¡Debe seleccionar si el monto será Cargo o Abono a la cuenta contable! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If TipoCat > 0 And Val(Me.txtCodDetalle.Text) = 0 Then
            If MsgBox("La Cuenta Contable tiene un Catálogo de Detalle Asociado" & vbCrLf & "pero no se ha ingresado un código detallle " & vbCrLf & "para este movimiento" & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Return False
            Else
                Return True
            End If
        End If
            Return True
    End Function

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@ULTIMO         = 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
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

    Private Sub HabilitaCamposTransaccionE(ByVal Bandera)
        'Me.cmbLIBRO_CONTABLE.Enabled = Bandera
        Me.cmbTIPO_DOCUMENTO.Enabled = Bandera
    End Sub

    Private Sub HabilitaDeshabilita(ByVal Bandera)
        'Me.cmbCOMPAÑIA.Enabled = Bandera
        'Me.cmbLIBRO_CONTABLE.Enabled = Bandera
        'Me.cmbTIPO_DOCUMENTO.Enabled = Bandera
        'Me.cmbTIPO_PARTIDA.Enabled = Bandera

        Me.btnGuardar.Enabled = Bandera
        Me.btnGuardarLinea.Enabled = Bandera
        'Me.btnBuscarPartida.Enabled = Bandera
        Me.btnProcesarPartida.Enabled = Bandera
        Me.btnBuscarExcel.Enabled = Bandera
        Me.btnImportarExcel.Enabled = Bandera
        'Me.cmbLIBRO_CONTABLE.Enabled = Bandera
        Me.cmbTIPO_DOCUMENTO.Enabled = Bandera
        Me.cmbTIPO_PARTIDA.Enabled = Bandera
        Me.txtDOCUMENTO.Enabled = Bandera
        Me.dpFECHA_CONTABLE.Enabled = Bandera
        Me.txtCONCEPTO.Enabled = Bandera
        Me.gbImportar.Enabled = Bandera
        Me.btnActualizarDetalle.Enabled = Bandera
        Me.btnEliminarDetalle.Enabled = Bandera

    End Sub

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO = " & Año & vbCrLf
            Sql &= ",@MES = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            Sql &= ",@PROCESADO = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") Then
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
                If Datareader_.Item("CIERRE_FINAL") Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
                If Datareader_.Item("PRE_CIERRE") Then
                    If Not ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Function

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            Sql &= ",@PROCESADO      = 0" & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub Mantenimiento_TransaccionE(ByVal Compañia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            Sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            Sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            Sql &= ",@PARTIDA        = " & Partida & vbCrLf
            Sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@ANULADA        = " & Anulada & vbCrLf
            Sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Select Case IUD
                Case "I"
                    MsgBox("¡Partida Reservada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.dpFECHA_CONTABLE.MinDate = FechaContable.AddDays(-FechaContable.Day).AddDays(1)
                    Me.dpFECHA_CONTABLE.MaxDate = CDate(Date.DaysInMonth(FechaContable.Year, FechaContable.Month) & Format(FechaContable, "/MM/yyyy"))
                Case "U"
                    MsgBox("¡Partida Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Partida Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Private Sub Procesa_Transaccion(ByVal Compañia, ByVal LibroContable, ByVal Transaccion)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            'Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR " & vbCrLf
            'Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            'Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            'Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            'Sql &= ",@USUARIO        = '" & Usuario & "'"
            Sql = "UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO " & vbCrLf
            Sql &= " SET PROCESADO = 1, USUARIO_EDICION = '" & Usuario & "', USUARIO_EDICION_FECHA = GETDATE()" & vbCrLf
            Sql &= " WHERE COMPAÑIA  = " & Compañia & vbCrLf
            Sql &= "  AND TRANSACCION    = " & Transaccion
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Private Sub Mantenimiento_TransaccionL(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LINEA          = " & Linea & vbCrLf
            Sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            Sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            Sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'" & vbCrLf
            Sql &= ",@CUENTANEW	     = " & CuentaMod & vbCrLf
            Sql &= ",@DETALLENEW     = " & DetalleMod & vbCrLf
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Private Sub BuscaTransaccion(ByVal Transaccion As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Dim fechaContable As Date
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@TRANSACCION = " & Transaccion & vbCrLf
            Sql &= ",@BANDERA = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Me.cmbLIBRO_CONTABLE.SelectedValue = DataReader_.Item("LIBRO_CONTABLE")
                Me.cmbTIPO_DOCUMENTO.SelectedValue = DataReader_.Item("TIPO_DOCUMENTO")
                Me.txtDOCUMENTO.Text = DataReader_.Item("DOCUMENTO")
                Me.cmbTIPO_PARTIDA.SelectedValue = DataReader_.Item("TIPO_PARTIDA")
                Me.txtPARTIDA.Text = DataReader_.Item("PARTIDA")
                fechaContable = CDate(DataReader_.Item("FECHA_CONTABLE"))
                Me.dpFECHA_CONTABLE.MinDate = fechaContable.AddDays(-fechaContable.Day).AddDays(1) 'CDate("01/" & fechaContable.Month.ToString.PadLeft(2, "0") & "/" & fechaContable.Year.ToString)
                Me.dpFECHA_CONTABLE.MaxDate = fechaContable.AddDays(-fechaContable.Day).AddDays(1).AddMonths(1).AddDays(-1) 'CDate(Date.DaysInMonth(fechaContable.Year, fechaContable.Month).ToString.PadLeft(2, "0") & "/" & fechaContable.Month.ToString.PadLeft(2, "0") & "/" & fechaContable.Year.ToString)
                Me.dpFECHA_CONTABLE.Value = DataReader_.Item("FECHA_CONTABLE")
                Me.txtCONCEPTO.Text = DataReader_.Item("CONCEPTO")
                If DataReader_.Item("ANULADA") = True Then
                    Me.lblAnulada.Visible = True
                    Me.lblTransaccionAnula.Visible = True
                    Me.lblTransaccionAnula.Text = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & DataReader_.Item("TRANSACCION_ANULA")).ToString()
                Else
                    Me.lblAnulada.Visible = False
                    Me.lblTransaccionAnula.Visible = False
                    Me.lblTransaccionAnula.Text = ""
                End If
                Me.chkProcesada.Checked = DataReader_.Item("PROCESADO")
            Else
                MsgBox("No existe la PARTIDA N° " & Me.txtPARTIDA.Text, MsgBoxStyle.Critical, "Búsqueda")
                LimpiaCamposEncabezado()
                LimpiaCamposLinea()
                LimpiaCamposTotales()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPartida_Detalle(ByVal Cia As Integer, ByVal Libro As Integer, ByVal Transaccion As Integer, ByVal Bandera As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Cia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@BANDERA        = " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPartidas.DataSource = Table
            'LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPartida_Diferencia(ByVal Cia As Integer, ByVal Libro As Integer, ByVal Transaccion As Integer, ByVal Bandera As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@BANDERA        = " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Me.txtCARGOS.Text = Format(DataReader_.Item("CARGOS"), "0.00")
                Me.txtABONOS.Text = Format(DataReader_.Item("ABONOS"), "0.00")
                Me.txtDIFERENCIA.Text = Format(DataReader_.Item("DIFERENCIA"), "0.00")
            Else
                Me.txtCARGOS.Text = ""
                Me.txtABONOS.Text = ""
                Me.txtDIFERENCIA.Text = ""
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvPartidas.Columns.Item(0).Width = 50 'Correlativo
        Me.dgvPartidas.Columns.Item(1).Width = 50 'Codigo Cuenta Contable
        Me.dgvPartidas.Columns.Item(2).Width = 100 'Cuenta Completa
        Me.dgvPartidas.Columns.Item(3).Width = 100 'cod detalle
        Me.dgvPartidas.Columns.Item(4).Width = 150 'Descripción Cuenta
        Me.dgvPartidas.Columns.Item(5).Width = 150 'Concepto
        Me.dgvPartidas.Columns.Item(6).Width = 75 'Cargo
        Me.dgvPartidas.Columns.Item(7).Width = 75 'Abono
        Me.dgvPartidas.Columns.Item(8).Width = 50 'Transaccion
        Me.dgvPartidas.Columns(0).Visible = False
        Me.dgvPartidas.Columns(1).Visible = False
        'Me.dgvPartidas.Columns(2).Visible = False
        Me.dgvPartidas.Columns(8).Visible = False
        Me.dgvPartidas.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvPartidas.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Function ValidaProcesar() As Boolean
        If Trim(Me.txtTRANSACCION.Text) = "" Or Trim(Me.txtTRANSACCION.Text) = "0" Then
            MsgBox("¡Debe generar un N° de Transacción válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If chkProcesada.Checked Then
            MsgBox("¡No puede procesar la Partida, esta ya fué procesada. Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.dgvPartidas.Rows.Count < 1 Then
            MsgBox("¡La transacción debe tener al menos 1 línea! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Val(Me.txtCARGOS.Text) - Val(Me.txtABONOS.Text) <> 0 Then
            MsgBox("¡La partida no está cuadrada! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    ' Comienzan los Otros Sub

    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        If Trim(Me.lblArchivoExcel.Text) <> "" And Trim(Me.cmbSheets.Text) <> "" Then
            If Me.dgvPartidas.Rows.Count > 0 Then
                If MsgBox("El proceso de carga eliminará las líneas existentes de la Partida." & vbCrLf & "¿Está seguro(a) que desea importar datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.No Then
                    MsgBox("No se realizó ningún cambio.", MsgBoxStyle.Information, "Mensaje")
                    Return
                End If
            End If
            Hay_Datos = False
            LlenaGrid_Excel(Trim(Me.cmbSheets.Text))
            'Inserta Líneas de Partida en "CONTABILIDAD_PARTIDAS_DETALLE"
            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 0, 0, 0, Me.txtCONCEPTO.Text, "X", 0, "A")
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
            If Hay_Datos Then
                MsgBox("¡Proceso de carga de datos finalizado!", MsgBoxStyle.Information, "Mensaje")
            End If
            Me.lblArchivoExcel.Text = ""
            While Me.cmbSheets.Items.Count > 0
                Me.cmbSheets.Items.RemoveAt(0)
            End While
            LimpiaCamposLinea()
        Else
            If Trim(Me.lblArchivoExcel.Text) = "" Then
                MsgBox("Ingrese la ruta del archivo en Excel que cargará", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If
            If Trim(Me.cmbSheets.Text) = "" Then
                MsgBox("Ingrese el nombre de la hoja del archivo en Excel que cargará", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnBuscarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarExcel.Click
        Dim Result As Integer
        'If Val(Me.txtTRANSACCION.Text) = 0 Then
        '    Me.btnGuardar.PerformClick()
        'End If
        If Val(Me.txtTRANSACCION.Text) > 0 Then
            Result = Me.OpenFileDialogAbrir.ShowDialog()
            If Result = Windows.Forms.DialogResult.OK Then
                Me.lblArchivoExcel.Text = Me.OpenFileDialogAbrir.FileName
                ListarHojasExcel(Me.lblArchivoExcel.Text)
            Else
                MsgBox("Usuario ha CANCELADO el proceso.", MsgBoxStyle.Information, "Busqueda Archivo")
            End If
        Else
            MsgBox("¡Primero debe generar un N° de PARTIDA válido para poder importar la partida!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub ListarHojasExcel(ByVal XLSFile As String)
        Try
            Dim oExcelApp = CreateObject("EXCEL.Application")
            While Me.cmbSheets.Items.Count > 0
                Me.cmbSheets.Items.RemoveAt(0)
            End While
            oExcelApp.WorkBooks.Open(XLSFile)
            Dim oExcelSheets = oExcelApp.WorkBooks(1).Sheets
            Dim CntSheets As Integer = oExcelSheets.Count
            For i As Integer = 1 To CntSheets
                Me.cmbSheets.Items.Add(oExcelSheets(i).Name)
            Next
            oExcelApp.WorkBooks(1).Close()
            oExcelApp.Quit()
            Me.cmbSheets.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaLibrosContables(Compañia)
            CargaTipoDocumento(Compañia)
            CargaTipoPartida(Compañia)
        End If
    End Sub


    Private Sub btnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = False
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Numero = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.lblCuenta.Text = Producto
            Me.txtCUENTA_COMPLETA.Text = Tipo
            If Numero = "1" Then
                Me.cmbTIPO_PARTIDA.SelectedValue = Numero
            End If
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
            Numero = ""
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCamposEncabezado()
        LimpiaCamposLinea()
        LimpiaCamposTotales()
        HabilitaDeshabilita(True)
        Me.chkProcesada.Checked = False
        Me.dgvPartidas.DataSource = Nothing
    End Sub

    Private Sub txtMONTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMONTO.KeyPress
        Dim cadena As String = Me.txtMONTO.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.cmbCARGO_ABONO.Focus()
        End If
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCierreContable(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value), "E") Then
            If ValidaCampos_Encabezado() = True And ValidaCierreContable(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value), "C") Then
                If Me.txtTRANSACCION.Text.Trim.Length = 0 Or Val(Me.txtTRANSACCION.Text) <= 0 Then
                    Me.txtTRANSACCION.Text = GeneraCorrelativo(Compañia, "TRA", Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToString
                    Me.txtPARTIDA.Text = GeneraCorrelativo(Compañia, "PAR", Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToString
                    Mantenimiento_TransaccionE(Compañia, Me.txtTRANSACCION.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Trim(Me.txtDOCUMENTO.Text), Me.cmbTIPO_PARTIDA.SelectedValue, Me.txtPARTIDA.Text, Me.dpFECHA_CONTABLE.Value, Trim(Me.txtCONCEPTO.Text), "0", "0", "I")
                Else
                    If Val(Me.txtPARTIDA.Text) = 0 Then
                        Me.txtPARTIDA.Text = GeneraCorrelativo(Compañia, "PAR", Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToString
                    End If
                    Mantenimiento_TransaccionE(Compañia, Me.txtTRANSACCION.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Trim(Me.txtDOCUMENTO.Text), Me.cmbTIPO_PARTIDA.SelectedValue, Val(Me.txtPARTIDA.Text), Me.dpFECHA_CONTABLE.Value, Trim(Me.txtCONCEPTO.Text), IIf(Me.lblAnulada.Visible = True, "1", "0"), IIf(Me.lblTransaccionAnula.Visible = True, Me.lblTransaccionAnula.Text, "0"), "U")
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscarTransaccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTransaccion.Click
        If Trim(Me.txtTRANSACCION.Text) = "" Or Trim(Me.txtTRANSACCION.Text) = "0" Then
            Dim Transacciones As New Contabilidad_BusquedaTransaccion
            Transacciones.Compañia_Value = Compañia
            Transacciones.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
            Transacciones.cmbLIBRO_CONTABLE.Enabled = False
            Producto = ""
            Transacciones.ShowDialog()
            If Producto <> "" Then
                Me.txtTRANSACCION.Text = Producto
                Producto = ""
                BuscaTransaccion(Me.txtTRANSACCION.Text)
                CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
                CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
                If Me.chkProcesada.Checked Then
                    MsgBox("¡La Partida ya fue procesada!" & vbCrLf & "No podrá realizar cambios.", MsgBoxStyle.Information, "Mensaje")
                    HabilitaDeshabilita(False)
                Else
                    HabilitaDeshabilita(True)
                    HabilitaCamposTransaccionE(False)
                End If
            End If
        Else
            BuscaTransaccion(Me.txtTRANSACCION.Text)
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 1)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
            If Me.chkProcesada.Checked Then
                MsgBox("¡La Partida ya fue procesada!" & vbCrLf & "No podrá realizar cambios.", MsgBoxStyle.Information, "Mensaje")
                HabilitaDeshabilita(False)
            Else
                HabilitaDeshabilita(True)
                HabilitaCamposTransaccionE(False)
            End If
        End If
    End Sub

    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        If Val(Me.txtTRANSACCION.Text) = 0 Then
            MsgBox("¡Primero debe generar un N° de Partida válido para ingresar detalles.", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If ValidaCampos_Linea() = True Then
            If LineaMod > 0 Then
                Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, LineaMod, Val(Me.txtCodDetalle.Text), Me.lblCuenta.Text, Trim(Me.txtCONCEPTO_L.Text), Mid(Me.cmbCARGO_ABONO.Text, 1, 1), Me.txtMONTO.Text, "P")
            Else
                Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 0, Val(Me.txtCodDetalle.Text), Me.lblCuenta.Text, Trim(Me.txtCONCEPTO_L.Text), Mid(Me.cmbCARGO_ABONO.Text, 1, 1), Me.txtMONTO.Text, "E")
            End If
            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 0, Val(Me.txtCodDetalle.Text), Me.lblCuenta.Text, Trim(Me.txtCONCEPTO_L.Text), Mid(Me.cmbCARGO_ABONO.Text, 1, 1), Me.txtMONTO.Text, "A")
            LimpiaCamposLinea()
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
        End If
        If Me.dgvPartidas.Rows.Count > 0 Then
            HabilitaCamposTransaccionE(False)
        End If
        Me.txtCUENTA_COMPLETA.Focus()
    End Sub

    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        Dim Transacciones As New Contabilidad_BusquedaTransaccion
        Transacciones.Compañia_Value = Compañia
        Transacciones.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Transacciones.cmbLIBRO_CONTABLE.Enabled = False
        Transacciones.dpFECHA_INI.Value = Me.dpFECHA_CONTABLE.Value.Date.AddDays(-(Me.dpFECHA_CONTABLE.Value.Day) + 1)
        Transacciones.dpFECHA_FIN.Value = Transacciones.dpFECHA_INI.Value.AddMonths(1).AddDays(-1)
        If Trim(Me.txtPARTIDA.Text) = "" Or Trim(Me.txtPARTIDA.Text) = "0" Then
            Me.btnNuevo.PerformClick()
        End If
        Producto = ""
        Transacciones.ShowDialog(Me)
        If Producto <> "" Then
            Me.txtTRANSACCION.Text = Producto
            Producto = ""
            BuscaTransaccion(Me.txtTRANSACCION.Text)
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
            If Me.chkProcesada.Checked Then
                MsgBox("¡La Partida ya está procesada!" & vbCrLf & "No podrá realizar cambios.", MsgBoxStyle.Information, "Mensaje")
                HabilitaDeshabilita(False)
            Else
                HabilitaDeshabilita(True)
            End If
        End If
    End Sub

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        If ValidaProcesar() = True Then
            'Me.txtPARTIDA.Text = GeneraCorrelativo(Compañia, "PAR", Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToString
            If ValidaCierreContable(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.dpFECHA_CONTABLE.Value.Year, Me.dpFECHA_CONTABLE.Value.Month, "E") Then
                If MsgBox("¿Confirma que desea procesar la partida No." & Me.txtPARTIDA.Text & "?" & vbCrLf & vbCrLf & "Una vez procesada no podrá hacer cambios solamente anularla.", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                    Mantenimiento_TransaccionE(Compañia, Me.txtTRANSACCION.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Trim(Me.txtDOCUMENTO.Text), Me.cmbTIPO_PARTIDA.SelectedValue, Val(Me.txtPARTIDA.Text), Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy HH:mm:ss"), Trim(Me.txtCONCEPTO.Text), IIf(Me.lblAnulada.Visible = True, "1", "0"), IIf(Me.lblTransaccionAnula.Visible = True, Me.lblTransaccionAnula.Text, "0"), "U")
                    Procesa_Transaccion(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text)
                    BuscaTransaccion(Me.txtTRANSACCION.Text)
                    CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
                    CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
                    If Me.chkProcesada.Checked Then
                        MsgBox("¡La Transacción ya fue procesada!" & vbCrLf & "No podrá realizar cambios.", MsgBoxStyle.Information, "Mensaje")
                        HabilitaDeshabilita(False)
                    Else
                        HabilitaDeshabilita(True)
                    End If
                    Rpts.CargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.txtTRANSACCION.Text, Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value), 1)
                    Rpts.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro(a) que desea eliminar la línea seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.dgvPartidas.CurrentRow.Cells.Item(0).Value, Me.dgvPartidas.CurrentRow.Cells.Item(1).Value, "0", "", "", "0", "D")
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 1)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
        End If

    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Me.txtTRANSACCION.Text <> "0" And Me.txtTRANSACCION.Text.Trim.Length > 0 Then
            Rpts.CargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.txtTRANSACCION.Text, Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value), 1)
            Rpts.ShowDialog()
        Else
            MsgBox("¡Debe seleccionar un N° de Partida válido!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnActualizarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarDetalle.Click
        If (ValidarMonto()) Then
            If MsgBox("¿Está seguro(a) que desea actualizar el detalle de la partida?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Dim i As Integer = 0

                For i = 0 To dgvPartidas.RowCount - 1
                    Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.dgvPartidas.Rows(i).Cells.Item(0).Value, Me.dgvPartidas.Rows(i).Cells.Item(3).Value, Me.dgvPartidas.Rows(i).Cells.Item(1).Value, Trim(IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(5).Value), "", Me.dgvPartidas.Rows(i).Cells.Item(5).Value)), IIf(Trim(IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(6).Value), 0, Me.dgvPartidas.Rows(i).Cells.Item(6).Value)) = 0, "A", "C"), IIf(Trim((IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(6).Value), 0, Me.dgvPartidas.Rows(i).Cells.Item(6).Value))) = 0, Me.dgvPartidas.Rows(i).Cells.Item(7).Value, Me.dgvPartidas.Rows(i).Cells.Item(6).Value), "P")
                Next
                MsgBox("Se ha actualizado la partida exitosamente", MsgBoxStyle.Information, "Partidas")
                'CARGAMOS LOS DATOS NUEVAMENTE                
                CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
                CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
            End If
        End If
    End Sub

    Private Function ValidarMonto() As Boolean
        Dim i As Integer = 0
        Try
            For i = 0 To dgvPartidas.RowCount - 1
                If Trim(IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(6).Value), "", Me.dgvPartidas.Rows(i).Cells.Item(6).Value)) <> "" Then
                    If (Convert.ToDouble(Trim(Me.dgvPartidas.Rows(i).Cells.Item(6).Value))) <= 0 Then
                        MsgBox("El cargo para la linea " & Me.dgvPartidas.Rows(i).Cells.Item(0).Value & " debe ser mayor de cero", MsgBoxStyle.Information, "Validación")
                        Return False
                    End If
                End If
                If Trim(IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(7).Value), 0, CDbl(Me.dgvPartidas.Rows(i).Cells.Item(7).Value))) > 0 Then
                    If (Convert.ToDouble(Trim(Me.dgvPartidas.Rows(i).Cells.Item(7).Value))) <= 0 Then
                        MsgBox("El abono para la linea " & Me.dgvPartidas.Rows(i).Cells.Item(0).Value & " debe ser mayor de cero", MsgBoxStyle.Information, "Validación")
                        Return False
                    End If
                End If
                If IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(7).Value), 0, CDbl(Me.dgvPartidas.Rows(i).Cells.Item(7).Value)) = 0 And IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(6).Value), 0, CDbl(Me.dgvPartidas.Rows(i).Cells.Item(6).Value)) = 0 Then
                    MsgBox("La linea " & Me.dgvPartidas.Rows(i).Cells.Item(0).Value & " debe de tener un monto mayor de cero", MsgBoxStyle.Information, "Validación")
                    Return False
                End If
                If (IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(7).Value), 0, CDbl(Me.dgvPartidas.Rows(i).Cells.Item(7).Value))) <> 0 And (IIf(IsDBNull(Me.dgvPartidas.Rows(i).Cells.Item(6).Value), 0, CDbl(Me.dgvPartidas.Rows(i).Cells.Item(6).Value))) <> 0 Then
                    MsgBox("No puede especificar el cargo y el abono en un mismo registro.", MsgBoxStyle.Information, "Validación")
                    Return False
                End If
            Next

        Catch ex As Exception
            MsgBox("La fila " & i + 1 & " contiene un valor no valido. " & vbCrLf & ex.Message, MsgBoxStyle.Information, "Validación de Detalle de Partida")
            Return False
        End Try
        Return True
    End Function

    Private Sub btnEliminarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDetalle.Click
        If MsgBox("¿Está seguro(a) que desea eliminar la línea seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.dgvPartidas.CurrentRow.Cells.Item(0).Value, Me.dgvPartidas.CurrentRow.Cells.Item(3).Value, Me.dgvPartidas.CurrentRow.Cells.Item(1).Value, "", "", "0", "F")
            Mantenimiento_TransaccionL(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, Me.dgvPartidas.CurrentRow.Cells.Item(0).Value, Me.dgvPartidas.CurrentRow.Cells.Item(3).Value, Me.dgvPartidas.CurrentRow.Cells.Item(1).Value, "", "", "0", "A")
            CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
            CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
            LimpiaCamposLinea()
        End If
    End Sub

    Private Sub dgvPartidas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartidas.CellClick
        If Me.dgvPartidas.Rows.Count > 0 Then
            LineaMod = Me.dgvPartidas.CurrentRow.Cells(0).Value
            Me.lblCuenta.Text = IIf(IsDBNull(Me.dgvPartidas.CurrentRow.Cells(1).Value), "", Me.dgvPartidas.CurrentRow.Cells(1).Value)
            CuentaMod = CInt(Val(Me.lblCuenta.Text))
            Me.txtCUENTA_COMPLETA.Text = IIf(IsDBNull(Me.dgvPartidas.CurrentRow.Cells(2).Value), "", Me.dgvPartidas.CurrentRow.Cells(2).Value)
            Me.txtCUENTA_COMPLETA_LostFocus(New Object, New System.EventArgs)
            Me.txtCodDetalle.Text = Me.dgvPartidas.CurrentRow.Cells(3).Value
            DetalleMod = CInt(Val(Me.txtCodDetalle.Text))
            Me.txtCodDetalle_LostFocus(New Object, New System.EventArgs)
            Me.txtCONCEPTO_L.Text = Me.dgvPartidas.CurrentRow.Cells(5).Value
            Me.txtMONTO.Text = Format(Val(Me.dgvPartidas.CurrentRow.Cells(6).Value) + Val(Me.dgvPartidas.CurrentRow.Cells(7).Value), "0.00")
            If Val(Me.dgvPartidas.CurrentRow.Cells(6).Value) > 0 Then
                Me.cmbCARGO_ABONO.SelectedIndex = 0
            Else
                Me.cmbCARGO_ABONO.SelectedIndex = 1
            End If
            Me.txtCUENTA_COMPLETA.Focus()
        End If
    End Sub

    Private Sub dgvPartidas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartidas.CellEnter
    End Sub

    Private Sub dgvPartidas_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPartidas.DataError
        MsgBox("Dato no válido en la columna " & dgvPartidas.Columns(e.ColumnIndex).HeaderText, MsgBoxStyle.Information, "Validación")
    End Sub

    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.LostFocus
        If txtCUENTA_COMPLETA.Text.Length > 0 Then
            Dim tbl As DataTable = jClass.ejecutaSQLl_llenaDTABLE("SELECT DESCRIPCION_CUENTA,CUENTA,CATALOGO FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_COMPLETA.Text.Trim & "' AND CUENTA_MAYOR=0")

            If tbl IsNot Nothing And tbl.Rows.Count > 0 Then
                Dim DescripcionCuentaSeleccionada As String = tbl.Rows(0)(0)

                If DescripcionCuentaSeleccionada = "" Then
                    txtCUENTA_COMPLETA.Text = ""
                    lblCuenta.Text = ""
                    MsgBox("La cuenta ingresada no existe o es cuenta de mayor." & vbCrLf & "Favor verificar.", MsgBoxStyle.Information)
                Else
                    lblCuenta.Text = tbl.Rows(0)(1).ToString.Trim
                    TipoCat = CInt(tbl.Rows(0)(2))
                End If
            Else
                MsgBox("La cuenta ingresada no existe o es cuenta de mayor." & vbCrLf & "Favor verificar.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub txtCONCEPTO_L_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONCEPTO_L.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtMONTO.Focus()
        End If
    End Sub

    Private Sub cmbCARGO_ABONO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCARGO_ABONO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarLinea.Focus()
        End If
    End Sub

    Private Sub btnGuardarLinea_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarLinea.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCUENTA_COMPLETA.Focus()
        End If
    End Sub

    Private Sub Contabilidad_Partidas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnNuevaLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaLinea.Click
        LimpiaCamposLinea()
    End Sub

    Private Sub txtCodDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodDetalle.KeyPress, txtPARTIDA.KeyPress, txtDOCUMENTO.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPARTIDA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPARTIDA.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPARTIDA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPARTIDA.LostFocus
        If Me.txtPARTIDA.Text.Length > 0 Then
            Sql = "SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO "
            Sql &= " WHERE COMPAÑIA = " & Compañia
            Sql &= "   AND MONTH(FECHA_CONTABLE) = " & Me.dpFECHA_CONTABLE.Value.Month
            Sql &= "   AND YEAR(FECHA_CONTABLE) = " & Me.dpFECHA_CONTABLE.Value.Year
            Sql &= "   AND PARTIDA = " & Me.txtPARTIDA.Text
            Me.txtTRANSACCION.Text = jClass.obtenerEscalar(Sql)
            If Me.txtTRANSACCION.Text.Length > 0 Then
                BuscaTransaccion(Me.txtTRANSACCION.Text)
                CargaPartida_Detalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 6)
                CargaPartida_Diferencia(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtTRANSACCION.Text, 4)
                If Me.chkProcesada.Checked Then
                    MsgBox("¡La Partida ya está procesada!" & vbCrLf & "No podrá realizar cambios.", MsgBoxStyle.Information, "Mensaje")
                    HabilitaDeshabilita(False)
                Else
                    HabilitaDeshabilita(True)
                End If
            Else
                MsgBox("No existe Partida N° " & Me.txtPARTIDA.Text & vbCrLf & "para el periodo contable: " & vbCrLf & Format(Me.dpFECHA_CONTABLE.Value, "MMMM-yyyy").ToUpper(), MsgBoxStyle.Information, "Búsqueda")
            End If
        End If
    End Sub

    Private Sub txtCodDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodDetalle.LostFocus
        If Val(Me.txtCodDetalle.Text) > 0 Then
            If Me.txtCUENTA_COMPLETA.Text.Length = 0 Then
                MsgBox("Ingrese la Cuenta Contable", MsgBoxStyle.Information, "Búsqueda Códigos")
                Return
            End If
            If TipoCat = 0 Then
                'MsgBox("La Cuenta " & Me.txtCUENTA_COMPLETA.Text & " No Existe o No tiene Catálogo relacionado.", MsgBoxStyle.Information, "Busqueda Códigos")
                Me.NotifyIcon1.BalloonTipText = "La Cuenta " & Me.txtCUENTA_COMPLETA.Text & " No tiene Catálogo relacionado."
                Me.NotifyIcon1.Visible = True
                Me.NotifyIcon1.ShowBalloonTip(5)
                Return
            End If
            Me.NotifyIcon1.BalloonTipText = jClass.obtenerEscalar("IF EXISTS(SELECT DESCRIPCION FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " AND TIPO = " & TipoCat & " AND CODIGO = " & txtCodDetalle.Text & ") SELECT DESCRIPCION FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " AND TIPO = " & TipoCat & " AND CODIGO = " & txtCodDetalle.Text & " ELSE SELECT 'NO EXISTE CODIGO DETALLE'").ToString()
            Me.NotifyIcon1.Visible = True
            Me.NotifyIcon1.ShowBalloonTip(5)
        End If
    End Sub

    Private Sub btnBuscaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaDetalle.Click
        If Me.txtCUENTA_COMPLETA.Text.Length = 0 Then
            MsgBox("Ingrese la Cuenta Contable.", MsgBoxStyle.Information, "Busqueda Códigos")
            Return
        End If
        TipoCat = CInt(jClass.obtenerEscalar("SELECT CATALOGO FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA = '" & Me.txtCUENTA_COMPLETA.Text & "'"))
        If TipoCat = 0 Then
            MsgBox("La Cuenta " & Me.txtCUENTA_COMPLETA.Text & " No tiene Catálogo relacionado.", MsgBoxStyle.Information, "Busqueda Códigos")
            Return
        End If
        Producto = ""
        Nombre_Factura = ""
        Dim FrmCodigos As New Contabilidad_BusquedaCodigoDetalle(TipoCat)
        FrmCodigos.ShowDialog(Me)
        Me.txtCodDetalle.Text = Producto
        If Nombre_Factura.Length > 0 Then
            Me.NotifyIcon1.BalloonTipText = jClass.obtenerEscalar("IF EXISTS(SELECT DESCRIPCION FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " AND TIPO = " & TipoCat & " AND CODIGO = " & txtCodDetalle.Text & ") SELECT DESCRIPCION FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " AND TIPO = " & TipoCat & " AND CODIGO = " & txtCodDetalle.Text & " ELSE SELECT 'NO EXISTE CODIGO DETALLE'").ToString()
            Me.NotifyIcon1.Visible = True
            Me.NotifyIcon1.ShowBalloonTip(5)
        End If
    End Sub

    Private Sub dpFECHA_CONTABLE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim datepck As DateTimePicker = CType(sender, DateTimePicker)
        If jClass.obtenerEscalar("SELECT COUNT(TRANSACCION) FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND PARTIDA = " & Me.txtPARTIDA.Text & " AND MONTH(FECHA_CONTABLE) = " & datepck.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & datepck.Value.Year) > 0 Then
            MsgBox("La partida No." & Me.txtPARTIDA.Text & " ya existe para el mes seleccionado", MsgBoxStyle.Information, "Fecha No válida")
            e.Cancel = True
        End If
    End Sub
End Class