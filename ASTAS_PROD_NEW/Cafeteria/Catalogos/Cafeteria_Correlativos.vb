Public Class Cafeteria_Correlativos
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim banderaIU As Boolean = False
    Dim Iniciando2 As Boolean

    Private Sub Cafeteria_Correlativos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.btnUnLok.Enabled = False
        Me.txtCompañia.Text = Descripcion_Compañia
        'LLENA EL COMBO DE BODEGAS
        c_data2.CargaBodegas(Compañia, Me.cbCafeteria, 9)
        'cargarCajas()
        'CargarGrid(Compañia, "S")        
        Iniciando = False
    End Sub

    Public Sub cargarCajas()        
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cbSeleccioneCaja.DataSource = Nothing
            Me.btnUnLok.Enabled = False
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data2.CargarCombo(Me.cbSeleccioneCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If

    End Sub

    Sub CargarGrid(ByVal CIA, ByVal SIUD)
        Try
            DS01.Reset()
            cadenaSIUD(CIA, SIUD)
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.Cierre_Apertura_Grid.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()

            For i As Integer = 0 To Cierre_Apertura_Grid.ColumnCount - 1
                Cierre_Apertura_Grid.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Aviso...No posee datos la bodega a reportar.", MsgBoxStyle.Information)

        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub

    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD)
        Dim CAJA As String

        CAJA = cbSeleccioneCaja.SelectedValue.ToString()

        SQL = "Execute [dbo].[sp_CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO_IUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & cbCafeteria.SelectedValue
        SQL &= ",@NUMERO_CAJA  = " & IIf(Me.cbSeleccioneCaja.SelectedValue = Nothing, "", Me.cbSeleccioneCaja.SelectedValue)
        SQL &= ",@SERIE  = '" & IIf(txtSerie.Text = "", 0, txtSerie.Text) & "'"
        SQL &= ",@CORRELATIVO_INICIAL = " & IIf(txtDineroInicial.Text = "", 0, txtDineroInicial.Text)
        SQL &= ",@CORRELATIVO_ACTUAL = " & IIf(txtCorrelativoActual.Text = "", 0, txtCorrelativoActual.Text)
        SQL &= ",@CORRELATIVO_FINAL = " & IIf(txtCorrelativoFinal.Text = "", 0, txtCorrelativoFinal.Text)
        SQL &= ",@CORRELATIVO_NOTIFICACION = " & IIf(txtCorrelativoNotificacion.Text = "", 0, txtCorrelativoNotificacion.Text)
        SQL &= ",@N_RESOLUCION = '" & IIf(txtResolucion.Text = "", "0", txtResolucion.Text) & "'"
        SQL &= ",@FECHA_APROVACION = '" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy 00:00:01") & "'"
        SQL &= ",@FECHA_AUTORIZA = '" & Format(Me.dtpFechaAutoriza.Value, "dd-MM-yyyy 00:00:01") & "'"
        SQL &= ",@ACTIVA = " & chkActiva.CheckState
        SQL &= ",@USUARIO = '" & Usuario & "'"
        SQL &= ",@IUD = '" & SIUD & "'"
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.btnUnLok.Enabled = True
        Try
            If (banderaIU = False) Then
                Dim respuesta As MsgBoxResult
                respuesta = MsgBox("Desea agregar nuevos correlativos a la caja?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                If respuesta = MsgBoxResult.Yes Then
                    cadenaSIUD(Compañia, "I")
                    c_data2.Ejecutar_ConsultaSQL(SQL)
                    CargarGrid(Compañia, "S")
                    Me.btnLimpiar.PerformClick()
                    MsgBox("La Caja ha sido agregada con exito!", MsgBoxStyle.Information)
                End If
            Else
                Dim respuesta As MsgBoxResult
                respuesta = MsgBox("Desea actualizarle los correlativos a la caja?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                If respuesta = MsgBoxResult.Yes Then
                    cadenaSIUD(Compañia, "U")
                    c_data2.Ejecutar_ConsultaSQL(SQL)
                    CargarGrid(Compañia, "S")
                    Me.btnLimpiar.PerformClick()
                    MsgBox("La Caja ha sido actualizada con exito!", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Try
            banderaIU = False
            txtCorrelativoFinal.ReadOnly = False
            dtpFechaTrabajo.Enabled = True
            dtpFechaAutoriza.Enabled = True
            txtCorrelativoFinal.BackColor = Color.White
            txtResolucion.ReadOnly = False
            txtResolucion.BackColor = Color.White
            Me.txtDineroInicial.ReadOnly = False
            txtDineroInicial.BackColor = Color.White
            Me.txtSerie.ReadOnly = False
            Me.txtSerie.BackColor = Color.White
            Me.btnUnLok.Enabled = False

            cbCafeteria.SelectedIndex = 0
            'cbSeleccioneCaja.SelectedIndex = 0
            txtDineroInicial.Text = ""
            txtCorrelativoFinal.Text = ""
            txtCorrelativoNotificacion.Text = ""
            txtResolucion.Text = ""
            Me.txtSerie.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim respuesta As MsgBoxResult
            respuesta = MsgBox("Desea eliminar el registro de caja?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                cadenaSIUD(Compañia, "D")
                c_data2.Ejecutar_ConsultaSQL(SQL)
                CargarGrid(Compañia, "S")
                Me.btnLimpiar.PerformClick()
                MsgBox("La Caja ha sido agregada con exito!", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema!", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            Iniciando2 = False
        End If
    End Sub

    Private Sub cbSeleccioneCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeleccioneCaja.SelectedIndexChanged
        If Iniciando = False And Not Iniciando2 Then
            CargarGrid(Compañia, "S")
        End If
    End Sub

    Private Sub Cierre_Apertura_Grid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Cierre_Apertura_Grid.CellClick
        banderaIU = True
        Me.btnUnLok.Enabled = True
        dtpFechaTrabajo.Value = Cierre_Apertura_Grid.CurrentRow.Cells(12).Value
        dtpFechaAutoriza.Value = Cierre_Apertura_Grid.CurrentRow.Cells(13).Value
        cbCafeteria.SelectedValue = Cierre_Apertura_Grid.CurrentRow.Cells(15).Value
        cbSeleccioneCaja.SelectedValue = Cierre_Apertura_Grid.CurrentRow.Cells(16).Value
        dtpFechaTrabajo.Enabled = False
        dtpFechaAutoriza.Enabled = False
        txtDineroInicial.ReadOnly = True
        txtDineroInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))

        txtResolucion.ReadOnly = True
        txtResolucion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))

        txtDineroInicial.Text = Cierre_Apertura_Grid.CurrentRow.Cells(1).Value.ToString()
        txtCorrelativoFinal.ReadOnly = True
        txtCorrelativoFinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        txtCorrelativoFinal.Text = Cierre_Apertura_Grid.CurrentRow.Cells(2).Value.ToString()
        txtCorrelativoNotificacion.Text = Cierre_Apertura_Grid.CurrentRow.Cells(4).Value.ToString()
        Me.txtCorrelativoActual.Text = Cierre_Apertura_Grid.CurrentRow.Cells(3).Value.ToString()
        txtResolucion.Text = Cierre_Apertura_Grid.CurrentRow.Cells(11).Value.ToString()
        If (Cierre_Apertura_Grid.CurrentRow.Cells(5).Value.ToString() = "True") Then
            chkActiva.Checked = True
        Else
            chkActiva.Checked = False
        End If
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSerie.Text = Cierre_Apertura_Grid.CurrentRow.Cells(10).Value.ToString()
    End Sub

    Private Sub txtDineroInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDineroInicial.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtDineroInicial.Text.Equals(String.Empty) Then
                    e.Handled = True
                Else
                    e.Handled = txtDineroInicial.Text.Contains(".")

                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCorrelativoNotificacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativoNotificacion.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtCorrelativoNotificacion.Text.Equals(String.Empty) Then
                    e.Handled = True
                Else
                    e.Handled = txtCorrelativoNotificacion.Text.Contains(".")
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCorrelativoFinal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativoFinal.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtCorrelativoFinal.Text.Equals(String.Empty) Then
                    e.Handled = True
                Else
                    e.Handled = txtCorrelativoFinal.Text.Contains(".")
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDineroInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDineroInicial.TextChanged
        Me.txtCorrelativoActual.Text = Me.txtDineroInicial.Text
    End Sub

    Private Sub txtCorrelativoActual_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativoActual.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtCorrelativoActual.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtCorrelativoActual.Text = ""
                Else
                    e.Handled = txtCorrelativoActual.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtCorrelativoActual.Text = ""
            End If
        End If

    End Sub

    Private Sub btnUnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnLok.Click
        txtCorrelativoFinal.ReadOnly = False
        dtpFechaAutoriza.Enabled = True
        txtCorrelativoFinal.BackColor = Color.White
        txtResolucion.ReadOnly = False
        txtResolucion.BackColor = Color.White
        Me.txtDineroInicial.ReadOnly = False
        txtDineroInicial.BackColor = Color.White
    End Sub
End Class