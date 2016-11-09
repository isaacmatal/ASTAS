Imports System.Data
Imports System.Data.SqlClient
Public Class Cooperativa_Origenes
    Dim Bandera As String
    Dim Origen As String = 0
    Dim sqlCmd As SqlCommand
    Dim Proc As New jarsClass
    Private Sub Cooperativa_Origenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.PbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        LlenarTabla()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.TxtDivision.Text.Trim > "" Then
            If MsgBox("Desea agregar o modificar?", MsgBoxStyle.YesNo, "Adicionar/Modficar") = MsgBoxResult.Yes Then
                If TxtCodigo.Text = "" Then
                    Bandera = "I"
                Else
                    Bandera = "U"
                End If

                sqlCmd = New SqlCommand("EXECUTE dbo.sp_COOPERATIVA_ORIGENES @COMPAÑIA=" & Compañia & ", @DESCRIPCION='" & Me.TxtDivision.Text & "', @BANDERA='" & Bandera & "', @ORIGEN=" & Origen)
                Dim Resulta As Integer = Proc.ejecutarComandoSql(sqlCmd)
                If Resulta > 0 Then
                    MsgBox("Actualización Realizada Correctamente.", MsgBoxStyle.Exclamation)
                End If
                LlenarTabla()
            End If
        Else
            MsgBox("No está definido la Descripción.", MsgBoxStyle.Exclamation)
            Me.TxtDivision.Focus()
        End If
    End Sub
    Private Sub LlenarTabla()
        Me.DGV_Datos.DataSource = Proc.ejecutaSQLl_llenaDTABLE("EXECUTE dbo.sp_COOPERATIVA_ORIGENES @COMPAÑIA=" & Compañia & ", @DESCRIPCION='" & Me.TxtDivision.Text & "', @BANDERA='S', @ORIGEN=" & Origen)
        Me.DGV_Datos.Columns.Item(0).Visible = False
        Me.DGV_Datos.Columns.Item(1).Width = 65 'Codigo
        Me.DGV_Datos.Columns.Item(2).Width = 220 'Descripción
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Me.TxtCodigo.Clear()
        Me.TxtDivision.Clear()
        Me.TxtDivision.Focus()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If MsgBox("Esta correcto y desea eliminar el registro?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            sqlCmd = New SqlCommand("EXECUTE dbo.sp_COOPERATIVA_ORIGENES @COMPAÑIA=" & Compañia & ", @DESCRIPCION='" & Me.TxtDivision.Text & "', @BANDERA='D', @ORIGEN=" & Origen)
            Dim Resulta As Integer = Proc.ejecutarComandoSql(sqlCmd)
            If Resulta > 0 Then
                MsgBox("Eliminación Realizada Correctamente.", MsgBoxStyle.Exclamation)
            End If
            LlenarTabla()
        End If

    End Sub

    Private Sub DGV_Datos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_Datos.Click
        TxtCodigo.Text = DGV_Datos.CurrentRow.Cells(1).Value.ToString()
        Origen = TxtCodigo.Text
        TxtDivision.Text = DGV_Datos.CurrentRow.Cells(2).Value.ToString()
    End Sub
End Class