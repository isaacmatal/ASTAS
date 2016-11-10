Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_Partidas_Cierre_Anual
    Dim jclass As New jarsClass
    Dim Table As DataTable
    Dim sql As String
    Dim Transac, numPdas, Proceso As Integer
    Dim LibroC, cuentaLiquidadora As Integer
    Dim Parametros(7) As String
    Dim Rpts As New frmReportes_Ver

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.Label2.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.Label2.Text = texto
        End If
    End Sub

    Private Sub Contabilidad_Partidas_Cierre_Anual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.NudYear.Value = Now.Year - 1
        LibroC = jclass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        cuentaLiquidadora = CInt(jclass.obtenerEscalar("SELECT VALOR FROM dbo.CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 44"))
    End Sub

    Private Sub Contabilidad_Partidas_Cierre_Anual_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Function Mantenimiento_TransaccionL(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String) As Boolean
        Dim Resultado As Boolean = True
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            sql &= ",@LINEA          = " & Linea & vbCrLf
            sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.CommandTimeout = 7200
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Resultado = False
        Finally
            Conexion_.Close()
        End Try
        Return Resultado
    End Function

    Private Function Mantenimiento_TransaccionE(ByVal Compañia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String) As Boolean
        Dim Resultado As Boolean = True
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            sql &= ",@PARTIDA        = " & Partida & vbCrLf
            sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            sql &= ",@ANULADA        = " & Anulada & vbCrLf
            sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.CommandTimeout = 7200
            Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Resultado = False
        Finally
            Conexion_.Close()
        End Try
        Return Resultado
    End Function

    Private Function GeneraTransaccion(ByVal Concepto As String, ByVal txtPda As String, ByVal tipoCierre As String, ByVal Year As String) As Integer
        Dim sqlCmd As New SqlCommand
        Dim CtaContable As Integer = 0
        Dim NumPartida As Integer = 0
        Dim NumTran As Integer = 0
        Dim SetearTexto As New CallBackSetText(AddressOf SetText)
        Try
            If ValidaCierreContable(Compañia, LibroC, CInt(Year), 12, "E") Then
                NumPartida = Val(txtPda)
                If NumPartida > 0 Then
                    NumTran = jclass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & NumPartida & " AND MONTH(FECHA_CONTABLE) = 12 AND YEAR(FECHA_CONTABLE) = " & Me.NudYear.Value & " AND COMPAÑIA = " & Compañia & " AND CIERRE_ANUAL = '" & tipoCierre & "'")
                    If NumTran = 0 Then
                        MsgBox("No se encontró el número de partida" & vbCrLf & "o partida ingresada no es de cierre.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                        Return 0
                    Else
                        If jclass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                            MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                            Return 0
                        Else
                            If jclass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran) > 0 Then
                                If MsgBox("La partida No." & NumPartida & " tiene detalle, si continúa el detalle se eliminará." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                    SetearTexto("Eliminando Registros...")
                                    jclass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                                Else
                                    MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                    Return 0
                                End If
                            End If
                        End If
                    End If
                Else
                    NumTran = Me.GeneraCorrelativo(Compañia, "TRA", Me.NudYear.Value, 12)
                    NumPartida = Me.GeneraCorrelativo(Compañia, "PAR", Me.NudYear.Value, 12)
                    Mantenimiento_TransaccionE(Compañia, NumTran, LibroC, 1, "0", 2, NumPartida, CDate("31/12/" & CInt(Me.NudYear.Value).ToString()), Concepto, 0, 0, "I")
                    jclass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CIERRE_ANUAL = '" & tipoCierre & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        numPdas = NumPartida
        Transac = NumTran
        Return NumTran
    End Function

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            sql &= ",@AÑO = " & Año & vbCrLf
            sql &= ",@MES = " & Mes & vbCrLf
            sql &= ",@PRE_CIERRE = 0" & vbCrLf
            sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            sql &= ",@PROCESADO = 0" & vbCrLf
            sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") = True Then
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
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

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            sql &= ",@AÑO            = " & Año & vbCrLf
            sql &= ",@MES            = " & Mes & vbCrLf
            sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            sql &= ",@PROCESADO      = 0" & vbCrLf
            sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.CommandTimeout = 7200
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

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            sql &= ",@AÑO            = " & Año & vbCrLf
            sql &= ",@MES            = " & Mes & vbCrLf
            sql &= ",@ULTIMO         = 0"
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.CommandTimeout = 7200
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

    Private Function DevuelveCuenta(ByVal CuentaContable As String) As Integer
        Return jclass.obtenerEscalar("SELECT CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & LibroC & " AND CUENTA_COMPLETA = '" & CuentaContable & "'")
    End Function

    Private Sub NudYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudYear.ValueChanged
        For Each ctl As Control In Me.grpPdas.Controls
            If TypeOf (ctl) Is TextBox Then
                ctl.Text = Nothing
                ctl.Tag = Nothing
            End If
        Next
        Table = jclass.obtenerDatos(New SqlCommand("SELECT TRANSACCION, PARTIDA, CIERRE_ANUAL FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND YEAR(FECHA_CONTABLE) = " & NudYear.Value.ToString() & " AND CIERRE_ANUAL IS NOT NULL AND CIERRE_ANUAL <> 'APERTURA'"))
        For i As Integer = 0 To Table.Rows.Count - 1
            If Table.Rows(i).Item("CIERRE_ANUAL") = "ING" Then
                Me.txtPdaIng.Text = Table.Rows(i).Item("PARTIDA")
                Me.txtPdaIng.Tag = Table.Rows(i).Item("TRANSACCION")
            End If
            If Table.Rows(i).Item("CIERRE_ANUAL") = "OTRING" Then
                Me.txtPdaOtrIngr.Text = Table.Rows(i).Item("PARTIDA")
                Me.txtPdaOtrIngr.Tag = Table.Rows(i).Item("TRANSACCION")
            End If
            If Table.Rows(i).Item("CIERRE_ANUAL") = "COSTOS" Then
                Me.txtPdaCostos.Text = Table.Rows(i).Item("PARTIDA")
                Me.txtPdaCostos.Tag = Table.Rows(i).Item("TRANSACCION")
            End If
            If Table.Rows(i).Item("CIERRE_ANUAL") = "GASTOS" Then
                Me.txtGastos.Text = Table.Rows(i).Item("PARTIDA")
                Me.txtGastos.Tag = Table.Rows(i).Item("TRANSACCION")
            End If
            If Table.Rows(i).Item("CIERRE_ANUAL") = "CIERRE" Then
                Me.txtPdaAnual.Text = Table.Rows(i).Item("PARTIDA")
                Me.txtPdaAnual.Tag = Table.Rows(i).Item("TRANSACCION")
            End If
        Next
        Table = jclass.obtenerDatos(New SqlCommand("SELECT TRANSACCION, PARTIDA, CIERRE_ANUAL FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND YEAR(FECHA_CONTABLE) = " & (NudYear.Value + 1).ToString() & " AND CIERRE_ANUAL = 'APERTURA'"))
        If Table.Rows.Count > 0 Then
            If Table.Rows(0).Item("CIERRE_ANUAL") = "APERTURA" Then
                Me.txtPdaAper.Text = Table.Rows(0).Item("PARTIDA")
                Me.txtPdaAper.Tag = Table.Rows(0).Item("TRANSACCION")
            End If
        End If
    End Sub

    Private Function generarPartidasCierreAnual() As Boolean
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim Concepto As String = Parametros(0)
        Dim Partida As String = Parametros(1)
        Dim tipoCierre As String = Parametros(2)
        Dim tipoMov As String = Parametros(3)
        Dim cuentaInicial As String = Parametros(4)
        Dim cuentaFinal As String = Parametros(5)
        Dim Year As String = Parametros(6)
        Dim Resultado As Boolean = True
        Dim Total As Double = 0
        Dim Monto As Double = 0
        Dim CargoAbono As String = String.Empty
        Dim Transaccion As Integer
        Transaccion = GeneraTransaccion(Concepto, Partida, tipoCierre, Year)
        If Transaccion > 0 Then
            sql = "EXECUTE [dbo].[sp_CONTABILIDAD_REPORTES_AUXILIAR_CUENTAS]" & vbCrLf
            sql &= "@COMPAÑIA   = " & Compañia & "," & vbCrLf
            sql &= "@LIBRO      = 4," & vbCrLf
            sql &= "@CUENTAI    = '" & cuentaInicial & "'," & vbCrLf
            sql &= "@CUENTAF    = '" & cuentaFinal & "'," & vbCrLf
            sql &= "@FECHAI     = '01/12/" & Year & "'," & vbCrLf
            sql &= "@FECHAF     = '31/12/" & Year & "',"
            sql &= "@CODIGOI    = 0," & vbCrLf
            sql &= "@CODIGOF    = 2147483647"
            poneTexto("Calculando Saldos...")
            Table = jclass.obtenerDatos(New SqlCommand(sql))
            poneTexto("Generando Partida...")
            For i As Integer = 0 To Table.Rows.Count - 1
                If CDbl(Me.Table.Rows(i).Item("SALDO")) <> 0 Then
                    If Me.Table.Rows(i).Item("TIPO_CUENTA") = 1 Or Me.Table.Rows(i).Item("TIPO_CUENTA") = 4 Then
                        CargoAbono = "A"
                        Monto = CDbl(Me.Table.Rows(i).Item("SALDO"))
                        If CDbl(Me.Table.Rows(i).Item("SALDO")) < 0 Then
                            CargoAbono = "C"
                            Monto = CDbl(Me.Table.Rows(i).Item("SALDO")) * -1
                        End If
                    Else
                        CargoAbono = "C"
                        Monto = CDbl(Me.Table.Rows(i).Item("SALDO"))
                        If CDbl(Me.Table.Rows(i).Item("SALDO")) < 0 Then
                            CargoAbono = "A"
                            Monto = CDbl(Me.Table.Rows(i).Item("SALDO")) * -1
                        End If
                    End If
                    Resultado = Mantenimiento_TransaccionL(Compañia, LibroC, Transaccion, 0, CDbl(Me.Table.Rows(i).Item("DETALLE")), DevuelveCuenta(Me.Table.Rows(i).Item("CUENTA_COMPLETA")), Concepto, CargoAbono, Monto, "E")
                    Total += CDbl(Me.Table.Rows(i).Item("SALDO"))
                    If Not Resultado Then
                        Exit For
                    End If
                End If
                Me.bwCierres.ReportProgress(Math.Floor(((i + 1.0) / Table.Rows.Count) * 100))
            Next
            If tipoCierre <> "CIERRE" Then
                Mantenimiento_TransaccionL(Compañia, LibroC, Transaccion, 0, 0, cuentaLiquidadora, Concepto, tipoMov, Total, "E")
            End If
            poneTexto("Finalizando...")
            Mantenimiento_TransaccionL(Compañia, LibroC, Transaccion, 0, 0, cuentaLiquidadora, Concepto, tipoMov, Total, "A")
            'MsgBox("Proceso Finalizado" & IIf(Resultado, ".", " (CON ERRORES)."), MsgBoxStyle.Information, "Cierre Anual")
        Else
            MsgBox("Proceso Cancelado.", MsgBoxStyle.Information, "Transaccion = 0")
        End If
        Return Resultado
    End Function

    Private Sub Activar(ByVal estado As Boolean)
        For Each ctl As Control In Me.Controls
            'If TypeOf (ctl) Is TextBox Then
            If ctl.Name <> "Label2" Then
                ctl.Enabled = estado
            End If
            'End If
        Next
    End Sub
    Private Sub btnIngr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngr.Click
        Activar(False)
        Proceso = 1
        PB1.Value = 0
        PB1.Visible = True
        Parametros(0) = "Liquidación de Ingresos del Ejercicio " & Me.NudYear.Value.ToString()
        Parametros(1) = Me.txtPdaIng.Text
        Parametros(2) = "ING"
        Parametros(3) = "A"
        Parametros(4) = "5100000000000"
        Parametros(5) = "5199999999999"
        Parametros(6) = Me.NudYear.Value.ToString()
        Me.bwCierres.RunWorkerAsync()
    End Sub

    Private Sub btnOtrosIng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtrosIng.Click
        Activar(False)
        Proceso = 2
        PB1.Visible = True
        PB1.Value = 0
        Parametros(0) = "Liquidación de Otros Ingresos del Ejercicio " & Me.NudYear.Value.ToString()
        Parametros(1) = Me.txtPdaOtrIngr.Text
        Parametros(2) = "OTRING"
        Parametros(3) = "A"
        Parametros(4) = "5200000000000"
        Parametros(5) = "5399999999999"
        Parametros(6) = Me.NudYear.Value.ToString()
        Me.bwCierres.RunWorkerAsync()
    End Sub

    Private Sub btnCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostos.Click
        Activar(False)
        Proceso = 3
        PB1.Visible = True
        PB1.Value = 0
        Parametros(0) = "Liquidación de Costos del Ejercicio " & Me.NudYear.Value.ToString()
        Parametros(1) = Me.txtPdaCostos.Text
        Parametros(2) = "COSTOS"
        Parametros(3) = "C"
        Parametros(4) = "4100000000000"
        Parametros(5) = "4199999999999"
        Parametros(6) = Me.NudYear.Value.ToString()
        Me.bwCierres.RunWorkerAsync()
    End Sub

    Private Sub btnGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGastos.Click
        Activar(False)
        Proceso = 4
        PB1.Visible = True
        PB1.Value = 0
        Parametros(0) = "Liquidación de Gastos del Ejercicio " & Me.NudYear.Value.ToString()
        Parametros(1) = Me.txtGastos.Text
        Parametros(2) = "GASTOS"
        Parametros(3) = "C"
        Parametros(4) = "4200000000000"
        Parametros(5) = "4399999999999"
        Parametros(6) = Me.NudYear.Value.ToString()
        Me.bwCierres.RunWorkerAsync()
    End Sub

    Private Sub btnCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierre.Click
        If Val(Me.txtPdaIng.Text) = 0 Or Val(Me.txtPdaOtrIngr.Text) = 0 Or Val(Me.txtPdaCostos.Text) = 0 Or Val(Me.txtGastos.Text) = 0 Then
            MsgBox("Antes de generar el Cierre Anual debe generar las" & vbCrLf & "partidas de liquidación de INGRESOS, COSTOS y GASTOS.", MsgBoxStyle.Critical, "Partidas Cierre Anual")
            Return
        End If
        Activar(False)
        Proceso = 5
        PB1.Visible = True
        PB1.Value = 0
        Parametros(0) = "Cierre del Ejercicio " & Me.NudYear.Value.ToString()
        Parametros(1) = Me.txtPdaAnual.Text
        Parametros(2) = "CIERRE"
        Parametros(3) = "X"
        Parametros(4) = "1100000000000"
        Parametros(5) = "6999999999999"
        Parametros(6) = Me.NudYear.Value.ToString()
        Me.bwCierres.RunWorkerAsync()
    End Sub

    Private Sub bwCierres_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCierres.DoWork
        generarPartidasCierreAnual()
    End Sub

    Private Sub bwCierres_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwCierres.ProgressChanged, bwApertura.ProgressChanged
        Me.PB1.Value = e.ProgressPercentage
        Me.Label2.Text = "Generando Partida... " & e.ProgressPercentage.ToString() & "%"
    End Sub

    Private Sub bws_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCierres.RunWorkerCompleted, bwApertura.RunWorkerCompleted
        If e.Cancelled Then
            MsgBox("Proceso cancelado por el usuario!!", MsgBoxStyle.Information, "Resultado")
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error al Procesar Partida" & vbCrLf & vbCrLf & e.Error.Message.ToUpper(), MsgBoxStyle.Information, "Resultado")
        Else
            MsgBox("Proceso finalizado", MsgBoxStyle.Information, "Resultado")
        End If
        PB1.Visible = False
        Select Case Proceso
            Case 1
                Me.txtPdaIng.Text = numPdas
                Me.txtPdaIng.Tag = Transac
            Case 2
                Me.txtPdaOtrIngr.Text = numPdas
                Me.txtPdaOtrIngr.Tag = Transac
            Case 3
                Me.txtPdaCostos.Text = numPdas
                Me.txtPdaCostos.Tag = Transac
            Case 4
                Me.txtGastos.Text = numPdas
                Me.txtGastos.Tag = Transac
            Case 5
                Me.txtPdaAnual.Text = numPdas
                Me.txtPdaAnual.Tag = Transac
            Case 6
                Me.txtPdaAper.Text = numPdas
                Me.txtPdaAper.Tag = Transac
        End Select
        Activar(True)
        Me.Label2.Text = ""
    End Sub

    Private Sub btnApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApertura.Click
        If Val(Me.txtPdaAnual.Text) = 0 Then
            MsgBox("Antes de generar la Apertura del siguiente ejercicio " & vbCrLf & "debe generar la partida de Cierre Anual Ejercicio Corriente.", MsgBoxStyle.Critical, "Partidas Cierre Anual")
            Return
        End If
        Activar(False)
        Proceso = 6
        PB1.Visible = True
        PB1.Value = 0
        Parametros(0) = "Apertura del Ejercicio " & (Me.NudYear.Value + 1).ToString()
        Parametros(1) = Me.txtPdaAper.Text
        Parametros(2) = "APERTURA"
        Parametros(3) = Me.txtPdaAnual.Tag.ToString()
        Parametros(4) = "1100000000000"
        Parametros(5) = "6999999999999"
        Parametros(6) = (Me.NudYear.Value + 1).ToString()
        Me.bwApertura.RunWorkerAsync()
    End Sub

    Private Sub generaPartidaApertura()
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim Resultado As Boolean = True
        Dim Total As Double = 0
        Dim Concepto As String = Parametros(0)
        Dim CargoAbono As String = String.Empty
        If ValidaCierreContable(Compañia, LibroC, CInt(Parametros(6)), 1, "E") Then
            Transac = jclass.obtenerEscalar("SELECT ISNULL(TRANSACCION, 0) FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = 1 AND MONTH(FECHA_CONTABLE) = 1 AND YEAR(FECHA_CONTABLE) = " & Parametros(6) & " AND COMPAÑIA = " & Compañia)
            If Transac > 0 Then
                If jclass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transac) > 0 Then
                    If MsgBox("La partida No.1 tiene detalle, si continúa el detalle se eliminará." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                        poneTexto("Eliminando Registros...")
                        jclass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transac)
                    Else
                        MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                        Return
                    End If
                End If
                jclass.obtenerEscalar("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Concepto & "', FECHA_CONTABLE = '01/01/" & Parametros(6) & "', PROCESADO = 0 WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transac)
            Else
                Transac = Me.GeneraCorrelativo(Compañia, "TRA", CInt(Parametros(6)), 1)
                numPdas = Me.GeneraCorrelativo(Compañia, "PAR", CInt(Parametros(6)), 1)
                Mantenimiento_TransaccionE(Compañia, Transac, LibroC, 1, "0", 2, CInt(Parametros(1)), CDate("01/01/" & Parametros(6)), Concepto, 0, 0, "I")
                jclass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CIERRE_ANUAL = 'APERTURA' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transac)
            End If
        End If
        sql = "SELECT [CUENTA_CONTABLE], [COD_DETALLE], [CARGOS], [ABONOS]" & vbCrLf
        sql &= "  FROM [dbo].[CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO]" & vbCrLf
        sql &= " WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Parametros(3) & " ORDER BY CORRELATIVO"
        poneTexto("Calculando Saldos...")
        Table = jclass.obtenerDatos(New SqlCommand(sql))
        poneTexto("Generando Partida...")
        For i As Integer = 0 To Table.Rows.Count - 1
            If Me.Table.Rows(i).Item("CARGOS") > 0 Then
                CargoAbono = "A"
                Total = Me.Table.Rows(i).Item("CARGOS")
            Else
                CargoAbono = "C"
                Total = Me.Table.Rows(i).Item("ABONOS")
            End If
            Resultado = Mantenimiento_TransaccionL(Compañia, LibroC, Transac, 0, Me.Table.Rows(i).Item("COD_DETALLE"), Me.Table.Rows(i).Item("CUENTA_CONTABLE"), Concepto, CargoAbono, Total, "E")
            Me.bwApertura.ReportProgress(Math.Floor(((i + 1.0) / Table.Rows.Count) * 100))
        Next
        poneTexto("Finalizando...")
        Mantenimiento_TransaccionL(Compañia, LibroC, Transac, 0, 0, 0, Concepto, "X", Total, "A")
    End Sub

    Private Sub bwApertura_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwApertura.DoWork
        generaPartidaApertura()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.Label2.Text = "Generando Reporte..." & vbCrLf & "Espere..."
        Activar(False)
        Timer1.Enabled = True
        Dim Transacciones As String = String.Empty
        For Each c As Control In Me.grpPdas.Controls
            If TypeOf (c) Is TextBox Then
                If c.Text.Length > 0 Then
                    If Transacciones.Length = 0 Then
                        Transacciones &= c.Tag.ToString()
                    Else
                        Transacciones &= "," & c.Tag.ToString()
                    End If
                End If
            End If
        Next
        If Transacciones.Length > 0 Then
            Rpts.crvReporte.DisplayGroupTree = True
            PB1.Value = 0
            PB1.Visible = True
            Me.bwPartidasRPT.RunWorkerAsync(Transacciones)
            Me.bwAvance.RunWorkerAsync()
        Else
            MsgBox("Número de Partida inválido", MsgBoxStyle.Critical, "Impresión")
        End If
    End Sub

    Private Sub bwPartidasRPT_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwPartidasRPT.DoWork
        CargaPartidaIN(LibroC, e.Argument.ToString())
    End Sub

    Private Sub bwPartidasRPT_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwPartidasRPT.RunWorkerCompleted
        Dim Rpt As New Contabilidad_Partida_Contable
        Rpts.chkNoDet.Visible = True
        Rpt.SetDataSource(Table)
        Rpts.ReportesGenericos(Rpt)
        Rpts.ShowDialog()
        Me.Label2.Text = ""
        Timer1.Enabled = False
        Activar(True)
        Me.Label2.Visible = True
    End Sub

    Public Sub CargaPartidaIN(ByVal Libro As Integer, ByVal Transacciones As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "SELECT E.PARTIDA," & vbCrLf
            sql &= "       D.FECHA_TRAN," & vbCrLf
            sql &= "	   C.CUENTA_COMPLETA," & vbCrLf
            sql &= "	   D.COD_DETALLE," & vbCrLf
            sql &= "	   C.DESCRIPCION_CUENTA," & vbCrLf
            sql &= "	   D.CONCEPTO AS CONCEPTOD," & vbCrLf
            sql &= "	   D.CARGOS," & vbCrLf
            sql &= "	   D.ABONOS," & vbCrLf
            sql &= "	   E.CONCEPTO AS CONCEPTOE," & vbCrLf
            sql &= "	   E.TIPO_PARTIDA," & vbCrLf
            sql &= "	   E.DOCUMENTO," & vbCrLf
            sql &= "	   T.DESCRIPCION_TIPO_PARTIDA," & vbCrLf
            sql &= "	   (SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = " & Compañia & ") AS EMPRESA," & vbCrLf
            sql &= "	   E.USUARIO_CREACION," & vbCrLf
            sql &= "	   E.USUARIO_CREACION_FECHA," & vbCrLf
            sql &= "	   E.USUARIO_EDICION," & vbCrLf
            sql &= "       E.USUARIO_EDICION_FECHA," & vbCrLf
            sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,4) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL1,"
            sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,6) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL2,"
            sql &= "       (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,8) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL3,"
            sql &= "       E.PROCESADO," & vbCrLf
            sql &= "       CASE D.ABONOS WHEN 0 THEN 'A-CARGOS' ELSE 'B-ABONOS' END AS ORDEN" & vbCrLf
            sql &= "  FROM [dbo].[CONTABILIDAD_PARTIDAS_ENCABEZADO] E," & vbCrLf
            sql &= "       [dbo].[CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO] D," & vbCrLf
            sql &= "	   [dbo].[CONTABILIDAD_CATALOGO_CUENTAS] C," & vbCrLf
            sql &= "       [dbo].[CONTABILIDAD_CATALOGO_TIPO_PARTIDA] T" & vbCrLf
            sql &= " WHERE E.COMPAÑIA = D.COMPAÑIA And E.TRANSACCION = D.TRANSACCION" & vbCrLf
            sql &= "   AND E.COMPAÑIA = T.COMPAÑIA AND E.TIPO_PARTIDA = T.TIPO_PARTIDA" & vbCrLf
            sql &= "   AND D.COMPAÑIA = C.COMPAÑIA AND D.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
            sql &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND E.TRANSACCION IN (" & Transacciones & ")" & vbCrLf
            sql &= "   AND C.LIBRO_CONTABLE = " & Libro
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        Conexion_.Close()
    End Sub

    Private Sub btnBalanceGral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalanceGral.Click
        Me.Label2.Text = "Generando Reporte..." & vbCrLf & "Espere..."
        Activar(False)
        Timer1.Enabled = True
        Rpts.crvReporte.DisplayGroupTree = False
        PB1.Value = 0
        PB1.Visible = True
        Me.bwBalanceRPT.RunWorkerAsync(Me.NudYear.Value.ToString() & "-12-31")
        bwAvance.RunWorkerAsync()
    End Sub

    Private Sub bwBalanceRPT_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwBalanceRPT.DoWork
        CargaBalanceGeneral(Compañia, LibroC, LibroC, CDate(e.Argument.ToString()), 3, IIf(Me.rbReporte.Checked, 1, 2))
    End Sub

    Private Sub bwBalanceRPT_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwBalanceRPT.RunWorkerCompleted
        Dim Rpt As New Contabilidad_Reportes_Balance_General_RPT
        Dim RptCta As New Contabilidad_Reportes_Balance_General_RPT_Cuenta
        Rpts.chkNoDet.Visible = False
        If Me.rbReporte.Checked Then
            Rpt.SetDataSource(Table)
            Rpts.ReportesGenericos(Rpt)
        Else
            RptCta.SetDataSource(Table)
            Rpts.ReportesGenericos(RptCta)
        End If
        Rpts.ShowDialog()
        Me.Label2.Text = ""
        Timer1.Enabled = False
        Activar(True)
        Me.Label2.Visible = True
    End Sub

    Public Sub CargaBalanceGeneral(ByVal Compañia As Integer, ByVal Libro As Integer, ByVal Libro2 As Integer, ByVal FechaR As Date, ByVal Reporte As Integer, ByVal Formato As Integer)
        Try
            sql = "Execute sp_CONTABILIDAD_REPORTES_BALANCE_GENERAL_RPT " & vbCrLf
            sql &= "  @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ", @LIBRO_CONTABLE = " & Libro & vbCrLf
            sql &= ", @LIBRO_EXTRACON = " & Libro2 & vbCrLf
            sql &= ", @FECHA          = '" & Format(FechaR, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ", @REPORTE        = " & Reporte & vbCrLf
            sql &= ", @FORMATO		  = " & Formato & vbCrLf
            Table = jclass.obtenerDatos(New SqlClient.SqlCommand(sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Rpts.ShowDialog()
        Me.Label2.Text = ""
        Timer1.Enabled = False
        Me.Label2.Visible = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Application.DoEvents()
        If Me.Label2.Visible Then
            Me.Label2.Visible = False
        Else
            Me.Label2.Visible = True
        End If
    End Sub

    Private Sub bwAvance_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAvance.DoWork
        While bwBalanceRPT.IsBusy
            For i As Integer = 0 To 100
                If bwBalanceRPT.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(750)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    bwAvance.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While

        While bwPartidasRPT.IsBusy
            For i As Integer = 0 To 100
                If bwPartidasRPT.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(200)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    bwAvance.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While

        bwAvance.ReportProgress(100)
    End Sub

    Private Sub bwAvance_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwAvance.ProgressChanged
        PB1.Value = e.ProgressPercentage
    End Sub

    Private Sub bwAvance_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAvance.RunWorkerCompleted
        PB1.Visible = False
        PB1.Value = 0
    End Sub
End Class