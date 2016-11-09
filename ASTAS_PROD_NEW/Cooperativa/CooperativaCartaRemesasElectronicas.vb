Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaCartaRemesasElectronicas

    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Inicio As Boolean = True

    Private Sub CooperativaCartaRemesasElectronicas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBancos(Compañia, Me.cmbBanco)
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Me.cmbTipoRemesa.SelectedIndex = 0
        Inicio = False
        If Me.cmbBanco.Items.Count > 0 Then
            Me.cmbBanco.SelectedIndex = 1
        End If
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedIndexChanged
        If Not Inicio Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco.SelectedValue, 2, Me.cmbCUENTA_BANCARIA)
            If Me.cmbCUENTA_BANCARIA.Items.Count > 0 Then
                Me.cmbCUENTA_BANCARIA.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim Reporte As New CooperativaCartaRemesasElectronicas_rpt
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = Reporte.Section2.ReportObjects.Item("txtCorrelativo")
        txtObj.Text = "Correlativo: " & Me.NudBloque.Value.ToString()
        sql = "SELECT UPPER(BA.DESCRIPCION_BANCO) AS BANCO, RM.CUENTA_BANCARIA, CS.NOMBRE_COMPLETO, RM.MONTO, CS.CUENTA_BANCARIA AS CTASOCIO, RM.FECHA_CONTABLE," & vbCrLf
        sql &= "        CASE RM.UBICACION WHEN 1 THEN 'PRESTAMOS' WHEN 2 THEN 'AHORROS EXT.' END AS TIPORM, CS.CODIGO_EMPLEADO AS CODIGO" & vbCrLf
        sql &= "   FROM dbo.COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS RM, " & vbCrLf
        sql &= "	    dbo.COOPERATIVA_CATALOGO_SOCIOS CS," & vbCrLf
        sql &= "        dbo.CONTABILIDAD_CATALOGO_BANCOS BA " & vbCrLf
        sql &= "  WHERE RM.COMPAÑIA = CS.COMPAÑIA" & vbCrLf
        sql &= "	AND RM.CODIGO_EMPLEADO = CS.CODIGO_EMPLEADO" & vbCrLf
        sql &= "	AND RM.CODIGO_EMPLEADO_AS = CS.CODIGO_EMPLEADO_AS" & vbCrLf
        sql &= "	AND RM.COMPAÑIA = BA.COMPAÑIA" & vbCrLf
        sql &= "	AND RM.BANCO = BA.BANCO" & vbCrLf
        sql &= "	AND RM.COMPAÑIA = " & Compañia & vbCrLf
        sql &= "	AND RM.BANCO = " & Me.cmbBanco.SelectedValue & vbCrLf
        sql &= "	AND RM.CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
        sql &= "	AND RM.UBICACION = " & IIf(Me.cmbTipoRemesa.Text = "Prestamos", 1, 2) & vbCrLf
        sql &= "	AND CONVERT(DATE,RM.FECHA_CONTABLE) = CONVERT(DATE,'" & Me.dpFECHA.Value.ToString("dd/MM/yyyy") & "')" & vbCrLf
        sql &= "	AND RM.BLOQUE = " & Me.NudBloque.Value
        sql &= "	AND CS.ORIGEN IN (" & Permitir & ")"

        'sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS_IUD]"
        'sql &= " @COMPAÑIA = " & Compañia
        'sql &= ", @BANCO = " & Me.cmbBanco.SelectedValue
        'sql &= ", @CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
        'sql &= ", @FECHA_CONTABLE = '" & Me.dpFECHA.Value.ToString("dd/MM/yyyy") & "'"
        'sql &= ", @UBICACION = " & IIf(Me.cmbTipoRemesa.Text = "Prestamos", 1, 2)
        'sql &= ", @BANDERA = 'R'"
        'sql &= ", @BLOQUE = " & Me.NudBloque.Value
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            Reporte.SetDataSource(Table)
            Me.crvRepRemesas.ReportSource = Reporte
        Else
            MsgBox("No hay datos para los paramétros especificados", MsgBoxStyle.Information, "Reporte")
            Me.crvRepRemesas.ReportSource = Nothing
        End If
    End Sub
End Class