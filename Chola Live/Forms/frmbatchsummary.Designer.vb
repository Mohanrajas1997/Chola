﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbatchsummary
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtchqno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtagreementno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.dgvsummary = New System.Windows.Forms.DataGridView()
        Me.dtpcycledate = New System.Windows.Forms.DateTimePicker()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltotrec = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbobatchno = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        CType(Me.dgvsummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtchqno
        '
        Me.txtchqno.Location = New System.Drawing.Point(559, 11)
        Me.txtchqno.Name = "txtchqno"
        Me.txtchqno.Size = New System.Drawing.Size(98, 20)
        Me.txtchqno.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(502, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Chq No#"
        '
        'txtagreementno
        '
        Me.txtagreementno.Location = New System.Drawing.Point(397, 9)
        Me.txtagreementno.Name = "txtagreementno"
        Me.txtagreementno.Size = New System.Drawing.Size(98, 20)
        Me.txtagreementno.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(313, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Agreement No#"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(627, 37)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 6
        Me.btnclose.Text = "E&xit"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(546, 37)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(465, 37)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(75, 23)
        Me.btnclear.TabIndex = 4
        Me.btnclear.Text = "C&lear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(386, 37)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 3
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'dgvsummary
        '
        Me.dgvsummary.AllowUserToAddRows = False
        Me.dgvsummary.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvsummary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvsummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvsummary.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvsummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsummary.GridColor = System.Drawing.SystemColors.Desktop
        Me.dgvsummary.Location = New System.Drawing.Point(3, 3)
        Me.dgvsummary.Name = "dgvsummary"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsummary.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvsummary.RowHeadersVisible = False
        Me.dgvsummary.Size = New System.Drawing.Size(240, 150)
        Me.dgvsummary.TabIndex = 0
        '
        'dtpcycledate
        '
        Me.dtpcycledate.CustomFormat = "dd-MM-yyyy"
        Me.dtpcycledate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpcycledate.Location = New System.Drawing.Point(63, 10)
        Me.dtpcycledate.Name = "dtpcycledate"
        Me.dtpcycledate.Size = New System.Drawing.Size(80, 20)
        Me.dtpcycledate.TabIndex = 0
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.dgvsummary)
        Me.pnlMain.Location = New System.Drawing.Point(6, 93)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1128, 648)
        Me.pnlMain.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cycle Date"
        '
        'lbltotrec
        '
        Me.lbltotrec.AutoSize = True
        Me.lbltotrec.ForeColor = System.Drawing.Color.Green
        Me.lbltotrec.Location = New System.Drawing.Point(850, 20)
        Me.lbltotrec.Name = "lbltotrec"
        Me.lbltotrec.Size = New System.Drawing.Size(0, 13)
        Me.lbltotrec.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbostatus)
        Me.Panel1.Controls.Add(Me.cbobatchno)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboproduct)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtchqno)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtagreementno)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.btnclear)
        Me.Panel1.Controls.Add(Me.btnrefresh)
        Me.Panel1.Controls.Add(Me.dtpcycledate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(6, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 69)
        Me.Panel1.TabIndex = 34
        '
        'cbobatchno
        '
        Me.cbobatchno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbobatchno.FormattingEnabled = True
        Me.cbobatchno.Location = New System.Drawing.Point(63, 36)
        Me.cbobatchno.Name = "cbobatchno"
        Me.cbobatchno.Size = New System.Drawing.Size(121, 21)
        Me.cbobatchno.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Batch No"
        '
        'cboproduct
        '
        Me.cboproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(190, 9)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(121, 21)
        Me.cboproduct.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Product"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(193, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Entry Status"
        '
        'cbostatus
        '
        Me.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"", "Completed", "Not Completed"})
        Me.cbostatus.Location = New System.Drawing.Point(257, 39)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(109, 21)
        Me.cbostatus.TabIndex = 33
        '
        'frmbatchsummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(724, 333)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lbltotrec)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmbatchsummary"
        Me.Text = "Batch summary"
        CType(Me.dgvsummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtchqno As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtagreementno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents dgvsummary As System.Windows.Forms.DataGridView
    Friend WithEvents dtpcycledate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltotrec As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbobatchno As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbostatus As System.Windows.Forms.ComboBox
End Class
