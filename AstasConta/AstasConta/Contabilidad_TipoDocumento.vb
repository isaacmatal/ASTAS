Imports System.Data.SqlClient

Public Class Contabilidad_TipoDocumento
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_TipoDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaTiposDocumentos(Compañia, 0)
        LimpiaCampos()
        Iniciando = False
    End Sub

    Private Sub CargaTiposDocumentos(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO  "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvTipoDocumento.Columns.Clear()
            Me.dgvTipoDocumento.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Dim Fill As New cmbFill
        Fill.ajustarGrid(5, Me.dgvTipoDocumento)
    End Sub

    Private Sub LimpiaCampos()
        Me.txtTipo.Text = "0"
        Me.txtDescripcion.Text = ""
        Me.txtIdentificador.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDescripcion.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción válida!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtIdentificador.Text) = "" Then
            MsgBox("¡Debe ingresar un Identificador válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_TipoDocumento(ByVal Compañia, ByVal TipoDocumento, ByVal Descripcion, ByVal Identificador, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO_IUD "
            Sql &= Compañia
            Sql &= ", " & TipoDocumento
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Identificador & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Tipo de Documento Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Tipo de Documento Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Tipo de Documento Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaTiposDocumentos(Compañia, 0)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.txtTipo.Text = "0" Then
                Mantenimiento_TipoDocumento(Compañia, Me.txtTipo.Text, Trim(Me.txtDescripcion.Text), Trim(Me.txtIdentificador.Text), "I")
            Else
                Mantenimiento_TipoDocumento(Compañia, Me.txtTipo.Text, Trim(Me.txtDescripcion.Text), Trim(Me.txtIdentificador.Text), "U")
            End If
            LimpiaCampos()
            CargaTiposDocumentos(Compañia, 0)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.txtTipo.Text) <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mesanje") = MsgBoxResult.Yes Then
                Mantenimiento_TipoDocumento(Compañia, Me.txtTipo.Text, Trim(Me.txtDescripcion.Text), Trim(Me.txtIdentificador.Text), "D")
            End If
            LimpiaCampos()
            CargaTiposDocumentos(Compañia, 0)
        Else
            MsgBox("¡Debe seleccionar un registro válido!" & Chr(13) & "No se eliminará ningún registro.", MsgBoxStyle.Critical, "Validación")
            LimpiaCampos()
        End If
    End Sub

    Private Sub dgvTipoDocumento_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoDocumento.CellClick
       
    End Sub

    Private Sub dgvTipoDocumento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoDocumento.CellContentClick

    End Sub

    Private Sub dgvTipoDocumento_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoDocumento.CellEnter
        If Me.dgvTipoDocumento.CurrentRow.Index < Me.dgvTipoDocumento.Rows.Count Then
            Me.txtTipo.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(0).Value
            Me.txtIdentificador.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(1).Value
            Me.txtDescripcion.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(2).Value
            'Else
        End If
    End Sub

    Private Sub Contabilidad_TipoDocumento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class