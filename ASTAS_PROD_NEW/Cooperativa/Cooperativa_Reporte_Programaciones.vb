Imports System.Data
Imports System.Data.SqlClient

Public Class Cooperativa_Reporte_Programaciones
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim T_cobro As String = 1

    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub ooperativa_Reporte_Programaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Carga_TipoSolicitudes()
        Iniciando = False
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub
    Public Sub CargaReporte()
        Dim Comando_Track As New SqlCommand
        Dim Rpt As Object

        Rpt = New Cooperativa_Reporte_Programacion_solicitudes


        Try
            DS01.Reset()
            If Me.Cmbdeducciones.SelectedValue = 9999 Then
                Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_RPT @COMPAÑIA=" & Compañia & " ,@FECHA_INIPRES='" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:00") & "',@FECHA_PRIMERPAG='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=7, @NOMBRECOMPAÑIA='" & Usuario & "'"

            Else
                ''Dim ded As Integer = Me.Cmbdeducciones.SelectedValue
                Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_RPT @COMPAÑIA=" & Compañia & " ,@FECHA_INIPRES='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA_PRIMERPAG='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=8, @NOMBRECOMPAÑIA='" & Usuario & "', @N_SOLICITUD=" & Me.Cmbdeducciones.SelectedValue
            End If
            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))

            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Private Sub Carga_TipoSolicitudes()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_TIPO_SOLICITUDES" & vbCrLf
            Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            Cmbdeducciones.ValueMember = "SOLICITUD"
            Cmbdeducciones.DisplayMember = "DESCRIPCION_SOLICITUD"
            Cmbdeducciones.DataSource = Table
            Cmbdeducciones.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Cooperativa_Reporte_Programaciones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub


    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        CargaReporte()
    End Sub
End Class