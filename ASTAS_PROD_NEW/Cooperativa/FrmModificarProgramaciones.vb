Imports System.Data
Imports System.Data.SqlClient
Public Class FrmModificarProgramaciones
    Dim Sql As String
    Dim Rpts As New FrmCooperativaReportes
    Dim Division_value As String
    Dim Seccion_value As String
    Dim Departamento_value As String
    Dim jClass As New jarsClass
    Dim Permitir As String
    Dim NumCarga As Integer

    Private Sub FrmModificarProgramaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.btnReprogramar.Enabled = False
        Me.btnConsolidar.Enabled = False
        Me.btnAbonoEfectivo.Enabled = False
        Me.btnAnular.Enabled = False
        NumCarga = 0
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub
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
                'DgvProgramacionesDetalle.DataSource = Nothing
            End If
        End If
    End Sub
    Private Sub BuscaSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & DS.Tables(0).Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & DS.Tables(0).Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, DS.Tables(0).Rows(0).Item(1) & " - " & DS.Tables(0).Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                TxtCodigoAs.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuxis.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombre.Text = DS.Tables(0).Rows(0).Item(2)
                Departamento_value = DS.Tables(0).Rows(0).Item(3)
                Division_value = DS.Tables(0).Rows(0).Item(4)
                Seccion_value = DS.Tables(0).Rows(0).Item(9)
                Hay_Datos = True
            Else
                MsgBox("No existe código de socio!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub CargaProgramaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            'Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PROGRAMACIONES_USUARIO " & compañia & ",'" & Trim((TxtCodigoAs.Text)) & "'," & Trim(Val(TxtCodigoBuxis.Text)) & "," & 2
            'Sql = "SELECT s.CORRELATIVO[Nº Solicitud],s.DESCRIPCION_SOLICITUD[Solicitud],SUM(sd.CAPITAL) AS DEUDA FROM VISTA_COOPERATIVA_PROGRAMACION_SOLICITUDES s inner join COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd on sd.NUMERO_SOLICITUD=s.CORRELATIVO"
            'Sql = Sql & " WHERE s.COMPAÑIA='" & compañia & "' AND s.CODIGO_AS='" & Trim((TxtCodigoAs.Text)) & "' AND s.CODIGO_BUXIS='" & Trim(Val(TxtCodigoBuxis.Text)) & "' AND s.CORRELATIVO NOT IN(SELECT NUMERO_SOLICITUD FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS) AND sd.CAPITAL_D=0"
            'Sql = Sql & " group by s.CORRELATIVO, s.DESCRIPCION_SOLICITUD order by DEUDA"
            Sql = "SELECT D.NUMERO_SOLICITUD AS [Nº Solicitud], MAX(DD.DESCRIPCION_SOLICITUD) AS [Solicitud], SUM(D.CAPITAL) AS [Saldo Pendiente], COUNT(D.COMPAÑIA) AS [Cuotas Pendientes], " & vbCrLf
            Sql &= "(SELECT COUNT(DET.NUMERO_SOLICITUD) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE DET WHERE DET.COMPAÑIA = 1 AND DET.NUMERO_SOLICITUD = D.NUMERO_SOLICITUD AND DATEPART(D,DET.FECHA_PAGO)=12) AS [Cuotas Especiales],"
            Sql &= "MAX(E.CUOTA) AS Cuota, max(A.NUMERO_FACTURA) AS [No.Factura o Vale], MAX(S.FECHA_SOLICITUD) AS [Fecha Otorgado], MAX(VALOR_VALE) AS [Monto Otorgado],DD.SOLICITUD" & vbCrLf
            Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, " & vbCrLf
            Sql &= "       COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO E," & vbCrLf
            Sql &= "       COOPERATIVA_SOLICITUDES S, " & vbCrLf
            Sql &= "       COOPERATIVA_CATALOGO_SOLICITUDES DD," & vbCrLf
            Sql &= "       COOPERATIVA_SOLICITUDES_AUTORIZACION A " & vbCrLf
            Sql &= " WHERE D.COMPAÑIA = E.COMPAÑIA And D.NUMERO_SOLICITUD = E.NUMERO_SOLICITUD" & vbCrLf
            Sql &= "   AND E.COMPAÑIA = S.COMPAÑIA AND E.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
            Sql &= "   AND S.COMPAÑIA = DD.COMPAÑIA AND S.SOLICITUD = DD.SOLICITUD" & vbCrLf
            Sql &= "   AND S.COMPAÑIA = A.COMPAÑIA AND S.CORRELATIVO = A.N_SOLICITUD" & vbCrLf
            Sql &= "   AND D.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND s.CODIGO_AS= '" & Trim((TxtCodigoAs.Text)) & "'" & vbCrLf
            Sql &= "   AND s.CODIGO_BUXIS = '" & Trim(Val(TxtCodigoBuxis.Text)) & "'" & vbCrLf
            Sql &= "   AND D.CAPITAL_D = 0 " & vbCrLf
            Sql &= "   AND D.NUMERO_SOLICITUD < 200000000 " & vbCrLf
            Sql &= " GROUP BY D.NUMERO_SOLICITUD,DD.SOLICITUD"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            ' agregando el checkbox
            If (NumCarga = 0) Then
                Dim chk As New DataGridViewCheckBoxColumn()
                DgvProgramaciones.Columns.Add(chk)
                chk.HeaderText = " "
                chk.Name = "chk"
                NumCarga = NumCarga + 1
            End If

            Me.DgvProgramaciones.DataSource = Table
            'Me.DgvProgramaciones.Rows(2).Cells(0).Value = True
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvProgramaciones.Columns(0).Width = 20
        Me.DgvProgramaciones.Columns(1).Width = 60
        Me.DgvProgramaciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramaciones.Columns(2).Width = 230
        Me.DgvProgramaciones.Columns(3).Width = 70
        Me.DgvProgramaciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramaciones.Columns(3).DefaultCellStyle.Format = "#,###.00"
        Me.DgvProgramaciones.Columns(4).Width = 70
        Me.DgvProgramaciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramaciones.Columns(5).Width = 70
        Me.DgvProgramaciones.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramaciones.Columns(6).Width = 70
        Me.DgvProgramaciones.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramaciones.Columns(6).DefaultCellStyle.Format = "#,###.00"
        Me.DgvProgramaciones.Columns(7).Width = 75
        Me.DgvProgramaciones.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramaciones.Columns(8).Width = 75
        Me.DgvProgramaciones.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramaciones.Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"
        Me.DgvProgramaciones.Columns(9).Width = 70
        Me.DgvProgramaciones.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramaciones.Columns(9).DefaultCellStyle.Format = "#,###.00"
        Me.DgvProgramaciones.Columns(10).Visible = False
    End Sub

    Private Function NumeroDeCuotasA_Reprogramar() As Integer
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_Track As New SqlConnection
        'Dim Comando_Track As SqlCommand
        'Dim DataReader_Track As SqlDataReader
        'Dim NumeroCuo As Integer
        'Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & DgvProgramacionesDetalle.CurrentRow.Cells(0).Value & "," & DgvProgramacionesDetalle.CurrentRow.Cells(1).Value & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 3
        '    Comando_Track = New SqlCommand(Sql, Conexion_Track)
        '    DataReader_Track = Comando_Track.ExecuteReader
        '    If DataReader_Track.Read = True Then
        '        NumeroCuo = DataReader_Track.Item("Cuotas a reprogramar")
        '    End If
        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'Return NumeroCuo
    End Function
    Private Sub MantenimientoFechaDetalle(ByVal LineaCuota, ByVal NuevaFechaPag, ByVal Bandera)
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_Track As New SqlConnection
        'Dim Comando_Track As SqlCommand
        'Dim DataReader_Track As SqlDataReader
        'Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & DgvProgramacionesDetalle.CurrentRow.Cells(0).Value & "," & LineaCuota & ",'" & Format(NuevaFechaPag, "dd-MM-yyyy HH:mm:ss") & "','" & Usuario & "'," & Bandera
        '    Comando_Track = New SqlCommand(Sql, Conexion_Track)
        '    DataReader_Track = Comando_Track.ExecuteReader
        '    If DataReader_Track.Read = True Then

        '    End If
        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub
    Private Function FechaUltimoPago() As DateTime
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_Track As New SqlConnection
        'Dim Comando_Track As SqlCommand
        'Dim DataReader_Track As SqlDataReader
        'Dim FechaUltimoPag As DateTime
        'Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & DgvProgramacionesDetalle.CurrentRow.Cells(0).Value & "," & DgvProgramacionesDetalle.CurrentRow.Cells(1).Value & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 5
        '    Comando_Track = New SqlCommand(Sql, Conexion_Track)
        '    DataReader_Track = Comando_Track.ExecuteReader
        '    If DataReader_Track.Read = True Then
        '        FechaUltimoPag = DataReader_Track.Item("FECHA_PAGO")
        '    End If
        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'Return FechaUltimoPag
    End Function
    Private Function FechaProxPago() As DateTime
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_Track As New SqlConnection
        'Dim Comando_Track As SqlCommand
        'Dim DataReader_Track As SqlDataReader
        'Dim FechaProxPag As DateTime
        'Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & DgvProgramacionesDetalle.CurrentRow.Cells(0).Value & "," & DgvProgramacionesDetalle.CurrentRow.Cells(1).Value & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 4
        '    Comando_Track = New SqlCommand(Sql, Conexion_Track)
        '    DataReader_Track = Comando_Track.ExecuteReader
        '    If DataReader_Track.Read = True Then
        '        FechaProxPag = DataReader_Track.Item("FECHA_PAGO")
        '    Else
        '        FechaProxPag = FechaUltimoPago()
        '    End If
        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'Return FechaProxPag
    End Function
    Private Sub CargaDetalleProgramaciones()
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_Track As New SqlConnection
        'Dim Comando_Track As SqlCommand
        'Dim DataAdapter_ As SqlDataAdapter
        'Dim Table As DataTable
        'Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & DgvProgramaciones.CurrentRow.Cells(0).Value & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 2
        '    Comando_Track = New SqlCommand(Sql, Conexion_Track)
        '    DataAdapter_ = New SqlDataAdapter(Comando_Track)
        '    Table = New DataTable("Datos")
        '    DgvProgramacionesDetalle.Columns.Clear()
        '    DataAdapter_.Fill(Table)
        '    Me.DgvProgramacionesDetalle.DataSource = Table
        '    LimpiaGridDetalle()
        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub
    Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TxtCodigoAs.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtNombre.Text = Nothing
        Me.DgvProgramaciones.DataSource = Nothing
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress, TxtCodigoBuxis.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoAs.Text <> Nothing Or Me.TxtCodigoBuxis.Text <> Nothing Then
                ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoBux = Val(Me.TxtCodigoBuxis.Text)
                BuscaSocio()
                If Hay_Datos Then
                    ParamcodigoBux = TxtCodigoBuxis.Text
                    CargaProgramaciones()
                Else
                    Me.TxtCodigoAs.Text = ""
                End If
                Me.chkAll.Visible = True
            End If
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btnReprogramar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprogramar.Click
        Dim frmReprogramar As New FrmReprogramarSolicitud
        Dim i As Integer

        For i = 0 To Me.DgvProgramaciones.Rows.Count - 1
            If (Me.DgvProgramaciones.Rows(i).Cells(0).Value) Then
                frmReprogramar.NumSolicitud_Value = Me.DgvProgramaciones.Rows(i).Cells(1).Value
                frmReprogramar.TxtCapital.Text = Me.DgvProgramaciones.Rows(i).Cells(3).Value
            End If
        Next

        separarProgEspecial(frmReprogramar.NumSolicitud_Value.ToString())
        Try
            CargaProgramaciones()
            frmReprogramar.TxtCapital.Text = Format(jClass.obtenerEscalar("SELECT SUM(CAPITAL) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD IN (" & frmReprogramar.NumSolicitud_Value.ToString() & ") AND CAPITAL_D = 0"), "0.00")
            CargaProgramaciones()
            frmReprogramar.TxtCodigoAs.Text = Me.TxtCodigoAs.Text
            frmReprogramar.TxtCodigoBuxis.Text = Me.TxtCodigoBuxis.Text
            frmReprogramar.TxtNombre.Text = Me.TxtNombre.Text
            frmReprogramar.ShowDialog(Me)
            CargaProgramaciones()
            LimpiaGrid()
            Me.btnReprogramar.Enabled = False
            Me.btnConsolidar.Enabled = False
            Me.btnAbonoEfectivo.Enabled = False
            Me.btnAnular.Enabled = False
            Me.btnSeparar.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnConsolidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidar.Click
        'If DgvProgramaciones.CurrentRow Is Nothing Then
        '    MessageBox.Show("Debe de seleccionar un tipo de deuda a consolidar", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        Dim tipoSolicitud As String
        Dim i As Integer
        Dim j As Integer
        Dim solicitudes As String
        solicitudes = ""
        j = 0
        Dim FrmConsolidar As New FrmConsolidarDeudas
        For i = 0 To Me.DgvProgramaciones.Rows.Count() - 1
            If (Me.DgvProgramaciones.Rows(i).Cells(0).Value) Then
                If j = 0 Then
                    solicitudes = Me.DgvProgramaciones.Rows(i).Cells(1).Value
                Else
                    solicitudes = solicitudes & "," & Me.DgvProgramaciones.Rows(i).Cells(1).Value
                End If
                j = j + 1
            End If
        Next
        Try
            separarProgEspecial(solicitudes)
            CargaProgramaciones()
            tipoSolicitud = DgvProgramaciones.CurrentRow.Cells(2).Value
            FrmConsolidar.totalDeudas = j
            FrmConsolidar.Compañia_Value = compañia
            FrmConsolidar.TxtNumSolicitudes.Text = Trim(solicitudes)
            FrmConsolidar.Cod_AS = Me.TxtCodigoAs.Text
            FrmConsolidar.Cod_buxis = Me.TxtCodigoBuxis.Text
            FrmConsolidar.Socio = Me.TxtNombre.Text
            FrmConsolidar.TipoDeuda = tipoSolicitud
            FrmConsolidar.ShowDialog(Me)
            CargaProgramaciones()
            LimpiaGrid()
            Me.btnConsolidar.Enabled = False
            Me.btnAbonoEfectivo.Enabled = False
            Me.btnAnular.Enabled = False
            Me.btnReprogramar.Enabled = False
            Me.btnSeparar.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAbonoEfectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbonoEfectivo.Click
        Dim frmAbonar As New frmAbonoEfectivo
        Dim i As Integer
        Dim j As Integer
        Dim sumaMontos As Double
        Dim solicitudes, tipoSol As String
        j = 0
        sumaMontos = 0
        solicitudes = ""
        tipoSol = ""
        For i = 0 To DgvProgramaciones.Rows.Count - 1
            If (DgvProgramaciones.Rows(i).Cells(0).Value) Then
                If j = 0 Then
                    solicitudes &= Me.DgvProgramaciones.Rows(i).Cells(1).Value
                    tipoSol = Me.DgvProgramaciones.Rows(i).Cells(2).Value
                Else
                    If tipoSol = Me.DgvProgramaciones.Rows(i).Cells(2).Value Then
                        solicitudes &= "," & Me.DgvProgramaciones.Rows(i).Cells(1).Value
                    Else
                        MsgBox("Debe elegir deudas del mismo tipo para efectuar el abono", MsgBoxStyle.Information, "Abonos")
                        Return
                    End If
                End If
                sumaMontos += Me.DgvProgramaciones.Rows(i).Cells(3).Value
                j += 1
            End If
        Next
        Try
            separarProgEspecial(solicitudes)
            CargaProgramaciones()
            sumaMontos = jClass.obtenerEscalar("SELECT SUM(CAPITAL) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD IN (" & solicitudes & ") AND CAPITAL_D = 0")
            CargaProgramaciones()
            frmAbonar.totalSolicitudes = j
            frmAbonar.Num_Solicitud = solicitudes
            frmAbonar.TxtMonto.Text = sumaMontos
            frmAbonar.Compañia_Value = Compañia
            frmAbonar.Cod_AS = Me.TxtCodigoAs.Text
            frmAbonar.Cod_buxis = Me.TxtCodigoBuxis.Text
            frmAbonar.Socio = Me.TxtNombre.Text
            frmAbonar.ShowDialog(Me)
            CargaProgramaciones()
            LimpiaGrid()
            Me.btnConsolidar.Enabled = False
            Me.btnAbonoEfectivo.Enabled = False
            Me.btnReprogramar.Enabled = False
            Me.btnAnular.Enabled = False
            Me.btnSeparar.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvProgramaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProgramaciones.CellContentClick
        Dim seleccionados As Integer
        Dim i As Integer
        'cambio del checkbox 
        If DgvProgramaciones.CurrentRow.Cells(0).Value Then
            DgvProgramaciones.CurrentRow.Cells(0).Value = False
        Else
            DgvProgramaciones.CurrentRow.Cells(0).Value = True
        End If

        'Efectos de los botones
        seleccionados = 0
        For i = 0 To DgvProgramaciones.Rows.Count - 1
            If (DgvProgramaciones.Rows(i).Cells(0).Value) Then
                seleccionados = seleccionados + 1
            End If
        Next

        If (seleccionados = 0) Then
            Me.btnAbonoEfectivo.Enabled = False
            Me.btnConsolidar.Enabled = False
            Me.btnReprogramar.Enabled = False
            Me.btnAnular.Enabled = False
            Me.btnSeparar.Enabled = False
            Me.btnConsultarDetalle.Enabled = False
            Me.btnConsultar.Enabled = False
        End If
        If (seleccionados = 1) Then
            Me.btnReprogramar.Enabled = True
            Me.btnAbonoEfectivo.Enabled = True
            Me.btnConsolidar.Enabled = False
            Me.btnAnular.Enabled = True
            Me.btnSeparar.Enabled = True
            Me.btnConsultarDetalle.Enabled = True
            Me.btnConsultar.Enabled = False
        End If
        If (seleccionados > 1) Then
            Me.btnReprogramar.Enabled = False
            Me.btnAbonoEfectivo.Enabled = True
            Me.btnConsolidar.Enabled = True
            Me.btnAnular.Enabled = False
            Me.btnSeparar.Enabled = True
            Me.btnConsultarDetalle.Enabled = False
            Me.btnConsultar.Enabled = True
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim frmAnular As New frmAnularSolicitudReversion
        Dim solicitud As String = String.Empty
        Dim i As Integer
        Dim deuda As Double
        For i = 0 To Me.DgvProgramaciones.Rows.Count - 1
            If Me.DgvProgramaciones.Rows(i).Cells(0).Value Then
                solicitud = Me.DgvProgramaciones.Rows(i).Cells(1).Value
                deuda = Me.DgvProgramaciones.Rows(i).Cells(3).Value
            End If
        Next
        frmAnular.codigoAs = Me.TxtCodigoAs.Text.Trim
        frmAnular.codigoBuxis = Me.TxtCodigoBuxis.Text.Trim
        frmAnular.company = Compañia
        frmAnular.noSoli = solicitud
        frmAnular.nombreSocio = Me.TxtNombre.Text.Trim
        frmAnular.deuda = deuda
        frmAnular.ShowDialog()
        CargaProgramaciones()
        LimpiaGrid()
        Me.btnConsolidar.Enabled = False
        Me.btnAbonoEfectivo.Enabled = False
        Me.btnReprogramar.Enabled = False
        Me.btnAnular.Enabled = False
        Me.btnSeparar.Enabled = False
    End Sub

    Private Sub FrmModificarProgramaciones_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TxtCodigoBuxis.Clear()
        Me.TxtCodigoAs.Clear()
        Me.TxtNombre.Clear()
        While Me.DgvProgramaciones.Rows.Count > 0
            Me.DgvProgramaciones.Rows.RemoveAt(0)
        End While
        Me.chkAll.Visible = False
        Me.btnConsolidar.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For i As Integer = 0 To DgvProgramaciones.Rows.Count - 1
            DgvProgramaciones.Rows(i).Cells(0).Value = True
        Next

        Dim _x As Integer
        If chkAll.Checked Then
            For _x = 0 To DgvProgramaciones.Rows.Count - 1
                DgvProgramaciones.Rows(_x).Cells(0).Value = True
            Next
            Me.btnConsultarDetalle.Enabled = False
            Me.btnConsultar.Enabled = True
        End If

        If Not chkAll.Checked Then
            For _x = 0 To DgvProgramaciones.Rows.Count - 1
                DgvProgramaciones.Rows(_x).Cells(0).Value = False
            Next
            Me.btnConsultarDetalle.Enabled = False
            Me.btnConsultar.Enabled = False
        End If
    End Sub

    Private Sub separarProgEspecial(ByVal solicitudes As String)
        Dim opc As Integer = jClass.obtenerEscalar("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & solicitudes & "', @BANDERA = 1")
        If opc > 0 Then
            If MsgBox("Entre las solicitudes seleccionadas existen cuotas especiales" & vbCrLf & "¿Desea separar las cuotas especiales antes de continuar?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                jClass.ejecutarComandoSql(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & solicitudes & "', @BANDERA = 0"))
            End If
        End If
    End Sub

    Private Sub btnSeparar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeparar.Click
        Dim i As Integer
        Dim j As Integer
        Dim solicitudes As String = String.Empty
        j = 0
        For i = 0 To Me.DgvProgramaciones.Rows.Count() - 1
            If (Me.DgvProgramaciones.Rows(i).Cells(0).Value) Then
                If j = 0 Then
                    solicitudes = Me.DgvProgramaciones.Rows(i).Cells(1).Value
                Else
                    solicitudes = solicitudes & "," & Me.DgvProgramaciones.Rows(i).Cells(1).Value
                End If
                j = j + 1
            End If
        Next
        If solicitudes.Length > 0 Then
            If MsgBox("¿Desea separar las cuotas especiales de las solicitudes seleccionadas?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                jClass.ejecutarComandoSql(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & solicitudes & "'"))
            End If
        End If
        CargaProgramaciones()
        Me.btnReprogramar.Enabled = False
        Me.btnConsolidar.Enabled = False
        Me.btnAbonoEfectivo.Enabled = False
        Me.btnAnular.Enabled = False
        Me.btnSeparar.Enabled = False
    End Sub

    Private Sub btnConsultarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarDetalle.Click
        Dim i As Integer
        Dim j As Integer
        Dim _otrogado As Date
        Dim _solicitud As Integer

        j = 0

        For i = 0 To DgvProgramaciones.Rows.Count - 1
            If (DgvProgramaciones.Rows(i).Cells(0).Value) Then
                If j = 0 Then
                    _solicitud = Me.DgvProgramaciones.Rows(i).Cells(1).Value
                    _otrogado = Me.DgvProgramaciones.Rows(i).Cells(8).Value
                Else                    
                    MsgBox("Seleccione una solicitud solamente.", MsgBoxStyle.Information, "Sistema")
                    Return
                End If
                j += 1
            End If
        Next

        Dim _frm_visualizar As New FrmModificarProgramacionesVisualizarDetalles()
        _frm_visualizar._codigo_socio = CInt(TxtCodigoBuxis.Text)
        _frm_visualizar._num_solicitud = _solicitud
        _frm_visualizar._nombre_socio = Me.TxtNombre.Text
        _frm_visualizar._fecha_otorgado = _otrogado
        _frm_visualizar.ShowDialog()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim i As Integer
        Dim _solicitudes As String = String.Empty

        For i = 0 To DgvProgramaciones.Rows.Count - 1
            If (DgvProgramaciones.Rows(i).Cells(0).Value) Then
                _solicitudes &= Me.DgvProgramaciones.Rows(i).Cells(1).Value & ","
            End If
        Next

        _solicitudes = _solicitudes.TrimEnd(",")
        If _solicitudes.Length > 0 Then
            Dim _form As New FrmModificarProgramacionesVisualizarVariasSolicitudes()
            _form._codigo_socio = CInt(TxtCodigoBuxis.Text)
            _form._solicitudes = _solicitudes
            _form._nombre_socio = Me.TxtNombre.Text
            Dim c As Integer
            For c = 0 To DgvProgramaciones.Rows.Count - 1
                If (DgvProgramaciones.Rows(c).Cells(0).Value) Then
                    _form._solicitud_tipo &= Me.DgvProgramaciones.Rows(c).Cells(10).Value & ","
                End If
            Next
            _form._solicitud_tipo = _form._solicitud_tipo.TrimEnd(",")
            _form.ShowDialog()
        Else
            MsgBox("No ha seleccionado solicitudes.", MsgBoxStyle.Information)
        End If
    End Sub
End Class