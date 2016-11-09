Imports System.Data.SqlClient
Public Class Inventario_Reporte_Entradas_Salidas
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String, bodega1 As Integer
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Dim ENTRADA_SALIDA As String = "False"

    Private Sub Inventario_Reporte_Entradas_Salidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        c_data.CargaTipoDocumentoInventario(Compañia, Me.cmbTIPO_MOVIMIENTO, 2)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If MsgBox("Desea emitir el reporte?", MsgBoxStyle.YesNo, "REPORTE") = MsgBoxResult.Yes Then
            Try
                Dim in_out As Integer
                Dim ENTRADA_SALIDA As String
                'Determina si es entrada o salida el proceso a realizar
                ENTRADA_SALIDA = c_data1.leerDataeader("Exec sp_INVENTARIOS_DETERMINAR_SI_ES_ENTRADA_SALIDA @TIPO_DOCUMENTO=" & cmbTIPO_MOVIMIENTO.SelectedValue, 5)
                If ENTRADA_SALIDA = False Then
                    in_out = 0
                Else
                    in_out = 1
                End If
                Dim Report As New Inventario_Reporte_Entradas_Salidas_RPT
                Dim Report1 As New Inventario_Reporte_Transferencia_RPT
                Dim Dt As DataTable
                Dim SQL2 As New SqlCommand
                If chk_transferencias.Checked = True Then
                    If Me.cmbTIPO_MOVIMIENTO.SelectedValue = 4 Then
                        SQL2.CommandText = "EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BANDERA=53,@TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue & ",@ENTRADA_SALIDA =" & in_out & ",@FECHA1='" & Me.fecha_desde.Value.ToShortDateString & "', @FECHA2='" & Me.fecha_hasta.Value.ToShortDateString & "', @A_Cero = 0"
                    ElseIf Me.cmbTIPO_MOVIMIENTO.SelectedValue = 1 Then
                        SQL2.CommandText = "EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BANDERA=54,@TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue & ",@ENTRADA_SALIDA =" & in_out & ",@FECHA1='" & Me.fecha_desde.Value.ToShortDateString & "', @FECHA2='" & Me.fecha_hasta.Value.ToShortDateString & "', @A_Cero = 0"
                    Else
                        MsgBox("No exiten datos para dicha especificación.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Dt = c_data1.obtenerDatos(SQL2)
                    If Dt.Rows.Count > 0 Then
                        Report1.SetDataSource(Dt)
                        CrystalReportViewer1.ReportSource = Report1
                    Else
                        MsgBox("No exiten datos para dicha especificación.", MsgBoxStyle.Exclamation)
                    End If
                Else
                    SQL2.CommandText = "EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BANDERA=3,@TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue & ",@ENTRADA_SALIDA =" & in_out & ",@FECHA1='" & Me.fecha_desde.Value.ToShortDateString & "', @FECHA2='" & Me.fecha_hasta.Value.ToShortDateString & "', @A_Cero = 0"
                    Dt = c_data1.obtenerDatos(SQL2)
                    If Dt.Rows.Count > 0 Then
                        Report.SetDataSource(Dt)
                        CrystalReportViewer1.ReportSource = Report
                    Else
                        MsgBox("No exiten datos para dicha especificación.", MsgBoxStyle.Exclamation)
                    End If
                End If
                
            Catch ex As Exception
                MsgBox("AVISO...Ocurrio un problema de conexión. Pruebe en otra oportunidad.", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub Inventario_Reporte_Entradas_Salidas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    
End Class