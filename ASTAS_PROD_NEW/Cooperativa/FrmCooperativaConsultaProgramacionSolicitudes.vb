Imports System.Data.SqlClient

Public Class FrmCooperativaConsultaProgramacionSolicitudes

    'Constructor
    Dim Permitir As String
    Dim fill As New jarsClass

    'Variables
    Dim sql As String = ""
    Dim res As Integer = 0

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim DataAdapter As SqlDataAdapter
    Dim Table, tblSolic As DataTable
    Dim DataReader_ As SqlDataReader
    Dim Rpts As New frmReportes_Ver
    Dim jars As New jarsClass

    'Guarda el numero de la solicitud
    Public NumSolicitud As Integer

    'Al momento de cargar el formulario 
    'Cabal ing.benjamin parada, porque como casi nadie sabe que el event load 
    'se ejecuta al momento de cargar el formulario, eran muy importante aclarar eso ;)
    Private Sub FrmCooperativaConsultaProgramacionSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        'Me.lblMsj.Text = ""
        'Me.gbPrestamo.Visible = False
        'Desarrollado por Benjamin Parada
        'MEJORADO POR ISAAC MATAL
        'CargaCompany(Usuario, 1)
        Try
            Permitir = fill.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    'MEJORADO POR ISAAC MATAL
    'codigo innecesario
    'Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxCompania.SelectedIndexChanged
    '    Me.TxtCodigoAs.Text = Nothing
    '    Me.TxtCodigoBuxis.Text = Nothing
    '    Me.TxtNombre.Text = Nothing
    '    Me.DgvProgramaciones.DataSource = Nothing
    '    limpiaDGV()
    '    Me.lblMsj.Text = ""
    '    'Me.DgvProgramacionesDetalle.DataSource = Nothing
    'End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    'MEJORADO POR ISAAC MATAL
    'codigo innecesario
    'Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERA)
    '    Conexion_Track = fill.devuelveCadenaConexion()
    '    Try
    '        Conexion_Track.Open()
    '        sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
    '        Comando_Track = New SqlCommand(sql, Conexion_Track)
    '        DataAdapter_ = New SqlDataAdapter(Comando_Track)
    '        Table = New DataTable("Datos")
    '        DataAdapter_.Fill(Table)
    '        Me.CbxCompania.DataSource = Table
    '        Me.CbxCompania.ValueMember = "COMPAÑIA"
    '        Me.CbxCompania.DisplayMember = "NOMBRE_COMPAÑIA"
    '        Conexion_Track.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Desarrollado por Benjamin Parada
    'MEJORADO POR ISAAC MATAL
    Private Sub BtnBuscarSocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocio.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocio()
            CargaProgramaciones()
            If DgvProgramaciones.RowCount = 0 Then
                limpiaDGV()
            End If
        End If
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    'MEJORADO POR ISAAC MATAL
    Private Sub BuscaSocio()
        Dim DS As New DataSet()
        Conexion_Track = fill.devuelveCadenaConexion()
        Try
            Conexion_Track.Open()
            sql = "Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                Origen = fill.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & DS.Tables(0).Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & DS.Tables(0).Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, DS.Tables(0).Rows(0).Item(1) & " - " & DS.Tables(0).Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                TxtCodigoAs.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuxis.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombre.Text = DS.Tables(0).Rows(0).Item(2)
                Hay_Datos = True
            Else
                MsgBox("Código de socio no existe!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    'MEJORADO POR ISAAC MATAL
    Private Sub CargaProgramaciones()
        Try
            sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PROGRAMACIONES_USUARIO " & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ",@CODIGO_AS = '" & Trim(TxtCodigoAs.Text) & "'" & vbCrLf
            sql &= ",@CODIGO_BUXIS = " & Val(TxtCodigoBuxis.Text) & vbCrLf
            sql &= ",@BANDERA = 1" & vbCrLf
            tblSolic = fill.obtenerDatos(New SqlCommand(sql))
            Me.rbTodas.Checked = True
            Me.DgvProgramaciones.DataSource = tblSolic
            Me.DgvProgramaciones.Columns.Item(1).Visible = False
            Me.DgvProgramaciones.Columns.Item(4).Visible = False
            Me.DgvProgramaciones.Columns.Item(6).Visible = False
            Me.DgvProgramaciones.Columns.Item(7).Visible = False
            Me.DgvProgramaciones.Columns.Item(8).Visible = False
            Me.DgvProgramaciones.Columns(0).Width = 70
            Me.DgvProgramaciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DgvProgramaciones.Columns(2).Width = 195
            Me.DgvProgramaciones.Columns(3).Width = 75
            Me.DgvProgramaciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DgvProgramaciones.Columns(5).Width = 70
            Me.DgvProgramaciones.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DgvProgramaciones.Columns(9).Width = 80
            Me.DgvProgramaciones.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DgvProgramaciones.Columns(10).Width = 60
            Me.DgvProgramaciones.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DgvProgramaciones.Columns(10).DefaultCellStyle.Format = "#,##0.00"
            If Me.DgvProgramaciones.Rows.Count > 0 Then
                Me.bntImprimir.Enabled = True
            Else
                Me.bntImprimir.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    'MEJORADO POR ISAAC MATAL
    Private Sub DgvProgramaciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProgramaciones.CellEnter
        If e.RowIndex > -1 Then
            NumSolicitud = Me.DgvProgramaciones.CurrentRow.Cells.Item(0).Value
            TxtNumSolicitud.Text = NumSolicitud
            limpiaDGV()
            Me.lblMsj.Text = ""
            cargarDetallesSolicitud(Compañia, NumSolicitud, DgvProgramacionesDetalle, 0)
            '-----------------------------------------------------------------------------------'
            '                           CARGA INFORMACION DE PRESTAMO                           '
            '-----------------------------------------------------------------------------------'

            If Me.DgvProgramaciones.CurrentRow.Cells(2).Value = "PRESTAMOS" Then
                If estaPagada(NumSolicitud) Then
                    Me.chkPagado.Checked = True

                    If tipoPago(NumSolicitud) = 1 Then
                        'pago con cheque
                        Me.txtFormaPago.Text = "CHEQUE"
                        Me.txtFechaContable.Text = jars.obtenerEscalar("select convert(char,FECHA_CONTABLE,106) from COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES where COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.txtBancoAsociacion.Text = jars.obtenerEscalar("select ccb.DESCRIPCION_BANCO from COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES psc inner join CONTABILIDAD_CATALOGO_BANCOS ccb on psc.BANCO=ccb.BANCO where psc.COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.txtNoCheque.Text = jars.obtenerEscalar("select CHEQUE from COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES where COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.Label7.Text = "No. Cheque:"
                    ElseIf tipoPago(NumSolicitud) = 2 Then
                        'pago con remesa
                        Me.txtFormaPago.Text = "REMESA"
                        Me.txtBancoAsociacion.Text = jars.obtenerEscalar("select ccb.DESCRIPCION_BANCO from COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS psc inner join CONTABILIDAD_CATALOGO_BANCOS ccb on psc.BANCO=ccb.BANCO where psc.COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.txtFechaContable.Text = jars.obtenerEscalar("select convert(char,FECHA_CONTABLE,106) from COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS where COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.txtNoCheque.Text = jars.obtenerEscalar("select REMESA from COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS where COMPAÑIA=" & Compañia & " and SOLICITUD=" & NumSolicitud)
                        Me.Label7.Text = "Remesa#"
                    Else
                        'no se encontro el tipo de pago
                        Me.txtFormaPago.Text = "NO DEFINIDO"
                        Me.txtFormaPago.Text = "NO DEFINIDO"
                        Me.txtNoCheque.Text = "NO DEFINIDO"
                        Me.txtBancoAsociacion.Text = "NO DEFINIDO"
                        Me.txtFechaContable.Text = "NO DEFINIDO"

                    End If
                Else
                    Me.chkPagado.Checked = False
                    Me.txtFormaPago.Text = "N/A"
                    Me.txtNoCheque.Text = "N/A"
                    Me.txtBancoAsociacion.Text = "N/A"
                    Me.txtFechaContable.Text = "N/A"
                End If
                Me.gbPrestamo.Visible = True
            Else
                Me.gbPrestamo.Visible = False
            End If


            If lblMsj.Text.Contains("Anulada") Then
                cargarDetallesSolicitud(Compañia, NumSolicitud, Me.dgvProgramacionAnulada, 1)
                cargarDetallesSolicitud(Compañia, NumSolicitud, Me.dgvProgramacionCancelada, 4)
                cargarDetallesSolicitud(Compañia, NumSolicitud, Me.DgvProgramacionesDetalle, 4)
            Else
                cargarDetallesSolicitud(Compañia, NumSolicitud, Me.dgvProgramacionCancelada, 2)
                cargarDetallesSolicitud(Compañia, NumSolicitud, Me.DgvProgramacionesDetalle, 3)
            End If
        End If
    End Sub
    ' Retorna el tipo de pago que se hace a la solicitud
    ' tipo 1 = pago por cheque
    ' tipo 2 = pago por remesa
    Private Function tipoPago(ByVal solicitud As Integer)
        Dim tipo As Integer
        Dim total As Integer

        tipo = 0

        total = jars.obtenerEscalar("Select count(*) from COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES where PERIODO <> 'Retiro Ext' AND COMPAÑIA=" & Compañia & " and CODIGO_EMPLEADO_AS='" & Me.TxtCodigoAs.Text & "' and  CODIGO_EMPLEADO='" & Me.TxtCodigoBuxis.Text & "' and SOLICITUD=" & solicitud)
        If total > 0 Then
            tipo = 1
        End If

        total = jars.obtenerEscalar("Select count(*) from COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS where UBICACION = 1 AND COMPAÑIA=" & Compañia & " and CODIGO_EMPLEADO_AS='" & Me.TxtCodigoAs.Text & "' and  CODIGO_EMPLEADO='" & Me.TxtCodigoBuxis.Text & "' and SOLICITUD=" & solicitud)
        If total > 0 Then
            tipo = 2
        End If

        Return tipo
    End Function
    Private Function estaPagada(ByVal solicitud As Integer)
        ' Verifica si una solicitud ya ha sido pagada o no
        ' retorna false si no se ha pagado y true si ya se pago
        Dim pagada As Boolean

        pagada = False

        'si es por remesa y el banco es distindo a 0 es porque ya se pago
        sql = "SELECT PAGADA FROM COOPERATIVA_SOLICITUDES_PRESTAMOS WHERE COMPAÑIA=" & Compañia & " AND CORRELATIVO=" & solicitud
        pagada = jars.obtenerEscalar(sql)

        Return pagada
    End Function

    'Metodo que limpia los DGV's del tabcontrol
    Private Sub limpiaDGV()
        DgvProgramacionesDetalle.DataSource = Nothing
        dgvProgramacionCancelada.DataSource = Nothing
        dgvProgramacionAnulada.DataSource = Nothing
    End Sub

    'Metodo que primero determina el estado de la solicitud para poder mostrar los detalles de la misma
    'Luego acorde al estado de la solicitud lo carga en los DGV
    Private Sub cargarDetallesSolicitud(ByVal cia As Integer, ByVal solicitud As Integer, ByVal dgv As DataGridView, ByVal flag As Integer)
        Conexion_Track = fill.devuelveCadenaConexion()
        Try
            Conexion_Track.Open()
            sql = " Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CONSULTAS "
            sql &= cia
            sql &= ", " & solicitud
            sql &= ", " & flag
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            'Si la bandera es 0 o 5 pasa a efectuar dos evaluaciones:
            'Siendo 0 evalua si la solicitud ha sido anulada, cancelada o tiene cuotas pendientes de pago.
            'Siendo 5 quiere decir que va evaluar si la solicitud que ha sido anulada tiene cuotas pendientes
            'o canceladas.
            If flag = 0 Or flag = 5 Then
                DataReader_ = Comando_Track.ExecuteReader()
                If DataReader_.Read = True Then
                    If Val(DataReader_.Item("Valor")) = 1 Then
                        'Mensaje del label
                        Me.lblMsj.Text = "Solicitud" & vbCrLf & "Anulada"
                        Me.cmbTipo.Text = "Anulada"
                        'Carga en el tab de Anuladas
                        cargarDetallesSolicitud(cia, solicitud, dgvProgramacionAnulada, 1)
                        Exit Sub
                    ElseIf Val(DataReader_.Item("Valor")) = 2 Then
                        'Mensaje del label
                        Me.lblMsj.Text = "Solicitud" & vbCrLf & "Cancelada"
                        Me.cmbTipo.Text = "Cancelada"
                        'Carga en el tab de canceladas
                        cargarDetallesSolicitud(cia, solicitud, dgvProgramacionCancelada, 2)
                        Exit Sub
                    ElseIf Val(DataReader_.Item("Valor")) = 3 Then
                        'Mensaje del label
                        Me.lblMsj.Text = "Solicitud" & vbCrLf & "Pendiente"
                        Me.cmbTipo.Text = "Pendiente"
                        'Carga en el tab de pagadas/pendientes
                        cargarDetallesSolicitud(cia, solicitud, DgvProgramacionesDetalle, 3)
                        Exit Sub
                    ElseIf Val(DataReader_.Item("Valor")) = 7 Then
                        'Siendo la solicitud anulad a carga las cuotas en el tab de canceladas
                        cargarDetallesSolicitud(cia, solicitud, dgvProgramacionCancelada, 4)
                        Exit Sub
                    ElseIf Val(DataReader_.Item("Valor")) = 14 Then
                        'Siendo la solicitud anulada carga las cuotas en el tab pagadas/pendientes
                        cargarDetallesSolicitud(cia, solicitud, DgvProgramacionesDetalle, 4)
                        Exit Sub
                    End If
                Else
                    'Si no puede determinar el estado siendo el flag 0 indica que no se pudieron mostrar los detalles
                    MsgBox("¡No se pudieron cargar correctamente los detalles!" & vbCrLf & "Verifique los datos seleccionados.", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.cmbTipo.Text = "Pendiente"
                End If
                'Cierra la conexion
                Conexion_Track.Close()
            ElseIf flag <> 0 And flag <> 5 Then
                'Si el flag es 1,2,3 o 4 hace lo siguiente
                'Crea el table con lo que devolvio la consulta
                Table = fill.LlenaDT(Conexion_Track, DataAdapter_, Comando_Track, sql, Table)
                'Cierra la conexion
                Conexion_Track.Close()
                'Asigna el table como fuente del DGV
                dgv.DataSource = Table
                'Oculta para todos los DGV's la columna 17 (16) que tiene el valor de la compañia
                dgv.Columns.Item(17).Visible = False
                'Ajusta el DGV
                fill.ajustarGrid(18, dgv)
                If flag = 1 Then
                    'Si la solicitud fue anulada entonces pasa a evaluar si los detalles fueron
                    'o bien cancelados o tiene cuotas pendientes de pago
                    cargarDetallesSolicitud(cia, solicitud, DgvProgramacionesDetalle, 5)
                    Exit Sub
                End If
                'Si no devolvio ningun registro limpia la fuente de informacion del DGV
                If dgv.Rows.Count = 0 Then
                    dgv.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress, TxtCodigoBuxis.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoAs.Text <> Nothing Or Me.TxtCodigoBuxis.Text <> Nothing Then
                If Me.TxtCodigoAs.Text <> Nothing Then
                    Me.TxtCodigoAs.Text = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                    ParamcodigoAs = Me.TxtCodigoAs.Text
                    ParamcodigoBux = fill.obtenerEscalar("SELECT CODIGO_EMPLEADO FROM dbo.COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "'")
                Else
                    ParamcodigoAs = fill.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM dbo.COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text)
                    ParamcodigoBux = Val(Me.TxtCodigoBuxis.Text)
                End If
                BuscaSocio()
                If Hay_Datos Then
                    CargaProgramaciones()
                    If DgvProgramaciones.RowCount = 0 Then
                        limpiaDGV()
                    End If
                Else
                    Me.TxtCodigoAs.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub bntImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntImprimir.Click
        Dim Reporte As Object
        Dim rep As New CooperativaProgramacion
        Dim fieldObj As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim pctr As CrystalDecisions.CrystalReports.Engine.PictureObject
        Dim flag As Integer = 3
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_RPT]"
        sql &= " @COMPAÑIA = " & Compañia
        If Not Me.chkTodas.Checked Then
            sql &= ", @N_SOLICITUD = " & Me.TxtNumSolicitud.Text
            Reporte = New CooperativaProgramacion
        Else
            Reporte = New CooperativaProgramacionConsultas
        End If
        sql &= ", @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'"
        sql &= ", @CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
        If Me.cmbTipo.Text = "Anulada" Then
            flag = 4
        ElseIf Me.cmbTipo.Text = "Cancelada" Then
            flag = 6
        ElseIf Me.cmbTipo.Text = "Pendiente" Then
            If Not Me.chkCanceladas.Checked And Me.chkTodas.Checked Then
                flag = 5
            End If
        End If
        sql &= ", @BANDERA = " & flag
        Comando_Track.CommandText = sql
        Table = fill.obtenerDatos(Comando_Track)
        Reporte.SetDataSource(Table)
        If Origen = 5 Or Origen = 6 Then
            pctr = Reporte.Section1.ReportObjects.Item("picture1")
            pctr.ObjectFormat.EnableSuppress = True
            pctr = Reporte.Section1.ReportObjects.Item("picture2")
            pctr.ObjectFormat.EnableSuppress = False
            fieldObj = Reporte.Section1.ReportObjects.Item("NOMBRECOMPAÑIA1")
            fieldObj.ObjectFormat.EnableSuppress = True
            txtObj = Reporte.Section1.ReportObjects.Item("txtATAF")
            txtObj.ObjectFormat.EnableSuppress = False
            txtObj.Text = fill.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2")
        End If
        If Me.chkDetalle.Checked Then
            Reporte.Section3.SectionFormat.EnableSuppress = True
        End If
        If flag = 4 And Me.chkTodas.Checked Then
            Reporte.Section4.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
        End If
        Rpts.ReportesGenericos(Reporte)
        Rpts.ShowDialog()
    End Sub

    Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        Me.chkCanceladas.Enabled = chkTodas.Checked
        Me.cmbTipo.Enabled = chkTodas.Checked
        Dim msj As String
        If Me.DgvProgramaciones.Rows.Count > 0 Then
            If Not Me.chkTodas.Checked Then
                Me.chkCanceladas.Checked = False
                msj = Me.lblMsj.Text.Substring(11)
                Me.cmbTipo.Text = msj
            End If
            If Me.cmbTipo.Text <> "Pendiente" Then
                Me.chkCanceladas.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If Me.cmbTipo.Text <> "Pendiente" Then
            Me.chkCanceladas.Enabled = False
        Else
            Me.chkCanceladas.Enabled = True
        End If
    End Sub

    Private Sub FrmCooperativaConsultaProgramacionSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNuevo.Click
        Me.TxtCodigoBuxis.Clear()
        Me.TxtCodigoAs.Clear()
        Me.TxtNombre.Clear()
        Me.DgvProgramaciones.DataSource = Nothing
        Me.DgvProgramacionesDetalle.DataSource = Nothing
        Me.dgvProgramacionCancelada.DataSource = Nothing
        Me.dgvProgramacionAnulada.DataSource = Nothing
        Me.TxtCodigoBuxis.Focus()
    End Sub

    Private Sub rbPend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPend.CheckedChanged
        Dim tblFiltrada As New DataTable
        Dim myrows As DataRow()
        If rbPend.Checked Then
            myrows = tblSolic.Select("[Saldo Actual] > 0")
            Table.Reset()
            tblFiltrada = tblSolic.Clone
            For i As Integer = 0 To myrows.Length - 1
                tblFiltrada.ImportRow(myrows(i))
            Next
            Me.DgvProgramaciones.DataSource = tblFiltrada
        End If
    End Sub

    Private Sub rbTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodas.CheckedChanged
        If rbTodas.Checked Then
            Me.DgvProgramaciones.DataSource = tblSolic
        End If
    End Sub
End Class