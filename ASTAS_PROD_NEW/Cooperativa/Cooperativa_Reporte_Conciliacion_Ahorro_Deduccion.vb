Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cooperativa_Reporte_Conciliacion_Ahorro_Deduccion
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Iniciando As Boolean
    Private Sub Cooperativa_Reporte_Conciliacion_Ahorro_Deduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label5.Text = Compañia
        Me.Txt_Fecha.Text = Now()
        Hay_Datos = False
        Iniciando = False
    End Sub
    Private Sub BuscaSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'" & "," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                TxtCodigoAs.Text = DS.Tables(0).Rows(0).Item(0)
                txtNombreSocio.Text = DS.Tables(0).Rows(0).Item(2)
                Hay_Datos = True
            Else
                MsgBox("¡Código de socio no existe!", MsgBoxStyle.Exclamation, "AVISO")
                Limpiar_Objetos()
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub Limpiar_Objetos()
        txtCodigoAS.Text = ""
        'TxtCodigoBuxis.Text = ""
        txtNombreSocio.Text = ""
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir el Reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Dim Rpt As New Cooperativa_Informe_Conciliacion_Ahorro_Deducciones
            Dim Sql As String
            Sql = "SELECT '" & Descripcion_Compañia & "' AS [COMPAÑIA]"
            Sql &= "      ,[VCS].[DIVISION] AS [DIVISION]"
            Sql &= "      ,[VCS].[DESCRIPCION_DIVISION]"
            Sql &= "      ,[VCS].[DEPARTAMENTO]"
            Sql &= "      ,[VCS].[DESCRIPCION_DEPARTAMENTO]"
            Sql &= "      ,[VDS].[CODIGO_EMPLEADO_AS] AS [CODIGO]"
            Sql &= "      ,[VDS].[CODIGO_EMPLEADO]"
            Sql &= "      ,[VDS].[NOMBRE_COMPLETO] AS [NOMBRE]"
            Sql &= "      ,([VDS].[AHORRO ORDINARIO]) AS [AHORRO]"
            Sql &= "      ,([VDS].[AHORRO ORDINARIO] * 2) AS [AHORRO DOBLE]"
            Sql &= "      ,[VDS].[Monto por Saldar] AS [DEDUCCIONES CONSILIDADAS]"
            Sql &= "      ,(([VDS].[AHORRO ORDINARIO] * 2)-([VDS].[Monto por Saldar])) AS [DIFERENCIA]"
            Sql &= "      ,(SELECT CASE VCS.ESTATUS "
            Sql &= "			WHEN 1 THEN 'NO SOCIO'"
            Sql &= "			WHEN 2 THEN 'SOCIO'"
            Sql &= "            END) AS [ESTADO]"
            Sql &= "  FROM [dbo].[VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO] VDS INNER JOIN"
            Sql &= "       [dbo].[VISTA_COOPERATIVA_CATALOGO_SOCIOS] VCS"
            Sql &= "       ON VDS.COMPAÑIA = VCS.COMPAÑIA"
            Sql &= "          AND VDS.CODIGO_EMPLEADO_AS = VCS.CODIGO_EMPLEADO_AS"
            Sql &= "          AND VDS.CODIGO_EMPLEADO = VCS.CODIGO_EMPLEADO"
            Sql &= "  WHERE VCS.COMPAÑIA = " & Compañia
            Sql &= "   AND  VCS.ESTATUS NOT IN(0)"
            Sql &= "   AND VDS.[AHORRO ORDINARIO] <> 0"
            Sql &= "  ORDER BY DIVISION, DEPARTAMENTO, NOMBRES"
            Rpt.SetDataSource(jasr_fill.obtenerDatos(New SqlCommand(Sql)))
            Rpts.crvReporte.ReportSource = Rpt
            Rpts.Text = Me.Text
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub txtCodigoAS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoAS.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.txtCodigoAS.Text <> Nothing Then
                Me.txtCodigoAS.Text = Me.txtCodigoAS.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.txtCodigoAS.Text
                ParamcodigoBux = 0
                BuscaSocio()
                Me.Txt_Fecha.Focus()
            End If
        End If
    End Sub
End Class