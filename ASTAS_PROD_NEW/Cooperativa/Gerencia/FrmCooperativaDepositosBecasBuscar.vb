Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCooperativaDepositosBecasBuscar

    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim cadena_sql_ As String
        cadena_sql_ = "SELECT ID_MAESTRO As ID, NOMBREARCHIVO,FECHA, CONCEPTO, HOJA FROM [COOPERATIVA_DEPOSITOS_BECAS_MAESTRO] WHERE ID_MAESTRO <> 0 AND  (NOMBREARCHIVO Like '%" & txtFindText.Text & "%' OR FECHA = '" & dpFecha.Text & "')"
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(cadena_sql_, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables.Item(0).Rows.Count = 0 Then
                MsgBox("¡No existen coincidencias!", MsgBoxStyle.Critical, "Mensaje")

            End If
            dgvMaestro.DataSource = DS.Tables(0)

            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvMaestro_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaestro.CellClick
        Try
            If dgvMaestro.RowCount = 0 Then
                Return
            Else
                DepositosBecasId = dgvMaestro.CurrentRow.Cells(0).Value
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class