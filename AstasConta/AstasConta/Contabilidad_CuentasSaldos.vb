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
        CargaLibrosContables(Compañia)
        CargaAños()
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

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE LIBRO_PRINCIPAL = 1 AND COMPAÑIA = " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            Libro = Comando_.ExecuteScalar
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaAños()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_AÑOS_CONTABLES "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            If Table.Rows.Count = 0 Then
                Table.Rows.Add(Now.Year)
            End If
            Me.cmbAÑO.DataSource = Table
            Me.cmbAÑO.ValueMember = "Año"
            Me.cmbAÑO.DisplayMember = "Año"
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
            Me.cmbMES.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasSaldos(ByVal Compañia, ByVal LibroContable, ByVal CuentaIni, ByVal CuentaFin, ByVal Fecha, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_SALDOS "
            Sql &= Compañia
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
            MsgBox("¡Debe seleccionar una Cuenta Contable Inicial!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtCUENTA_COMPLETA_02.Text) = "" Then
            MsgBox("¡Debe seleccionar una Cuenta Contable Final!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ConvierteFecha(ByVal Año, ByVal Mes) As Date
        Dim Fecha As Date
        Select Case Mes
            Case 1
                Fecha = "31-Ene-" & Año.ToString & " 23:59:59"
            Case 2
                Fecha = "28-Ene-" & Año.ToString & " 23:59:59"
            Case 3
                Fecha = "31-Mar-" & Año.ToString & " 23:59:59"
            Case 4
                Fecha = "30-Abr-" & Año.ToString & " 23:59:59"
            Case 5
                Fecha = "31-May-" & Año.ToString & " 23:59:59"
            Case 6
                Fecha = "30-Jun-" & Año.ToString & " 23:59:59"
            Case 7
                Fecha = "31-Jul-" & Año.ToString & " 23:59:59"
            Case 8
                Fecha = "31-Ago-" & Año.ToString & " 23:59:59"
            Case 9
                Fecha = "30-Sep-" & Año.ToString & " 23:59:59"
            Case 10
                Fecha = "31-Oct-" & Año.ToString & " 23:59:59"
            Case 11
                Fecha = "30-Nov-" & Año.ToString & " 23:59:59"
            Case 12
                Fecha = "31-Dic-" & Año.ToString & " 23:59:59"
        End Select
        Return Fecha
    End Function

    Private Sub btnBuscar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar01.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
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
        Cuentas.Compañia_Value = Compañia
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
            CargaCuentasSaldos(Compañia, Libro, Me.txtCUENTA_COMPLETA_01.Text, Me.txtCUENTA_COMPLETA_02.Text, Format(ConvierteFecha(Me.cmbAÑO.SelectedValue, Me.cmbMES.SelectedValue), "dd-MM-yyyy HH:mm:ss"), 1)
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
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "Saldos de Cuentas: " & Me.cmbMES.Text & "-" & Me.cmbAÑO.Text
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
        txtObj.Text = "PERIODO CONTABLE: " & Me.cmbMES.Text & "-" & Me.cmbAÑO.Text
        Sql = "SELECT C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, S.SALDO, CC.NOMBRE_COMPAÑIA, "
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,1) AS CLASIFICACION, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = C.COMPAÑIA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,1)) AS DESCCLASIF,"
        Sql &= "	   SUBSTRING(C.CUENTA_COMPLETA,1,2) AS GRUPO, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = C.COMPAÑIA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,2)) AS DESCGRUPO,"
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,4) AS SUBGRUPO, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = C.COMPAÑIA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,4)) AS DESCSUBGR,"
        Sql &= "	   SUBSTRING(C.CUENTA_COMPLETA,1,6) AS CUENTA, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = C.COMPAÑIA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,6)) AS DESCCUENTA,"
        Sql &= "       SUBSTRING(C.CUENTA_COMPLETA,1,8) AS SUBCUENTA, (SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = C.COMPAÑIA AND LIBRO_CONTABLE = C.LIBRO_CONTABLE AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,8)) AS DESCSUBCTA"
        Sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS C "
        Sql &= "       LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS S "
        Sql &= "	          ON C.COMPAÑIA = S.COMPAÑIA "
        Sql &= "		     AND C.LIBRO_CONTABLE = S.LIBRO_CONTABLE "
        Sql &= "		     AND C.CUENTA = S.CUENTA"
        Sql &= "		     AND S.MES = " & Me.cmbMES.SelectedValue
        Sql &= "		     AND S.AÑO = " & Me.cmbAÑO.SelectedValue & ","
        Sql &= "        CATALOGO_COMPAÑIAS CC "
        Sql &= "        WHERE C.COMPAÑIA = CC.COMPAÑIA"
        Sql &= "   AND C.COMPAÑIA = " & Compañia
        Sql &= "   AND C.LIBRO_CONTABLE = " & Libro
        Sql &= "   AND C.CUENTA_MAYOR = 0"
        Sql &= " ORDER BY CUENTA_COMPLETA"
        TableDatos = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(TableDatos)
        frmVer.crvReporte.ReportSource = rpt
        frmVer.ShowDialog(Me)
    End Sub
End Class