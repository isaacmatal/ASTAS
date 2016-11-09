Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaCuentas
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass
    Public Compañia_Value As Integer
    Public LibroContable_Value As Integer
    Public BuscaTodas As Boolean

    Private Sub Contabilidad_BusquedaCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        Me.cmbCOMPAÑIA.SelectedValue = Compañia_Value
        CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        Me.cmbLIBRO_CONTABLE.SelectedValue = LibroContable_Value
        btnBuscar.PerformClick()
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.cmbCOMPAÑIA.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvCuentas.Columns.Item(0).Width = 50
        'Me.dgvCuentas.Columns.Item(1).Width = 125
        'Me.dgvCuentas.Columns.Item(2).Width = 250
        ' Me.dgvCuentas.Columns.Item(3).Width = 50
        Me.dgvCuentas.Columns.Item(4).Width = 75
        Me.dgvCuentas.Columns.Item(5).Width = 125
        Me.dgvCuentas.Columns(0).Visible = False

        Me.dgvCuentas.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub BuscaCuentas(ByVal Compañia, ByVal LibroContable, ByVal CuentaCompleta, ByVal DescripcionCuenta)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", '" & CuentaCompleta & "'"
            Sql &= ", '" & DescripcionCuenta & "'"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvCuentas.Columns.Clear()
            Me.dgvCuentas.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscaCuentas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text))
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
End Class