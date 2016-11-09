<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_cooperativa_socio_hoja_datos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_cooperativa_socio_hoja_datos))
        Me.crvHojaDatosSocio = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtCodSocio = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscarSoc = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodBuxis = New System.Windows.Forms.TextBox
        Me.btnLimpiarCampos = New System.Windows.Forms.Button
        Me.lblBloq = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'crvHojaDatosSocio
        '
        Me.crvHojaDatosSocio.ActiveViewIndex = -1
        Me.crvHojaDatosSocio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvHojaDatosSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvHojaDatosSocio.DisplayGroupTree = False
        Me.crvHojaDatosSocio.Location = New System.Drawing.Point(0, 36)
        Me.crvHojaDatosSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvHojaDatosSocio.Name = "crvHojaDatosSocio"
        Me.crvHojaDatosSocio.SelectionFormula = ""
        Me.crvHojaDatosSocio.ShowGotoPageButton = False
        Me.crvHojaDatosSocio.ShowGroupTreeButton = False
        Me.crvHojaDatosSocio.ShowRefreshButton = False
        Me.crvHojaDatosSocio.Size = New System.Drawing.Size(802, 488)
        Me.crvHojaDatosSocio.TabIndex = 0
        Me.crvHojaDatosSocio.ViewTimeSelectionFormula = ""
        '
        'txtCodSocio
        '
        Me.txtCodSocio.Location = New System.Drawing.Point(253, 8)
        Me.txtCodSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodSocio.Name = "txtCodSocio"
        Me.txtCodSocio.Size = New System.Drawing.Size(78, 22)
        Me.txtCodSocio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(187, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Codigo AS:"
        '
        'BtnBuscarSoc
        '
        Me.BtnBuscarSoc.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarSoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSoc.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSoc.Image = CType(resources.GetObject("BtnBuscarSoc.Image"), System.Drawing.Image)
        Me.BtnBuscarSoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSoc.Location = New System.Drawing.Point(336, 7)
        Me.BtnBuscarSoc.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.BtnBuscarSoc.Name = "BtnBuscarSoc"
        Me.BtnBuscarSoc.Size = New System.Drawing.Size(24, 25)
        Me.BtnBuscarSoc.TabIndex = 23
        Me.BtnBuscarSoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSoc.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Codigo Buxis:"
        '
        'txtCodBuxis
        '
        Me.txtCodBuxis.Location = New System.Drawing.Point(78, 8)
        Me.txtCodBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodBuxis.Name = "txtCodBuxis"
        Me.txtCodBuxis.Size = New System.Drawing.Size(78, 22)
        Me.txtCodBuxis.TabIndex = 0
        '
        'btnLimpiarCampos
        '
        Me.btnLimpiarCampos.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiarCampos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarCampos.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiarCampos.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnLimpiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarCampos.Location = New System.Drawing.Point(366, 7)
        Me.btnLimpiarCampos.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnLimpiarCampos.Name = "btnLimpiarCampos"
        Me.btnLimpiarCampos.Size = New System.Drawing.Size(24, 25)
        Me.btnLimpiarCampos.TabIndex = 26
        Me.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLimpiarCampos.UseVisualStyleBackColor = False
        '
        'lblBloq
        '
        Me.lblBloq.AutoSize = True
        Me.lblBloq.BackColor = System.Drawing.Color.Transparent
        Me.lblBloq.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloq.ForeColor = System.Drawing.Color.Red
        Me.lblBloq.Location = New System.Drawing.Point(397, 8)
        Me.lblBloq.Name = "lblBloq"
        Me.lblBloq.Size = New System.Drawing.Size(477, 19)
        Me.lblBloq.TabIndex = 27
        Me.lblBloq.Text = "CREDITO BLOQUEADO. CONSULTAR A GERENCIA"
        Me.lblBloq.Visible = False
        '
        'frm_reporte_cooperativa_socio_hoja_datos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 524)
        Me.Controls.Add(Me.lblBloq)
        Me.Controls.Add(Me.btnLimpiarCampos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodBuxis)
        Me.Controls.Add(Me.BtnBuscarSoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodSocio)
        Me.Controls.Add(Me.crvHojaDatosSocio)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_reporte_cooperativa_socio_hoja_datos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Cooperativa Socio Hoja de Datos Para Autorizaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crvHojaDatosSocio As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtCodSocio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSoc As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodBuxis As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiarCampos As System.Windows.Forms.Button
    Friend WithEvents lblBloq As System.Windows.Forms.Label
End Class
