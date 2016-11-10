Imports System.Data.SqlClient

Public Class Contabilidad_CuentasEquivalentes
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim c_data2 As New jarsClass

    Private Sub Contabilidad_CuentasEquivalentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaCompañiaEquivalente()
        CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        CargaLibrosContablesEquivalentes(Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue)
        CargaCuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 0)
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.cmbCOMPAÑIA.SelectedItem = 1
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCompañiaEquivalente()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA_EQUIVALENTE.DataSource = Table
            Me.cmbCOMPAÑIA_EQUIVALENTE.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA_EQUIVALENTE.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.cmbCOMPAÑIA.SelectedItem = 1
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContablesEquivalentes(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE_EQUIVALENTE.DataSource = Table
            Me.cmbLIBRO_CONTABLE_EQUIVALENTE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE_EQUIVALENTE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA.Text = "0"
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
    End Sub

    Private Sub LimpiaCamposEquivalentes()
        Me.txtCUENTA_EQUIVALENTE.Text = "0"
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Text = ""
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Text = ""
    End Sub

    Private Sub Mantenimiento_CuentasEquivalentes(ByVal Compañia, ByVal LibroContable, ByVal Cuenta, ByVal CompañiaEQ, ByVal LibroContableEQ, ByVal CuentaEQ, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_EQUIVALENCIAS__IUD "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", " & Cuenta
            Sql &= ", " & CompañiaEQ
            Sql &= ", " & LibroContableEQ
            Sql &= ", " & CuentaEQ
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Cuenta Equivalente Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Cuenta Equivalente Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Cuenta Equivalente Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtCUENTA.Text) = "0" Then
            MsgBox("¡Debe seleccionar un Cuenta Contable válida! Verifique.", MsgBoxStyle.Critical, "Valiadción")
            Return False
            Exit Function
        End If
        If Trim(Me.txtCUENTA_EQUIVALENTE.Text) = "0" Then
            MsgBox("¡Debe seleccionar un Cuenta Contable Equivalente válida! Verifique.", MsgBoxStyle.Critical, "Valiadción")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub LimpiaGrid()
        Me.dgvCuentasEquivalentes.Columns.Item(0).Width = 50
        Me.dgvCuentasEquivalentes.Columns.Item(1).Width = 75
        Me.dgvCuentasEquivalentes.Columns.Item(2).Width = 200
        Me.dgvCuentasEquivalentes.Columns.Item(3).Width = 50
        Me.dgvCuentasEquivalentes.Columns.Item(4).Width = 175
        Me.dgvCuentasEquivalentes.Columns.Item(5).Width = 50
        Me.dgvCuentasEquivalentes.Columns.Item(6).Width = 200
        Me.dgvCuentasEquivalentes.Columns.Item(7).Width = 75
        Me.dgvCuentasEquivalentes.Columns.Item(8).Width = 125
        Me.dgvCuentasEquivalentes.Columns(0).Visible = False
        Me.dgvCuentasEquivalentes.Columns(3).Visible = False
        Me.dgvCuentasEquivalentes.Columns(5).Visible = False

    End Sub

    Private Sub CargaCuentasEquivalentes(ByVal Compañia, ByVal LibroContable, ByVal Cuenta)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_EQUIVALENCIAS "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", " & Cuenta
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvCuentasEquivalentes.Columns.Clear()
            Me.dgvCuentasEquivalentes.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub cmbCOMPAÑIA_EQUIVALENTE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA_EQUIVALENTE.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContablesEquivalentes(Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = True
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA.Text = Producto
            Me.txtCUENTA_COMPLETA.Text = Tipo
            Me.txtDESCRIPCION_CUENTA.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
        CargaCuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text)
    End Sub

    Private Sub btnBuscar_Equivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar_Equivalente.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE_EQUIVALENTE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = True
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_EQUIVALENTE.Text = Producto
            Me.txtCUENTA_COMPLETA_EQUIVALENTE.Text = Tipo
            Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnNuevoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCuenta.Click
        LimpiaCampos()
        CargaCuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, "0")
    End Sub

    Private Sub btnNuevo_Equivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo_Equivalente.Click
        LimpiaCamposEquivalentes()
    End Sub

    Private Sub btnGuardar_Equivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar_Equivalente.Click
        If ValidaCampos() = True Then
            Mantenimiento_CuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text, Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue, Me.cmbLIBRO_CONTABLE_EQUIVALENTE.SelectedValue, Me.txtCUENTA_EQUIVALENTE.Text, "I")
            CargaCuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text)
            LimpiaCamposEquivalentes()
        End If
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        LimpiaCampos()
    End Sub

    Private Sub cmbLIBRO_CONTABLE_EQUIVALENTE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE_EQUIVALENTE.SelectedIndexChanged
        LimpiaCamposEquivalentes()
    End Sub

    Private Sub dgvCuentasEquivalentes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasEquivalentes.CellContentClick

    End Sub

    Private Sub btnEliminar_Equivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar_Equivalente.Click
        If ValidaCampos() = True Then
            If MsgBox("¿Está seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_CuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text, Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue, Me.cmbLIBRO_CONTABLE_EQUIVALENTE.SelectedValue, Me.txtCUENTA_EQUIVALENTE.Text, "D")
                CargaCuentasEquivalentes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text)
                LimpiaCamposEquivalentes()
            End If
        End If
    End Sub

    Private Sub dgvCuentasEquivalentes_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasEquivalentes.CellEnter
        Me.cmbCOMPAÑIA_EQUIVALENTE.SelectedValue = Me.dgvCuentasEquivalentes.CurrentRow.Cells.Item(5).Value
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.SelectedValue = Me.dgvCuentasEquivalentes.CurrentRow.Cells.Item(3).Value
        Me.txtCUENTA_EQUIVALENTE.Text = Me.dgvCuentasEquivalentes.CurrentRow.Cells.Item(0).Value
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Text = Me.dgvCuentasEquivalentes.CurrentRow.Cells.Item(1).Value
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Text = Me.dgvCuentasEquivalentes.CurrentRow.Cells.Item(2).Value
    End Sub


    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            If txtCUENTA_COMPLETA.Text = "" Then
                MsgBox("Favor ingresar un codigo de cuenta", MsgBoxStyle.Information)
            Else
                Dim tbl As DataTable = c_data2.ejecutaSQLl_llenaDTABLE("SELECT DESCRIPCION_CUENTA,CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & cmbCOMPAÑIA.SelectedValue & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_COMPLETA.Text.Trim & "' AND CUENTA_MAYOR=0")

                If tbl IsNot Nothing And tbl.Rows.Count > 0 Then
                    txtDESCRIPCION_CUENTA.Text = tbl.Rows(0)(0)

                    If txtDESCRIPCION_CUENTA.Text = "" Then
                        txtCUENTA.Text = ""
                        txtCUENTA_COMPLETA.Text = ""
                        MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                    Else
                        btnBuscar.Focus()
                        txtCUENTA.Text = tbl.Rows(0)(1).ToString.Trim
                    End If
                Else
                    MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                End If
            End If

        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_EQUIVALENTE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA_EQUIVALENTE.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            If txtCUENTA_COMPLETA_EQUIVALENTE.Text = "" Then
                MsgBox("Favor ingresar un codigo de cuenta", MsgBoxStyle.Information)
            Else
                Dim tbl As DataTable = c_data2.ejecutaSQLl_llenaDTABLE("SELECT DESCRIPCION_CUENTA,CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & cmbCOMPAÑIA.SelectedValue & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_COMPLETA_EQUIVALENTE.Text.Trim & "' AND CUENTA_MAYOR=0")

                If tbl IsNot Nothing And tbl.Rows.Count > 0 Then
                    txtDESCRIPCION_CUENTA_EQUIVALENTE.Text = tbl.Rows(0)(0)

                    If txtDESCRIPCION_CUENTA_EQUIVALENTE.Text = "" Then
                        txtCUENTA_COMPLETA_EQUIVALENTE.Text = ""
                        txtCUENTA_EQUIVALENTE.Text = ""
                        MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                    Else
                        btnBuscar_Equivalente.Focus()
                        txtCUENTA_EQUIVALENTE.Text = tbl.Rows(0)(1).ToString.Trim
                    End If
                Else
                    MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub Contabilidad_CuentasEquivalentes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class