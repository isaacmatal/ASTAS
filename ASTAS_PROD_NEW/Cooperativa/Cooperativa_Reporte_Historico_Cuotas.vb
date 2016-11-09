Imports System.Data.SqlClient

Public Class Cooperativa_Reporte_Historico_Cuotas
    Dim jasr_fill As New jarsClass
    Dim Sql As String
    Dim empresas_ As String
    Dim rubros_ As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim Tabla As DataTable
    Dim TRubro_ As DataTable
    Dim tbl_ As New DataTable
    Dim tbl2_ As New DataTable

    Private Sub Cooperativa_Reporte_Historico_Cuotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label4.Text = Descripcion_Compañia
        Iniciando = False
        Me.Fecha.Value = Date.Now

        Try
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES "
            Tabla = jasr_fill.obtenerDatos(sqlCmd)

            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("ORIGEN", Type.GetType("System.Int32"))
            tbl_.Columns.Add("DESCRIPCION_ORIGEN", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next

            dgvOrigen.AutoGenerateColumns = False
            'Set Columns Count
            dgvOrigen.ColumnCount = 3

            'Add Columns
            dgvOrigen.Columns(0).Name = "Seleccionar"
            dgvOrigen.Columns(0).HeaderText = "Seleccionar"
            dgvOrigen.Columns(0).DataPropertyName = "Seleccionar"

            dgvOrigen.Columns(1).Name = "ORIGEN"
            dgvOrigen.Columns(1).HeaderText = "ORIGEN"
            dgvOrigen.Columns(1).DataPropertyName = "ORIGEN"

            dgvOrigen.Columns(2).Name = "DESCRIPCION_ORIGEN"
            dgvOrigen.Columns(2).HeaderText = "Empresa"
            dgvOrigen.Columns(2).DataPropertyName = "DESCRIPCION_ORIGEN"

            dgvOrigen.DataSource = tbl_
            Me.dgvOrigen.Columns("ORIGEN").Visible = False

            'Rubros
            Dim sqlCmd2 As New SqlCommand
            'sqlCmd2.CommandText = "SELECT * FROM (SELECT D.COD_MV AS CODIGO_DEDUCCION ,(SELECT DD.DESCRIPCION_DEDUCCION FROM COOPERATIVA_CATALOGO_DEDUCCIONES DD  WHERE D.COD_MV = DD.DEDUCCION) AS 'RUBRO' FROM  dbo.PLANILLA_DESCUENTOS_APLICADOS  D  INNER JOIN [dbo].[COOPERATIVA_SOLICITUDES] C  ON D.UNID_HD = C.CORRELATIVO AND D.COD_MV = C.DEDUCCION) qry_rubro  GROUP BY qry_rubro.CODIGO_DEDUCCION, qry_rubro.RUBRO ORDER BY qry_rubro.RUBRO"
            sqlCmd2.CommandText = "SELECT DEDUCCION AS CODIGO_DEDUCCION, DESCRIPCION_DEDUCCION FROM COOPERATIVA_CATALOGO_DEDUCCIONES"
            TRubro_ = jasr_fill.obtenerDatos(sqlCmd2)

            tbl2_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl2_.Columns.Add("CODIGO_DEDUCCION", Type.GetType("System.Int32"))
            tbl2_.Columns.Add("DESCRIPCION_DEDUCCION", Type.GetType("System.String"))
            For Each row2 As DataRow In TRubro_.Rows
                tbl2_.Rows.Add(False, row2(0), row2(1))
            Next

            dgvRubro.AutoGenerateColumns = False
            dgvRubro.ColumnCount = 3

            dgvRubro.Columns(0).Name = "Seleccionar"
            dgvRubro.Columns(0).HeaderText = "Seleccionar"
            dgvRubro.Columns(0).DataPropertyName = "Seleccionar"

            dgvRubro.Columns(1).Name = "CODIGO_DEDUCCION"
            dgvRubro.Columns(1).HeaderText = "CODIGO_DEDUCCION"
            dgvRubro.Columns(1).DataPropertyName = "CODIGO_DEDUCCION"

            dgvRubro.Columns(2).Name = "DESCRIPCION_DEDUCCION"
            dgvRubro.Columns(2).HeaderText = "Rubro"
            dgvRubro.Columns(2).DataPropertyName = "DESCRIPCION_DEDUCCION"

            dgvRubro.DataSource = tbl2_
            Me.dgvRubro.Columns("CODIGO_DEDUCCION").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try

        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            'If Me.Fecha.Value < Me.dateDesde.Value Then
            '    Me.Fecha.Value = Date.Now
            '    MsgBox("Debe seleccionar una fecha mayor a la fecha de inicio.", MsgBoxStyle.Critical, "AVISO")
            '    Return
            'End If

            If MsgBox("¿Está seguro que desea generar el Reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                empresas_ = String.Empty
                getEmpresas()
                getRubros()

                If String.IsNullOrEmpty(empresas_) Then
                    MsgBox("Debe seleccionar almenos una Empresa.", MsgBoxStyle.Exclamation, "AVISO")
                    Return
                End If

                If String.IsNullOrEmpty(rubros_) Then
                    MsgBox("Debe seleccionar almenos un Rubro.", MsgBoxStyle.Exclamation, "AVISO")
                    Return
                End If

                Me.btnImprimir.Enabled = False

                Dim tbl_rep_ As DataTable
                Dim sqlCmd_ As New SqlCommand
                sqlCmd_.CommandText = "Exec sp_COOPERATIVA_REPORTE_HISTORICO_CUOTAS_FILTER @FECHA_FINAL2='" & Fecha.Text.ToString() & "'" & IIf(String.IsNullOrEmpty(empresas_), String.Empty, ", @ORIGEN2='" & empresas_ & "', @RUBROS2='" & rubros_ & "', @ULT_QUINCENA2=" & IIf(Me.rad1.Checked, 0, 1))
                tbl_rep_ = jasr_fill.obtenerDatos(sqlCmd_)

                If tbl_rep_.Rows.Count > 0 Then
                    Rpts.GetReporteHistoricoCuotas(tbl_rep_)
                    Rpts.ShowDialog()
                Else
                    MsgBox("No Existen datos!.", MsgBoxStyle.Exclamation, "AVISO")
                End If
                Me.btnImprimir.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub getEmpresas()
        empresas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvOrigen.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                empresas_ = empresas_ & oRow.Cells("ORIGEN").Value & ","
            End If
        Next

        empresas_ = empresas_.TrimEnd(",")
    End Sub

    Private Sub getRubros()
        rubros_ = String.Empty
        For Each oRow As DataGridViewRow In dgvRubro.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                rubros_ = rubros_ & oRow.Cells("CODIGO_DEDUCCION").Value & ","
            End If
        Next

        rubros_ = rubros_.TrimEnd(",")
    End Sub

    Private Sub chkTodasEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasEmpresas.CheckedChanged
        If Me.chkTodasEmpresas.Checked Then
            For Each oRow As DataGridViewRow In dgvOrigen.Rows
                oRow.Cells("Seleccionar").Value = True
            Next
        Else
            For Each oRow As DataGridViewRow In dgvOrigen.Rows
                oRow.Cells("Seleccionar").Value = False
            Next
        End If
    End Sub

    Private Sub chkAllRubros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllRubros.CheckedChanged
        If Me.chkAllRubros.Checked Then
            For Each oRow As DataGridViewRow In dgvRubro.Rows
                oRow.Cells("Seleccionar").Value = True
            Next
        Else
            For Each oRow As DataGridViewRow In dgvRubro.Rows
                oRow.Cells("Seleccionar").Value = False
            Next
        End If
    End Sub
End Class