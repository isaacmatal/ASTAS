Imports System.Data.SqlClient

Public Class Contabilidad_Partida_Costeo_Diario
    Dim Sql As String
    Dim SqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass

    Private Sub Contabilidad_Partida_Costeo_Diario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        ' llenado de bodegas
        llenarBodegas()
    End Sub

    Private Sub llenarBodegas()
        Sql = "Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compa�ia & ", 0, '" & Usuario & "'"
        SqlCmd = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(SqlCmd)
        Me.cmbBodega.DataSource = Table
        Me.cmbBodega.ValueMember = "BODEGA"
        Me.cmbBodega.DisplayMember = "DESCRIPCION_BODEGA"
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If MsgBox("�Desea generar partida de costeo diario?", MsgBoxStyle.YesNo, "PARTIDA DE COSTOS") = MsgBoxResult.Yes Then
            Partida_Contable()
        End If
    End Sub

    Private Sub Partida_Contable()
        Dim Concepto As String
        Dim CtaAbonada, CtaCargada, Libro, Transaccion, Partida, i As Integer
        Dim CentCosto As Integer
        Dim Fecha As DateTime = Me.dpFechaContable.Value
        Dim NumPartida As String = String.Empty
        Dim CostoVenta As Double
        Try
            Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPA�IA = " & Compa�ia & " AND LIBRO_PRINCIPAL = 1")
            If ValidaCierreContable(Compa�ia, Libro, Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month, "E") Then
                Sql = "EXECUTE [sp_INVENTARIOS_MOVIMIENTO_SIUD] @COMPA�IA = " & Compa�ia & ", @BODEGA = " & Me.cmbBodega.SelectedValue & ", @FECHA_MOVIMIENTO = '" & Me.dpFechaContable.Text & "', @SIUD = 'COSTEOXBODEGA'"
                SqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(SqlCmd)
                If Table.Rows.Count > 0 Then
                    Concepto = "Costo de Ventas del " & Fecha.ToShortDateString & " de " & Me.cmbBodega.Text
                    Partida = Val(Me.txtPartida.Text)
                    If Partida > 0 Then
                        Transaccion = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPA�IA = " & Compa�ia)
                        If Transaccion = 0 Then
                            MsgBox("No se encontr� el n�mero de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                            Return
                        Else
                            If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & Transaccion & " AND COMPA�IA = " & Compa�ia) Then
                                MsgBox("Partida ya est� actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return
                            Else
                                If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & Transaccion) > 0 Then
                                    If MsgBox("La partida No." & Partida & " tiene detalle, si contin�a el detalle se eliminar�." & "�Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                        jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & Transaccion)
                                    Else
                                        MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                        Return
                                    End If
                                End If
                            End If
                        End If
                        jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Concepto & "' WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & Transaccion)
                    Else
                        Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPA�IA = " & Compa�ia & ", @TIPO_DOCUMENTO = 'TRA', @A�O = " & Fecha.Year & ", @MES = " & Fecha.Month & ", @ULTIMO = 0")
                        jClass.EncabezadoPartida(Transaccion, 2, 7, "0", Fecha, Libro, Concepto, 0, 0, "I")
                        Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & Transaccion)
                    End If
                    For Each Row As DataRow In Table.Rows
                        CentCosto = Row.Item("CENTRO_COSTO")
                        CtaCargada = Row.Item("CUENTA_CONTABLE_COSTO_VENTAS")
                        CtaAbonada = Row.Item("CUENTA_CONTABLE_INVENTARIO")
                        CostoVenta = Row.Item("COSTO_TOTAL")
                        Concepto = "Costo de Ventas " & Row.Item("DESCRIPCION_BODEGA") & " del " & Fecha.ToShortDateString
                        jClass.DetallePartida(Transaccion, 0, CentCosto, Fecha, Libro, Concepto, CtaCargada, "C", CostoVenta, 0, "I")
                        jClass.DetallePartida(Transaccion, 0, 0, Fecha, Libro, Concepto, CtaCargada, "C", CostoVenta, 0, "E")
                        jClass.DetallePartida(Transaccion, 0, CentCosto, Fecha, Libro, Concepto, CtaAbonada, "A", 0, CostoVenta, "I")
                        jClass.DetallePartida(Transaccion, 0, 0, Fecha, Libro, Concepto, CtaAbonada, "A", 0, CostoVenta, "E")
                        i += 1
                    Next

                    Me.txtPartida.Text = Partida
                    Me.txtLibroContable.Text = Libro
                    Me.Txt_Transaccion.Text = Transaccion
                    Me.CargaPartida_Detalle(Compa�ia, Libro, Transaccion, 6)
                    'SqlCmd.CommandText = "EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPA�IA = " & Compa�ia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'"
                    'jClass.ejecutarComandoSql(SqlCmd)
                Else
                    MessageBox.Show("No se encuentran movimientos para la fecha y bodega seleccionada. Es posible que ya se halla generado la partida con anterioridad.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Partida Costeo Diario.")
        End Try
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If MsgBox("Emitir Impresa la partida generada?.", MsgBoxStyle.YesNo, "IMPRIME PARTIDA") = MsgBoxResult.Yes Then
            Rpts.CargaPartida(Compa�ia, Val(Me.txtLibroContable.Text), Val(Me.Txt_Transaccion.Text), Val(Me.Txt_Transaccion.Text), Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), 1)
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub txtPartida_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub CargaPartida_Detalle(ByVal Compa�ia As Integer, ByVal Libro As Integer, ByVal Transaccion As Integer, ByVal Bandera As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPA�IA       = " & Compa�ia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@BANDERA        = " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPartidas.DataSource = Table
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCierreContablePermisos(ByVal Compa�ia As Integer, ByVal LC As Integer, ByVal A�o As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPA�IA       = " & Compa�ia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@A�O            = " & A�o & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            Sql &= ",@PROCESADO      = 0" & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function ValidaCierreContable(ByVal Compa�ia As Integer, ByVal LC As Integer, ByVal A�o As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPA�IA = " & Compa�ia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@A�O = " & A�o & vbCrLf
            Sql &= ",@MES = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            Sql &= ",@PROCESADO = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") = True Then
                    MsgBox("�El Per�odo Contable ya est� CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacci�n.", MsgBoxStyle.Critical, "Validaci�n")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("�El Per�odo Contable ya est� en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacci�n. Verifique la Fecha Contable y comun�quese con el Contador General.", MsgBoxStyle.Critical, "Validaci�n")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compa�ia, LC, A�o, Mes, "L") = False Then
                        MsgBox("!El Per�odo Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podr� registrar partidas en dicho per�odo. Verifique la Fecha Contable y comun�quese con el Contador General.", MsgBoxStyle.Critical, "Validaci�n")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("�No existe el Per�odo Contable! Llame al Contador General" & vbCrLf & "No podr� registrar partidas en dicho per�odo.", MsgBoxStyle.Critical, "Validaci�n")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub dpFechaContable_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaContable.ValueChanged
        Me.txtPartida.Clear()
        While Me.dgvPartidas.Rows.Count > 0
            Me.dgvPartidas.Rows.RemoveAt(0)
        End While
    End Sub

    Private Sub Contabilidad_Partida_Costeo_Diario_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
        Me.txtPartida.Clear()
        While Me.dgvPartidas.Rows.Count > 0
            Me.dgvPartidas.Rows.RemoveAt(0)
        End While
    End Sub
End Class