Imports System.Data
Imports System.Data.SqlClient

Public Class Busquedas_empleados_avicola

    Dim sql As String
    Public Compañia_Value As Integer

    Private Sub LimpiaGrid()
        Me.DgvSocios.Columns(0).Width = 50
        Me.DgvSocios.Columns(1).Width = 50
        Me.DgvSocios.Columns(2).Width = 200
        Me.DgvSocios.Columns(3).Width = 100
        Me.DgvSocios.Columns(4).Width = 125
        Me.DgvSocios.Columns(5).Width = 75
        Me.DgvSocios.Columns(6).Width = 100
        Me.DgvSocios.Columns(7).Width = 100
    End Sub

    Private Function GeneraSql() As String
        Dim Condicion As String
        Condicion = ""
        sql = "SELECT CODIGO_EMPLEADO_AS AS 'Código AS', CODIGO_EMPLEADO AS 'Código Buxis', NOMBRE_COMPLETO AS 'Nombre del Socio', "
        sql &= "DUI, NIT, TELEFONO AS [Teléfono], DESCRIPCION_DEPARTAMENTO AS Departamento, DESCRIPCION_SECCION AS [Sección] "
        sql &= "FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS"

        If Trim(Me.CbxCompania.Text) <> Nothing Then
            If Condicion = "" Then
                Condicion = " Where NOMBRE_COMPAÑIA ='" & Trim(Me.CbxCompania.Text) & "' "
            Else
                Condicion = " Where NOMBRE_COMPAÑIA ='" & Trim(Me.CbxCompania.Text) & "' "
            End If
        End If
        If Trim(Me.TxtNombre.Text) <> Nothing Then
            If Condicion = "" Then
                Condicion = " Where NOMBRE_COMPLETO Like '%" & Trim(Me.TxtNombre.Text) & "%' "
            Else
                Condicion &= " And NOMBRE_COMPLETO Like '%" & Trim(Me.TxtNombre.Text) & "%' "
            End If
        End If
        If Trim(Me.TxtDui.Text) <> Nothing Then
            If Condicion = "" Then
                Condicion = " Where DUI Like '%" & Trim(Me.TxtDui.Text) & "%' "
            Else
                Condicion &= " And DUI Like '%" & Trim(Me.TxtDui.Text) & "%' "
            End If
        End If
        If Trim(Me.TxtTelefono.Text) <> Nothing Then
            If Condicion = "" Then
                Condicion = " Where TELEFONO Like '%" & Trim(Me.TxtTelefono.Text) & "%' "
            Else
                Condicion &= " And TELEFONO Like '%" & Trim(Me.TxtTelefono.Text) & "%' "
            End If
        End If
        If Trim(Me.CbxDepartamento.Text) <> Nothing And Me.CbxDepartamento.SelectedValue <> 9999 Then
            If Condicion = "" Then
                Condicion = " Where DESCRIPCION_DEPARTAMENTO ='" & Trim(Me.CbxDepartamento.Text) & "' "
            Else
                Condicion &= " And DESCRIPCION_DEPARTAMENTO ='" & Trim(Me.CbxDepartamento.Text) & "' "
            End If
        End If
        sql &= Condicion & " and estatus=" & StadoBusqueda
        Return sql
    End Function

    Private Sub BuscaSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables.Item(0).Rows.Count = 0 Then
                MsgBox("¡No se encontro ningun Socio!", MsgBoxStyle.Critical, "Mensaje")
                Me.DgvSocios.RefreshEdit()
            End If
            DgvSocios.DataSource = DS.Tables(0)
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub LImpiaCampos()
        Me.TxtNombre.Text = ""
        Me.TxtDui.Text = ""
        Me.TxtTelefono.Text = ""
    End Sub
    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        If Me.TxtNombre.Text = Nothing And Me.TxtDui.Text = Nothing And Me.TxtTelefono.Text = Nothing And CbxDepartamento.Text = "" Then
            MsgBox("¡Favor Ingresar un filtro de búsqueda válido!", MsgBoxStyle.Critical, "Mensaje")
        Else
            BuscaSocio()
            LImpiaCampos()
        End If
    End Sub

    Private Sub FrmBuscarSocios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompany(Usuario, 1)
        Me.CbxCompania.SelectedValue = Compañia_Value
        CargaDepartamento(CbxCompania.SelectedValue)
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
            sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
            Comando_Track = New SqlCommand(sql, Conexion_Track)
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
    Private Sub CargaDepartamento(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "Execute Coo.sp_COOPERATIVA_DEPARTAMENTOS " & Compañia
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDepartamento.DataSource = Table
            Me.CbxDepartamento.ValueMember = "DEPARTAMENTO"
            Me.CbxDepartamento.DisplayMember = "DESCRIPCION_DEPARTAMENTO"
            Me.CbxDepartamento.SelectedValue = 9999
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtDui_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDui.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub DgvSocios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSocios.CellClick
        Try
            If DgvSocios.RowCount = 0 Then
                Return
            Else
                ParamcodigoAs = DgvSocios.CurrentRow.Cells(0).Value
                ParamcodigoBux = DgvSocios.CurrentRow.Cells(1).Value
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class