Imports System.Data.SqlClient

Public Class Activo_Fijo_Generar_Partidas
    Dim Sql As String
    Dim jClass As New jarsClass
    'Dim ProcesosContables As New Contabilidad_Procesos
    Dim Table As DataTable
    Dim Iniciando As Boolean
    Dim NumTran As Integer = 0
    Dim LC As Integer = 0
    Dim entidad_generica_ As New EntidadGenerica
    Dim tabla_detalle_ As New DataTable("DatosPartidasDetalle")
    Dim tabla_tipos_ As New DataTable("DatosPartidasTipos")
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter

    Private Function LastDayOfMonth(ByVal year_ As Integer, ByVal month_ As Integer) As Date
        Return New DateTime(year_, month_, DateTime.DaysInMonth(year_, month_))
    End Function

    Private Function procesarPartidas() As Boolean
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim result_ As Boolean = False
        Try
            Conexion_.Open()
            Sql = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_GENERAR_PARTIDA" & vbCrLf
            Sql &= " @FECHA_CONTABLE = '" & Me.LastDayOfMonth(Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToShortDateString() & "'" & vbCrLf
            Sql &= ",@AÑOCONTABLE = " & Year(Me.dpFECHA_CONTABLE.Value) & vbCrLf
            Sql &= ",@MESCONTABLE = " & Month(Me.dpFECHA_CONTABLE.Value) & vbCrLf
            Sql &= ",@COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@TIPODOCUMENTO = 7" & vbCrLf
            Sql &= ",@PARTIDAGRAL=" & IIf(Me.txtPartidaGral.Text.Length > 0, Me.txtPartidaGral.Text.Trim(), 0) & vbCrLf
            Sql &= ",@PARTIDADETALLE=" & IIf(Me.txtPartidaDetalle.Text.Length > 0, Me.txtPartidaDetalle.Text.Trim(), 0) & vbCrLf
            Sql &= ",@BANDERA = 0" & vbCrLf
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("PARTIDA_AF")
            DataAdapter_.Fill(Table)
            Conexion_.Close()
            result_ = True
            Me.fillGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return result_
    End Function

    Private Sub Activo_Fijo_Generar_Partidas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub Activo_Fijo_Generar_Partidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        LC = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA=" & Compañia & " AND LIBRO_PRINCIPAL=1").ToString()
        Iniciando = False
        Me.fillGrid()
    End Sub

    Private Function ValidaCierreContable(ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
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
                    If Not ValidaCierreContablePermisos(Año, Mes, "L") Then
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

    Private Function ValidaCierreContablePermisos(ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
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

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        If MsgBox("Desea Generar las partidas contables de Activo Fijo. ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            btnProcesarPartida.Visible = False
            If ValidaCierreContable(Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value), "E") Then
                If Me.validarPartidas() Then
                    If procesarPartidas() Then
                        MsgBox("Proceso ejecutado con exito...", MsgBoxStyle.Information, "Sistema")
                    Else
                        MsgBox("Error en el proceso de generacion de partidas contables.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If
            btnProcesarPartida.Visible = True
        End If
    End Sub

    Private Function validarPartidas() As Boolean
        If Me.txtTransaccion.Text.Trim().Length > 0 Then
            Dim existe_ As Integer = Val(jClass.obtenerEscalar("SELECT COUNT(*) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE TRANSACCION = " & Me.txtTransaccion.Text.Trim() & " AND COMPAÑIA = " & Compañia).ToString())
            If existe_ > 0 Then
                MsgBox("Las Partidas para esta fecha ya estan generadas.", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub dpFECHA_CONTABLE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFECHA_CONTABLE.ValueChanged
        If Not Iniciando Then
            Me.fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Me.txtPartidaGral.Text = String.Empty
        Me.txtPartidaDetalle.Text = String.Empty
        dgvDetalles.DataSource = Nothing
        dgvTipos.DataSource = Nothing
        Dim query_ As String = "SELECT PARTIDAGENERAL,PARTIDA,TRANSACCION,B.DESCRIPCION_BIEN,(SELECT TOP 1 CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS C WHERE C.CUENTA = AFP.CUENTA AND COMPAÑIA=" & Compañia & ") As CUENTA,VALOR,B.COMPAÑIA,USUARIO_CREA FROM dbo.CONTABILIDAD_ACTIVO_FIJO_PARTIDAS AFP INNER JOIN  dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN B ON AFP.BIEN = B.BIEN WHERE AFP.COMPAÑIA=" & Compañia & " AND AFP.FECHA_PARTIDA='" & Me.LastDayOfMonth(Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToShortDateString() & "' AND AFP.MES=" & Month(Me.dpFECHA_CONTABLE.Value) & " AND AFP.TIPO =0 AND AFP.AÑO=" & Year(Me.dpFECHA_CONTABLE.Value)

        tabla_detalle_ = entidad_generica_.getData(query_)
        If tabla_detalle_.Rows.Count > 0 Then
            dgvDetalles.DataSource = tabla_detalle_
            Me.txtPartidaGral.Text = tabla_detalle_.Rows(0)("PARTIDAGENERAL").ToString()
            Me.txtPartidaDetalle.Text = tabla_detalle_.Rows(0)("PARTIDA").ToString()
            Me.txtTransaccion.Text = tabla_detalle_.Rows(0)("TRANSACCION").ToString()

            dgvDetalles.Columns("PARTIDAGENERAL").Visible = False
            dgvDetalles.Columns("PARTIDA").Visible = False
            dgvDetalles.Columns("TRANSACCION").Visible = False
            dgvDetalles.Columns("COMPAÑIA").Visible = False
        End If

        tabla_tipos_ = entidad_generica_.getData("SELECT PARTIDAGENERAL,PARTIDA,TRANSACCION,B.DESCRIPCION_BIEN,(SELECT TOP 1 CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS C WHERE C.CUENTA = AFP.CUENTA AND COMPAÑIA=" & Compañia & ") As CUENTA,VALOR,B.COMPAÑIA,USUARIO_CREA FROM dbo.CONTABILIDAD_ACTIVO_FIJO_PARTIDAS AFP INNER JOIN  dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN B ON AFP.BIEN = B.BIEN WHERE AFP.COMPAÑIA=" & Compañia & " AND AFP.FECHA_PARTIDA='" & Me.LastDayOfMonth(Year(Me.dpFECHA_CONTABLE.Value), Month(Me.dpFECHA_CONTABLE.Value)).ToShortDateString() & "' AND AFP.MES=" & Month(Me.dpFECHA_CONTABLE.Value) & " AND AFP.TIPO =1 AND AFP.AÑO=" & Year(Me.dpFECHA_CONTABLE.Value))
        If tabla_tipos_.Rows.Count > 0 Then
            dgvTipos.DataSource = tabla_tipos_
            dgvTipos.Columns("PARTIDAGENERAL").Visible = False
            dgvTipos.Columns("PARTIDA").Visible = False
            dgvTipos.Columns("TRANSACCION").Visible = False
            dgvTipos.Columns("COMPAÑIA").Visible = False
        End If
    End Sub
End Class