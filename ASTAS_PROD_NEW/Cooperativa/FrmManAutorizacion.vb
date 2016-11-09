Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class FrmManAutorizacion
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jclass As New jarsClass
    Dim FPro As New Facturacion_Procesos

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
    Private Sub Carga_TipoSolicitudes()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_TIPO_SOLICITUDES " & CbxCompania.SelectedValue & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            CbxTipoSolicitud.ValueMember = "SOLICITUD"
            CbxTipoSolicitud.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxTipoSolicitud.DataSource = Table
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaUsuarios(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_USUARIOS " & Compañia & ", '', '', 0 "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.CbxUsuarios.DataSource = Table
            Me.CbxUsuarios.ValueMember = "USUARIO"
            Me.CbxUsuarios.DisplayMember = "USUARIO_COMPLETO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Muestra_Correlativos()
        Dim Conxion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "COO.sp_COOPERATIVA_CORRELATIVOS_AUTORIZACION " & CbxCompania.SelectedValue
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            CbxCorrelativos.DataSource = Table
            CbxCorrelativos.ValueMember = "CORRELATIVO"
            CbxCorrelativos.DisplayMember = "DESCRIPCION"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Mantenimiento_Autorizaciones(ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "exec Coo.sp_COOPERATIVA_CATALOGO_AUTORIZACIONES_IUD " & CbxCorrelativos.SelectedValue & "," & Me.CbxCompania.SelectedValue & "," & CbxTipoSolicitud.SelectedValue & ",'" & CbxUsuarios.SelectedValue & "','" & Usuario & "'," & IUD
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Select Case IUD
                Case "I"
                    MsgBox("¡Autorizacion Creada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡La autorizacion ha sido modificada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("¡Solicitud Eliminada con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaAutorizaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New OleDbConnection
        'Dim Comando_Track As OleDbCommand
        'Dim DataReader_Track As OleDbDataReader
        'Dim DataAdapter As OleDbDataAdapter
        'Dim Table As DataTable
        Dim conStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Documents and Settings\ematal\My Documents\AHORSOC al 31.10.2013.xlsx"";Extended Properties=""Excel 12.0;HDR=Yes;"""
        'Conexion_Track = New OleDbConnection(conStr)
        'Try
        '    Conexion_Track.Open()
        '    Sql = "SELECT * FROM [AHORSOC$]"
        '    Comando_Track = New OleDbCommand(Sql, Conexion_Track)
        '    DataAdapter = New OleDbDataAdapter(Comando_Track)
        '    Table = New DataTable("Datos")
        '    DataAdapter.Fill(Table)
        '    DataReader_Track = Comando_Track.ExecuteReader
        '    If DataReader_Track.Read = True Then
        '        DgvAutorizaciones.DataSource = Table
        '    Else
        '        DgvAutorizaciones.DataSource = Nothing
        '    End If
        '    LimpiaGrid()

        '    Conexion_Track.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub
    Private Sub LimpiaGrid()
        If DgvAutorizaciones.Columns.Count > 1 Then
            Me.DgvAutorizaciones.Columns(0).Width = 75
            Me.DgvAutorizaciones.Columns(3).Width = 175
            Me.DgvAutorizaciones.Columns(4).Width = 85
            Me.DgvAutorizaciones.Columns(5).Width = 75
            Me.DgvAutorizaciones.Columns(6).Width = 125
            Me.DgvAutorizaciones.Columns(7).Width = 75
            Me.DgvAutorizaciones.Columns(8).Width = 125
            Me.DgvAutorizaciones.Columns(1).Visible = False
            Me.DgvAutorizaciones.Columns(2).Visible = False
            DgvAutorizaciones.RefreshEdit()
        End If
    End Sub
    Private Sub FrmManAutorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Company(Usuario, 1)
        Carga_TipoSolicitudes()
        CargaUsuarios(Me.CbxCompania.SelectedValue)
        Muestra_Correlativos()
        CargaAutorizaciones()
        Iniciando = False
    End Sub

    Private Sub CbxCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxCompania.SelectedIndexChanged
        If Iniciando = False Then
            Carga_TipoSolicitudes()
            CargaUsuarios(Me.CbxCompania.SelectedValue)
            Muestra_Correlativos()
            CargaAutorizaciones()
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If MsgBox("Está seguro de querer procesar?.", MsgBoxStyle.YesNo, "PROCESO") = MsgBoxResult.Yes Then
            Dim Table As DataTable
            Dim sqlCmd As New SqlClient.SqlCommand
            Dim numSoli As Integer

            'SELECCIONA TODOS LOS EMPLEADOS QUE HAN CONSUMIDO EN EL INETERVALO SEÑALADO Y SUS RESPECTIVOS MONTOS
            '*****************************************************************************************************
            sqlCmd.CommandText = "SELECT F.CODIGO_EMPLEADO, S.CODIGO_EMPLEADO_AS,TOTAL_FACTURA, S.NOMBRE_COMPLETO, " & vbCrLf
            sqlCmd.CommandText &= "F.NUMERO_FACTURA, F.FECHA_FACTURA, (SELECT DESCRIPCION_BODEGA FROM INVENTARIOS_CATALOGO_BODEGAS I WHERE I.BODEGA = F.BODEGA) AS BODEGA, " & vbCrLf
            sqlCmd.CommandText &= "F.DESCONTAR_CUOTAS_DESDE AS FECHA_PAGO, F.USUARIO_CREACION_FECHA AS FECHA_ELABORACION" & vbCrLf
            sqlCmd.CommandText &= "FROM FACTURACION_GENERADA_ENCABEZADO F, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            sqlCmd.CommandText &= "WHERE(F.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO)" & vbCrLf
            sqlCmd.CommandText &= "AND F.BODEGA IN (1,2,3)" & vbCrLf
            sqlCmd.CommandText &= "AND F.FORMA_PAGO = 2" & vbCrLf
            sqlCmd.CommandText &= "AND F.ANULADA = 0" & vbCrLf
            sqlCmd.CommandText &= "AND F.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlCmd.CommandText &= "AND F.TOTAL_FACTURA > 0" & vbCrLf
            sqlCmd.CommandText &= "AND CONVERT(DATE,F.FECHA_FACTURA) BETWEEN CONVERT(DATE,'" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATE,'" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlCmd.CommandText &= "ORDER BY BODEGA, NUMERO_FACTURA"
            Table = jclass.obtenerDatos(sqlCmd)
            Me.DgvAutorizaciones.DataSource = Table
            '*****************************************************************************************************
            If Table.Rows.Count > 0 Then
                For i As Integer = 0 To Table.Rows.Count - 1
                    numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
                    FPro.SolicitudesFacturacionSocios(Compañia, 15, numSoli, Table.Rows(i).Item("CODIGO_EMPLEADO_AS"), Table.Rows(i).Item("CODIGO_EMPLEADO"), Table.Rows(i).Item("FECHA_FACTURA"), 1, Table.Rows(i).Item("TOTAL_FACTURA"), 0, 0, "QQ", 1, Table.Rows(i).Item("FECHA_PAGO"), "Factura No. " & Table.Rows(i).Item("NUMERO_FACTURA") & " Generada en " & Table.Rows(i).Item("BODEGA"), 1, Table.Rows(i).Item("NUMERO_FACTURA"))
                Next
                MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Descuentos")
            Else
                MsgBox("No existen datos que procesar.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If Me.DgvAutorizaciones.RowCount <= 0 Then
        Else
            Dim Result As DialogResult = MessageBox.Show("¿Está seguro(a) que desea eliminar la Autorizacion?   ", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If Result = Windows.Forms.DialogResult.Yes Then
                Mantenimiento_Autorizaciones("D")
                CargaAutorizaciones()
                Me.BtnEliminar.Enabled = False
            Else
            End If
        End If
    End Sub

    Private Sub DgvAutorizaciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAutorizaciones.CellClick
        Try
            If Me.DgvAutorizaciones.RowCount <= 0 Then
            Else
                CbxCorrelativos.SelectedValue = DgvAutorizaciones.CurrentRow.Cells(0).Value
                CbxCompania.SelectedValue = DgvAutorizaciones.CurrentRow.Cells(1).Value
                CbxTipoSolicitud.SelectedValue = DgvAutorizaciones.CurrentRow.Cells(2).Value
                CbxUsuarios.SelectedValue = DgvAutorizaciones.CurrentRow.Cells(4).Value
                Me.BtnEliminar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class