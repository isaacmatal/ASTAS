Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FrmCooperativaReporteSaldosUltPago
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim Rpt As New ControlFechasPago
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim frmVer As New frmReportes_Ver
    Dim Iniciando As Boolean

    Delegate Sub SetProgressPercentageCallback(ByVal [Percentage] As Integer)

    Private Sub FrmCooperativaReporteSaldosUltPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaEmpresas()
        CargaTipoSolicitudes()
        Iniciando = False
    End Sub

    Private Sub BtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        If MsgBox("¿Está seguro que desea Imprimir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.pbTabla.Value = 0
            Me.pbTabla.Visible = True
            Sql = "SELECT D.CODIGO_EMPLEADO, D.CODIGO_EMPLEADO_AS, D.NOMBRE_COMPLETO,S.ORIGEN," & vbCrLf
            Sql &= "D.[AHORRO ORDINARIO],D.[AHORRO EXTRAORDINARIO], D.[Monto por Saldar], A.[DESCRIPCION DEDUCCION],A.DEUDA," & vbCrLf
            Sql &= "(SELECT MAX(FEC_ACU_HD) FROM PLANILLA_DESCUENTOS_APLICADOS WHERE COD_MF = A.[Codigo Buxis] AND COD_MV = A.Deduccion AND APLICADO = 1) AS FECULTPAG, " & vbCrLf
            Sql &= "(SELECT MAX(FECHA_SOLICITUD) FROM COOPERATIVA_SOLICITUDES WHERE CODIGO_BUXIS = A.[Codigo Buxis] AND DEDUCCION = A.Deduccion AND PROGRAMADA = 1) AS FECULTSOL" & vbCrLf
            Sql &= "FROM (SELECT VCTS.[Tipo Solicitud] AS TIPO_SOLI, VCTS.Solicitud AS [DESCRIPCION DEDUCCION], SUM(CPSD.CAPITAL) AS DEUDA, MAX(VCTS.Deduccion) AS Deduccion, VCTS.[Codigo Buxis], VCTS.[Codigo AS]" & vbCrLf
            Sql &= "FROM dbo.COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE CPSD, " & vbCrLf
            Sql &= "VISTA_COOPERATIVA_TODAS_SOLICITUDES VCTS," & vbCrLf
            Sql &= "dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CCD" & vbCrLf
            Sql &= "WHERE CPSD.COMPAÑIA = VCTS.Compañia" & vbCrLf
            Sql &= "AND CPSD.NUMERO_SOLICITUD = VCTS.[N° Solicitud]" & vbCrLf
            Sql &= "AND VCTS.Compañia = CCD.COMPAÑIA" & vbCrLf
            Sql &= "AND VCTS.Deduccion = CCD.DEDUCCION" & vbCrLf
            Sql &= "AND CPSD.CAPITAL_D = 0 " & vbCrLf
            Sql &= "AND VCTS.ANULADA = 0 " & vbCrLf
            'Sql &= "AND CPSD.REPROGRAMADA = 0" & vbCrLf
            Sql &= "AND VCTS.Compañia = 1" & vbCrLf
            Sql &= "GROUP BY VCTS.[Tipo Solicitud],VCTS.Solicitud,VCTS.[Codigo AS],VCTS.[Codigo Buxis]) A, VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO D, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            Sql &= "WHERE A.[Codigo Buxis] = D.CODIGO_EMPLEADO" & vbCrLf
            Sql &= "AND D.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO" & vbCrLf
            If Me.cmbEmpresa.SelectedValue <> 999 Then
                Sql &= "AND S.ORIGEN = " & Me.cmbEmpresa.SelectedValue & vbCrLf
            End If
            If Me.cmbTipoSolic.SelectedValue <> 9999 Then
                Sql &= "AND A.TIPO_SOLI = " & Me.cmbTipoSolic.SelectedValue & vbCrLf
            End If
            Sql &= "ORDER BY CODIGO_EMPLEADO"
            sqlCmd.CommandText = Sql
            sqlCmd.CommandTimeout = 7200
            bwTabla.RunWorkerAsync()
        End If
    End Sub

    Private Sub CargaEmpresas()
        Sql = "SELECT 999 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbEmpresa.DataSource = Table
        Me.cmbEmpresa.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbEmpresa.ValueMember = "ORIGEN"
        Me.cmbEmpresa.SelectedValue = 999
    End Sub

    Private Sub CargaTipoSolicitudes()
        Sql = "SELECT 9999 AS SOLICITUD, 'TODAS' AS DESCRIPCION_SOLICITUD UNION SELECT SOLICITUD, DESCRIPCION_SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbTipoSolic.DataSource = Table
        Me.cmbTipoSolic.DisplayMember = "DESCRIPCION_SOLICITUD"
        Me.cmbTipoSolic.ValueMember = "SOLICITUD"
        Me.cmbTipoSolic.SelectedValue = 9999
    End Sub

    Private Sub bwTabla_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwTabla.DoWork
        bwAvance.RunWorkerAsync()
        Table = jClass.obtenerDatos(sqlCmd)
    End Sub

    Private Sub bwTabla_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTabla.RunWorkerCompleted
        Me.pbTabla.Visible = False
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = Rpt.Section1.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        If Me.chkFecha.Checked Then
            Dim tablaT As DataTable = Table.Clone()
            Dim MyRows As DataRow()
            MyRows = Table.Select("[FECULTPAG] < #" & Format(Me.dpFecha.Value, "yyyy-MM-dd") & "#")
            For i As Integer = 0 To MyRows.Length - 1
                tablaT.ImportRow(MyRows(i))
            Next
            Rpt.SetDataSource(tablaT)
        Else
            Rpt.SetDataSource(Table)
        End If
        frmVer.ReportesGenericos(Rpt)
        frmVer.ShowDialog()
    End Sub

    Private Sub bwAvance_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAvance.DoWork
        While bwTabla.IsBusy
            For i As Integer = 0 To 100
                If bwTabla.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(500)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    bwAvance.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While

        bwAvance.ReportProgress(100)
    End Sub

    Private Sub bwAvance_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwAvance.ProgressChanged
        Me.SetProgressPercentage(e.ProgressPercentage)
    End Sub

    Private Sub SetProgressPercentage(ByVal [Percentage] As Integer)
        If Me.pbTabla.InvokeRequired Then
            Dim d As New SetProgressPercentageCallback(AddressOf SetProgressPercentage)
            Me.Invoke(d, New Object() {[Percentage]})
        Else
            pbTabla.Value = [Percentage]
        End If
    End Sub

    Private Sub chkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFecha.CheckedChanged
        dpFecha.Enabled = chkFecha.Checked
    End Sub
End Class