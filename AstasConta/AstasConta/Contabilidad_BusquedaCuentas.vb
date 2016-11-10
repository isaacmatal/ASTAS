Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaCuentas
    Dim Sql As String
    Dim Iniciando As Boolean
    Public Compañia_Value As Integer
    Public LibroContable_Value As Integer
    Public BuscaTodas As Boolean
    Dim TableData As DataTable

    Private Sub Contabilidad_BusquedaCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compañia)
        Me.cmbLIBRO_CONTABLE.SelectedValue = LibroContable_Value
        btnBuscar.PerformClick()
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvCuentas.Columns(0).Visible = False
        Me.dgvCuentas.Columns(4).Visible = False
        Me.dgvCuentas.Columns(5).Visible = False
        Me.dgvCuentas.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvCuentas.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvCuentas.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub BuscaCuentas(ByVal Compañia, ByVal LibroContable, ByVal CuentaCompleta, ByVal DescripcionCuenta)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CUENTAS_BUSQUEDA" & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= "@LIBRO_CONTABLE = " & LibroContable & "," & vbCrLf
            Sql &= "@CUENTA_COMPLETA = '" & CuentaCompleta & "'," & vbCrLf
            Sql &= "@DESCRIPCION_CUENTA = '" & DescripcionCuenta & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            TableData = New DataTable("Datos")
            DataAdapter_.Fill(TableData)
            Me.dgvCuentas.Columns.Clear()
            Me.dgvCuentas.DataSource = TableData
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaLibrosContables(Compañia)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text))
        LimpiaCampos()
    End Sub

    Private Sub dgvCuentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        If Me.dgvCuentas.CurrentRow.Index < Me.dgvCuentas.Rows.Count Then
            If Me.dgvCuentas.CurrentRow.Cells.Item(3).Value <> True Then
                Producto = Me.dgvCuentas.CurrentRow.Cells.Item(0).Value
                Tipo = Me.dgvCuentas.CurrentRow.Cells.Item(1).Value
                Descripcion_Producto = Me.dgvCuentas.CurrentRow.Cells.Item(2).Value
                Me.Close()
                Me.Dispose()
            Else
                If BuscaTodas = True Then
                    Producto = Me.dgvCuentas.CurrentRow.Cells.Item(0).Value
                    Tipo = Me.dgvCuentas.CurrentRow.Cells.Item(1).Value
                    Descripcion_Producto = Me.dgvCuentas.CurrentRow.Cells.Item(2).Value
                    Me.Close()
                    Me.Dispose()
                Else
                    MsgBox("¡Debe seleccionar una Cuenta de Detalle!", MsgBoxStyle.Critical, "Validación")
                    Producto = ""
                    Tipo = ""
                    Descripcion_Producto = ""
                End If
            End If
        Else
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub Contabilidad_BusquedaCuentas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.TextChanged, txtDESCRIPCION_CUENTA.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = TableData.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvCuentas.DataSource = TableData
        Else
            rows = TableData.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvCuentas.DataSource = Nothing
            Me.dgvCuentas.DataSource = tablaT
        End If
        LimpiaGrid()
    End Sub
End Class