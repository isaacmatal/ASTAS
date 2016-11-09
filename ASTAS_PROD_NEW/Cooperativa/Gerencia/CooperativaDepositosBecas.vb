Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class CooperativaDepositosBecas
    Dim oExcelApp = CreateObject("EXCEL.Application")
    'Dim oExcelApp = CreateObject("ADODB.Connection")
    Dim genRemesa As New generarRemesa
    Dim Sql As String
    Dim accion_ As String
    Dim sqlCmd As New SqlCommand
    Dim TableRem As New DataTable("Remesas")
    Dim TableDetSocio As New DataTable("SociosDet")
    Dim jClass As New jarsClass
    Dim iniciando As Boolean = True
    Dim correla_ As Int32
    Dim index_row_ As Int32
    Dim id_maestro_ As Int32

    Private Sub CooperativaDepositosBecas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        accion_ = "insert"
        id_maestro_ = 0
        correla_ = 0
        index_row_ = 0
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CrearTablaRem()
        CrearTablaDetalle()
        jClass.CargaBancos(Compañia, Me.cmbBanco)
        jClass.CargaBancos(Compañia, Me.cmbBanco2)
        jClass.CargaBancos(Compañia, Me.cmbBanco3)
        If Me.cmbBanco.Items.Count > 1 Then
            Me.cmbBanco.SelectedIndex = 1
        End If
        If Me.cmbBanco2.Items.Count > 1 Then
            Me.cmbBanco2.SelectedIndex = 1
        End If
        If Me.cmbBanco3.Items.Count > 1 Then
            Me.cmbBanco3.SelectedIndex = 1
        End If
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco.SelectedValue, 2, Me.cmbCuentaBancaria)
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco.SelectedValue, 2, Me.cmbCuentaBanco2)
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco.SelectedValue, 2, Me.cmbCuentaBanco3)
        iniciando = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        If Me.txtConceptoDeposito.Text.Length = 0 Then
            MsgBox("Defina un concepto para los depositos.", MsgBoxStyle.Information, "Verifique")
            Return
        End If
        If Me.txtArchivo.Text.Length = 0 Then
            MsgBox("Seleccione un archivo a cargar", MsgBoxStyle.Information, "Archivo EXCEL")
            Return
        End If
        Dim TablaDetalle As New DataTable("detalle")
        TablaDetalle.Clear()
        Dim Conexion_Track As New OleDbConnection
        Dim Comando_Track As OleDbCommand
        Dim DataReader_Track As OleDbDataReader
        Dim DataAdapter As OleDbDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        If Me.txtArchivo.Text.Length = 0 Then
            MsgBox("Seleccione un archivo a cargar", MsgBoxStyle.Information, "Archivo EXCEL")
            Return
        End If
        'Dim conStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""" & Me.txtArchivo.Text & """;Extended Properties=""Excel 8.0;HDR=Yes;"""
        Dim conStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.txtArchivo.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""

        Conexion_Track = New OleDbConnection(conStr)
        Try
            Conexion_Track.Open()
            Sql = "SELECT * FROM [" & Me.cmbSheets.Text & "$]"
            Comando_Track = New OleDbCommand(Sql, Conexion_Track)
            DataAdapter = New OleDbDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DataAdapter.Fill(TablaDetalle)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                dgvAutorizaciones.DataSource = Table
            Else
                dgvAutorizaciones.DataSource = Nothing
            End If
            Me.Text = Me.dgvAutorizaciones.Rows.Count.ToString & " Registros Cargados"
            Conexion_Track.Close()

            '===================================================
            'Dim valor_cod_ As String
            Dim archivo_ As String
            archivo_ = txtArchivo.Text
            Dim file_name As String() = archivo_.Split("\")
            Dim index_ As Int32 = file_name.Length - 1
            archivo_ = file_name(index_)

            For c As Integer = 0 To TablaDetalle.Rows.Count - 1
                TablaDetalle.Rows(c).Item(3) = txtConceptoDeposito.Text
            Next

            If TablaDetalle.Columns.Count > 5 Then
                TablaDetalle.Columns.Remove("BECADO")
                TablaDetalle.Columns.Remove("NIVEL")
            End If

            If MessageBox.Show("¿Desea almacenar esta carga en la Base de Datos S/N?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cooperativaDepositosBecas(archivo_, txtConceptoDeposito.Text, dpFechaDep.Value, cmbSheets.SelectedItem.ToString(), TablaDetalle)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
        OpenFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtArchivo.Text = OpenFile.FileName
            ListarHojasExcel(Me.txtArchivo.Text)
            Me.dgvAutorizaciones.DataSource = Nothing
        End If
    End Sub

    Private Sub ListarHojasExcel(ByVal XLSFile As String)
        Try
            While Me.cmbSheets.Items.Count > 0
                Me.cmbSheets.Items.RemoveAt(0)
            End While
            oExcelApp.WorkBooks.Open(XLSFile)
            Dim oExcelSheets = oExcelApp.WorkBooks(1).Sheets
            Dim CntSheets As Integer = oExcelSheets.Count
            For i As Integer = 1 To CntSheets
                Me.cmbSheets.Items.Add(oExcelSheets(i).Name)
            Next

            oExcelApp.WorkBooks(1).Close()
            Me.cmbSheets.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CooperativaDepositosBecas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (oExcelApp IsNot Nothing) Then
            oExcelApp.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApp)
            oExcelApp = Nothing
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            Dim CorrBAC As Integer
            Dim MontoBAC As Double = 0
            Dim NumRegsBAC As Double = 0
            Dim DatosSocio As DataTable
            genRemesa.abrirCarpeta = False
            While TableRem.Rows.Count > 0
                TableRem.Rows.RemoveAt(0)
            End While
            If Me.txtArchivo.Text.Length = 0 Then
                MsgBox("Seleccione un archivo a cargar", MsgBoxStyle.Information, "Archivo EXCEL")
                Return
            End If
            If Me.dgvAutorizaciones.Rows.Count = 0 Then
                MsgBox("No hay datos para procesar." & vbCrLf & "Cargue los datos de la hoja " & Me.cmbSheets.Text & ".", MsgBoxStyle.Information, "Archivo EXCEL")
                Return
            End If

            If Me.txtConceptoDeposito.Text.Length = 0 Then
                MsgBox("Defina un concepto para los depositos.", MsgBoxStyle.Information, "Verifique")
                Return
            End If

            For Each row As DataGridViewRow In Me.dgvAutorizaciones.Rows
                If Not IsDBNull(row.Cells(1).Value) Then
                    Sql = "SELECT (CONVERT(NVARCHAR,S.DIVISION)+CONVERT(NVARCHAR,S.SECCION)+CONVERT(NVARCHAR,S.DEPARTAMENTO)) AS [UBICACION]," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO," & vbCrLf
                    Sql &= "       S.NOMBRE_COMPLETO," & vbCrLf
                    Sql &= "       S.BANCO," & vbCrLf
                    Sql &= "	   S.CUENTA_BANCARIA," & vbCrLf
                    Sql &= "	   S.TIPO_CUENTA_BANCARIA," & vbCrLf
                    Sql &= "       S.NIT," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO_AS" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
                    Sql &= " WHERE S.CODIGO_EMPLEADO = " & row.Cells(1).Value.ToString & vbCrLf
                    Sql &= "   AND S.COMPAÑIA = " & Compañia
                    sqlCmd.CommandText = Sql
                    DatosSocio = jClass.obtenerDatos(sqlCmd)
                    If CInt(DatosSocio.Rows(0).Item("BANCO")) = Me.cmbBanco.SelectedValue Then
                        TableRem.Rows.Add(Me.cmbBanco.SelectedValue, _
                                          Me.cmbBanco.Text, _
                                          Me.cmbCuentaBancaria.SelectedValue, _
                                          DatosSocio.Rows(0).Item("NOMBRE_COMPLETO"), _
                                          row.Cells("VALOR").Value, _
                                          DatosSocio.Rows(0).Item("CUENTA_BANCARIA"), _
                                          Me.dpFechaDep.Value, _
                                          Me.txtConceptoDeposito.Text, _
                                          DatosSocio.Rows(0).Item("CODIGO_EMPLEADO_AS"), _
                                          DatosSocio.Rows(0).Item("NIT"), _
                                          DatosSocio.Rows(0).Item("UBICACION"), _
                                          DatosSocio.Rows(0).Item("CODIGO_EMPLEADO"))
                    End If
                End If
            Next
            'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
            If Me.cmbBanco.SelectedValue = 3 Then
                For i As Integer = 0 To TableRem.Rows.Count - 1
                    MontoBAC += TableRem.Rows(i).Item("MONTO")
                    NumRegsBAC += 1
                Next
                CorrBAC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                CorrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", CorrBAC))
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (CorrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                genRemesa.EncabBAC = "B4978" & CorrBAC.ToString("00000") & Format(Me.dpFechaDep.Value, "yyyyMMdd").PadLeft(33, " ") & (MontoBAC * 100).ToString().PadLeft(13, " ") & NumRegsBAC.ToString().PadLeft(5, " ")
                genRemesa.setEncab = True
            Else
                genRemesa.setEncab = False
            End If
            'For Each row As DataRow In TableRem.Rows
            For i As Integer = 0 To TableRem.Rows.Count - 1
                If i = TableRem.Rows.Count - 1 Then
                    genRemesa.abrirCarpeta = True
                End If
                genRemesa.Bloque = 1
                genRemesa.TipoTran = txtConceptoDeposito.Text '"BECADOS"
                genRemesa.ctaSocio = TableRem.Rows(i).Item("CTASOCIO")
                genRemesa.bco = Me.cmbBanco.SelectedValue
                genRemesa.monto = CDbl(TableRem.Rows(i).Item("MONTO"))
                genRemesa.NITSocio = TableRem.Rows(i).Item("NITSOCIO")
                genRemesa.FechaDep = Format(TableRem.Rows(i).Item("FECHA_CONTABLE"), "yyyyMMdd")
                genRemesa.ubicacion = TableRem.Rows(i).Item("UBICACION")
                genRemesa.socio = TableRem.Rows(i).Item("NOMBRE_COMPLETO")
                genRemesa.recibirParametros(Compañia, TableRem.Rows(i).Item("CODBANCO").ToString, TableRem.Rows(i).Item("CTASOCIO"), "0", TableRem.Rows(i).Item("CODIGO").ToString.PadLeft(6, "0"), TableRem.Rows(i).Item("CODIGOBUXIS").ToString, "BECAS")
                genRemesa.setEncab = False
            Next
            MostrarReporte()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CrearTablaRem()
        TableRem.Columns.Add("CODBANCO", Type.GetType("System.Int32"))
        TableRem.Columns.Add("BANCO", Type.GetType("System.String"))
        TableRem.Columns.Add("CUENTA_BANCARIA", Type.GetType("System.String"))
        TableRem.Columns.Add("NOMBRE_COMPLETO", Type.GetType("System.String"))
        TableRem.Columns.Add("MONTO", Type.GetType("System.Double"))
        TableRem.Columns.Add("CTASOCIO", Type.GetType("System.String"))
        TableRem.Columns.Add("FECHA_CONTABLE", Type.GetType("System.DateTime"))
        TableRem.Columns.Add("TIPORM", Type.GetType("System.String"))
        TableRem.Columns.Add("CODIGO", Type.GetType("System.Int32"))
        TableRem.Columns.Add("NITSOCIO", Type.GetType("System.String"))
        TableRem.Columns.Add("UBICACION", Type.GetType("System.String"))
        TableRem.Columns.Add("CODIGOBUXIS", Type.GetType("System.String"))
    End Sub

    Private Sub MostrarReporte()
        If TableRem.Rows.Count > 0 Then
            'Dim rows As DataRow()
            Dim TableRep As DataTable = TableRem.Clone()
            Dim rpt As New CooperativaCartaRemesasElectronicas_rpt
            Dim VerRep As New frmReportes_Ver
            rpt.SetDataSource(TableRem)
            VerRep.ReportesGenericos(rpt)
            VerRep.ShowDialog()
        Else
            MsgBox("No encontraron socios para generar remesas...", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedIndexChanged
        If Not iniciando Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco.SelectedValue, 2, Me.cmbCuentaBancaria)
        End If
    End Sub

    Private Sub cmbSheets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheets.SelectedIndexChanged
        If Not iniciando Then
            Me.dgvAutorizaciones.DataSource = Nothing
        End If
    End Sub

    Private Sub CooperativaDepositosBecas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
                   Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Public Sub cooperativaDepositosBecas(ByVal archivo_ As String, ByVal concepto_ As String, ByVal fecha_ As Date, ByVal hoja_ As String, ByVal detalle_ As DataTable)
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim sqlCmd As New SqlCommand

        Try
            sqlCmd.CommandText = "sp_COOPERATIVA_DEPOSITOS_BECAS"
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Connection = Conexion_Track
            sqlCmd.Parameters.AddWithValue("@NOMBREARCHIVO", archivo_)
            sqlCmd.Parameters.AddWithValue("@CONCEPTO", concepto_)
            sqlCmd.Parameters.AddWithValue("@FECHA", fecha_)
            sqlCmd.Parameters.AddWithValue("@ACCION", accion_)
            sqlCmd.Parameters.AddWithValue("@NOMBREHOJA", hoja_)
            sqlCmd.Parameters.AddWithValue("@IDMAESTRO", id_maestro_)
            sqlCmd.Parameters.AddWithValue("@DETALLE", detalle_)
            Conexion_Track.Open()
            sqlCmd.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardando Excel en DB!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabEncabezado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabEncabezado.SelectedIndexChanged
        Try
            txtArchivo.Clear()
            txtConceptoDeposito.Clear()
            cmbSheets.SelectedIndex = -1
            cmbBanco.SelectedIndex = -1
            cmbCuentaBancaria.SelectedIndex = -1
            CancelarEdicion()
            Dim tblMaster As DataTable
            Dim string_sql_ As String
            dgvAutorizaciones.DataSource = Nothing
            string_sql_ = "SELECT ID_MAESTRO AS CORRELATIVO, NOMBREARCHIVO As ARCHIVO, FECHA, HOJA FROM [dbo].[COOPERATIVA_DEPOSITOS_BECAS_MAESTRO] WHERE ID_MAESTRO <> 0"
            sqlCmd.CommandText = string_sql_
            tblMaster = jClass.obtenerDatos(sqlCmd)
            dgvEncabezado.DataSource = tblMaster
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvEncabezado_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEncabezado.CellClick
        Try            
            dgvAutorizaciones.DataSource = Nothing
            Dim Table As DataTable
            Dim row_index_ As Integer
            row_index_ = Me.dgvEncabezado.Rows(e.RowIndex).Cells(0).Value()

            Dim string_sql_det_ As String
            string_sql_det_ = "SELECT CORRELATIVO As #, CODIGO, NOMBRE, CONCEPTO, VALOR FROM COOPERATIVA_DEPOSITOS_BECAS_DETALLE WHERE ID_MAESTRO =" & row_index_.ToString() & " ORDER BY CORRELATIVO ASC"
            sqlCmd.CommandText = string_sql_det_
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                dgvAutorizaciones.DataSource = Table
            Else
                MsgBox("No Existen datos para este detalle", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnGenerateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateFile.Click
        Try
            Dim CorrBAC As Integer
            Dim MontoBAC As Double = 0
            Dim NumRegsBAC As Double = 0
            Dim DatosSocio As DataTable
            genRemesa.abrirCarpeta = False
            While TableRem.Rows.Count > 0
                TableRem.Rows.RemoveAt(0)
            End While
            
            If Me.dgvAutorizaciones.Rows.Count = 0 Then
                MsgBox("No hay datos para procesar.", MsgBoxStyle.Information, "Verifique")
                Return
            End If

            If Me.txtConceptoDeposito2.Text.Length = 0 Then
                MsgBox("Defina un concepto para los depositos.", MsgBoxStyle.Information, "Verifique")
                Return
            End If

            For Each row As DataGridViewRow In Me.dgvAutorizaciones.Rows                
                If Not IsDBNull(row.Cells(1).Value) Then
                    Sql = "SELECT (CONVERT(NVARCHAR,S.DIVISION)+CONVERT(NVARCHAR,S.SECCION)+CONVERT(NVARCHAR,S.DEPARTAMENTO)) AS [UBICACION]," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO," & vbCrLf
                    Sql &= "       S.NOMBRE_COMPLETO," & vbCrLf
                    Sql &= "       S.BANCO," & vbCrLf
                    Sql &= "	   S.CUENTA_BANCARIA," & vbCrLf
                    Sql &= "	   S.TIPO_CUENTA_BANCARIA," & vbCrLf
                    Sql &= "       S.NIT," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO_AS" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
                    Sql &= " WHERE S.CODIGO_EMPLEADO = '" & row.Cells(1).Value.ToString.PadLeft(6, "0") & "'" & vbCrLf
                    Sql &= "  AND S.COMPAÑIA = " & Compañia
                    sqlCmd.CommandText = Sql
                    DatosSocio = jClass.obtenerDatos(sqlCmd)
                    If DatosSocio.Rows.Count > 0 Then
                        If CInt(DatosSocio.Rows(0).Item("BANCO")) = Me.cmbBanco2.SelectedValue Then
                            TableRem.Rows.Add(Me.cmbBanco2.SelectedValue, _
                                              Me.cmbBanco2.Text, _
                                              DatosSocio.Rows(0).Item("TIPO_CUENTA_BANCARIA"), _
                                              DatosSocio.Rows(0).Item("NOMBRE_COMPLETO"), _
                                              row.Cells("VALOR").Value, _
                                              DatosSocio.Rows(0).Item("CUENTA_BANCARIA"), _
                                              Me.dpFechaDep2.Value, _
                                              Me.txtConceptoDeposito2.Text, _
                                              DatosSocio.Rows(0).Item("CODIGO_EMPLEADO_AS"), _
                                              DatosSocio.Rows(0).Item("NIT"), _
                                              DatosSocio.Rows(0).Item("UBICACION"), _
                                              DatosSocio.Rows(0).Item("CODIGO_EMPLEADO"))

                        End If
                    End If
                    
                End If
            Next
            'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
            If Me.cmbBanco2.SelectedValue = 3 Then
                For i As Integer = 0 To TableRem.Rows.Count - 1
                    MontoBAC += TableRem.Rows(i).Item("MONTO")
                    NumRegsBAC += 1
                Next
                CorrBAC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                CorrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", CorrBAC))
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (CorrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                genRemesa.EncabBAC = "B4978" & CorrBAC.ToString("00000") & Format(Me.dpFechaDep2.Value, "yyyyMMdd").PadLeft(33, " ") & (MontoBAC * 100).ToString().PadLeft(13, " ") & NumRegsBAC.ToString().PadLeft(5, " ")
                genRemesa.setEncab = True
            Else
                genRemesa.setEncab = False
            End If
            'For Each row As DataRow In TableRem.Rows
            For i As Integer = 0 To TableRem.Rows.Count - 1
                If i = TableRem.Rows.Count - 1 Then
                    genRemesa.abrirCarpeta = True
                End If
                genRemesa.Bloque = 1
                genRemesa.TipoTran = txtConceptoDeposito2.Text
                genRemesa.TipCta = TableRem.Rows(i).Item("CUENTA_BANCARIA")
                genRemesa.ctaSocio = TableRem.Rows(i).Item("CTASOCIO")
                genRemesa.bco = Me.cmbBanco2.SelectedValue
                genRemesa.monto = CDbl(TableRem.Rows(i).Item("MONTO"))
                genRemesa.NITSocio = TableRem.Rows(i).Item("NITSOCIO")
                genRemesa.FechaDep = Format(TableRem.Rows(i).Item("FECHA_CONTABLE"), "yyyyMMdd")
                genRemesa.ubicacion = TableRem.Rows(i).Item("UBICACION")
                genRemesa.socio = TableRem.Rows(i).Item("NOMBRE_COMPLETO")
                genRemesa.recibirParametros(Compañia, TableRem.Rows(i).Item("CODBANCO").ToString, TableRem.Rows(i).Item("CTASOCIO"), "0", TableRem.Rows(i).Item("CODIGO").ToString.PadLeft(6, "0"), TableRem.Rows(i).Item("CODIGOBUXIS").ToString, "BECAS")
                genRemesa.setEncab = False
            Next
            MostrarReporte()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtConcepto_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.Validated
        If txtConcepto.Text.Length > 0 Then
            txtConcepto.Enabled = False
            Me.btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub txtCodigo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Validated
        If txtCodigo.Text.Length > 0 Then
            Sql = "SELECT S.NOMBRE_COMPLETO " & vbCrLf
            Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
            Sql &= " WHERE S.CODIGO_EMPLEADO = '" & txtCodigo.Text & "' OR S.CODIGO_EMPLEADO_AS = '" & txtCodigo.Text & "'" & vbCrLf
            Sql &= "  AND S.COMPAÑIA = " & Compañia
            sqlCmd.CommandText = Sql
            Dim dato_socio As New DataTable
            dato_socio = jClass.obtenerDatos(sqlCmd)

            If dato_socio.Rows.Count > 0 Then                
                Me.txtNombre.Text = dato_socio.Rows(0).Item("NOMBRE_COMPLETO").ToString()
                Me.txtValor.Focus()
            Else
                MsgBox("Còdigo no valido...", MsgBoxStyle.Exclamation)
            End If
        End If        
    End Sub

    Private Sub tbpAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpAgregar.Click
        Me.btnDeleteRow.Enabled = False
        Me.txtConcepto.Focus()
    End Sub

    Private Sub btnFindSocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSocio.Click
        Try
            Dim Frm_Busqueda As New Busquedas_empleados_avicola
            Frm_Busqueda.Compañia_Value = Compañia
            Dim dato_socio As New DataTable

            Frm_Busqueda.ShowDialog()

            Sql = "SELECT S.NOMBRE_COMPLETO " & vbCrLf
            Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
            Sql &= " WHERE S.CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "'" & vbCrLf
            Sql &= "  AND S.COMPAÑIA = " & Compañia
            sqlCmd.CommandText = Sql
            dato_socio = jClass.obtenerDatos(sqlCmd)

            If dato_socio.Rows.Count > 0 Then
                Me.txtCodigo.Text = ParamcodigoBux
                Me.txtNombre.Text = dato_socio.Rows(0).Item("NOMBRE_COMPLETO").ToString()
                Me.txtCodigo.Focus()
            Else
                MsgBox("Socio no existe...", MsgBoxStyle.Exclamation)
            End If
            ParamcodigoBux = 0
            ParamcodigoAs = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        TableDetSocio.Clear()        
        Me.btnFind.Enabled = False
        Me.btnNuevo.Enabled = False
        Me.btnCancelar.Enabled = True
        Me.txtConcepto.Enabled = True
        Me.btnNewRow.Enabled = True
        dgvAutorizaciones.DataSource = Nothing
        LimpiarEncabezado()
        LimpiarDatosSocio()
        correla_ = 0
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        CancelarEdicion()
    End Sub

    Private Sub CancelarEdicion()
        Me.btnNuevo.Enabled = True
        Me.btnCancelar.Enabled = False
        Me.btnGuardar.Enabled = False
        Me.btnFind.Enabled = True
        Me.txtConcepto.Enabled = False
        Me.txtCodigo.Enabled = False
        Me.txtValor.Enabled = False
        Me.btnFindSocio.Enabled = False
        accion_ = "insert"
        id_maestro_ = 0
        dgvAutorizaciones.DataSource = Nothing
        LimpiarEncabezado()
        LimpiarDatosSocio()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If TableDetSocio.Rows.Count > 0 Then
                cooperativaDepositosBecas(txtConcepto.Text & "- " & DateTime.Now.ToShortDateString & " " & DateTime.Now.ToShortTimeString, txtConcepto.Text, dpFechaDep3.Value, "REGISTRO MANUAL", TableDetSocio)
                Me.btnNuevo.Enabled = True
                Me.btnCancelar.Enabled = False
                Me.btnGuardar.Enabled = False
                Me.btnFind.Enabled = True
                Me.txtConcepto.Enabled = False
                Me.txtCodigo.Enabled = False
                Me.txtValor.Enabled = False
                Me.btnFindSocio.Enabled = False
                accion_ = "insert"
                id_maestro_ = 0
                LimpiarEncabezado()
                LimpiarDatosSocio()
                TableDetSocio.Clear()                
            Else
                MsgBox("No ha agregado socios para guardar...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarEncabezado()
        Me.txtConcepto.Clear()        
        Me.txtConcepto.Focus()
    End Sub

    Private Sub LimpiarDatosSocio()
        Me.txtCodigo.Clear()
        Me.txtNombre.Clear()
        Me.txtValor.Text = "0.00"
    End Sub

    Private Sub CrearTablaDetalle()
        TableDetSocio.Columns.Add("#", Type.GetType("System.Int32"))
        TableDetSocio.Columns.Add("CODIGO", Type.GetType("System.String"))
        TableDetSocio.Columns.Add("NOMBRE", Type.GetType("System.String"))
        TableDetSocio.Columns.Add("CONCEPTO", Type.GetType("System.String"))
        TableDetSocio.Columns.Add("VALOR", Type.GetType("System.Double"))
    End Sub

    Private Sub btnSaveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRow.Click
        Try
            If txtCodigo.Text.Length > 0 And CInt(txtValor.Text) > 0 Then
                correla_ = correla_ + 1
                TableDetSocio.Rows.Add(correla_, Me.txtCodigo.Text, Me.txtNombre.Text, Me.txtConcepto.Text, Me.txtValor.Text)
                dgvAutorizaciones.DataSource = TableDetSocio

                Me.txtCodigo.Enabled = False
                Me.txtValor.Enabled = False
                Me.btnFindSocio.Enabled = False

                Me.btnNewRow.Enabled = True
                Me.btnSaveRow.Enabled = False
                Me.btnGuardar.Enabled = True
                Me.txtCodigo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnNewRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRow.Click
        LimpiarDatosSocio()
        Me.txtCodigo.Enabled = True
        Me.txtValor.Enabled = True
        Me.btnFindSocio.Enabled = True
        Me.btnNewRow.Enabled = False
        Me.btnSaveRow.Enabled = True
    End Sub

    Private Sub dgvAutorizaciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAutorizaciones.CellClick
        Me.txtCodigo.Text = Me.dgvAutorizaciones.CurrentRow.Cells.Item(1).Value
        Me.txtNombre.Text = Me.dgvAutorizaciones.CurrentRow.Cells.Item(2).Value
        Me.txtValor.Text = Me.dgvAutorizaciones.CurrentRow.Cells.Item(4).Value
        index_row_ = Me.dgvAutorizaciones.CurrentRow.Index
        Me.btnDeleteRow.Enabled = True
    End Sub

    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRow.Click
        Me.btnDeleteRow.Enabled = False

        TableDetSocio.Rows.RemoveAt(index_row_)
        dgvAutorizaciones.DataSource = TableDetSocio
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        correla_ = 0
        Dim frm_busqueda_ As New FrmCooperativaDepositosBecasBuscar
        frm_busqueda_.ShowDialog()

        Try
            If DepositosBecasId <> 0 Then
                Dim TableEncabezadoSocio As New DataTable("SociosEncabezado")
                Dim sql_string_ As String
                sql_string_ = "SELECT ID_MAESTRO,NOMBREARCHIVO,CONCEPTO,FECHA,HOJA " & vbCrLf
                sql_string_ &= " FROM COOPERATIVA_DEPOSITOS_BECAS_MAESTRO " & vbCrLf
                sql_string_ &= " WHERE ID_MAESTRO = " & DepositosBecasId
                sqlCmd.CommandText = sql_string_
                TableEncabezadoSocio = jClass.obtenerDatos(sqlCmd)

                sql_string_ = "SELECT CORRELATIVO As #, ISNULL(CODIGO, 0) CODIGO, ISNULL(NOMBRE, '') NOMBRE, ISNULL(CONCEPTO, '') CONCEPTO, VALOR " & vbCrLf
                sql_string_ &= " FROM COOPERATIVA_DEPOSITOS_BECAS_DETALLE " & vbCrLf
                sql_string_ &= " WHERE CORRELATIVO IS NOT NULL AND ID_MAESTRO =" & DepositosBecasId & "ORDER BY CORRELATIVO"

                sqlCmd.CommandText = sql_string_
                TableDetSocio = jClass.obtenerDatos(sqlCmd)
                Dim tot_detalle_ As Integer
                tot_detalle_ = TableDetSocio.Rows.Count

                If TableEncabezadoSocio.Rows.Count > 0 And tot_detalle_ > 0 Then
                    correla_ = TableDetSocio.Rows(tot_detalle_ - 1).Item("#")
                    id_maestro_ = TableEncabezadoSocio.Rows(0).Item("ID_MAESTRO")

                    Me.txtConcepto.Text = TableEncabezadoSocio.Rows(0).Item("CONCEPTO")
                    Me.dpFechaDep3.Text = TableEncabezadoSocio.Rows(0).Item("FECHA")
                    dgvAutorizaciones.DataSource = TableDetSocio

                    Me.btnFindSocio.Enabled = True
                    Me.btnNewRow.Enabled = True
                    Me.btnSaveRow.Enabled = False
                    Me.btnNuevo.Enabled = False
                    Me.btnCancelar.Enabled = True
                    Me.btnGuardar.Enabled = False
                    Me.btnFindSocio.Enabled = False
                    accion_ = "update"
                    Me.btnNewRow.Focus()
                Else
                    MsgBox("Socio no existe...", MsgBoxStyle.Exclamation)
                End If

                DepositosBecasId = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCargar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar2.Click
        If rbAstas.Checked = False And rbAtaf.Checked = False Then
            MsgBox("No ha seleccionado la asociaciòn...", MsgBoxStyle.Information, "Verifique")
            Return
        End If

        dgvAutorizaciones.DataSource = Nothing
        Dim TDetalle As New DataTable("SociosDetalle")
        Dim Sql As String
        Sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        Sql &= " @BANDERA = 14"
        Sql &= ", @FECHA1 = '" & Format(Me.txtDesde.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        Sql &= ", @FECHA2 = '" & Format(Me.txtHasta.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        Sql &= ", @PARAMETRO = ''"
        Sql &= ", @NUMERO_REPARTO = " & nudReparto.Value.ToString()
        If rbAstas.Checked = True Then
            Sql &= ", @ASOCIACION = 1"
        End If
        If rbAtaf.Checked = True Then
            Sql &= ", @ASOCIACION = 2"
        End If
        Sql &= ", @COMPAÑIA = " & Compañia
        sqlCmd.CommandText = Sql
        TDetalle = jClass.obtenerDatos(sqlCmd)
        dgvAutorizaciones.DataSource = TDetalle
        Dim SumObj As Object
        SumObj = TDetalle.Compute("SUM(VALOR)", "1=1")
        txtTotal.Text = Format(SumObj, "#,###.00")

    End Sub

    Private Sub btnGenerar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar2.Click
        Try
            Dim CorrBAC As Integer
            Dim MontoBAC As Double = 0
            Dim NumRegsBAC As Double = 0
            Dim DatosSocio As DataTable
            genRemesa.abrirCarpeta = False
            While TableRem.Rows.Count > 0
                TableRem.Rows.RemoveAt(0)
            End While
            
            If Me.dgvAutorizaciones.Rows.Count = 0 Then
                MsgBox("No hay datos para procesar." & vbCrLf & "Cargue los datos de la hoja " & Me.cmbSheets.Text & ".", MsgBoxStyle.Information, "Archivo EXCEL")
                Return
            End If

            If Me.txtConceptoDeposito3.Text.Length = 0 Then
                MsgBox("Defina un concepto para los depositos.", MsgBoxStyle.Information, "Verifique")
                Return
            End If

            For Each row As DataGridViewRow In Me.dgvAutorizaciones.Rows
                If Not IsDBNull(row.Cells(1).Value) Then
                    Sql = "SELECT (CONVERT(NVARCHAR,S.DIVISION)+CONVERT(NVARCHAR,S.SECCION)+CONVERT(NVARCHAR,S.DEPARTAMENTO)) AS [UBICACION]," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO," & vbCrLf
                    Sql &= "       S.NOMBRE_COMPLETO," & vbCrLf
                    Sql &= "       S.BANCO," & vbCrLf
                    Sql &= "	   S.CUENTA_BANCARIA," & vbCrLf
                    Sql &= "	   S.TIPO_CUENTA_BANCARIA," & vbCrLf
                    Sql &= "       S.NIT," & vbCrLf
                    Sql &= "       S.CODIGO_EMPLEADO_AS" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
                    Sql &= " WHERE S.CODIGO_EMPLEADO = " & row.Cells(1).Value.ToString & vbCrLf
                    Sql &= "  AND S.COMPAÑIA = " & Compañia
                    sqlCmd.CommandText = Sql
                    'CInt(jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & row.Cells(1).Value.ToString)), _
                    DatosSocio = jClass.obtenerDatos(sqlCmd)
                    If CInt(DatosSocio.Rows(0).Item("BANCO")) = Me.cmbBanco3.SelectedValue Then
                        If DatosSocio.Rows(0).Item("CUENTA_BANCARIA").ToString().Length > 0 Then
                            TableRem.Rows.Add(Me.cmbBanco3.SelectedValue, _
                                              Me.cmbBanco3.Text, _
                                              Me.cmbCuentaBanco3.SelectedValue, _
                                              DatosSocio.Rows(0).Item("NOMBRE_COMPLETO"), _
                                              row.Cells("VALOR").Value, _
                                              DatosSocio.Rows(0).Item("CUENTA_BANCARIA"), _
                                              Me.dpFechaDep4.Value, _
                                              txtConceptoDeposito.Text, _
                                              DatosSocio.Rows(0).Item("CODIGO_EMPLEADO_AS"), _
                                              DatosSocio.Rows(0).Item("NIT"), _
                                              DatosSocio.Rows(0).Item("UBICACION"), _
                                              DatosSocio.Rows(0).Item("CODIGO_EMPLEADO"))
                        End If
                    End If
                End If
            Next
            'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
            If Me.cmbBanco3.SelectedValue = 3 Then
                For i As Integer = 0 To TableRem.Rows.Count - 1
                    MontoBAC += TableRem.Rows(i).Item("MONTO")
                    NumRegsBAC += 1
                Next
                MontoBAC = Math.Round(MontoBAC, 2)
                CorrBAC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                CorrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", CorrBAC))
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (CorrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                genRemesa.EncabBAC = "B4978" & CorrBAC.ToString("00000") & Format(Me.dpFechaDep.Value, "yyyyMMdd").PadLeft(33, " ") & (MontoBAC * 100).ToString().PadLeft(13, " ") & NumRegsBAC.ToString().PadLeft(5, " ")
                genRemesa.setEncab = True
            Else
                genRemesa.setEncab = False
            End If
            'For Each row As DataRow In TableRem.Rows
            For i As Integer = 0 To TableRem.Rows.Count - 1
                If i = TableRem.Rows.Count - 1 Then
                    genRemesa.abrirCarpeta = True
                End If
                genRemesa.Bloque = 1
                genRemesa.TipoTran = txtConceptoDeposito3.Text '"DIVIDENDOS"
                genRemesa.ctaSocio = TableRem.Rows(i).Item("CTASOCIO")
                genRemesa.bco = Me.cmbBanco3.SelectedValue
                genRemesa.monto = CDbl(TableRem.Rows(i).Item("MONTO"))
                genRemesa.NITSocio = TableRem.Rows(i).Item("NITSOCIO")
                genRemesa.FechaDep = Format(TableRem.Rows(i).Item("FECHA_CONTABLE"), "yyyyMMdd")
                genRemesa.ubicacion = TableRem.Rows(i).Item("UBICACION")
                genRemesa.socio = TableRem.Rows(i).Item("NOMBRE_COMPLETO")
                genRemesa.recibirParametros(Compañia, TableRem.Rows(i).Item("CODBANCO").ToString, TableRem.Rows(i).Item("CTASOCIO"), "0", TableRem.Rows(i).Item("CODIGO").ToString.PadLeft(6, "0"), TableRem.Rows(i).Item("CODIGOBUXIS").ToString, "BECAS")
                genRemesa.setEncab = False
            Next
            MostrarReporte()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbBanco3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco3.SelectedIndexChanged
        If Not iniciando Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco3.SelectedValue, 2, Me.cmbCuentaBanco3)
        End If
    End Sub

    Private Sub cmbBanco2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco2.SelectedIndexChanged
        If Not iniciando Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBanco2.SelectedValue, 2, Me.cmbCuentaBanco2)
        End If
    End Sub
End Class
