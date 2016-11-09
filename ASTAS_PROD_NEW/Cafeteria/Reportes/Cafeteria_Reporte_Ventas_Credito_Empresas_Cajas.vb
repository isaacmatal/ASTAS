Imports System.Data.SqlClient

Public Class Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim cajas_ As String
    Dim empresas_ As String

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            getCajas()
            getEmpresas()
            If Not String.IsNullOrEmpty(empresas_) Then
                If cajas_.Length > 0 Then
                    Me.BtnBuscar.Enabled = False

                    If cajas_.Contains(",") Then
                        CargaReporteAll()
                    Else
                        CargaReporte()
                    End If

                    Me.BtnBuscar.Enabled = True
                Else
                    MsgBox("Debe seleccionar almenos una Caja", MsgBoxStyle.Critical, "AVISO")
                End If
            Else
                MsgBox("Debe seleccionar almenos una Empresa", MsgBoxStyle.Critical, "AVISO")
            End If
        End If
    End Sub

    Public Sub CargaReporteAll()
        Dim Rpt As New Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas_Rpt
        Try
            Dim periodo_pago_ As String = String.Empty
            If radQuincenal.Checked Then
                periodo_pago_ = "QQ"
            Else
                periodo_pago_ = "MM"
            End If
            Sql = String.Empty
            DS01.Reset()
            Sql = "EXECUTE sp_CAFETERIA_VENTAS_EMPRESAS_CAJAS @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @contado=" & chkCjasSinMov.Checked & ", @cajas='" & cajas_ & "', @origen='" & empresas_ & "', @periodo_pago='" & periodo_pago_ & "'"
            c_data1.ejecutaSQLl_llenaDTABLE(Sql)
            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub loadCajas()
        Try
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            'sqlCmd.CommandText = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA = 12, @COMPAÑIA = " & Compañia & ", @USUARIO = '" & Usuario & "'"
            sqlCmd.CommandText = "SELECT CJ.CAJA, RTRIM(CJ.DESCRIPCION) + ' - ' + BD.DESCRIPCION_BODEGA + ' - ' + CJ.DESCRIPCION_3 As DESCRIPCION FROM CAFETERIA_CATALOGO_BODEGA_CAJA CJ INNER JOIN INVENTARIOS_CATALOGO_BODEGAS BD ON CJ.BODEGA = BD.BODEGA AND CJ.COMPAÑIA = BD.COMPAÑIA WHERE CJ.COMPAÑIA =" & Compañia

            Tabla = c_data1.obtenerDatos(sqlCmd)


            Dim tbl_ As New DataTable
            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("CAJA", Type.GetType("System.Int32"))
            tbl_.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next

            dgvCajas.AutoGenerateColumns = False
            'Set Columns Count
            dgvCajas.ColumnCount = 3

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

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub loadEmpresas()
        Try
            Dim Tabla2 As DataTable
            Dim sqlCmd_ As New SqlCommand
            sqlCmd_.CommandText = " SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA=" & Compañia & " ORDER BY ORIGEN"
            Tabla2 = c_data1.obtenerDatos(sqlCmd_)

            Dim tbl2_ As New DataTable
            tbl2_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl2_.Columns.Add("ORIGEN", Type.GetType("System.Int32"))
            tbl2_.Columns.Add("DESCRIPCION_ORIGEN", Type.GetType("System.String"))

            For Each row As DataRow In Tabla2.Rows
                tbl2_.Rows.Add(False, row(0), row(1))
            Next

            dgvEmpresas.AutoGenerateColumns = False
            'Set Columns Count
            dgvEmpresas.ColumnCount = 3

            'Add Columns
            dgvEmpresas.Columns(0).Name = "Seleccionar"
            dgvEmpresas.Columns(0).HeaderText = "Seleccionar"
            dgvEmpresas.Columns(0).DataPropertyName = "Seleccionar"

            dgvEmpresas.Columns(1).Name = "ORIGEN"
            dgvEmpresas.Columns(1).HeaderText = "Origen"
            dgvEmpresas.Columns(1).DataPropertyName = "ORIGEN"

            dgvEmpresas.Columns(2).Name = "DESCRIPCION_ORIGEN"
            dgvEmpresas.Columns(2).HeaderText = "Empresa"
            dgvEmpresas.Columns(2).DataPropertyName = "DESCRIPCION_ORIGEN"

            dgvEmpresas.Columns(1).Visible = False
            dgvEmpresas.DataSource = tbl2_
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub getCajas()
        cajas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvCajas.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                cajas_ = cajas_ & oRow.Cells("CAJA").Value & ","
            End If
        Next
        cajas_ = cajas_.TrimEnd(",")
    End Sub

    Private Sub getEmpresas()
        empresas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvEmpresas.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                empresas_ = empresas_ & oRow.Cells("ORIGEN").Value & ","
            End If
        Next
        empresas_ = empresas_.TrimEnd(",")
    End Sub

    Public Sub CargaReporte()
        Dim Rpt As New Cafeteria_Reporte_Ventas_Credito_Empresas_una_Caja
        Try
            Dim periodo_pago_ As String = String.Empty
            If radQuincenal.Checked Then
                periodo_pago_ = "QQ"
            Else
                periodo_pago_ = "MM"
            End If
            getCajas()
            Sql = String.Empty
            DS01.Reset()
            Sql = "EXECUTE sp_CAFETERIA_VENTAS_EMPRESAS_CAJAS @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @contado=" & chkCjasSinMov.Checked & ", @cajas='" & cajas_ & "', @origen='" & empresas_ & "', @periodo_pago='" & periodo_pago_ & "'"
            c_data1.ejecutaSQLl_llenaDTABLE(Sql)
            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            'Dim dt_cajas_ As New DataTable()
            'Sql = "SELECT 0 As CAJA,'Todas las Cajas' As DESCRIPCION UNION ALL SELECT  CAJA, RTRIM(DESCRIPCION) + '-' + DESCRIPCION_3 As DESCRIPCION FROM  dbo . CAFETERIA_CATALOGO_BODEGA_CAJA WHERE COMPAÑIA = 1"
            'dt_cajas_ = c_data1.ejecutaSQLl_llenaDTABLE(Sql)
            'Me.cmbCajas.DataSource = dt_cajas_
            'Me.cmbCajas.ValueMember = "CAJA"
            'Me.cmbCajas.DisplayMember = "DESCRIPCION"
            'Me.cmbCajas.SelectedIndex = 0
            Sql = String.Empty
            loadEmpresas()
            loadCajas()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        Iniciando = False
    End Sub

    Private Sub allOrigen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allOrigen.CheckedChanged
        If allOrigen.Checked Then
            For Each fila As DataGridViewRow In dgvEmpresas.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvEmpresas.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub allBodegas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allBodegas.CheckedChanged
        If allBodegas.Checked Then
            For Each fila As DataGridViewRow In dgvCajas.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvCajas.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub
End Class