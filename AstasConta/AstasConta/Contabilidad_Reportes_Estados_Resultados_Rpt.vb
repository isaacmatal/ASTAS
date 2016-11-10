Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Estados_Resultados_Rpt

    Private Sub Contabilidad_Reportes_Estados_Resultados_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim Rpt As New Contabilidad_Reportes_Estado_Resultado_Rpt
        Dim Sql As String
        Dim jClass As New jarsClass
        Dim table As DataTable
        Dim sqlCmd As New SqlCommand
        jClass.Ejecutar_ConsultaSQL(SaldosMesDetalle(Me.dpFECHA_CONTABLE.Value.Month, Me.dpFECHA_CONTABLE.Value.Year))
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_ESTADO_RESULTADOS_RPT "
            Sql &= " @COMPA�IA= " & Compa�ia
            Sql &= ", @FECHA = '" & Date.DaysInMonth(Me.dpFECHA_CONTABLE.Value.Year, Me.dpFECHA_CONTABLE.Value.Month).ToString() & Format(Me.dpFECHA_CONTABLE.Value, "/MM/yyyy") & "'"
            Sql &= ", @BANDERA = " & IIf(Me.chkGober.Checked, "2", "1")
            sqlCmd.CommandText = Sql
            table = jClass.obtenerDatos(sqlCmd)
            If table.Rows.Count > 0 Then
                Rpt.SetDataSource(table)
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Function SaldosMesDetalle(ByVal Mes As Integer, ByVal Year As Integer) As String
        Dim query As String
        query = "DECLARE @COMPA�IA INT=" & Compa�ia & ", @LIBRO_CONTABLE INT, @MES INT, @A�O INT, @FECHAAPERTURA AS DATETIME = '01/" & Mes.ToString.PadLeft(2, "0") & "/" & Year.ToString() & "'" & vbCrLf
        query &= "" & vbCrLf
        query &= "SET @MES = MONTH(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @A�O = YEAR(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @FECHAAPERTURA = DATEADD(M, 1, @FECHAAPERTURA)" & vbCrLf
        query &= "SELECT @LIBRO_CONTABLE = LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPA�IA = @COMPA�IA AND LIBRO_PRINCIPAL = 1" & vbCrLf
        query &= "" & vbCrLf
        query &= "DELETE FROM [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE] WHERE COMPA�IA = @COMPA�IA AND MES = @MES AND A�O = @A�O" & vbCrLf
        query &= "" & vbCrLf
        query &= "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
        query &= "SELECT @COMPA�IA AS COMPA�IA, A.LIBRO_CONTABLE," & vbCrLf
        query &= "	     @A�O AS A�O," & vbCrLf
        query &= "	     @MES AS MES," & vbCrLf
        query &= "	     A.CUENTA_CONTABLE," & vbCrLf
        query &= "	     C.CUENTA_COMPLETA, " & vbCrLf
        query &= "       A.COD_DETALLE, " & vbCrLf
        query &= "       CASE WHEN C.TIPO_CUENTA = 1 OR C.TIPO_CUENTA = 4 THEN A.CARGOS - A.ABONOS ELSE A.ABONOS - A.CARGOS END AS SALDO, " & vbCrLf
        query &= "	     '" & Usuario & "' AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	     @FECHAAPERTURA AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	     '" & Usuario & "' AS USUARIO_EDICION_FECHA," & vbCrLf
        query &= "	     @FECHAAPERTURA AS USUARIO_EDICION_FECHA" & vbCrLf
        query &= "  FROM (SELECT COMPA�IA, CUENTA_CONTABLE, COD_DETALLE, SUM(CARGOS) AS CARGOS, SUM(ABONOS) AS ABONOS, @LIBRO_CONTABLE AS LIBRO_CONTABLE" & vbCrLf
        query &= "          FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO" & vbCrLf
        query &= "	       WHERE FECHA_TRAN < @FECHAAPERTURA" & vbCrLf
        query &= "	       GROUP BY COMPA�IA, CUENTA_CONTABLE, COD_DETALLE) A, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
        query &= " WHERE A.COMPA�IA = C.COMPA�IA And A.LIBRO_CONTABLE = C.LIBRO_CONTABLE And A.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
        query &= "	 AND C.COMPA�IA = @COMPA�IA AND C.LIBRO_CONTABLE = @LIBRO_CONTABLE"
        Return query
    End Function
End Class