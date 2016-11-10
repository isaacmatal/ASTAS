Imports System.Data.SqlClient

Public Class Contabilidad_Partida_Costeo_Cafeteria
    Dim Sql As String
    Dim SqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass

    Private Sub Contabilidad_Partida_Costeo_Cafeteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        ' llenado de bodegas
        'llenarBodegas()
    End Sub

    'Private Sub llenarBodegas()
    '    Sql = "Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compañia & ", 0, '" & Usuario & "'"
    '    SqlCmd = New SqlCommand(Sql)
    '    Table = jClass.obtenerDatos(SqlCmd)
    '    Me.cmbBodega.DataSource = Table
    '    Me.cmbBodega.ValueMember = "BODEGA"
    '    Me.cmbBodega.DisplayMember = "DESCRIPCION_BODEGA"
    'End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If MsgBox("¿Desea generar partida de costeo diario?", MsgBoxStyle.YesNo, "PARTIDA DE COSTOS") = MsgBoxResult.Yes Then
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
            Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
            If ValidaCierreContable(Compañia, Libro, Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month, "E") Then
                'Sql = "SELECT MAX(BODEGA) AS BODEGA, MAX(DESCRIPCION_BODEGA) AS DESC_BODEGA,ISNULL(SUM(MONTO),0.0) AS MONTO, ISNULL(SUM(COSTO),0.0) AS COSTO, MAX(CUENTA_CONTABLE_INVENTARIO) AS CTAINV, MAX(CUENTA_CONTABLE_COSTO_VENTAS) AS CTACOSTO, ISNULL(MAX(CENTRO_COSTO),0) AS CENTRO_COSTO FROM " & vbCrLf
                'Sql &= "(SELECT F.BODEGA, B.DESCRIPCION_BODEGA, F.CODIGO_EMPLEADO, F.TIPO_MOVIMIENTO, F.MOVIMIENTO, CONVERT(NUMERIC(10,2),F.MONTO) AS MONTO, B.CUENTA_CONTABLE_INVENTARIO, B.CUENTA_CONTABLE_COSTO_VENTAS, CENTRO_COSTO" & vbCrLf
                'Sql &= "      ,ROUND((SELECT ISNULL(SUM(COSTO_TOTAL),0) FROM INVENTARIOS_MOVIMIENTOS_DETALLE WHERE  F.COMPAÑIA = COMPAÑIA AND F.BODEGA = BODEGA AND F.TIPO_MOVIMIENTO = TIPO_MOVIMIENTO AND F.MOVIMIENTO = MOVIMIENTO),2) AS COSTO" & vbCrLf
                'Sql &= "FROM CAFETERIA_FACTURACION_ENCABEZADO F, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
                'Sql &= "WHERE F.COMPAÑIA = B.COMPAÑIA AND F.BODEGA = B.BODEGA" & vbCrLf
                'Sql &= "  AND CONVERT(DATE, F.FECHA_FACTURA) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103)) A GROUP BY BODEGA" '& vbCrLf
                'Sql &= "  AND F.BODEGA = 42) A GROUP BY BODEGA"

                'Sql = "SELECT BODEGA, DESC_BODEGA, 0.0 AS MONTO, SUM(COSTO_TOTAL) AS COSTO, MAX(CUENTA_CONTABLE_INVENTARIO) AS CTAINV, MAX(CUENTA_CONTABLE_COSTO_VENTAS) AS CTACOSTO, ISNULL(MAX(CENTRO_COSTO),0) AS CENTRO_COSTO" & vbCrLf
                'Sql &= "FROM (SELECT M.BODEGA, B.DESCRIPCION_BODEGA AS DESC_BODEGA, M.PRODUCTO, ROUND(SUM(M.COSTO_TOTAL),2) AS COSTO_TOTAL, MAX(B.CUENTA_CONTABLE_INVENTARIO) AS CUENTA_CONTABLE_INVENTARIO, MAX(B.CUENTA_CONTABLE_COSTO_VENTAS) AS CUENTA_CONTABLE_COSTO_VENTAS, ISNULL(MAX(B.CENTRO_COSTO),0) AS CENTRO_COSTO" & vbCrLf
                'Sql &= "	    FROM INVENTARIOS_MOVIMIENTOS_DETALLE M, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
                'Sql &= "	   WHERE M.COMPAÑIA = B.COMPAÑIA AND M.BODEGA = B.BODEGA " & vbCrLf
                'Sql &= "	     AND CONVERT(DATE,M.FECHA_MOVIMIENTO) = CONVERT(DATE,'" & Format(Fecha, "dd/MM/yyyy") & "',103) " & vbCrLf
                'Sql &= "	     AND M.TIPO_MOVIMIENTO = 2" & vbCrLf
                'Sql &= "	     AND M.ANULADO = 0" & vbCrLf
                'Sql &= "	     AND M.PROCESADO = 1" & vbCrLf
                'Sql &= "	     AND M.COMPAÑIA = " & Compañia & vbCrLf
                'Sql &= "	   GROUP BY M.BODEGA, B.DESCRIPCION_BODEGA, M.PRODUCTO) A" & vbCrLf
                'Sql &= " GROUP BY BODEGA, DESC_BODEGA"

                Sql = "EXECUTE [dbo].[sp_INVENTARIOS_VERIFICAR_EXISTENCIAS] " & vbCrLf
                Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ",@FECHA = '" & Format(Fecha, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ",@BANDERA = 2" & vbCrLf
                SqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(SqlCmd)
                If Table.Rows.Count > 0 Then
                    Concepto = "Costo de Ventas del " & Format(Fecha, "dd/MM/yyyy") & " de Cafetería"
                    Partida = Val(Me.txtPartida.Text)
                    If Partida > 0 Then
                        Transaccion = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPAÑIA = " & Compañia)
                        If Transaccion = 0 Then
                            MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                            Return
                        Else
                            If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & Transaccion & " AND COMPAÑIA = " & Compañia) Then
                                MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return
                            Else
                                If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
                                    If MsgBox("La partida No." & Partida & " tiene detalle, si continúa el detalle se eliminará." & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                        jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                                    Else
                                        MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                        Return
                                    End If
                                End If
                            End If
                        End If
                        jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                    Else
                        Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & Fecha.Year & ", @MES = " & Fecha.Month & ", @ULTIMO = 0")
                        jClass.EncabezadoPartida(Transaccion, 2, 7, "0", Fecha, Libro, Concepto, 0, 0, "I")
                        Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                    End If
                    For Each Row As DataRow In Table.Rows
                        CentCosto = Row.Item("CENTRO_COSTO")
                        CtaCargada = Row.Item("CTACOSTO")
                        CtaAbonada = Row.Item("CTAINV")
                        CostoVenta = Row.Item("COSTO")
                        Concepto = "Costo de Ventas de Cafeterías del " & Fecha.ToShortDateString & ", " & Row.Item("DESC_BODEGA")
                        jClass.DetallePartida(Transaccion, 0, 0, Fecha, Libro, Concepto, CtaCargada, "C", CostoVenta, 0, "E")
                        jClass.DetallePartida(Transaccion, 0, 0, Fecha, Libro, Concepto, CtaAbonada, "A", 0, CostoVenta, "E")
                        i += 1
                    Next
                    jClass.DetallePartida(Transaccion, 0, 1, Fecha, Libro, "Concepto", 0, "X", 0, 0, "A")
                    Me.txtPartida.Text = Partida
                    Me.txtLibroContable.Text = Libro
                    Me.Txt_Transaccion.Text = Transaccion
                    Me.CargaPartida_Detalle(Compañia, Libro, Transaccion, 6)
                    'SqlCmd.CommandText = "EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPAÑIA = " & Compañia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'"
                    'jClass.ejecutarComandoSql(SqlCmd)
                Else
                    MessageBox.Show("No se encuentran movimientos para la fecha seleccionada.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Partida Costeo Diario.")
        End Try
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If MsgBox("Emitir Impresa la partida generada?.", MsgBoxStyle.YesNo, "IMPRIME PARTIDA") = MsgBoxResult.Yes Then
            Rpts.CargaPartida(Compañia, Val(Me.txtLibroContable.Text), Val(Me.Txt_Transaccion.Text), Val(Me.Txt_Transaccion.Text), Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), 1)
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub txtPartida_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub CargaPartida_Detalle(ByVal Compañia As Integer, ByVal Libro As Integer, ByVal Transaccion As Integer, ByVal Bandera As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
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

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
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

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO = " & Año & vbCrLf
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
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
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

    Private Sub Contabilidad_Partida_Costeo_Cafeteria_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    'Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
    '    Me.txtPartida.Clear()
    '    While Me.dgvPartidas.Rows.Count > 0
    '        Me.dgvPartidas.Rows.RemoveAt(0)
    '    End While
    'End Sub
End Class