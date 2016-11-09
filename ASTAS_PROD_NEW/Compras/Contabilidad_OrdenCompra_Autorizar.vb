Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Autorizar
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver

    Private Sub Contabilidad_OrdenCompra_Autorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 2)
        BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "2", "3"))
        Iniciando = False

    End Sub

    Private Sub CargaCompañia()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= Bandera
            Sql &= ", " & Compañia
            Sql &= ", ''"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
            Me.cmbBODEGA.SelectedValue = 999
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        'JASC27082013
        Me.dgvOrdenesCompra.Columns(0).Width = 50 'Seleccionar
        Me.dgvOrdenesCompra.Columns(1).Width = 100 'OC
        Me.dgvOrdenesCompra.Columns(2).Width = 75 'Fecha
        Me.dgvOrdenesCompra.Columns(3).Width = 150 'Proveedor
        Me.dgvOrdenesCompra.Columns(4).Width = 75 'Subtotal
        Me.dgvOrdenesCompra.Columns(5).Width = 75 'IVA
        Me.dgvOrdenesCompra.Columns(6).Width = 75 'Total
        Me.dgvOrdenesCompra.Columns(7).Width = 75 'Percepcion
        Me.dgvOrdenesCompra.Columns(8).Width = 75 'Total Compra
        Me.dgvOrdenesCompra.Columns(9).Width = 75 'Forma Pago
        Me.dgvOrdenesCompra.Columns(10).Width = 75 'Condicion
        Me.dgvOrdenesCompra.Columns(11).Width = 100 'Bodega
        Me.dgvOrdenesCompra.Columns(12).Width = 75 'Usuario Procesado
        Me.dgvOrdenesCompra.Columns(13).Width = 125 'Fecha Procesado

        Me.dgvOrdenesCompra.Columns(6).DefaultCellStyle.ForeColor = Color.Blue
        Me.dgvOrdenesCompra.Columns(7).DefaultCellStyle.ForeColor = Color.Red
        Me.dgvOrdenesCompra.Columns(8).DefaultCellStyle.ForeColor = Color.Navy

        Me.dgvOrdenesCompra.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvOrdenesCompra.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvOrdenesCompra.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvOrdenesCompra.Columns.Item(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvOrdenesCompra.Columns.Item(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvOrdenesCompra.Columns.Item(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Me.dgvOrdenesCompra.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvOrdenesCompra.Columns(1).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(2).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(3).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(4).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(5).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(6).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(7).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(8).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(9).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(10).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(11).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(12).ReadOnly = True
        Me.dgvOrdenesCompra.Columns(13).ReadOnly = True
    End Sub

    Private Sub BuscarOC(ByVal Compañia, ByVal Bodega, ByVal OC, ByVal NombreProveedor, ByVal NombreComercial, ByVal NIT, ByVal NRC, ByVal FechaIni, ByVal FechaFin, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & OC
            Sql &= ", '" & NombreProveedor & "'"
            Sql &= ", '" & NombreComercial & "'"
            Sql &= ", '" & NIT & "'"
            Sql &= ", '" & NRC & "'"
            Sql &= ", '" & Format(FechaIni, "dd-MM-yyyy 00:00:01") & "'"
            Sql &= ", '" & Format(FechaFin, "dd-MM-yyyy 23:59:59") & "'"
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvOrdenesCompra.Columns.Clear()
            Me.dgvOrdenesCompra.DataSource = Table
            Conexion_.Close()
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub AutorizaOC(ByVal Compañia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal Comentario, ByVal IUD, ByVal usrProcesaOC)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Autorizada
            Sql &= ", " & Anulada
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", '" & Comentario & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            If Comando_.ExecuteNonQuery() > 0 And Autorizada = 1 Then
                Correo(OrdenCompra, usrProcesaOC)
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 2)
            BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "2", "3"))
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "2", "3"))
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim ComentarioOC As String = String.Empty
        'If MsgBox("¿Está seguro(a) que desea Autorizar la Orden de Compra seleccionada?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
        '    ComentarioOC = InputBox("Ingrese un Comentario para las Ordenes de Compra que desea autorizar:", "Ingresar Comentario")
        '    If Trim(ComentarioOC) = "" Then
        '        MsgBox("¡Debe ingresar un Comentario, no puede dejarlo vacío!" & Chr(13) & "No se autorizarán las Ordenes de Compra", MsgBoxStyle.Critical, "Validación")
        '    Else
        For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
            If Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value = True Then
                AutorizaOC(Me.cmbCOMPAÑIA.SelectedValue, Me.dgvOrdenesCompra.Rows(i).Cells.Item(1).Value, IIf(Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value, 1, 0), "0", ComentarioOC, "U", Me.dgvOrdenesCompra.Rows(i).Cells.Item(1).Value)
            End If
        Next
        MsgBox("¡Orden de Compra Autorizada con éxito!", MsgBoxStyle.Information, "Mensaje")
        BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "2", "3"))
        '    End If
        'End If
    End Sub

    Private Sub Correo(ByVal OC As Integer, ByVal usrProcesaOC As String)
        'clase para enviar correos
        Try
            Dim sendMail As New EnviarCorreo
            Dim jClass As New jarsClass
            Sql = "SELECT REQUISICION, " & vbCrLf
            Sql &= "      (SELECT DESCRIPCION_BODEGA FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND BODEGA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.BODEGA) AS BODEGA," & vbCrLf
            Sql &= "      (SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_CREA_SOLICITA) AS SOLICITANTE, " & vbCrLf
            Sql &= "      (SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_CREA_SOLICITA) AS CORREO_SOLICITANTE, " & vbCrLf
            Sql &= "      (SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_REVISA) AS AUTORIZADOR," & vbCrLf
            Sql &= "      (SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_REVISA) AS CORREO_AUTORIZADOR," & vbCrLf
            Sql &= "      (SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & usrProcesaOC & "') AS PROCESAOC," & vbCrLf
            Sql &= "       FECHA_SOLICITA" & vbCrLf
            Sql &= "  FROM CONTABILIDAD_ORDEN_COMPRA_REQUISICION WHERE COMPAÑIA = " & Compañia & " AND ORDEN_GENERADA LIKE '%" & OC & "%'" & vbCrLf
            Dim tblDatosReq As DataTable = jClass.obtenerDatos(New SqlCommand(Sql))
            'para el autorizador
            sendMail.Enviar(tblDatosReq.Rows(0).Item("CORREO_AUTORIZADOR"), _
                            IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                            "Orden de Compra No. " & OC & " AUTORIZADA (Req.#" & tblDatosReq.Rows(0).Item("REQUISICION") & ")", _
                            "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                            "Orden Compra Autorizada por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                            "Usuario Solicitante: <strong>" & tblDatosReq.Rows(0).Item("SOLICITANTE") & "</strong><br />" & _
                            "Bodega Solicitante: <strong>" & tblDatosReq.Rows(0).Item("BODEGA") & "</strong><br />" & _
                            "Producto requeridos para el <strong><u>" & CDate(tblDatosReq.Rows(0).Item("FECHA_SOLICITA")).ToLongDateString() & "</u></strong><br /><br />" & _
                            "Procesado por: <strong>" & tblDatosReq.Rows(0).Item("PROCESAOC") & "</strong><br />" & _
                            "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>ORDEN DE COMPRA LISTA PARA RECIBIR PRODUCTOS SOLICITADOS</strong><p></div>")

            'para el solicitante
            sendMail.Enviar(tblDatosReq.Rows(0).Item("CORREO_SOLICITANTE"), _
                            IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                            "Orden de Compra No. " & OC & " AUTORIZADA (Req.#" & tblDatosReq.Rows(0).Item("REQUISICION") & ")", _
                            "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                            "Orden Compra Autorizada por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                            "Requisición Autorizada por: <strong>" & tblDatosReq.Rows(0).Item("AUTORIZADOR") & "</strong><br />" & _
                            "Producto requeridos para el <strong><u>" & CDate(tblDatosReq.Rows(0).Item("FECHA_SOLICITA")).ToLongDateString() & "</u></strong><br />" & _
                            "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>ORDEN DE COMPRA LISTA PARA RECIBIR PRODUCTOS SOLICITADOS</strong><p></div>")
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim ComentarioOC As String
        If MsgBox("¿Está seguro(a) que desea Anular la Orden de Compra seleccionada?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            ComentarioOC = InputBox("Ingrese un Comentario para las Ordenes de Compra que desea anular:", "Ingresar Comentario")
            If Trim(ComentarioOC) = "" Then
                MsgBox("¡Debe ingresar un Comentario, no puede dejarlo vacío!" & "No se anulará la Orden de Compra", MsgBoxStyle.Critical, "Validación")
            Else
                For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
                    If Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value = True Then
                        AutorizaOC(Me.cmbCOMPAÑIA.SelectedValue, Me.dgvOrdenesCompra.Rows(i).Cells.Item(1).Value, 0, Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value, ComentarioOC, "U", "")
                    End If
                Next
                BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "2", "3"))
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.dgvOrdenesCompra.Rows.Count > 0 Then
            Rpts.CargaOC(Me.cmbCOMPAÑIA.SelectedValue, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(1).Value)
            Rpts.ShowDialog()
        Else
            MsgBox("¡Debe seleccionar una Orden de Compra válida!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub Btn_Todas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Todas.Click
        If MsgBox("Marcar/Desmarcar todas las Ordenes de Compra?", MsgBoxStyle.YesNo, "MARCAR") = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
                If Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value = True Then
                    Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value = False
                Else
                    Me.dgvOrdenesCompra.Rows(i).Cells.Item(0).Value = True
                End If
            Next
        End If
    End Sub

    Private Sub Contabilidad_OrdenCompra_Autorizar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class