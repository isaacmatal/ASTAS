Imports System.Data
Imports System.Data.SqlClient

Public Class Cooperativa_Catalogo_Vales

    Dim Res As Integer
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim jClass As New jarsClass

    Private Sub Cooperativa_Catalogo_Tipo_Vales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        'Me.dgvTipos.AutoGenerateColumns = False
        Deducciones(Compañia)
        CargaVales()
    End Sub
    Private Sub Deducciones(ByVal Compania)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & Compania & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "Deducción"
            Me.CbxDeduccion.DisplayMember = "Descripción Deducción"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaVales()                
        dgvTipos.DataSource = jClass.ObtenerDataSet("Execute [dbo].[sp_COOPERATIVA_CATALOGO_VALES_SIUD] @COMPAÑIA = " & Compañia).Tables(0)

        For i As Integer = 1 To Me.dgvTipos.Columns.Count
            Me.dgvTipos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvTipos.Columns.Item(i - 1).Visible = True
        Next

    End Sub    

    Private Sub MantenimientoVales(ByVal SIUD As String)
        Res = 0
        sqlCmd.CommandText = "Execute [dbo].[sp_COOPERATIVA_CATALOGO_VALES_SIUD]"
        sqlCmd.CommandText &= "  @COMPAÑIA = " & Compañia
        sqlCmd.CommandText &= ", @CODIGO = " & Me.lblCodigo.Text
        sqlCmd.CommandText &= ", @DESCRIPCION = '" & Me.txtDescripcion.Text & "'"
        sqlCmd.CommandText &= ", @VALOR = " & Me.txtValor.Text
        sqlCmd.CommandText &= ", @ACTIVO = " & IIf(Me.chkActivo.Checked, 1, 0)
        sqlCmd.CommandText &= ", @PORCENTAJE = " & Me.txtPorc.Text
        sqlCmd.CommandText &= ", @DEDUCCION = " & Me.CbxDeduccion.SelectedValue
        sqlCmd.CommandText &= ", @USUARIO = '" & Usuario & "'"
        sqlCmd.CommandText &= ", @SIUD = '" & SIUD & "'"
        Res = jClass.ejecutarComandoSql(sqlCmd)
        If Res > 0 Then
            MsgBox("Catálogo actualizado con éxito", MsgBoxStyle.Information, "Catálogo")
        Else
            MsgBox("Catálogo no actualizado...", MsgBoxStyle.Information, "Catálogo Error")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Val(lblCodigo.Text) = 0 Then
            MantenimientoVales("I")
        Else
            MantenimientoVales("U")
        End If
        CargaVales()
        Me.btnNuevo.PerformClick()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            MantenimientoVales("D")
            CargaVales()
            Me.btnNuevo.PerformClick()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.lblCodigo.Text = "0"
        Me.txtDescripcion.Clear()
        Me.txtPorc.Text = "0.00"
        Me.chkActivo.Checked = False
        Me.txtValor.Text = "0.00"
    End Sub

    Private Sub dgvTipos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipos.CellClick
        If e.RowIndex > -1 Then
            Try
                Me.lblCodigo.Text = Me.dgvTipos.Rows(e.RowIndex).Cells(0).Value
                Me.txtDescripcion.Text = Me.dgvTipos.Rows(e.RowIndex).Cells(1).Value
                Me.txtValor.Text = Me.dgvTipos.Rows(e.RowIndex).Cells(2).Value
                Me.chkActivo.Checked = Me.dgvTipos.Rows(e.RowIndex).Cells(3).Value
                Me.txtPorc.Text = Me.dgvTipos.Rows(e.RowIndex).Cells(4).Value
                Me.CbxDeduccion.SelectedValue = Me.dgvTipos.Rows(e.RowIndex).Cells(6).Value
            Catch ex As Exception
                jClass.msjError(ex, "dgvTipos_CellClick()")
            End Try
        End If
    End Sub

    Private Sub soloNumeros_y_punto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress, txtPorc.KeyPress
        Dim cadena As String = sender.Text
        Dim Ocurrencias As Boolean
        Ocurrencias = cadena.Contains(".")
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> ControlChars.Tab And e.KeyChar <> Convert.ToChar(Keys.Enter) Then
            If e.KeyChar = "." Then
                If Ocurrencias Then
                    MsgBox("Ya hay un punto decimal.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            Else
                If Not IsNumeric(e.KeyChar) Then
                    MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub Cooperativa_Catalogo_Vales_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class