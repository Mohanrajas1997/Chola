<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegenerateDepositSlip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDepositslipList = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpcycledate = New System.Windows.Forms.DateTimePicker()
        Me.lblCycledate = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.txtDepositslipno = New System.Windows.Forms.TextBox()
        Me.lblDepositslipno = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblTotRec = New System.Windows.Forms.Label()
        CType(Me.dgvDepositslipList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDepositslipList
        '
        Me.dgvDepositslipList.AllowUserToAddRows = False
        Me.dgvDepositslipList.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvDepositslipList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDepositslipList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDepositslipList.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDepositslipList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDepositslipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepositslipList.GridColor = System.Drawing.SystemColors.Desktop
        Me.dgvDepositslipList.Location = New System.Drawing.Point(3, 3)
        Me.dgvDepositslipList.Name = "dgvDepositslipList"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDepositslipList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDepositslipList.RowHeadersVisible = False
        Me.dgvDepositslipList.Size = New System.Drawing.Size(240, 102)
        Me.dgvDepositslipList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpcycledate)
        Me.Panel1.Controls.Add(Me.lblCycledate)
        Me.Panel1.Controls.Add(Me.lblProduct)
        Me.Panel1.Controls.Add(Me.cboproduct)
        Me.Panel1.Controls.Add(Me.txtDepositslipno)
        Me.Panel1.Controls.Add(Me.lblDepositslipno)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.btnclear)
        Me.Panel1.Controls.Add(Me.btnrefresh)
        Me.Panel1.Location = New System.Drawing.Point(9, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(625, 69)
        Me.Panel1.TabIndex = 36
        '
        'dtpcycledate
        '
        Me.dtpcycledate.CustomFormat = "dd-MM-yyyy"
        Me.dtpcycledate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpcycledate.Location = New System.Drawing.Point(75, 6)
        Me.dtpcycledate.Name = "dtpcycledate"
        Me.dtpcycledate.Size = New System.Drawing.Size(121, 20)
        Me.dtpcycledate.TabIndex = 30
        '
        'lblCycledate
        '
        Me.lblCycledate.AutoSize = True
        Me.lblCycledate.Location = New System.Drawing.Point(10, 9)
        Me.lblCycledate.Name = "lblCycledate"
        Me.lblCycledate.Size = New System.Drawing.Size(59, 13)
        Me.lblCycledate.TabIndex = 31
        Me.lblCycledate.Text = "Cycle Date"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(425, 9)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 32
        Me.lblProduct.Text = "Product"
        '
        'cboproduct
        '
        Me.cboproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(490, 6)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(121, 21)
        Me.cboproduct.TabIndex = 33
        '
        'txtDepositslipno
        '
        Me.txtDepositslipno.Location = New System.Drawing.Point(289, 6)
        Me.txtDepositslipno.MaxLength = 5
        Me.txtDepositslipno.Name = "txtDepositslipno"
        Me.txtDepositslipno.Size = New System.Drawing.Size(121, 20)
        Me.txtDepositslipno.TabIndex = 0
        '
        'lblDepositslipno
        '
        Me.lblDepositslipno.AutoSize = True
        Me.lblDepositslipno.Location = New System.Drawing.Point(206, 9)
        Me.lblDepositslipno.Name = "lblDepositslipno"
        Me.lblDepositslipno.Size = New System.Drawing.Size(77, 13)
        Me.lblDepositslipno.TabIndex = 15
        Me.lblDepositslipno.Text = "DepositSlip No"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(536, 37)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(455, 37)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(75, 23)
        Me.btnclear.TabIndex = 4
        Me.btnclear.Text = "Clear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(374, 37)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 3
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.dgvDepositslipList)
        Me.pnlMain.Location = New System.Drawing.Point(9, 99)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(625, 117)
        Me.pnlMain.TabIndex = 37
        '
        'lblTotRec
        '
        Me.lblTotRec.AutoSize = True
        Me.lblTotRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRec.ForeColor = System.Drawing.Color.Green
        Me.lblTotRec.Location = New System.Drawing.Point(12, 226)
        Me.lblTotRec.Name = "lblTotRec"
        Me.lblTotRec.Size = New System.Drawing.Size(87, 13)
        Me.lblTotRec.TabIndex = 42
        Me.lblTotRec.Text = "Total Records"
        '
        'frmRegenerateDepositSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(652, 249)
        Me.Controls.Add(Me.lblTotRec)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "frmRegenerateDepositSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regenerate Deposit Slip"
        CType(Me.dgvDepositslipList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDepositslipList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDepositslipno As System.Windows.Forms.TextBox
    Friend WithEvents lblDepositslipno As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents dtpcycledate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCycledate As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotRec As System.Windows.Forms.Label
End Class
