Imports System.Data.SqlClient
Imports System
Public Class Contabilidad_Consulta_Cheques_Emergencia
    Dim sql As String
    Dim jClass As New jarsClass
    Dim VLetras As New NumeroLetras
    Dim table As DataTable

    Private Sub Contabilidad_Consulta_Cheques_Emergencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.dpdesde.Value = Now.AddDays(-Now.Day).AddDays(1)
        Me.dphasta.Value = Now
        Me.btnconsultar.PerformClick()
    End Sub

    Private Sub btnconsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsultar.Click
        Dim sqlcom As New SqlCommand
        sql = " EXECUTE sp_CONTABILIDAD_VER_CHEQUES_EMERGENCIA "
        sql &= " @COMPAÑIA = " & Compañia
        sql &= ",@FECHA_DESDE = '" & Format(Me.dpdesde.Value, "dd-MM-yyyy 00:00:00") & "'"
        sql &= ",@FECHA_HASTA = '" & Format(Me.dphasta.Value, "dd-MM-yyyy 23:59:59") & "'"
        sqlcom.CommandText = sql
        table = jClass.obtenerDatos(sqlcom)
        Me.dgvchequeemergencia.DataSource = table
        estiloDataGrid()
    End Sub

    Private Sub estiloDataGrid()
        Dim i As Integer
        Me.dgvchequeemergencia.Columns.Item(2).Visible = False 'Cod.Banco
        Me.dgvchequeemergencia.Columns(3).Width = 60 'cheque
        Me.dgvchequeemergencia.Columns(4).Width = 130 'banco
        Me.dgvchequeemergencia.Columns(5).Width = 120 'Cuenta Bancaria
        Me.dgvchequeemergencia.Columns(6).Width = 200 'a nombre de
        Me.dgvchequeemergencia.Columns(7).Width = 80 'monto
        Me.dgvchequeemergencia.Columns(8).Width = 200 'concepto 
        Me.dgvchequeemergencia.Columns(9).Width = 70  'fecha
        Me.dgvchequeemergencia.Columns(10).Width = 60 'partida
        Me.dgvchequeemergencia.Columns(11).Visible = False 'partida liquidada
        Me.dgvchequeemergencia.Columns(12).Width = 80 'usuario
        Me.dgvchequeemergencia.Columns(13).Width = 60 'impreso
        Me.dgvchequeemergencia.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvchequeemergencia.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvchequeemergencia.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvchequeemergencia.Columns(7).DefaultCellStyle.Format = "#,###.00"
        Me.dgvchequeemergencia.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 2 To 5
            Me.dgvchequeemergencia.Columns(i).ReadOnly = True
        Next
        Me.dgvchequeemergencia.Columns(10).ReadOnly = True
        Me.dgvchequeemergencia.Columns(12).ReadOnly = True
        Me.dgvchequeemergencia.Columns(13).ReadOnly = True
    End Sub
    Private Sub GenerarCheque(ByVal Opcion As Integer)
        Try
            Dim chequeTable As New DataTable
            Dim ValorenLetras As String
            Dim Rpts As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
            Dim frmVer As New frmReportes_Ver
            Dim contch As New Contabilidad_Imprimir_Cheques
            chequeTable.Columns.Add("Numero Cheque", Type.GetType("System.Int32"))
            chequeTable.Columns.Add("Nombre", Type.GetType("System.String"))
            chequeTable.Columns.Add("Valor Cheque", Type.GetType("System.Double"))
            chequeTable.Columns.Add("Letras", Type.GetType("System.String"))
            chequeTable.Columns.Add("Negociable", Type.GetType("System.Boolean"))
            chequeTable.Columns.Add("Fecha", Type.GetType("System.DateTime"))
            If Opcion = 1 Then
                ValorenLetras = VLetras.Letras(Me.dgvchequeemergencia.CurrentRow.Cells(7).Value.ToString()).Replace("US DOLARES", "").Trim()
                chequeTable.Rows.Add(Me.dgvchequeemergencia.CurrentRow.Cells(3).Value, Me.dgvchequeemergencia.CurrentRow.Cells(6).Value, Me.dgvchequeemergencia.CurrentRow.Cells(7).Value, ValorenLetras, IIf(IsDBNull(Me.dgvchequeemergencia.CurrentRow.Cells(1).Value), False, Me.dgvchequeemergencia.CurrentRow.Cells(1).Value), Me.dgvchequeemergencia.CurrentRow.Cells(9).Value)
                Rpts.SetDataSource(chequeTable)
                frmVer.crvReporte.ReportSource = Rpts
                frmVer.ShowDialog(Me)
                sql = "UPDATE [dbo].[CONTABILIDAD_CHEQUE_EMERGENCIA]" & vbCrLf
                Sql &= "   SET IMPRESO = 1" & vbCrLf
                sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                sql &= "   AND CHEQUE = " & Me.dgvchequeemergencia.CurrentRow.Cells("N° cheque").Value.ToString() & vbCrLf
                sql &= "   AND BANCO = " & Me.dgvchequeemergencia.CurrentRow.Cells("CODBANCO").Value.ToString() & vbCrLf
                sql &= "   AND CUENTA_BANCARIA = '" & Me.dgvchequeemergencia.CurrentRow.Cells("Cuenta Bancaria").Value & "'" & vbCrLf
                jClass.Ejecutar_ConsultaSQL(sql)
            Else
                'chequeTable.Columns.Add("No Negociable", Type.GetType("System.Boolean"))
                For i As Integer = 0 To Me.dgvchequeemergencia.Rows.Count - 1
                    If Me.dgvchequeemergencia.Rows(i).Cells(0).Value Then
                        ValorenLetras = VLetras.Letras(Me.dgvchequeemergencia.Rows(i).Cells(7).Value.ToString()).Replace("US DOLARES", "").Trim()
                        chequeTable.Rows.Add(Me.dgvchequeemergencia.Rows(i).Cells(3).Value, Me.dgvchequeemergencia.Rows(i).Cells(6).Value, Me.dgvchequeemergencia.Rows(i).Cells(7).Value, ValorenLetras, Me.dgvchequeemergencia.Rows(i).Cells(1).Value, Me.dgvchequeemergencia.Rows(i).Cells(9).Value)
                    End If
                Next
                contch.dgvCheques.DataSource = chequeTable
                contch.dgvCheques.Columns(0).Width = 50
                contch.dgvCheques.Columns(1).Width = 200
                contch.dgvCheques.Columns(2).Width = 80
                contch.dgvCheques.Columns(2).DefaultCellStyle.Format = "#,###.00"
                contch.dgvCheques.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                contch.dgvCheques.Columns(3).Width = 160
                contch.dgvCheques.Columns(4).Width = 70
                contch.dgvCheques.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
                contch.dgvCheques.Columns(5).Width = 80
                contch.ShowDialog(Me)
            End If
        Catch ex As Exception
            jClass.msjError(ex, "generar cheque")
        End Try
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Dim j As Integer = 0
        Dim RowsAffected As Integer
        Dim sqlCmd As New SqlCommand
        For Each row As DataGridViewRow In Me.dgvchequeemergencia.Rows
            If Not row.Cells("Impreso").Value And row.Cells("Usuario").Value = Usuario Then
                sql = "EXECUTE sp_CONTABILIDAD_CHEQUE_EMERGENCIA_IUD" & vbCrLf
                sql &= " @COMPAÑIA = " & Compañia & vbCrLf
                sql &= ",@CHEQUE = " & Val(row.Cells("N° cheque").Value) & vbCrLf
                sql &= ",@PERSONA = '" & row.Cells("A Nombre De").Value & "'" & vbCrLf
                sql &= ",@MONTO = " & Val(row.Cells("Monto").Value) & vbCrLf
                sql &= ",@MONTO_LETRAS = '" & VLetras.Letras(Format(row.Cells("Monto").Value, "0.00")) & "'" & vbCrLf
                sql &= ",@CONCEPTO = '" & row.Cells("Concepto").Value & "'" & vbCrLf
                sql &= ",@BANCO = " & Val(row.Cells("CODBANCO").Value) & vbCrLf
                sql &= ",@CUENTA_BANCARIA = '" & row.Cells("Cuenta Bancaria").Value & "'" & vbCrLf
                sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
                sql &= ",@ACCION = 'U'"
                sqlCmd.CommandText = sql
                RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
                If RowsAffected > 0 Then
                    j = j + 1
                End If
            End If
        Next
        If j > 0 Then
            MsgBox("Cambios almacenados con exito", MsgBoxStyle.Information, "Mensaje")
        End If
        Me.btnconsultar.PerformClick()
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim frm As New frmReportes_Ver
        Dim reporte As New Contabilidad_reporte_chequesemergencia

        Dim sqlcom As New SqlCommand
        Dim table As DataTable
        sql = "EXECUTE sp_CONTABILIDAD_CHEQUES_EMERGENCIA_RPT " & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        sql &= ",@FECHA_DESDE = '" & Format(Me.dpdesde.Value, "dd-MM-yyyy 00:00:00") & "'" & vbCrLf
        sql &= ",@FECHA_HASTA = '" & Format(Me.dphasta.Value, "dd-MM-yyyy 23:59:59") & "'"
        sqlcom.CommandText = sql
        table = jClass.obtenerDatos(sqlcom)
        reporte.SetDataSource(table)
        frm.Show()
        frm.crvReporte.ReportSource = reporte
    End Sub

    Private Sub Contabilidad_Consulta_Cheques_Emergencia_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnImpCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpCheque.Click
        GenerarCheque(2)
        Me.btnconsultar.PerformClick()
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaBco.TextChanged, txtCONCEPTO.TextChanged, txtCheque.TextChanged, txtNombre.TextChanged, txtBanco.TextChanged, txtUsuario.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = table.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvchequeemergencia.DataSource = table
        Else
            rows = table.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvchequeemergencia.DataSource = Nothing
            Me.dgvchequeemergencia.DataSource = tablaT
            Me.estiloDataGrid()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChqInd.Click
        GenerarCheque(1)
        Me.btnconsultar.PerformClick()
    End Sub
End Class