Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Contabilidad_Reportes_Auxiliar_Cuentas
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim c_data2 As New jarsClass
    Dim Rpts As New frmReportes_Ver
    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        CargaLibrosContables(Compañia)
        Iniciando = False
    End Sub

#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS02 As New DataSet()
    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Private Sub CargaLibrosContables(ByVal Compañia)
        Try
            DS02.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            MiddleConnection()
            DataAdapter.Fill(DS02)
            Me.cmbLIBRO_CONTABLE.DataSource = DS02.Tables(0)
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    'Private Sub btnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
    '    Dim Cuentas As New Contabilidad_BusquedaCuentas
    '    Cuentas.Compañia_Value = Compañia
    '    Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
    '    Cuentas.cmbCOMPAÑIA.Enabled = False
    '    Cuentas.cmbLIBRO_CONTABLE.Enabled = False
    '    Cuentas.BuscaTodas = False
    '    Producto = ""
    '    Descripcion_Producto = ""
    '    Cuentas.ShowDialog()
    '    If Producto <> "" Then
    '        Me.lblCuenta.Text = Producto
    '        Me.txtCUENTA_I.Text = Tipo
    '        Producto = ""
    '        Descripcion_Producto = ""
    '    End If
    'End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        If MsgBox("¿Está seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If Me.txtCUENTA_I.Text.Trim <> "" And Me.txtCUENTA_F.Text.Trim <> "" Then
                If Me.txtCUENTA_I.Text <= Me.txtCUENTA_F.Text Then
                    If Me.dpFecha_I.Value.Date <= Me.dpFecha_F.Value.Date Then
                        Me.Label.Visible = True
                        Rpts.CargaReporteAuxiliarContable(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA_I.Text, Me.txtCUENTA_F.Text, Format(Me.dpFecha_I.Value, "dd-MM-yyyy 00:00:01"), Format(Me.dpFecha_F.Value, "dd-MM-yyyy 00:00:01"))
                        If Hay_Datos Then
                            Rpts.ShowDialog()
                        End If
                        Me.Label.Visible = False
                    Else
                        MsgBox("Fecha Inicial es Mayor que la Final.", MsgBoxStyle.Exclamation, "FECHAS")
                    End If
                Else
                    MsgBox("Cuenta Inicial es Mayor que la Final.", MsgBoxStyle.Exclamation, "CUENTAS")
                End If
            Else
                MsgBox("Cuentas No deben estar vacías.", MsgBoxStyle.Exclamation, "CUENTAS VACIAS")
            End If
        End If
    End Sub
    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_I.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If txtCUENTA_I.Text.Trim = "" Then
                MsgBox("Favor ingresar un código de cuenta", MsgBoxStyle.Information)
            Else
                Me.txtCONCEPTO_I.Text = c_data2.obtenerEscalar("SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_I.Text.Trim & "'") ' AND CUENTA_MAYOR=0")

                If Me.txtCONCEPTO_I.Text.Trim = "" Then
                    MsgBox("Cuenta ingresada no existe. Favor verificar", MsgBoxStyle.Information, "CUENTAS")
                    txtCUENTA_I.Text = ""
                    txtCONCEPTO_I.Text = ""
                    txtCUENTA_I.Focus()
                Else
                    txtCUENTA_F.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCUENTA_F_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_F.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If txtCUENTA_F.Text.Trim = "" Then
                MsgBox("Favor ingresar un código de cuenta", MsgBoxStyle.Information)
            Else
                Me.txtCONCEPTO_F.Text = c_data2.obtenerEscalar("SELECT DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_F.Text.Trim & "'") ' AND CUENTA_MAYOR=0")

                If Me.txtCONCEPTO_F.Text.Trim = "" Then
                    MsgBox("Cuenta ingresada no existe. Favor verificar", MsgBoxStyle.Information, "CUENTAS")
                    txtCUENTA_F.Text = ""
                    txtCONCEPTO_F.Text = ""
                    txtCUENTA_F.Focus()
                Else
                    Me.btnVerBC.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscarCuenta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta1.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = False
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_I.Text = Tipo
            Me.txtCONCEPTO_I.Text = Descripcion_Producto
        End If
    End Sub

    Private Sub btnBuscarCuenta2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta2.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = False
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.txtCUENTA_F.Text = Tipo
            Me.txtCONCEPTO_F.Text = Descripcion_Producto
        End If
    End Sub

    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class