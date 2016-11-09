Imports System.Data.SqlClient
Public Class Inventario_Reporte_Por_Periodo_por_Proveedor
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Dim ENTRADA_SALIDA As String = "TRUE"
    Private Sub Inventario_Reporte_Por_Periodo_por_Proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        'c_data.CargaTipoDocumentoInventario(Compañia, Me.cmbTIPO_MOVIMIENTO, 2)
        c_data1.CargarCombo(Me.cmbProveedor, "Execute sp_INVENTARIO_CATALOGO_PROVEEDORES ", "PROVEEDOR", "NOMBRE_PROVEEDOR")
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        Dim Rpt As New Inventario_Reporte_Compras_Diarias_por_Periodo_por_Proveedor
        Dim sqlcmd As New SqlCommand
        Dim BODEGA As Integer = Me.cmbBODEGA.SelectedValue
        Dim PROVEEDOR As Integer = Me.cmbProveedor.SelectedValue
        Dim BANDERA As Integer = 8
        Dim TIPO_MOVIMIENTO As Integer = 3 'Me.cmbTIPO_MOVIMIENTO.SelectedValue
        Try
            SQL = "Execute sp_INVENTARIOS_GENERAR_REPORTES"
            SQL &= " @COMPAÑIA = " & Compañia
            SQL &= ", @TIPO_MOVIMIENTO = '" & TIPO_MOVIMIENTO & "'"
            SQL &= ", @BODEGA = '" & BODEGA & "'"
            SQL &= ", @PROVEEDOR = '" & PROVEEDOR & "'"
            SQL &= ", @ENTRADA_SALIDA = '" & ENTRADA_SALIDA & "'"
            SQL &= ", @FECHA1 = '" & Me.fecha_desde.Text & "'"
            SQL &= ", @FECHA2 = '" & Me.fecha_hasta.Text & "'"
            SQL &= ", @BANDERA = '" & BANDERA & "'"
            sqlcmd.CommandText = SQL

            Rpt.SetDataSource(c_data1.obtenerDatos(sqlcmd))


            Dim frmVer As New frmReportes_Ver
            frmVer.ReportesGenericos(Rpt)
            frmVer.crvReporte.DisplayGroupTree = False
            frmVer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try

    End Sub
End Class