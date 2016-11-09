Public Class Cafeteria_Facturacion_Periodos_Pago

    Dim ConnString As String = "Provider=SQLOLEDB;Data Source=" & Servidor & ";Persist Security Info=True;Password=" & PasswordDB & ";User ID=" & ASTAS.UsuarioDB & ";Initial Catalog=" & BaseDatos

    Private Sub CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Click
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.CurrentRow.Cells(0).Value = Compañia
        Me.Validate()
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource.EndEdit()
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter.Update(Me.DSPeriodosCobro.CAFETERIA_FACTURACION_PERIODOS_DE_COBRO)
    End Sub

    Private Sub Cafeteria_Facturacion_Periodos_Pago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter.Connection.ConnectionString = ConnString
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter.Fill(Me.DSPeriodosCobro.CAFETERIA_FACTURACION_PERIODOS_DE_COBRO)
    End Sub

    Private Sub CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.DataError
        e.ThrowException = False
    End Sub

    Private Sub CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.RowsAdded
        If Not (sender.currentrow Is Nothing) Then
            Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Rows(e.RowIndex).Cells(0).Value = Compañia
        End If
    End Sub

 
End Class