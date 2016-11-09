Imports System.Data.SqlClient
Public Class Reporte_Margen_Ganancias
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim TipoFactira As Integer = 1

    Private Sub Inventario_Reporte_Existencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        GroupBox1.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            'Dim rpt As New frmReportes_Ver(Compañia, Me.cmbBODEGA.SelectedValue, Me.fecha_hasta.Value, 2, 0, 0, 0, True)
            'rpt.ShowDialog()
            CargarREPORTE(1, Me.cmbBODEGA.SelectedValue)

        Catch ex As Exception
            MsgBox("AVISO...Ocurrio un problema a la hora de general el documento", MsgBoxStyle.Information)
        End Try
    End Sub


    Private Sub CargarREPORTE(ByVal Compañia As Integer, ByVal Bodega As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()

            SQL = "EXECUTE sp_INVENTARIO_MARGEN_GANANCIAS " & Compañia & "," & Bodega & ",'" & Format(fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "','" & Format(fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "' , " & TipoFactira
            Comando_ = New SqlCommand(SQL, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            Me.dtsReporte.Tables(0).Rows.Clear()
            DataAdapter_.Fill(Me.dtsReporte.Tables(0))

            If Me.dtsReporte.Tables(0).Rows.Count > 0 Then
                Me.dtsReporte.WriteXmlSchema(Application.StartupPath & "\xsdMargenGanancias.xsd")


                Dim rptvista As New ASTAS.Inventario_Margen_Ganancias

                rptvista.SetDataSource(dtsReporte)
                rptvista.SetParameterValue("fechaI", fecha_desde.Value)
                rptvista.SetParameterValue("fechaf", fecha_hasta.Value)

                CrystalReportViewer1.ReportSource = rptvista
            Else
                MsgBox("No hay Datos para mostrar...", MsgBoxStyle.Information)

            End If


            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub rdbCF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCF.CheckedChanged
        If Me.rdbCF.Checked = True Then
            Me.TipoFactira = 1
        End If
    End Sub

    Private Sub rdbCCF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCCF.CheckedChanged
        If Me.rdbCCF.Checked = True Then
            Me.TipoFactira = 2
        End If
    End Sub
End Class