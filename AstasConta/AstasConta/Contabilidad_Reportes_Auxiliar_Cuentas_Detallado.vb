Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Auxiliar_Cuentas_Detallado
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand

    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim controles1(2) As Object
        controles1(0) = Me.txtCuentaIni
        controles1(1) = Me.txtCONCEPTO_I
        Dim controles2(2) As Object
        controles2(0) = Me.txtCuentafin
        controles2(1) = Me.txtDesCtaFin
        Dim controles3(4) As Object
        controles3(0) = Me.txtCodDetalle
        controles3(1) = Me.txtDescDetalleIni
        controles3(2) = "Inicial"
        controles3(3) = Me.txtCuentaIni
        Dim controles4(4) As Object
        controles4(0) = Me.txtCodDetalle2
        controles4(1) = Me.txtDescDetalleFin
        controles4(2) = "Final"
        controles4(3) = Me.txtCuentafin
        Dim controles5(2) As Object
        controles5(0) = Me.txtCuentaIni
        controles5(1) = Me.txtDescDetalleIni
        Dim controles6(2) As Object
        controles6(0) = Me.txtCuentafin
        controles6(1) = Me.txtDescDetalleFin
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compañia)
        Iniciando = False
        Me.WindowState = FormWindowState.Maximized
        Me.CrystalReportViewer1.BackColor = Color.DarkGray
        Me.txtCuentaIni.Tag = Me.txtCONCEPTO_I
        Me.txtCuentafin.Tag = Me.txtDesCtaFin
        Me.btnBuscarCuenta1.Tag = controles1
        Me.btnBuscarCuenta2.Tag = controles2
        Me.btnBuscaDetalleIni.Tag = controles3
        Me.btnBuscaDetalleFin.Tag = controles4
        Me.txtCodDetalle.Tag = controles5
        Me.txtCodDetalle2.Tag = controles6
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Try
            sqlCmd.CommandText = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Table = jClass.obtenerDatos(sqlCmd)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        If Me.dpFecha_I.Value.Date <= Me.dpFecha_F.Value.Date Then
            Dim rpt As New Contabilidad_Reportes_Auxiliar_Cuentas_Detallado_RPT
            Dim rptgob As New Contabilidad_Reportes_Auxiliar_Cuentas_Gobernacion
            Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim Libro As Integer = Me.cmbLIBRO_CONTABLE.SelectedValue
            Dim MesAnt, YearAnt, RowsAffected As Integer
            txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
            txtObj.Text = Descripcion_Compañia
            txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
            txtObj.Text = "Del " & Me.dpFecha_I.Text & " al " & Me.dpFecha_F.Text
            txtObj = rptgob.Section2.ReportObjects.Item("txtEmpresa")
            txtObj.Text = Descripcion_Compañia
            txtObj = rptgob.Section2.ReportObjects.Item("txtPeriodo")
            txtObj.Text = "Del " & Me.dpFecha_I.Text & " al " & Me.dpFecha_F.Text

            If Me.dpFecha_I.Value.Month = 1 Then
                MesAnt = 12
                YearAnt = Me.dpFecha_I.Value.Year - 1
            Else
                MesAnt = Me.dpFecha_I.Value.Month - 1
                YearAnt = Me.dpFecha_I.Value.Year
            End If
            If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
                jClass.Ejecutar_ConsultaSQL(SaldosMesDetalle(MesAnt, YearAnt))

                'Temporalmente se hace un complementado de registros
                'por los movimientos que no tengan saldo inicial 
                'del mes anterior hasta que se cree un SP que 
                'genere este reporte

                Sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
                Sql &= "SELECT C.COMPAÑIA, C.LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, C.CUENTA,C.CUENTA_COMPLETA, 0 AS DETALLE, 0 AS SALDO," & vbCrLf
                Sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
                Sql &= "FROM CONTABILIDAD_CATALOGO_CUENTAS C " & vbCrLf
                Sql &= "   LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
                Sql &= "   ON C.COMPAÑIA = D.COMPAÑIA" & vbCrLf
                Sql &= "  AND C.LIBRO_CONTABLE = D.LIBRO_CONTABLE" & vbCrLf
                Sql &= "  AND C.CUENTA_COMPLETA = D.CUENTA_COMPLETA" & vbCrLf
                Sql &= "  AND D.MES = " & MesAnt & vbCrLf
                Sql &= "  AND AÑO = " & YearAnt & vbCrLf
                Sql &= "  AND D.LIBRO_CONTABLE = " & Libro & vbCrLf
                Sql &= "WHERE C.LIBRO_CONTABLE = " & Libro & vbCrLf
                Sql &= "  AND C.CUENTA_MAYOR = 0" & vbCrLf
                Sql &= "  AND C.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND D.SALDO IS NULL" & vbCrLf
                Sql &= "  AND C.CUENTA_COMPLETA IS NOT NULL" & vbCrLf
                RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(Sql))
                'MsgBox(RowsAffected, MsgBoxStyle.Information)

                'Temporalmente se hace un complementado de registros
                'por los movimientos que no tengas saldo inicial 
                'del mes anterior hasta que se cree un SP que 
                'genere este reporte
                Sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
                Sql &= "SELECT DISTINCT E.COMPAÑIA, " & Libro & " AS LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, E.CUENTA_CONTABLE AS CUENTA, " & vbCrLf
                Sql &= "    (SELECT CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = E.COMPAÑIA AND CUENTA = E.CUENTA_CONTABLE AND LIBRO_CONTABLE = " & Libro & " AND COMPAÑIA = " & Compañia & " ) AS CUENTA_CAT," & vbCrLf
                Sql &= "	E.COD_DETALLE, 0 AS SALDO," & vbCrLf
                Sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
                Sql &= "FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO E LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
                Sql &= "   ON E.COMPAÑIA = D.COMPAÑIA " & vbCrLf
                Sql &= "  AND E.CUENTA_CONTABLE = D.CUENTA " & vbCrLf
                Sql &= "  AND D.MES = " & MesAnt & vbCrLf
                Sql &= "  AND D.AÑO = " & YearAnt & vbCrLf
                Sql &= "  AND E.COD_DETALLE = D.DETALLE" & vbCrLf
                Sql &= "WHERE CONVERT(DATE, E.FECHA_TRAN) BETWEEN CONVERT(DATE, '" & Format(Me.dpFecha_I.Value.AddDays(-Me.dpFecha_I.Value.Day).AddDays(1), "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dpFecha_I.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
                Sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND D.CUENTA IS NULL" & vbCrLf
                Sql &= "  AND E.CUENTA_CONTABLE > 0" & vbCrLf
                RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(Sql))
                'MsgBox(RowsAffected, MsgBoxStyle.Information)
            End If
            Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_REPORTES_AUXILIAR_CUENTAS]" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
                Sql &= ",@LIBRO = " & IIf(Me.chkNoAgruparCod.Checked, "3", "2") & vbCrLf
            Else
                Sql &= ",@LIBRO = " & IIf(Me.chkNoAgruparCod.Checked, "6", "5") & vbCrLf
            End If
            Sql &= ",@CUENTAI = '" & Me.txtCuentaIni.Text & "'" & vbCrLf
            Sql &= ",@CUENTAF = '" & Me.txtCuentafin.Text & "'" & vbCrLf
            Sql &= ",@FECHAI = '" & Format(Me.dpFecha_I.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@FECHAF = '" & Format(Me.dpFecha_F.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@CODIGOI = " & Val(Me.txtCodDetalle.Text) & vbCrLf
            Sql &= ",@CODIGOF = " & Val(Me.txtCodDetalle2.Text) & vbCrLf
            If chkSaldoCero.Checked Then
                Sql &= ",@SALDOSCERO = 1" & vbCrLf
            End If

            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
                rpt.SetDataSource(Table)
                Me.CrystalReportViewer1.ReportSource = rpt
            ElseIf Me.cmbLIBRO_CONTABLE.SelectedValue = 2 Then
                rptgob.SetDataSource(Table)
                Me.CrystalReportViewer1.ReportSource = rptgob
            End If
        Else
            MsgBox("Fecha Inicial es Mayor que la Final.", MsgBoxStyle.Exclamation, "FECHAS")
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaIni.KeyPress, txtCuentafin.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If sender.Text.Trim = "" Then
                MsgBox("Ingrese un código de cuenta", MsgBoxStyle.Information)
            Else
                sender.tag.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & sender.Text.Trim & "'") ' AND CUENTA_MAYOR=0")

                If sender.Text.Trim = "" Then
                    MsgBox("Cuenta ingresada no existe. Favor verificar", MsgBoxStyle.Information, "CUENTAS")
                    sender.Text = ""
                    sender.Tag.Text = ""
                    sender.Focus()
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscarCuenta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta1.Click, btnBuscarCuenta2.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = False
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            sender.Tag(0).Text = Tipo
            sender.Tag(1).Text = Descripcion_Producto
        End If
    End Sub

    Private Sub txtCodDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodDetalle.KeyPress, txtCodDetalle2.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Detallado_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnBuscaDetalleIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaDetalleIni.Click, btnBuscaDetalleFin.Click
        Dim TipoCat As Integer
        If sender.Tag(3).Text.Length = 0 Then
            MsgBox("Ingrese la Cuenta " & sender.Tag(2).ToString(), MsgBoxStyle.Information, "Busqueda Códigos")
            Return
        End If
        TipoCat = CInt(jClass.obtenerEscalar("SELECT CATALOGO FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA = '" & sender.Tag(3).Text & "'"))
        If TipoCat = 0 Then
            MsgBox("La Cuenta " & sender.Tag(3).Text & " No tiene Catálogo relacionado.", MsgBoxStyle.Information, "Busqueda Códigos")
            Return
        End If
        Producto = ""
        Nombre_Factura = ""
        Dim FrmCodigos As New Contabilidad_BusquedaCodigoDetalle(TipoCat)
        FrmCodigos.ShowDialog(Me)
        sender.Tag(0).Text = Producto
        sender.Tag(1).Text = Nombre_Factura
    End Sub

    Private Sub txtCodDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodDetalle.LostFocus, txtCodDetalle2.LostFocus
        Dim TipoCat As Integer
        If Val(sender.Text) > 0 Then
            If sender.Tag(0).Text.Length = 0 Then
                MsgBox("Ingrese la Cuenta " & sender.Tag(2).ToString(), MsgBoxStyle.Information, "Busqueda Códigos")
                Return
            End If
            TipoCat = CInt(jClass.obtenerEscalar("SELECT CATALOGO FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA = '" & sender.Tag(0).Text & "'"))
            If TipoCat = 0 Then
                sender.Tag(1).Text = "La Cuenta " & sender.Tag(0).Text & " No tiene Catálogo relacionado."
                Return
            End If
            sender.Tag(1).Text = jClass.obtenerEscalar("SELECT DESCRIPCION FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " AND TIPO = " & TipoCat & " AND CODIGO = " & sender.Text)
        Else
            sender.Tag(1).Text = ""
        End If
    End Sub

    Private Function SaldosMesDetalle(ByVal Mes As Integer, ByVal Year As Integer) As String
        Dim query As String
        query = "DECLARE @COMPAÑIA INT=" & Compañia & ", @LIBRO_CONTABLE INT, @MES INT, @AÑO INT, @FECHAAPERTURA AS DATETIME = '01/" & Mes.ToString.PadLeft(2, "0") & "/" & Year.ToString() & "'" & vbCrLf
        query &= "" & vbCrLf
        query &= "SET @MES = MONTH(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @AÑO = YEAR(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @FECHAAPERTURA = DATEADD(M, 1, @FECHAAPERTURA)" & vbCrLf
        query &= "SELECT @LIBRO_CONTABLE = LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = @COMPAÑIA AND LIBRO_PRINCIPAL = 1" & vbCrLf
        query &= "" & vbCrLf
        query &= "DELETE FROM [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE] WHERE COMPAÑIA = @COMPAÑIA AND MES = @MES AND AÑO = @AÑO" & vbCrLf
        query &= "" & vbCrLf
        query &= "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
        query &= "SELECT @COMPAÑIA AS COMPAÑIA, A.LIBRO_CONTABLE," & vbCrLf
        query &= "	     @AÑO AS AÑO," & vbCrLf
        query &= "	     @MES AS MES," & vbCrLf
        query &= "	     A.CUENTA_CONTABLE," & vbCrLf
        query &= "	     C.CUENTA_COMPLETA, " & vbCrLf
        query &= "       A.COD_DETALLE, " & vbCrLf
        query &= "       CASE WHEN C.TIPO_CUENTA = 1 OR C.TIPO_CUENTA = 4 THEN A.CARGOS - A.ABONOS ELSE A.ABONOS - A.CARGOS END AS SALDO, " & vbCrLf
        query &= "	     '" & Usuario & "' AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	     @FECHAAPERTURA AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	     '" & Usuario & "' AS USUARIO_EDICION_FECHA," & vbCrLf
        query &= "	     @FECHAAPERTURA AS USUARIO_EDICION_FECHA" & vbCrLf
        query &= "  FROM (SELECT COMPAÑIA, CUENTA_CONTABLE, COD_DETALLE, SUM(CARGOS) AS CARGOS, SUM(ABONOS) AS ABONOS, @LIBRO_CONTABLE AS LIBRO_CONTABLE" & vbCrLf
        query &= "          FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO" & vbCrLf
        query &= "	       WHERE FECHA_TRAN < @FECHAAPERTURA" & vbCrLf
        query &= "	       GROUP BY COMPAÑIA, CUENTA_CONTABLE, COD_DETALLE) A, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
        query &= " WHERE A.COMPAÑIA = C.COMPAÑIA And A.LIBRO_CONTABLE = C.LIBRO_CONTABLE And A.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
        query &= "	 AND C.COMPAÑIA = @COMPAÑIA AND C.LIBRO_CONTABLE = @LIBRO_CONTABLE"
        Return query
    End Function

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged

    End Sub

    Private Sub txtCuentaIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuentaIni.TextChanged

    End Sub
End Class