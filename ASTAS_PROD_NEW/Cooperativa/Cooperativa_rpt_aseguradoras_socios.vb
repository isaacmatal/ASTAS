Imports System.Data
Imports System.Data.SqlClient

Public Class Cooperativa_rpt_aseguradoras_socios
    Dim rpts As New frmReportes_Ver
    Dim rpt1 As New Cooperativa_reporte_aseguradoras_saldos_socios
    Dim jClass As New jarsClass

    Private Sub Cooperativa_rpt_aseguradoras_socios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaEmpresas()
        CargaTipoSolicitudes()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("¿Esta seguro de generar el reporte?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Return
        End If
        If String.IsNullOrEmpty(Me.txtAseguradora.Text.Trim) Then
            MessageBox.Show("El nombre de la aseguradora no puede ser nulo.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtAseguradora.Focus()
            Return
        End If
        If String.IsNullOrEmpty(Me.txtPoliza.Text.Trim) Then
            MessageBox.Show("El número de poliza no puede ser nulo.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtPoliza.Focus()
            Return
        End If
        If String.IsNullOrEmpty(Me.txtProcentaje.Text.Trim) Then
            MessageBox.Show("El número de poliza no puede ser nulo.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtPoliza.Focus()
            Return
        End If

        Dim tbl As New DataTable
        Dim cmd As New SqlCommand
        Dim aseguradora As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim mesaje As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("Text10"), CrystalDecisions.CrystalReports.Engine.TextObject)

        aseguradora.Text = Me.txtAseguradora.Text
        mesaje.Text = "POR ESTE MEDIO ENVIAMOS LISTADO DE PERSONAS QUE TIENEN SALDO AL " & Format(Me.dtpFechaContable.Value, "dd DE MMMM DE yyyy").ToUpper & ", SEGUN POLIZA NO. " & Me.txtPoliza.Text
        'cmd = New SqlCommand("execute COOPERATIVA_RPT_ASEGURADORAS " & Compañia & ", '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', " & Me.txtProcentaje.Text)
        cmd = New SqlCommand(consulta())
        tbl = jClass.obtenerDatos(cmd)
        If tbl.Rows.Count > 0 Then
            rpt1.SetDataSource(tbl)
            rpts.ReportesGenericos(rpt1)
            rpts.ShowDialog()
        Else
            MessageBox.Show("No existen datos para la fecha seleccionada")
        End If
    End Sub

    Private Function consulta() As String
        Dim sql As String = ""
        Dim ctas As String = ""
        Dim Table As DataTable
        Dim MesAnt As Integer = Me.dtpFechaContable.Value.AddMonths(-1).Month
        Dim YearAnt As Integer = Me.dtpFechaContable.Value.AddMonths(-1).Year
        Dim Libro As Integer = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")

        sql = "SELECT C.CUENTA_COMPLETA" & vbCrLf
        sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS C, COOPERATIVA_CATALOGO_SOLICITUDES S, COOPERATIVA_CATALOGO_DEDUCCIONES D" & vbCrLf
        sql &= " WHERE C.COMPAÑIA = S.COMPAÑIA AND C.SOLICITUD = S.SOLICITUD" & vbCrLf
        sql &= "   AND S.COMPAÑIA = D.COMPAÑIA AND S.DEDUCCION = D.DEDUCCION AND D.INTERES > 0" & vbCrLf
        sql &= "   AND C.COMPAÑIA = " & Compañia
        If Val(Me.cmbTipoSolic.SelectedValue) > 0 Then
            sql &= "   AND C.SOLICITUD = " & Me.cmbTipoSolic.SelectedValue
        End If
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        For i As Integer = 0 To Table.Rows.Count - 1
            If i = 0 Then
                ctas &= "'" & Table.Rows(i).Item(0) & "'"
            Else
                ctas &= ", '" & Table.Rows(i).Item(0) & "'"
            End If
        Next

        sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
        sql &= "SELECT C.COMPAÑIA, C.LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, C.CUENTA,C.CUENTA_COMPLETA, 0 AS DETALLE, 0 AS SALDO," & vbCrLf
        sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
        sql &= "FROM CONTABILIDAD_CATALOGO_CUENTAS C " & vbCrLf
        sql &= "   LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
        sql &= "   ON C.COMPAÑIA = D.COMPAÑIA" & vbCrLf
        sql &= "  AND C.LIBRO_CONTABLE = D.LIBRO_CONTABLE" & vbCrLf
        sql &= "  AND C.CUENTA_COMPLETA = D.CUENTA_COMPLETA" & vbCrLf
        sql &= "  AND D.MES = " & MesAnt & vbCrLf
        sql &= "  AND AÑO = " & YearAnt & vbCrLf
        sql &= "  AND D.LIBRO_CONTABLE = " & Libro & vbCrLf
        sql &= "WHERE C.LIBRO_CONTABLE = " & Libro & vbCrLf
        sql &= "  AND C.CUENTA_MAYOR = 0" & vbCrLf
        sql &= "  AND C.COMPAÑIA = " & Compañia & vbCrLf
        sql &= "  AND D.SALDO IS NULL" & vbCrLf
        sql &= "  AND C.CUENTA_COMPLETA IS NOT NULL"
        jClass.ejecutarComandoSql(New SqlCommand(sql))

        sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
        sql &= "SELECT DISTINCT E.COMPAÑIA, " & Libro & " AS LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, E.CUENTA_CONTABLE AS CUENTA, " & vbCrLf
        sql &= "    (SELECT CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = E.COMPAÑIA AND CUENTA = E.CUENTA_CONTABLE AND LIBRO_CONTABLE = " & Libro & " AND COMPAÑIA = " & Compañia & " ) AS CUENTA_CAT," & vbCrLf
        sql &= "	E.COD_DETALLE, 0 AS SALDO," & vbCrLf
        sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
        sql &= "FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO E LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
        sql &= "   ON E.COMPAÑIA = D.COMPAÑIA " & vbCrLf
        sql &= "  AND E.CUENTA_CONTABLE = D.CUENTA " & vbCrLf
        sql &= "  AND D.MES = " & MesAnt & vbCrLf
        sql &= "  AND D.AÑO = " & YearAnt & vbCrLf
        sql &= "  AND E.COD_DETALLE = D.DETALLE" & vbCrLf
        sql &= "WHERE CONVERT(DATE, E.FECHA_TRAN) BETWEEN CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value.AddDays(-Me.dtpFechaContable.Value.Day).AddDays(1), "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
        sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
        sql &= "  AND D.CUENTA IS NULL" & vbCrLf
        sql &= "  AND E.CUENTA_CONTABLE > 0"
        jClass.ejecutarComandoSql(New SqlCommand(sql))

        sql = "SELECT B.CODIGO_AS, B.CODIGO_BUXIS, B.NOMBRE_COMPLETO, B.SALDO, B.FENAC, B.PROCENTAJE, B.FECHA FROM" & vbCrLf
        sql &= "(SELECT SUBSTRING(X.CUENTA_COMPLETA,1,6) AS CODIGO_AS, COD.CODIGO AS CODIGO_BUXIS, COD.DESCRIPCION AS NOMBRE_COMPLETO," & vbCrLf
        sql &= "       CASE WHEN A.TIPO_CUENTA = 1 OR A.TIPO_CUENTA = 4 THEN ISNULL(SD.SALDO,0.00) + ISNULL(A.CARGOS,0.00) - ISNULL(A.ABONOS,0.00) ELSE ISNULL(SD.SALDO,0.00) - ISNULL(A.CARGOS,0.00) + ISNULL(A.ABONOS,0.00) END AS SALDO, " & vbCrLf
        sql &= "	   ISNULL((SELECT CASE WHEN LEN(NIT) = 0 THEN '' ELSE SUBSTRING(NIT,6,2) + '/' + SUBSTRING(NIT,8,2) + '/19' + SUBSTRING(NIT,10,2) END FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = COD.CODIGO),'') AS FENAC," & vbCrLf
        sql &= "	   " & txtProcentaje.Text & " AS PROCENTAJE," & vbCrLf
        sql &= "	   CONVERT(DATETIME, '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', 103) AS FECHA" & vbCrLf
        sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS X " & vbCrLf
        sql &= "       LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE SD ON X.COMPAÑIA = SD.COMPAÑIA AND X.CUENTA = SD.CUENTA AND X.LIBRO_CONTABLE = SD.LIBRO_CONTABLE AND SD.MES = " & MesAnt & " AND SD.AÑO = " & YearAnt & vbCrLf
        sql &= "       LEFT JOIN (SELECT D.COMPAÑIA, D.CUENTA_CONTABLE, D.COD_DETALLE, SUM(D.CARGOS) CARGOS, SUM(D.ABONOS) ABONOS, " & vbCrLf
        sql &= "	                     C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, C.TIPO_CUENTA, " & Libro & " AS LIBRO_CONTABLE, MAX(C.CATALOGO) AS CATALOGO" & vbCrLf
        sql &= "					FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO D, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
        sql &= "                WHERE D.COMPAÑIA = C.COMPAÑIA" & vbCrLf
        sql &= "                  AND D.COMPAÑIA = " & Compañia & vbCrLf
        sql &= "					 AND D.CUENTA_CONTABLE = C.CUENTA " & vbCrLf
        sql &= "					 AND C.LIBRO_CONTABLE = " & Libro & vbCrLf
        sql &= "					 AND C.CUENTA_COMPLETA IN (" & ctas & ") " & vbCrLf
        sql &= "					 AND C.CUENTA_MAYOR = 0" & vbCrLf
        sql &= "					 AND D.COD_DETALLE BETWEEN 1 AND 999999999" & vbCrLf
        sql &= "					 AND CONVERT(DATE, D.FECHA_TRAN) BETWEEN CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value.AddDays(-Me.dtpFechaContable.Value.Day).AddDays(1), "dd/MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
        sql &= "				   GROUP BY D.COMPAÑIA, D.CUENTA_CONTABLE, D.COD_DETALLE, C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, C.TIPO_CUENTA) A " & vbCrLf
        sql &= "		ON X.COMPAÑIA = A.COMPAÑIA AND X.LIBRO_CONTABLE = A.LIBRO_CONTABLE AND X.CUENTA = A.CUENTA_CONTABLE AND SD.DETALLE = A.COD_DETALLE" & vbCrLf
        sql &= "        LEFT JOIN CONTABILIDAD_CATALOGO_CODIGO_DETALLE COD ON X.COMPAÑIA = COD.COMPAÑIA AND X.CATALOGO = COD.TIPO AND SD.DETALLE = COD.CODIGO" & vbCrLf
        sql &= " WHERE X.LIBRO_CONTABLE = " & Libro & " AND X.CUENTA_MAYOR = 0 AND COD.DESCRIPCION IS NOT NULL AND X.COMPAÑIA = " & Compañia & vbCrLf
        If Me.cmbEmpresa.SelectedValue > 0 Then
            sql &= "   AND COD.ORIGEN = " & Me.cmbEmpresa.SelectedValue
        End If
        sql &= "   AND X.CUENTA_COMPLETA IN (" & ctas & ")) B " & vbCrLf
        sql &= " WHERE B.SALDO > 0" & vbCrLf
        sql &= " ORDER BY CODIGO_BUXIS" & vbCrLf
        Return sql
    End Function

    Private Sub CargaEmpresas()
        Dim sql As String
        Dim Table As DataTable
        sql = "SELECT 0 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia
        'sql &= "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        Me.cmbEmpresa.DataSource = Table
        Me.cmbEmpresa.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbEmpresa.ValueMember = "ORIGEN"
        Me.cmbEmpresa.SelectedIndex = 0
    End Sub

    Private Sub CargaTipoSolicitudes()
        Dim sql As String
        Dim Table As DataTable
        sql = "SELECT '0' AS SOLICITUD, 'TODAS' AS DESCRIPCION_SOLICITUD " & vbCrLf
        sql &= "UNION " & vbCrLf
        sql &= "SELECT S.SOLICITUD, S.DESCRIPCION_SOLICITUD " & vbCrLf
        sql &= "  FROM COOPERATIVA_CATALOGO_SOLICITUDES S, COOPERATIVA_CATALOGO_DEDUCCIONES D" & vbCrLf
        sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA AND S.DEDUCCION = D.DEDUCCION " & vbCrLf
        sql &= "   AND D.INTERES > 0" & vbCrLf
        sql &= "   AND S.COMPAÑIA = 1" & vbCrLf
        sql &= "   AND CHARINDEX('ATAF', S.DESCRIPCION_SOLICITUD, 1) = 0"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbTipoSolic.DataSource = Table
        Me.cmbTipoSolic.DisplayMember = "DESCRIPCION_SOLICITUD"
        Me.cmbTipoSolic.ValueMember = "SOLICITUD"
        Me.cmbTipoSolic.SelectedValue = 0
    End Sub
End Class