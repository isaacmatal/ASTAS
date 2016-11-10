Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Contabilidad_Ingreso_Manual_Libro_Ventas
    Dim Comando_ As New SqlCommand
    Dim Table As DataTable
    Dim sql As String
    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim Iniciando, ExisteDoc As Boolean
    Dim PorcIVA, PorcPercep As Double
    Dim RowsAffected As Integer
    'Dim oExcelApp = CreateObject("ADODB.Connection")
    Dim oExcelApp = CreateObject("EXCEL.Application")

    Private Sub Contabilidad_Ingreso_Manual_Libro_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA_CONTABLE.Value = multi.FechaActual_Servidor()
        Iniciando = True
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        CargaTipoDocumento()
        Me.cmbTipDoc.SelectedIndex = 0
        Iniciando = False
        PorcIVA = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 1")
        PorcPercep = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 2")
        Me.OpenFileDialogAbrir.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        VerificarPeriodo()
    End Sub

    Private Sub CargaTipoDocumento()
        Try
            sql = "SELECT TIPO_DOCUMENTO, DESCRIPCION_TIPO_DOCUMENTO FROM FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPAÑIA = " & Compañia
            'sql &= " AND TIPO_DOCUMENTO<=2"
            Comando_.CommandText = sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbTipDoc.DataSource = Table
            Me.cmbTipDoc.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTipDoc.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtSUBTOTAL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSUBTOTAL.TextChanged
        Dim iva As Double
        Dim subtotal As Double
        Dim total, retencion As Double

        If Me.txtSUBTOTAL.Text.Length > 0 Then
            subtotal = CDbl(Me.txtSUBTOTAL.Text)

            If (Me.cmbTipDoc.SelectedValue = 2) Or (Me.cmbTipDoc.SelectedValue = 4) Then
                iva = Math.Round(subtotal * (PorcIVA / 100), 2)
            Else
                iva = 0
            End If

            total = subtotal + iva
            If Val(Me.txtCompReten.Text) > 0 Then
                retencion = Math.Round(subtotal * ((PorcPercep / 100)), 2)
            Else
                retencion = 0
            End If

            Me.txtIVA.Text = Format(iva, "0.00")
            Me.txtTotFact.Text = Format(total, "0.00")
            Me.txtRetencion.Text = Format(retencion, "0.00")
        End If

    End Sub

    Private Sub txtIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA.TextChanged
        Dim iva As Double
        Dim subtotal As Double
        Dim total As Double

        If Me.txtIVA.Text.Length > 0 Then
            subtotal = Val(Me.txtSUBTOTAL.Text)
            iva = Val(Me.txtIVA.Text)
            total = subtotal + iva

            Me.txtTotFact.Text = Format(total, "0.00")
        End If

    End Sub

    Private Sub limpiartodo()
        Me.txtConcepto.Clear()
        Me.txtNoFact.Clear()
        Me.txtNomFact.Clear()
        Me.txtRegIva.Clear()
        Me.txtCliente.Clear()
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtRetencion.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.cmbTipDoc.SelectedIndex = 0
        ExisteDoc = False
    End Sub

    Private Sub bntNuevaFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevaFact.Click
        Me.limpiaCampos(0)
    End Sub
    'Limpia los campos del Formulario completo
    Private Sub limpiaCampos(ByVal opcion As Integer)
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.txtConcepto.Clear()
        Me.txtNoFact.Clear()
        Me.txtNomFact.Clear()
        Me.cmbBODEGA.Enabled = True
        ExisteDoc = False
    End Sub

    Private Sub btnGuardaFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaFactura.Click
        Try
            If Not validaCampos() Then
                Return
            End If
            If Not Me.ExisteDoc Then
                sql = "INSERT INTO [dbo].[FACTURACION_MANUAL_LIBRO_VENTAS]" & vbCrLf
                sql &= "           ([COMPAÑIA]" & vbCrLf
                sql &= "           ,[BODEGA]" & vbCrLf
                sql &= "           ,[NUMERO_FACTURA]" & vbCrLf
                sql &= "           ,[NOMBRE_FACTURA]" & vbCrLf
                sql &= "           ,[FECHA_FACTURA]" & vbCrLf
                sql &= "           ,[TIPO_DOCUMENTO]" & vbCrLf
                sql &= "           ,[EXENTO]" & vbCrLf
                sql &= "           ,[SUB_TOTAL]" & vbCrLf
                sql &= "           ,[IVA]" & vbCrLf
                sql &= "           ,[TOTAL_IVA]" & vbCrLf
                sql &= "           ,[RETENCION]" & vbCrLf
                sql &= "           ,[TOTAL_FACTURA]" & vbCrLf
                sql &= "           ,[ANULADA]" & vbCrLf
                sql &= "           ,[NUMERO_PARTIDA]" & vbCrLf
                sql &= "           ,[CONCEPTO]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION_FECHA]" & vbCrLf
                sql &= "           ,[CAJA]" & vbCrLf
                sql &= "           ,[REGISTRO]" & vbCrLf
                sql &= "           ,[COMPROB_RETENCION]" & vbCrLf
                sql &= "           ,[DUI]" & vbCrLf
                sql &= "           ,[NIT])" & vbCrLf
                sql &= "     VALUES" & vbCrLf
                sql &= "           (" & Compañia & vbCrLf
                sql &= "           ," & Me.cmbBODEGA.SelectedValue & vbCrLf
                sql &= "           ," & Me.txtNoFact.Text & vbCrLf
                sql &= "           ,'" & Me.txtNomFact.Text & "'" & vbCrLf
                sql &= "           ,'" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "           ," & Me.cmbTipDoc.SelectedValue & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ," & IIf(Me.cmbTipDoc.SelectedValue = 4, "-", "") & Me.txtSUBTOTAL.Text & vbCrLf
                sql &= "           ," & PorcIVA & vbCrLf
                sql &= "           ," & IIf(Me.cmbTipDoc.SelectedValue = 4, "-", "") & Me.txtIVA.Text & vbCrLf
                sql &= "           ," & IIf(Me.cmbTipDoc.SelectedValue = 4, "-", "") & Me.txtRetencion.Text & vbCrLf
                sql &= "           ," & IIf(Me.cmbTipDoc.SelectedValue = 4, "-", "") & Me.txtTotFact.Text & vbCrLf
                sql &= "           ," & CInt(Me.chkAnulada.Checked) & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,'" & Me.txtConcepto.Text & "'" & vbCrLf
                sql &= "           ,'" & Usuario & "'" & vbCrLf
                sql &= "           ,GETDATE()" & vbCrLf 'USUARIO_CREACION_FECHA
                sql &= "           ,'" & Usuario & "'" & vbCrLf
                sql &= "           ,GETDATE()" & vbCrLf 'USUARIO_EDICION_FECHA
                sql &= "           ," & Val(Me.txtCaja.Text) & vbCrLf
                sql &= "           ,'" & Me.txtRegIva.Text & "'" & vbCrLf
                sql &= "           ," & Val(Me.txtCompReten.Text) & vbCrLf
                sql &= "           ,'" & Me.txtDUI.Text & "'" & vbCrLf
                sql &= "           ,'" & Me.txtNIT.Text & "')" & vbCrLf
                RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(sql))
            Else
                sql = "UPDATE [dbo].[FACTURACION_MANUAL_LIBRO_VENTAS]" & vbCrLf
                sql &= "   SET [NOMBRE_FACTURA] = '" & Me.txtNomFact.Text & "'" & vbCrLf
                sql &= "      ,[FECHA_FACTURA] = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "      ,[EXENTO] = 0" & vbCrLf
                sql &= "      ,[SUB_TOTAL] = " & Me.txtSUBTOTAL.Text & vbCrLf
                sql &= "      ,[IVA] = " & PorcIVA & vbCrLf
                sql &= "      ,[TOTAL_IVA] = " & Me.txtIVA.Text & vbCrLf
                sql &= "      ,[RETENCION] = " & Me.txtRetencion.Text & vbCrLf
                sql &= "      ,[TOTAL_FACTURA] = " & Me.txtTotFact.Text & vbCrLf
                sql &= "      ,[ANULADA] = " & CInt(Me.chkAnulada.Checked) & vbCrLf
                sql &= "      ,[NUMERO_PARTIDA] = 0" & vbCrLf
                sql &= "      ,[CONCEPTO] = '" & Me.txtConcepto.Text & "'" & vbCrLf
                sql &= "      ,[USUARIO_CREACION] = '" & Usuario & "'" & vbCrLf
                sql &= "      ,[USUARIO_CREACION_FECHA] = GETDATE()" & vbCrLf
                sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
                sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
                sql &= "      ,[REGISTRO] = '" & Me.txtRegIva.Text & "'" & vbCrLf
                sql &= "      ,[CAJA] = " & Val(Me.txtCaja.Text) & vbCrLf
                sql &= "      ,[COMPROB_RETENCION] = " & Val(Me.txtCompReten.Text) & vbCrLf
                sql &= "      ,[DUI] = '" & Me.txtDUI.Text & "'" & vbCrLf
                sql &= "      ,[NIT] = '" & Me.txtNIT.Text & "'" & vbCrLf
                sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
                sql &= "  AND BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                sql &= "  AND TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue & vbCrLf
                sql &= "  AND NUMERO_FACTURA = " & Me.txtNoFact.Text
                RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(sql))
            End If
            If RowsAffected > 0 Then
                If Not Iniciando Then
                    MsgBox(Me.cmbTipDoc.Text & " Guardado con Exito", MsgBoxStyle.Information, Me.Text)
                End If
                limpiartodo()
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Ingreso Manual LV")
        End Try
    End Sub

    Private Sub txtNoFact_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFact.KeyPress, txtCliente.KeyPress, txtCompReten.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If Val(Me.txtNoFact.Text & e.KeyChar) > 2147483647.0 Then
            e.KeyChar = Nothing
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNoFact_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoFact.LostFocus
        If Val(Me.txtNoFact.Text) > 0 Then
            sql = "SELECT [NOMBRE_FACTURA]" & vbCrLf
            sql &= "      ,[FECHA_FACTURA]" & vbCrLf
            sql &= "      ,[EXENTO]" & vbCrLf
            sql &= "      ,[SUB_TOTAL]" & vbCrLf
            sql &= "      ,[TOTAL_IVA]" & vbCrLf
            sql &= "      ,[RETENCION]" & vbCrLf
            sql &= "      ,[TOTAL_FACTURA]" & vbCrLf
            sql &= "      ,[ANULADA]" & vbCrLf
            sql &= "      ,[CONCEPTO]" & vbCrLf
            sql &= "      ,[REGISTRO]" & vbCrLf
            sql &= "  FROM [dbo].[FACTURACION_MANUAL_LIBRO_VENTAS] " & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            sql &= "   AND TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue & vbCrLf
            sql &= "   AND NUMERO_FACTURA = " & Me.txtNoFact.Text
            Table = jClass.obtenerDatos(New SqlCommand(sql))
            If Table.Rows.Count > 0 Then
                Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_FACTURA").ToString()
                Me.dpFECHA_CONTABLE.Value = Table.Rows(0).Item("FECHA_FACTURA")
                Me.txtSUBTOTAL.Text = Format((Table.Rows(0).Item("SUB_TOTAL")), "0.00")
                Me.txtIVA.Text = Format((Table.Rows(0).Item("TOTAL_IVA")), "0.00")
                Me.txtRetencion.Text = Format((Table.Rows(0).Item("RETENCION")), "0.00")
                Me.txtTotFact.Text = Format((Table.Rows(0).Item("TOTAL_FACTURA")), "0.00")
                Me.chkAnulada.Checked = CBool(Table.Rows(0).Item("ANULADA"))
                Me.txtConcepto.Text = Table.Rows(0).Item("CONCEPTO").ToString()
                Me.txtRegIva.Text = Table.Rows(0).Item("REGISTRO").ToString()
                ExisteDoc = True
            Else
                ExisteDoc = False
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está Seguro de Eliminar " & Me.cmbTipDoc.Text & " No." & Me.txtNoFact.Text & "?", MsgBoxStyle.YesNo, "Cnfirmación") = MsgBoxResult.Yes Then
            sql = "DELETE FROM [dbo].[FACTURACION_MANUAL_LIBRO_VENTAS] " & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            sql &= "   AND TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue & vbCrLf
            sql &= "   AND NUMERO_FACTURA = " & Me.txtNoFact.Text
            RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(sql))
            If RowsAffected > 0 Then
                MsgBox(Me.cmbTipDoc.Text & " Eliminado con Exito", MsgBoxStyle.Information, Me.Text)
                limpiartodo()
            End If
        End If
    End Sub

    Private Function validaCampos() As Boolean
        Dim msj As String = String.Empty
        Dim Result As Boolean = True
        If Val(Me.txtNoFact.Text) = 0 Then
            msj = " - N° Documento" & vbCrLf
        End If
        If Me.txtNomFact.Text.Length = 0 Then
            msj &= " - Nombre Factura" & vbCrLf
        End If
        If Me.txtConcepto.Text.Length = 0 Then
            msj &= " - Concepto" & vbCrLf
        End If
        If Val(Me.txtSUBTOTAL.Text) = 0 Then
            msj &= " - Subtotal"
        End If
        If Val(Me.txtTotFact.Text) > 226.0 Then
            'If Me.txtNIT.Text.Trim.Replace("-", "").Length = 0 Then
            '    msj &= " - NIT"
            'End If
            If Me.txtRegIva.Text.Length = 0 Then
                If Me.txtDUI.Text.Trim.Replace("-", "").Length = 0 Then
                    msj &= " - DUI"
                End If
            End If
        End If
        If msj.Length > 0 Then
            MsgBox("Hay campos vacíos" & vbCrLf & msj, MsgBoxStyle.Information, "Validación doc.#" & Me.txtNoFact.Text)
            Result = False
        End If
        Return Result
    End Function

    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        If Me.txtCliente.Text.Length > 0 Then
            Try
                sql = "SELECT NOMBRE, NRC, DUI, NIT FROM CONTABILIDAD_CATALOGO_CLIENTES WHERE COMPAÑIA = " & Compañia & " AND CLIENTE = " & Me.txtCliente.Text
                Table = jClass.obtenerDatos(New SqlCommand(sql))
                If Table.Rows.Count > 0 Then
                    Me.txtRegIva.Text = Table.Rows(0).Item("NRC")
                    Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE")
                    Me.txtDUI.Text = Table.Rows(0).Item("DUI")
                    Me.txtNIT.Text = Table.Rows(0).Item("NIT")
                Else
                    MsgBox("Código no encontrado", MsgBoxStyle.Information, "Cliente")
                End If
            Catch ex As Exception
                jClass.msjError(ex, "Ingreso Manual Libro Ventas")
            End Try
        End If
    End Sub

    Private Sub validaCampoDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSUBTOTAL.KeyPress, txtRetencion.KeyPress, txtIVA.KeyPress
        Dim cadena As String = sender.Text
        Dim Ocurrencias As Boolean
        Ocurrencias = cadena.Contains(".")
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> ControlChars.Tab And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> Convert.ToChar(Keys.Delete) And e.KeyChar <> "-" Then
            If e.KeyChar = "." Then
                If Ocurrencias Then
                    MsgBox("Ya hay un punto decimal.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            Else
                If Not IsNumeric(e.KeyChar) Then
                    MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbTipDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipDoc.SelectedIndexChanged
        If Not Iniciando Then
            If Me.cmbTipDoc.SelectedValue = 5 Then
                Me.Label6.Visible = True
                Me.txtCaja.Visible = True
            Else
                Me.Label6.Visible = False
                Me.txtCaja.Visible = False
            End If
            If Me.cmbTipDoc.SelectedValue = 2 Then
                Me.Label7.Visible = True
                Me.txtCompReten.Visible = True
            Else
                Me.Label7.Visible = False
                Me.txtCompReten.Visible = False
            End If
        End If
    End Sub

    Private Sub ListarHojasExcel(ByVal XLSFile As String)
        Try
            While Me.cmbSheets.Items.Count > 0
                Me.cmbSheets.Items.RemoveAt(0)
            End While
            oExcelApp.WorkBooks.Open(XLSFile)
            Dim oExcelSheets = oExcelApp.WorkBooks(1).Sheets
            Dim CntSheets As Integer = oExcelSheets.Count
            For i As Integer = 1 To CntSheets
                Me.cmbSheets.Items.Add(oExcelSheets(i).Name)
            Next
            oExcelApp.WorkBooks(1).Close()
            Me.cmbSheets.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnBuscarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarExcel.Click
        Dim Result As Integer
        Result = Me.OpenFileDialogAbrir.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            Me.lblArchivoExcel.Text = Me.OpenFileDialogAbrir.FileName
            ListarHojasExcel(Me.lblArchivoExcel.Text)
        Else
            MsgBox("Usuario ha CANCELADO el proceso.", MsgBoxStyle.Information, "Busqueda Archivo")
        End If
    End Sub

    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        LlenaGrid_Excel(Me.cmbSheets.Text)
        Me.lblArchivoExcel.Text = ""
        While Me.cmbSheets.Items.Count > 0
            Me.cmbSheets.Items.RemoveAt(0)
        End While
    End Sub

    Private Sub LlenaGrid_Excel(ByVal Hoja_Excel)
        Dim Conexion_Excel As New OleDbConnection
        Dim Comando_Excel As New OleDbCommand
        Dim DataAdapter_Excel As New OleDbDataAdapter
        Dim Table As New DataTable
        Dim CadenaCnn, Concepto As String
        Dim CodBodega, CodClie, Tipodoc, Docto, errores As Integer
        Dim CarAbo As String = String.Empty
        Iniciando = True
        Concepto = ""
        Try
            'CadenaCnn = "Provider=Microsoft.Jet.Oledb.4.0; data source= " + Me.lblArchivoExcel.Text + " ;Extended properties=Excel 8.0;"
            CadenaCnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.lblArchivoExcel.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
            Conexion_Excel = New OleDbConnection(CadenaCnn)
            Conexion_Excel.Open()
            sql = "SELECT CODBODEGA" & vbCrLf
            sql &= ", CODCLIENTE" & vbCrLf
            sql &= ", COMPROBANTE" & vbCrLf
            sql &= ", SUBTOTAL" & vbCrLf
            sql &= ", IVA" & vbCrLf
            sql &= ", RETENCION" & vbCrLf
            sql &= ", TIPODOC" & vbCrLf
            sql &= ", FECHA" & vbCrLf
            sql &= ", NOMBRE" & vbCrLf
            sql &= ", REGISTRO" & vbCrLf
            sql &= ", CONCEPTO" & vbCrLf
            sql &= ", ANULADO" & vbCrLf
            sql &= ", CAJA" & vbCrLf
            sql &= ", DUI" & vbCrLf
            sql &= ", NIT" & vbCrLf
            sql &= " FROM [" & Hoja_Excel & "$]"
            Comando_Excel = New OleDbCommand(Sql, Conexion_Excel)
            DataAdapter_Excel.SelectCommand = Comando_Excel
            DataAdapter_Excel.Fill(Table)
            Conexion_Excel.Close()
            Conexion_Excel.Dispose()
            If Table.Rows.Count = 0 Then
                MsgBox("¡El archivo de Excel está vacío! Verifique...", MsgBoxStyle.Critical, "Archivo Excel")
                Return
            End If
            Iniciando = True
            For i As Integer = 0 To Table.Rows.Count - 1
                If Not IsDBNull(Table.Rows(i).Item("CODBODEGA")) Then
                    If ValidaBodega(Val(Table.Rows(i).Item("CODBODEGA"))) Then
                        CodBodega = CInt(Table.Rows(i).Item("CODBODEGA"))
                    Else
                        CodBodega = 0
                    End If
                Else
                    CodBodega = 0
                End If
                If Not IsDBNull(Table.Rows(i).Item("CODCLIENTE")) Then
                    If ValidaCliente(Val(Table.Rows(i).Item("CODCLIENTE"))) Then
                        CodClie = Table.Rows(i).Item("CODCLIENTE")
                        Me.txtCliente.Text = CodClie
                        Me.txtCliente_LostFocus(Me.txtCliente, New System.EventArgs)
                    Else
                        CodClie = 0
                    End If
                Else
                    CodClie = 0
                End If
                If Not IsDBNull(Table.Rows(i).Item("TIPODOC")) Then
                    If ValidaTipoDoc(Val(Table.Rows(i).Item("TIPODOC"))) Then
                        Tipodoc = Table.Rows(i).Item("TIPODOC")
                    Else
                        Tipodoc = 0
                    End If
                Else
                    Tipodoc = 0
                End If
                If Not IsDBNull(Table.Rows(i).Item("COMPROBANTE")) Then
                    If IsNumeric(Table.Rows(i).Item("COMPROBANTE")) Then
                        Docto = Table.Rows(i).Item("COMPROBANTE")
                    Else
                        Docto = 0
                    End If
                Else
                    Docto = 0
                End If
                If CodBodega = 0 Or Tipodoc = 0 Or Docto = 0 Then
                    Concepto &= "Linea: " & (i + 2).ToString() & vbCrLf
                    Concepto &= IIf(CodBodega = 0, "  CODIGO BODEGA INCORRECTO" & vbCrLf, "")
                    Concepto &= IIf(Tipodoc = 0, "  TIPO DOCUMENTO INCORRECTO" & vbCrLf, "")
                    Concepto &= IIf(Docto = 0, "  NUMERO COMPROBANTE INCORRECTO" & vbCrLf, "")
                    errores += 1
                Else
                    ExisteDoc = ValidaDoc(CodBodega, Tipodoc, Docto)
                    Me.cmbBODEGA.SelectedValue = CodBodega
                    Me.cmbTipDoc.SelectedValue = Tipodoc
                    Me.txtNoFact.Text = Docto
                    If IsDBNull(Table.Rows(i).Item("SUBTOTAL")) Then
                        Me.txtSUBTOTAL.Text = "0.00"
                    Else
                        Me.txtSUBTOTAL.Text = Format(Table.Rows(i).Item("SUBTOTAL"), "0.00")
                    End If
                    If IsDBNull(Table.Rows(i).Item("IVA")) Then
                        Me.txtIVA.Text = "0.00"
                    Else
                        Me.txtIVA.Text = Format(Table.Rows(i).Item("IVA"), "0.00")
                    End If
                    If IsDBNull(Table.Rows(i).Item("RETENCION")) Then
                        Me.txtRetencion.Text = "0.00"
                    Else
                        Me.txtRetencion.Text = Format(Table.Rows(i).Item("RETENCION"), "0.00")
                    End If
                    If IsDBNull(Table.Rows(i).Item("ANULADO")) Then
                        Me.chkAnulada.Checked = False
                    Else
                        Me.chkAnulada.Checked = IIf(Table.Rows(i).Item("ANULADO").ToString() = "S", True, False)
                    End If
                    Me.txtTotFact.Text = Format(Val(Me.txtSUBTOTAL.Text) + Val(Me.txtIVA.Text) + Val(Me.txtRetencion.Text), "0.00")
                    If IsDBNull(Table.Rows(i).Item("FECHA")) Then
                        Me.dpFECHA_CONTABLE.Value = Now()
                    Else
                        Me.dpFECHA_CONTABLE.Value = CDate(Table.Rows(i).Item("FECHA"))
                    End If
                    If CodClie = 0 Then
                        If IsDBNull(Table.Rows(i).Item("NOMBRE")) Then
                            Me.txtNomFact.Text = ""
                        Else
                            Me.txtNomFact.Text = Table.Rows(i).Item("NOMBRE").ToString().Replace("'", "*")
                        End If
                        If IsDBNull(Table.Rows(i).Item("REGISTRO")) Then
                            Me.txtRegIva.Text = ""
                        Else
                            Me.txtRegIva.Text = Table.Rows(i).Item("REGISTRO").ToString().Replace("'", "*")
                        End If
                    End If
                    If IsDBNull(Table.Rows(i).Item("CONCEPTO")) Then
                        Me.txtConcepto.Text = "Sin Concepto"
                    Else
                        Me.txtConcepto.Text = Table.Rows(i).Item("CONCEPTO").ToString().Replace("'", "*")
                    End If
                    If IsDBNull(Table.Rows(i).Item("CAJA")) Then
                        Me.txtCaja.Text = ""
                    Else
                        Me.txtCaja.Text = Table.Rows(i).Item("CAJA").ToString()
                    End If
                    If IsDBNull(Table.Rows(i).Item("DUI")) Then
                        Me.txtDUI.Text = ""
                    Else
                        Me.txtDUI.Text = Table.Rows(i).Item("DUI").ToString()
                    End If
                    If IsDBNull(Table.Rows(i).Item("NIT")) Then
                        Me.txtNIT.Text = ""
                    Else
                        Me.txtNIT.Text = Table.Rows(i).Item("NIT").ToString()
                    End If
                End If
                Me.btnGuardaFactura.PerformClick()
            Next
            If errores > 0 Then
                MsgBox("Hay datos incorrectos en el archivo" & vbCrLf & Concepto, MsgBoxStyle.Information, "Archivo Excel")
            Else
                MsgBox("Proceso de Carga Finalizado", MsgBoxStyle.Information, "Archivo Excel")
            End If
            Iniciando = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Carga Archivo Excel")
            Conexion_Excel.Close()
            Conexion_Excel.Dispose()
        End Try
    End Sub

    Private Function ValidaDoc(ByVal Bodega As Integer, ByVal TipoDoc As Integer, ByVal Comprob As Integer) As Boolean
        Dim Result As Boolean = False
        sql = "SELECT COUNT(BODEGA) AS CANTREG" & vbCrLf
        sql &= "  FROM [dbo].[FACTURACION_MANUAL_LIBRO_VENTAS] " & vbCrLf
        sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        sql &= "   AND BODEGA = " & Bodega & vbCrLf
        sql &= "   AND TIPO_DOCUMENTO = " & TipoDoc & vbCrLf
        sql &= "   AND NUMERO_FACTURA = " & Comprob
        If jClass.obtenerEscalar(sql) > 0 Then
            Result = True
        End If
        Return Result
    End Function

    Private Function ValidaBodega(ByVal CodBodega As Integer) As Boolean
        Dim Result As Boolean = False
        If CodBodega > 0 Then
            Sql = "SELECT COUNT(BODEGA) AS CANTREG" & vbCrLf
            Sql &= "  FROM [dbo].[INVENTARIOS_CATALOGO_BODEGAS]" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND BODEGA = " & CodBodega
            If jClass.obtenerEscalar(Sql) > 0 Then
                Result = True
            End If
        End If
        Return Result
    End Function

    Private Function ValidaCliente(ByVal CodClie As Integer) As Boolean
        Dim Result As Boolean = False
        If CodClie > 0 Then
            sql = "SELECT COUNT(CLIENTE) AS CANTREG" & vbCrLf
            sql &= "  FROM [dbo].[CONTABILIDAD_CATALOGO_CLIENTES]" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND CLIENTE = " & CodClie
            If jClass.obtenerEscalar(Sql) > 0 Then
                Result = True
            End If
        End If
        Return Result
    End Function

    Private Function ValidaTipoDoc(ByVal TipoDoc As Integer) As Boolean
        Dim Result As Boolean = False
        If TipoDoc > 0 Then
            Sql = "SELECT COUNT(TIPO_DOCUMENTO) AS CANTREG" & vbCrLf
            Sql &= "  FROM [dbo].[FACTURACION_CATALOGO_TIPO_DOCUMENTO]" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND TIPO_DOCUMENTO = " & TipoDoc
            If jClass.obtenerEscalar(Sql) > 0 Then
                Result = True
            End If
        End If
        Return Result
    End Function

    Private Sub txtCompReten_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompReten.TextChanged
        If Val(Me.txtCompReten.Text) > 0 Then
            Me.txtRetencion.Text = Format(Math.Round(Val(Me.txtSUBTOTAL.Text) * (PorcPercep / 100), 2, MidpointRounding.AwayFromZero), "0.00")
        Else
            Me.txtRetencion.Text = "0.00"
        End If
    End Sub

    Private Sub VerificarPeriodo()
        Dim periodo_cerrado As Integer
        periodo_cerrado = jClass.obtenerEscalar("SELECT COUNT(COMPAÑIA) FROM FACTURACION_MANUAL_LIBRO_VENTAS WHERE COMPAÑIA = " & Compañia & " AND MONTH(FECHA_FACTURA) = " & Me.dpFECHA_CONTABLE.Value.Month.ToString() & " AND YEAR(FECHA_FACTURA) = " & Me.dpFECHA_CONTABLE.Value.Year.ToString() & " AND PERIODO_CERRADO = 1")
        If periodo_cerrado > 0 Then
            MsgBox("El período " & Format(Me.dpFECHA_CONTABLE.Value, "MMMM/yyyy") & " ya fue cerrado.", MsgBoxStyle.Information, "Validación Período")
            Me.btnGuardaFactura.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.btnImportarExcel.Enabled = False
        Else
            Me.btnGuardaFactura.Enabled = True
            Me.btnEliminar.Enabled = True
            Me.btnImportarExcel.Enabled = True
        End If
    End Sub

    Private Sub dpFECHA_CONTABLE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFECHA_CONTABLE.ValueChanged
        If Not Iniciando Then
            VerificarPeriodo()
        End If
    End Sub
End Class