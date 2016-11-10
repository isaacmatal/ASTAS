Imports System.Data.SqlClient

Public Class Contabilidad_Clientes_Cuentas_Contables
    Dim jClass As New jarsClass
    Dim index As Integer

    Private Sub Contabilidad_Clientes_Cuentas_Contables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBodega(Compañia, Me.cmbBodega)
        cargaCMB()
        CargaGrid()
        Iniciando = False
    End Sub

    Private Sub cargaCMB()
        Dim sql As String
        jClass.CargaBodega(Compañia, Me.cmbBodega)
        sql = "SELECT CUENTA_COMPLETA + '-' + DESCRIPCION_CUENTA AS DESCRIPCION_CUENTA, CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = (SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1)"
        Me.cmbCuentaContable.DataSource = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbCuentaContable.DisplayMember = "DESCRIPCION_CUENTA"
        Me.cmbCuentaContable.ValueMember = "CUENTA"
        sql = "SELECT NOMBRE,CLIENTE FROM CONTABILIDAD_CATALOGO_CLIENTES WHERE CLIENTE > 0"
        Me.cmbCliente.DataSource = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbCliente.DisplayMember = "NOMBRE"
        Me.cmbCliente.ValueMember = "CLIENTE"
    End Sub

    Private Sub CargaGrid()
        Dim tblCtasClientes As DataTable
        tblCtasClientes = jClass.obtenerDatos(New SqlCommand("EXECUTE [sp_CONTABILIDAD_CATALOGO_CLIENTES] @COMPAÑIA = " & Compañia & ", @NOMBRE = '', @NIT = '', @BANDERA = 5"))
        Me.dgvCtasClientes.DataSource = tblCtasClientes
        For i As Integer = 3 To Me.dgvCtasClientes.Columns.Count - 1
            Me.dgvCtasClientes.Columns(i).Visible = False
        Next
    End Sub

    Private Sub Contabilidad_Clientes_Cuentas_Contables_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.cmbBodega.SelectedIndex = -1
        Me.cmbCliente.SelectedIndex = -1
        Me.cmbCuentaContable.SelectedIndex = -1
        index = 0
    End Sub

    Private Sub dgvCtasClientes_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCtasClientes.CellEnter
        If e.RowIndex > -1 Then
            Me.cmbCliente.SelectedValue = Me.dgvCtasClientes.Rows(e.RowIndex).Cells(3).Value
            Me.cmbBodega.SelectedValue = Me.dgvCtasClientes.Rows(e.RowIndex).Cells(4).Value
            Me.cmbCuentaContable.SelectedValue = Me.dgvCtasClientes.Rows(e.RowIndex).Cells(5).Value
            index = Me.dgvCtasClientes.Rows(e.RowIndex).Cells(6).Value
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Sql As String
        If index = 0 Then
            Sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CLIENTES_CUENTAS_CONTABLES]" & vbCrLf
            Sql &= "           ([COMPAÑIA]" & vbCrLf
            Sql &= "           ,[CLIENTE]" & vbCrLf
            Sql &= "           ,[BODEGA]" & vbCrLf
            Sql &= "           ,[CUENTA_CONTABLE]" & vbCrLf
            Sql &= "           ,[USUARIO_CREACION]" & vbCrLf
            Sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
            Sql &= "           ,[USUARIO_EDICION]" & vbCrLf
            Sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           (" & Compañia & vbCrLf
            Sql &= "           ," & Me.cmbCliente.SelectedValue & vbCrLf
            Sql &= "           ," & Me.cmbBodega.SelectedValue & vbCrLf
            Sql &= "           ," & Me.cmbCuentaContable.SelectedValue & vbCrLf
            Sql &= "           ,'" & Usuario & "'" & vbCrLf
            Sql &= "           ,GETDATE()" & vbCrLf
            Sql &= "           ,'" & Usuario & "'" & vbCrLf
            Sql &= "           ,GETDATE())" & vbCrLf
        Else
            Sql = "UPDATE [dbo].[CONTABILIDAD_CATALOGO_CLIENTES_CUENTAS_CONTABLES]" & vbCrLf
            Sql &= "   SET [COMPAÑIA] = " & Compañia & vbCrLf
            Sql &= "      ,[CLIENTE] = " & Me.cmbCliente.SelectedValue & vbCrLf
            Sql &= "      ,[BODEGA] = " & Me.cmbBodega.SelectedValue & vbCrLf
            Sql &= "      ,[CUENTA_CONTABLE] = " & Me.cmbCuentaContable.SelectedValue & vbCrLf
            Sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            Sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            Sql &= " WHERE INDICE = " & index & vbCrLf
        End If
        If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            MsgBox("Registro guardado éxitosamente", MsgBoxStyle.Information, "Guardar datos")
        End If
        CargaGrid()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim Sql As String
        Sql = "DELETE FROM [dbo].[CONTABILIDAD_CATALOGO_CLIENTES_CUENTAS_CONTABLES]" & vbCrLf
        Sql &= " WHERE INDICE = " & index & vbCrLf
        If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Guardar datos")
        End If
        CargaGrid()
    End Sub
End Class