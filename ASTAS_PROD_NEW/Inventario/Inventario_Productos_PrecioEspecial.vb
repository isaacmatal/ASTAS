'Autor: Mauricio José Gámez Brito
Imports System.Data.SqlClient
Public Class Inventario_Productos_PrecioEspecial
    Dim Sql As String
    Dim iniciado As Boolean
    Dim jClass As New jarsClass
    Dim Comando_ As New SqlCommand
    Dim Table As DataTable

    Private Sub Inventario_Productos_PrecioEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        iniciado = False
        CargaCompañia()
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 5)
        cargarGrid()
        iniciado = True
    End Sub

    Private Sub CargaCompañia()
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ",@COMPAÑIA= " & Compañia
            Sql &= ",@USUARIO= '" & Usuario & "'"
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar_PB.Click
        If Me.cmbBODEGA.SelectedValue <> Nothing Then
            Dim Productos As New Inventario_BusquedaProductosBodega("", 1)
            Productos.Compañia_Value = Compañia
            Productos.Bodega_Value = Me.cmbBODEGA.SelectedValue
            Productos.cmbBODEGA.Enabled = False
            Producto = ""
            Descripcion_Producto = ""
            Productos.ShowDialog()

            If Producto <> Nothing Then
                Me.lblPRODUCTO_PB.Text = Producto
                Me.lblDESCRIPCION_PRODUCTO_PB.Text = Descripcion_Producto
                cargarExistencias()
                Me.lblregistro.Text = "N"
            End If
        Else
            MsgBox("Debe seleccionar una bodega", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub cargarExistencias()
        Dim existencias As Double
        Dim existencias_precioespecial As Double
        Try
            Sql = "select dbo.calcular_existencia_actual("
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= "," & Me.cmbBODEGA.SelectedValue
            Sql &= "," & Me.lblPRODUCTO_PB.Text.Trim
            Sql &= ",CONVERT(VARCHAR,Getdate(),103))"
            Comando_.CommandText = Sql
            existencias = jClass.obtenerEscalar(Sql)

            Sql = "SELECT ISNULL(SUM(CANTIDAD),0) AS CANTIDAD_EXISTENTE "
            Sql &= " FROM INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL"
            Sql &= " WHERE  PRODUCTO = " & Me.lblPRODUCTO_PB.Text.Trim
            Sql &= " AND COMPAÑIA = " & Me.cmbCOMPAÑIA.SelectedValue
            Sql &= " AND BODEGA = " & Me.cmbBODEGA.SelectedValue

            Comando_.CommandText = Sql
            existencias_precioespecial = jClass.obtenerEscalar(Sql)
            Me.lblExistencias.Text = existencias - existencias_precioespecial
            Me.lblExistencias_PE.Text = existencias_precioespecial
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.lblPRODUCTO_PB.Text.Length = 0 Then
            MsgBox("Debe selecionar un producto", MsgBoxStyle.Critical, "Error")
            Return
        End If
        If Me.txtcantidad.Text.Length = 0 Then
            MsgBox("Debe ingresar una cantidad", MsgBoxStyle.Critical, "Error")
            Me.txtcantidad.Focus()
            Return
        End If
        If Val(Me.lblExistencias.Text) < Val(Me.txtcantidad.Text) Then
            MsgBox("La cantidad ingresada supera a las existencias", MsgBoxStyle.Critical, "Eror")
            Me.txtcantidad.Focus()
            Return
        End If
        If Me.txtprecio.Text.Length = 0 Then
            MsgBox("Debe ingresar un precio", MsgBoxStyle.Critical, "Error")
            Me.txtprecio.Focus()
            Return
        End If
        If Me.lblregistro.Text = "N" Then
            ' Agregar
            mantenimiento_tabla(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text.Trim, Me.txtcantidad.Text, Me.txtprecio.Text, Usuario, "", "I")
        Else
            'Actualizar
            mantenimiento_tabla(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text.Trim, Me.txtcantidad.Text, Me.txtprecio.Text, Usuario, Me.lblid.Text.Trim, "U")
        End If
        cargarGrid()
        limpiarcampos()
        Me.lblregistro.Text = "N"
    End Sub

    Private Sub mantenimiento_tabla(ByVal compañia, ByVal bodega, ByVal producto, ByVal cantidad, ByVal precio, ByVal usuario, ByVal id, ByVal accion)
        If id = "" Then
            id = "''"
        End If
        If cantidad = "" Then
            cantidad = "''"
        End If
        If precio = "" Then
            precio = "''"
        End If
        Sql = "execute sp_INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL_IUD  "
        Sql &= compañia
        Sql &= "," & bodega
        Sql &= "," & producto
        Sql &= "," & cantidad
        Sql &= "," & precio
        Sql &= "," & usuario
        Sql &= "," & id
        Sql &= "," & accion

        Comando_.CommandText = Sql
        jClass.ejecutarComandoSql(Comando_)
        'execute sp_INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL_IUD 1,4,3010103,1,1.2,'desarrollo','I'
    End Sub

    Private Sub cargarGrid()
        Sql = "execute SP_INVENTARIOS_CARGAR_PRODUCTOS_PRECIO_ESPECIAL "
        Sql &= Me.cmbCOMPAÑIA.SelectedValue
        Sql &= " , " & Me.cmbBODEGA.SelectedValue
        Comando_.CommandText = Sql
        Table = jClass.obtenerDatos(Comando_)

        Me.dgvproductos.DataSource = Table
        Me.dgvproductos.Columns(0).Visible = False 'ID
        Me.dgvproductos.Columns(1).Width = 80 ' producto
        Me.dgvproductos.Columns(2).Width = 300 ' descripcion producto
        Me.dgvproductos.Columns(3).Width = 80 'cantidad
        Me.dgvproductos.Columns(4).Width = 80 ' precio

        Me.dgvproductos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvproductos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txtcantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        Dim cadena As String = Me.txtcantidad.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtprecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        Dim cadena As String = Me.txtprecio.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub bntNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevo.Click
        limpiarcampos()
        Me.lblregistro.Text = "N"
    End Sub

    Private Sub limpiarcampos()
        Me.lblPRODUCTO_PB.Clear()
        Me.lblDESCRIPCION_PRODUCTO_PB.Text = ""
        Me.lblExistencias.Text = "0.00"
        Me.txtcantidad.Clear()
        Me.txtprecio.Clear()
        Me.lblid.Text = ""
        Me.lblExistencias_PE.Text = "0.00"
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If iniciado = True Then
            cargarGrid()
        End If
    End Sub

    Private Sub dgvproductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        Me.lblid.Text = Me.dgvproductos.CurrentRow.Cells.Item(0).Value
        Me.lblPRODUCTO_PB.Text = Me.dgvproductos.CurrentRow.Cells.Item(1).Value
        Me.lblDESCRIPCION_PRODUCTO_PB.Text = Me.dgvproductos.CurrentRow.Cells.Item(2).Value
        Me.txtcantidad.Text = Me.dgvproductos.CurrentRow.Cells.Item(3).Value
        Me.txtprecio.Text = Me.dgvproductos.CurrentRow.Cells.Item(4).Value

        cargarExistencias()
        Me.lblregistro.Text = "A"
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If Me.lblid.Text.Length <> 0 Then
            If MsgBox("¿Esta seguro/a de eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                mantenimiento_tabla(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text, "", "", Usuario, Me.lblid.Text.Trim, "D")
                limpiarcampos()
                Me.lblregistro.Text = "N"
                cargarGrid()
            End If
        Else
            MsgBox("Debe seleccionar el item a eliminar", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

End Class