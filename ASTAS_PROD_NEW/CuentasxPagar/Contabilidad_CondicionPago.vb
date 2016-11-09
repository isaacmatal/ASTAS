Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_CondicionPago
    Dim Iniciando As Boolean

#Region "Connection"
    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DS As New DataSet()
    Dim SQL As String

    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'DS.Reset()
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        'DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
        DataAdapter.Fill(DS)
        DataGrid.DataSource = DS.Tables(0)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

    Private Sub LImpiaGrid()
        For i As Integer = 1 To Me.DataGrid.Columns.Count
            Me.DataGrid.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Me.DataGrid.Columns(3).Width = 75
        Me.DataGrid.Columns(4).Width = 125
        Me.DataGrid.Columns(5).Visible = False
        Me.DataGrid.Columns(6).Visible = False
    End Sub

    Sub CargarDatosGrid(ByVal Compañia, ByVal FormaPago, ByVal Bandera)
        Try
            DS.Reset()
            OpenConnection()
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO "
            SQL &= Compañia
            SQL &= ", " & FormaPago
            SQL &= ", " & Bandera
            MiddleConnection()
            'CloseConnection()
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
        LImpiaGrid()
    End Sub

    Private Sub CargaFormaPago(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            SQL = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO "
            SQL &= Compañia
            SQL &= ", " & Bandera
            Comando_ = New SqlCommand(SQL, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbFORMA_PAGO.DataSource = Table
            Me.cmbFORMA_PAGO.ValueMember = "Pago"
            Me.cmbFORMA_PAGO.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub CargarDatosCombobox()
        Me.CmbCompania.Text = ""
        Try
            OpenConnection()
            SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            'DataReader_Track = Comando_Track.ExecuteReader
            Me.CmbCompania.DataSource = table
            Me.CmbCompania.ValueMember = "COMPAÑIA"
            Me.CmbCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            'DataReader_Tr ack.Close()
            Me.CmbCompania.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

#End Region

    Sub LimpiarTXT()
        Me.TxtCreditoDescripcion.Text = ""
        Me.TxtDiasPago.Text = ""
        Me.TxtCod.Text = ""
    End Sub

#Region "Pruebas"


    'Sub TextoConversion()

    '    For Each control As Control In Me.GroupBox1.Controls
    '        Dim ValorNumerico As Object
    '        Dim NumericCheck As Boolean

    '        If TypeOf control Is TextBox Then
    '            control.Text = Trim(control.Text)
    '            control.Text = UCase(control.Text)

    '            ValorNumerico = control.Text
    '            NumericCheck = IsNumeric(ValorNumerico)
    '            If NumericCheck = True Then
    '                'MessageBox.Show("Los valores numericos son: " & control.Text)
    '                'Val(control.Text)

    '            End If

    '        End If

    '    Next
    'End Sub
#End Region

    Sub TextoConversion()
        For Each control As Control In Me.GroupBox1.Controls
            If TypeOf control Is TextBox Then
                control.Text = Trim(control.Text)
                'control.Text = UCase(control.Text)
            End If
        Next
    End Sub

    Sub Validacion(ByVal accion)
        If Me.TxtCreditoDescripcion.Text = Nothing Then
            MsgBox("¡Ingrese un Descricpión de Condición de Pago válida!", MsgBoxStyle.Critical, "Mensaje")
            Me.TxtCreditoDescripcion.Focus()
            Exit Sub
        End If
        If Val(Me.TxtDiasPago.Text) <= 0 Then
            MsgBox("¡Ingrese un número de días de pago válido (N° Días > 0)!", MsgBoxStyle.Critical, "Mensaje")
            Me.TxtDiasPago.Focus()
            Exit Sub
        End If
        Mantenimiento(1, accion)
    End Sub

    Sub Mantenimiento(ByVal activar, ByVal accion)
        If activar = 1 Then
            Dim mensaje As String = String.Empty

            Select Case accion
                Case "I"
                    mensaje = "¡Condición de Pago guardada con éxito!"
                Case "U"
                    mensaje = "¡Condición de Pago actualizada con éxito!"
                Case "D"
                    mensaje = "¡Condición de Pago eliminada con éxito!"
            End Select
            Try
                OpenConnection()
                SQL = "Execute  sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO_IUD "
                SQL &= Me.CmbCompania.SelectedValue
                SQL &= ", " & Val(Me.TxtCod.Text)
                SQL &= ", " & Me.cmbFORMA_PAGO.SelectedValue
                SQL &= ", '" & Me.TxtCreditoDescripcion.Text & "'"
                SQL &= ", " & Me.TxtDiasPago.Text
                SQL &= ", '" & Usuario & "'"
                SQL &= ",'" & accion & "'"
                MiddleConnection()
                MsgBox(mensaje, MsgBoxStyle.Information, "Mensaje")
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

    Private Sub TxtDiasPago_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDiasPago.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Contabilidad_CondicionPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        LimpiarTXT()
        CargarDatosCombobox()
        CargaFormaPago(Me.CmbCompania.SelectedValue, 1)
        CargarDatosGrid(Me.CmbCompania.SelectedValue, Me.cmbFORMA_PAGO.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        
    End Sub

    Private Sub BtnLimpiar_BtnActualizar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiarBeneficiarios.Click, BtnActualizar.Click
        If sender Is BtnLimpiarBeneficiarios Then
            LimpiarTXT()
        ElseIf sender Is BtnActualizar Then
            CargarDatosGrid(Me.CmbCompania.SelectedValue, Me.cmbFORMA_PAGO.SelectedValue, 1)
        End If

    End Sub

    Private Sub BtnAgregar_BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click, BtnEliminar.Click
        TextoConversion()
        Dim accion As String = String.Empty
        If sender Is BtnAgregar Then
            If Me.TxtCod.Text = "" Then
                accion = "I"
            Else
                accion = "U"
            End If
        ElseIf sender Is BtnEliminar Then
            accion = "D"
        End If
        Validacion(accion)
        LimpiarTXT()
        CargarDatosGrid(Me.CmbCompania.SelectedValue, Me.cmbFORMA_PAGO.SelectedValue, 1)
    End Sub

    Private Sub CmbCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCompania.SelectedIndexChanged
        If Iniciando = False Then
            CargaFormaPago(Me.CmbCompania.SelectedValue, 1)
        End If
    End Sub

    Private Sub cmbFORMA_PAGO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFORMA_PAGO.SelectedIndexChanged
        If Iniciando = False Then
            CargarDatosGrid(Me.CmbCompania.SelectedValue, Me.cmbFORMA_PAGO.SelectedValue, 1)
        End If
    End Sub

    Private Sub DataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellContentClick

    End Sub

    Private Sub DataGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellEnter
        Me.TxtCod.Text = Me.DataGrid.Rows(e.RowIndex).Cells(0).Value()
        Me.TxtCreditoDescripcion.Text = Me.DataGrid.Rows(e.RowIndex).Cells(1).Value()
        Me.TxtDiasPago.Text = Me.DataGrid.Rows(e.RowIndex).Cells(2).Value()
    End Sub
End Class