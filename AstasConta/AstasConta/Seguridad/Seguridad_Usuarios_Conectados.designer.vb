<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Usuarios_Conectados
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvUsuariosConectados = New System.Windows.Forms.DataGridView
        Me.codusuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombreusuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.horaconexion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.apppath = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.appversion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.instancia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.txtMensaje = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMsjAsunto = New System.Windows.Forms.TextBox
        Me.btnOut = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUsrMsj = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvUsuariosConectados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUsuariosConectados
        '
        Me.dgvUsuariosConectados.AllowUserToAddRows = False
        Me.dgvUsuariosConectados.AllowUserToDeleteRows = False
        Me.dgvUsuariosConectados.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvUsuariosConectados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUsuariosConectados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUsuariosConectados.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvUsuariosConectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvUsuariosConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuariosConectados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codusuario, Me.nombreusuario, Me.horaconexion, Me.Company, Me.pc, Me.ip, Me.apppath, Me.appversion, Me.instancia})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUsuariosConectados.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvUsuariosConectados.Location = New System.Drawing.Point(0, 0)
        Me.dgvUsuariosConectados.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvUsuariosConectados.Name = "dgvUsuariosConectados"
        Me.dgvUsuariosConectados.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUsuariosConectados.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvUsuariosConectados.RowHeadersWidth = 30
        Me.dgvUsuariosConectados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuariosConectados.Size = New System.Drawing.Size(961, 335)
        Me.dgvUsuariosConectados.TabIndex = 0
        '
        'codusuario
        '
        Me.codusuario.DataPropertyName = "USUARIO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codusuario.DefaultCellStyle = DataGridViewCellStyle2
        Me.codusuario.HeaderText = "Usuario"
        Me.codusuario.Name = "codusuario"
        Me.codusuario.ReadOnly = True
        Me.codusuario.Width = 80
        '
        'nombreusuario
        '
        Me.nombreusuario.DataPropertyName = "NOMBRE_USUARIO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.nombreusuario.DefaultCellStyle = DataGridViewCellStyle3
        Me.nombreusuario.HeaderText = "Nombre Usuario"
        Me.nombreusuario.Name = "nombreusuario"
        Me.nombreusuario.ReadOnly = True
        Me.nombreusuario.Width = 200
        '
        'horaconexion
        '
        Me.horaconexion.DataPropertyName = "HORA_CONEXION"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "G"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.horaconexion.DefaultCellStyle = DataGridViewCellStyle4
        Me.horaconexion.HeaderText = "Hora Conexion"
        Me.horaconexion.Name = "horaconexion"
        Me.horaconexion.ReadOnly = True
        Me.horaconexion.Width = 140
        '
        'Company
        '
        Me.Company.DataPropertyName = "NOMBRE_COMPAÑIA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Company.DefaultCellStyle = DataGridViewCellStyle5
        Me.Company.HeaderText = "Compañia"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        Me.Company.Width = 330
        '
        'pc
        '
        Me.pc.DataPropertyName = "HOST"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.pc.DefaultCellStyle = DataGridViewCellStyle6
        Me.pc.HeaderText = "PC"
        Me.pc.Name = "pc"
        Me.pc.ReadOnly = True
        Me.pc.Width = 80
        '
        'ip
        '
        Me.ip.DataPropertyName = "IPADDRESS"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ip.DefaultCellStyle = DataGridViewCellStyle7
        Me.ip.HeaderText = "IP"
        Me.ip.Name = "ip"
        Me.ip.ReadOnly = True
        Me.ip.Width = 80
        '
        'apppath
        '
        Me.apppath.DataPropertyName = "APP_PATH"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.apppath.DefaultCellStyle = DataGridViewCellStyle8
        Me.apppath.HeaderText = "Ruta EXE"
        Me.apppath.Name = "apppath"
        Me.apppath.ReadOnly = True
        Me.apppath.Width = 200
        '
        'appversion
        '
        Me.appversion.DataPropertyName = "APP_VERSION"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.appversion.DefaultCellStyle = DataGridViewCellStyle9
        Me.appversion.HeaderText = "Versión Aplicación"
        Me.appversion.Name = "appversion"
        Me.appversion.ReadOnly = True
        '
        'instancia
        '
        Me.instancia.DataPropertyName = "INSTANCIA"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.instancia.DefaultCellStyle = DataGridViewCellStyle10
        Me.instancia.HeaderText = "Instancia"
        Me.instancia.Name = "instancia"
        Me.instancia.ReadOnly = True
        Me.instancia.Width = 60
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(306, 143)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(66, 38)
        Me.btnEnviar.TabIndex = 9
        Me.btnEnviar.Text = "&Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(6, 143)
        Me.txtMensaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(294, 115)
        Me.txtMensaje.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMsjAsunto)
        Me.GroupBox1.Controls.Add(Me.btnOut)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtUsrMsj)
        Me.GroupBox1.Controls.Add(Me.txtMensaje)
        Me.GroupBox1.Controls.Add(Me.btnEnviar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 343)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(961, 268)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enviar Mensaje a Usuario"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(875, 14)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 38)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "&Refrescar"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Asunto:"
        '
        'txtMsjAsunto
        '
        Me.txtMsjAsunto.Location = New System.Drawing.Point(6, 95)
        Me.txtMsjAsunto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMsjAsunto.Name = "txtMsjAsunto"
        Me.txtMsjAsunto.Size = New System.Drawing.Size(294, 20)
        Me.txtMsjAsunto.TabIndex = 7
        '
        'btnOut
        '
        Me.btnOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOut.Location = New System.Drawing.Point(780, 14)
        Me.btnOut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOut.Name = "btnOut"
        Me.btnOut.Size = New System.Drawing.Size(89, 38)
        Me.btnOut.TabIndex = 6
        Me.btnOut.Text = "&Desconectar"
        Me.btnOut.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mensaje:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Enviar a:"
        '
        'txtUsrMsj
        '
        Me.txtUsrMsj.Location = New System.Drawing.Point(6, 44)
        Me.txtUsrMsj.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUsrMsj.Name = "txtUsrMsj"
        Me.txtUsrMsj.ReadOnly = True
        Me.txtUsrMsj.Size = New System.Drawing.Size(294, 20)
        Me.txtUsrMsj.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'Seguridad_Usuarios_Conectados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 614)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvUsuariosConectados)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Seguridad_Usuarios_Conectados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad - Usuarios Conectados"
        CType(Me.dgvUsuariosConectados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvUsuariosConectados As System.Windows.Forms.DataGridView
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsrMsj As System.Windows.Forms.TextBox
    Friend WithEvents btnOut As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMsjAsunto As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents codusuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombreusuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents horaconexion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents apppath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents appversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents instancia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
