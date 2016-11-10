Imports System.Data
Imports System.Data.SqlClient

Public Class Activo_Fijo_Reports_Viewer
    Dim i As Integer = 0
    Dim Table As DataTable
    Dim sql As String
    Dim jClass As New jarsClass
    Dim objEntidad As New EntidadGenerica
    Dim _clasificacion As New DataTable()
    Dim _tpo_bien As New DataTable()
    Dim _bienes As New DataTable()
    Dim _ubicacion As New DataTable()
    Dim _codigos_ubicacion As String = String.Empty
    Dim _tipos_bien As String = String.Empty

    Private Sub Activo_Fijo_Reports_Viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'Ubicacion
        sql = "SELECT UBICACION, DESCRIPCION_UBICACION  FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION"
        Me._ubicacion = jClass.obtenerDatos(New SqlCommand(sql))
        _ubicacion.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
        For Each _sel_row As DataRow In _ubicacion.Rows
            _sel_row("Seleccione") = True
        Next _sel_row

        Me.dgvUbicacion.DataSource = _ubicacion

        With dgvUbicacion
            .Columns("UBICACION").Visible = False
            .Columns("UBICACION").DisplayIndex = 0
            .Columns("Seleccione").DisplayIndex = 1
            .Columns("Seleccione").Width = 65
            .Columns("DESCRIPCION_UBICACION").DisplayIndex = 2
            .Columns("DESCRIPCION_UBICACION").Width = 275
            .Columns("DESCRIPCION_UBICACION").HeaderText = "Ubicación"
        End With
    End Sub

    Private Sub Activo_Fijo_Reports_Viewer_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim _codigo_bienes As String = String.Empty

        For i = 0 To Me.dgvBienesSeleccionar.Rows.Count - 1
            If (Me.dgvBienesSeleccionar.Rows(i).Cells(6).Value) Then
                _codigo_bienes &= CInt(Me.dgvBienesSeleccionar.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _codigo_bienes = _codigo_bienes.TrimEnd(",")

        'Verificacondo si se filtro por ubicacion
        For i = 0 To Me.dgvUbicacion.Rows.Count - 1
            If (Me.dgvUbicacion.Rows(i).Cells(2).Value) Then
                _codigos_ubicacion &= CInt(Me.dgvUbicacion.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _codigos_ubicacion = _codigos_ubicacion.TrimEnd(",")
        If Not _codigos_ubicacion.Length > 0 Then
            _codigos_ubicacion = "NULL"
        End If

        If _codigo_bienes.Length > 0 Then
            Me.btnPrint.Visible = False
            Dim _verreport As New frmReportes_Ver()
            _verreport.ReportesActivoFijo(dtpHasta.Value.ToShortDateString(), IIf(radFinanciero.Checked, "financiero", "fiscal"), IIf(Me.radCatAmbos.Checked, 3, IIf(Me.radDepreciable.Checked, 1, 0)), IIf(Me.chkDeBaja.Checked, 1, 0), _codigo_bienes, _codigos_ubicacion)
            _verreport.ShowDialog()
            Me.btnPrint.Visible = True
        Else
            MessageBox.Show("Seleccione los Bienes a incluir en el Reporte", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub dgvClasificacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClasificacion.CellContentClick
        If dgvClasificacion.CurrentRow.Cells(2).Value Then
            dgvClasificacion.CurrentRow.Cells(2).Value = False
        Else
            dgvClasificacion.CurrentRow.Cells(2).Value = True
        End If
        procesoClasificacion()
    End Sub

    

    Private Sub dgvTipoBien_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoBien.CellContentClick
        If dgvTipoBien.CurrentRow.Cells(3).Value Then
            dgvTipoBien.CurrentRow.Cells(3).Value = False
        Else
            dgvTipoBien.CurrentRow.Cells(3).Value = True
        End If
        procesoTpoBien()
    End Sub

    Private Sub procesoTpoBien()
        _tipos_bien = String.Empty
        For i = 0 To dgvTipoBien.Rows.Count - 1
            If (Me.dgvTipoBien.Rows(i).Cells(3).Value) Then
                _tipos_bien &= CInt(Me.dgvTipoBien.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _tipos_bien = _tipos_bien.TrimEnd(",")

        If _tipos_bien.Length > 0 Then
            Dim _depreciable As String = IIf(Me.radCatAmbos.Checked, String.Empty, IIf(Me.radDepreciable.Checked, " AND B.APLICAR_DEPRECIACION = 1 ", " AND B.APLICAR_DEPRECIACION = 0 "))
            sql = "SELECT B.BIEN,B.DESCRIPCION_BIEN, (SELECT DESCRIPCION_CLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE CLASIFICACION = B.CLASIFICACION) AS CLASIFICACION,(SELECT DESCRPCION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO_BIEN WHERE TIPO_BIEN = B.TIPO_BIEN) As TIPO, (SELECT DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION WHERE UBICACION = B.UBICACION) AS DESCRIPCION_UBICACION, B.CODIGO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN B WHERE B.COMPAÑIA=" & Compañia & _depreciable & " AND CONVERT(date, B.FECHA_ADQUICICION, 103) <= CONVERT(date, '" & Me.dtpHasta.Value.ToShortDateString() & "', 103) AND B.BAJA_TOTAL=" & IIf(Me.chkDeBaja.Checked, "1", "0") & " AND B.TIPO_BIEN IN (" & _tipos_bien & ")"
            Me._bienes = jClass.obtenerDatos(New SqlCommand(sql))
            _bienes.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
            For Each _selrow As DataRow In _bienes.Rows
                _selrow("Seleccione") = False
            Next _selrow

            Me.dgvBienesSeleccionar.DataSource = _bienes

            With dgvBienesSeleccionar
                .Columns("BIEN").Visible = False
                .Columns("BIEN").DisplayIndex = 0

                .Columns("Seleccione").DisplayIndex = 1
                .Columns("Seleccione").Width = 65

                .Columns("DESCRIPCION_BIEN").DisplayIndex = 2
                .Columns("DESCRIPCION_BIEN").Width = 300
                .Columns("DESCRIPCION_BIEN").HeaderText = "Descripción del Bien"

                .Columns("CLASIFICACION").DisplayIndex = 3
                .Columns("CLASIFICACION").Width = 150
                .Columns("CLASIFICACION").HeaderText = "Clasificación"

                .Columns("TIPO").DisplayIndex = 4
                .Columns("TIPO").Width = 200
                .Columns("TIPO").HeaderText = "Tipo de Bien"

                .Columns("CODIGO").DisplayIndex = 5
                .Columns("CODIGO").Width = 100
                .Columns("CODIGO").HeaderText = "Código"

                .Columns("DESCRIPCION_UBICACION").DisplayIndex = 6
                .Columns("DESCRIPCION_UBICACION").Width = 250
                .Columns("DESCRIPCION_UBICACION").HeaderText = "Ubicacion"
            End With
        Else
            Me.dgvBienesSeleccionar.DataSource = Nothing
        End If
    End Sub

    Private Sub dgvBienesSeleccionar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBienesSeleccionar.CellContentClick
        If dgvBienesSeleccionar.CurrentRow.Cells(6).Value Then
            dgvBienesSeleccionar.CurrentRow.Cells(6).Value = False
        Else
            dgvBienesSeleccionar.CurrentRow.Cells(6).Value = True
        End If
    End Sub

    Private Sub txtDescripcionBien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcionBien.TextChanged
        If _bienes.Rows.Count > 0 Then
            Dim dv As New DataView(_bienes)
            dv.RowFilter = "DESCRIPCION_BIEN like '%" & txtDescripcionBien.Text & "%' OR CODIGO like '%" & txtDescripcionBien.Text & "%' OR DESCRIPCION_UBICACION Like '%" & txtDescripcionBien.Text & "%'"
            Me.dgvBienesSeleccionar.DataSource = dv
        End If
    End Sub

    Private Sub chkBienesAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBienesAll.CheckedChanged
        Dim _s As Integer
        If chkBienesAll.Checked Then
            For _s = 0 To Me.dgvBienesSeleccionar.Rows.Count - 1
                dgvBienesSeleccionar.Rows(_s).Cells(6).Value = True
            Next
        End If

        If Not chkBienesAll.Checked Then
            For _s = 0 To dgvBienesSeleccionar.Rows.Count - 1
                dgvBienesSeleccionar.Rows(_s).Cells(6).Value = False
            Next
        End If
    End Sub

    Private Sub dgvUbicacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUbicacion.CellContentClick
        If dgvUbicacion.CurrentRow.Cells(2).Value Then
            dgvUbicacion.CurrentRow.Cells(2).Value = False
        Else
            dgvUbicacion.CurrentRow.Cells(2).Value = True
        End If

        procesoUbicaciones()
    End Sub

    Private Sub procesoUbicaciones()
        _codigos_ubicacion = String.Empty
        For i = 0 To Me.dgvUbicacion.Rows.Count - 1
            If (Me.dgvUbicacion.Rows(i).Cells(2).Value) Then
                _codigos_ubicacion &= CInt(Me.dgvUbicacion.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _codigos_ubicacion = _codigos_ubicacion.TrimEnd(",")

        If _codigos_ubicacion.Length > 0 Then
            Dim _depreciable As String = IIf(Me.radCatAmbos.Checked, String.Empty, IIf(Me.radDepreciable.Checked, " AND B.APLICAR_DEPRECIACION = 1 ", " AND B.APLICAR_DEPRECIACION = 0 "))
            If _tipos_bien.Length > 0 Then
                sql = "SELECT B.BIEN,B.DESCRIPCION_BIEN, (SELECT DESCRIPCION_CLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE CLASIFICACION = B.CLASIFICACION) AS CLASIFICACION,(SELECT DESCRPCION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO_BIEN WHERE TIPO_BIEN = B.TIPO_BIEN) As TIPO, (SELECT DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION WHERE UBICACION = B.UBICACION) AS DESCRIPCION_UBICACION, B.CODIGO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN B WHERE B.COMPAÑIA=" & Compañia & _depreciable & " AND CONVERT(date, B.FECHA_ADQUICICION, 103) <= CONVERT(date, '" & Me.dtpHasta.Value.ToShortDateString() & "', 103) AND B.BAJA_TOTAL=" & IIf(Me.chkDeBaja.Checked, "1", "0") & " AND B.TIPO_BIEN IN (" & _tipos_bien & ") AND B.UBICACION IN (" & _codigos_ubicacion & ")"
            Else
                sql = "SELECT B.BIEN,B.DESCRIPCION_BIEN, (SELECT DESCRIPCION_CLASIFICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE CLASIFICACION = B.CLASIFICACION) AS CLASIFICACION,(SELECT DESCRPCION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO_BIEN WHERE TIPO_BIEN = B.TIPO_BIEN) As TIPO, (SELECT DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION WHERE UBICACION = B.UBICACION) AS DESCRIPCION_UBICACION, B.CODIGO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN B WHERE B.COMPAÑIA=" & Compañia & _depreciable & " AND CONVERT(date, B.FECHA_ADQUICICION, 103) <= CONVERT(date, '" & Me.dtpHasta.Value.ToShortDateString() & "', 103) AND B.BAJA_TOTAL=" & IIf(Me.chkDeBaja.Checked, "1", "0") & " AND B.UBICACION IN (" & _codigos_ubicacion & ")"
            End If

            Me._bienes = jClass.obtenerDatos(New SqlCommand(sql))
            _bienes.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
            For Each _selrow As DataRow In _bienes.Rows
                _selrow("Seleccione") = False
            Next _selrow

            Me.dgvBienesSeleccionar.DataSource = _bienes

            With dgvBienesSeleccionar
                .Columns("BIEN").Visible = False
                .Columns("BIEN").DisplayIndex = 0

                .Columns("Seleccione").DisplayIndex = 1
                .Columns("Seleccione").Width = 65

                .Columns("DESCRIPCION_BIEN").DisplayIndex = 2
                .Columns("DESCRIPCION_BIEN").Width = 300
                .Columns("DESCRIPCION_BIEN").HeaderText = "Descripción del Bien"

                .Columns("CLASIFICACION").DisplayIndex = 3
                .Columns("CLASIFICACION").Width = 150
                .Columns("CLASIFICACION").HeaderText = "Clasificación"

                .Columns("TIPO").DisplayIndex = 4
                .Columns("TIPO").Width = 200
                .Columns("TIPO").HeaderText = "Tipo de Bien"

                .Columns("CODIGO").DisplayIndex = 5
                .Columns("CODIGO").Width = 100
                .Columns("CODIGO").HeaderText = "Código"

                .Columns("DESCRIPCION_UBICACION").DisplayIndex = 6
                .Columns("DESCRIPCION_UBICACION").Width = 250
                .Columns("DESCRIPCION_UBICACION").HeaderText = "Ubicacion"
            End With
        Else
            Me.dgvBienesSeleccionar.DataSource = Nothing
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
        _q = 0
        procesoTpoBien()
    End Sub

    Private Sub chkAllUbica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllUbica.CheckedChanged
        Dim _q As Integer
        If chkAllUbica.Checked Then
            For _q = 0 To Me.dgvUbicacion.Rows.Count - 1
                dgvUbicacion.Rows(_q).Cells(2).Value = True
            Next
        End If

        If Not chkAllUbica.Checked Then
            For _q = 0 To dgvUbicacion.Rows.Count - 1
                dgvUbicacion.Rows(_q).Cells(2).Value = False
            Next
        End If
        _q = 0
        procesoUbicaciones()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Me.resetear()
    End Sub

    Private Sub resetear()
        Me.txtDescripcionBien.Text = String.Empty
        Me.chkAllClasificacion.Checked = False
        Me.chkAllTpoBien.Checked = False
        Me.chkAllUbica.Checked = True
        Me.chkBienesAll.Checked = False
        Me.dgvBienesSeleccionar.DataSource = Nothing
    End Sub

    Private Sub radDepreciable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDepreciable.Click
        Me.resetear()
    End Sub

    Private Sub radNoDepreciable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNoDepreciable.Click
        Me.resetear()
    End Sub

    Private Sub radCatAmbos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCatAmbos.Click
        Me.resetear()
    End Sub

    Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
        Me.resetear()
    End Sub
End Class