Imports System.Data
Imports System.Data.SqlClient
Public Class FrmSolConsultar
    Dim Sql As String
    Dim Bandera As Integer = 0
    Dim Iniciando As Boolean
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub FrmSolConsultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        FechaActual()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargaCompany(Usuario, 1)
        Carga_TipoSolicitudes()
        Carga_Solicitudes()
        LimpiaGrid()
        Iniciando = False
    End Sub
    Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERAS)
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERAS
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.CbxCompania.DataSource = Table
            Me.CbxCompania.ValueMember = "COMPAÑIA"
            Me.CbxCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function FechaActual() As DateTime
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Fecha As DateTime
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR'" & 0 & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DataAdapter_.Fill(DS)
            DpFechaFin.Value = DS.Tables(0).Rows(0).Item(0)
            Fecha = DS.Tables(0).Rows(0).Item(0)
            DpFechaIni.Value = DpFechaFin.Value.AddDays(-DpFechaFin.Value.Day + 1)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Fecha
    End Function
    Private Sub Carga_TipoSolicitudes()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_TIPO_SOLICITUDES " & CbxCompania.SelectedValue & "," & 0
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable
            DataAdapter_.Fill(Table)
            CbxTipoSolicitudes.ValueMember = "SOLICITUD"
            CbxTipoSolicitudes.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxTipoSolicitudes.DataSource = Table
            CbxTipoSolicitudes.SelectedValue = 9999
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Carga_Solicitudes()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_COOPERATIVA_CONSULTAR_SOLICITUDES " & CbxCompania.SelectedValue & "," & 0 & "," & 0 & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DgvSolicitudes.DataSource = Table
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 48     'Correlativo
        Me.DgvSolicitudes.Columns(1).Width = 132    'Nombre Solicitud
        Me.DgvSolicitudes.Columns(2).Width = 60     'Autorización
        Me.DgvSolicitudes.Columns(3).Width = 60     'Pagada
        Me.DgvSolicitudes.Columns(4).Width = 60     'Programada
        Me.DgvSolicitudes.Columns(5).Width = 60     'Denegado
        Me.DgvSolicitudes.Columns(6).Width = 176    'Nombre Socio
        Me.DgvSolicitudes.Columns(7).Width = 66     'Fecha Solicitud
        Me.DgvSolicitudes.Columns(8).Width = 64     'Valor
        Me.DgvSolicitudes.Columns(9).Width = 60     'Interes
        Me.DgvSolicitudes.Columns(10).Width = 48    'Período
        Me.DgvSolicitudes.Columns(11).Width = 48    'Cuota
        Me.DgvSolicitudes.Columns(12).Width = 165   'Excepción
        Me.DgvSolicitudes.Columns(13).Width = 60    'Digitado
        Me.DgvSolicitudes.Columns(14).Width = 60    'Revisado
        Me.DgvSolicitudes.Columns(15).Width = 165   'Razón Anulada
        Me.DgvSolicitudes.Columns(16).Width = 165   'Razón Denegada
        Me.DgvSolicitudes.Columns(17).Width = 60    'Origen
        Me.DgvSolicitudes.Columns(18).Visible = False
        Me.DgvSolicitudes.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If CDate(DpFechaIni.Value.ToShortDateString) > CDate(DpFechaFin.Value.ToShortDateString) Then
            MsgBox("¡La fecha  ''Hasta''  no puede ser menor que la fecha  ''Desde''", MsgBoxStyle.Critical, "Validación")
            DpFechaFin.Focus()
            Return
        End If
        BuscaSolicitudes()
    End Sub
    Private Sub BuscaSolicitudes()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try

            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DgvSolicitudes.DataSource = Table
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("¡No se ha encontrado ninguna Solicitud!", MsgBoxStyle.Critical, "Mensaje")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function GeneraSql() As String
        Sql = "Execute dbo.sp_COOPERATIVA_CONSULTAR_SOLICITUDES " & CbxCompania.SelectedValue & "," & Me.CbxTipoSolicitudes.SelectedValue & ",'" & Format(DpFechaIni.Value, "dd-MM-yyyy 00:00:01") & "','" & Format(DpFechaFin.Value, "dd-MM-yyyy 23:59:59") & "'," & Bandera & ", '" & Permitir & "'"
        Return Sql
    End Function
    Private Sub ChkBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBox1.Click
        If Me.ChkBox1.Checked Then
            Bandera = 1
            Me.ChkBox2.CheckState = CheckState.Unchecked
            Me.ChkBox3.CheckState = CheckState.Unchecked
            Me.ChkBox4.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub ChkBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBox2.Click
        If Me.ChkBox2.Checked Then
            Bandera = 2
            Me.ChkBox1.CheckState = CheckState.Unchecked
            Me.ChkBox3.CheckState = CheckState.Unchecked
            Me.ChkBox4.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub ChkBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBox3.Click
        If Me.ChkBox3.Checked Then
            Bandera = 3
            Me.ChkBox1.CheckState = CheckState.Unchecked
            Me.ChkBox2.CheckState = CheckState.Unchecked
            Me.ChkBox4.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub ChckBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBox4.Click
        If Me.ChkBox4.Checked Then
            Bandera = 4
            Me.ChkBox1.CheckState = CheckState.Unchecked
            Me.ChkBox2.CheckState = CheckState.Unchecked
            Me.ChkBox3.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If MsgBox("¿Está seguro(a) que desea emitir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Dim Rpt As New Cooperativa_Reporte_Consultar_Solicitudes
            Dim Reporte As New frmReportes_Ver
            If Me.DgvSolicitudes.Columns.Count > 0 Then
                Rpt.SetDataSource(DgvSolicitudes.DataSource)
                Reporte.ReportesGenericos(Rpt)
                Reporte.ShowDialog()
            End If
        End If
    End Sub

    Private Sub FrmSolConsultar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class