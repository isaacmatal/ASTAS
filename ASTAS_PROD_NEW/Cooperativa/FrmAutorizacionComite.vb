Imports System.Data
Imports System.Data.SqlClient
Public Class FrmAutorizacionComite
    Dim Sql As String
    Dim Iniciando As Boolean
    Private Sub FrmAutorizacionComite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        FechaActual()
        CargaCompany(Usuario, 1)
        Carga_TipoSolicitudes()
        Carga_Solicitudes(5)
        LimpiaGrid()
        Iniciando = False
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
    Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERA)
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
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
    Private Sub Carga_TipoSolicitudes()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PRESTAMO " & CbxCompania.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable
            DataAdapter_.Fill(Table)
            CbxTipoSolicitudes.ValueMember = "SOLICITUD"
            CbxTipoSolicitudes.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxTipoSolicitudes.DataSource = Table
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Carga_Solicitudes(ByVal Bandera)
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.SP_COOPERATIVA_TODAS_LAS_SOLICITUDES " & CbxCompania.SelectedValue & "," & IIf(CbxTipoSolicitudes.Text = Nothing, 0, CbxTipoSolicitudes.SelectedValue) & "," & IIf(TxtNumSol.Text = Nothing, 0, TxtNumSol.Text) & ",'" & Format(DpFechaIni.Value, "dd-MM-yyyy 00:00:01") & "','" & Format(DpFechaFin.Value, "dd-MM-yyyy 23:59:59") & "'," & Bandera
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
        Me.DgvSolicitudes.Columns(0).Width = 48
        Me.DgvSolicitudes.Columns(1).Visible = False
        Me.DgvSolicitudes.Columns(2).Visible = False
        Me.DgvSolicitudes.Columns(4).Visible = False
        Me.DgvSolicitudes.Columns(13).Visible = False
        Me.DgvSolicitudes.Columns(14).Visible = False
        Me.DgvSolicitudes.Columns(15).Visible = False
        Me.DgvSolicitudes.Columns(16).Visible = False
        Me.DgvSolicitudes.Columns(17).Visible = False
        Me.DgvSolicitudes.Columns(18).Visible = False
        Me.DgvSolicitudes.Columns(19).Visible = False
        Me.DgvSolicitudes.Columns(3).Width = 165
        Me.DgvSolicitudes.Columns(5).Width = 175
        Me.DgvSolicitudes.Columns(6).Width = 75
        Me.DgvSolicitudes.Columns(7).Width = 175
        Me.DgvSolicitudes.Columns(8).Width = 60
        Me.DgvSolicitudes.Columns(9).Width = 50
        Me.DgvSolicitudes.Columns(10).Width = 50
        Me.DgvSolicitudes.Columns(11).Width = 45
        Me.DgvSolicitudes.Columns(12).Width = 100
        Me.DgvSolicitudes.Columns.Item(8).DefaultCellStyle.Format = "##,##0.00"
        Me.DgvSolicitudes.Columns.Item(8).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxCompania.SelectedIndexChanged
        If Iniciando = False Then
            Carga_TipoSolicitudes()
            Carga_Solicitudes(5)
            LimpiaGrid()
        End If
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

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If CDate(DpFechaIni.Value.ToShortDateString) > CDate(DpFechaFin.Value.ToShortDateString) Then
            MsgBox("¡La fecha  ''Hasta''  no puede ser menor que la fecha  ''Desde''", MsgBoxStyle.Critical, "Validación")
            DpFechaFin.Focus()
            Return
        End If
        Carga_Solicitudes(6)
    End Sub

    Private Sub TsmiAutorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsmiAutorizacion.Click, BtnAutorizar.Click
        If DgvSolicitudes.RowCount = 0 Then
            MsgBox("Debe de seleccionar una solicitud", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If VerificaUsuario() = False Then
            MsgBox("No Tiene Permisos para autorizar esta solicitud", MsgBoxStyle.Critical, "Validación")
            Return
        End If

        '**********************************.
        If DgvSolicitudes.CurrentRow.Index < DgvSolicitudes.RowCount And DgvSolicitudes.CurrentRow.Cells.Item(0).Value <> 0 Then
            ParamcodSolicitud = DgvSolicitudes.CurrentRow.Cells.Item(0).Value
            Dim FrmAutori As New FrmAutorizaciones
            FrmAutori.TipoSolicitud = DgvSolicitudes.CurrentRow.Cells.Item(2).Value
            Dim TipoSol As Integer = DgvSolicitudes.CurrentRow.Cells.Item(2).Value
            FrmAutori.compañia = CbxCompania.SelectedValue
            FrmAutori.SpcAutorizacion_D_A.Visible = False
            'FrmAutori.Size = New System.Drawing.Size(702, 312)
            'FrmAutori.GbxAutorizacion.Size = New System.Drawing.Size(680, 208)
            FrmAutori.ShowDialog()
            Carga_Solicitudes(5)
        End If
    End Sub
    Private Function VerificaUsuario() As Boolean
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim bandera As Boolean
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES " & CbxCompania.SelectedValue & "," & 1 & ",'" & Usuario & "'," & DgvSolicitudes.CurrentRow.Cells.Item(2).Value & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                bandera = True
            Else
                bandera = False
            End If
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bandera
    End Function

End Class