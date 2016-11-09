Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FrmBuscarSolicitudesPrestamo
    Dim sql As String
    Public Bandera As Integer = 0
    Public origenes As String

    Private Function GeneraSql() As String
        sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_PRESTAMOS " & Compañia _
        & "," & IIf(Trim(TxtNumSolicitud.Text) = "", "0", Trim(Me.TxtNumSolicitud.Text)) & "," & _
        IIf(Trim(TxtCodigoAs.Text) = "", "0", Trim(Me.TxtCodigoAs.Text)) & "," _
        & IIf(Trim(TxtCodigoBuxis.Text) = "", "0", Trim(Me.TxtCodigoBuxis.Text)) & ",'" & Trim(Me.TxtNombre.Text) & "'," & Bandera & ", '" & origenes & "'"
        Return sql
    End Function

    Private Sub BuscaSolicitudes()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvSolicitudes.DataSource = DS.Tables(0)
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("No se ha encontrado ninguna Solicitud", MsgBoxStyle.Information, "Mensaje")
                DgvSolicitudes.DataSource = Nothing
                'Me.Close()
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 50
        Me.DgvSolicitudes.Columns(1).Visible = False
        Me.DgvSolicitudes.Columns(2).Width = 110
        Me.DgvSolicitudes.Columns(3).Width = 57
        Me.DgvSolicitudes.Columns(4).Width = 50
        Me.DgvSolicitudes.Columns(5).Width = 250
        Me.DgvSolicitudes.Columns(6).Width = 55
        Me.DgvSolicitudes.Columns(7).Width = 75
        Me.DgvSolicitudes.Columns(8).Width = 100
        Me.DgvSolicitudes.Columns(9).Width = 125
    End Sub
    Private Sub LimpiaCampos()
        Me.TxtCodigoAs.Text = ""
        Me.TxtCodigoBuxis.Text = ""
        Me.TxtNumSolicitud.Text = ""
        Me.TxtNombre.Text = ""
    End Sub
    Private Sub FrmBuscarSolicitudesPrestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        BuscaSolicitudes()
    End Sub

    Private Sub BtnBuscarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSolicitudes.Click
        If Me.TxtNombre.Text = Nothing And Me.TxtNumSolicitud.Text = Nothing And Me.TxtCodigoAs.Text = Nothing And Me.TxtCodigoBuxis.Text = Nothing Then
            MsgBox("¡Favor ingresar un filtro de búsqueda válido!", MsgBoxStyle.Critical, "Mensaje")
            DgvSolicitudes.DataSource = Nothing
        Else
            BuscaSolicitudes()
            LimpiaCampos()
        End If
    End Sub

    Private Sub TxtNumSolicitud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumSolicitud.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub DgvSolicitudes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitudes.CellClick
        Try
            If e.RowIndex = -1 Then
                Return
            Else
                ParamcodSolicitud = DgvSolicitudes.CurrentRow.Cells(0).Value()
                ParamcodigoAs = DgvSolicitudes.CurrentRow.Cells(3).Value()
                ParamcodigoBux = DgvSolicitudes.CurrentRow.Cells(4).Value()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FrmBuscarSolicitudesPrestamo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class