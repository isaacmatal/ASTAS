Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Precios_Venta
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim Table As DataTable

    Private Sub Cafeteria_Reporte_Precios_Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        CargarTiempoComida()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargarTiempoComida()
        Try
            Sql = "EXECUTE sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA @COMPAÑIA = " & Compañia & ", @IUD = 'S'"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            cmbTiempo.DataSource = Table
            cmbTiempo.ValueMember = "Tiempo de Comida"
            cmbTiempo.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Rpt As New Cafeteria_Reporte_Precios_Venta_Rpt
        Try
            Sql = "EXECUTE sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD " & vbCrLf
            Sql &= " @COMPAÑIA  = " & Compañia & vbCrLf
            Sql &= ",@BODEGA    = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            Sql &= ",@TIEMPO    = " & Me.cmbTiempo.SelectedValue & vbCrLf
            Sql &= ",@FECHA     = '" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "'" & vbCrLf
            Sql &= ",@CODIGO    = 0" & vbCrLf 'codigo
            Sql &= ",@CANTIDAD  = 0" & vbCrLf 'Cantidad
            Sql &= ",@USUARIO   = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD       = 'Y'" & vbCrLf
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            If Table.Rows.Count >= 0 Then
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
End Class