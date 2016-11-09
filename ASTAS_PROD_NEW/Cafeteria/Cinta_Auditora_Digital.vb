Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Cinta_Auditora_Digital
    'Req. Inicial #151
    Dim c_data2 As New jarsClass
    Dim TICKET As New GenerarTicket
    Dim Iniciando As Boolean
    Dim DS01, DS02 As New DataSet()
    Dim SQL As String
    Dim Iniciando2 As Boolean
    Dim listaTicket As New List(Of String)
    Dim direccion As String, BODEGA As String, CAJA As String
    Dim bandera As Boolean = False
    Dim Tiempo As String = 0
    Dim bodega_ataf As Integer = 82
    Dim detener As Boolean
    'VARIABLES NECESARIAS
    '----------------------------------------
    Dim VentaBruta As Double = 0.0
    Dim Efectivo As Double = 0.0
    Dim Credito As Double = 0.0
    Dim Descuentos As Double = 0.0
    Dim Corte As Double = 0
    '----------------------------------------
    Dim Resolucion As String, fecha_resolucion As String, fecha_autorizacion As String, del As String, al As String, descripcion_bodega As String
    Dim Movimiento As String, PRODUCTO As String, item As String, serie As String, fecha_aprovacion As String, tiempo_c As String, correlativo_Actual As String

    Private Sub Cinta_Auditora_Digital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True

        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia

        'LLENA EL COMBO DE BODEGAS
        c_data2.CargaBodegas(Compañia, Me.cbCafeteria, 9)

        c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'S'", "Tiempo de Comida", "Descripción")
        'c_data2.CargarCombo(Me.cbSeleccioneCaja, "Execute sp_CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO_SIUD " & Compañia & ", " & "'S'", "Tiempo de Comida", "Descripción")        
        cargarCajas()
        BODEGA = Me.cbCafeteria.SelectedValue
        CAJA = Me.cbSeleccioneCaja.SelectedValue
        Tiempo = cbTiempoComida.SelectedValue
        Iniciando = False
    End Sub
    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.Label3.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.Label3.Text = texto
        End If
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)

        If (Val(a) = 0) Then
            Me.cbSeleccioneCaja.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data2.CargarCombo(Me.cbSeleccioneCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")

        End If

    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            BODEGA = Me.cbCafeteria.SelectedValue
            cargarCajas()
            CAJA = Me.cbSeleccioneCaja.SelectedValue
            Me.Cierre_Apertura_Grid.DataSource = Nothing
            Me.lblCantTKT.Text = ""
            Iniciando2 = False
        End If
    End Sub
    Public Function NumeroFactura() As Integer
        Dim permiso As Integer = 0
        'sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @BANDERA=1
        direccion = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=1", 0)
        'sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @BANDERA=2
        Dim tblDatos As DataTable
        tblDatos = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2"))
        Resolucion = tblDatos.Rows(0).Item(0) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 0)
        fecha_resolucion = tblDatos.Rows(0).Item(1) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 1)
        fecha_autorizacion = tblDatos.Rows(0).Item(2) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 2)
        del = tblDatos.Rows(0).Item(3) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 3)
        al = tblDatos.Rows(0).Item(4) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 4)
        'sp_CAFETERIA_FACTURACION_OBTENER_SERIE BANDERA=1
        tblDatos = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@BANDERA=1"))
        serie = tblDatos.Rows(0).Item(0) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@BANDERA=1", 0)
        correlativo_Actual = tblDatos.Rows(0).Item(3) 'c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@BANDERA=1", 3)

        permiso = 1
        If ((serie = Nothing) Or (serie = "")) Or ((correlativo_Actual = Nothing) Or (correlativo_Actual = "")) Or ((Resolucion = Nothing) Or (Resolucion = "")) Or ((fecha_resolucion = Nothing) Or (fecha_resolucion = "")) Or ((fecha_autorizacion = Nothing) Or (fecha_autorizacion = "")) Or ((Val(del) = Nothing) Or (del = "")) Or ((al = Nothing) Or (al = "")) Then
            permiso = 0
        End If
        Return permiso
    End Function
    Private Sub ImprimirTicket(ByVal continua, ByVal Tiempo)
        'NumeroFactura()
        'comandos.Ejecutar_ConsultaSQL("Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@SERIE='" & serie & "', @NUMERO_FACTURA=" & correlativo_Actual & ", @FECHA='" & Format(dtpFechaInicioTrabajo.Value, "yyyy-MM-dd") & "', @TIEMPO=" & cbTiempoComida.SelectedValue & ", @CAJA=" & cmbCajas.SelectedValue & ", @CODIGO_EMPLEADO=0,@CODIGO_EMPLEADO_AS='000000',@ANULADO=0,@FORMA_PAGO=1,@IVA=0,@DEUDA=0,@MONTO=0,@TIPO_DOCUMENTO=28,@ORIGEN=1,@PROCESADO=1, @USUARIO_CREACION='" & Usuario & "', @TIPO_MOV=2, @MOV=" & Movimiento)

        'CARGAR DATOS DEL CORTE
        Dim ds As New DataSet
        ds = DevolverDataSet(Tiempo)

        'ACCEDER A LAS DOS DATATABLE
        Dim tbl As New DataTable
        tbl = ds.Tables(0)

        Dim tbl2 As New DataTable
        tbl2 = ds.Tables(1)

        If (tbl.Rows.Count = 0) Then
            If continua = 0 Then
                MsgBox("Aviso...NO HAY DATOS QUE MOSTRAR", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If

        'PREPARAMOS VARIABLES
        VentaBruta = 0.0
        Efectivo = 0.0
        Credito = 0.0
        Descuentos = 0.0

        CortesX_Z(TICKET, tbl, tbl2, Tiempo)
        'If Corte = 1 Or Corte = 2 Then
        '    CortesX_Z(TICKET, tbl, tbl2, Tiempo)
        'ElseIf Corte = 3 Then
        '    CortesX_Z(TICKET, tbl, tbl2, Tiempo)
        'End If
    End Sub
    Public Sub CorteX(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable, ByVal Tiempo As String)
        Dim DEVOLUCIONES As Double
        Dim ds As New DataSet
        ds = llenado_Datasets("X", Tiempo)
        tbl = ds.Tables(0)
        tbl2 = ds.Tables(1)
        DEVOLUCIONES = tbl.Rows(0).Item(8)
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("NRC:82735-5                            ")
        ticket.EscribirTicket("NIT:0614-020994-102-1                  ")
        ticket.EscribirTicket(" ASOCIACION DE TRABAJADORES DE AVICOLA ")
        ticket.EscribirTicket("  SALVADOREÑA S.A DE C.V. Y FILIALES   ")
        ticket.EscribirTicket("                 ASTAS                 ")
        ticket.EscribirTicket("GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO ")
        ticket.EscribirTicket("CLASIFICADOS PREVIAMENTE CAFETERIAS Y  ")
        ticket.EscribirTicket("FRUTERIAS                              ")
        'DIRECCION CAJA
        ticket.EscribirTicket(tbl2.Rows(0).Item(4).ToString().Trim() & " " & tbl2.Rows(0).Item(5).ToString().Trim())
        ticket.EscribirTicket("TICKET # " & tbl2.Rows(0).Item(2).ToString()) 'NUMERO DE TICKET

        ticket.EscribirTicket("FECHA: " & Movimiento)
        ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket("CORTE PARCIAL X")
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 0))
        ticket.EscribirTicket("FECHA DE RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 1).ToString().Substring(0, 10))
        ticket.EscribirTicket("AUTORIZADA: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 2).ToString().Substring(0, 10))
        ticket.EscribirTicket("DEL: " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        ticket.EscribirTicket("AL:  " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        'ticket.EscribirTicket("DEL: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 3).ToString.PadLeft(6, "0"))
        'ticket.EscribirTicket("AL:  " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 4).ToString.PadLeft(6, "0"))
        ticket.EscribirTicket("=======================================")
        VentaBruta = 0
        For i As Integer = 0 To tbl.Rows.Count - 1
            VentaBruta += tbl.Rows(i).Item(1)
            Efectivo += tbl.Rows(i).Item(2)
            Credito += tbl.Rows(i).Item(3)
            Descuentos += tbl.Rows(i).Item(4)
        Next
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & FormatNumber(VentaBruta, 2).PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL VENTAS " & FormatNumber(VentaBruta, 2).PadLeft(23, " "))
        ticket.EscribirTicket("TICKETS EMITIDOS")
        ticket.EscribirTicket("INICIAL " & tbl.Rows(0).Item(6).ToString().Trim().PadLeft(28))
        ticket.EscribirTicket("FINAL " & tbl2.Rows(0).Item(2).ToString().Trim().PadLeft(30))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")

        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Format(VentaBruta, "#,##0.00").PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(17, " ")) 'TOTAL DEPOSITAR
        ticket.EscribirTicket("VENTA TOTAL " & Format(VentaBruta - DEVOLUCIONES, "#,##0.00").PadLeft(24, " ")) 'TOTAL DEPOSITAR      
        For i As Integer = 0 To 6
            ticket.EscribirTicket(" ")
        Next
    End Sub
    Public Sub CorteZ(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable, ByVal Tiempo As String)
        Dim DEVOLUCIONES As Double
        Dim ds As New DataSet
        ds = llenado_Datasets("Z", Tiempo)
        tbl = ds.Tables(0)
        tbl2 = ds.Tables(1)
        DEVOLUCIONES = tbl.Rows(0).Item(8)
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("NRC:82735-5                            ")
        ticket.EscribirTicket("NIT:0614-020994-102-1                  ")
        ticket.EscribirTicket(" ASOCIACION DE TRABAJADORES DE AVICOLA ")
        ticket.EscribirTicket("  SALVADOREÑA S.A DE C.V. Y FILIALES   ")
        ticket.EscribirTicket("                 ASTAS                 ")
        ticket.EscribirTicket("GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO ")
        ticket.EscribirTicket("CLASIFICADOS PREVIAMENTE CAFETERIAS Y  ")
        ticket.EscribirTicket("FRUTERIAS                              ")
        ticket.EscribirTicket(tbl2.Rows(0).Item(4).ToString().Trim() & " " & tbl2.Rows(0).Item(5).ToString().Trim()) 'DIRECCION CAJA
        ticket.EscribirTicket("TICKET # " & tbl2.Rows(0).Item(2).ToString()) 'NUMERO DE TICKET
        ticket.EscribirTicket("FECHA: " & Movimiento)
        ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket("CORTE PARCIAL Z")
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 0))
        ticket.EscribirTicket("FECHA DE RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 1).ToString().Substring(0, 10))
        ticket.EscribirTicket("AUTORIZADA: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 2).ToString().Substring(0, 10))
        ticket.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        ticket.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        'ticket.EscribirTicket("DEL: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 3).ToString.PadLeft(6, "0"))
        'ticket.EscribirTicket("AL:  " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 4).ToString.PadLeft(6, "0"))
        ticket.EscribirTicket("=======================================")
        VentaBruta = 0
        For i As Integer = 0 To tbl.Rows.Count - 1
            VentaBruta += tbl.Rows(i).Item(0)
            Efectivo += tbl.Rows(i).Item(1)
            Credito += tbl.Rows(i).Item(2)
            Descuentos += tbl.Rows(i).Item(3)
        Next
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & FormatNumber(VentaBruta, 2).PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL VENTAS " & FormatNumber(VentaBruta, 2).PadLeft(23, " "))
        ticket.EscribirTicket("TICKETS EMITIDOS")
        ticket.EscribirTicket("INICIAL " & tbl.Rows(0).Item(5).ToString().Trim().PadLeft(28))
        ticket.EscribirTicket("FINAL " & tbl2.Rows(0).Item(2).ToString().Trim().PadLeft(30))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")

        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Format(VentaBruta, "#,##0.00").PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(17, " ")) 'TOTAL DEPOSITAR
        ticket.EscribirTicket("VENTA TOTAL " & Format(VentaBruta - DEVOLUCIONES, "#,##0.00").PadLeft(24, " ")) 'TOTAL DEPOSITAR      
        For i As Integer = 0 To 6
            ticket.EscribirTicket(" ")
        Next
    End Sub
    Public Sub CorteZZ(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable)
        'If tbl.Rows(0).Item(6).ToString = "" Then
        '    ticket.CerrarArchivoSinImprimir()
        '    Exit Sub
        'End If
        Dim DEVOLUCIONES As Double
        Dim ds As New DataSet
        ds = llenado_Datasets("ZZ", Tiempo)
        tbl = ds.Tables(0)
        tbl2 = ds.Tables(1)
        DEVOLUCIONES = tbl.Rows(0).Item(2)
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("NRC:82735-5                            ")
        ticket.EscribirTicket("NIT:0614-020994-102-1                  ")
        ticket.EscribirTicket(" ASOCIACION DE TRABAJADORES DE AVICOLA ")
        ticket.EscribirTicket("  SALVADOREÑA S.A DE C.V. Y FILIALES   ")
        ticket.EscribirTicket("                 ASTAS                 ")
        ticket.EscribirTicket("GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO ")
        ticket.EscribirTicket("CLASIFICADOS PREVIAMENTE CAFETERIAS Y  ")
        ticket.EscribirTicket("FRUTERIAS                              ")

        'DIRECCION CAJA
        ticket.EscribirTicket(tbl2.Rows(0).Item(4).ToString().Trim() & " " & tbl2.Rows(0).Item(5).ToString().Trim())
        ticket.EscribirTicket("TICKET # " & tbl.Rows(0).Item(8).ToString().Trim()) 'NUMERO DE TICKET
        ticket.EscribirTicket("FECHA: " & Movimiento)
        ticket.EscribirTicket(tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket("CORTE PARCIAL ZZ")
        ticket.EscribirTicket("=======================================")
        ticket.EscribirTicket("RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 0))
        ticket.EscribirTicket("FECHA DE RESOLUCION: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 1).ToString().Substring(0, 10))
        ticket.EscribirTicket("AUTORIZADA: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 2).ToString().Substring(0, 10))
        ticket.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        ticket.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        'ticket.EscribirTicket("DEL: " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 3).ToString.PadLeft(6, "0"))
        'ticket.EscribirTicket("AL:  " & c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & BODEGA & ", @CAJA=" & CAJA & ", @BANDERA=2", 4).ToString.PadLeft(6, "0"))
        ticket.EscribirTicket("=======================================")
        VentaBruta = FormatNumber(tbl.Rows(0).Item(1), 2)
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Format(VentaBruta, "#,##0.00").PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL VENTAS " & Format(VentaBruta, "#,##0.00").PadLeft(23, " "))
        ticket.EscribirTicket("TICKETS")
        ticket.EscribirTicket("INICIAL " & tbl.Rows(0).Item(7).ToString().Trim().PadLeft(28))
        ticket.EscribirTicket("FINAL " & tbl.Rows(0).Item(8).ToString().Trim().PadLeft(30))
        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("DEVOLUCIONES")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")
        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))
        ticket.EscribirTicket("TOTAL DEVOLUCIONES    " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(14, " "))

        ticket.EscribirTicket(" ")
        ticket.EscribirTicket("GRAN TOTAL")
        ticket.EscribirTicket("TOTAL VENTAS EXENTAS            0.00")
        ticket.EscribirTicket("TOTAL VENTAS NO SUJETAS         0.00")

        ticket.EscribirTicket("TOTAL VENTAS GRAVADAS " & Format(VentaBruta, "#,##0.00").PadLeft(14, " ")) 'VENTA BRUTA
        ticket.EscribirTicket("TOTAL DEVOLUCIONES " & (IIf(DEVOLUCIONES > 0, "-", " ") & Format(DEVOLUCIONES, "#,##0.00")).PadLeft(17, " ")) 'TOTAL DEPOSITAR
        ticket.EscribirTicket("VENTA TOTAL " & Format(VentaBruta - DEVOLUCIONES, "#,##0.00").PadLeft(24, " ")) 'TOTAL DEPOSITAR      
        For i As Integer = 0 To 6
            ticket.EscribirTicket(" ")
        Next
    End Sub
    Public Function llenado_Datasets(ByVal corteTiempo As String, ByVal Tiempo As String) As DataSet
        Dim ds As New DataSet
        SQL = "EXEC sp_CAFETERIA_CORTE_CAJA_RPT @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@FECHA= '" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        If corteTiempo <> "X" Then
            SQL &= ",@TIPO_CORTE='" & corteTiempo & "'"
        Else
            SQL &= ",@TIEMPO=" & Tiempo
            SQL &= ",@TIPO_CORTE='" & corteTiempo & "'"
        End If
        ds = c_data2.ObtenerDataSet(SQL)
        Return ds
    End Function
    Private Sub CortesX_Z(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable, ByVal Tiempo As String)
        Dim ds As New DataSet
        'TODO CORTE X
        If Corte = 1 Then
            ''ticket.AbrirArchivo2()
            CorteX(ticket, tbl, tbl2, Tiempo)
            ''ticket.CerrarArchivo2()
        End If
        If Corte = 2 Then
            ''ticket.AbrirArchivo2()
            CorteX(ticket, tbl, tbl2, Tiempo)
            ''ticket.CerrarArchivo2()
            ''ticket.AbrirArchivo2()
            CorteZ(ticket, tbl, tbl2, Tiempo)
            ''ticket.CerrarArchivo2()
        End If
        If Corte = 3 Then
            ''ticket.AbrirArchivo2()
            CorteX(ticket, tbl, tbl2, Tiempo)
            ''ticket.CerrarArchivo2()
            ''ticket.AbrirArchivo2()
            CorteZ(ticket, tbl, tbl2, Tiempo)
            ''ticket.CerrarArchivo2()
            ''ticket.AbrirArchivo2()
            CorteZZ(ticket, tbl, tbl2)
            ''ticket.CerrarArchivo2()
        End If
    End Sub
    Private Function DevolverDataSet(ByVal Tiempo) As DataSet
        Dim sql As String = String.Empty
        If BODEGA = bodega_ataf Then
            sql = "EXEC sp_ALMACENES_DESPENSAS_CORTE_CAJA_RPT @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@FECHA= '" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        Else
            If Corte <> 0 Then
                sql = "EXEC sp_CAFETERIA_CORTE_CAJA_RPT @COMPAÑIA=" & Compañia & ",@BODEGA=" & BODEGA & ",@CAJA=" & CAJA & ",@FECHA= '" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"
            End If
            If Corte = 1 Then
                sql &= ",@TIEMPO=" & Tiempo
                sql &= ",@TIPO_CORTE='X'"
            End If
        End If

        If Corte = 2 Then
            sql &= ",@TIPO_CORTE='Z'"
        End If
        If Corte = 3 Then
            sql &= ",@TIPO_CORTE='ZZ'"
        End If

        Return c_data2.ObtenerDataSet(sql)
    End Function

    Public Sub GuardarTicket(ByVal nombre As String, ByVal codigo As String, ByVal lista As List(Of String), ByVal Mtotal As String, ByVal Numero_Ticket As String, Optional ByVal formaPago As String = "")
        Dim intTamnio As Integer = direccion.Trim.Length - 8
        'TICKET.EscribirTicket("=======================================")
        TICKET.EscribirTicket("NRC:82735-5                            ")
        TICKET.EscribirTicket("NIT:0614-020994-102-1                  ")
        TICKET.EscribirTicket(" ASOCIACION DE TRABAJADORES DE AVICOLA ")
        TICKET.EscribirTicket("  SALVADOREÑA S.A DE C.V. Y FILIALES   ")
        TICKET.EscribirTicket("                 ASTAS                 ")
        TICKET.EscribirTicket("GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO ")
        TICKET.EscribirTicket("CLASIFICADOS PREVIAMENTE CAFETERIAS Y  ")
        TICKET.EscribirTicket("FRUTERIAS                              ")
        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7).Trim)
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio).Trim)
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("TICKET # " & Numero_Ticket & " " & descripcion_bodega & " CAJA No." & CAJA)
        TICKET.EscribirTicket("FECHA   :" & Movimiento)
        TICKET.EscribirTicket("                                       ")
        ''TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("RESOLUCION: " & Resolucion)
        TICKET.EscribirTicket("FECHA DE RESOLUCION: " & fecha_resolucion.Substring(0, 10))
        TICKET.EscribirTicket("AUTORIZADA: " & fecha_autorizacion.Substring(0, 10))
        TICKET.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        TICKET.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("CODIGO C:" & codigo & "   " & formaPago)
        TICKET.EscribirTicket("CLIENTE :" & nombre)
        TICKET.EscribirTicket("TIEMPO C:" & tiempo_c)
        TICKET.EscribirTicket("---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicket("CANT PRODUCTO            P/U  PREC.T")

        For i As Integer = 0 To lista.Count - 1
            TICKET.EscribirTicket(lista.Item(i).Trim)
        Next
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("SUBTT. VTA. GRAVADA     $:" & Mtotal.PadLeft(11, "."))
        TICKET.EscribirTicket("SUBTT. VTA. EXENTA      $:" & ("0.00").PadLeft(11, "."))
        ''TICKET.EscribirTicket("Subtt. Vta. Disponible  $:" & ("0.00").PadLeft(11, "."))
        TICKET.EscribirTicket("SUBTT. VTA. NO SUJ.     $:" & ("0.00").PadLeft(11, "."))
        TICKET.EscribirTicket("VENTA TOTAL             $:" & Mtotal.PadLeft(11, "."))
        TICKET.EscribirTicket("")
        TICKET.EscribirTicket("")
        TICKET.EscribirTicket("")
        TICKET.EscribirTicket("")
    End Sub
    Public Sub cargaGrid()
        Dim cuantosTKT As Integer = 0
        Dim numTKT As Integer = 0
        DS01.Reset()
        c_data2.MiddleConnection(SQL)
        c_data2.DataAdapter.Fill(DS01)
        Me.Cierre_Apertura_Grid.DataSource = DS01.Tables(0)
        c_data2.cerrarConexion()
        Corte = 0

        For i As Integer = 0 To Me.Cierre_Apertura_Grid.Columns.Count - 1
            Me.Cierre_Apertura_Grid.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If Not "0,9,14".Contains(i.ToString()) Then
                Me.Cierre_Apertura_Grid.Columns.Item(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        For i As Integer = 0 To Me.Cierre_Apertura_Grid.Rows.Count - 1
            If numTKT <> Me.Cierre_Apertura_Grid.Rows(i).Cells("NUMERO_FACTURA").Value Then
                numTKT = Me.Cierre_Apertura_Grid.Rows(i).Cells("NUMERO_FACTURA").Value
                cuantosTKT += 1
            End If
            If Me.Cierre_Apertura_Grid.Rows(i).Cells(0).Value.ToString() = "CORTE" Then
                Corte = Corte + 1
            End If
        Next
        If Me.Cierre_Apertura_Grid.Rows.Count > 0 Then
            PB1.Value = 0
            PB1.Maximum = Me.Cierre_Apertura_Grid.Rows.Count
        End If
        Me.lblCantTKT.Text = Format(cuantosTKT, "#,##0") & " Tickets"
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal bandera, ByVal Tiempo)
        If bandera = 0 Then
            SQL = "Execute [dbo].[sp_CAFETERIA_CINTAS_AUDITORAS] "
            SQL &= "@COMPAÑIA = " & CIA
            SQL &= ",@FECHA_FIN = '" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy") & "'"
            SQL &= ",@BODEGA = " & BODEGA
            SQL &= ",@CAJA = " & CAJA
            SQL &= ",@TIEMPO = " & Tiempo
            If rbTo2Tiempos.Checked = True Then
                'MUESTRA TODOS LOS TIEMPOS
                SQL &= ",@BANDERA = 2"
            Else
                'MUESTRA SOLO DETERMINADO TIEMPO
                SQL &= ",@BANDERA = 1"
            End If
        Else
            SQL = "Execute [dbo].[sp_CAFETERIA_CINTAS_AUDITORAS] "
            SQL &= "@COMPAÑIA = " & CIA
            SQL &= ",@FECHA_FIN = '" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy") & "'"
            SQL &= ",@BODEGA = " & BODEGA
            SQL &= ",@CAJA = " & CAJA
            SQL &= ",@TIEMPO = " & Tiempo
            SQL &= ",@BANDERA = " & bandera
        End If
    End Sub

    Private Sub rbCorteZZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTo2Tiempos.CheckedChanged
        If rbTo2Tiempos.Checked = True Then
            cbTiempoComida.Enabled = False
            Tiempo = 0
        Else
            cbTiempoComida.Enabled = True
            Tiempo = cbTiempoComida.SelectedValue
        End If
    End Sub
    Public Sub Cargando(ByVal activar As Boolean)
        Label3.Visible = activar
        PictureBox1.Visible = activar
        Me.btnCancelar.Visible = activar
        Me.PB1.Visible = activar
        Me.PB1.Value = 0
        Me.cbSeleccioneCaja.Enabled = Not activar
        Me.cbTiempoComida.Enabled = Not activar
        Me.cbCafeteria.Enabled = Not activar
        Me.btnImprimir.Enabled = Not activar
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        PRODUCTO = Format(Me.dtpFechaTrabajo.Value, "ddMMyyyy")
        descripcion_bodega = Me.cbCafeteria.Text.Trim
        Cargando(True)
        detener = False
        If Me.rbTo2Tiempos.Checked Then
            Me.Label3.Text = "Generando Cinta Auditora Calculando Parámetros"
            DS02 = Me.llenado_Datasets("Z", Me.cbTiempoComida.SelectedValue)
            Try
                Me.lblCantTKT.Text = Format((CInt(DS02.Tables(0).Rows(0).Item("TICKET_FINAL")) - CInt(DS02.Tables(0).Rows(0).Item("TICKET_INICIAL")) + 1), "#,##0") & " Tickets"
            Catch ex As Exception
                Me.lblCantTKT.Text = "NO CORTE Z"
            End Try
            Me.Refresh()
            cadenaSIUD(Compañia, 3, cbTiempoComida.SelectedValue.ToString())
            Me.PB1.Maximum = CInt(Val(c_data2.obtenerEscalar(SQL)))
            PB1.Value = 0
            BW2.RunWorkerAsync(Me.dtpFechaTrabajo.Value)
        Else
            If Cierre_Apertura_Grid.RowCount = 0 Then
                Me.Label3.Text = "Generando Cinta Auditora Tiempo:" & Me.cbTiempoComida.Text.Trim & vbCrLf & " Cargando Datos"
                Me.Refresh()
                cadenaSIUD(Compañia, 0, cbTiempoComida.SelectedValue.ToString())
                cargaGrid()
                'MsgBox("Primero debe cargar datos", MsgBoxStyle.Critical, Me.Text)
                'Return
            End If
            tiempo_c = Me.cbTiempoComida.Text.Trim
            Bw1.RunWorkerAsync()
        End If
    End Sub
    Public Sub ImpresionCintaAuditora(ByVal continua As Integer, ByVal Tiempo As String, Optional ByRef e As System.ComponentModel.DoWorkEventArgs = Nothing)
        Dim montoTotal As String = 0
        Dim numTicket As Integer = 0
        Dim NombreTicket As String = String.Empty
        Dim cod As String = String.Empty
        Dim FPago As String = String.Empty
        Dim poneTexto As New CallBackSetText(AddressOf SetText)

        NumeroFactura()
        TICKET.AbrirArchivo2()
        poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Imprimiendo Tickets")
        For i As Integer = 0 To Cierre_Apertura_Grid.Rows.Count - 1
            If Me.Bw1.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
            If Cierre_Apertura_Grid.Rows(i).Cells(0).Value.ToString() = "CORTE" Then
                If Not detener Then
                    poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Imprimiendo Cortes")
                    GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
                    Movimiento = Format(Cierre_Apertura_Grid.Rows(i).Cells(15).Value, "dd/MM/yyyy hh:mm:ss tt")
                    ImprimirTicket(1, Tiempo)
                End If
                detener = True
                numTicket = 0
            Else
                If numTicket <> Cierre_Apertura_Grid.Rows(i).Cells(8).Value And numTicket > 0 Then
                    GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
                    montoTotal = 0
                    listaTicket.Clear()
                End If
                numTicket = Cierre_Apertura_Grid.Rows(i).Cells(8).Value
                NombreTicket = Cierre_Apertura_Grid.Rows(i).Cells(9).Value.ToString()
                cod = Cierre_Apertura_Grid.Rows(i).Cells(2).Value.ToString()
                FPago = Cierre_Apertura_Grid.Rows(i).Cells(14).Value.ToString()
                Movimiento = Format(Cierre_Apertura_Grid.Rows(i).Cells(15).Value, "dd/MM/yyyy hh:mm:ss tt")
                montoTotal = (Val(Cierre_Apertura_Grid.Rows(i).Cells(7).Value.ToString())).ToString
                listaTicket.Add(Math.Round(Cierre_Apertura_Grid.Rows(i).Cells(4).Value, 2).ToString().PadRight(5, " ") & " " & Cierre_Apertura_Grid.Rows(i).Cells(0).Value.ToString().PadRight(19, " ") & " " & Math.Round(Val(Cierre_Apertura_Grid.Rows(i).Cells(5).Value), 2).ToString("0.00").PadRight(6, " ") & " " & Math.Round(Val(Cierre_Apertura_Grid.Rows(i).Cells(6).Value), 2).ToString("0.00").PadRight(6, " "))
            End If
            Bw1.ReportProgress(i + 1)
        Next
        listaTicket.Clear()
        If Cierre_Apertura_Grid.Rows(Cierre_Apertura_Grid.Rows.Count - 1).Cells(0).Value.ToString() <> "CORTE" Then
            ''TICKET.AbrirArchivo2()
            NumeroFactura()
            GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
            ''TICKET.CerrarArchivo2()
        End If
        TICKET.CerrarArchivoSinImprimir()
        poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Creando Archivo PDF")
        CintaPDF()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        ImpresionCintaAuditora(6, Tiempo, e)
    End Sub

    Private Sub cbSeleccioneCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeleccioneCaja.SelectedIndexChanged
        If Iniciando = False Then
            If Iniciando2 = False Then
                CAJA = Me.cbSeleccioneCaja.SelectedValue
                Tiempo = cbTiempoComida.SelectedValue
                Me.Cierre_Apertura_Grid.DataSource = Nothing
                Me.lblCantTKT.Text = ""
            End If
        End If
    End Sub

    Private Sub cbTiempoComida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTiempoComida.SelectedIndexChanged
        If Iniciando = False Then
            Tiempo = cbTiempoComida.SelectedValue
            Me.Cierre_Apertura_Grid.DataSource = Nothing
            Me.lblCantTKT.Text = ""
        End If
    End Sub

    Private Sub GroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        Dim Rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As System.Drawing.Drawing2D.LinearGradientBrush = _
               New System.Drawing.Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               System.Drawing.Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Cinta_Auditora_Digital_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As System.Drawing.Drawing2D.LinearGradientBrush = _
               New System.Drawing.Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               System.Drawing.Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw1.ProgressChanged
        PB1.Value = e.ProgressPercentage
    End Sub

    Private Sub RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            MsgBox("Impresión cancelada por el usuario!!", MsgBoxStyle.Information, "Resultado")
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error al Imprmir cinta auditora:" & vbCrLf & vbCrLf & e.Error.Message.ToUpper(), MsgBoxStyle.Information, "Resultado")
        Else
            MsgBox("Cinta Impresa correctamente", MsgBoxStyle.Information, "Resultado")
        End If
        Cargando(False)
        detener = False
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.rbTo2Tiempos.Checked Then
            BW2.CancelAsync()
        Else
            Bw1.CancelAsync()
        End If
    End Sub

    Private Sub dtpFechaTrabajo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaTrabajo.ValueChanged
        Me.Cierre_Apertura_Grid.DataSource = Nothing
        Me.lblCantTKT.Text = ""
    End Sub

    Private Sub CintaPDF()
        'http://www.ajpdsoft.com/modules.php?name=News&file=article&sid=596
        Try
            'Archivo que contiene la información
            Dim Fichero As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ticket.txt"
            'Nombre del archio PDF a crear
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\CINTA\Caja " & CAJA.ToString().PadLeft(2, "0") & " - Cinta Auditora dia " & PRODUCTO.ToString().PadLeft(2, "0") & "_" & tiempo_c & ".pdf"
            'Obtenemos el texto a guardar en PDF
            Dim objFichero As New StreamReader(Fichero)
            Dim Texto As String
            Texto = objFichero.ReadToEnd
            objFichero.Close()
            'Creamos el objeto documento PDF
            Dim documentoPDF As New Document
            PdfWriter.GetInstance(documentoPDF, New FileStream(fileName, FileMode.Create))
            documentoPDF.Open()

            'Escribimos el texto en el objeto documento PDF
            documentoPDF.Add(New Paragraph(Texto, FontFactory.GetFont(FontFactory.COURIER, 8, iTextSharp.text.Font.NORMAL)))

            'Cerramos el objeto documento, guardamos y creamos el PDF
            documentoPDF.Close()
            'Comprobamos si se ha creado el fichero PDF
            If System.IO.File.Exists(Fichero) Then
                If MsgBox("Texto convertido a fichero PDF correctamente " & vbCrLf & "¿desea abrir el fichero PDF resultante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Abrimos el fichero PDF con la aplicación asociada
                    System.Diagnostics.Process.Start(fileName)
                End If
            Else
                MsgBox("El fichero PDF no se ha generado, " & vbCrLf & "compruebe que tiene permisos en la carpeta de destino.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error al intentar convertir el texto a PDF: " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BW2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW2.DoWork
        'Req.#152
        Dim tblTickets As DataTable
        Dim montoTotal As String = 0
        Dim numTicket As Integer = 0
        Dim NombreTicket As String = String.Empty
        Dim cod As String = String.Empty
        Dim FPago As String = String.Empty
        Dim poneTexto As New CallBackSetText(AddressOf SetText)

        TICKET.AbrirArchivo2()
        NumeroFactura()
        For j As Integer = 1 To 5
            If Me.BW2.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
            tiempo_c = c_data2.obtenerEscalar("SELECT RTRIM([DESCRIPCION]) FROM [dbo].[CAFETERIA_CATALOGO_TIEMPO_COMIDA] WHERE [COMPAÑIA] = " & Compañia & " AND [TIEMPO_COMIDA] = " & j)
            poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Cargando Datos")
            Corte = c_data2.obtenerEscalar("SELECT COUNT(COMPAÑIA) FROM CAFETERIA_FACTURACION_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND FECHA_FACTURA = '" & Format(e.Argument, "dd/MM/yyyy") & "' AND BODEGA = " & BODEGA & " AND CAJA = " & CAJA & " and TIPO_DOCUMENTO <> 27 and TIEMPO = " & j)
            SQL = "EXECUTE [dbo].[sp_CAFETERIA_CINTAS_AUDITORAS] " & vbCrLf
            SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
            SQL &= ",@FECHA_FIN = '" & Format(e.Argument, "dd/MM/yyyy") & "'" & vbCrLf
            SQL &= ",@BODEGA = " & BODEGA & vbCrLf
            SQL &= ",@CAJA = " & CAJA & vbCrLf
            SQL &= ",@TIEMPO = " & j & vbCrLf
            SQL &= ",@BANDERA = 1" & vbCrLf
            numTicket = 0
            detener = False
            tblTickets = c_data2.obtenerDatos(New SqlCommand(SQL))
            poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Imprimiendo Tickets")
            For i As Integer = 0 To tblTickets.Rows.Count - 1
                If Me.BW2.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
                If tblTickets.Rows(i).Item(0).ToString() = "CORTE" Then
                    If Not detener Then
                        poneTexto("Generando Cinta Auditora Tiempo: " & tiempo_c & vbCrLf & " Imprimiendo Cortes")
                        GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
                        Movimiento = Format(tblTickets.Rows(i).Item(15), "dd/MM/yyyy hh:mm:ss tt")
                        ImprimirTicket(1, j)
                    End If
                    detener = True
                    numTicket = 0
                Else
                    If numTicket <> tblTickets.Rows(i).Item(8) And numTicket > 0 Then
                        GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
                        montoTotal = 0
                        listaTicket.Clear()
                    End If
                    numTicket = tblTickets.Rows(i).Item(8)
                    NombreTicket = tblTickets.Rows(i).Item(9).ToString()
                    cod = tblTickets.Rows(i).Item(2).ToString()
                    FPago = tblTickets.Rows(i).Item(14).ToString()
                    Movimiento = Format(tblTickets.Rows(i).Item(15), "dd/MM/yyyy hh:mm:ss tt")
                    montoTotal = (Val(tblTickets.Rows(i).Item(7).ToString())).ToString
                    listaTicket.Add(Math.Round(tblTickets.Rows(i).Item(4), 2).ToString().PadRight(5, " ") & " " & tblTickets.Rows(i).Item(0).ToString().PadRight(19, " ") & " " & Math.Round(Val(tblTickets.Rows(i).Item(5)), 2).ToString("0.00").PadRight(6, " ") & " " & Math.Round(Val(tblTickets.Rows(i).Item(6)), 2).ToString("0.00").PadRight(6, " "))
                End If
                BW2.ReportProgress(1)
            Next
            listaTicket.Clear()
            If tblTickets.Rows.Count > 0 Then
                If tblTickets.Rows(tblTickets.Rows.Count - 1).Item(0).ToString() <> "CORTE" Then
                    GuardarTicket(NombreTicket, cod, listaTicket, Math.Round(Val(montoTotal), 2).ToString("0.00"), numTicket, FPago)
                End If
            End If
        Next
        TICKET.CerrarArchivoSinImprimir()
        tiempo_c = "TODOS_LOS_TIEMPOS"
        poneTexto("Generando Cinta Auditora " & tiempo_c & " Creando Archivo PDF")
        CintaPDF()
    End Sub

    Private Sub BW2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW2.ProgressChanged
        Try
            PB1.Value += e.ProgressPercentage
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BW2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW2.RunWorkerCompleted
        If e.Cancelled Then
            MsgBox("Impresión cancelada por el usuario!!", MsgBoxStyle.Information, "Resultado")
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error al Imprmir cinta auditora:" & vbCrLf & vbCrLf & e.Error.Message.ToUpper(), MsgBoxStyle.Information, "Resultado")
        Else
            MsgBox("Cinta Impresa correctamente", MsgBoxStyle.Information, "Resultado")
        End If
        Cargando(False)
        detener = False
    End Sub
End Class