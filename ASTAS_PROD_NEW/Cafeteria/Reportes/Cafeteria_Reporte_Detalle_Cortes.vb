Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Detalle_Cortes
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Reporte_Detalle_Cortes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 7)
        cargarCajas()
        Iniciando = False
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir Detalle de Cortes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If CheckBox1.Checked = True Then
                Rpts.GetReporteDetalleCortes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbCajas.SelectedValue, Format(Me.txtFechaI.Value, "dd-MM-yyyy"), Format(Me.txtFechaF.Value, "dd-MM-yyyy"), "W")
            Else
                Rpts.GetReporteDetalleCortes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbCajas.SelectedValue, Format(Me.txtFechaI.Value, "dd-MM-yyyy"), Format(Me.txtFechaF.Value, "dd-MM-yyyy"), "S")
            End If
            Rpts.ShowDialog()
        End If
    End Sub
    Public Sub cargarCajas()
        Dim a As String = jasr_fill.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            jasr_fill.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            cargarCajas()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbCajas.Enabled = False
        Else
            cmbCajas.Enabled = True
        End If
    End Sub
End Class