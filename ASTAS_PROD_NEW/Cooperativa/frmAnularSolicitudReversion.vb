Imports system.data
Imports System.Data.SqlClient
Public Class frmAnularSolicitudReversion
    Public codigoAs
    Public codigoBuxis
    Public company
    Public nombreSocio
    Public noSoli
    Public deuda As Double
    Private Sql As String
    Private func As New jarsClass
    Private Sub frmAnularSolicitudReversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        setSocio()
        'MessageBox.Show("DEUDA: " & deuda)
        Me.txtNoSolicitud.Text = noSoli
        Me.TxtCapital.Text = deuda
        Deducciones()
        setTasasInteres()
        CargaDetalleProgramaciones()
    End Sub
    Private Sub setSocio()
        Me.TxtCodigoAs.Text = codigoAs
        Me.TxtCodigoBuxis.Text = codigoBuxis
        Me.TxtNombre.Text = nombreSocio
    End Sub
       Private Sub setTasasInteres()
        Me.LblInteres.Text = getTasaInteres()
        Me.LblSegDeuda.Text = getTasaSeguro()
    End Sub
    Private Function getTasaSeguro()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO where COMPAÑIA=" & Compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()

            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return 0
    End Function
    Private Function getTasaInteres()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()

            Sql = "Select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES where COMPAÑIA=" & Compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()

            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return 0
    End Function
    Private Sub Deducciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            If esPrestamo() Then
                Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
                Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
                Sql &= "inner join COOPERATIVA_SOLICITUDES_PRESTAMOS csp "
                Sql &= "on csp.DEDUCCION=ccd.DEDUCCION "
                Sql &= "where ccd.COMPAÑIA=" & Compañia
                Sql &= " and csp.CORRELATIVO=" & Me.txtNoSolicitud.Text
            Else
                Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
                Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
                Sql &= "inner join COOPERATIVA_SOLICITUDES cs "
                Sql &= "on cs.DEDUCCION=ccd.DEDUCCION "
                Sql &= "where ccd.COMPAÑIA=" & compañia
                Sql &= " and cs.CORRELATIVO=" & Me.txtNoSolicitud.Text
            End If
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "DEDUCCION"
            Me.CbxDeduccion.DisplayMember = "DESCRIPCION_DEDUCCION"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function esPrestamo()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Dim totalReg As Integer
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()

            Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
            Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
            Sql &= "inner join COOPERATIVA_SOLICITUDES_PRESTAMOS csp "
            Sql &= "on csp.DEDUCCION=ccd.DEDUCCION "
            Sql &= "where ccd.COMPAÑIA=" & compañia
            Sql &= "and csp.CORRELATIVO=" & Me.txtNoSolicitud.Text

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            DataReader_Track = Comando_Track.ExecuteReader
            totalReg = Table.Rows.Count
            Conexion_Track.Close()

            If (totalReg > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return False
    End Function
    Private Sub CargaDetalleProgramaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & Compañia & "," & Me.txtNoSolicitud.Text & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            Me.DgvDetalleProgramaciones.Columns.Clear()
            DataAdapter.Fill(Table)
            Me.DgvDetalleProgramaciones.DataSource = Table
            LimpiaGridDetalle()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub LimpiaGridDetalle()
        Me.DgvDetalleProgramaciones.Columns(0).Width = 50
        Me.DgvDetalleProgramaciones.Columns(1).Width = 50
        Me.DgvDetalleProgramaciones.Columns(2).Width = 95
        Me.DgvDetalleProgramaciones.Columns(3).Width = 75
        Me.DgvDetalleProgramaciones.Columns(4).Width = 75
        Me.DgvDetalleProgramaciones.Columns(5).Width = 57
        Me.DgvDetalleProgramaciones.Columns(6).Width = 75
        Me.DgvDetalleProgramaciones.Columns(7).Width = 57
        Me.DgvDetalleProgramaciones.Columns(8).Width = 75
        Me.DgvDetalleProgramaciones.Columns(9).Width = 57
        Me.DgvDetalleProgramaciones.Columns(10).Width = 75
        Me.DgvDetalleProgramaciones.Columns(11).Width = 57
        Me.DgvDetalleProgramaciones.Columns(12).Width = 75
        Me.DgvDetalleProgramaciones.Columns(13).Width = 75
        Me.DgvDetalleProgramaciones.Columns(14).Width = 57
        Me.DgvDetalleProgramaciones.Columns(15).Width = 57
        Me.DgvDetalleProgramaciones.Columns(16).Visible = False
    End Sub
    Private Sub anularSolicitudes()
        ' Anular solicitudes 
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Sql = ""
        Try
            'anula las programaciones consolidadas
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            '@compañia @num_solicitud @motivo @usuario @bandera
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION " & Compañia & "," & Me.txtNoSolicitud.Text & ",'ANULACION SOLICITUD #" & Me.txtNoSolicitud.TabIndex & " MOTIVO:" & Me.txtConcepto.Text.Trim & "','" & Usuario & "', 1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Conexion_Track.Close()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET FECHA_ANULADA = '" & Format(Me.dtpFechaAnulado.Value, "dd/MM/yyyy") & "' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.txtNoSolicitud.Text
            func.Ejecutar_ConsultaSQL(Sql)
            MessageBox.Show("PROCESO DE ANULACIÓN COMPLETADO CON ÉXITO")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub
    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        'Dim sql As String
        'Dim libroContable As Integer
        'Dim cuenta As Integer
        'Dim fechaSolicitud As String
        'Dim tipoDocumento As Integer
        'Dim solicitud As Integer
        'Dim origen As Integer
        'Dim conCheque As Boolean
        'Dim deuda_solicitud As Double = 0
        'Dim cuentaContable As String
        'Dim concepto As String

        If MsgBox("¿Está seguro de eliminar la programación seleccionada?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then
            Return
        End If

        'If seDesconto() Then
        '    MessageBox.Show("La solicitud ya ha sido descontada. No es posible realizar la anulación", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If
        If Me.txtConcepto.Text.Length = 0 Or String.IsNullOrEmpty(Me.txtConcepto.Text.Trim) Then
            MessageBox.Show("Debe ingresar el motivo de la reversión de la solicitud", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtConcepto.Focus()
            Return
        End If

        'deuda_solicitud = deuda

        'solicitud = func.obtenerEscalar("SELECT SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA=" & compañia & " AND DEDUCCION=" & Me.CbxDeduccion.SelectedValue & " AND DESCRIPCION_SOLICITUD='" & Me.CbxDeduccion.SelectedItem(1) & "'")
        'libroContable = func.obtenerEscalar("SELECT LIBRO_CONTABLE FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE COMPAÑIA=" & compañia & " AND DEDUCCION=" & Me.CbxDeduccion.SelectedValue)
        'cuenta = func.obtenerEscalar("SELECT CUENTA FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE COMPAÑIA=" & compañia & " AND DEDUCCION=" & Me.CbxDeduccion.SelectedValue)
        'fechaSolicitud = func.obtenerEscalar("SELECT USUARIO_CREACION_FECHA FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA=" & compañia & " AND CORRELATIVO=" & Me.txtNoSolicitud.Text)
        'tipoDocumento = func.obtenerEscalar("select tipo_documento from COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA=" & compañia & " AND SOLICITUD=" & solicitud)

        'sql = "SELECT VCS.ORIGEN "
        'sql &= "FROM  VISTA_COOPERATIVA_SOLICITUDES VCS "
        'sql &= "INNER JOIN FACTURACION_CATALOGO_PERIODOS_CUOTA FCPC "
        'sql &= "ON VCS.COMPAÑIA=FCPC.COMPAÑIA AND VCS.PERIODO = FCPC.PERIODO "
        'sql &= "INNER JOIN COOPERATIVA_SOLICITUDES_AUTORIZACION CSA "
        'sql &= "ON VCS.COMPAÑIA=CSA.COMPAÑIA AND VCS.CORRELATIVO = CSA.N_SOLICITUD "
        'sql &= "WHERE VCS.COMPAÑIA = " & compañia & " and VCS.CORRELATIVO=" & Me.txtNoSolicitud.Text

        'origen = func.obtenerEscalar(sql)
        'sql = ""
        'sql &= "select CUENTA_COMPLETA from CONTABILIDAD_CATALOGO_CUENTAS "
        'sql &= "where Compañia=" & compañia & " And cuenta=" & cuenta & " And LIBRO_CONTABLE=" & libroContable
        'cuentaContable = func.obtenerEscalar(sql)

        'If tieneOrdenCompra() Then
        '    If tieneChequeOrdenCompra() Then
        '        'MessageBox.Show("CHEQUE DE ORDEN DE COMPRA")
        '        'elimino el cheque
        '        'partida reversion para el cheque
        '        sql = "Exec sp_COOPERATIVA_REVERSION_SOLICITUDES " & compañia
        '        sql &= "," & solicitud
        '        sql &= "," & Me.txtNoSolicitud.Text
        '        sql &= "," & tipoDocumento
        '        sql &= ",'" & Me.txtConcepto.Text & "'"
        '        sql &= ",'" & Usuario & "'"
        '        sql &= ",1"
        '        Try
        '            func.Ejecutar_ConsultaSQL(sql)
        '        Catch
        '            func.cerrarConexion()
        '        End Try
        ' End If
        '    'Elimino la orden de compra
        '    sql = "Exec sp_COOPERATIVA_REVERSION_SOLICITUDES " & compañia
        '    sql &= "," & solicitud
        '    sql &= "," & Me.txtNoSolicitud.Text
        '    sql &= "," & tipoDocumento
        '    sql &= ",'" & Me.txtConcepto.Text & "'"
        '    sql &= ",'" & Usuario & "'"
        '    sql &= ",2"
        '    func.Ejecutar_ConsultaSQL(sql)
        'End If
        ''Partida de reversion para la solicitud
        'func.Ejecutar_ConsultaSQL("EXEC sp_CONTABILIDAD_PARTIDA_DEVOLUCION_FACTURACION " & CbxCompania.SelectedValue & ",1," & tipoDocumento & "," & origen & ",0,'" & Format(Now, "Short Date") & "'," & cuenta & ",0," & deuda_solicitud & ",'" & Me.txtConcepto.Text.Trim & "','" & Usuario & "'")
        anularSolicitudes() 'listo   
        'MessageBox.Show("PROCESO DE REVERSIÓN COMPLETADO CON ÉXITO")
        Me.Close()
    End Sub

 
    Private Function seDesconto()
        'Verifica si la solicitud ya posee cuotas descontadas
        Dim totalDescontadas As Integer
        Dim sql As String
        Dim descontada As Boolean

        sql = "SELECT COUNT(*) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE"
        sql &= " WHERE CAPITAL_D=0"
        sql &= " AND INTERES_D=0"
        sql &= " AND SEG_DEUDA=0"
        sql &= " AND COMPAÑIA=" & Compañia
        sql &= " AND NUMERO_SOLICITUD=" & Me.txtNoSolicitud.Text

        totalDescontadas = func.obtenerEscalar(sql)

        If totalDescontadas > 0 Then
            descontada = False
        Else
            descontada = True
        End If

        Return descontada
    End Function
    Private Function tieneOrdenCompra()
        Dim ordenCompra As Boolean
        Dim regTotal As Integer

        regTotal = func.obtenerEscalar("select COUNT(*) from COOPERATIVA_ORDEN_COMPRA_ENCABEZADO where COMPAÑIA=" & Compañia & " and CORRELATIVO=" & Me.txtNoSolicitud.Text)

        If regTotal = 0 Then
            ordenCompra = False
        Else
            ordenCompra = True
        End If

        Return ordenCompra
    End Function
    Private Function getOrdenCompra()
        Dim ordenCompra As Integer

        ordenCompra = func.obtenerEscalar("SELECT ORDEN_COMPRA from COOPERATIVA_ORDEN_COMPRA_ENCABEZADO where COMPAÑIA=" & Compañia & " AND CORRELATIVO=" & Me.txtNoSolicitud.Text)

        Return ordenCompra
    End Function
    Private Function tieneChequeOrdenCompra()
        Dim ordenCompra As Integer
        Dim totalCheque As Integer
        Dim cheque As Boolean

        ordenCompra = getOrdenCompra()
        totalCheque = func.obtenerEscalar("select count(*) from COOPERATIVA_ORDEN_COMPRA_CHEQUES where compañia=" & Compañia & " and ORDEN_COMPRA=" & ordenCompra & " and cheque>0")

        If totalCheque = 0 Then
            cheque = False
        Else
            cheque = True
        End If

        Return cheque
    End Function

    Private Sub frmAnularSolicitudReversion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class