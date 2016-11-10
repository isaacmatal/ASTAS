Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Catalogo_Cuentas
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Iniciando As Boolean
    Private Sub Contabilidad_Reportes_Catalogo_Cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        CargaLibrosContables(Compañia)
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir las Cuentas Contables?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            GetReporte_Listado_Cuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Format(Me.txtFechaI.Value, "dd-MM-yyyy"))
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub

    Sub GetReporte_Listado_Cuentas(ByVal Compañia As Integer, ByVal Libro As Integer, ByVal Fecha As DateTime)
        Dim Rpt As New Contabilidad_Reportes_Catalogo_Cuentas_Rpt
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_CATALOGO_CUENTAS "
            Sql &= Compañia
            Sql &= ", " & Libro
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
    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class