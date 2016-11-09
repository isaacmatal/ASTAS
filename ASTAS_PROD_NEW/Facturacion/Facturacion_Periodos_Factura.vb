Imports System.Data
Imports System.Data.SqlClient

Public Class Facturacion_Periodos_Factura
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sql As String
    Dim sqlCmd As New SqlCommand
    Dim itemMod As Integer
    Dim multi As New multiUsos
    Dim cargando As Boolean = True

    Private Sub Facturacion_Periodos_Factura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        cargando = False
        llenaGrid()
    End Sub

    Private Sub llenaGrid()
        If Not cargando Then
            sql = "SELECT [FECHA_REAL],[FECHA_FACTURACION] FROM [dbo].[FACTURACION_FECHAS_CIERRE] WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & "ORDER BY FECHA_REAL DESC"
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Me.dgvPeriodos.DataSource = Table
        End If
    End Sub

    Private Sub dgvPeriodos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodos.CellClick
        Me.dpFechaDia.Value = Me.dgvPeriodos.Rows(e.RowIndex).Cells("FechaDia").Value
        Me.dpFechaFact.Value = Me.dgvPeriodos.Rows(e.RowIndex).Cells("FechaFactura").Value
        itemMod = 1
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarCampos() Then
            If itemMod = 0 Then
                sql = "INSERT INTO [dbo].[FACTURACION_FECHAS_CIERRE]" & vbCrLf
                sql &= "           ([COMPAÑIA]" & vbCrLf
                sql &= "           ,[BODEGA]" & vbCrLf
                sql &= "           ,[FECHA_REAL]" & vbCrLf
                sql &= "           ,[FECHA_FACTURACION]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
                sql &= "     VALUES" & vbCrLf
                sql &= "           (" & Compañia & vbCrLf
                sql &= "           ," & Me.cmbBODEGA.SelectedValue & vbCrLf
                sql &= "           ,'" & Format(Me.dpFechaDia.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "           ,'" & Format(Me.dpFechaFact.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "           ,'" & Usuario & "'" & vbCrLf
                sql &= "           ,GETDATE()" & vbCrLf
                sql &= "           ,'" & Usuario & "'" & vbCrLf
                sql &= "           ,GETDATE())" & vbCrLf
            Else
                sql = "UPDATE [dbo].[FACTURACION_FECHAS_CIERRE]"
                sql &= "   SET [FECHA_REAL] = '" & Format(Me.dpFechaDia.Value, "dd/MM/yyyy") & "'"
                sql &= "      ,[FECHA_FACTURACION] = '" & Format(Me.dpFechaFact.Value, "dd/MM/yyyy") & "'"
                sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
                sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
                sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                sql &= "   AND BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                sql &= "   AND FECHA_REAL = '" & Format(Me.dpFechaDia.Value, "dd/MM/yyyy") & "'"
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
            If CInt(jClass.obtenerEscalar("SELECT COUNT(FECHA_REAL) FROM FACTURACION_FECHAS_CIERRE WHERE CONVERT(DATE,'" & Format(Me.dpFechaDia.Value, "dd/MM/yyyy") & "',103) = FECHA_REAL AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND COMPAÑIA = " & Compañia)) > 0 Then
                msj &= "Fecha del Día ya existe para" & vbCrLf & Me.cmbBODEGA.Text
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
            jClass.Ejecutar_ConsultaSQL("DELETE FROM FACTURACION_FECHAS_CIERRE WHERE CONVERT(DATE,'" & Format(Me.dpFechaDia.Value, "dd/MM/yyyy") & "',103) = FECHA_REAL AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND COMPAÑIA = " & Compañia)
            llenaGrid()
            btnNuevo_Click(sender, e)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        itemMod = 0
        Me.dpFechaFact.Value = Now
        Me.dpFechaDia.Value = Now
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        llenaGrid()
    End Sub
End Class