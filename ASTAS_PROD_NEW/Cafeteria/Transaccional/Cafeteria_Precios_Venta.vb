Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Precios_Venta
    Dim fill As New cmbFill
    Dim jasr_fill As New jarsClass
    Dim Frm_Bodegas As New Cafeteria_Busqueda_Recetas_por_Bodega
    Dim Sql As String

    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader
    Dim ganancia_ As Decimal
    Dim iva_valor_ As Decimal = 1.13
    Dim ejecutar_ As Boolean = True

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Precios_Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 10)
        CargarTiempoComida(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTiempo, "S")
        Iniciando = False
    End Sub
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
    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo As ComboBox, ByVal IUD As Char)
        Try
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            cmbTiempo.DataSource = Table
            cmbTiempo.ValueMember = "Tiempo de Comida"
            cmbTiempo.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error-CargarTiempoComida")
        End Try
    End Sub
    Sub CargarRecetas(ByVal Compañia As Integer, ByVal Bodega As Integer)
        Try
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "Execute sp_CAFETERIA_CATALOGO_RECETA_BODEGA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '0'"
            Sql &= ", '1'"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            DataAdapter_.Fill(Table)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error-CargarRecetas")
        End Try
    End Sub
    Sub MantenimientoProgramacion(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo, ByVal Codigo, ByVal Cantidad, ByVal IUD)
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Codigo
            Sql &= ", " & Cantidad
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Me.DgvProductos.DataSource = DS01.Tables(0)

            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error-MantenimientoProgramacion")
        End Try
    End Sub
    Sub Mantenimiento_de_Precios(ByVal Compañia, ByVal Bodega, ByVal Codigo, ByVal Cantidad, ByVal IUD, ByVal porcentaje_)
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_PRECIOS_VENTA_IUD "
            Sql &= "@COMPAÑIA=" & Compañia
            Sql &= ",@BODEGA=" & Bodega
            Sql &= ",@CODIGO= " & Codigo
            Sql &= ",@TIEMPO=" & cmbTiempo.SelectedValue
            Sql &= ",@PRECIO= " & Cantidad
            Sql &= ",@FECHA= '" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "'"
            Sql &= ",@USUARIO= '" & Usuario & "'"
            Sql &= ",@IUD= '" & IUD & "'"
            Sql &= ",@porcentaje= " & porcentaje_
            MiddleConnection()
            DataAdapter.Fill(DS01)
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error-Mantenimiento_de_Precios")
        End Try
    End Sub

    Private Sub DgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProductos.CellClick
        Me.txtProducto.Text = Me.DgvProductos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION1.Text = Me.DgvProductos.CurrentRow.Cells.Item(1).Value
        Me.txtMedida.Text = Me.DgvProductos.CurrentRow.Cells.Item(3).Value

        ejecutar_ = False
        Me.txtCantidad.Text = Me.DgvProductos.CurrentRow.Cells.Item(6).Value
        Me.txtPorcentaje.Text = Me.DgvProductos.CurrentRow.Cells.Item(12).Value.ToString()
        ejecutar_ = True
    End Sub

    Private Sub cmbTiempo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiempo.SelectedIndexChanged
        BtnBuscar.PerformClick()
    End Sub

    Private Sub Limpiar()
        txtProducto.Text = ""
        txtDESCRIPCION1.Text = ""
        txtMedida.Text = ""
        txtCantidad.Text = ""
        txtPorcentaje.Text = ""
    End Sub

    Private Sub btnGuardarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCB.Click
        Dim precio_ As Decimal = 0.0

        If Val(Me.txtPorcentaje.Text) <> 0 Then
            ganancia_ = ((Val(Me.txtPorcentaje.Text) * DgvProductos.Rows(DgvProductos.CurrentCell.RowIndex).Cells.Item(5).Value) / 100)
            precio_ = (ganancia_ + DgvProductos.Rows(DgvProductos.CurrentCell.RowIndex).Cells.Item(5).Value) * iva_valor_
        Else
            precio_ = Val(Me.txtCantidad.Text)
            Me.txtPorcentaje.Text = 0
        End If


        If MsgBox("¿Está seguro que desea Modificar el Precio del Producto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If (precio_ > 0) Then

                Mantenimiento_de_Precios(Me.cmbCOMPAÑIA.SelectedValue, cmbBODEGA.SelectedValue, Me.txtProducto.Text, precio_, "I", Me.txtPorcentaje.Text)
                If bodega_cocina1(0) = cmbBODEGA.SelectedValue Then
                    Mantenimiento_de_Precios(Me.cmbCOMPAÑIA.SelectedValue, bodega_cocina2(0), Me.txtProducto.Text, precio_, "U2", Me.txtPorcentaje.Text)
                Else
                    Mantenimiento_de_Precios(Me.cmbCOMPAÑIA.SelectedValue, bodega_cocina2(1), Me.txtProducto.Text, precio_, "U2", Me.txtPorcentaje.Text)
                End If

                MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")

                Limpiar()
            Else
                MsgBox("Falta especificar el Precio a Cambiar.", MsgBoxStyle.OkOnly, "Mensaje")
            End If
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
        End If
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtCantidad.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtCantidad.Text = ""
                Else
                    e.Handled = txtCantidad.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtCantidad.Text = ""
            End If
        End If
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        BtnBuscar.PerformClick()
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        BtnBuscar.PerformClick()
    End Sub

    Private Sub btnPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecios.Click
        Dim frmPermisos_ As New Seguridad_Solicitud_Permiso(1)
        frmPermisos_.ShowDialog()

        If continuar_ Then
            txtCantidad.Enabled = True
            txtCantidad.BackColor = Color.White

            txtPorcentaje.Enabled = True
            txtPorcentaje.BackColor = Color.White
        End If
    End Sub

    Private Sub txtPorcentaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentaje.TextChanged
        If ejecutar_ Then
            If Me.txtPorcentaje.Text.Length > 0 Then
                txtCantidad.Enabled = False
                txtCantidad.BackColor = Color.LightGray
                ejecutar_ = False
                ganancia_ = ((Val(Me.txtPorcentaje.Text) * DgvProductos.Rows(DgvProductos.CurrentCell.RowIndex).Cells.Item(5).Value) / 100)
                txtCantidad.Text = (ganancia_ + DgvProductos.Rows(DgvProductos.CurrentCell.RowIndex).Cells.Item(5).Value) * iva_valor_
                ejecutar_ = True
            Else
                txtCantidad.Enabled = True
                txtCantidad.BackColor = Color.White
            End If
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If ejecutar_ Then
            If Me.txtCantidad.Text.Length > 0 Then
                txtPorcentaje.Text = ""
                txtPorcentaje.Enabled = False
                txtPorcentaje.BackColor = Color.LightGray
            Else
                txtPorcentaje.Enabled = True
                txtPorcentaje.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtPorcentaje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtPorcentaje.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtPorcentaje.Text = ""
                Else
                    e.Handled = txtPorcentaje.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtPorcentaje.Text = ""
            End If
        End If
    End Sub
End Class