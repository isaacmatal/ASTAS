Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Rubros_Detalle
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Reportes_Rubros_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaReportes(Me.cmbCOMPA�IA.SelectedValue, 2)
        CargaLibroContable(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue)
        CargaGrupo(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, 0)
        CargaRubros(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 0)
        CargaDetalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub CargaCompa�ia()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaReportes(ByVal Compa�ia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES "
            Sql &= Compa�ia
            Sql &= ", 0" 'LIBRO_CONTABLE
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbREPORTE.DataSource = Table
            Me.cmbREPORTE.ValueMember = "REPORTE"
            Me.cmbREPORTE.DisplayMember = "DESCRIPCION"
            If Me.cmbREPORTE.Items.Count = 0 Then
                Me.dgvDetalle.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaGrupo(ByVal Compa�ia, ByVal Reporte, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_GRUPOS "
            Sql &= Compa�ia
            Sql &= ", " & Reporte
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbGRUPO.DataSource = Table
            Me.cmbGRUPO.ValueMember = "GRUPO"
            Me.cmbGRUPO.DisplayMember = "DESCRIPCION_GRUPO"
            If Me.cmbGRUPO.Items.Count = 0 Then
                Me.dgvDetalle.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaRubros(ByVal Compa�ia, ByVal Reporte, ByVal Grupo, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_RUBROS "
            Sql &= Compa�ia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbRUBRO.DataSource = Table
            Me.cmbRUBRO.ValueMember = "RUBRO"
            Me.cmbRUBRO.DisplayMember = "DESCRIPCION_RUBRO"
            If Me.cmbRUBRO.Items.Count = 0 Then
                Me.dgvDetalle.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibroContable(ByVal Compa�ia, ByVal Reporte)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_REPORTES "
            Sql &= "Where COMPA�IA = " & Compa�ia
            Sql &= " And REPORTE =  " & Reporte
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Me.lblLIBRO_CONTABLE.Text = Datareader_.Item("LIBRO_CONTABLE")
            Else
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscaCuenta(ByVal Compa�ia, ByVal LC, ByVal CuentaCompleta, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_CUENTAS "
            Sql &= "Where COMPA�IA = " & Compa�ia
            Sql &= " And LIBRO_CONTABLE =  " & LC
            Sql &= " And CUENTA_COMPLETA =  '" & CuentaCompleta & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Select Case Bandera
                    Case 1
                        Me.lblDESCRIPCION_CUENTA_01.Text = Datareader_.Item("DESCRIPCION_CUENTA")
                    Case 2
                        Me.lblDESCRIPCION_CUENTA_02.Text = Datareader_.Item("DESCRIPCION_CUENTA")
                End Select
            Else
                Select Case Bandera
                    Case 1
                        Me.lblDESCRIPCION_CUENTA_01.Text = ""
                    Case 2
                        Me.lblDESCRIPCION_CUENTA_02.Text = ""
                End Select
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.TxtDETALLE.Text = ""
        Me.TxtCUENTA_COMPLETA_01.Text = ""
        Me.TxtCUENTA_COMPLETA_02.Text = ""
        Me.lblDESCRIPCION_CUENTA_01.Text = ""
        Me.lblDESCRIPCION_CUENTA_02.Text = ""
        Me.Txt_Nombe.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Me.TxtDETALLE.Text = "" Then
            MsgBox("�N�mero de l�nea no est� definida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.TxtCUENTA_COMPLETA_01.Text = "" Then
            MsgBox("�Debe seleccionar una Cuenta Inicial v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.TxtCUENTA_COMPLETA_02.Text = "" Then
            MsgBox("�Debe seleccionar una Cuenta Final v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.cmbCARGO_ABONO.Text = "" Then
            MsgBox("�Debe seleccionar si el Detalle ser� Cargo / Abono / Saldo! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Detalle(ByVal Compa�ia, ByVal Reporte, ByVal Grupo, ByVal Rubro, ByVal Detalle, ByVal Cuenta_Inicial, ByVal Cuenta_Final, ByVal CargoAbono, ByVal CambioLinea, ByVal Nombre, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_RUBROS_DETALLE_IUD "
            Sql &= Compa�ia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", " & Rubro
            Sql &= ", " & Detalle
            Sql &= ", '" & Cuenta_Inicial & "'"
            Sql &= ", '" & Cuenta_Final & "'"
            Sql &= ", '" & CargoAbono & "'"
            Sql &= ", " & CambioLinea
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Nombre & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            DataAdapter = New SqlDataAdapter(Comando_)
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("�L�nea de Detalle Almacenada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�L�nea de Detalle Actualizada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�L�nea de Detalle Eliminada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvDetalle.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDetalle.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDetalle.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDetalle.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDetalle.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDetalle.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CargaDetalle(ByVal Compa�ia, ByVal Reporte, ByVal Grupo, ByVal Rubro, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_RUBROS_DETALLE "
            Sql &= Compa�ia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", " & Rubro
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvDetalle.Columns.Clear()
            Me.dgvDetalle.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaReportes(Me.cmbCOMPA�IA.SelectedValue, 2)
        End If
    End Sub

    Private Sub cmbREPORTE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbREPORTE.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaLibroContable(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue)
            CargaGrupo(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, 0)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnBuscar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar01.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Cuentas.LibroContable_Value = Me.lblLIBRO_CONTABLE.Text
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = True
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.TxtCUENTA_COMPLETA_01.Text = Tipo
            Me.lblDESCRIPCION_CUENTA_01.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnBuscar02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar02.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Cuentas.LibroContable_Value = Me.lblLIBRO_CONTABLE.Text
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = True
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.TxtCUENTA_COMPLETA_02.Text = Tipo
            Me.lblDESCRIPCION_CUENTA_02.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            Mantenimiento_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, Val(Me.TxtDETALLE.Text), Me.TxtCUENTA_COMPLETA_01.Text, Me.TxtCUENTA_COMPLETA_02.Text, Mid(Me.cmbCARGO_ABONO.Text, 1, 1), IIf(Me.ChkLinea.CheckState, 1, 0), Me.Txt_Nombe.Text, "I")
            CargaDetalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub cmbRUBRO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRUBRO.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaDetalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, 1)
        End If
    End Sub

    Private Sub dgvDetalle_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter
        Me.TxtDETALLE.Text = Me.dgvDetalle.CurrentRow.Cells.Item(0).Value
        Me.TxtCUENTA_COMPLETA_01.Text = Me.dgvDetalle.CurrentRow.Cells.Item(1).Value
        Me.TxtCUENTA_COMPLETA_02.Text = Me.dgvDetalle.CurrentRow.Cells.Item(2).Value
        BuscaCuenta(Me.cmbCOMPA�IA.SelectedValue, Me.lblLIBRO_CONTABLE.Text, Me.TxtCUENTA_COMPLETA_01.Text, 1)
        BuscaCuenta(Me.cmbCOMPA�IA.SelectedValue, Me.lblLIBRO_CONTABLE.Text, Me.TxtCUENTA_COMPLETA_02.Text, 2)
        Me.cmbCARGO_ABONO.SelectedIndex = IIf(Me.dgvDetalle.CurrentRow.Cells.Item(6).Value = "C", 0, _
                                          IIf(Me.dgvDetalle.CurrentRow.Cells.Item(6).Value = "A", 1, 2))
        Me.Txt_Nombe.Text = Me.dgvDetalle.CurrentRow.Cells.Item(8).Value
        If Me.dgvDetalle.CurrentRow.Cells.Item(7).Value = 0 Then
            Me.ChkLinea.Checked = False
        Else
            Me.ChkLinea.Checked = True
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.TxtDETALLE.Text <> "" Then
            Mantenimiento_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, Val(Me.TxtDETALLE.Text), Me.TxtCUENTA_COMPLETA_01.Text, Me.TxtCUENTA_COMPLETA_02.Text, Mid(Me.cmbCARGO_ABONO.Text, 1, 1), IIf(Me.ChkLinea.CheckState, 1, 0), Me.Txt_Nombe.Text, "D")
            CargaDetalle(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Me.cmbRUBRO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("�Debe seleccionar un registro v�lido! Verifique" & Chr(13) & "No se eliminar� ning�n registro.", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaRubros(Me.cmbCOMPA�IA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 0)
        End If
    End Sub

    Private Sub TxtCUENTA_COMPLETA_01_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCUENTA_COMPLETA_01.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCUENTA_COMPLETA_01.Text <> Nothing Then
                BuscaCuenta(Compa�ia, lblLIBRO_CONTABLE.Text, Me.TxtCUENTA_COMPLETA_01.Text, 1)
                Me.TxtCUENTA_COMPLETA_02.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCUENTA_COMPLETA_02_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCUENTA_COMPLETA_02.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCUENTA_COMPLETA_02.Text <> Nothing Then
                BuscaCuenta(Compa�ia, lblLIBRO_CONTABLE.Text, Me.TxtCUENTA_COMPLETA_02.Text, 2)
                Me.cmbCARGO_ABONO.Focus()
            End If
        End If
    End Sub

    Private Sub TxtDETALLE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDETALLE.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If TxtDETALLE.Text <> Nothing Then
                Me.TxtCUENTA_COMPLETA_01.Focus()
            End If
        End If
    End Sub
End Class