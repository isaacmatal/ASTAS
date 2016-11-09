Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FrmCooperativaReporteCartera
    Dim Sql As String
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver

    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim DataReader_ As SqlDataReader
    Dim Table As DataTable
    Dim DS As New DataSet

    Dim Iniciando As Boolean
    Private Sub FrmCooperativaReporteCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        Iniciando = False
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir la Cartera de Socios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.GetReporteCarteraSocios(Me.cmbCOMPAÑIA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"))
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class