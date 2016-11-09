Imports System.Data
Imports System.Data.SqlClient

Public Class Facturacion_Periodos_Cobro
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sql As String
    Dim sqlCmd As New SqlCommand
    Dim itemMod As Integer

    Private Sub Facturacion_Periodos_Cobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        llenaGrid()
    End Sub

    Private Sub llenaGrid()
        sql = "SELECT [FECHA_PAGO] ,[FECHA_INICIO_PERIODO] ,[FECHA_FINAL_PERIODO] ,[ITEM]"
        sql &= "FROM [dbo].[FACTURACION_PERIODOS_COBRO] ORDER BY FECHA_PAGO DESC"
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.dgvPeriodos.DataSource = Table
    End Sub

    Private Sub dgvPeriodos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodos.CellContentClick
        Me.dpFechaPago.Value = Me.dgvPeriodos.Rows(e.RowIndex).Cells("FechaPago").Value
        Me.dpFechaInicio.Value = Me.dgvPeriodos.Rows(e.RowIndex).Cells("FechaInicio").Value
        Me.dpFechaFinal.Value = Me.dgvPeriodos.Rows(e.RowIndex).Cells("FechaFinal").Value
        itemMod = Me.dgvPeriodos.Rows(e.RowIndex).Cells("item").Value
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarCampos() Then
            If itemMod = 0 Then
                sql = "INSERT INTO [dbo].[FACTURACION_PERIODOS_COBRO]"
                sql &= "           ([FECHA_PAGO]"
                sql &= "           ,[FECHA_INICIO_PERIODO]"
                sql &= "           ,[FECHA_FINAL_PERIODO])"
                sql &= "     VALUES"
                sql &= "           ('" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                sql &= "           ,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "'"
                sql &= "           ,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "')"
            Else
                sql = "UPDATE [dbo].[FACTURACION_PERIODOS_COBRO]"
                sql &= "   SET [FECHA_PAGO] = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                sql &= "      ,[FECHA_INICIO_PERIODO] = '" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "'"
                sql &= "      ,[FECHA_FINAL_PERIODO] = '" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "'"
                sql &= " WHERE ITEM = " & itemMod
            End If
            sqlCmd.CommandText = sql
            jClass.ejecutarComandoSql(sqlCmd)
            llenaGrid()
            btnNuevo_Click(sender, e)
        End If
    End Sub

    Private Function validarCampos() As Boolean
        Dim msj As String = String.Empty
        If itemMod = 0 Then
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "',103) = FECHA_PAGO")) > 0 Then
                msj &= "Fecha de pago ya existe" & vbCrLf
            End If
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO")) > 0 Then
                msj &= "Fecha Inicial ya esta incluida en la fecha de pago: " & jClass.obtenerEscalar("SELECT CONVERT(VARCHAR,FECHA_PAGO,103) AS FECHA_PAGO FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO") & vbCrLf
            End If
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO")) > 0 Then
                msj &= "Fecha Final ya esta incluida en la fecha de pago: " & jClass.obtenerEscalar("SELECT CONVERT(VARCHAR,FECHA_PAGO,103) AS FECHA_PAGO FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO")
            End If
        Else
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO AND FECHA_PAGO <> CONVERT(DATE,'" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "',103)")) > 0 Then
                msj &= "Fecha Inicial ya esta incluida en la fecha de pago: " & jClass.obtenerEscalar("SELECT CONVERT(VARCHAR,FECHA_PAGO,103) AS FECHA_PAGO FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO AND FECHA_PAGO <> CONVERT(DATE,'" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "',103)") & vbCrLf
            End If
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO AND FECHA_PAGO <> CONVERT(DATE,'" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "',103)")) > 0 Then
                msj &= "Fecha Final ya esta incluida en la fecha de pago: " & jClass.obtenerEscalar("SELECT CONVERT(VARCHAR,FECHA_PAGO,103) AS FECHA_PAGO FROM FACTURACION_PERIODOS_COBRO WHERE CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) >= FECHA_INICIO_PERIODO AND CONVERT(DATE,'" & Format(Me.dpFechaFinal.Value, "dd/MM/yyyy") & "',103) <= FECHA_FINAL_PERIODO AND FECHA_PAGO <> CONVERT(DATE,'" & Format(Me.dpFechaInicio.Value, "dd/MM/yyyy") & "',103) AND FECHA_PAGO <> CONVERT(DATE,'" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "',103)")
            End If
        End If
        If msj = Nothing Then
            Return True
        Else
            MsgBox("Periodo no Válido." & vbCrLf & msj, MsgBoxStyle.Information, "Validación")
            Return False
        End If
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            jClass.Ejecutar_ConsultaSQL("DELETE FROM FACTURACION_PERIODOS_COBRO WHERE ITEM = " & itemMod)
            llenaGrid()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        itemMod = 0
        Me.dpFechaInicio.Value = Now
        Me.dpFechaFinal.Value = Now
        Me.dpFechaPago.Value = Now
    End Sub
End Class