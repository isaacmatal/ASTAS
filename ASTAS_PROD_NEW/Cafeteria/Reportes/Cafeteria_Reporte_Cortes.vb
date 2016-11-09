Imports System.Data.SqlClient

Public Class Cafeteria_Reporte_Cortes
    Dim dr_ As DataRow
    Dim Table_ As DataTable
    Dim comandos As New jarsClass
    Dim Iniciando As Boolean
    Dim Iniciando2 As Boolean
    Dim bodega_ataf As Integer = 82
    'VARIABLES NECESARIAS
    Dim VentaBruta As Double = 0.0
    Dim Efectivo As Double = 0.0
    Dim Credito As Double = 0.0
    Dim Descuentos As Double = 0.0
    Dim Resolucion As String, fecha_resolucion As String, fecha_autorizacion As String, del As String, al As String, descripcion_bodega As String
    Dim Movimiento As String, PRODUCTO As String, item As String, serie As String, fecha_aprovacion As String, tiempo_c As String, correlativo_Actual As String
    Private Sub Cafeteria_Reporte_Cortes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        bodega_ataf = comandos.leerDataeader("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE=29", 0)
        'LLENA EL COMBO DE BODEGAS
        comandos.CargaBodegas(Compañia, Me.cmbBODEGA, 9)
        If Me.cmbBODEGA.SelectedIndex <> -1 Then
            cargarCajas()
        End If
        If Me.cmbCajas.SelectedValue <> Nothing Then
            If cmbBODEGA.SelectedValue = bodega_ataf Then
                comandos.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'W'," & cmbCajas.SelectedValue, "Tiempo de Comida", "Descripción")
                Label2.Text = "ASOCIACION DE TRABAJADORES DE AVICOLA SALVADOREÑA Y FILIALES"
            Else
                comandos.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'S'," & Me.cmbCajas.SelectedValue, "Tiempo de Comida", "Descripción")
                Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
            End If
        End If

        Iniciando = False
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            If Me.cmbCajas.SelectedValue <> Nothing Then
                If cmbBODEGA.SelectedValue = bodega_ataf Then
                    comandos.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'W'," & Me.cmbCajas.SelectedValue, "Tiempo de Comida", "Descripción")
                    Label2.Text = "ASOCIACION DE TRABAJADORES DE AVICOLA SALVADOREÑA Y FILIALES"
                Else
                    comandos.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'S'," & Me.cmbCajas.SelectedValue, "Tiempo de Comida", "Descripción")
                    Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
                End If
            End If
            Iniciando2 = False
        End If
    End Sub

    Public Sub cargarCajas()
        Dim a As String = comandos.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BANDERA=4, @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La cafeteria no tiene caja asignada", MsgBoxStyle.Information)
        Else
            comandos.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If
    End Sub

    Private Function ValidarCampos() As Boolean
        If cmbCajas.SelectedIndex = -1 Then
            MsgBox("Favor seleccionar una caja", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub btnImprimirCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirCorte.Click
        If ValidarCampos() Then
            If MsgBox("¿Desea reimprimir el Corte?", MsgBoxStyle.YesNo, "Reimpresion de Corte") = MsgBoxResult.Yes Then
                ImprimirTicket()
            End If
        End If
    End Sub
    Private Sub ImprimirTicketSIMP()
        'CARGAR DATOS DEL CORTE
        Dim ds As New DataSet
        ds = DevolverDataSet()

        'ACCEDER A LAS DOS DATATABLE
        Dim tbl As New DataTable
        tbl = ds.Tables(0)

        Dim tbl2 As New DataTable
        tbl2 = ds.Tables(1)

        If (tbl.Rows.Count = 0) Then
            MsgBox("Aviso...NO HAY DATOS QUE MOSTRAR", MsgBoxStyle.Information)
            Exit Sub
        End If
        'PREPARAMOS VARIABLES
        VentaBruta = 0.0
        Efectivo = 0.0
        Credito = 0.0
        Descuentos = 0.0

        'GENERAMOS EL TICKET
        Dim ticket As New GenerarTicket
        ticket.AbrirArchivo()

        'DIRECCION CAJA
        ticket.EscribirTicket(tbl2.Rows(0).Item(4).ToString().Trim() & " " & tbl2.Rows(0).Item(5).ToString().Trim())

        If Not rbCorteZZ.Checked Then
            CortesX_Z(ticket, tbl, tbl2)
            Return
        End If

        ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(7).ToString()) 'NUMERO DE TICKET
        ticket.EscribirTicket("FECHA: " & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & " " & Date.Now.ToShortTimeString)
        ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket("CORTE PARCIAL ZZ")
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("Resolucion: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 0))
        ticket.EscribirTicket("Fecha de Resolucion: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 1))
        ticket.EscribirTicket("Autorizada: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 2))
        ticket.EscribirTicket("Del: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 3))
        ticket.EscribirTicket("Al: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 4))
        ticket.EscribirTicket("=======================================")
        VentaBruta = FormatNumber(tbl.Rows(0).Item(0), 2)
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS          0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS       0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString().PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL VENTAS " & VentaBruta.ToString().PadLeft(23, " "))
        ticket.EscribirTicket("TICKETS EMITIDOS")
        ticket.EscribirTicket("INICIAL " & tbl.Rows(0).Item(6).ToString().Trim().PadLeft(25))
        ticket.EscribirTicket("FINAL " & tbl.Rows(0).Item(7).ToString().Trim().PadLeft(25))

        Dim DEVOLUCIONES As String = tbl.Rows(0).Item(1).ToString()

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS          0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS       0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS -" & Val(DEVOLUCIONES).ToString().PadLeft(11, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES -" & Val(DEVOLUCIONES).ToString().PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS          0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS       0.00")

        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString().PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES " & Val(DEVOLUCIONES).ToString().PadLeft(15, " ")) 'TOTAL DEPOSITAR
        ticket.EscribirTicket("VENTA TOTAL " & (VentaBruta - Val(DEVOLUCIONES)).ToString().PadLeft(24, " ")) 'TOTAL DEPOSITAR
        ticket.CerrarArchivoSinImprimir()
        MsgBox("Corte ZZ exportado exitosamente a .txt (Mis Documentos)", MsgBoxStyle.Information, "Reimpresion de Cortes")
        'ticket.ImprimirTicket()
    End Sub

    Private Sub ImprimirTicket()
        'CARGAR DATOS DEL CORTE
        Dim ds As New DataSet
        ds = DevolverDataSet()

        'ACCEDER A LAS DOS DATATABLE
        Dim tbl As New DataTable
        tbl = ds.Tables(0)

        Dim tbl2 As New DataTable
        tbl2 = ds.Tables(1)

        'PREPARAMOS VARIABLES
        VentaBruta = 0.0
        Efectivo = 0.0
        Credito = 0.0
        Descuentos = 0.0

        'GENERAMOS EL TICKET
        Dim ticket As New GenerarTicket
        ticket.AbrirArchivo()

        'DIRECCION CAJA
        ticket.EscribirTicket(tbl2.Rows(0).Item(4).ToString().Trim() & " " & tbl2.Rows(0).Item(5).ToString().Trim())
        'Dim reso
        Dim tbl_corr_ As DataTable
        tbl_corr_ = DevolverTablaCorrela()

        If Not rbCorteZZ.Checked Then
            CortesX_Z(ticket, tbl, tbl2)
            Return
        End If

        'Dim resolucion_ As String = comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 0)
        Dim resolucion_ As String
        Dim index_ As Integer = tbl_corr_.Rows.Count - 1
        resolucion_ = tbl_corr_.Rows(index_).Item("RESOLUCION").ToString().Trim()

        'ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(8).ToString().Trim()) 'NUMERO DE TICKET


        For Each dr_ In tbl_corr_.Rows
            If dr_("RESOLUCION").ToString().Trim().Equals(resolucion_.Trim()) Then
                If Date.DaysInMonth(dtpFechaInicioTrabajo.Value.Year, dtpFechaInicioTrabajo.Value.Month) = dtpFechaInicioTrabajo.Value.Day Then
                    ticket.EscribirTicket("TICKET # " & (Val(dr_("TICKET_FINAL").ToString()) - IIf(rbCorteZZ.Checked, 0, 1)).ToString()) 'NUMERO DE TICKET
                    Exit For
                Else
                    'SI ES DIA CON DIA
                    ticket.EscribirTicket("TICKET # " & (Val(dr_("TICKET_FINAL").ToString()))) 'NUMERO DE TICKET
                    Exit For
                End If
            End If
        Next dr_
        ticket.EscribirTicket("FECHA: " & Format(tbl_corr_.Rows(0).Item("FECHATKT"), "dd/MM/yyyy h:mm:ss:tt")) 'dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy"))
        ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket("CORTE PARCIAL ZZ")
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("RESOLUCION: " & resolucion_)
        ticket.EscribirTicket("FECHA DE RESOLUCION: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 1)), "dd/MM/yyyy"))
        ticket.EscribirTicket("AUTORIZADA: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 2)), "dd/MM/yyyy"))
        ticket.EscribirTicket("DEL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 3).ToString().PadLeft(6, "0"))
        ticket.EscribirTicket("AL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 4).ToString().PadLeft(6, "0"))
        ticket.EscribirTicket("=======================================")
        VentaBruta = FormatNumber(tbl.Rows(0).Item(1), 2)
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS   " & (0.0).ToString("#,##0.00").PadLeft(13, " "))
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS" & (0.0).ToString("#,##0.00").PadLeft(13, " "))
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS  " & VentaBruta.ToString("#,##0.00").PadLeft(13, " "))
        ticket.EscribirTicket("TOTAL VENTAS           " & VentaBruta.ToString("#,##0.00").PadLeft(13, " "))
        ticket.EscribirTicket("TICKETS EMITIDOS")

        Dim dr As DataRow
        For Each dr In tbl_corr_.Rows
            ticket.EscribirTicket("RESOLUCION " & dr("RESOLUCION").ToString().Trim())
            ticket.EscribirTicket("INICIAL " & dr("TICKET_INICIAL").ToString().Trim().PadLeft(22))
            ticket.EscribirTicket("FINAL   " & dr("TICKET_FINAL").ToString().Trim().PadLeft(22))
        Next dr

        Dim DEVOLUCIONES As String

        DEVOLUCIONES = IIf(Val(tbl.Rows(0).Item(2)) > 0, -1, 1) * Val(tbl.Rows(0).Item(2))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")

        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString("#,##0.00").PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " ")) 'TOTAL ANULACIONES
        ticket.EscribirTicket("VENTA TOTAL           " & (VentaBruta + Val(DEVOLUCIONES)).ToString("#,##0.00").PadLeft(14, " ")) 'TOTAL NETO
        ticket.CerrarArchivo2()

        MsgBox("Corte ZZ reimpreso exitosamente", MsgBoxStyle.Information, "Reimpresion de Cortes")
        'ticket.ImprimirTicket()
    End Sub

    Private Function DevolverTablaCorrela() As DataTable
        Dim Sql_ As String
        Sql_ = "EXEC sp_CAFETERIA_CORTE_CORRELATIVOS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ",@FECHA= '" & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        If rbCorteX.Checked Then
            Sql_ += ", @TIEMPO=" & cbTiempoComida.SelectedValue
            Sql_ += ", @TIPO_CORTE='X'"
        End If
        If rbCorteZ.Checked Then
            Sql_ += ",@TIPO_CORTE='Z'"
        End If
        If rbCorteZZ.Checked Then
            Sql_ += ",@TIPO_CORTE='ZZ'"
        End If

        Try
            Table_ = comandos.obtenerDatos(New SqlCommand(Sql_))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try

        If (Table_.Rows.Count = 0) Then
            MsgBox("Aviso...NO HAY DATOS QUE MOSTRAR", MsgBoxStyle.Information)
        End If
        Return Table_
    End Function

    Private Sub CortesX_Z(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable)
        'TODO CORTE X        
        Dim tbl_corr_ As New DataTable
        tbl_corr_ = DevolverTablaCorrela()

        If rbCorteX.Checked Then
            If tbl.Rows(0).Item(7).ToString = "" Then
                Label5.Visible = True
                ticket.CerrarArchivoSinImprimir()
                Exit Sub
            Else
                Label5.Visible = False
            End If

            'EVALUA POR CADA TIEMPO DE COMIDA, POR SER CORTE X
            If cbTiempoComida.SelectedValue = 5 Then
                'EVALUA EL FIN DE MES
                If Date.DaysInMonth(dtpFechaInicioTrabajo.Value.Year, dtpFechaInicioTrabajo.Value.Month) = dtpFechaInicioTrabajo.Value.Day Then
                    ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(7).ToString() - 2) 'NUMERO DE TICKET
                Else
                    'EVALUA EL DIA A DIA
                    ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(7).ToString() - 1) 'NUMERO DE TICKET
                End If
            Else
                'EVALUA CADA TIEMPO
                ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(7).ToString().Trim()) 'NUMERO DE TICKET
            End If

            Dim resolucion_ As String
            Dim index_ As Integer = tbl_corr_.Rows.Count - 1
            resolucion_ = tbl_corr_.Rows(index_).Item("RESOLUCION").ToString().Trim()

            ticket.EscribirTicket("FECHA: " & Format(tbl_corr_.Rows(0).Item("FECHATKT"), "dd/MM/yyyy h:mm:ss tt")) ' & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & " " & Date.Now.ToShortTimeString)
            ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
            ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
            ticket.EscribirTicket("CORTE PARCIAL X")
            ticket.EscribirTicket("=======================================")
            'ticket.EscribirTicket("Resolucion: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 0))
            ticket.EscribirTicket("RESOLUCION: " & resolucion_)
            ticket.EscribirTicket("FECHA DE RESOLUCION: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 1)), "dd/MM/yyyy"))
            ticket.EscribirTicket("AUTORIZADA: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 2)), "dd/MM/yyyy"))
            ticket.EscribirTicket("DEL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 3).ToString().PadLeft(6, "0"))
            ticket.EscribirTicket("AL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 4).ToString().PadLeft(6, "0"))
            ticket.EscribirTicket("=======================================")

            For i As Integer = 0 To tbl.Rows.Count - 1
                VentaBruta += tbl.Rows(i).Item(1)
                Efectivo += tbl.Rows(i).Item(2)
                Credito += tbl.Rows(i).Item(3)
                Descuentos += tbl.Rows(i).Item(4)
            Next
            ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
            ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
            ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString("#,##0.00").PadLeft(14, " "))
            ticket.EscribirTicket("TOTAL VENTAS          " & VentaBruta.ToString("#,##0.00").PadLeft(14, " "))
            ticket.EscribirTicket("TICKETS EMITIDOS")
            '============================================================================  
            Dim dr As DataRow
            For Each dr In tbl_corr_.Rows
                ticket.EscribirTicket("RESOLUCION " & dr("RESOLUCION").ToString().Trim())
                ticket.EscribirTicket("INICIAL " & dr("TICKET_INICIAL").ToString().Trim().PadLeft(22))
                If cbTiempoComida.SelectedValue = 5 Then
                    'EVALUA EL FIN DE MES
                    If Date.DaysInMonth(dtpFechaInicioTrabajo.Value.Year, dtpFechaInicioTrabajo.Value.Month) = dtpFechaInicioTrabajo.Value.Day Then
                        ticket.EscribirTicket("FINAL   " & (dr("TICKET_FINAL").ToString() - 2).ToString().Trim().PadLeft(22))
                    Else
                        'EVALUA EL DIA A DIA
                        ticket.EscribirTicket("FINAL   " & (dr("TICKET_FINAL").ToString() - 1).ToString().Trim().PadLeft(22))
                    End If
                Else
                    'EVALUA CADA TIEMPO
                    ticket.EscribirTicket("FINAL   " & dr("TICKET_FINAL").ToString().Trim().PadLeft(22))
                End If
            Next dr
            '============================================================================
        End If

        '============================================================================
        '============================================================================
        If rbCorteZ.Checked Then
            If tbl.Rows(0).Item(6).ToString = "" Then
                Label5.Visible = True
                ticket.CerrarArchivoSinImprimir()
                Exit Sub

            Else
                Label5.Visible = False
            End If

            'Dim resolucion_ As String = comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 0)
            'Dim dr_ As DataRow
            Dim resolucion_ As String
            Dim index_ As Integer = tbl_corr_.Rows.Count - 1
            resolucion_ = tbl_corr_.Rows(index_).Item("RESOLUCION").ToString().Trim()

            'SI ES FIN DE MES
            For Each dr_ In tbl_corr_.Rows
                If dr_("RESOLUCION").ToString().Trim().Equals(resolucion_.Trim()) Then
                    If Date.DaysInMonth(dtpFechaInicioTrabajo.Value.Year, dtpFechaInicioTrabajo.Value.Month) = dtpFechaInicioTrabajo.Value.Day Then
                        ticket.EscribirTicket("TICKET # " & (Val(dr_("TICKET_FINAL").ToString()) - 1).ToString()) 'NUMERO DE TICKET
                    Else
                        'SI ES DIA CON DIA
                        ticket.EscribirTicket("TICKET # " & (Val(dr_("TICKET_FINAL").ToString()))) 'NUMERO DE TICKET
                    End If
                End If
            Next dr_

            ticket.EscribirTicket("FECHA: " & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & " " & Date.Now.ToShortTimeString)
            ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
            ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
            ticket.EscribirTicket("CORTE PARCIAL Z")
            ticket.EscribirTicket("=======================================")
            ticket.EscribirTicket("RESOLUCION: " & resolucion_)
            ticket.EscribirTicket("FECHA DE RESOLUCION: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 1)), "dd/MM/yyyy"))
            ticket.EscribirTicket("AUTORIZADA: " & Format(CDate(comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 2)), "dd/MM/yyyy"))
            ticket.EscribirTicket("DEL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 3).ToString().PadLeft(6, "0"))
            ticket.EscribirTicket("AL: " & comandos.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @BANDERA=2", 4).ToString().PadLeft(6, "0"))
            ticket.EscribirTicket("=======================================")

            For i As Integer = 0 To tbl.Rows.Count - 1
                VentaBruta += tbl.Rows(i).Item(0)
                Efectivo += tbl.Rows(i).Item(1)
                Credito += tbl.Rows(i).Item(2)
                Descuentos += tbl.Rows(i).Item(3)
            Next
            ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
            ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
            ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString("#,##0.00").PadLeft(14, " "))
            ticket.EscribirTicket("TOTAL VENTAS          " & VentaBruta.ToString("#,##0.00").PadLeft(14, " "))
            ticket.EscribirTicket("TICKETS EMITIDOS")

            '============================================================================   
            Dim dr As DataRow
            For Each dr In tbl_corr_.Rows
                ticket.EscribirTicket("RESOLUCION " & dr("RESOLUCION").ToString().Trim())
                ticket.EscribirTicket("INICIAL " & dr("TICKET_INICIAL").ToString().Trim().PadLeft(22))
                'SI ES FIN DE MES
                If Date.DaysInMonth(dtpFechaInicioTrabajo.Value.Year, dtpFechaInicioTrabajo.Value.Month) = dtpFechaInicioTrabajo.Value.Day Then
                    ticket.EscribirTicket("FINAL   " & (dr("TICKET_FINAL").ToString() - 1).ToString().Trim().PadLeft(22))
                Else
                    'SI ES DIA CON DIA
                    ticket.EscribirTicket("FINAL   " & dr("TICKET_FINAL").ToString().Trim().PadLeft(22))
                End If
            Next dr
            '============================================================================
        End If

        Dim DEVOLUCIONES As String = (IIf(Val(tbl.Rows(0).Item(8)) > 0, -1, 1) * Val(tbl.Rows(0).Item(8))).ToString("0.00")

        DEVOLUCIONES = IIf(Val(tbl.Rows(0).Item(8)) > 0, -1, 1) * Val(tbl.Rows(0).Item(8))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & VentaBruta.ToString("#,##0.00").PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & Val(DEVOLUCIONES).ToString("#,##0.00").PadLeft(14, " ")) 'TOTAL ANULACIONES
        ticket.EscribirTicket("VENTA TOTAL           " & (VentaBruta + Val(DEVOLUCIONES)).ToString("#,##0.00").PadLeft(14, " ")) 'TOTAL NETO
        ticket.CerrarArchivo(correlativo_Actual, cmbCajas.SelectedValue)
        MsgBox("Corte " & IIf(rbCorteX.Checked, "X", "Z") & " reimpreso exitosamente", MsgBoxStyle.Information, "Reimpresion de Cortes")
        'ticket.ImprimirTicket()
    End Sub

    Private Function DevolverDataSet() As DataSet
        Dim sql As String
        If cmbBODEGA.SelectedValue = bodega_ataf Then
            sql = "EXEC sp_ALMACENES_DESPENSAS_CORTE_CAJA_RPT @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ",@FECHA= '" & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        Else
            sql = "EXEC sp_CAFETERIA_CORTE_CAJA_RPT @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ",@FECHA= '" & dtpFechaInicioTrabajo.Value.ToString("dd/MM/yyyy") & "'"
            If rbCorteX.Checked Then
                sql += ",@TIEMPO=" & cbTiempoComida.SelectedValue
                sql += ",@TIPO_CORTE='X'"
            End If
        End If

        If rbCorteZ.Checked Then
            sql += ",@TIPO_CORTE='Z'"
        End If
        If rbCorteZZ.Checked Then
            sql += ",@TIPO_CORTE='ZZ'"
        End If

        Return comandos.ObtenerDataSet(sql)
    End Function

    Private Sub rbCorteX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCorteX.CheckedChanged
        If rbCorteX.Checked Then
            cbTiempoComida.Enabled = True
            dtpFechaInicioTrabajo.Format = DateTimePickerFormat.Short
            Label5.Visible = False
            rbCorteZ.Checked = False
            rbCorteZZ.Checked = False
        End If
    End Sub

    Private Sub rbCorteZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCorteZ.CheckedChanged
        If rbCorteZ.Checked Then
            cbTiempoComida.Enabled = False
            dtpFechaInicioTrabajo.Format = DateTimePickerFormat.Short
            Label5.Visible = False
            rbCorteZZ.Checked = False
            rbCorteX.Checked = False
        End If
    End Sub

    Private Sub rbCorteZZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCorteZZ.CheckedChanged
        If rbCorteZZ.Checked Then
            cbTiempoComida.Enabled = False
            rbCorteX.Checked = False
            rbCorteZ.Checked = False
            dtpFechaInicioTrabajo.Format = DateTimePickerFormat.Custom
            Label5.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ValidarCampos() Then
            If MsgBox("¿Desea reimprimir el Corte?", MsgBoxStyle.YesNo, "Reimpresion de Corte") = MsgBoxResult.Yes Then
                ImprimirTicketSIMP()
            End If
        End If
    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged
        Label5.Visible = False
    End Sub

    Private Sub cbTiempoComida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTiempoComida.SelectedIndexChanged
        Label5.Visible = False
    End Sub

    Private Sub dtpFechaInicioTrabajo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicioTrabajo.ValueChanged
        Label5.Visible = False
    End Sub

    Private Sub Cafeteria_Reporte_Cortes_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        'Dim LinearBrush As Drawing2D.LinearGradientBrush = _
        '       New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
        '       Drawing2D.LinearGradientMode.Vertical)
        'Dim g As Graphics = e.Graphics
        'g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class