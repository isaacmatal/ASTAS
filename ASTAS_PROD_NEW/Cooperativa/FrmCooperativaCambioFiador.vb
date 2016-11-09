Imports System.Data.SqlClient

Public Class FrmCooperativaCambioFiador
    Dim jClass As New jarsClass
    Dim Permitir As String
    Dim sql As String = ""
    Dim Comando_ As New SqlCommand
    Dim Table, Table2 As DataTable

    Private Sub FrmCooperativaCambioFiador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub NuevaConsulta()
        Me.txtEstatus.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtNombre.Text = Nothing
        While Table.Rows.Count > 0
            Table.Rows.RemoveAt(0)
        End While
        While Table2.Rows.Count > 0
            Table2.Rows.RemoveAt(0)
        End While
        Me.BtnLimpiar.PerformClick()
        Me.TxtCodigoBuxis.Focus()
    End Sub

    Private Sub BtnBuscarSocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocio.Click
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoBux <> Nothing Then
            BuscaSocio()
            Me.BtnLimpiar.PerformClick()
            CargaProgramaciones()
        End If
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    Private Sub BuscaSocio()
        Dim tblDatos As DataTable
        Try
            sql = "EXECUTE Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO @CodigoA = '0', @CodigoB = " & ParamcodigoBux & ", @COMPAÑIA = " & Compañia
            Comando_.CommandText = sql
            tblDatos = jClass.obtenerDatos(Comando_)
            If tblDatos.Rows.Count > 0 Then
                Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & tblDatos.Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & tblDatos.Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a consultar este código", MsgBoxStyle.Information, tblDatos.Rows(0).Item(1) & " - " & tblDatos.Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                txtEstatus.Text = tblDatos.Rows(0).Item(11)
                TxtCodigoBuxis.Text = tblDatos.Rows(0).Item(1)
                TxtNombre.Text = tblDatos.Rows(0).Item(2)
                Hay_Datos = True
            Else
                MsgBox("No existe código de socio.!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscaSocioFiador()
        Dim tblDatos As DataTable
        Dim OrigenFiador As Integer
        Try
            OrigenFiador = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & ParamcodigoBux)
            If Not Permitir.Contains(Origen.ToString()) Then
                MsgBox("No esta autorizado a consultar este código", MsgBoxStyle.Information, ParamcodigoBux)
                Hay_Datos = False
                Return
            End If
            sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '0','" & ParamcodigoBux & "'," & Compañia
            Comando_.CommandText = sql
            tblDatos = jClass.obtenerDatos(Comando_)
            If tblDatos.Rows.Count > 0 Then
                Me.TxtCodigoBuFi.Text = ParamcodigoBux
                TxtNombreFiador.Text = tblDatos.Rows(0).Item(2)
                Hay_Datos = True
            Else
                MsgBox("No existe código de socio.!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    Private Sub CargaProgramaciones()
        Try
            sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO=" & Val(TxtCodigoBuxis.Text) & ", @BANDERA=8"
            Comando_.CommandText = sql
            Table = jClass.obtenerDatos(Comando_)
            Me.dgvFiadoresDelSocio.DataSource = Table
            sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO=" & Val(TxtCodigoBuxis.Text) & ", @BANDERA=9"
            Comando_.CommandText = sql
            Table2 = jClass.obtenerDatos(Comando_)
            Me.dgvEsFiadorDe.DataSource = Table2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Desarrollado por Benjamin Parada, editado por Jonathan Peña
    Private Sub DgvProgramaciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFiadoresDelSocio.CellEnter
        Dim dgvFiador As DataGridView = CType(sender, DataGridView)
        If e.RowIndex > -1 Then
            Me.TxtCodigoBuFi.Text = dgvFiador.Rows(e.RowIndex).Cells("codigo").Value.ToString()
            Me.TxtNombreFiador.Text = dgvFiador.Rows(e.RowIndex).Cells("nombrefiador").Value.ToString()
            Me.txtMontoOtr.Text = Format(dgvFiador.Rows(e.RowIndex).Cells("monto").Value, "0.00")
            Me.txtSaldoAct.Text = dgvFiador.Rows(e.RowIndex).Cells("saldo").Value.ToString()
            Me.txtNumSol.Text = dgvFiador.Rows(e.RowIndex).Cells("numsolic").Value.ToString()
            Me.lblNuevo.Text = "0"
        End If
    End Sub

    Private Sub BtnBuscarSocFi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocFi.Click
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocioFiador()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Desea eliminar el registro seleccionado?", MsgBoxStyle.YesNo, "CONFIRMAR ELIMINACION") = MsgBoxResult.Yes Then
            If Val(Fiadores(3, Me.TxtCodigoBuxis.Text, Me.txtNumSol.Text, Me.TxtCodigoBuFi.Text, Val(Me.txtSaldoAct.Text), Val(Me.txtMontoOtr.Text)).Rows(0).Item(0)) > 0 Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Resultado")
            Else
                MsgBox("Registro NO fue eliminado", MsgBoxStyle.Information, "Error")
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.TxtCodigoBuFi.Text.Length > 0 Then
            If Me.TxtCodigoBuxis.Text = Me.TxtCodigoBuFi.Text Then
                MessageBox.Show("El Socio Fiador no puede ser el mismo que el socio solicitante", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.BtnBuscarSocFi.Focus()
                Return
            End If
            If Me.TxtCodigoBuFi.Text.Length = 0 Then
                MsgBox("Debe ingresar un número de solicitud", MsgBoxStyle.Information, "Guardar")
                Return
            End If
            Fiadores(2, Me.TxtCodigoBuxis.Text, Me.txtNumSol.Text, Me.TxtCodigoBuFi.Text, Val(Me.txtSaldoAct.Text), Val(Me.txtMontoOtr.Text))
        End If
        Me.lblNuevo.Text = "0"
    End Sub

    Private Function Fiadores(ByVal Bandera As Integer, ByVal codEmp As Integer, ByVal numSol As Integer, ByVal codigoFiador As Integer, ByVal Saldo As Double, ByVal MontoOtorgado As Double) As DataTable
        Dim tblResultado As New DataTable
        sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]" & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        sql &= ",@CODIGO_EMPLEADO = " & codEmp & vbCrLf
        sql &= ",@NUMERO_SOLICITUD = " & numSol & vbCrLf
        sql &= ",@CODIGO_EMPLEADO_FIADOR = " & codigoFiador & vbCrLf
        sql &= ",@SALDO_ACTUAL = " & Saldo & vbCrLf
        sql &= ",@MONTO = '" & MontoOtorgado & "'" & vbCrLf
        sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        sql &= ",@BANDERA = " & Bandera & vbCrLf
        tblResultado = jClass.obtenerDatos(New SqlCommand(sql), 1)
        CargaProgramaciones()
        Return tblResultado
    End Function

    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoBuxis.Text <> Nothing Then
                ParamcodigoAs = "0"
                ParamcodigoBux = Val(Me.TxtCodigoBuxis.Text)
                BuscaSocio()
                If Hay_Datos Then
                    ParamcodigoAs = "0"
                    ParamcodigoBux = Me.TxtCodigoBuxis.Text
                    CargaProgramaciones()
                Else
                    Me.TxtCodigoBuxis.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub TxtCodigoBuFi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuFi.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoBuFi.Text <> Nothing Then
                ParamcodigoBux = Me.TxtCodigoBuFi.Text
                BuscaSocioFiador()
            End If
        End If
    End Sub

    Private Sub FrmCooperativaCambioFiador_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo.Click
        NuevaConsulta()
        Me.lblNuevo.Text = "0"
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Me.TxtCodigoBuFi.Clear()
        Me.txtMontoOtr.Clear()
        Me.txtSaldoAct.Clear()
        Me.TxtNombreFiador.Clear()
        Me.txtNumSol.Clear()
        Me.lblNuevo.Text = "1"
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New Cooperativa_Detalle_Fiadores
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt.Section2.ReportObjects.Item("txtNombre")
        txtObj.Text = Me.TxtNombre.Text
        rpt.SetDataSource(Table)
        rpt.Subreports.Item(0).SetDataSource(Table2)
        frmVer.ReportesGenericos(rpt)
        frmVer.crvReporte.DisplayGroupTree = False
        frmVer.ShowDialog()
    End Sub
End Class