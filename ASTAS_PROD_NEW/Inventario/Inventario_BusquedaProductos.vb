Imports System.Data.SqlClient

Public Class Inventario_BusquedaProductos

    'Constructor
    Dim fill As New jarsClass

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader As SqlDataReader

    'Declaraciones
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Public Compañia_Value As Integer
    Public BuscaProductosStock As Boolean

    'Cuando carga el formulario
    Private Sub Inventario_BusquedaProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        txtCompañia.Text = Descripcion_Compañia
        cargaCMB()
        Iniciando = False
    End Sub

    'Si se cambia el valor de la compañía
    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            fill.CargaGrupos(Compañia, Me.cmbGRUPO)
        End If
    End Sub

    'Carga los comboBox
    Private Sub cargaCMB()        
        If Compañia_Value <> Nothing Then

        End If
        fill.CargaGrupos(Compañia, Me.cmbGRUPO)
    End Sub

    'Validacion comilla simple
    Private Sub txtDescripProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripProducto.KeyPress
        fill.noComillaSimple(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscar.PerformClick()
        End If        
    End Sub

    'Limpia Campos
    Private Sub limpiaCampos()
        cargaCMB()
        Me.txtDescripProducto.Clear()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If valCamposVacios() = Nothing Then
            buscarProductos(Compañia, Me.cmbGRUPO.SelectedValue, Trim(Me.txtDescripProducto.Text))
            limpiaCampos()
        End If
    End Sub

    'Valida si los comboBox tienen o no valores, de no tener no hace la busqueda
    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Compañia = Nothing Then
            camposVacios &= vbCrLf & "Compañía"
        End If
        If Me.cmbGRUPO.SelectedValue = Nothing And Me.cmbGRUPO.Text <> "No Definido" Then
            camposVacios &= vbCrLf & "Grupo"
        End If
        If camposVacios <> Nothing Then
            MsgBox("No se puede continuar con la operación debido a" & vbCrLf & "la falta de información en los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Sub LimpiaGrid()
        Me.dgvProductos.Columns.Item(0).Visible = False
        Me.dgvProductos.Columns.Item(2).Visible = False
        Me.dgvProductos.Columns.Item(3).Visible = False
        Me.dgvProductos.Columns.Item(4).Visible = False
        Me.dgvProductos.Columns.Item(6).Visible = False
        Me.dgvProductos.Columns.Item(8).Visible = False
        Me.dgvProductos.Columns.Item(11).Visible = False
        Me.dgvProductos.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        fill.ajustarGrid(13, Me.dgvProductos)
        Me.dgvProductos.Columns(13).Width = 75
        Me.dgvProductos.Columns(14).Width = 125
    End Sub

    Private Sub buscarProductos(ByVal cia, ByVal grupo, ByVal descripcion)
        If cia = Nothing Then
            cia = 0
        End If
        If grupo = Nothing Then
            grupo = 0
        End If
        If descripcion = Nothing Then
            descripcion = "0"
        End If
        Dim servicios As Integer
        If chkServicio.Checked = True Then
            servicios = 1
        Else
            servicios = 0
        End If
        Try
            sql = " Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS "
            sql &= "@COMPAÑIA=" & cia
            sql &= ", @GRUPO=" & grupo
            sql &= ", @DESCRIPCION_PRODUCTO='" & descripcion & "'"
            sql &= ", @BANDERA=" & 1
            sql &= ", @SERVICIO=" & servicios
            Table = fill.obtenerDatos(New SqlCommand(sql))
            Me.dgvProductos.Columns.Clear()
            Me.dgvProductos.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If Me.dgvProductos.RowCount = 0 Then
            Return
        Else
            If Me.dgvProductos.CurrentRow.Index < Me.dgvProductos.Rows.Count Then
                If BuscaProductosStock = False Then                    
                    Numero = ""
                    Producto = ""
                    Descripcion_Producto = ""
                    Check = 0
                    Numero_Factura = 0
                    'Valor compañía
                    CodigoProducto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                    'Descripción del producto
                    Numero = Me.dgvProductos.CurrentRow.Cells.Item(5).Value
                    'Grupo del Producto
                    Producto = Me.dgvProductos.CurrentRow.Cells.Item(2).Value
                    'Subgrupo del producto
                    Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(3).Value
                    'Unidad de Medida
                    Numero_Factura = Me.dgvProductos.CurrentRow.Cells.Item(6).Value
                    'Unidad Libra
                    If Me.dgvProductos.CurrentRow.Cells.Item(8).Value = False Then
                        Check = 0
                    ElseIf Me.dgvProductos.CurrentRow.Cells.Item(8).Value Then
                        Check = 1
                    End If
                    Me.Close()
                    Me.Dispose()
                Else
                    If Me.dgvProductos.CurrentRow.Cells.Item(9).Value = False And Me.dgvProductos.CurrentRow.Cells.Item(10).Value = True Then
                        Numero = ""
                        Producto = ""
                        Descripcion_Producto = ""
                        Check = 0
                        Numero_Factura = 0
                        'Valor compañía
                        CodigoProducto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                        'Descripción del producto
                        Numero = Me.dgvProductos.CurrentRow.Cells.Item(5).Value
                        'Grupo del Producto
                        Producto = Me.dgvProductos.CurrentRow.Cells.Item(2).Value
                        'Subgrupo del producto
                        Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(3).Value
                        'Unidad de Medida
                        Numero_Factura = Me.dgvProductos.CurrentRow.Cells.Item(6).Value
                        'Unidad Libra
                        If Me.dgvProductos.CurrentRow.Cells.Item(8).Value = False Then
                            Check = 0
                        ElseIf Me.dgvProductos.CurrentRow.Cells.Item(8).Value Then
                            Check = 1
                        End If
                        Me.Close()
                        Me.Dispose()
                    Else
                        MsgBox("¡Debe seleccionar un Producto que sea de 'Stock'! Verifique" & Chr(13) & "No puede seleccionar Servicios o Productos que sean No Stock.", MsgBoxStyle.Critical, "Validación")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub
End Class