Imports System.Data
Imports System.Data.SqlClient
Public Class FrmManDeduccion
    Dim sql As String
    Dim Iniciando As Boolean

    Private Sub CargaDeducciones(ByVal compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & compañia & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DgvDeducciones.DataSource = Table
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.CbxLibroContable.DataSource = Table
            Me.CbxLibroContable.ValueMember = "Código"
            Me.CbxLibroContable.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Limpiar_Objetos()
        TxtCodigoDeducc.Text = ""
        TxtDescripcion.Text = ""
        TxtCuentaCont.Text = ""
        TxtCuentade.Text = ""
        TxtInteresDeuda.Text = ""
        txtSegDeuda.Text = ""
        Me.BtnEliminar.Enabled = False
        Me.TxtCodigoDeducc.ReadOnly = False
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvDeducciones.Columns(1).Width = 60
        Me.DgvDeducciones.Columns(2).Width = 150
        Me.DgvDeducciones.Columns(3).Width = 45
        Me.DgvDeducciones.Columns(7).Width = 250
        Me.DgvDeducciones.Columns(8).Width = 75
        Me.DgvDeducciones.Columns(9).Width = 125
        Me.DgvDeducciones.Columns(0).Visible = False
        Me.DgvDeducciones.Columns(4).Visible = False
        Me.DgvDeducciones.Columns(5).Visible = False

        Me.DgvDeducciones.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub Mantenimiento_Deducciones(ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "exec dbo.sp_COOPERATIVA_CATALOGO_DEDUCCIONES_IUD " & Compañia & "," _
            & CInt(Me.TxtCodigoDeducc.Text) & ",'" & Trim(TxtDescripcion.Text) & "'," & CbxLibroContable.SelectedValue & "," & lblCodigo.Text & "," & Val(Me.TxtInteresDeuda.Text) & ",'" & Usuario & "','" & IUD & "'," & Val(Me.txtSegDeuda.Text)
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Select Case IUD
                Case "I"
                    MsgBox("Deducción Creada Exitosamente", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("La deducción: " + Me.TxtDescripcion.Text + " ha sido modificada", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("Deducción Eliminada Exitosamente", MsgBoxStyle.Information, "Mensaje")
            End Select
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FrmManDeduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.lblNombreEmpresa.Text = Descripcion_Compañia
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaDeducciones(Compañia)
        CargaLibrosContables(Compañia)
        Iniciando = False
    End Sub

    Private Sub TxtCodigoDeducc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoDeducc.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtInteresDeuda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInteresDeuda.KeyPress
        Dim cadena As String = TxtInteresDeuda.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCuenta.Click
        Tipo = Nothing
        Descripcion_Producto = Nothing
        Try
            Dim FrmBuscarCuenta As New Contabilidad_BusquedaCuentas
            FrmBuscarCuenta.Compañia_Value = Compañia
            FrmBuscarCuenta.LibroContable_Value = CbxLibroContable.SelectedValue
            FrmBuscarCuenta.cmbCOMPAÑIA.Enabled = False
            FrmBuscarCuenta.cmbLIBRO_CONTABLE.Enabled = False
            FrmBuscarCuenta.ShowDialog()
            If Producto <> Nothing And Tipo <> Nothing And lblCodigo.Text <> Nothing Then
                TxtCuentaCont.Text = Tipo
                TxtCuentade.Text = Descripcion_Producto
                lblCodigo.Text = Producto
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaLibrosContables(Compañia)
            CargaDeducciones(Compañia)
            Limpiar_Objetos()
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Limpiar_Objetos()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If TxtCodigoDeducc.Text = Nothing Then
            Me.TxtCodigoDeducc.BackColor = Color.LightYellow
            MsgBox("Debe de ingresar un:  Código deducción", MsgBoxStyle.Information)
            Me.TxtCodigoDeducc.Focus()
            Return
        Else
            Me.TxtCodigoDeducc.BackColor = Color.White
        End If
        If TxtDescripcion.Text = Nothing Then
            Me.TxtDescripcion.BackColor = Color.LightYellow
            MsgBox("Debe de ingresar una:  Descripción", MsgBoxStyle.Information)
            Me.TxtDescripcion.Focus()
            Return
        Else
            Me.TxtDescripcion.BackColor = Color.White
        End If
        If TxtCuentaCont.Text = Nothing Then
            MsgBox("Debe de seleccionar una: Cuenta contable", MsgBoxStyle.Information)
            Me.BtnBuscarCuenta.Focus()
            Return
        End If
        If TxtInteresDeuda.Text = Nothing Then
            Me.TxtInteresDeuda.BackColor = Color.LightYellow
            MsgBox("Debe de ingresar el: Interés deuda", MsgBoxStyle.Information)
            Me.TxtInteresDeuda.Focus()
            Return
        Else
            Me.TxtInteresDeuda.BackColor = Color.White
        End If
        If txtSegDeuda.Text = Nothing Then
            Me.txtSegDeuda.BackColor = Color.LightYellow
            MsgBox("Debe de ingresar el: Interés deuda", MsgBoxStyle.Information)
            Me.txtSegDeuda.Focus()
            Return
        Else
            Me.txtSegDeuda.BackColor = Color.White
        End If
        Mantenimiento_Deducciones("I")
        CargaDeducciones(Compañia)
        Me.BtnEliminar.Enabled = True
        Me.TxtCodigoDeducc.ReadOnly = True
        Limpiar_Objetos()
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If Me.DgvDeducciones.RowCount <= 0 Or Me.TxtCodigoDeducc.Text = Nothing Then
            MsgBox("¡Debe Seleccionar una Deducción válida! Verifique", MsgBoxStyle.Critical, "Validación")
        Else
            Dim Result As DialogResult = MessageBox.Show("¿Está seguro(a) que desea eliminar la Solicitud N° " + TxtCodigoDeducc.Text & " ?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If Result = Windows.Forms.DialogResult.Yes Then
                Mantenimiento_Deducciones("D")
                CargaDeducciones(Compañia)
                Limpiar_Objetos()
                Me.BtnEliminar.Enabled = False
                Me.TxtCodigoDeducc.ReadOnly = False
            Else
            End If
        End If
    End Sub

    Private Sub CbxLibroContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxLibroContable.SelectedIndexChanged
        Limpiar_Objetos()
    End Sub

    Private Sub DgvDeducciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDeducciones.CellEnter
        Try
            If Me.DgvDeducciones.RowCount <= 0 Then
            Else
                CbxLibroContable.SelectedValue = DgvDeducciones.CurrentRow.Cells(4).Value
                TxtCodigoDeducc.Text = DgvDeducciones.CurrentRow.Cells(1).Value
                TxtDescripcion.Text = DgvDeducciones.CurrentRow.Cells(2).Value
                TxtInteresDeuda.Text = DgvDeducciones.CurrentRow.Cells(3).Value
                TxtCuentaCont.Text = DgvDeducciones.CurrentRow.Cells(6).Value
                TxtCuentade.Text = DgvDeducciones.CurrentRow.Cells(7).Value
                lblCodigo.Text = DgvDeducciones.CurrentRow.Cells(5).Value
                Me.txtSegDeuda.Text = DgvDeducciones.CurrentRow.Cells(10).Value
                Me.BtnEliminar.Enabled = True
                Me.TxtCodigoDeducc.ReadOnly = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FrmManDeduccion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class