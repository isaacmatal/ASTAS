Imports System.Data.SqlClient

Public Class Contabilidad_CuentasSaldos_Periodos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_CuentasSaldos_Periodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        CargaA�os_Ini()
        CargaCuentasSaldos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 0)
        Iniciando = False
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
        Me.cmbCOMPA�IA.Enabled = True
        Me.cmbLIBRO_CONTABLE.Enabled = True
        CargaCuentasSaldos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 0)
    End Sub

    Private Sub CargaCompa�ia()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContables(ByVal Compa�ia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripci�n"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaA�os_Ini()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_A�OS_CONTABLES "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbA�O_INI.DataSource = Table
            Me.cmbA�O_INI.ValueMember = "A�o"
            Me.cmbA�O_INI.DisplayMember = "A�o"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        For i As Integer = 1 To dgvSaldos.Columns.Count - 1
            Me.dgvSaldos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If i > 2 Then
                Me.dgvSaldos.Columns(i - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Me.dgvSaldos.Columns(4).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(8).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(12).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(16).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(20).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(24).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(28).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(32).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(36).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(40).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(44).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(48).DefaultCellStyle.ForeColor = Color.Navy

        Me.dgvSaldos.Columns(5).DefaultCellStyle.ForeColor = Color.Blue
        Me.dgvSaldos.Columns.Item(1).Frozen = True
    End Sub

    Private Sub CargaCuentasSaldos(ByVal Compa�ia, ByVal LibroContable, ByVal A�o)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_PERIODOS "
            Sql &= Compa�ia
            Sql &= ", " & LibroContable
            Sql &= ", " & A�o
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvSaldos.Columns.Clear()
            Me.dgvSaldos.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaCuentasSaldos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbA�O_INI.SelectedValue)
    End Sub

    Private Sub btnBuscar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = True
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_COMPLETA.Text = Tipo
            Me.txtDESCRIPCION_CUENTA.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
            Me.cmbCOMPA�IA.Enabled = False
            Me.cmbLIBRO_CONTABLE.Enabled = False
        End If
    End Sub

  
End Class