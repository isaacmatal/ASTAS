Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Web

Public Class Contabilidad_Informe_Compras_Ventas
    Dim jClass As New jarsClass

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim Sql As String
        Dim Table As DataTable
        Dim sb = New StringBuilder()
        Dim var2 As String
        Dim ident As Integer
        Dim Tipo_doc As Integer
        Dim NIT As String = String.Empty
        Dim NRC As String
        Dim IVA As String
        Dim excluidos As String
        Dim Total As String
        Dim fecha As String
        Dim num_doc As String
        Dim fec_cont As Date
        Dim Mes As String
        Dim año As String
        Dim direccion As String
        Dim dia As String
        dia = ""
        var2 = ""
        Tipo_doc = 0
        Total = ""
        Try
            If Me.RdbPinscrito.Checked = True Or Me.RdbExcluido.Checked = True Or Me.Rdbexentos.Checked = True Then

                Sql = "Execute sp_CONTABILIDAD_REPORTES_LIBRO_COMPRAS " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @BODEGA = " & 1 & vbCrLf
                Sql &= ", @FEC_INI = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy 00:00:01") & "'" & vbCrLf
                Sql &= ", @FEC_FIN = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy 23:59:59") & "'" & vbCrLf
                Sql &= ", @CONSOLI = " & 1 & vbCrLf
                Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
                Sql &= ", @BANDERA = " & 1

                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                'Dim num_ As Integer = Table.Rows.Count
                'Dim num_new As Integer = Table.Select("TIPO_DOC <> '#' AND SUBTOTAL > 0 AND ").Length

                'Dim filas_() As DataRow

                'filas_ = Table.Select("TIPO_DOC <> '#' AND SUBTOTAL > 0")

                ''INCRITO EN IVA
                If Me.RdbPinscrito.Checked = True Then
                    For Each dr As DataRow In Table.Rows
                        var2 = dr(20).ToString
                        If var2 <> "#" And dr(10) <> 0 Then ''And dr(10) <> 0 
                            If var2 = "CCF" Then
                                Tipo_doc = 1
                            ElseIf var2 = "ND" Then
                                Tipo_doc = 4
                            ElseIf var2 = "NC" Then
                                Tipo_doc = 5
                            End If
                            If dr(10) < 0 Then
                                Tipo_doc = 5
                            End If

                            ident = 2
                            NRC = (Eliminar(dr(6).ToString)).PadRight(14, " ")
                            fec_cont = dr(4)
                            Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                            año = Year(fec_cont)
                            fecha = fec_cont.ToString("yyyyMMdd")
                            Total = (Eliminar(dr(10).ToString)).PadLeft(11, "0")
                            IVA = (Eliminar(Format(Math.Round(dr(10) * 0.13, 2), "0.00"))).PadLeft(11, "0")
                            num_doc = dr(5).ToString.PadRight(20, " ")
                            sb.Append(Mes & ident & NRC & fecha & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)
                            'sb.Append(Mes & "," & ident & "," & NRC & "," & fecha & "," & Tipo_doc & "," & num_doc & "," & Total & "," & IVA & "," & año + vbCrLf)
                        End If
                    Next
                End If
                'EXENTOS
                If Me.Rdbexentos.Checked = True Then
                    For Each dr As DataRow In Table.Rows
                        var2 = dr(20).ToString
                        If var2 <> "#" And dr(15) > 0 Then

                            If var2 = "CCF" Then
                                Tipo_doc = 1
                            ElseIf var2 = "ND" Then
                                Tipo_doc = 4
                            ElseIf var2 = "NC" Then
                                Tipo_doc = 5
                            End If
                            ident = 2
                            NRC = (Eliminar(dr(6).ToString)).PadRight(14, " ")
                            fec_cont = dr(4)
                            Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                            año = Year(fec_cont)
                            fecha = fec_cont.ToString("yyyyMMdd")
                            Total = (Eliminar(dr(15).ToString)).PadLeft(11, "0")
                            ''Total = (Eliminar(Format(Math.Round((dr(12) / 1.13), 2), "0.00"))).PadLeft(11, "0")
                            ''IVA = (Eliminar(dr(11).ToString)).PadLeft(11, "0")
                            IVA = (Eliminar(Format(Math.Round(0.0, 2), "0.00"))).PadLeft(11, "0")
                            'IVA = (Eliminar(Format(Math.Round((((dr(10) / 1.13)) * 0.13), 2), "0.00"))).PadLeft(11, "0")
                            num_doc = dr(5).ToString.PadRight(20, " ")
                            sb.Append(Mes & ident & NRC & fecha & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)
                        End If
                    Next
                End If
                '' EXCLUIDO EN IVA
                If Me.RdbExcluido.Checked = True Then
                    For Each dr As DataRow In Table.Rows
                        var2 = dr(20).ToString
                        If var2 = "#" Then
                            Tipo_doc = 1
                            ident = 1
                            NIT = (Eliminar(dr(7).ToString)).PadRight(14, " ")
                            fec_cont = dr(4)
                            Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                            año = Year(fec_cont)
                            fecha = fec_cont.ToString("yyyyMMdd")
                            'excluidos = (Eliminar(dr(14).ToString)).PadLeft(11, "0")
                            excluidos = (Eliminar(Format(Math.Round((dr(14)), 2), "0.00"))).PadLeft(11, "0")
                            direccion = dr(9).ToString.PadRight(150, " ")
                            num_doc = dr(5).ToString.PadRight(20, " ")
                            sb.Append(Mes & ident & NIT & fecha & Tipo_doc & num_doc & excluidos & direccion & año + vbCrLf)
                        End If
                    Next
                End If

            End If
            'CLIENTES FACTURAS < $200 
            If Me.Rdbclientesmenor.Checked = True Then

                Sql = " Execute sp_FACTURACION_GENERADA_LIBROS_VENTAS_IVA " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @TIPO_DOCUMENTO = " & 1 & vbCrLf
                Sql &= ", @MONTH = " & 1 & vbCrLf
                Sql &= ", @RESUMEN = " & 1 & vbCrLf
                Sql &= ", @CONDICION_FECHAS = " & 0 & vbCrLf
                Sql &= ", @FECHA_DESDE = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy 00:00:00") & "'" & vbCrLf
                Sql &= ", @FECHA_HASTA = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy 23:59:59") & "'" & vbCrLf
                Sql &= ", @TODAS_BODEGAS = " & 1 & vbCrLf
                Sql &= ", @BANDERA = " & 1

                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                Dim REGISTROS As String
                For Each dr As DataRow In Table.Rows

                    REGISTROS = (dr(20).ToString).PadLeft(8, "0")
                    dia = (Eliminar(dr(0)).ToString).PadLeft(2, "0")
                    Mes = (Eliminar(dr(13)).ToString).PadLeft(2, "0")
                    año = dr(12).ToString
                    Total = (Eliminar(Format(Math.Round((dr(10) / 1.13), 2), "0.00"))).PadLeft(11, "0")
                    IVA = (Eliminar(Format(Math.Round(((Math.Round((dr(10) / 1.13), 2)) * 0.13), 2), "0.00"))).PadLeft(11, "0")

                    'sb.Append(año & Mes & dia & REGISTROS & Total & IVA & año + vbCrLf)
                    sb.Append(año & Mes & dia & REGISTROS & Total & IVA & año + vbCrLf)

                Next


            End If
            'CLIENTES FACTURAS > $200 Y CCF
            If Me.Rdbclientesmayor.Checked = True Then

                Sql = " Execute sp_FACTURACION_GENERADA_LIBROS_VENTAS_IVA " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @TIPO_DOCUMENTO = " & 1 & vbCrLf
                Sql &= ", @MONTH = " & 1 & vbCrLf
                Sql &= ", @RESUMEN = " & 1 & vbCrLf
                Sql &= ", @CONDICION_FECHAS = " & 0 & vbCrLf
                Sql &= ", @FECHA_DESDE = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy 00:00:00") & "'" & vbCrLf
                Sql &= ", @FECHA_HASTA = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy 23:59:59") & "'" & vbCrLf
                Sql &= ", @TODAS_BODEGAS = " & 1 & vbCrLf
                Sql &= ", @BANDERA = " & 2

                Table = jClass.obtenerDatos(New SqlCommand(Sql))

                For Each dr As DataRow In Table.Rows
                    If (Len((Eliminar(dr(13)).ToString))) = 9 Then
                        ident = 3
                        NIT = (Eliminar(dr(13)).ToString).PadLeft(14, " ")
                    ElseIf (Len((Eliminar(dr(13)).ToString))) = 14 Then
                        ident = 1
                        NIT = (Eliminar(dr(13)).ToString).PadRight(14, " ")
                    ElseIf (Len((Eliminar(dr(13)).ToString))) = 13 Then
                        ident = 4
                        NIT = (Eliminar(dr(13)).ToString).PadLeft(14, " ")
                    End If

                    fec_cont = dr(7)
                    Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                    año = Year(fec_cont)
                    fecha = fec_cont.ToString("yyyyMMdd")
                    Tipo_doc = 6
                    num_doc = (dr(1).ToString).PadRight(20, " ")

                    Total = (Eliminar(Format(Math.Round((dr(5) / 1.13), 2), "0.00"))).PadLeft(11, "0")
                    IVA = (Eliminar(Format(Math.Round(((Math.Round((dr(5) / 1.13), 2)) * 0.13), 2), "0.00"))).PadLeft(11, "0")

                    'Total = (Eliminar(Format(Math.Round((dr(5) / 1.13), 2), "0.00"))).PadLeft(11, "0")
                    'IVA = (Eliminar(Format(Math.Round((((dr(5) / 1.13)) * 0.13), 2), "0.00"))).PadLeft(11, "0")

                    'sb.Append(Mes & ident & NIT & fecha & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)

                    sb.Append(Mes & ident & NIT & fecha & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)

                Next


                Sql = " Execute sp_FACTURACION_GENERADA_LIBROS_VENTAS_IVA " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @TIPO_DOCUMENTO = " & 2 & vbCrLf
                Sql &= ", @MONTH = " & 1 & vbCrLf
                Sql &= ", @RESUMEN = " & 1 & vbCrLf
                Sql &= ", @CONDICION_FECHAS = " & 0 & vbCrLf
                Sql &= ", @FECHA_DESDE = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy HH:mm:ss") & "'" & vbCrLf
                Sql &= ", @FECHA_HASTA = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy HH:mm:ss") & "'" & vbCrLf
                Sql &= ", @TODAS_BODEGAS = " & 1 & vbCrLf
                Sql &= ", @BANDERA = " & 0

                Table = jClass.obtenerDatos(New SqlCommand(Sql))

                For Each dr As DataRow In Table.Rows
                    If dr(28) = 0 And dr(8) <> 0 Then
                        Select Case dr(15).ToString
                            Case "ENERO"
                                Mes = "01"
                            Case "FEBRERO"
                                Mes = "02"
                            Case "MARZO"
                                Mes = "03"
                            Case "ABRIL"
                                Mes = "04"
                            Case "MAYO"
                                Mes = "05"
                            Case "JUNIO"
                                Mes = "06"
                            Case "JULIO"
                                Mes = "07"
                            Case "AGOSTO"
                                Mes = "08"
                            Case "SEPTIEMBRE"
                                Mes = "09"
                            Case "OCTUBRE"
                                Mes = "10"
                            Case "NOVIEMBRE"
                                Mes = "11"
                            Case Else
                                Mes = "12"
                        End Select
                        If dr(12) < 0 Then
                            Tipo_doc = 5
                        Else
                            Tipo_doc = 1
                        End If
                        dia = (dr(1).ToString).PadLeft(2, "0")
                        año = Year(fec_cont)
                        NRC = (Eliminar(dr(6)).ToString).PadRight(14, " ")
                        ident = 2
                        num_doc = (dr(3).ToString).PadRight(20, " ")
                        Total = (Eliminar(Format(Math.Round((dr(12) / 1.13), 2), "0.00"))).PadLeft(11, "0")
                        'IVA = (Eliminar(Format(Math.Round(dr(9), 2), "0.00"))).PadLeft(11, "0")
                        IVA = (Eliminar(Format(Math.Round(((Math.Round((dr(12) / 1.13), 2)) * 0.13), 2), "0.00"))).PadLeft(11, "0")

                        'sb.Append(Mes & ident & NRC & año & Mes & dia & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)
                        sb.Append(Mes & ident & NRC & año & Mes & dia & Tipo_doc & num_doc & Total & IVA & año + vbCrLf)
                    End If

                Next

            End If

            'INFORME DE RETENCIONES Y PERCEPCIONES
            'PERCEPCIONES PROVIENEN DEL LIBRO DE COMPRAS
            If Me.RdbRetencion.Checked = True Then
                Sql = "Execute sp_CONTABILIDAD_REPORTES_LIBRO_COMPRAS " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @BODEGA = " & 1 & vbCrLf
                Sql &= ", @FEC_INI = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy 00:00:01") & "'" & vbCrLf
                Sql &= ", @FEC_FIN = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy 23:59:59") & "'" & vbCrLf
                Sql &= ", @CONSOLI = " & 1 & vbCrLf
                Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
                Sql &= ", @BANDERA = " & 1

                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                Dim ident2 As Integer = 0
                Dim percepReten As String = ""
                For Each dr As DataRow In Table.Rows
                    If dr(13) <> 0 Then
                        'El nombre se guarda en la variable dirección
                        direccion = (Eliminar(dr(8).ToString).ToUpper).PadRight(40, " ")
                        If direccion.ToString.Length > 40 Then
                            direccion = direccion.Substring(1, 40)
                        End If

                        NIT = (Eliminar(dr(7).ToString)).PadLeft(14, "0")
                        ident = 1
                        If dr(20).ToString = "CCF" Then
                            Tipo_doc = 1
                        ElseIf dr(20).ToString = "NC" Then
                            Tipo_doc = 5
                        End If
                        ident2 = 1
                        num_doc = (Eliminar(dr(5).ToString)).PadRight(16, " ")
                        Total = (Eliminar(Format(dr(10), "0.00"))).PadLeft(15, "0")
                        percepReten = (Eliminar(Format(dr(13), "0.00"))).PadLeft(12, "0")
                        fec_cont = Me.fecha_Ini.Value
                        Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                        año = (Eliminar(Year(fec_cont).ToString))

                        sb.Append(direccion & NIT & ident & ident2 & Tipo_doc & num_doc & Total & percepReten & Mes & año + vbCrLf)
                    End If

                Next

                'RETENCIONES PROVIENEN DEL LIBRO DE VENTAS
                Sql = " Execute sp_FACTURACION_GENERADA_LIBROS_VENTAS_IVA " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @TIPO_DOCUMENTO = " & 2 & vbCrLf
                Sql &= ", @MONTH = " & 1 & vbCrLf
                Sql &= ", @RESUMEN = " & 1 & vbCrLf
                Sql &= ", @CONDICION_FECHAS = " & 0 & vbCrLf
                Sql &= ", @FECHA_DESDE = '" & Format(Me.fecha_Ini.Value, "dd-MM-yyyy HH:mm:ss") & "'" & vbCrLf
                Sql &= ", @FECHA_HASTA = '" & Format(Me.Fecha_Fin.Value, "dd-MM-yyyy HH:mm:ss") & "'" & vbCrLf
                Sql &= ", @TODAS_BODEGAS = " & 1 & vbCrLf
                Sql &= ", @BANDERA = " & 3

                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                For Each dr As DataRow In Table.Rows
                    If dr(11) > 0 Then
                        'El nombre se guarda en la variable dirección
                        direccion = (Eliminar(dr(5).ToString).ToUpper).PadRight(40, " ")
                        NIT = (Eliminar(dr(6).ToString)).PadLeft(14, "0")
                        ident = 1
                        Tipo_doc = 3
                        ident2 = 3
                        num_doc = (Eliminar(dr(31).ToString)).PadRight(16, " ")
                        percepReten = (Eliminar(Format(dr(11), "0.00"))).PadLeft(12, "0")
                        Total = (Eliminar(Format(Math.Round(dr(11) / 0.01, 2), "0.00"))).PadLeft(15, "0")
                        'Total = (Eliminar(Format(Math.Round(percepReten / 0.01, 2), "0.00"))).PadLeft(15, "0")
                        fec_cont = Me.fecha_Ini.Value
                        Mes = (Eliminar(Month(fec_cont).ToString)).PadLeft(2, "0")
                        año = (Eliminar(Year(fec_cont).ToString))

                        sb.Append(direccion & NIT & ident & ident2 & Tipo_doc & num_doc & Total & percepReten & Mes & año + vbCrLf)
                    End If

                Next

            End If

            Dim SaveFileDialog1 As New SaveFileDialog

            SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, sb.ToString, False, Encoding.Unicode)

            End If
            MessageBox.Show("Escritura realizada con éxito")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try

    End Sub

    Public Function Eliminar(ByVal numeroFormateado As String) As String

        Dim pattern As String = "[\.\-\,\'\""]"
        Dim replacement As String = String.Empty
        Dim regex As New System.Text.RegularExpressions.Regex(pattern)

        Return regex.Replace(numeroFormateado, replacement)

    End Function

    Private Sub Contabilidad_Informe_Compras_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.fecha_Ini.Value = Now.AddDays(-Now.Day).AddDays(1)

    End Sub

    Private Sub RdbRetencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbRetencion.CheckedChanged
        If Me.RdbRetencion.Checked = True Then
            Me.Rdbclientesmayor.Checked = False
            Me.Rdbclientesmenor.Checked = False
            Me.RdbExcluido.Checked = False
            Me.RdbPinscrito.Checked = False
            Me.Rdbexentos.Checked = False
        End If
    End Sub

    Private Sub RdbPinscrito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbPinscrito.CheckedChanged
        If Me.RdbPinscrito.Checked = True Then
            Me.RdbRetencion.Checked = False
        End If
    End Sub

    Private Sub RdbExcluido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbExcluido.CheckedChanged
        If Me.RdbExcluido.Checked = True Then
            Me.RdbRetencion.Checked = False
        End If
    End Sub

    Private Sub Rdbclientesmenor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdbclientesmenor.CheckedChanged
        If Me.Rdbclientesmenor.Checked = True Then
            Me.RdbRetencion.Checked = False
        End If
    End Sub

    Private Sub Rdbclientesmayor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdbclientesmayor.CheckedChanged
        If Me.Rdbclientesmayor.Checked = True Then
            Me.RdbRetencion.Checked = False
        End If
    End Sub

    Private Sub Contabilidad_Informe_Compras_Ventas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Rdbexentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdbexentos.CheckedChanged
        If Me.Rdbexentos.Checked = True Then
            Me.RdbRetencion.Checked = False
        End If
    End Sub
End Class