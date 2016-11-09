Imports System.Data
Imports System.Data.SqlClient

Public Class FrmManSolicitudes
    Dim sql As String
    Dim Iniciando As Boolean
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.TxtDescripcion.Text = Nothing Then
            Me.TxtDescripcion.BackColor = Color.LightYellow
            MsgBox("Debe de ingresar una: Descripción", MsgBoxStyle.Information)
            Me.TxtDescripcion.Focus()
            Return
        Else
            Me.TxtDescripcion.BackColor = Color.White
        End If
        '----------
        'If Me.TxtMontoIni.Text = Nothing Then
        '    Me.TxtMontoIni.BackColor = Color.LightYellow
        '    MsgBox("Debe de ingresar un:  Monto Inicial", MsgBoxStyle.Information)
        '    Me.TxtMontoIni.Focus()
        '    Return
        'Else
        '    Me.TxtMontoIni.BackColor = Color.White
        'End If
        '-----------
        'If Me.TxtMontoFin.Text = Nothing Then
        '    Me.TxtMontoFin.BackColor = Color.LightYellow
        '    MsgBox("Debe de ingresar un: Monto Final", MsgBoxStyle.Information)
        '    Me.TxtMontoFin.Focus()
        '    Return
        'Else
        '    Me.TxtMontoFin.BackColor = Color.White
        'End If
        '-----------
        'If Me.TxtMontoMax.Text = Nothing Then
        '    Me.TxtMontoMax.BackColor = Color.LightYellow
        '    MsgBox("Debe de ingresar un: Monto Maximo", MsgBoxStyle.Information)
        '    Me.TxtMontoMax.Focus()
        '    Return
        'Else
        '    Me.TxtMontoMax.BackColor = Color.White
        'End If
        '-----------
        'If Me.NudCuotaMin.Text = Nothing Then
        '    Me.NudCuotaMin.BackColor = Color.LightYellow
        '    MsgBox("Debe de ingresar una: Cuota Minima", MsgBoxStyle.Information)
        '    Me.NudCuotaMin.Focus()
        '    Return
        'Else
        '    Me.NudCuotaMin.BackColor = Color.White
        'End If
        '-----------
        If Me.NudCuotaMax.Text = Nothing Then
            Me.NudCuotaMax.Text = "1"
            'Me.NudCuotaMax.BackColor = Color.LightYellow
            'MsgBox("Debe de ingresar una: Cuota Maxima", MsgBoxStyle.Information)
            'Me.NudCuotaMax.Focus()
            'Return
        Else
            Me.NudCuotaMax.BackColor = Color.White
        End If
        '-----------
        'If CDbl(Me.TxtMontoFin.Text) < CDbl(Me.TxtMontoIni.Text) Then
        '    MsgBox("El monto Final no puede ser menor que el monto Inicial", MsgBoxStyle.Information)
        '    Me.TxtMontoFin.Text = Nothing
        '    Me.TxtMontoFin.Focus()
        '    Return
        'End If
        '-----------
        'If CDbl(Me.TxtMontoMax.Text) < CDbl(Me.TxtMontoFin.Text) Then
        '    MsgBox("El monto Maximo no puede ser menor que el monto Final", MsgBoxStyle.Information)
        '    Me.TxtMontoMax.Text = Nothing
        '    Me.TxtMontoMax.Focus()
        '    Return
        'End If
        '-----------
        'If NudCuotaMax.Value < NudCuotaMin.Value Then
        '    MessageBox.Show("La Cuota Maxima no puede ser menor que la Cuota Minima", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    Me.NudCuotaMax.Value = 1
        '    Me.NudCuotaMax.Focus()
        '    Return
        'End If
        If Me.TxtCodigoSolicitud.Text = 0 Then
            Mantenimiento_Solicitudes("I")
            CargaSolicitudes(Compañia)
            Limpiar_Objetos()
        Else
            Mantenimiento_Solicitudes("U")
            CargaSolicitudes(Compañia)
            Limpiar_Objetos()
        End If
    End Sub
    Private Sub Mantenimiento_Solicitudes(ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "EXECUTE dbo.sp_COOPERATIVA_CATALOGO_SOLICITUDES_IUD " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & "," & vbCrLf
            sql &= "@SOLICITUD = " & CInt(Me.TxtCodigoSolicitud.Text) & "," & vbCrLf
            sql &= "@DEDUCCION = " & CbxDeduccion.SelectedValue & "," & vbCrLf
            sql &= "@TIPO_DOCUMENTO = " & CbxTipDocumento.SelectedValue & "," & vbCrLf
            sql &= "@DESCRIPCION_SOLICITUD = '" & Trim(Me.TxtDescripcion.Text) & "'," & vbCrLf
            sql &= "@DESCUENTOS_VARIOS_PERIODOS = " & IIf(ChxVariosPeriodos.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@PERIODO = 'QQ'," & vbCrLf
            sql &= "@CUOTA_INICIAL = " & NudCuotaMin.Value & "," & vbCrLf
            sql &= "@CUOTA_FINAL = " & Me.NudCuotaMax.Value & "," & vbCrLf
            sql &= "@COTIZACION = " & IIf(ChxCotizacion.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@ORDEN_COMPRA = " & IIf(ChxOrdenCompra.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@MONTO_INICIAL = " & Val(Me.TxtMontoIni.Text) & "," & vbCrLf
            sql &= "@MONTO_FINAL = " & Val(Me.TxtMontoFin.Text) & "," & vbCrLf
            sql &= "@MONTO_MAXIMO = " & Val(Me.TxtMontoMax.Text) & "," & vbCrLf
            sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
            sql &= "@IUD = '" & IUD & "'," & vbCrLf
            sql &= "@CON_IVA = " & IIf(ChxGeneraIVA.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@ES_PRESTAMO = " & IIf(Me.chkTipoPrestamo.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@MOSTRAR_LIS = " & IIf(Me.chxMostrarlistado.Checked = True, "1", "0") & "," & vbCrLf
            sql &= "@SOLO_SOCIOS = " & IIf(Me.chkSoloSocios.Checked = True, "1", "0")
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Select Case IUD
                Case "I"
                    MsgBox("¡Solicitud Creada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡La solicitud: " + Me.TxtDescripcion.Text + " ha sido modificada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("¡Solicitud Eliminada con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Deducciones(ByVal Compania)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & Compania & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "Deducción"
            Me.CbxDeduccion.DisplayMember = "Descripción Deducción"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaTipoDocumento()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute dbo.sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO " & Compañia & "," & 1
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxTipDocumento.DataSource = Table
            Me.CbxTipDocumento.ValueMember = "TIPO_DOCUMENTO"
            Me.CbxTipDocumento.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Limpiar_Objetos()
        TxtCodigoSolicitud.Text = 0
        TxtDescripcion.Text = Nothing
        NudCuotaMin.Value = 1
        NudCuotaMax.Value = 1
        TxtMontoIni.Text = "0.00"
        ChxVariosPeriodos.Checked = False
        ChxCotizacion.Checked = False
        ChxOrdenCompra.Checked = False
        TxtMontoFin.Text = "0.00"
        TxtMontoMax.Text = "0.00"
        Me.BtnEliminar.Enabled = True
        Me.BtnGuardar.Enabled = True
    End Sub
    Private Sub CargaSolicitudes(ByVal compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "EXECUTE Coo.sp_COOPERATIVA_CATALOGO_SOLICITUDES @COMPAÑIA = " & compañia
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DgvSolicitudes.DataSource = Table
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(1).Width = 50
        Me.DgvSolicitudes.Columns(2).Width = 150
        Me.DgvSolicitudes.Columns(3).Width = 60
        Me.DgvSolicitudes.Columns(5).Width = 180 'Descripcion Documento
        Me.DgvSolicitudes.Columns(6).Width = 50
        Me.DgvSolicitudes.Columns(7).Width = 50
        Me.DgvSolicitudes.Columns(10).Width = 60
        Me.DgvSolicitudes.Columns(11).Width = 60
        Me.DgvSolicitudes.Columns(15).Width = 75
        Me.DgvSolicitudes.Columns(16).Width = 125
        Me.DgvSolicitudes.Columns(0).Visible = False
        Me.DgvSolicitudes.Columns(4).Visible = False
        Me.DgvSolicitudes.Columns(18).Visible = False
        Me.DgvSolicitudes.Columns(19).Visible = False

        Me.DgvSolicitudes.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns.Item(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns.Item(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns.Item(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns.Item(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DgvSolicitudes.Columns.Item(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Me.DgvSolicitudes.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.DgvSolicitudes.Columns.Item(8).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(9).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(12).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(13).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(14).DefaultCellStyle.ForeColor = Color.Blue
        Me.DgvSolicitudes.Columns.Item(0).Frozen = True
        Me.DgvSolicitudes.Columns.Item(1).Frozen = True
        Me.DgvSolicitudes.Columns.Item(2).Frozen = True
        Me.DgvSolicitudes.Columns.Item(3).Frozen = True
    End Sub

    Private Sub FrmManSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaSolicitudes(Compañia)
        Deducciones(Compañia)
        CargaTipoDocumento()
        Me.BtnEliminar.Enabled = False
        Me.BtnGuardar.Enabled = False
        Iniciando = False
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub TxtCodigoSolicitud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoSolicitud.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtMontoIni_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoIni.KeyPress
        Dim cadena As String = TxtMontoIni.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtMontoFin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoFin.KeyPress
        Dim cadena As String = TxtMontoFin.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If Me.DgvSolicitudes.RowCount <= 0 Then
            MsgBox("¡Debe Seleccionar una Solicitud válida! Verifique", MsgBoxStyle.Critical, "Validación")
        Else
            Dim Result As DialogResult = MessageBox.Show("¿Está seguro(a) que desea eliminar la Solicitud N° " + TxtCodigoSolicitud.Text & " ?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If Result = Windows.Forms.DialogResult.Yes Then
                Mantenimiento_Solicitudes("D")
                CargaSolicitudes(Compañia)
                Limpiar_Objetos()
                CbxDeduccion.Enabled = True
                Me.BtnEliminar.Enabled = False
                Me.BtnGuardar.Enabled = False
            Else
            End If
        End If
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        Limpiar_Objetos()
        CbxDeduccion.Enabled = True
    End Sub

    Private Sub TxtMontoMax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoMax.KeyPress
        Dim cadena As String = TxtMontoMax.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NudCuotaMin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudCuotaMin.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub NudCuotaMax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudCuotaMax.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub DgvSolicitudes_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitudes.CellEnter
        Dim jars As New jarsClass
        Try
            If Me.DgvSolicitudes.RowCount <= 0 Then
            Else
                TxtCodigoSolicitud.Text = DgvSolicitudes.CurrentRow.Cells(1).Value
                TxtDescripcion.Text = DgvSolicitudes.CurrentRow.Cells(2).Value
                CbxDeduccion.SelectedValue = DgvSolicitudes.CurrentRow.Cells(3).Value
                CbxTipDocumento.SelectedValue = DgvSolicitudes.CurrentRow.Cells(4).Value 'Tipo Documento
                ChxVariosPeriodos.Checked = DgvSolicitudes.CurrentRow.Cells(6).Value
                NudCuotaMin.Value = DgvSolicitudes.CurrentRow.Cells(8).Value
                NudCuotaMax.Value = DgvSolicitudes.CurrentRow.Cells(9).Value
                ChxCotizacion.Checked = DgvSolicitudes.CurrentRow.Cells(10).Value
                ChxOrdenCompra.Checked = DgvSolicitudes.CurrentRow.Cells(11).Value
                TxtMontoIni.Text = DgvSolicitudes.CurrentRow.Cells(12).Value
                TxtMontoFin.Text = DgvSolicitudes.CurrentRow.Cells(13).Value
                TxtMontoMax.Text = DgvSolicitudes.CurrentRow.Cells(14).Value
                ChxGeneraIVA.Checked = DgvSolicitudes.CurrentRow.Cells(17).Value
                Me.chkTipoPrestamo.Checked = DgvSolicitudes.CurrentRow.Cells(18).Value
                Me.chxMostrarlistado.Checked = DgvSolicitudes.CurrentRow.Cells(19).Value
                Me.chkSoloSocios.Checked = DgvSolicitudes.CurrentRow.Cells(20).Value
                Me.BtnEliminar.Enabled = True
                Me.BtnGuardar.Enabled = True
                CbxDeduccion.Enabled = False

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FrmManSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class