Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Produccion_Diaria
    Dim Sql As String
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Frm_Bodegas As New Cafeteria_Busqueda_Recetas_por_Bodega

    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader

    Dim Iniciando As Boolean

    Private Sub Cafeteria_Reporte_Produccion_Diaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 10)
        CargarTiempoComida(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTiempo, "S")
        Iniciando = False
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region
    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo As ComboBox, ByVal IUD As Char)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            jasr_fill.CargarCombo(cmbTiempo, Sql, "Tiempo de Comida", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
       
        If MsgBox("¿Está seguro que desea Imprimir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Dim Tabla As DataTable
            Dim sqlCmd1 As New SqlCommand
            'Reporte de cocina
            Dim Rpt As New Cafeteria_Reporte_Produccion_Diaria_Rpt_Cocina
            sqlCmd1.CommandText = Sql
            'reporte de administracion
            Dim Rpt1 As New Cafeteria_Reporte_Produccion_Diaria_Rpt


            Sql = "Execute sp_CAFETERIA_REPORTE_PROGRAMACION_DIARIA "
            Sql &= Compañia
            Sql &= ", " & Me.cmbBODEGA.SelectedValue
            Sql &= ", " & Me.cmbTiempo.SelectedValue
            Sql &= ", '" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "'"
            
            sqlCmd1.CommandText = Sql

            Tabla = jasr_fill.obtenerDatos(sqlCmd1)
            If Me.CheckBox1.Checked = True Then
                Rpt.SetDataSource(Tabla)
                Me.CrystalReportViewer1.ReportSource = Rpt
            Else
                Rpt1.SetDataSource(Tabla)
                Me.CrystalReportViewer1.ReportSource = Rpt1
            End If
            

        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.CheckBox2.Checked = False
        Else
            Me.CheckBox2.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.CheckBox1.Checked = False
        Else
            Me.CheckBox1.Checked = True
        End If
    End Sub
End Class