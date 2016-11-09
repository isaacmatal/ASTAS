Imports System.Data.SqlClient

Public Class Inventario_Reporte_Compras_Recibidas
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Tiempo As String
    Dim dtareader As SqlDataReader
    Dim bodegas_ As String

    Private Sub Inventario_Reporte_Compras_Recibidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        loadBodegas()
        Me.dvBodegas.Columns("BODEGA").Visible = False
        Iniciando = False
    End Sub

    Private Sub loadBodegas()
        Try
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA = 12, @COMPAÑIA = " & Compañia & ", @USUARIO = '" & Usuario & "'"
            Tabla = c_data1.obtenerDatos(sqlCmd)


            Dim tbl_ As New DataTable
            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("BODEGA", Type.GetType("System.String"))
            tbl_.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next
          
            dvBodegas.AutoGenerateColumns = False
            'Set Columns Count
            dvBodegas.ColumnCount = 3

            'Add Columns
            dvBodegas.Columns(0).Name = "Seleccionar"
            dvBodegas.Columns(0).HeaderText = "Seleccionar"
            dvBodegas.Columns(0).DataPropertyName = "Seleccionar"

            dvBodegas.Columns(1).Name = "BODEGA"
            dvBodegas.Columns(1).HeaderText = "Bodega"
            dvBodegas.Columns(1).DataPropertyName = "BODEGA"

            dvBodegas.Columns(2).Name = "DESCRIPCION"
            dvBodegas.Columns(2).HeaderText = "Descripciòn"
            dvBodegas.Columns(2).DataPropertyName = "DESCRIPCION"

            dvBodegas.DataSource = tbl_

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try


    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Try
            If Me.fecha_desde.Value <= Me.fecha_hasta.Value Then
                Dim Tabla As DataTable
                Dim sqlCmd As New SqlCommand
                Dim rep As New Inventarios_Reporte_Compras_Recibidas
                getBodegas()
                sqlCmd.CommandText = "EXECUTE sp_INVENTARIOS_COMPRAS_RECIVIDAS @FECHA_DESDE='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA_HASTA='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "', @COMPAÑIA='" & Compañia & "', @BODEGAS='" & bodegas_ & "'"
                Tabla = c_data1.obtenerDatos(sqlCmd)
                rep.SetDataSource(Tabla)
                txtObj = rep.Section2.ReportObjects.Item("txtEmpresa")
                txtObj.Text = Descripcion_Compañia
                crvReporte.ReportSource = rep
            Else
                MsgBox("Fecha de Desde no puede ser mayor a fecha Hasta", MsgBoxStyle.Information, "Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub getBodegas()
        bodegas_ = String.Empty
        For Each oRow As DataGridViewRow In dvBodegas.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                bodegas_ = bodegas_ & oRow.Cells("BODEGA").Value & ","
            End If
        Next

        bodegas_ = bodegas_.TrimEnd(",")
    End Sub
End Class