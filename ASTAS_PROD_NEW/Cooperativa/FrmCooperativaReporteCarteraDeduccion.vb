Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FrmCooperativaReporteCarteraDeduccion
    Dim Sql As String
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Rpt As New Cooperativa_Reporte_Cartera_Socios_DeduccionRpt
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim frmVer As New frmReportes_Ver
    Dim Iniciando As Boolean

    Delegate Sub SetProgressPercentageCallback(ByVal [Percentage] As Integer)

    Private Sub FrmCooperativaReporteCarteraDeduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargaEmpresas()
        CargaTipoSolicitudes()
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.pbTabla.Value = 0
            Me.pbTabla.Visible = True
            'Sql = "SELECT '" & Descripcion_Compañia & "' AS Compañia," & vbCrLf
            'Sql &= "       CONVERT(DATETIME,'" & Format(txtFecha.Value, "dd/MM/yyyy") & "',103) AS Fecha," & vbCrLf
            'Sql &= "       S.Deduccion AS Deduccion," & vbCrLf
            'Sql &= "       MAX(DD.DESCRIPCION_SOLICITUD) AS Solicitud," & vbCrLf
            'Sql &= "       S.[Codigo_AS] AS [Codigo AS]," & vbCrLf
            'Sql &= "       S.[Codigo_Buxis] AS [Codigo Buxis]," & vbCrLf
            'Sql &= "       SOC.NOMBRE_COMPLETO AS [Nombre]," & vbCrLf
            'Sql &= "       SUM(D.CAPITAL) AS DEUDA" & vbCrLf
            'Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, COOPERATIVA_SOLICITUDES_AUTORIZACION A, COOPERATIVA_CATALOGO_SOCIOS SOC, COOPERATIVA_CATALOGO_SOLICITUDES DD" & vbCrLf
            'Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA And S.CORRELATIVO = D.NUMERO_SOLICITUD" & vbCrLf
            'Sql &= "   AND S.COMPAÑIA = A.COMPAÑIA AND S.CORRELATIVO = A.N_SOLICITUD" & vbCrLf
            'Sql &= "   AND S.COMPAÑIA = SOC.COMPAÑIA AND S.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO AND S.CODIGO_AS = SOC.CODIGO_EMPLEADO_AS" & vbCrLf
            'Sql &= "   AND S.COMPAÑIA = DD.COMPAÑIA AND S.DEDUCCION = DD.DEDUCCION" & vbCrLf
            'Sql &= "   AND A.ANULADA = 0" & vbCrLf
            'Sql &= "   AND D.CAPITAL_D = 0" & vbCrLf
            'Sql &= "   AND CONVERT(DATE,S.FECHA_SOLICITUD) <= CONVERT(DATE,'" & Format(txtFecha.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            'If Me.ComboBox1.SelectedValue <> 999 Then
            '    Sql &= "  AND SOC.ORIGEN = " & Me.ComboBox1.SelectedValue & vbCrLf
            'End If
            'If Me.ComboBox2.SelectedValue <> 9999 Then
            '    Sql &= "  AND S.SOLICITUD = " & Me.ComboBox2.SelectedValue & vbCrLf
            'End If
            'Sql &= "GROUP BY S.DEDUCCION, S.CODIGO_BUXIS, S. CODIGO_AS, SOC.NOMBRE_COMPLETO"
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_REPORTE_CARTERA_SOCIOS_I]" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= " ,@FECHA_HASTA = '" & Format(txtFecha.Value, "dd/MM/yyyy") & "'" & vbCrLf
            If Me.cmbTipoSolic.SelectedValue <> 9999 Then
                Sql &= " ,@TIPO_SOLIC = " & Me.cmbTipoSolic.SelectedValue & vbCrLf
            End If
            If Me.cmbEmpresa.SelectedValue <> 999 Then
                Sql &= " ,@ORIGEN = " & Me.cmbEmpresa.SelectedValue
            End If
            sqlCmd.CommandText = Sql
            sqlCmd.CommandTimeout = 7200
            bwTabla.RunWorkerAsync()
            'Table = jClass.obtenerDatos(sqlCmd)
            'Rpt.SetDataSource(Table)
            'frmVer.ReportesGenericos(Rpt)
            'frmVer.ShowDialog()
        End If
    End Sub

    Private Sub CargaEmpresas()
        'Sql = "SELECT 999 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES"
        Sql = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN IN (" & Permitir & ")"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbEmpresa.DataSource = Table
        Me.cmbEmpresa.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbEmpresa.ValueMember = "ORIGEN"
        Me.cmbEmpresa.SelectedIndex = 0
        'Me.cmbEmpresa.SelectedValue = 999
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
        Rpt.SetDataSource(Table)
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

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.pbTabla.InvokeRequired Then
            Dim d As New SetProgressPercentageCallback(AddressOf SetProgressPercentage)
            Me.Invoke(d, New Object() {[Percentage]})
        Else
            pbTabla.Value = [Percentage]
        End If
    End Sub
End Class