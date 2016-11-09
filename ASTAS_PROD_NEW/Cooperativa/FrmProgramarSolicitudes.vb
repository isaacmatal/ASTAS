Imports System.Data
Imports System.Data.SqlClient
Public Class FrmProgramarSolicitudes
    Dim sql As String
    Dim Iniciando As Boolean
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Function GeneraSql() As String
        sql = "EXECUTE Coo.sp_COOPERATIVA_TODAS_LAS_SOLICITUDES_APROBADA" & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
        sql &= " @T_SOLICITUD = " & CbxTipoSolicitudes.SelectedValue & "," & vbCrLf
        sql &= " @N_SOLICITUD = " & Val(TxtNumSol.Text) & "," & VBCRLF
        sql &= " @FECHA_INI = '" & Format(DpFechaIni.Value, "dd-MM-yyyy 00:00:01") & "'," & vbCrLf
        sql &= " @FECHA_FIN = '" & Format(DpFechaFin.Value, "dd-MM-yyyy 23:59:59") & "'," & vbCrLf
        sql &= " @BANDERA = 4,"
        sql &= " @ORIGENES = '" & Permitir & "'"
        Return sql
    End Function

    Private Sub FrmProgramarSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Me.DpFechaIni.Value = Me.DpFechaFin.Value.Date.AddDays(-Me.DpFechaFin.Value.Date.Day).AddDays(1)
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Carga_TipoSolicitudes()
        Carga_Solicitudes()
        LimpiaGrid()
        Iniciando = False
    End Sub

    Private Sub Carga_TipoSolicitudes()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_TIPO_SOLICITUDES " & Compañia & "," & 0
            Comando_Track = New SqlCommand(sql, Conexion_Track)
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
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_TODAS_LAS_SOLICITUDES_APROBADA " & Compañia & "," & 0 & "," & 0 & "," & 0 & "," & 0 & "," & 3 & ", '" & Permitir & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvSolicitudes.DataSource = DS.Tables(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BuscaSolicitudes()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvSolicitudes.DataSource = DS.Tables(0)
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("¡No se ha encontrado ninguna Solicitud!", MsgBoxStyle.Critical, "Mensaje")
                DgvSolicitudes.DataSource = Nothing
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 48
        Me.DgvSolicitudes.Columns(1).Visible = False
        Me.DgvSolicitudes.Columns(2).Visible = False
        Me.DgvSolicitudes.Columns(12).Visible = False
        Me.DgvSolicitudes.Columns(3).Width = 165
        Me.DgvSolicitudes.Columns(4).Width = 60
        Me.DgvSolicitudes.Columns(5).Width = 175
        Me.DgvSolicitudes.Columns(6).Width = 75
        Me.DgvSolicitudes.Columns(7).Width = 175
        Me.DgvSolicitudes.Columns(8).Width = 60
        Me.DgvSolicitudes.Columns(9).Width = 50
        Me.DgvSolicitudes.Columns(10).Width = 50
        Me.DgvSolicitudes.Columns(11).Width = 45
        Me.DgvSolicitudes.Columns(14).Visible = False
        Me.DgvSolicitudes.Columns(15).Visible = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If CDate(DpFechaIni.Value.ToShortDateString) > CDate(DpFechaFin.Value.ToShortDateString) Then
            MsgBox("¡La fecha  ''Hasta''  no puede ser menor que la fecha  ''Desde''", MsgBoxStyle.Critical, "Validación")
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

    Private Sub BtnProgramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProgramacion.Click
        Dim FrmProgra As New FrmProgramacion
        If DgvSolicitudes.RowCount <> 0 Then
            FrmProgra.Monto_value = DgvSolicitudes.CurrentRow.Cells.Item(8).Value
            FrmProgra.Num_Solicitud = DgvSolicitudes.CurrentRow.Cells.Item(0).Value
            FrmProgra.ShowInTaskbar = False
            'If DgvSolicitudes.CurrentRow.Cells.Item(7).Value <> Nothing Then
            '    FrmProgra.ChxExcepcion.Checked = True
            'Else
            '    FrmProgra.ChxExcepcion.Checked = False
            'End If
            FrmProgra.ShowDialog(Me)
            Carga_Solicitudes()
        Else
            MessageBox.Show("Debe de seleccionar una solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnProgramacionEspecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgEspecial.Click
        Dim FrmPrograE As New FrmProgramacionEspecial
        If DgvSolicitudes.RowCount <> 0 Then
            FrmPrograE.Monto_value = DgvSolicitudes.CurrentRow.Cells.Item(8).Value
            FrmPrograE.Num_Solicitud = DgvSolicitudes.CurrentRow.Cells.Item(0).Value
            FrmPrograE.ShowDialog()
            Carga_Solicitudes()
        Else
            MessageBox.Show("Debe de seleccionar una solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FrmProgramarSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class