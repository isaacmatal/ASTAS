Imports System.Data.SqlClient

Public Class Contabilidad_CuentasSaldos
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Libro As Integer
    Dim Table As DataTable
    Dim jClass As New jarsClass

    Private Sub Contabilidad_CuentasSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compa�ia)
        CargaA�os()
        CargaMes()
        Iniciando = False
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA_COMPLETA_01.Text = ""
        Me.txtCUENTA_COMPLETA_02.Text = ""
        Me.txtDESCRIPCION_CUENTA_01.Text = ""
        Me.txtDESCRIPCION_CUENTA_02.Text = ""
        Me.dgvSaldos.DataSource = Nothing
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvSaldos.Columns(0).Width = 100
        Me.dgvSaldos.Columns(1).Width = 200
        Me.dgvSaldos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvSaldos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvSaldos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvSaldos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvSaldos.Columns(2).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvSaldos.Columns(5).DefaultCellStyle.ForeColor = Color.Blue

        Me.dgvSaldos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvSaldos.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvSaldos.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvSaldos.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CargaLibrosContables(ByVal Compa�ia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE LIBRO_PRINCIPAL = 1 AND COMPA�IA = " & Compa�ia
            Comando_ = New SqlCommand(Sql, Conexion_)
            Libro = Comando_.ExecuteScalar
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaA�os()
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
            If Table.Rows.Count = 0 Then
                Table.Rows.Add(Now.Year)
            End If
            Me.cmbA�O.DataSource = Table
            Me.cmbA�O.ValueMember = "A�o"
            Me.cmbA�O.DisplayMember = "A�o"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaMes()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_MESES "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMES.DataSource = Table
            Me.cmbMES.ValueMember = "Mes"
            Me.cmbMES.DisplayMember = "Descripci�n"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasSaldos(ByVal Compa�ia, ByVal LibroContable, ByVal CuentaIni, ByVal CuentaFin, ByVal Fecha, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_SALDOS "
            Sql &= Compa�ia
            Sql &= ", " & LibroContable
            Sql &= ", '" & CuentaIni & "'"
            Sql &= ", '" & CuentaFin & "'"
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Bandera
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

    Private Function ValidaCamposBusqueda() As Boolean
        If Trim(Me.txtCUENTA_COMPLETA_01.Text) = "" Then
            MsgBox("�Debe seleccionar una Cuenta Contable Inicial!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.txtCUENTA_COMPLETA_02.Text) = "" Then
            MsgBox("�Debe seleccionar una Cuenta Contable Final!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ConvierteFecha(ByVal A�o, ByVal Mes) As Date
        Dim Fecha As Date
        Select Case Mes
            Case 1
                Fecha = "31-Ene-" & A�o.ToString & " 23:59:59"
            Case 2
                Fecha = "28-Ene-" & A�o.ToString & " 23:59:59"
            Case 3
                Fecha = "31-Mar-" & A�o.ToString & " 23:59:59"
            Case 4
                Fecha = "30-Abr-" & A�o.ToString & " 23:59:59"
            Case 5
                Fecha = "31-May-" & A�o.ToString & " 23:59:59"
            Case 6
                Fecha = "30-Jun-" & A�o.ToString & " 23:59:59"
            Case 7
                Fecha = "31-Jul-" & A�o.ToString & " 23:59:59"
            Case 8
                Fecha = "31-Ago-" & A�o.ToString & " 23:59:59"
            Case 9
                Fecha = "30-Sep-" & A�o.ToString & " 23:59:59"
            Case 10
                Fecha = "31-Oct-" & A�o.ToString & " 23:59:59"
            Case 11
                Fecha = "30-Nov-" & A�o.ToString & " 23:59:59"
            Case 12
                Fecha = "31-Dic-" & A�o.ToString & " 23:59:59"
        End Select
        Return Fecha
    End Function

    Private Sub btnBuscar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar01.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compa�ia_Value = Compa�ia
        Cuentas.LibroContable_Value = Libro
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_COMPLETA_01.Text = Tipo
            Me.txtDESCRIPCION_CUENTA_01.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnBuscar02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar02.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compa�ia_Value = Compa�ia
        Cuentas.LibroContable_Value = Libro
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_COMPLETA_02.Text = Tipo
            Me.txtDESCRIPCION_CUENTA_02.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If ValidaCamposBusqueda() = True Then
            CargaCuentasSaldos(Compa�ia, Libro, Me.txtCUENTA_COMPLETA_01.Text, Me.txtCUENTA_COMPLETA_02.Text, Format(ConvierteFecha(Me.cmbA�O.SelectedValue, Me.cmbMES.SelectedValue), "dd-MM-yyyy HH:mm:ss"), 1)
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub Contabilidad_CuentasSaldos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New Contabilidad_Reporte_Saldos_Cuentas
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compa�ia
        txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "Saldos de Cuentas: " & Me.cmbMES.Text & "-" & Me.cmbA�O.Text
        rpt.SetDataSource(Table)
        frmVer.crvReporte.ReportSource = rpt
        frmVer.ShowDialog(Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TableDatos As DataTable
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New Contabilidad_Reporte_Saldos_Mensuales
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "PERIODO CONTABLE: " & Me.cmbMES.Text & "-" & Me.cmbA�O.Text
        Sql = "SELECT C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, S.SALDO, CC.NOMBRE_COMPA�IA, "
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,1) AS CLASIFICACION, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = C.COMPA�IA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,1)) AS DESCCLASIF,"
        Sql &= "	   SUBSTRING(C.CUENTA_COMPLETA,1,2) AS GRUPO, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = C.COMPA�IA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,2)) AS DESCGRUPO,"
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,4) AS SUBGRUPO, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = C.COMPA�IA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,4)) AS DESCSUBGR,"
        Sql &= "	   SUBSTRING(C.CUENTA_COMPLETA,1,6) AS CUENTA, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = C.COMPA�IA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,6)) AS DESCCUENTA,"
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,8) AS SUBCUENTA, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = C.COMPA�IA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,8)) AS DESCSUBCTA"
        Sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS C "
        Sql &= "       LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS S "
        Sql &= "	          ON C.COMPA�IA = S.COMPA�IA "
        Sql &= "		     AND C.LIBRO_CONTABLE = S.LIBRO_CONTABLE "
        Sql &= "		     AND C.CUENTA = S.CUENTA"
        Sql &= "		     AND S.MES = " & Me.cmbMES.SelectedValue
        Sql &= "		     AND S.A�O = " & Me.cmbA�O.SelectedValue & ","
        Sql &= "        CATALOGO_COMPA�IAS CC "
        Sql &= "        WHERE C.COMPA�IA = CC.COMPA�IA"
        Sql &= "   AND C.COMPA�IA = " & Compa�ia
        Sql &= "   AND C.LIBRO_CONTABLE = " & Libro
        Sql &= "   AND C.CUENTA_MAYOR = 0"
        Sql &= " ORDER BY CUENTA_COMPLETA"
        TableDatos = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(TableDatos)
        frmVer.crvReporte.ReportSource = rpt
        frmVer.ShowDialog(Me)
    End Sub
End Class