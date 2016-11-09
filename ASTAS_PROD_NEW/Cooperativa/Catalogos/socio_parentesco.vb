Imports System.Data
Imports System.Data.SqlClient

Public Class socio_parentesco

    '#Region "Coneccion"

    'Public Connection As New SqlConnection("Data Source=GENERICO;Initial Catalog=Astas_Db;uid=ASTAS;pwd=ASTAS;")
    'Private oConexion As SqlConnection
    'Private oDataSet As DataSet
    'Private oDataAdapter As SqlDataAdapter
    '#End Region

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
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
        DataAdapter.Fill(DS)
        DGV_parentesco.DataSource = DS.Tables(0)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
        CargarDatos()
    End Sub

#End Region

    Sub CargarDatos()
        Try
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            DS.Reset()
            Conexion_Track.Open()

            'SQL = "SELECT PARENTESCO as ID, DESCRIPCION_PARENTESCO as Parentesco FROM COOPERATIVA_CATALOGO_PARENTESCOS"
            SQL = "Exec sp_COOPERATIVA_CATALOGO_PARENTESCOS_IUD'" & Compañia & "','','','','S'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)

            'da.Fill(DS)

            DGV_parentesco.DataSource = DS.Tables(0)

            'If DS.Tables(0).Rows.Count > 1 Then
            '    Dim FrmPrincipal As New FrmBuscarSocios
            '    FrmPrincipal.ShowDialog()
            'Else
            'TxtNombre.Text = DS.Tables(0).Rows(0).Item(2)
            'TxtDepartamento.Text = DS.Tables(0).Rows(0).Item(3)
            'TxtSeccion.Text = DS.Tables(0).Rows(0).Item(4)
            'DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            'End If
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            Me.DGV_parentesco.Columns.Item(0).Width = 40 'Codigo
            Me.DGV_parentesco.Columns.Item(1).Width = 180 'Codigo
        End Try
    End Sub

 

#Region "Comunes"
    Sub Limpiar()
        Me.TxtCodigo.Clear()
        Me.TxtParentesco.Clear()
        Me.TxtParentesco.Focus()
        TxtWhiteColor()
    End Sub

    Sub TxtWhiteColor()
        Me.TxtCodigo.BackColor = Color.White
        Me.TxtCodigo.BackColor = Color.White
    End Sub

    Sub Validar(ByVal action As String)
        If Trim(Me.TxtParentesco.Text) = Nothing Then
            MessageBox.Show("El campo PARENTESCO NO puede estar vacío...!!!", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If action = "insertar" Then
                Insert()
            ElseIf action = "modificar" Then
                Modificar()
            ElseIf action = "eliminar" Then
                Eliminar()
            End If
        End If
    End Sub

    Sub ValidarBeneficiarios()

    End Sub
#End Region

#Region "Query's Mantenimiento"
    Sub Insert()
        Try
            OpenConnection()
            SQL = "Exec sp_COOPERATIVA_CATALOGO_PARENTESCOS_IUD'" & Compañia & "','','" & Trim(Me.TxtParentesco.Text) & "','" & UsuarioDB & "','I'"
            MiddleConnection()
            MessageBox.Show("Nuevo parentesco agregado exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MessageBox.Show("El dato NO pudo ser agregado, Error de conexion con la Base de Datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub Modificar()
        Resultado = MessageBox.Show("Esta seguro que desea MODIFICAR el registro...???", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Resultado = System.Windows.Forms.DialogResult.OK Then
            Try
                OpenConnection()
                SQL = "Exec sp_COOPERATIVA_CATALOGO_PARENTESCOS_IUD'" & Compañia & "','" & Trim(Me.TxtCodigo.Text) & "','" & Trim(Me.TxtParentesco.Text) & "','" & UsuarioDB & "','U'"
                MiddleConnection()
                MessageBox.Show("EL registro fue MODIFICADO exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El dato NO pudo ser Modificado, Error de conexion con la Base de Datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

    Sub Eliminar()
        Resultado = MessageBox.Show("Esta seguro que desea ELIMINAR el registro...???", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                OpenConnection()
                SQL = "Exec sp_COOPERATIVA_CATALOGO_PARENTESCOS_IUD'" & Compañia & "','" & Trim(Me.TxtCodigo.Text) & "','" & Trim(Me.TxtParentesco.Text) & "','" & UsuarioDB & "','D'"
                MiddleConnection()
                MessageBox.Show("EL registro fue Eliminado exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("El dato NO pudo ser Eliminado, Error de conexion con la Base de Datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

#End Region

    Private Sub Botones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click, BtnAgregar.Click, BtnEliminar.Click
        If sender Is BtnLimpiar Then
            Limpiar()
        ElseIf sender Is BtnAgregar Then
            If Me.TxtCodigo.Text = Nothing Then
                Validar("insertar")
                'ElseIf sender Is BtnEditar Then
            ElseIf Me.TxtCodigo.Text <> Nothing Then
                Validar("modificar")
            End If
        ElseIf sender Is BtnEliminar Then
            Validar("eliminar")
        End If
        Limpiar()
    End Sub

    Private Sub socio_parentesco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargarDatos()
    End Sub

    Private Sub DGV_parentesco_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_parentesco.CellClick
        Try
            Me.TxtCodigo.Text = Me.DGV_parentesco.Rows(e.RowIndex).Cells(0).Value()
            Me.TxtParentesco.Text = Me.DGV_parentesco.Rows(e.RowIndex).Cells(1).Value()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

    End Sub

    Private Sub socio_parentesco_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class

