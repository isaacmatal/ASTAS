Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FrmCooperativaReporteAhorros
    Dim Sql As String
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Rpts As New frmReportes_Ver
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Rpt As New Cooperativa_Reporte_Ahorros_Socios_Rpt
    Dim Iniciando As Boolean

    Private Sub FrmCooperativaReporteAhorros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label4.Text = Descripcion_Compañia
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargaEmpresas()
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir los Ahorros de Socios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Sql = " SELECT '" & Descripcion_Compañia & "' AS Compañia," & vbCrLf
            Sql &= "       CONVERT(VARCHAR,'" & Format(Me.dpFecha.Value, "dd/MM/yyyy") & "',103) AS Fecha," & vbCrLf
            Sql &= "       MAX(VCCS.DIVISION) AS DIVISION, " & vbCrLf
            Sql &= "       MAX(VCCS.DEPARTAMENTO) AS DEPARTAMENTO, " & vbCrLf
            Sql &= "       MAX(VCCS.DESCRIPCION_DIVISION) AS DESCRIPCION_DIVISION," & vbCrLf
            Sql &= "       MAX(VCCS.DESCRIPCION_DEPARTAMENTO) AS DESCRIPCION_DEPARTAMENTO," & vbCrLf
            Sql &= "       MAX(VCCS.CODIGO_EMPLEADO) AS CODIGO_EMPLEADO," & vbCrLf
            Sql &= "       MAX(VCCS.CODIGO_EMPLEADO_AS) AS CODIGO_EMPLEADO_AS," & vbCrLf
            Sql &= "       MAX(VCCS.NOMBRE_COMPLETO) AS NOMBRE_COMPLETO," & vbCrLf
            Sql &= "       SUM(VCDS.CUOTA_ORDINARIO) AS ORDINARIO," & vbCrLf
            Sql &= "       SUM(VCDS.CUOTA_EXTRAORDINARIO) AS EXTRAORDI," & vbCrLf
            Sql &= "       MAX(VCCS.PORCENTAJE_AHORRO_ORDINARIO) AS POR_ORDIN," & vbCrLf
            Sql &= "       MAX(VCCS.PORCENTAJE_AHORRO_EXTRAORDINARIO) AS POR_EXTRA" & vbCrLf
            Sql &= "  FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS VCCS" & vbCrLf
            Sql &= "       INNER JOIN COOPERATIVA_SOCIO_AHORROS VCDS ON  VCDS.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "         AND VCDS.CODIGO_EMPLEADO_AS = VCCS.CODIGO_EMPLEADO_AS" & vbCrLf
            Sql &= "         AND VCDS.CODIGO_EMPLEADO = VCCS.CODIGO_EMPLEADO " & vbCrLf
            Sql &= "         AND (VCDS.CUOTA_EXTRAORDINARIO <> 0 OR VCDS.CUOTA_ORDINARIO <> 0)" & vbCrLf
            Sql &= " WHERE VCCS.COMPAÑIA = " & Compañia
            Sql &= "   AND VCDS.FECHA_AHORRO <= '" & Format(Me.dpFecha.Value, "dd/MM/yyyy") & "'"
            If Me.cmbOrigen.SelectedValue < 999 Then
                Sql &= "   AND VCCS.ORIGEN = " & Me.cmbOrigen.SelectedValue
            Else
                Sql &= "   AND VCCS.ORIGEN IN (" & Permitir & ")"
            End If
            Sql &= " GROUP BY VCCS.CODIGO_EMPLEADO, VCCS.CODIGO_EMPLEADO_AS"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.SetDataSource(Table)
            Rpts.ReportesGenericos(Rpt)
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub CargaEmpresas()
        'Sql = "SELECT 999 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES"
        Sql = "SELECT 999 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN IN (" & Permitir & ")"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbOrigen.DataSource = Table
        Me.cmbOrigen.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbOrigen.ValueMember = "ORIGEN"
        Me.cmbOrigen.SelectedValue = 999
    End Sub
End Class