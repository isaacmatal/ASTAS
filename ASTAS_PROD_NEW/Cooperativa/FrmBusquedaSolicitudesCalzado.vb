Imports System.Data
Imports System.Data.SqlClient
Public Class FrmBusquedaSolicitudesCalzado
    Dim sql As String
    Public Compañia_Value As Integer
    Private Function GeneraSql(ByVal Bandera) As String
        sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_CALZADO " & Me.CbxCompañia.SelectedValue _
        & "," & IIf(Trim(TxtNumSolicitud.Text) = "", "0", Trim(Me.TxtNumSolicitud.Text)) & "," & _
        IIf(Trim(TxtCodigoAs.Text) = "", "0", Trim(Me.TxtCodigoAs.Text)) & "," _
        & IIf(Trim(TxtCodigoBuxis.Text) = "", "0", Trim(Me.TxtCodigoBuxis.Text)) & ",'" & Trim(Me.TxtNombre.Text) & "'," & Bandera
        Return sql
    End Function
    Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERA)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.CbxCompañia.DataSource = Table
            Me.CbxCompañia.ValueMember = "COMPAÑIA"
            Me.CbxCompañia.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub FrmBusquedaSolicitudesCalzado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompany(Usuario, 1)
        Me.CbxCompañia.SelectedValue = Compañia_Value
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 50
        Me.DgvSolicitudes.Columns(1).Width = 0
        Me.DgvSolicitudes.Columns(2).Width = 150
        Me.DgvSolicitudes.Columns(3).Width = 57
        Me.DgvSolicitudes.Columns(4).Width = 50
        Me.DgvSolicitudes.Columns(5).Width = 50
        Me.DgvSolicitudes.Columns(6).Width = 250
        Me.DgvSolicitudes.Columns(7).Width = 60
        Me.DgvSolicitudes.Columns(8).Width = 100
        Me.DgvSolicitudes.Columns(9).Width = 75
        Me.DgvSolicitudes.Columns(10).Width = 125
        Me.DgvSolicitudes.Columns(1).Visible = False
    End Sub
    Private Sub LimpiaCampos()
        Me.TxtCodigoAs.Text = ""
        Me.TxtCodigoBuxis.Text = ""
        Me.TxtNumSolicitud.Text = ""
        Me.TxtNombre.Text = ""
    End Sub

    Private Sub BtnBuscarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSolicitudes.Click
        If Me.TxtNombre.Text = Nothing And Me.TxtNumSolicitud.Text = Nothing And Me.TxtCodigoAs.Text = Nothing And Me.TxtCodigoBuxis.Text = Nothing And CbxCompañia.Text = Nothing Then
            MsgBox("¡Favor ingresar un filtro de búsqueda válido!", MsgBoxStyle.Critical, "Mensaje")
            DgvSolicitudes.DataSource = Nothing
        Else
            BuscaSolicitudes(1)
            LimpiaCampos()
        End If
    End Sub
    Private Sub BuscaSolicitudes(ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(Bandera), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvSolicitudes.DataSource = DS.Tables(0)
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("¡No se ha encontrado ninguna Solicitud!", MsgBoxStyle.Critical, "Mensaje")
                DgvSolicitudes.DataSource = Nothing
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DgvSolicitudes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitudes.CellClick
        Try
            If DgvSolicitudes.RowCount = 0 Then
                Return
            Else
                ParamcodSolicitud = DgvSolicitudes.CurrentRow.Cells(0).Value()
                ParamcodigoAs = DgvSolicitudes.CurrentRow.Cells(4).Value()
                ParamcodigoBux = DgvSolicitudes.CurrentRow.Cells(5).Value()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class