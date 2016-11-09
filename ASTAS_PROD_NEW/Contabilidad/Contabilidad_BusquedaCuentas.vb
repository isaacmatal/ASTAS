Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaCuentas
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass
    Public Compa�ia_Value As Integer
    Public LibroContable_Value As Integer
    Public BuscaTodas As Boolean

    Private Sub Contabilidad_BusquedaCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        Me.cmbCOMPA�IA.SelectedValue = Compa�ia_Value
        CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        Me.cmbLIBRO_CONTABLE.SelectedValue = LibroContable_Value
        btnBuscar.PerformClick()
        Iniciando = False
    End Sub

    Private Sub CargaCompa�ia()
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            Me.cmbCOMPA�IA.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContables(ByVal Compa�ia)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripci�n"
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

    Private Sub BuscaCuentas(ByVal Compa�ia, ByVal LibroContable, ByVal CuentaCompleta, ByVal DescripcionCuenta)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_BUSQUEDA "
            Sql &= Compa�ia
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

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscaCuentas(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text))
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
                    MsgBox("�Debe seleccionar una Cuenta de Detalle!", MsgBoxStyle.Critical, "Validaci�n")
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