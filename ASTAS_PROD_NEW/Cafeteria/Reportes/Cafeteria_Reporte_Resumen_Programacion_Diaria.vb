Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Resumen_Programacion_Diaria
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

    Private Sub Cafeteria_Reporte_Resumen_Programacion_Diaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "SELECT 0 AS [Tiempo de Comida],'Todos los Tiempos' AS [Descripción] union all SELECT TIEMPO_COMIDA AS [Tiempo de Comida],DESCRIPCION AS [Descripción] FROM  CAFETERIA_CATALOGO_TIEMPO_COMIDA T1	WHERE T1.COMPAÑIA = " & Compañia
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            cmbTiempo.DataSource = Table
            cmbTiempo.ValueMember = "Tiempo de Comida"
            cmbTiempo.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.GetReporteResumenProduccionDiaria(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFechaIn.Value, "dd-MM-yyyy 00:00:01"), Format(Me.txtFechaFn.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue)
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class