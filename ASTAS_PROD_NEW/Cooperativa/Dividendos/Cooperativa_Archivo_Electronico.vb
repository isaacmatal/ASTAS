Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Cooperativa_Archivo_Electronico
    Dim Proc As New jarsClass
    Dim asocs(3) As String

    Private Sub Cooperativa_Archivo_Electronico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga()
        TextBox1.Text = "09"
        asocs(0) = "N/A"
        asocs(1) = "A.S.T.A.S."
        asocs(2) = "A.T.A.F."
    End Sub
    Public Sub carga()
        dgvTipos.DataSource = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=11, @NUMERO_REPARTO=" & nudYear.Value & ",@ASOCIACION=" & Asociaciones.Value & ", @AÑO = " & Me.nudYear.Value).Tables(0)
        For i As Integer = 0 To dgvTipos.Columns.Count - 1
            dgvTipos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If i > 2 Then
                dgvTipos.Columns.Item(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvTipos.Columns.Item(i).DefaultCellStyle.Format = "#,###.00"
            End If
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            dgvDatos.DataSource = Proc.ObtenerDataSet("EXECUTE sp_REPORTES_VARIOS_DIVIDENDOS @COMPAÑIA=" & Compañia & ", @BANDERA=9, @FECHA1='" & Format(dgvTipos.CurrentRow.Cells(1).Value, "dd/MM/yyyy") & "', @FECHA2='" & Format(dgvTipos.CurrentRow.Cells(2).Value, "dd/MM/yyyy") & "', @PARAMETRO='" & Me.TextBox1.Text & "', @ASOCIACION = " & CInt(Me.Asociaciones.Value).ToString()).Tables(0)
            For i As Integer = 0 To dgvTipos.RowCount - 1
                dgvDatos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        Catch ex As Exception
            MsgBox("Asegurese de haber seleccionado el reparto indicado!")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\INFORME_F910.txt"

        Dim SW As IO.StreamWriter = New IO.StreamWriter(archivo, False, Encoding.ASCII)
        For i As Integer = 0 To dgvDatos.RowCount - 1
            SW.WriteLine(dgvDatos.Rows(i).Cells(0).Value.ToString().PadRight(40) & dgvDatos.Rows(i).Cells(1).Value.ToString() & dgvDatos.Rows(i).Cells(2).Value.ToString() & dgvDatos.Rows(i).Cells(3).Value.ToString() & dgvDatos.Rows(i).Cells(4).Value.ToString() & dgvDatos.Rows(i).Cells(5).Value.ToString() & dgvDatos.Rows(i).Cells(6).Value.ToString() & dgvDatos.Rows(i).Cells(7).Value.ToString())
        Next
        SW.Close()
        SW.Dispose()

        MsgBox("El archivo """ & archivo & """ ha sido generado con éxito")
        Process.Start("NOTEPAD.EXE", archivo)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dgvDatos.DataSource = Nothing
        dgvTipos.DataSource = Nothing
    End Sub

    Private Sub numeroReparto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudYear.ValueChanged
        carga()
    End Sub

    Private Sub Asociaciones_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Asociaciones.ValueChanged
        Me.lblAsoc.Text = asocs(Me.Asociaciones.Value)
        carga()
    End Sub
End Class