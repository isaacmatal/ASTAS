Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Contabilidad_Reportes_Catalogo_Clientes
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Iniciando As Boolean
    Private Sub Contabilidad_Reportes_Catalogo_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir el Listado de Clientes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            GetReporte_Listado_Clientes(Compañia, Format(Me.txtFechaI.Value, "dd-MM-yyyy"))
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub

    Sub GetReporte_Listado_Clientes(ByVal Compañia As Integer, ByVal Fecha As DateTime)
        Dim Rpt As New Contabilidad_Reportes_Listado_Clientes_Rpt
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_REPORTES_LISTADO_CLIENTES "
            Sql &= Compañia
            Sql &= ", '" & Fecha & "'"
            sqlCmd.CommandText = Sql
            Table = jasr_fill.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Rpts.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
End Class