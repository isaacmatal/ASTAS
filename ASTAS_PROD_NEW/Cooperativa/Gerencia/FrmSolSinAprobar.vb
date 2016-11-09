Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSolSinAprobar
    Dim Sql As String
    Dim Permitir As String
    Dim Procesos As New jarsClass

    Private Sub FrmSolSinProgramar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            Permitir = Procesos.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Carga_Solicitudes()
        LimpiaGrid()
    End Sub

    Private Sub Carga_Solicitudes()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.SP_COOPERATIVA_TODAS_LAS_SOLICITUDES " & Compañia & ", 0, 0, '" & Format(Now(), "dd-MM-yyyy 00:00:01") & "', '" & Format(Now(), "dd-MM-yyyy 23:59:59") & "', 7, '" & Permitir & "'"
            Comando_Track = New SqlCommand(Sql)
            Table = Procesos.obtenerDatos(Comando_Track)
            DgvSolicitudes.DataSource = Table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscaSolicitudes()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.SP_COOPERATIVA_TODAS_LAS_SOLICITUDES " & Compañia & ", 0, 0, '" & Format(Now(), "dd-MM-yyyy 00:00:01") & "', '" & Format(Now(), "dd-MM-yyyy 23:59:59") & "', 7, '" & Permitir & "'"
            Comando_Track = New SqlCommand(Sql)
            Table = Procesos.obtenerDatos(Comando_Track)
            DgvSolicitudes.DataSource = Table
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("No se ha encontrado ninguna Solicitud", MsgBoxStyle.Information, "Mensaje")
            End If
            Me.rbSelec.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 50 'Selec
        Me.DgvSolicitudes.Columns(1).Width = 60 'solicitud
        Me.DgvSolicitudes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(2).Visible = False 'Compañia
        Me.DgvSolicitudes.Columns(3).Visible = False 'cod tipo Solicitud
        Me.DgvSolicitudes.Columns(4).Width = 150 'desc tipo Solicitud
        Me.DgvSolicitudes.Columns(5).Visible = False 'deduccion
        Me.DgvSolicitudes.Columns(6).Width = 260 'nombre
        Me.DgvSolicitudes.Columns(7).Width = 80 'fecha Solicitud
        Me.DgvSolicitudes.Columns(8).Width = 260 'autorizacion excepcion
        Me.DgvSolicitudes.Columns(9).DefaultCellStyle.ForeColor = Color.Navy 'valor
        Me.DgvSolicitudes.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(9).Width = 80 'Valor
        Me.DgvSolicitudes.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'interes
        Me.DgvSolicitudes.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(11).Width = 80  'periodo
        Me.DgvSolicitudes.Columns(12).Width = 50 'cuotas
        Me.DgvSolicitudes.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(13).Width = 100 'usuario creacion
        For i As Integer = 1 To Me.DgvSolicitudes.Columns.Count - 1
            Me.DgvSolicitudes.Columns(i).ReadOnly = True
        Next
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsmiAutorizacion.Click, btnAutorizar.Click
        Dim SelectedRows As Integer = 0
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value Then
                SelectedRows += 1
            End If
        Next
        If SelectedRows = 0 Then
            MsgBox("No ha seleccionado registros para procesar.", MsgBoxStyle.Critical, "Validación")
            Return
        End If
        If MsgBox("¿Está seguro de Procesar las solicitudes seleccionadas?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.No Then
            Return
        End If
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            If DgvSolicitudes.Rows(i).Cells(0).Value And DgvSolicitudes.Rows(i).Cells(1).Value <> 0 Then
                Sql = " UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS" & vbCrLf
                Sql &= "	SET REVISADO= '" & Usuario & "'" & vbCrLf
                Sql &= "	   ,USUARIO_EDICION = '" & Usuario & "'" & vbCrLf
                Sql &= "	   ,USUARIO_EDICION_FECHA = GETDATE() " & vbCrLf
                Sql &= " WHERE  COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "	   AND CORRELATIVO = " & DgvSolicitudes.Rows(i).Cells.Item(1).Value
                Procesos.Ejecutar_ConsultaSQL(Sql)
            End If
        Next
        Carga_Solicitudes()
        Me.rbTodas.Checked = True
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        BuscaSolicitudes()
    End Sub

    Private Sub rbTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodas.CheckedChanged
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            Me.DgvSolicitudes.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub rbSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSelec.CheckedChanged
        For i As Integer = 0 To Me.DgvSolicitudes.Rows.Count - 1
            Me.DgvSolicitudes.Rows(i).Cells(0).Value = False
        Next
    End Sub

    Private Sub FrmSolSinProgramar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class

