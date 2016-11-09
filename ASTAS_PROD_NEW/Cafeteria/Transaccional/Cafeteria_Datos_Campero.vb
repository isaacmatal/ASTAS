Public Class Cafeteria_Datos_Campero
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim Iniciando2 As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Private Sub Cafeteria_Datos_Campero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        txtCompañia.Text = Descripcion_Compañia
        c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 9)
        cargarCajas()
        RadioButton1.Checked = True
        Iniciando = False
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data2.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            Iniciando2 = False
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        DS01.Reset()
        Dim periodo As String
        If RadioButton1.Checked = True Then
            periodo = "QQ"
        Else
            periodo = "MM"
        End If
        If (cmbCajas.Enabled = False) And (cmbBODEGA.Enabled = True) Then
            c_data2.MiddleConnection("EXECUTE sp_CAFETERIA_DATOS_CAMPERO @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ", @FECHA1='" & Format(dtpFechaDesde.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @FECHA2='" & Format(dtpFechaHasta.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @PERIODO_PAGO='" & periodo & "', @BANDERA=1")
        ElseIf (cmbCajas.Enabled = False) And (cmbBODEGA.Enabled = False) Then
            c_data2.MiddleConnection("EXECUTE sp_CAFETERIA_DATOS_CAMPERO @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ", @FECHA1='" & Format(dtpFechaDesde.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @FECHA2='" & Format(dtpFechaHasta.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @PERIODO_PAGO='" & periodo & "', @BANDERA=2")
        Else
            c_data2.MiddleConnection("EXECUTE sp_CAFETERIA_DATOS_CAMPERO @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ", @FECHA1='" & Format(dtpFechaDesde.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @FECHA2='" & Format(dtpFechaHasta.Value, "dd-MM-yyyy 00:00:01") & "'" & ", @PERIODO_PAGO='" & periodo & "', @BANDERA=0")
        End If

        c_data2.DataAdapter.Fill(DS01)
        Me.dgvDatos.DataSource = DS01.Tables(0)
        c_data2.cerrarConexion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ticket As New GenerarTicket

        ticket.AbrirArchivo2()
    
        For i As Integer = 0 To dgvDatos.RowCount - 1

            ticket.EscribirTicketSimple("""" & dgvDatos.Rows(i).Cells(0).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(1).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(2).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(3).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(4).Value.ToString() & """," & """" & Math.Round(dgvDatos.Rows(i).Cells(5).Value, 2).ToString().PadLeft(8, "0") & """," & """" & dgvDatos.Rows(i).Cells(6).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(7).Value.ToString() & """," & """" & dgvDatos.Rows(i).Cells(8).Value.ToString() & """")

        Next
        ticket.EscribirTicketSimple("")

        ticket.CerrarArchivo2()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            cmbCajas.Enabled = False
        Else
            cmbCajas.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbBODEGA.Enabled = False
            CheckBox2.Checked = True
        Else
            cmbBODEGA.Enabled = True
            CheckBox2.Checked = False
        End If
    End Sub
End Class