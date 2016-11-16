Imports System.Data.SqlClient

Public Class Activo_Fijo_Reporte_Comparativos
    Dim i As Integer = 0
    Dim Table As DataTable
    Dim sql As String
    Dim jClass As New jarsClass
    Dim objEntidad As New EntidadGenerica
    Dim _clasificacion As New DataTable()
    Dim _tpo_bien As New DataTable()    

    Private Sub Activo_Fijo_Reporte_Comparativos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        sql = "SELECT CLASIFICACION,DESCRIPCION_CLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE COMPAÑIA=" & Compañia
        Me._clasificacion = jClass.obtenerDatos(New SqlCommand(sql))
        _clasificacion.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
        For Each _selrow As DataRow In _clasificacion.Rows
            _selrow("Seleccione") = False
        Next _selrow

        Me.dgvClasificacion.DataSource = _clasificacion

        With dgvClasificacion
            .Columns("CLASIFICACION").Visible = False
            .Columns("CLASIFICACION").DisplayIndex = 0
            .Columns("Seleccione").DisplayIndex = 1
            .Columns("Seleccione").Width = 65
            .Columns("DESCRIPCION_CLASIFICACION").DisplayIndex = 2
            .Columns("DESCRIPCION_CLASIFICACION").Width = 200
            .Columns("DESCRIPCION_CLASIFICACION").HeaderText = "Clasificación"
        End With
    End Sub

    Private Sub Activo_Fijo_Reporte_Comparativos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub dgvClasificacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClasificacion.CellContentClick
        If dgvClasificacion.CurrentRow.Cells(2).Value Then
            dgvClasificacion.CurrentRow.Cells(2).Value = False
        Else
            dgvClasificacion.CurrentRow.Cells(2).Value = True
        End If
        procesoClasificacion()
    End Sub

    Private Sub procesoClasificacion()
        Dim _clasificaciones As String = String.Empty

        For i = 0 To dgvClasificacion.Rows.Count - 1
            If (Me.dgvClasificacion.Rows(i).Cells(2).Value) Then
                _clasificaciones &= CInt(Me.dgvClasificacion.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _clasificaciones = _clasificaciones.TrimEnd(",")

        If _clasificaciones.Length > 0 Then
            sql = "SELECT T.TIPO_BIEN,T.DESCRPCION,(SELECT DESCRIPCION_CLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE CLASIFICACION = T.CLASIFICACION) AS DCLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO_BIEN T WHERE T.COMPAÑIA=" & Compañia & " AND T.CLASIFICACION IN (" & _clasificaciones & ")"
            Me._tpo_bien = jClass.obtenerDatos(New SqlCommand(sql))
            _tpo_bien.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
            For Each _selrow As DataRow In _tpo_bien.Rows
                _selrow("Seleccione") = False
            Next _selrow

            Me.dgvTipoBien.DataSource = _tpo_bien

            With dgvTipoBien
                .Columns("TIPO_BIEN").Visible = False
                .Columns("TIPO_BIEN").DisplayIndex = 0
                .Columns("Seleccione").DisplayIndex = 1
                .Columns("Seleccione").Width = 65
                .Columns("DESCRPCION").DisplayIndex = 2
                .Columns("DESCRPCION").Width = 200
                .Columns("DESCRPCION").HeaderText = "Tipo de Bien"

                .Columns("DCLASIFICACION").DisplayIndex = 3
                .Columns("DCLASIFICACION").Width = 200
                .Columns("DCLASIFICACION").HeaderText = "Clasificación"
            End With
        Else
            Me.dgvTipoBien.DataSource = Nothing
        End If
    End Sub

    Private Sub chkAllClasificacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllClasificacion.CheckedChanged
        Dim _b As Integer
        If chkAllClasificacion.Checked Then
            For _b = 0 To Me.dgvClasificacion.Rows.Count - 1
                dgvClasificacion.Rows(_b).Cells(2).Value = True
            Next
        End If

        If Not chkAllClasificacion.Checked Then
            For _b = 0 To dgvClasificacion.Rows.Count - 1
                dgvClasificacion.Rows(_b).Cells(2).Value = False
            Next
        End If
        _b = 0

        procesoClasificacion()
    End Sub

    Private Sub chkAllTpoBien_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTpoBien.CheckedChanged
        Dim _q As Integer
        If chkAllTpoBien.Checked Then
            For _q = 0 To Me.dgvTipoBien.Rows.Count - 1
                dgvTipoBien.Rows(_q).Cells(3).Value = True
            Next
        End If

        If Not chkAllTpoBien.Checked Then
            For _q = 0 To dgvTipoBien.Rows.Count - 1
                dgvTipoBien.Rows(_q).Cells(3).Value = False
            Next
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim _clasificacion As String = String.Empty
        Dim _tipos_bien As String = String.Empty

        For i = 0 To Me.dgvClasificacion.Rows.Count - 1
            If (Me.dgvClasificacion.Rows(i).Cells(2).Value) Then
                _clasificacion &= CInt(Me.dgvClasificacion.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _clasificacion = _clasificacion.TrimEnd(",")

        For i = 0 To dgvTipoBien.Rows.Count - 1
            If (Me.dgvTipoBien.Rows(i).Cells(3).Value) Then
                _tipos_bien &= CInt(Me.dgvTipoBien.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _tipos_bien = _tipos_bien.TrimEnd(",")

        If Me.radCategoria.Checked Then
            If Not _clasificacion.Length > 0 Then
                MessageBox.Show("Seleccione las categorias a incluir en el Reporte", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
        End If
        
        If Me.radTipoBien.Checked Then
            If Not _tipos_bien.Length > 0 Then
                MessageBox.Show("Seleccione los Tipos de Bienes a incluir en el Reporte", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
        End If

        Me.btnPrint.Visible = False
        Dim _verreport As New frmReportes_Ver()
        _verreport.ReportesActivoFijoComparativos(dtpHasta.Value.ToShortDateString(), _tipos_bien, _clasificacion, IIf(Me.radCategoria.Checked, "1", "0"))
        _verreport.ShowDialog()
        Me.btnPrint.Visible = True
       
    End Sub
End Class