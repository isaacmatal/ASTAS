Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Contabilidad_Ingreso_Manual_Libro_Compras
    Dim Sql As String
    Dim Iniciando, CargaDetalle As Boolean
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim Accion As String = "I"
    Dim Linea As Integer = 0
    Dim IVA, Percepcion As Double
    Dim TipoDoc(5) As String
    Dim TipoProv As Integer
    Dim oExcelApp = CreateObject("EXCEL.Application")
    'Dim oExcelApp = CreateObject("ADODB.Connection")

    Private Sub Contabilidad_Ingreso_Manual_Libro_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        TipoDoc(0) = "N/A"
        TipoDoc(1) = "FAC"
        TipoDoc(2) = "CCF"
        TipoDoc(3) = "ND"
        TipoDoc(4) = "NC"
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBodegas(Compañia, 4)
        CargaTipoDocumento(Compañia)
        Me.cmbTipoDocumento.SelectedValue = 2
        Iniciando = False
        Me.CargaPorcentajeImpuestos(1)
        Me.OpenFileDialogAbrir.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        VerificarPeriodo()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compañia_Value = Compañia
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
            Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
            BuscarProveedor(Compañia, Me.TxtProveedor_Codigo.Text)
        Else
            BuscarProveedor(0, 0)
            Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""
    End Sub

    Private Sub TxtProveedor_Codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProveedor_Codigo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Me.cmbTipoDocumento.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub TxtProveedor_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.TextChanged
        If Me.TxtProveedor_Codigo.Text.Length > 0 Then
            Try
                Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
                Sql = Sql & " WHERE ESTADO = 1 AND COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text
                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                If Table.Rows.Count = 0 Then
                    MsgBox("¡No se encontró ningun proveedor!", MsgBoxStyle.Question, "Mensaje")
                    LimpiaCampos()
                Else
                    Me.TxtProveedor_Codigo.Text = Table.Rows(0).Item(0)
                    Me.TxtProveedor_NombreLegal.Text = Table.Rows(0).Item(1)
                    Me.TxtProveedor_NombreComercial.Text = Table.Rows(0).Item(2)
                    Me.TxtProveedor_RegistroFiscal.Text = Table.Rows(0).Item(3)
                    Me.TxtProveedor_Nit.Text = Table.Rows(0).Item(4)
                    Me.TxtProveedor_Direccion.Text = Table.Rows(0).Item(5)
                    TipoProv = CInt(Table.Rows(0).Item(6))
                    If Table.Rows(0).Item(6) = 4 Then
                        Me.cmbTipoDocumento.SelectedValue = 1
                    Else
                        Me.cmbTipoDocumento.SelectedValue = 2
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            LimpiaCampos()
        End If
    End Sub

    Private Sub BuscarProveedor(ByVal Compañia As Integer, ByVal Proveedor As Integer)
        Try
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND PROVEEDOR = " & Proveedor
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            If Table.Rows.Count > 0 Then
                Me.TxtProveedor_NombreLegal.Text = Table.Rows(0).Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = Table.Rows(0).Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = Table.Rows(0).Item("NRC")
                Me.TxtProveedor_Nit.Text = Table.Rows(0).Item("NIT")
                Me.TxtProveedor_Direccion.Text = Table.Rows(0).Item("DIRECCION")
                TipoProv = Table.Rows(0).Item("TIPO_PROVEEDOR")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub LimpiaCampos()
        Me.TxtProveedor_Codigo.Clear()
        Me.TxtProveedor_NombreLegal.Clear()
        Me.TxtProveedor_NombreComercial.Clear()
        Me.TxtProveedor_RegistroFiscal.Clear()
        Me.TxtProveedor_Nit.Clear()
        Me.TxtProveedor_Direccion.Clear()
        Me.txtDocumento.Clear()
        Me.txtsubtotal.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtPercepcion.Text = "0.00"
        Me.txtTotalFact.Text = "0.00"
        Me.txtTotal.Text = "0.00"
        Me.txtExento.Text = "0.00"
    End Sub

    Private Sub CargaBodegas(ByVal Compañia As Integer, ByVal Bandera As Integer)
        Try
            Sql = "SELECT [BODEGA] AS [Bodega], [DESCRIPCION_BODEGA] AS [Descripción] FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPorcentajeImpuestos(ByVal Constante As Integer)
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONSTANTES "
            Sql &= Compañia
            Sql &= ", " & Constante
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            If Constante = 1 Then
                IVA = Table.Rows(0).Item(0)
            ElseIf Constante = 2 Then
                Percepcion = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoDocumento(ByVal Compañia As Integer)
        Try
            Sql = "SELECT TIPO_DOCUMENTO, DESCRIPCION_TIPO_DOCUMENTO FROM dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPAÑIA = " & Compañia
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbTipoDocumento.DataSource = Table
            Me.cmbTipoDocumento.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTipoDocumento.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub calculoTotal()
        Dim subtotal, conIVA, Percibido As Double
        subtotal = CDbl(Me.txtsubtotal.Text)

        If Me.cmbTipoDocumento.SelectedValue > 1 Then
            conIVA = Math.Round(subtotal * (IVA / 100), 2)
            Me.txtIVA.Text = conIVA
            Me.txtTotal.Text = Format((subtotal + conIVA + Val(Me.txtExento.Text)), "0.00")
            If subtotal > 100 Then  'Solamente para compras mayores a $100 se realizará percepción.
                Percibido = Math.Round(subtotal * (Por_Percibido / 100), 2)
                Me.txtPercepcion.Text = Format(Percibido, "0.00")
                Me.txtTotalFact.Text = Format((subtotal + conIVA + Percibido + Val(Me.txtExento.Text)), "0.00")
            Else
                Percibido = 0.0
                Me.txtPercepcion.Text = "0.00"
                Me.txtTotalFact.Text = Format((subtotal + conIVA + Val(Me.txtExento.Text)), "0.00")
            End If
        Else
            Me.txtIVA.Text = "0.00"
            Me.txtTotal.Text = Format(subtotal, "0.00")
            Me.txtPercepcion.Text = "0.00"
            Me.txtTotalFact.Text = Format(subtotal, "0.00")
        End If
    End Sub

    Private Sub btnGuardarEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEncabezado.Click
        If Val(Me.txtDocumento.Text.Trim) = 0 Then
            MessageBox.Show("Debe ingresar el número de documento", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtDocumento.Focus()
            Return
        End If

        If Val(Me.txtsubtotal.Text) = 0 Then
            MessageBox.Show("Debe ingresar el subtotal", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtsubtotal.Focus()
            Return
        End If
        If CargaDetalle Then
            Sql = "UPDATE [dbo].[CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL]" & vbCrLf
            Sql &= "   SET [FECHA_CONTABLE] = '" & Format(Me.dpFECHA_OC.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "      ,[SUBTOTAL] = " & IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtsubtotal.Text) & vbCrLf
            Sql &= "      ,[IVA] = " & IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtIVA.Text) & vbCrLf
            Sql &= "      ,[TOTAL] = " & IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtTotalFact.Text) & vbCrLf
            Sql &= "      ,[RETENCION] = " & IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtPercepcion.Text) & vbCrLf
            Sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            Sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            Sql &= "      ,[EXENTOS] = " & Me.txtExento.Text & vbCrLf
            Sql &= "      ,[PERIODO_LIBRO] = '" & Format(Me.dpPeriodo.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia
            Sql &= "   AND BODEGA = " & Me.cmbBODEGA.SelectedValue
            Sql &= "   AND PROVEEDOR = " & Me.TxtProveedor_Codigo.Text
            Sql &= "   AND DOCUMENTO = " & Me.txtDocumento.Text
            Sql &= "   AND COD_TIPO_DOC = " & Me.cmbTipoDocumento.SelectedValue
        Else
            Sql = "INSERT INTO [dbo].[CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL]" & vbCrLf
            Sql &= "           ([COMPAÑIA]" & vbCrLf
            Sql &= "           ,[BODEGA]" & vbCrLf
            Sql &= "           ,[FECHA_CONTABLE]" & vbCrLf
            Sql &= "           ,[DOCUMENTO]" & vbCrLf
            Sql &= "           ,[PROVEEDOR]" & vbCrLf
            Sql &= "           ,[SUBTOTAL]" & vbCrLf
            Sql &= "           ,[IVA]" & vbCrLf
            Sql &= "           ,[TOTAL]" & vbCrLf
            Sql &= "           ,[RETENCION]" & vbCrLf
            Sql &= "           ,[EXCLUIDOS]" & vbCrLf
            Sql &= "           ,[NOTA_CREDITO]" & vbCrLf
            Sql &= "           ,[NUMERO_NC]" & vbCrLf
            Sql &= "           ,[COD_TIPO_DOC]" & vbCrLf
            Sql &= "           ,[TIPO_DOC]" & vbCrLf
            Sql &= "           ,[NOTA_DEBITO]" & vbCrLf
            Sql &= "           ,[NUMERO_ND]" & vbCrLf
            Sql &= "           ,[USUARIO_CREACION]" & vbCrLf
            Sql &= "           ,[EXENTOS]" & vbCrLf
            Sql &= "           ,[PERIODO_LIBRO])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           (" & Compañia & vbCrLf
            Sql &= "           ," & Me.cmbBODEGA.SelectedValue & vbCrLf
            Sql &= "           ,'" & Format(Me.dpFECHA_OC.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ," & Me.txtDocumento.Text & vbCrLf
            Sql &= "           ," & Me.TxtProveedor_Codigo.Text & vbCrLf
            Sql &= "           ," & IIf(Me.TxtProveedor_RegistroFiscal.Text.Length = 0, 0, IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtsubtotal.Text)) & vbCrLf
            Sql &= "           ," & IIf(Me.TxtProveedor_RegistroFiscal.Text.Length = 0, 0, IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtIVA.Text)) & vbCrLf
            Sql &= "           ," & IIf(Me.TxtProveedor_RegistroFiscal.Text.Length = 0, 0, IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtTotalFact.Text)) & vbCrLf
            Sql &= "           ," & IIf(Me.TxtProveedor_RegistroFiscal.Text.Length = 0, 0, IIf(Me.cmbTipoDocumento.SelectedValue = 4, "-", "") & Val(Me.txtPercepcion.Text)) & vbCrLf
            Sql &= "           ," & IIf(Me.TxtProveedor_RegistroFiscal.Text.Length = 0, Val(Me.txtTotalFact.Text), 0) & vbCrLf
            Sql &= "           ," & IIf(Me.cmbTipoDocumento.SelectedValue = 4, 1, 0) & vbCrLf
            Sql &= "           ,0" & vbCrLf
            Sql &= "           ," & Me.cmbTipoDocumento.SelectedValue & vbCrLf
            Sql &= "           ,'" & TipoDoc(Me.cmbTipoDocumento.SelectedValue) & "'" & vbCrLf
            Sql &= "           ," & IIf(Me.cmbTipoDocumento.SelectedValue = 3, 1, 0) & vbCrLf
            Sql &= "           ,0" & vbCrLf
            Sql &= "           ,'" & Usuario & "'" & vbCrLf
            Sql &= "           ," & Me.txtExento.Text & vbCrLf
            Sql &= "           ,'" & Format(Me.dpPeriodo.Value, "dd/MM/yyyy") & "')"
        End If
        If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            If Not Iniciando Then
                MsgBox("Información Guardada con éxito.", MsgBoxStyle.Information, "Información")
            End If
        Else
            If Not Iniciando Then
                MsgBox("No se guardó la información.", MsgBoxStyle.Information, "Error")
            End If
        End If
        LimpiaCampos()
        Me.cmbTipoDocumento.SelectedIndex = 2
        Me.TxtProveedor_Codigo.Focus()
        CargaDetalle = False
    End Sub

    Private Sub cmbTipoDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoDocumento.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocumento.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
        If Val(Me.txtDocumento.Text & e.KeyChar) > 2147483647 Then
            e.KeyChar = Nothing
        End If
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtDocumento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.LostFocus
        If Me.TxtProveedor_Codigo.Text.Length > 0 And Me.txtDocumento.Text.Length > 0 Then
            Sql = "SELECT  [FECHA_CONTABLE], [SUBTOTAL], [IVA], [TOTAL], [RETENCION], [EXENTOS], [PERIODO_LIBRO] FROM CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND PROVEEDOR = " & Me.TxtProveedor_Codigo.Text & " AND DOCUMENTO = " & Me.txtDocumento.Text & " AND COD_TIPO_DOC = " & Me.cmbTipoDocumento.SelectedValue
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            If Table.Rows.Count > 0 Then
                Me.dpFECHA_OC.Value = CDate(Table.Rows(0).Item("FECHA_CONTABLE"))
                Me.txtsubtotal.Text = Format(Table.Rows(0).Item("SUBTOTAL"), "0.00")
                Me.txtIVA.Text = Format(Table.Rows(0).Item("IVA"), "0.00")
                Me.txtTotal.Text = Format(Table.Rows(0).Item("SUBTOTAL") + Table.Rows(0).Item("IVA"), "0.00")
                Me.txtPercepcion.Text = Format(Table.Rows(0).Item("RETENCION"), "0.00")
                Me.txtTotalFact.Text = Format(Table.Rows(0).Item("TOTAL"), "0.00")
                Me.txtExento.Text = Format(Table.Rows(0).Item("EXENTOS"), "0.00")
                Me.dpPeriodo.Value = CDate(Table.Rows(0).Item("PERIODO_LIBRO"))
                CargaDetalle = True
            End If
        End If
    End Sub

    Private Sub txtsubtotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsubtotal.KeyPress, txtIVA.KeyPress, txtExento.KeyPress, txtPercepcion.KeyPress
        If e.KeyChar = "." And sender.Text.Contains(".") Then
            e.KeyChar = Nothing
        Else
            If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
                e.KeyChar = Nothing
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtsubtotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal.TextChanged
        If Me.txtsubtotal.Text <> "" And Iniciando = False Then
            If Not IsNumeric(Me.txtsubtotal.Text) Then
                MessageBox.Show("El subtotal debe ser un número", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtsubtotal.Text = ""
                Me.txtsubtotal.Focus()
                Return
            End If
            calculoTotal()
        End If
    End Sub

    Private Sub Contabilidad_Ingreso_Manual_Libro_Compras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub cmbTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDocumento.SelectedIndexChanged
        If Not Iniciando Then
            Me.Label6.Text = TipoDoc(Me.cmbTipoDocumento.SelectedValue) & " #:"
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Val(Me.txtDocumento.Text) > 0 Then
            If CargaDetalle Then
                If MsgBox("¿Está Seguro de Eliminar el documento No." & Me.txtDocumento.Text & "?", MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                    Sql = "DELETE FROM CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND PROVEEDOR = " & Me.TxtProveedor_Codigo.Text & " AND DOCUMENTO = " & Me.txtDocumento.Text & " AND COD_TIPO_DOC = " & Me.cmbTipoDocumento.SelectedValue
                    If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                        MsgBox("Documento Eliminado con éxito.", MsgBoxStyle.Information, "RESPUESTA")
                        LimpiaCampos()
                    End If
                End If
            End If
        Else
            MsgBox("Ingrese un número de documento para eliminar", MsgBoxStyle.Information, "SIN DOCUMENTO")
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
        Dim CodBodega, CodProv, Tipodoc, Docto, errores As Integer
        Dim CarAbo As String = String.Empty
        Iniciando = True
        Concepto = ""
        Try
            'CadenaCnn = "Provider=Microsoft.Jet.Oledb.4.0; data source= " + Me.lblArchivoExcel.Text + " ;Extended properties=Excel 8.0;"
            CadenaCnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.lblArchivoExcel.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
            Conexion_Excel = New OleDbConnection(CadenaCnn)
            Conexion_Excel.Open()
            Sql = "SELECT CODBODEGA"
            Sql &= ", CODPROV"
            Sql &= ", COMPROBANTE"
            Sql &= ", SUBTOTAL"
            Sql &= ", IVA"
            Sql &= ", PERCEPCION"
            Sql &= ", TIPODOC"
            Sql &= ", FECHA"
            Sql &= ", EXENTO"
            Sql &= " FROM [" & Hoja_Excel & "$]"
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
                If Not IsDBNull(Table.Rows(i).Item("CODPROV")) Then
                    If ValidaProv(Val(Table.Rows(i).Item("CODPROV"))) Then
                        CodProv = Table.Rows(i).Item("CODPROV")
                    Else
                        CodProv = 0
                    End If
                Else
                    CodProv = 0
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
                If CodBodega = 0 Or CodProv = 0 Or Tipodoc = 0 Or Docto = 0 Then
                    Concepto &= "Linea: " & (i + 2).ToString() & vbCrLf
                    Concepto &= IIf(CodBodega = 0, "  CODIGO BODEGA INCORRECTO" & vbCrLf, "")
                    Concepto &= IIf(CodProv = 0, "  CODIGO PROVEEDOR INCORRECTO" & vbCrLf, "")
                    Concepto &= IIf(Tipodoc = 0, "  TIPO DOCUMENTO INCORRECTO" & vbCrLf, "")
                    Concepto &= IIf(Docto = 0, "  NUMERO COMPROBANTE INCORRECTO" & vbCrLf, "")
                    errores += 1
                Else
                    CargaDetalle = ValidaDoc(CodBodega, CodProv, Tipodoc, Docto)
                    Me.cmbBODEGA.SelectedValue = CodBodega
                    Me.TxtProveedor_Codigo.Text = CodProv
                    Me.cmbTipoDocumento.SelectedValue = Tipodoc
                    Me.txtDocumento.Text = Docto
                    If IsDBNull(Table.Rows(i).Item("SUBTOTAL")) Then
                        Me.txtsubtotal.Text = "0.00"
                    Else
                        Me.txtsubtotal.Text = Format(Table.Rows(i).Item("SUBTOTAL"), "0.00")
                    End If
                    If IsDBNull(Table.Rows(i).Item("IVA")) Then
                        Me.txtIVA.Text = "0.00"
                    Else
                        Me.txtIVA.Text = Format(Table.Rows(i).Item("IVA"), "0.00")
                    End If
                    If IsDBNull(Table.Rows(i).Item("PERCEPCION")) Then
                        Me.txtPercepcion.Text = "0.00"
                    Else
                        Me.txtPercepcion.Text = Format(Table.Rows(i).Item("PERCEPCION"), "0.00")
                    End If
                    Me.txtTotal.Text = Format(Val(Me.txtsubtotal.Text) + Val(Me.txtIVA.Text), "0.00")
                    Me.txtTotalFact.Text = Format(Val(Me.txtTotal.Text) + Val(Me.txtPercepcion.Text), "0.00")
                    If IsDBNull(Table.Rows(i).Item("FECHA")) Then
                        Me.dpFECHA_OC.Value = Now()
                    Else
                        Me.dpFECHA_OC.Value = CDate(Table.Rows(i).Item("FECHA"))
                    End If
                    If IsDBNull(Table.Rows(i).Item("EXENTO")) Then
                        Me.txtExento.Text = "0.00"
                    Else
                        Me.txtExento.Text = Format(Table.Rows(i).Item("EXENTO"), "0.00")
                    End If
                    Me.btnGuardarEncabezado.PerformClick()
                End If
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

    Private Function ValidaDoc(ByVal Bodega As Integer, ByVal Prov As Integer, ByVal TipoDoc As Integer, ByVal Comprob As Integer) As Boolean
        Dim Result As Boolean = False
        Sql = "SELECT COUNT(BODEGA) AS CANTREG" & vbCrLf
        Sql &= "  FROM [dbo].[CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL]" & vbCrLf
        Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "   AND BODEGA = " & Bodega & vbCrLf
        Sql &= "   AND PROVEEDOR = " & Prov & vbCrLf
        Sql &= "   AND COD_TIPO_DOC = " & TipoDoc & vbCrLf
        Sql &= "   AND DOCUMENTO = " & Comprob
        If jClass.obtenerEscalar(Sql) > 0 Then
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

    Private Function ValidaProv(ByVal CodProv As Integer) As Boolean
        Dim Result As Boolean = False
        If CodProv > 0 Then
            Sql = "SELECT COUNT(PROVEEDOR) AS CANTREG" & vbCrLf
            Sql &= "  FROM [dbo].[CONTABILIDAD_CATALOGO_PROVEEDORES]" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND PROVEEDOR = " & CodProv
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

    Private Sub txtIVA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIVA.TextChanged, txtPercepcion.TextChanged, txtExento.TextChanged
        Me.txtTotal.Text = Format(Val(Me.txtsubtotal.Text) + Val(Me.txtIVA.Text) + Val(Me.txtExento.Text), "0.00")
        Me.txtTotalFact.Text = Format(Val(Me.txtsubtotal.Text) + Val(Me.txtIVA.Text) + Val(Me.txtPercepcion.Text) + Val(Me.txtExento.Text), "0.00")
    End Sub

    Private Sub VerificarPeriodo()
        Dim periodo_cerrado As Integer
        periodo_cerrado = jClass.obtenerEscalar("SELECT COUNT(COMPAÑIA) FROM CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL WHERE COMPAÑIA = " & Compañia & " AND MONTH(PERIODO_LIBRO) = " & Me.dpPeriodo.Value.Month.ToString() & " AND YEAR(PERIODO_LIBRO) = " & Me.dpPeriodo.Value.Year.ToString() & " AND PERIODO_CERRADO = 1")
        If periodo_cerrado > 0 Then
            MsgBox("El período " & Me.dpPeriodo.Text & " ya fue cerrado.", MsgBoxStyle.Information, "Validación Período")
            Me.btnGuardarEncabezado.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.btnImportarExcel.Enabled = False
        Else
            Me.btnGuardarEncabezado.Enabled = True
            Me.btnEliminar.Enabled = True
            Me.btnImportarExcel.Enabled = True
        End If
    End Sub

    Private Sub dpPeriodo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpPeriodo.ValueChanged
        If Not Iniciando Then
            VerificarPeriodo()
        End If
    End Sub
End Class