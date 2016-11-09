Public Class Cafeteria_Reporte_Empleados_Bloqueados
    Dim comandos As New jarsClass
    Dim _table As New DataTable()

    Private Sub Cafeteria_Reporte_Empleados_Bloqueados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)

        _table = comandos.ejecutaSQLl_llenaDTABLE("EXEC sp_COOPERATIVA_CATALOGO_ORIGENES @COMPAÑIA=" & Compañia & ", @BANDERA=3")
        Dim _seleccionar_col As DataColumn = New System.Data.DataColumn("SELECCIONADO", System.Type.GetType("System.Boolean"))
        _seleccionar_col.DefaultValue = False
        _table.Columns.Add(_seleccionar_col)
        Me.dgvOrigenes.DataSource = _table

        Me.dgvOrigenes.Columns(0).Visible = False
        Me.dgvOrigenes.Columns(1).Width = 250
        Me.dgvOrigenes.Columns(1).HeaderText = "Empresa"
        Me.dgvOrigenes.Columns(1).ReadOnly = True
        Me.dgvOrigenes.Columns(2).Width = 75
        Me.dgvOrigenes.Columns(2).HeaderText = "Seleccionar"
    End Sub


    Private Sub dgvOrigenes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrigenes.CellContentClick
        'cambio del checkbox 
        If dgvOrigenes.CurrentRow.Cells(2).Value Then
            dgvOrigenes.CurrentRow.Cells(2).Value = False
        Else
            dgvOrigenes.CurrentRow.Cells(2).Value = True
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim i As Integer
        Dim _origenes As String = String.Empty
        For i = 0 To dgvOrigenes.Rows.Count - 1
            If (dgvOrigenes.Rows(i).Cells(2).Value) Then
                _origenes &= dgvOrigenes.Rows(i).Cells(0).Value & ","
            End If
        Next

        If _origenes.Length > 0 Then
            Me.btnPrint.Enabled = False
            Dim _reportes As New frmReportes_Ver()
            _reportes.CargarRptDescuentosEmpleados(Compañia, _origenes.TrimEnd(","))
            _reportes.ShowDialog()
            Me.btnPrint.Enabled = True
        Else
            MsgBox("Seleccione una o varias empresas.", MsgBoxStyle.Information, "Validación")
        End If
      
    End Sub

    Private Sub chkOrigen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOrigen.CheckedChanged
        Dim i As Integer

        If chkOrigen.Checked Then
            For i = 0 To dgvOrigenes.Rows.Count - 1
                dgvOrigenes.Rows(i).Cells(2).Value = True
            Next
        Else
            For i = 0 To dgvOrigenes.Rows.Count - 1
                dgvOrigenes.Rows(i).Cells(2).Value = False
            Next
        End If
    End Sub
End Class