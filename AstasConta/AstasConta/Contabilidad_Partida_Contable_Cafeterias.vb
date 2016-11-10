Imports System.Data.SqlClient

Public Class Contabilidad_Partida_Contable_Cafeterias

    Dim jClass As New jarsClass
    Dim Sql As String
    Dim SqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim PorcIVA As Double
    Dim LibroC As Integer
    Dim Bodega As DataTable
    Dim iniciando As Boolean = True

    Private Sub Contabilidad_Partida_Contable_Cafeterias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PorcIVA = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 1 AND COMPA�IA = " & Compa�ia)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCajas()
        Me.dgvPartidas.AutoGenerateColumns = False
        LibroC = CInt(jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE_PRINCIPAL @COMPA�IA = " & Compa�ia))
        iniciando = False
        DatosBodega()
    End Sub

    Private Sub CargaCajas()
        Sql = "SELECT CAJA, RTRIM(DESCRIPCION) AS DESCRIPCION FROM CAFETERIA_CATALOGO_BODEGA_CAJA WHERE COMPA�IA = " & 1 & " ORDER BY CAJA"
        SqlCmd = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(SqlCmd)
        Me.cmbCajas.DataSource = Table
        Me.cmbCajas.ValueMember = "CAJA"
        Me.cmbCajas.DisplayMember = "DESCRIPCION"
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Me.Label6.Visible = True
        Dim sqlCmd As New SqlCommand
        Dim CtaContable As Integer = 0
        Dim NumPartida As Integer = 0
        Dim NumTran As Integer = 0
        Dim primerDoc, ultDoc As Integer
        Dim Linea, CtaCargoVtaCtdo, CtaAbono, CtaAbonoIVA As Integer
        Dim TotalFact, TotalFactCont, TotalIVAFact, SubTotalFact, SubTotalCont As Double
        Me.dgvPartidas.DataSource = Nothing
        Me.lblTransac.Text = ""
        Try
            If ValidaCierreContable(Compa�ia, LibroC, Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), "E") Then
                'Cr�dito
                Sql = "EXECUTE  [dbo].[sp_CAFETERIA_GENERAR_PARTIDAS]" & vbCrLf
                Sql &= "  @COMPA�IA = " & Compa�ia & vbCrLf
                Sql &= ", @FECHA_INICIAL = '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ", @CAJA = " & Me.cmbCajas.SelectedValue & vbCrLf
                Sql &= ", @BANDERA = 0"
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    NumPartida = Val(Me.txtPda.Text)
                    If NumPartida > 0 Then
                        NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & NumPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPA�IA = " & Compa�ia)
                        If NumTran = 0 Then
                            MsgBox("No se encontr� el n�mero de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                            Return
                        Else
                            If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPA�IA = " & Compa�ia) Then
                                MsgBox("Partida ya est� actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return
                            Else
                                If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & NumTran) > 0 Then
                                    If MsgBox("La partida No." & NumPartida & " tiene detalle, si contin�a el detalle se eliminar�." & vbCrLf & vbCrLf & "�Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                        jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & NumTran)
                                    Else
                                        MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                        Return
                                    End If
                                End If
                            End If
                        End If
                        'Concepto = "Facturaci�n al Cr�dito del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text
                        'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Partida & "' WHERE COMPA�IA = " & Compa�ia & " AND TRANSACCION = " & NumTran)
                    Else
                        NumTran = Me.GeneraCorrelativo(Compa�ia, "TRA", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                        NumPartida = Me.GeneraCorrelativo(Compa�ia, "PAR", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                        Mantenimiento_TransaccionE(Compa�ia, NumTran, LibroC, 1, "0", 2, NumPartida, Me.dpFechaContable.Value, "Facturaci�n Cafeter�as del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text & "(" & Bodega.Rows(0).Item("BODEGA") & ")", 0, 0, "I")
                    End If
                    Me.txtPda.Text = NumPartida.ToString()
                    Me.lblTransac.Text = NumTran.ToString()
                    Me.lblTransac2.Text = NumTran.ToString()
                    If Bodega.Rows(0).Item("PLANTA") = 1 Then
                        Sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPA�IA = " & Compa�ia & " AND CONSTANTE = 24"
                    Else
                        Sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPA�IA = " & Compa�ia & " AND CONSTANTE = 25"
                    End If
                    CtaContable = CInt(jClass.obtenerEscalar(Sql))
                    If Bodega.Rows(0).Item("PLANTA") = 1 Then
                        Sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPA�IA = " & Compa�ia & " AND CONSTANTE = 26"
                    Else
                        Sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPA�IA = " & Compa�ia & " AND CONSTANTE = 27"
                    End If
                    CtaCargoVtaCtdo = CInt(jClass.obtenerEscalar(Sql))
                    primerDoc = Table.Rows(0).Item("NUMERO_FACTURA")
                    CtaAbono = Table.Rows(0).Item("CTA_VENTA")
                    CtaAbonoIVA = Table.Rows(0).Item("CTA_IVA")
                    For Linea = 0 To Table.Rows.Count - 1
                        If primerDoc > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                            primerDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                        End If
                        If ultDoc < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                            ultDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                        End If
                        If Table.Rows(Linea).Item("FORMA_PAGO") = 2 Then
                            Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, Table.Rows(Linea).Item("CODIGO_EMPLEADO"), Table.Rows(Linea).Item("CTAXCOBRAR"), Table.Rows(Linea).Item("CONCEPTO").ToString(), "C", CDbl(Me.Table.Rows(Linea).Item("MONTO")), "E")
                            TotalFact += CDbl(Me.Table.Rows(Linea).Item("MONTO"))
                        Else
                            Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, Table.Rows(Linea).Item("CODIGO_EMPLEADO"), CtaCargoVtaCtdo, Table.Rows(Linea).Item("CONCEPTO"), "C", CDbl(Me.Table.Rows(Linea).Item("MONTO")), "E")
                            TotalFactCont += CDbl(Me.Table.Rows(Linea).Item("MONTO"))
                        End If
                    Next
                End If
                If NumTran > 0 Then
                    If TotalFact > 0 Then
                        'Venta Cr�dito
                        SubTotalFact = Math.Round(TotalFact / (1 + (Me.PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
                        TotalIVAFact = Math.Round(TotalFact - SubTotalFact, 2, MidpointRounding.AwayFromZero)
                        Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, 0, CtaAbono, "Vta.por Servicios de Alimentaci�n del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text & " (" & Bodega.Rows(0).Item("BODEGA") & ") Tickets del n�mero " & primerDoc & " al n�mero " & ultDoc, "A", SubTotalFact, "E")
                    End If
                    If TotalFactCont > 0 Then
                        'Venta Contado
                        SubTotalCont = Math.Round(TotalFactCont / (1 + (Me.PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
                        TotalIVAFact += Math.Round(TotalFactCont - SubTotalCont, 2, MidpointRounding.AwayFromZero)
                        Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, 0, CtaContable, "Vta.por Servicios de Alimentaci�n del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text & " (" & Bodega.Rows(0).Item("BODEGA") & ")", "A", SubTotalCont, "E")
                    End If
                    'IVA
                    Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "IVA por Servicios de Alimentaci�n del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text & " (" & Bodega.Rows(0).Item("BODEGA") & ")", "A", TotalIVAFact, "E")
                    'Generar Resumen
                    Mantenimiento_TransaccionL(Compa�ia, LibroC, NumTran, Linea, 1, 0, "Facturaci�n por Servicios de Alimentaci�n del D�a " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbCajas.Text & " (" & Bodega.Rows(0).Item("BODEGA") & ") Tickets del n�mero " & primerDoc & " al n�mero " & ultDoc, "C", 0, "A")
                    'Actualizar las facturas con el numero de partida generado
                    Sql = "UPDATE CAFETERIA_FACTURACION_ENCABEZADO " & vbCrLf
                    Sql &= "   SET PARTIDA = " & NumPartida & ", TRANSACCION = " & NumTran & ", CONTABILIZADO = 1" & vbCrLf
                    Sql &= " WHERE TIPO_DOCUMENTO = 27" & vbCrLf
                    Sql &= "   AND COMPA�IA = " & Compa�ia & vbCrLf
                    Sql &= "   AND CONVERT(DATE, FECHA_FACTURA) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
                    Sql &= "   AND CAJA = " & Me.cmbCajas.SelectedValue & vbCrLf
                    Sql &= "   AND ANULADO = 0"
                    Sql &= "   AND CONTABILIZADO = 0"
                    Linea = jClass.ejecutarComandoSql(New SqlCommand(Sql))
                    CargaPartida_Detalle(Compa�ia, LibroC, NumTran, 6)
                End If
                If Val(Me.lblTransac.Text) > 0 Then
                    MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Partida Facturaci�n")
                Else
                    MsgBox("No se gener� Partida para la fecha seleccionada." & vbCrLf & vbCrLf & "No hay datos de facturacion o partida ya fue generada.", MsgBoxStyle.Information, "Partida Facturaci�n")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Partida Facturas")
        End Try
        Me.Label6.Visible = False
    End Sub

    Private Sub Mantenimiento_TransaccionL(ByVal Compa�ia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPA�IA       = " & Compa�ia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LINEA          = " & Linea & vbCrLf
            Sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            Sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            Sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_TransaccionE(ByVal Compa�ia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            Sql &= " @COMPA�IA       = " & Compa�ia & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            Sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            Sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            Sql &= ",@PARTIDA        = " & Partida & vbCrLf
            Sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@ANULADA        = " & Anulada & vbCrLf
            Sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            'Select Case IUD
            '    Case "I"
            '        MsgBox("�Transacci�n Almacenada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            '    Case "U"
            '        MsgBox("�Transacci�n Actualizada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            '    Case "D"
            '        MsgBox("�Transacci�n Eliminada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            'End Select
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

    Private Function GeneraCorrelativo(ByVal Compa�ia, ByVal TipoDocumento, ByVal A�o, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            Sql &= " @COMPA�IA       = " & Compa�ia & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            Sql &= ",@A�O            = " & A�o & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@ULTIMO         = 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("ULTIMO")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub CargaPartida_Detalle(ByVal Compa�ia, ByVal Libro, ByVal Transaccion, ByVal Bandera)
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

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged
        Me.txtPda.Text = "0"
        Me.dgvPartidas.DataSource = Nothing
        If Not iniciando Then
            DatosBodega()
        End If
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Val(Me.lblTransac.Text) > 0 Then
            Dim rpts As New frmReportes_Ver
            rpts.CargaPartida(Compa�ia, LibroC, Me.lblTransac.Text, Me.lblTransac2.Text, Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), 1)
            rpts.ShowDialog()
        Else
            MsgBox("N�mero de Partida inv�lido", MsgBoxStyle.Critical, "Impresi�n")
        End If
    End Sub

    Private Sub Contabilidad_Partida_Contable_Cafeterias_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub DatosBodega()
        Sql = "SELECT TOP 1 B.DESCRIPCION_BODEGA AS BODEGA, C.PLANTA"
        Sql &= "  FROM INVENTARIOS_CATALOGO_BODEGAS B, CAFETERIA_CATALOGO_BODEGA_CAJA C"
        Sql &= " WHERE B.COMPA�IA = C.COMPA�IA"
        Sql &= "   AND B.BODEGA = C.BODEGA "
        Sql &= "   AND C.COMPA�IA = " & Compa�ia
        Sql &= "   AND C.CAJA = " & Me.cmbCajas.SelectedValue
        Bodega = jClass.obtenerDatos(New SqlCommand(Sql))
        Me.txtBodega.Text = Bodega.Rows(0).Item("BODEGA").ToString()
    End Sub
End Class