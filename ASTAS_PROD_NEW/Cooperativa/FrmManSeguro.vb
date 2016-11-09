Imports System.Data
Imports System.Data.SqlClient
Public Class FrmManSeguro
    Dim Sql As String
    Dim Iniciando As Boolean
    Private Sub FrmManSeguro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Company(Usuario, 1)
        Deducciones()
        MuestraSegDeuda()
        LimpiaGrid()
        Iniciando = False
    End Sub
    Private Sub Company(ByVal USUARIO, ByVal BANDERA)
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
            Me.CbxCompania.DataSource = Table
            Me.CbxCompania.ValueMember = "COMPAÑIA"
            Me.CbxCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.CbxCompania.SelectedItem = 1
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Deducciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & CbxCompania.SelectedValue & "," & 0 & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
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
    Private Sub Mantenimiento_SeguroDeuda(ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "exec Coo.sp_COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO_SIUD " & Me.CbxCompania.SelectedValue & "," & Me.CbxDeduccion.SelectedValue & "," & Trim(Val(TxtCorrelativo.Text)) & "," & Trim(Val(Me.TxtInteres.Text)) & "," & _
            IIf(ChxEstado.Checked = True, "1", "0") & ",'" & Usuario & "'," & IUD & ""
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            If IUD = 1 Then
                MsgBox("¡Seguro de Deuda Creado con éxito!", MsgBoxStyle.Information, "Mensaje")
            End If
            If IUD = 2 Then
                MsgBox("¡Seguro de Deuda: " + Me.TxtCorrelativo.Text + " ha sido modificadO con éxito!", MsgBoxStyle.Information, "Mensaje")
            End If
            If IUD = 3 Then
                MsgBox("¡Seguro de Deuda EliminadO con éxito!", MsgBoxStyle.Information, "Mensaje")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MuestraSegDeuda()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "exec Coo.sp_COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO_SIUD " & Me.CbxCompania.SelectedValue & "," & 0 & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & 4 & ""
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DgvSegDeuda.DataSource = Table
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvSegDeuda.Columns(0).Visible = False
        Me.DgvSegDeuda.Columns(1).Visible = False
        Me.DgvSegDeuda.Columns(2).Width = 65
        Me.DgvSegDeuda.Columns(3).Width = 160 'Descripcion
        Me.DgvSegDeuda.Columns(4).Width = 55 'Interes
        Me.DgvSegDeuda.Columns(5).Width = 65 'Estado
        Me.DgvSegDeuda.Columns(6).Width = 75
        Me.DgvSegDeuda.Columns(7).Width = 125
    End Sub
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.CbxDeduccion.Text = Nothing Then
            MessageBox.Show("Debe de seleccionar una Deduccion valida!!", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CbxDeduccion.Focus()
            Return
        End If
        If Trim(Me.TxtInteres.Text) = Nothing Then
            MessageBox.Show("Debe de ingresar un interes valido!!", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtInteres.Focus()
            Return
        End If
        If Me.TxtCorrelativo.Text = 0 Then
            Mantenimiento_SeguroDeuda(1)
            MuestraSegDeuda()
            LimpiaGrid()
        Else
            Mantenimiento_SeguroDeuda(2)
            MuestraSegDeuda()
            LimpiaGrid()
        End If
    End Sub

    Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxCompania.SelectedIndexChanged
        If Iniciando = False Then
            Deducciones()
            MuestraSegDeuda()
            LimpiaGrid()
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.TxtInteres.Text = Nothing
        Me.TxtCorrelativo.Text = 0
        Me.ChxEstado.Checked = False
    End Sub

    Private Sub DgvSegDeuda_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSegDeuda.CellEnter
        Try
            If Me.DgvSegDeuda.RowCount <= 0 Then
            Else
                CbxCompania.SelectedValue = DgvSegDeuda.CurrentRow.Cells(0).Value
                CbxDeduccion.SelectedValue = DgvSegDeuda.CurrentRow.Cells(1).Value
                TxtCorrelativo.Text = DgvSegDeuda.CurrentRow.Cells(2).Value
                TxtInteres.Text = DgvSegDeuda.CurrentRow.Cells(4).Value
                If DgvSegDeuda.CurrentRow.Cells(5).Value = "Activo" Then
                    Me.ChxEstado.Checked = True
                Else
                    Me.ChxEstado.Checked = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If Me.TxtCorrelativo.Text = 0 Then
            MessageBox.Show("Debe de seleccionar un Seguro valido!!!!", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim Result As DialogResult = MessageBox.Show("¿Está seguro(a) que desea eliminar el seguro N° " + TxtCorrelativo.Text & " ?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If Result = Windows.Forms.DialogResult.Yes Then
                Mantenimiento_SeguroDeuda(3)
                MuestraSegDeuda()
            End If
        End If
    End Sub

    Private Sub CbxDeduccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxDeduccion.SelectedIndexChanged
        Me.TxtCorrelativo.Text = 0
    End Sub

    Private Sub TxtInteres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInteres.KeyPress
        Dim cadena As String = TxtInteres.Text
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
End Class