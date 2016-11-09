Imports System.Data.SqlClient

Public Class Cafeteria_Reporte_ProduccionVsVentas
    Dim jClass As New jarsClass
    Dim Table As New DataTable
    Dim sqlCmd As New SqlCommand
    Dim sql As String
    Dim Iniciando As Boolean
    Dim c_data1 As New jarsClass
    Dim cajas_ As String
    Dim ejecutar As Boolean

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ejecutar = False
        btnNuevo.Visible = False
        Dim planta_ As String
        planta_ = IIf(rdPlanta1.Checked, "1", "2")

        Try
            Me.getCajas()
            If cajas_.Trim().Length > 0 Then
                Dim Rpt As New Cafeteria_Reporte_ProducVsVentas
                sqlCmd.CommandText = "Exec sp_CAFETERIA_REPORTE_PROD_VS_VENTAS  @COMPAÑIA=" & Compañia & ", @FECHA_DESDE='" & Format(Me.fecha_desde.Value, "dd/MM/yyyy") & "', @USUARIO='" & Usuario & "', @FECHA_HASTA='" & Format(Me.fecha_desde.Value, "dd/MM/yyyy") & "', @PLANTA=" & planta_ & ", @CAJAS='" & cajas_ & "'"
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.SetDataSource(Table)
                Me.CrystalReportViewer1.ReportSource = Rpt
            Else
                MsgBox("Seleccione una caja...", MsgBoxStyle.Information, "Información")
            End If            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        btnNuevo.Visible = True

        ejecutar = True
    End Sub

    Private Sub Cafeteria_Reporte_ProduccionVsVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvCajas.AutoGenerateColumns = False
        dgvCajas.ColumnCount = 3
        ejecutar = True
        chkAllCajas.Enabled = False
    End Sub


    Private Sub loadCajas()
        Try
            If Not Me.radNone.Checked Then
                dgvCajas.DataSource = Nothing
                Dim Tabla As DataTable
                Dim sqlCmd As New SqlCommand
                sqlCmd.CommandText = "SELECT CJ.CAJA, RTRIM(CJ.DESCRIPCION) + ' - ' + BD.DESCRIPCION_BODEGA + ' - ' + CJ.DESCRIPCION_3 As DESCRIPCION FROM CAFETERIA_CATALOGO_BODEGA_CAJA CJ INNER JOIN INVENTARIOS_CATALOGO_BODEGAS BD ON CJ.BODEGA = BD.BODEGA AND CJ.COMPAÑIA = BD.COMPAÑIA WHERE BD.PLANTA=" & IIf(Me.rdPlanta1.Checked, "1", "2") & " AND CJ.COMPAÑIA =" & Compañia

                Tabla = c_data1.obtenerDatos(sqlCmd)
                Dim tbl_ As New DataTable
                tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
                tbl_.Columns.Add("CAJA", Type.GetType("System.Int32"))
                tbl_.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

                For Each row As DataRow In Tabla.Rows
                    tbl_.Rows.Add(False, row(0), row(1))
                Next
                'Add Columns
                dgvCajas.Columns(0).Name = "Seleccionar"
                dgvCajas.Columns(0).HeaderText = "Seleccionar"
                dgvCajas.Columns(0).DataPropertyName = "Seleccionar"
                dgvCajas.Columns(1).Name = "CAJA"
                dgvCajas.Columns(1).HeaderText = "Caja"
                dgvCajas.Columns(1).DataPropertyName = "CAJA"
                dgvCajas.Columns(2).Name = "DESCRIPCION"
                dgvCajas.Columns(2).HeaderText = "Descripciòn"
                dgvCajas.Columns(2).DataPropertyName = "DESCRIPCION"
                dgvCajas.Columns(1).Visible = False
                dgvCajas.DataSource = tbl_
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub getCajas()
        cajas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvCajas.Rows
            If oRow.Cells("SELECCIONAR").Value = True Then
                cajas_ = cajas_ & oRow.Cells("CAJA").Value & ","
            End If
        Next
        cajas_ = cajas_.TrimEnd(",")
    End Sub

    Private Sub rdPlanta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPlanta1.Click
        If ejecutar Then
            chkAllCajas.Enabled = True
            Me.loadCajas()
        End If
    End Sub

    Private Sub rdPlanta2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPlanta2.Click
        If ejecutar Then
            chkAllCajas.Enabled = True
            Me.loadCajas()
        End If
    End Sub

    Private Sub chkAllCajas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllCajas.CheckedChanged
        If chkAllCajas.Checked Then
            For Each fila As DataGridViewRow In dgvCajas.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvCajas.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub radNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNone.Click
        If ejecutar Then
            dgvCajas.DataSource = Nothing
            chkAllCajas.Enabled = False
        End If
    End Sub
End Class