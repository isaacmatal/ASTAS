Imports System.Data.SqlClient

Public Class Contabilidad_Consulta_Auxiliar
    Dim Iniciando As Boolean
    Dim Sql As String

    Private Sub Contabilidad_Consulta_Auxiliar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        Iniciando = False
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

    Private Sub BuscaAuxiliar(ByVal Compa�ia, ByVal LC, ByVal CuentaCompleta, ByVal Mayor, ByVal Tama�oCuenta, ByVal FechaIni, ByVal FechaFin)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_PARTIDAS_AUXILIAR "
            Sql &= Compa�ia
            Sql &= ", " & LC
            Sql &= ", '" & CuentaCompleta & "'"
            Sql &= ", " & Mayor
            Sql &= ", " & Tama�oCuenta
            Sql &= ", '" & FechaIni & "'"
            Sql &= ", '" & FechaFin & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPartidas.Columns.Clear()
            Me.dgvPartidas.DataSource = Table
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.lblDESCRIPCION_CUENTA.Text = ""
        Me.dgvPartidas.Columns.Clear()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub


    Private Sub btnBuscarCTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCTA.Click
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
            'Me.txtCUENTA.Text = Producto
            Me.txtCUENTA_COMPLETA.Text = Tipo
            Me.lblDESCRIPCION_CUENTA.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
            BuscaAuxiliar(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA_COMPLETA.Text, IIf(Me.chkMayor.Checked = True, "1", "0"), Len(Me.txtCUENTA_COMPLETA.Text), Format(Me.dpFechaDesde.Value, "dd-MM-yyyy 00:00:01"), Format(Me.dpFechaHasta.Value, "dd-MM-yyyy 23:59:49"))
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Trim(Me.txtCUENTA_COMPLETA.Text) <> "" Then
            BuscaAuxiliar(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA_COMPLETA.Text, IIf(Me.chkMayor.Checked = True, "1", "0"), Len(Me.txtCUENTA_COMPLETA.Text), Format(Me.dpFechaDesde.Value, "dd-MM-yyyy 00:00:01"), Format(Me.dpFechaHasta.Value, "dd-MM-yyyy 23:59:49"))
        Else
            MsgBox("�Debe seleccionar una Cuenta Contable v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub Contabilidad_Consulta_Auxiliar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class
