Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Catalogo_Descuentos
    Dim fill As New cmbFill

    Dim Sql As String

    Dim Iniciando As Boolean
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region
    Private Sub Cafeteria_Catalogo_Descuentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)

        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        MantenimientoDescuentos(0, "", 0.0, 0, "S")
        Iniciando = False
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.txtCodigo.Clear()
        Me.txtDescripcion.Clear()
        Me.txtMonto.Clear()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If MsgBox("¿Está seguro que desea agregar/Modificar detalle del descuento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If (Me.txtCodigo.Text <> Nothing) And (Me.txtDescripcion.Text <> Nothing) Then
                If Me.txtMonto.Text <> 0 Then
                    MantenimientoDescuentos(Me.txtCodigo.Text, Me.txtDescripcion.Text, Me.txtMonto.Text, Me.chkEn_Uso.CheckState, "I")
                    MantenimientoDescuentos(Me.txtCodigo.Text, "", 0.0, 0, "S")
                Else
                    MsgBox("Falta especificar Monto a descontar.", MsgBoxStyle.OkOnly, "Mensaje")
                End If
            Else
                MsgBox("Falta especificar código de descuento o descripción por adicionar.", MsgBoxStyle.OkOnly, "Mensaje")
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If MsgBox("¿Desea eliminar detalle de descuento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            MantenimientoDescuentos(Me.txtCodigo.Text, "", 0.0, 0, "D")
            MantenimientoDescuentos(Me.txtCodigo.Text, "", 0.0, 0, "S")
        End If
    End Sub
    Sub MantenimientoDescuentos(ByVal Codigo, ByVal Descripcion, ByVal Monto, ByVal En_Uso, ByVal IUD)
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_CATALOGO_DESCUENTOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Codigo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & Monto
            Sql &= ", " & En_Uso
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If IUD = "S" Then
                Me.DgvProductos.DataSource = DS01.Tables(0)
                Me.DgvProductos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                For i As Integer = 1 To 7
                    Me.DgvProductos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProductos.CellContentClick
        Me.txtCodigo.Text = Me.DgvProductos.CurrentRow.Cells.Item(1).Value
        Me.txtDescripcion.Text = Me.DgvProductos.CurrentRow.Cells.Item(2).Value
        Me.txtMonto.Text = Me.DgvProductos.CurrentRow.Cells.Item(3).Value
        If Me.DgvProductos.CurrentRow.Cells.Item(4).Value = 0 Then
            Me.chkEn_Uso.Checked = False
        Else
            Me.chkEn_Uso.Checked = True
        End If

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtMonto.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtMonto.Text = ""
                Else
                    e.Handled = txtMonto.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtMonto.Text = ""
            End If
        End If
    End Sub
End Class