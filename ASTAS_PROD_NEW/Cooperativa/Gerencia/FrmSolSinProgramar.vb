Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSolSinProgramar
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim porcIVA As Double
    Dim TablaPdas As New DataTable("pdas")
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub FrmSolSinProgramar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Me.DpFechaIni.Value = Me.DpFechaFin.Value.Date.AddDays(-Me.DpFechaFin.Value.Day).AddDays(1)
        Me.dpFechaAut.Value = Now()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Carga_TipoSolicitudes()
        Carga_Solicitudes()
        CrearTabla()
        LimpiaGrid()
        porcIVA = RetornaConstante(1)
        Me.rbTodas.Checked = True
        Iniciando = False
    End Sub

    Private Sub Carga_TipoSolicitudes()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_TIPO_SOLICITUDES" & vbCrLf
            Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            CbxTipoSolicitudes.ValueMember = "SOLICITUD"
            CbxTipoSolicitudes.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxTipoSolicitudes.DataSource = Table
            CbxTipoSolicitudes.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function VerificaUsuario(ByVal Linea As Integer) As Boolean
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim bandera As Boolean
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @CORRELATIVO = 1," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @TIPOSOL = " & DgvSolicitudes.Rows(Linea).Cells(3).Value & "," & vbCrLf
            Sql &= " @BANDERA = 1" & vbCrLf
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                bandera = True
            Else
                bandera = False
            End If
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bandera
    End Function

    Private Function VerificaAutorizaciones(ByVal Linea As Integer) As Boolean
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CONTAR_AUTORIZACIONES " & Compañia & "," & DgvSolicitudes.Rows(Linea).Cells(1).Value & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Return True
            Else
                Return False
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function VerificaSiesSinCotizacion(ByVal Linea As Integer) As Boolean
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CONTAR_AUTORIZACIONES " & Compañia & "," & 0 & "," & DgvSolicitudes.Rows(Linea).Cells(3).Value & "," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Return True
            Else
                Return False
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Sub Carga_Solicitudes()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.SP_COOPERATIVA_TODAS_LAS_SOLICITUDES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @T_SOLICITUD = 9999," & vbCrLf
            Sql &= " @N_SOLICITUD = 0," & vbCrLf
            Sql &= " @FECHA_INI = 0," & vbCrLf
            Sql &= " @FECHA_FIN = 0," & vbCrLf
            Sql &= " @BANDERA = 2,"
            Sql &= " @ORIGENES = '" & Permitir & "'"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            DgvSolicitudes.DataSource = Table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscaSolicitudes()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.SP_COOPERATIVA_TODAS_LAS_SOLICITUDES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @T_SOLICITUD = " & CbxTipoSolicitudes.SelectedValue & "," & vbCrLf
            Sql &= " @N_SOLICITUD = " & IIf(TxtNumSol.Text.Length = 0, "0", TxtNumSol.Text) & "," & vbCrLf
            Sql &= " @FECHA_INI = '" & Format(DpFechaIni.Value, "dd-MM-yyyy 00:00:01") & "'," & vbCrLf
            Sql &= " @FECHA_FIN = '" & Format(DpFechaFin.Value, "dd-MM-yyyy 23:59:59") & "'," & vbCrLf
            Sql &= " @BANDERA = 2,"
            Sql &= " @ORIGENES = '" & Permitir & "'"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            DgvSolicitudes.DataSource = Table
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("¡No se ha encontrado ninguna Solicitud!", MsgBoxStyle.Information, "Mensaje")
            End If
            Me.rbTodas.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 50
        Me.DgvSolicitudes.Columns(1).Width = 60
        Me.DgvSolicitudes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(2).Visible = False
        Me.DgvSolicitudes.Columns(3).Visible = False
        Me.DgvSolicitudes.Columns(4).Width = 150
        Me.DgvSolicitudes.Columns(5).Visible = False
        Me.DgvSolicitudes.Columns(6).Width = 260
        Me.DgvSolicitudes.Columns(7).Width = 80
        Me.DgvSolicitudes.Columns(8).Width = 260
        Me.DgvSolicitudes.Columns(9).DefaultCellStyle.ForeColor = Color.Navy
        Me.DgvSolicitudes.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(9).Width = 80
        Me.DgvSolicitudes.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(11).Width = 80
        Me.DgvSolicitudes.Columns(12).Width = 50
        Me.DgvSolicitudes.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(13).Width = 100
        For i As Integer = 1 To Me.DgvSolicitudes.Columns.Count - 1
            Me.DgvSolicitudes.Columns(i).ReadOnly = True
            If i >= 14 Then
                Me.DgvSolicitudes.Columns(i).Visible = False
            End If
        Next
    End Sub

    Private Sub btnDenegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDenegar.Click
        Dim SelectedRows As Integer = 0
        Dim Denega As String = ""
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value Then
                SelectedRows += 1
            End If
        Next
        If SelectedRows = 0 Then
            MsgBox("No ha seleccionado registros para procesar.", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If MsgBox("¿Está seguro de Denegar las solicitudes seleccionadas?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.No Then
            Return
        End If
        While Denega.Length = 0
            Denega = InputBox("Ingrese el comentario de Denegación", "Denegar Solicitudes")
        End While
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value And DgvSolicitudes.Rows(i).Cells(1).Value <> 0 Then
                Autorizaciones(DgvSolicitudes.Rows(i).Cells(1).Value, Denega, Me.dpFechaAut.Value.Date, False, True, False, 4)
            End If
        Next
        Me.CbxTipoSolicitudes.SelectedValue = 9999
        Carga_Solicitudes()
        Me.rbTodas.Checked = True
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim SelectedRows As Integer = 0
        Dim Denega As String = ""
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value Then
                SelectedRows += 1
            End If
        Next
        If SelectedRows = 0 Then
            MsgBox("No ha seleccionado registros para procesar.", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If MsgBox("¿Está seguro de Anular las solicitudes seleccionadas?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.No Then
            Return
        End If
        While Denega.Length = 0
            Denega = InputBox("Ingrese el comentario de Denegación", "Denegar Solicitudes")
        End While
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value And DgvSolicitudes.Rows(i).Cells(1).Value <> 0 Then
                Autorizaciones(DgvSolicitudes.Rows(i).Cells(1).Value, Denega, Me.dpFechaAut.Value.Date, False, False, True, 5)
            End If
        Next
        Me.CbxTipoSolicitudes.SelectedValue = 9999
        Carga_Solicitudes()
        Me.rbTodas.Checked = True
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsmiAutorizacion.Click, btnAutorizar.Click
        Dim SelectedRows As Integer = 0
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value Then
                SelectedRows += 1
            End If
        Next
        If SelectedRows = 0 Then
            MsgBox("No ha seleccionado registros para procesar.", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If MsgBox("¿Está seguro de Autorizar las solicitudes seleccionadas?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.No Then
            Return
        End If
        Dim Autori As String = ""
        Dim MonthServer As Integer = Me.dpFechaAut.Value.Date.Month
        Dim YearServer As Integer = Me.dpFechaAut.Value.Date.Year
        Dim Concepto As String = ""
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value And DgvSolicitudes.Rows(i).Cells(1).Value <> 0 Then
                ParamcodSolicitud = DgvSolicitudes.Rows(i).Cells.Item(1).Value
                If DgvSolicitudes.Rows(i).Cells.Item(5).Value = 240 Or DgvSolicitudes.Rows(i).Cells.Item(5).Value = 104 Then
                    Autori = jClass.obtenerEscalar("SELECT RAZON FROM COOPERATIVA_SOLICITUDES_PRESTAMOS WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & ParamcodSolicitud).ToString()
                Else
                    Autori = "AUTORIZADA"
                End If
                Dim TipoSol As Integer = DgvSolicitudes.Rows(i).Cells.Item(3).Value
                Autorizaciones(ParamcodSolicitud, Autori, Me.dpFechaAut.Value, True, False, False, 1)
            End If
        Next
        Me.CbxTipoSolicitudes.SelectedValue = 9999
        Carga_Solicitudes()
        Me.rbTodas.Checked = True
    End Sub

    Private Sub Autorizaciones(ByVal NumeroSol As Integer, ByVal Comentario As String, ByVal FechaA1 As DateTime, ByVal Autorizada As Boolean, ByVal Denegada As Boolean, ByVal Anulada As Boolean, ByVal Bandera As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = NumeroSol
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = IIf(Autorizada, "DESTINO: " & Comentario, "")
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = FechaA1
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = FechaA1
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = FechaA1
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = Denegada
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = IIf(Denegada, Comentario, "")
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = FechaA1
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = Anulada
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = IIf(Anulada, Comentario, "")
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = FechaA1
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_BUXIS", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_CREACION", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = Bandera
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If CDate(DpFechaIni.Value.ToShortDateString) > CDate(DpFechaFin.Value.ToShortDateString) Then
            MsgBox("La fecha ''Hasta''no puede ser menor que la fecha ''Desde''", MsgBoxStyle.Information, "Validación")
            DpFechaFin.Focus()
            Return
        End If
        BuscaSolicitudes()
    End Sub

    Private Sub TxtNumSol_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumSol.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rbTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodas.CheckedChanged
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            Me.DgvSolicitudes.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub rbSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSelec.CheckedChanged
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            Me.DgvSolicitudes.Rows(i).Cells(0).Value = False
        Next
    End Sub

    Private Sub CrearTabla()
        TablaPdas.Columns.Add("tiposol", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("origen", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("tipdoc", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("valor", Type.GetType("System.Double"))
        TablaPdas.Columns.Add("documento", Type.GetType("System.String"))
        TablaPdas.Columns.Add("concepto", Type.GetType("System.String"))
        TablaPdas.Columns.Add("cantidad", Type.GetType("System.Int32"))
    End Sub

    Private Sub LlenarTabla(ByVal tiposol As Integer, ByVal origen As Integer, ByVal tipdoc As Integer, ByVal valor As Double, ByVal documento As String, ByVal concepto As String, ByVal descsol As String)
        Dim contador As Integer = 0
        For i As Integer = 0 To TablaPdas.Rows.Count - 1
            If TablaPdas.Rows(i).Item("origen") = origen And TablaPdas.Rows(i).Item("tiposol") = tiposol And TablaPdas.Rows(i).Item("tipdoc") = tipdoc Then
                TablaPdas.Rows(i).Item("valor") += valor
                TablaPdas.Rows(i).Item("documento") &= "," & documento
                TablaPdas.Rows(i).Item("concepto") &= vbCrLf & concepto
                TablaPdas.Rows(i).Item("cantidad") += 1
                contador += 1
            End If
        Next
        If contador = 0 Then
            TablaPdas.Rows.Add(tiposol, origen, tipdoc, valor, documento, descsol & vbCrLf & concepto, 1)
        End If
    End Sub

    Private Function RetornaConstante(ByVal Constante As Integer) As Double
        Dim ValorRetorno As Double
        ValorRetorno = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = " & Constante)
        If ValorRetorno = Nothing Then
            ValorRetorno = 0.0
        End If
        Return ValorRetorno
    End Function

    Private Sub FrmSolSinProgramar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class

