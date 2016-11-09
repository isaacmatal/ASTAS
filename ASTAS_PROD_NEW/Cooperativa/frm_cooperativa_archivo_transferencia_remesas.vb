Imports System.IO
Public Class frm_cooperativa_archivo_transferencia_remesas
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ruta As String
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Private Sub frm_cooperativa_archivo_transferencia_remesas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.dtpFechaDeposito.Enabled = False
        Me.Label4.Text = Descripcion_Compañia
        c_data1.CargarCombo(cmbBancos, "SELECT DESCRIPCION_BANCO, BANCO FROM CONTABILIDAD_CATALOGO_BANCOS WHERE COMPAÑIA=" & Compañia, "BANCO", "DESCRIPCION_BANCO")
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("Está correcto y desea generar archivo del banco a disco?", MsgBoxStyle.YesNo, "Archivo Texto") = MsgBoxResult.Yes Then
            If Me.GridTransferencia.RowCount > 0 Then
                Try
                    SaveFileDialog1.FileName = cmbBancos.SelectedText
                    SaveFileDialog1.Filter = "Archivo de text(*.txt)|*.txt"
                    SaveFileDialog1.ShowDialog()
                    ruta = SaveFileDialog1.FileName()
                    Dim escribir As New StreamWriter(ruta)
                    For i As Integer = 0 To GridTransferencia.RowCount - 1
                        If cmbBancos.SelectedValue = 1 Then
                            escribir.WriteLine(GridTransferencia.Rows(i).Cells(0).Value.ToString() & ";" & GridTransferencia.Rows(i).Cells(1).Value.ToString() & ";;" & GridTransferencia.Rows(i).Cells(2).Value.ToString() & ";" & GridTransferencia.Rows(i).Cells(3).Value.ToString() & ";" & GridTransferencia.Rows(i).Cells(4).Value.ToString())
                        ElseIf cmbBancos.SelectedValue = 2 Then
                            escribir.WriteLine(GridTransferencia.Rows(i).Cells(0).Value.ToString() & (Chr(9)) & GridTransferencia.Rows(i).Cells(1).Value.ToString() & " " & GridTransferencia.Rows(i).Cells(2).Value.ToString() & (Chr(9)) & GridTransferencia.Rows(i).Cells(3).Value.ToString() & (Chr(9)) & GridTransferencia.Rows(i).Cells(4).Value.ToString().PadLeft(10, "0"))
                        Else
                            escribir.WriteLine(GridTransferencia.Rows(i).Cells(0).Value.ToString() & GridTransferencia.Rows(i).Cells(1).Value.ToString() & GridTransferencia.Rows(i).Cells(2).Value.ToString() & GridTransferencia.Rows(i).Cells(3).Value.ToString() & GridTransferencia.Rows(i).Cells(4).Value.ToString() & GridTransferencia.Rows(i).Cells(5).Value.ToString() & GridTransferencia.Rows(i).Cells(6).Value.ToString() & GridTransferencia.Rows(i).Cells(7).Value.ToString() & GridTransferencia.Rows(i).Cells(8).Value.ToString() & GridTransferencia.Rows(i).Cells(9).Value.ToString() & GridTransferencia.Rows(i).Cells(10).Value.ToString() & GridTransferencia.Rows(i).Cells(11).Value.ToString())
                        End If
                        escribir.Flush()
                    Next
                    escribir.Close()
                    MsgBox("Fin de proceso de generación del archivo de texto.", MsgBoxStyle.Exclamation, "AVISO")
                Catch ex As Exception
                    MsgBox("Aviso...No se ha podido generar el archivo (.txt) " & ex.Message, MsgBoxStyle.Information)
                End Try
            Else
                MsgBox("No Existen datos para generar archivo de texto", MsgBoxStyle.Exclamation, "AVISO")
            End If
        End If
    End Sub
    Public Sub cargar(ByVal bandera)
        DS02.Clear()
        Me.GridTransferencia.DataSource = Nothing
        SQL = "Execute [sp_COOPERATIVA_REPORTE_DIVIDENDOS_SOCIOS_I] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@FECHA_DEPOSITO = '" & Format(dtpFechaDeposito.Value, "yyyy/MM/dd") & "'"
        SQL &= ",@CONCEPTO = '" & Me.txtConcepto.Text & "'"
        SQL &= ",@BANDERA = " & bandera
        CargarGrid(SQL, DS02)
        GridTransferencia.DataSource = DS02.Tables(0)
        c_data1.cerrarConexion()
        For i As Integer = 0 To Me.GridTransferencia.Columns.Count - 1
            Me.GridTransferencia.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub
    Public Sub CargarGrid(ByVal cadena, ByVal ds)
        Try
            ds.Reset()
            c_data1.MiddleConnection(cadena)
            c_data1.DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar los datos", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Ver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ver.Click
        If MsgBox("Reportar detalle de dividendos para abonar banco?", MsgBoxStyle.YesNo, "Archivo Texto") = MsgBoxResult.Yes Then
            If Iniciando = False Then
                Try
                    If cmbBancos.SelectedValue < 4 Then
                        cargar(cmbBancos.SelectedValue)
                    Else
                        MsgBox("Aviso...No hay un formato definido para este banco o no aplica!!!.", MsgBoxStyle.Information)
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub cmbBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
        If Iniciando = False Then
            DS02.Clear()
            Me.GridTransferencia.DataSource = Nothing

            txtConcepto.Enabled = IIf(cmbBancos.SelectedValue = 3, True, False)
            dtpFechaDeposito.Enabled = IIf(cmbBancos.SelectedValue = 2, False, True)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Verificar si existen socios sin cuenta bancaria?", MsgBoxStyle.YesNo, "Archivo Texto") = MsgBoxResult.Yes Then
            If Iniciando = False Then
                Try
                    cargar(6)
                    If Me.GridTransferencia.RowCount = 0 Then
                        MsgBox("Sin registros que reportar", MsgBoxStyle.Exclamation)
                    End If
                Catch ex As Exception
                    MsgBox("Aviso...No hay inconstencias!!!", MsgBoxStyle.Information)
                End Try
            End If
        End If
    End Sub
End Class