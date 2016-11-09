Imports System.Data.SqlClient
Public Class Inventario_Reporte_Ajuste
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Dim reporte_3 As New Inventario_Reporte_Ajustes_RPT

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
        Comando_Track.CommandTimeout = 7200
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Private Sub Inventario_Reporte_Ajuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
    End Sub
    Public Sub Reporte_de_Ajustes(ByVal compañia As String, ByVal bodega As String, ByVal fecha As String)
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "SELECT C.NOMBRE_COMPAÑIA, "
            Sql &= "B.DESCRIPCION_BODEGA, "
            Sql &= "G.DESCRIPCION_GRUPO,"
            Sql &= "GS.DESCRIPCION_SUBGRUPO, "
            Sql &= "A.MOVIMIENTO, "
            Sql &= "A.FECHA_MOVIMIENTO, "
            Sql &= "A.PRODUCTO, "
            Sql &= "P.DESCRIPCION_PRODUCTO, "
            SQL &= "A.EXISTENCIAS_TEORICAS, "
            Sql &= "A.EXISTENCIAS_FISICAS, "
            SQL &= "FALTANTE =  CASE A.OPERACION  WHEN '+' THEN ABS(A.AJUSTE) "
            Sql &= "ELSE 0 	END, "
            SQL &= "SOBRANTES =	CASE A.OPERACION  WHEN '-' THEN ABS(A.AJUSTE) "
            SQL &= "ELSE 0	END, "
            SQL &= "P.GRUPO, "
            SQL &= "P.SUBGRUPO, "
            SQL &= "(CASE P.TIPO_COSTO WHEN 1 THEN "
            SQL &= "dbo.INVENTARIOS_CALCULAR_COSTOS      (" & compañia & ",A.BODEGA,A.PRODUCTO,FECHA_MOVIMIENTO) ELSE "
            SQL &= "dbo.INVENTARIOS_CALCULAR_COSTOS_UEPS (" & compañia & ",A.BODEGA,A.PRODUCTO,FECHA_MOVIMIENTO) END ) "
            SQL &= "[Costo Unitario] "
            Sql &= "FROM INVENTARIOS_PRODUCTOS_BODEGAS_FISICOS_AJUSTES AS A		"
            SQL &= "INNER JOIN INVENTARIOS_CATALOGO_PRODUCTOS P "
            Sql &= "ON P.COMPAÑIA=A.COMPAÑIA AND P.PRODUCTO = A.PRODUCTO						"
            SQL &= "INNER JOIN INVENTARIOS_CATALOGO_GRUPOS AS G "
            SQL &= "ON A.COMPAÑIA=G.COMPAÑIA AND G.GRUPO = P.GRUPO "
            SQL &= "INNER JOIN INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS AS GS "
            SQL &= "ON A.COMPAÑIA=GS.COMPAÑIA AND GS.GRUPO = G.GRUPO AND GS.SUBGRUPO=P.SUBGRUPO "
            SQL &= "INNER JOIN INVENTARIOS_PRODUCTOS_BODEGAS AS PB "
            SQL &= "ON PB.COMPAÑIA=A.COMPAÑIA AND A.BODEGA = PB.BODEGA AND A.PRODUCTO= PB.PRODUCTO "
            SQL &= "INNER JOIN CATALOGO_COMPAÑIAS AS C "
            SQL &= "ON C.COMPAÑIA=A.COMPAÑIA "
            SQL &= "INNER JOIN INVENTARIOS_CATALOGO_BODEGAS AS B "
            SQL &= "ON A.BODEGA = B.BODEGA AND A.COMPAÑIA = B.COMPAÑIA  "
            SQL &= "WHERE A.COMPAÑIA=" & compañia & " AND A.BODEGA=" & bodega & " AND convert(date,A.FECHA_MOVIMIENTO)=convert(date,'" & fecha & "') "
            Sql &= "ORDER BY P.GRUPO,P.SUBGRUPO,A.PRODUCTO  "
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                reporte_3.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = reporte_3
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Reporte_de_Ajustes(Compañia, Me.cmbBODEGA.SelectedValue, Format(Me.fecha_desde.Value, "dd-MM-yyyy"))
        Catch ex As Exception
            MsgBox("Error...Ocurrio un problema a la hora de general el documento", MsgBoxStyle.Information)
        End Try        
    End Sub

    Private Sub Inventario_Reporte_Ajuste_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class