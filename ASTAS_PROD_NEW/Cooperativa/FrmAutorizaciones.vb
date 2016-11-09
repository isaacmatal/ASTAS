Imports System.Data
Imports System.Data.SqlClient
Public Class FrmAutorizaciones
    Dim Sql As String
    Public TipoSolicitud As Integer
    Public compañia As Integer
    Public Iniciando As Boolean
    Private Sub FrmAutorizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        DpFechaA1.Value = FechaActual()
        DpFechaA2.Value = FechaActual()
        DpFechaA3.Value = FechaActual()
        DpFechaAnulada.Value = FechaActual()
        DpFechaDenegada.Value = FechaActual()
        CargaCompany(Usuario, 1)
        Me.CbxCompania.SelectedValue = compañia
        CargaUsuarios()
        CbxUsuarios.Text = Usuario
        MuestraUsuarios()
        Me.lblNumeroSol.Text = Val(ParamcodSolicitud)
        ParamcodSolicitud = Nothing
        MuestraAutorizaciones()
        DeshabilitarOpciones()
        Iniciando = False
    End Sub
    Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERA)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Me.CbxCompania.DataSource = Table
                Me.CbxCompania.ValueMember = "COMPAÑIA"
                Me.CbxCompania.DisplayMember = "NOMBRE_COMPAÑIA"
                Me.CbxCompania.SelectedItem = 1
            Else
                MsgBox("No se ha encontrado ninguna Compañia ", MsgBoxStyle.Information)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function FechaActual() As Date
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Fecha As Date
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR'" & 0 & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DataAdapter_.Fill(DS)
            Fecha = DS.Tables(0).Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Fecha
    End Function
    Private Sub MuestraAutorizaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_AUTORIZACION " & CbxCompania.SelectedValue & "," & CInt(lblNumeroSol.Text)
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Me.ChxAutorizacionUno.Checked = DataReader_Track.Item("AUTORIZACION1")
                Me.TxtComentario1.Text = DataReader_Track.Item("COMENTARIO1")
                Me.ChxAutorizacionDos.Checked = DataReader_Track.Item("AUTORIZACION2")
                Me.TxtComentario2.Text = DataReader_Track.Item("COMENTARIO2")
                Me.ChxAutorizacionTres.Checked = DataReader_Track.Item("AUTORIZACION3")
                Me.TxtComentario3.Text = DataReader_Track.Item("COMENTARIO3")
                Me.ChxDenegada.Checked = DataReader_Track.Item("DENEGADA")
                Me.TxtComenDenegada.Text = DataReader_Track.Item("COMENTARIO_DENEGADA")
                Me.ChxAnulada.Checked = DataReader_Track.Item("ANULADA")
                Me.TxtComentAnulada.Text = DataReader_Track.Item("COMENTARIO_ANULADA")
                If Me.ChxAutorizacionUno.Checked = True Then
                    Me.DpFechaA1.Value = DataReader_Track.Item("FECHA1")
                End If
                If Me.ChxAutorizacionDos.Checked = True Then
                    Me.DpFechaA2.Value = DataReader_Track.Item("FECHA2")
                End If
                If Me.ChxAutorizacionTres.Checked = True Then
                    Me.DpFechaA3.Value = DataReader_Track.Item("FECHA3")
                End If
                If Me.ChxDenegada.Checked = True Then
                    Me.DpFechaDenegada.Value = DataReader_Track.Item("FECHA_DENEGADA")
                End If
                If Me.ChxAnulada.Checked = True Then
                    Me.DpFechaAnulada.Value = DataReader_Track.Item("FECHA_ANULADA")
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ActualizarAutorizaciones(ByVal Autorizacion)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = CbxCompania.SelectedValue
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = CInt(lblNumeroSol.Text)
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = IIf(ChxAutorizacionUno.Checked = True, 1, 0)
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = TxtComentario1.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = DpFechaA1.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = IIf(ChxAutorizacionDos.Checked = True, 1, 0)
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = TxtComentario2.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = DpFechaA2.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = IIf(ChxAutorizacionTres.Checked = True, 1, 0)
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = TxtComentario3.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = DpFechaA3.Value
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = IIf(ChxDenegada.Checked = True, 1, 0)
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = TxtComenDenegada.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = DpFechaDenegada.Value
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = Trim(CbxUsuarios.Text)
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = IIf(ChxAnulada.Checked = True, 1, 0)
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = TxtComentAnulada.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = DpFechaAnulada.Value
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = Trim(CbxUsuarios.Text)
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_BUXIS", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_CREACION", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = Autorizacion
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub
    Private Sub CargaUsuarios()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES " & CbxCompania.SelectedValue & "," & 0 & ",'" & Usuario & "'," & TipoSolicitud & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                CbxUsuarios.DataSource = Table
                CbxUsuarios.ValueMember = "Correlativo"
                Me.CbxUsuarios.DisplayMember = "USUARIO"
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub MuestraUsuarios()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES " & CbxCompania.SelectedValue & "," & 0 & ",'" & Usuario & "'," & TipoSolicitud & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            While DataReader_Track.Read = True
                Select Case DataReader_Track.Item("Correlativo")
                    Case 1
                        Me.lblAutoriza1.Text = DataReader_Track.Item("Usuario")
                    Case 2
                        Me.lblAutoriza2.Text = DataReader_Track.Item("Usuario")
                    Case 3
                        Me.lblAutoriza3.Text = DataReader_Track.Item("Usuario")
                End Select
            End While
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidarAutorizacion(ByVal nAutorizacion) As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim bandera As Boolean
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES " & CbxCompania.SelectedValue & "," & nAutorizacion & ",'" & Usuario & "'," & TipoSolicitud & "," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                bandera = True
            Else
                bandera = False
            End If

            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bandera
    End Function
    Private Sub DeshabilitarOpciones()
        'If Trim(Me.TxtComentario1.Text) <> Nothing Then
        If Me.ChxAutorizacionUno.Checked = True Then
            Me.ChxAutorizacionUno.Enabled = False
            Me.BtnAutorizacion1.Enabled = False
            Me.TxtComentario1.BackColor = Color.LightGray
        End If
        If Trim(Me.TxtComentario2.Text) <> Nothing Then
            Me.ChxAutorizacionDos.Enabled = False
            Me.BtnAutorizacion2.Enabled = False
            Me.TxtComentario2.BackColor = Color.LightGray
        End If
        If Trim(Me.TxtComentario3.Text) <> Nothing Then
            Me.ChxAutorizacionTres.Enabled = False
            Me.BtnAutorizacion3.Enabled = False
            Me.TxtComentario3.BackColor = Color.LightGray
        End If
        If Trim(Me.TxtComenDenegada.Text) <> Nothing Then
            Me.ChxDenegada.Enabled = False
            Me.BtnDenegar.Enabled = False
        End If
        If Trim(Me.TxtComentAnulada.Text) <> Nothing Then
            Me.ChxAnulada.Enabled = False
            Me.BtnAnular.Enabled = False
        End If
    End Sub
    Private Sub ChxAutorizacionUno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChxAutorizacionUno.CheckedChanged
        If Iniciando = False Then
            If ChxAutorizacionUno.Checked = True Then
                If ValidarAutorizacion(1) = False Then
                    Dim Resultado As DialogResult = MessageBox.Show("¿Usted No es el Usuario Indicado para autorizar, ¿Esta seguro de querer realizar esta autorizacion? ", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                    If Resultado = Windows.Forms.DialogResult.Yes Then
                        Me.BtnAutorizacion1.Enabled = True
                        Me.TxtComentario1.ReadOnly = False
                        Me.TxtComentario1.BackColor = Color.White
                    Else
                        Me.BtnAutorizacion1.Enabled = False
                        Me.TxtComentario1.ReadOnly = True
                        ChxAutorizacionUno.Checked = False
                        Me.TxtComentario1.BackColor = Color.LightGray
                        Return
                    End If
                Else
                    Me.BtnAutorizacion1.Enabled = True
                    Me.TxtComentario1.ReadOnly = False
                    Me.TxtComentario1.BackColor = Color.White
                End If
            Else
                Me.BtnAutorizacion1.Enabled = False
                Me.TxtComentario1.ReadOnly = True
                Me.TxtComentario1.Text = ""
                Me.TxtComentario1.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Private Sub ChxAutorizacionDos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChxAutorizacionDos.CheckedChanged
        If Iniciando = False Then
            If ChxAutorizacionDos.Checked = True Then
                If ValidarAutorizacion(2) = False Then
                    Dim Resultado As DialogResult = MessageBox.Show("¿Usted No es el Usuario Indicado para autorizar, ¿Esta seguro de querer realizar esta autorizacion? ", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                    If Resultado = Windows.Forms.DialogResult.Yes Then
                        Me.BtnAutorizacion2.Enabled = True
                        Me.TxtComentario2.ReadOnly = False
                        Me.TxtComentario2.BackColor = Color.White
                    Else
                        Me.BtnAutorizacion2.Enabled = False
                        Me.TxtComentario2.ReadOnly = True
                        ChxAutorizacionDos.Checked = False
                        Me.TxtComentario2.BackColor = Color.LightGray
                        Return
                    End If
                Else
                    Me.BtnAutorizacion2.Enabled = True
                    Me.TxtComentario2.ReadOnly = False
                    Me.TxtComentario2.BackColor = Color.White
                End If
            Else
                Me.BtnAutorizacion2.Enabled = False
                Me.TxtComentario2.ReadOnly = True
                Me.TxtComentario2.Text = ""
                Me.TxtComentario2.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub ChxAutorizacionTres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChxAutorizacionTres.CheckedChanged
        If Iniciando = False Then
            If ChxAutorizacionTres.Checked = True Then
                If ValidarAutorizacion(3) = False Then
                    Dim Resultado As DialogResult = MessageBox.Show("¿Usted No es el Usuario Indicado para autorizar, ¿Esta seguro de querer realizar esta autorizacion? ", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                    If Resultado = Windows.Forms.DialogResult.Yes Then
                        Me.BtnAutorizacion3.Enabled = True
                        Me.TxtComentario3.ReadOnly = False
                        Me.TxtComentario3.BackColor = Color.White
                    Else
                        Me.BtnAutorizacion3.Enabled = False
                        Me.TxtComentario3.ReadOnly = True
                        ChxAutorizacionTres.Checked = False
                        Me.TxtComentario3.BackColor = Color.LightGray
                        Return
                    End If
                Else
                    Me.BtnAutorizacion3.Enabled = True
                    Me.TxtComentario3.ReadOnly = False
                    Me.TxtComentario3.BackColor = Color.White
                End If
            Else
                Me.BtnAutorizacion3.Enabled = False
                Me.TxtComentario3.ReadOnly = True
                Me.TxtComentario3.Text = ""
                Me.TxtComentario3.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Private Sub BtnAutorizacion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizacion1.Click
        If Trim(Me.TxtComentario1.Text) = Nothing Then
            MsgBox("El campo comentario es requerido", MsgBoxStyle.Information)
            Me.TxtComentario1.Focus()
        Else
            ActualizarAutorizaciones(1)
            MsgBox("La solicitud Nº " + lblNumeroSol.Text + " ha sido autorizada", MsgBoxStyle.Information)
            Me.ChxAutorizacionUno.Enabled = False
            Me.TxtComentario1.ReadOnly = True
            Me.BtnAutorizacion1.Enabled = False
        End If

    End Sub

    Private Sub BtnAutorizacion2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizacion2.Click
        If Trim(Me.TxtComentario2.Text) = Nothing Then
            MsgBox("El campo comentario es requerido", MsgBoxStyle.Information)
            Me.TxtComentario2.Focus()
        Else
            ActualizarAutorizaciones(2)
            MsgBox("La solicitud Nº " + lblNumeroSol.Text + " ha sido autorizada", MsgBoxStyle.Information)
            Me.ChxAutorizacionDos.Enabled = False
            Me.TxtComentario2.ReadOnly = True
            Me.BtnAutorizacion2.Enabled = False
        End If
    End Sub

    Private Sub BtnAutorizacion3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizacion3.Click
        If Trim(Me.TxtComentario3.Text) = Nothing Then
            MsgBox("El campo comentario es requerido", MsgBoxStyle.Information)
            Me.TxtComentario3.Focus()
        Else
            ActualizarAutorizaciones(3)
            MsgBox("La solicitud Nº " + lblNumeroSol.Text + " ha sido autorizada", MsgBoxStyle.Information)
            Me.ChxAutorizacionTres.Enabled = False
            Me.TxtComentario3.ReadOnly = True
            Me.BtnAutorizacion3.Enabled = False
        End If
    End Sub

    Private Sub BtnDenegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDenegar.Click
        If Trim(Me.TxtComenDenegada.Text) = Nothing Then
            MsgBox("El campo comentario es requerido", MsgBoxStyle.Information)
            Me.TxtComenDenegada.Focus()
        Else
            ActualizarAutorizaciones(4)
            MsgBox("La solicitud Nº " + lblNumeroSol.Text + " ha sido Denegada", MsgBoxStyle.Information)
            Me.ChxDenegada.Enabled = False
            Me.TxtComenDenegada.ReadOnly = False
            Me.BtnDenegar.Enabled = False
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        If Trim(Me.TxtComentAnulada.Text) = Nothing Then
            MsgBox("El campo comentario es requerido", MsgBoxStyle.Information)
            Me.TxtComentAnulada.Focus()
        Else
            ActualizarAutorizaciones(5)
            MsgBox("La solicitud Nº " + lblNumeroSol.Text + " ha sido Anulada", MsgBoxStyle.Information)
            Me.ChxAnulada.Enabled = False
            Me.TxtComentAnulada.ReadOnly = False
            Me.BtnAnular.Enabled = False
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub ChxDenegada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChxDenegada.CheckedChanged
        If Iniciando = False Then
            If ChxDenegada.Checked = True Then
                Me.BtnDenegar.Enabled = True
                TxtComenDenegada.ReadOnly = False
            Else
                Me.BtnDenegar.Enabled = False
                TxtComenDenegada.ReadOnly = True
                Me.TxtComenDenegada.Text = ""
            End If
        End If
    End Sub

    Private Sub ChxAnulada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChxAnulada.CheckedChanged
        If Iniciando = False Then
            If ChxAnulada.Checked = True Then
                Me.BtnAnular.Enabled = True
                TxtComentAnulada.ReadOnly = False
            Else
                Me.BtnAnular.Enabled = False
                TxtComentAnulada.ReadOnly = True
                Me.TxtComentAnulada.Text = ""
            End If
        End If
    End Sub
End Class