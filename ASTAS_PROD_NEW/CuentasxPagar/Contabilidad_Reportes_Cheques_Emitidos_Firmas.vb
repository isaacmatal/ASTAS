Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Contabilidad_Reportes_Cheques_Emitidos_Firmas
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass

    Dim Iniciando As Boolean
    Private Sub Contabilidad_Reportes_Cheques_Emitidos_Firmas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        'jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir los Cheques enviados a Cancelación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.txtFechaF.Value = Me.txtFechaI.Value
            Rpts.GetReporteCheques_Emitidos_Proveedores_Firma(Compañia, Format(Me.txtFechaI.Value, "dd-MM-yyyy"), Format(Me.txtFechaF.Value, "dd-MM-yyyy"), 1)
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class