Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cooperativa_Reportes_Socios_No
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Es_Socio As Integer
    Dim Rpts As New frmReportes_Ver

    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass
    Private Sub Cooperativa_Reportes_Socios_No_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCompañia.Text = Descripcion_Compañia
        Iniciando = False
        Carga_Empresa()
        Carga_Divisiones()
        Me.chknosocios.Checked = True

    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim seccion As Integer = 0
        Dim division As Integer = 0
        Dim departamento As Integer = 0
        Dim empresa As Integer = 0

        If MsgBox("¿Está seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.Label.Visible = True
            ''EMPRERSA
            If Me.chktempresa.Checked Then
                empresa = 9999
            Else
                empresa = Me.cmbempresa.SelectedValue
            End If
            ''DIVISION
            If Me.chktdivision.Checked Then
                division = 9999
            Else
                division = Me.cmbdivision.SelectedValue
            End If
            ''DEPARTAMENTO  
            If Me.chktdepto.Checked Then
                departamento = 9999
            Else
                departamento = Me.cmbdepto.SelectedValue
            End If
            ''SECCION
            If Me.chktseccion.Checked Then
                seccion = 9999
            Else
                seccion = Me.cmbseccion.SelectedValue
            End If
            If Me.ChkSocios.Checked And Me.chknosocios.Checked Then
                Rpts.CargaReporteSociosNO(Compañia, 16, Me.ChkFirma.CheckState, empresa, division, departamento, seccion, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:00"))
            Else
                Rpts.CargaReporteSociosNO(Compañia, IIf(ChkSocios.CheckState, 15, 14), Me.ChkFirma.CheckState, empresa, division, departamento, seccion, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:00"))
            End If

            If Hay_Datos Then
                Rpts.ShowDialog()
            End If
            Me.Label.Visible = False
        End If
    End Sub

    Private Sub Carga_Empresa()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "select * from cooperativa_Catalogo_origenes where origen in (1,2,18)" ''& vbCrLf
            ''Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            ''Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            Me.cmbempresa.ValueMember = "ORIGEN"
            Me.cmbempresa.DisplayMember = "DESCRIPCION_ORIGEN"
            Me.cmbempresa.DataSource = Table
            'Me.cmbempresa.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Carga_Divisiones()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "select * from cooperativa_Catalogo_Divisiones" ''& vbCrLf
            ''Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            ''Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            Me.cmbdivision.ValueMember = "DIVISION"
            Me.cmbdivision.DisplayMember = "DESCRIPCION_DIVISION"
            Me.cmbdivision.DataSource = Table
            'Me.cmbempresa.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Carga_Departamentos()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "select * from cooperativa_Catalogo_Departamentos where Division =" & Me.cmbdivision.SelectedValue ''& vbCrLf
            ''Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            ''Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            Me.cmbdepto.ValueMember = "DEPARTAMENTO"
            Me.cmbdepto.DisplayMember = "DESCRIPCION_DEPARTAMENTO"
            Me.cmbdepto.DataSource = Table
            'Me.cmbempresa.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Carga_Seccion()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "select * from cooperativa_Catalogo_Secciones where division=" & Me.cmbdivision.SelectedValue & " and departamento=" & Me.cmbdepto.SelectedValue ''& vbCrLf
            ''Sql &= " @COMPAÑIA =" & Compañia & "," & vbCrLf
            ''Sql &= " @BANDERA = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            Me.cmbseccion.ValueMember = "SECCION"
            Me.cmbseccion.DisplayMember = "DESCRIPCION_SECCION"
            Me.cmbseccion.DataSource = Table
            'Me.cmbempresa.SelectedValue = 9999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    

    Private Sub cmbdivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdivision.SelectedIndexChanged
        Carga_Departamentos()

    End Sub

    Private Sub cmbdepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepto.SelectedIndexChanged
        Carga_Seccion()

    End Sub

    Private Sub chktempresa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktempresa.CheckedChanged
        If Me.chktempresa.Checked Then
            Me.cmbempresa.Enabled = False

        Else
            Me.cmbempresa.Enabled = True
        End If
    End Sub

    Private Sub chktdivision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktdivision.CheckedChanged
        If Me.chktdivision.Checked Then
            Me.cmbdivision.Enabled = False

        Else
            Me.cmbdivision.Enabled = True
        End If
    End Sub

    Private Sub chktdepto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktdepto.CheckedChanged
        If Me.chktdepto.Checked Then
            Me.cmbdepto.Enabled = False
        Else
            Me.cmbdepto.Enabled = True
        End If
    End Sub

    Private Sub chktseccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktseccion.CheckedChanged
        If Me.chktseccion.Checked Then
            Me.cmbseccion.Enabled = False
        Else
            Me.cmbseccion.Enabled = True
        End If
    End Sub
End Class