Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cooperativa_Reportes_Socios_x_Division
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Proc As New jarsClass
    Dim Rpts As New frmReportes_Ver
    Private Sub Cooperativa_Reportes_Socios_x_Division_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCompañia.Text = Descripcion_Compañia
        Sql = "SELECT DIVISION,DESCRIPCION_DIVISION FROM COOPERATIVA_CATALOGO_DIVISIONES WHERE COMPAÑIA=" & Compañia
        Proc.CargarCombo(CmbDivision, Sql, "DIVISION", "DESCRIPCION_DIVISION")
        Iniciando = False
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        If MsgBox("¿Está seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.Label.Visible = True
            Rpts.CargaCatalogo_x_Division(Compañia, Me.CmbDivision.SelectedValue, Me.ChkFirma.CheckState, IIf(Me.ChkSocios.CheckState, 1, 2))
            If Hay_Datos Then
                Rpts.ShowDialog()
            End If
            Me.Label.Visible = False
        End If
    End Sub
End Class