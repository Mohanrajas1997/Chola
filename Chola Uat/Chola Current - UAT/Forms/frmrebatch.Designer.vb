﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrebatch
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
        Me.dgvsummary = New System.Windows.Forms.DataGridView()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lbltotrec = New System.Windows.Forms.Label()
        Me.btnbatchtally = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.dtpcycledate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvsummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvsummary
        '
        Me.dgvsummary.AllowUserToAddRows = False
        Me.dgvsummary.AllowUserToDeleteRows = False
        Me.dgvsummary.AllowUserToResizeColumns = False
        Me.dgvsummary.AllowUserToResizeRows = False
        Me.dgvsummary.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvsummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsummary.GridColor = System.Drawing.SystemColors.Desktop
        Me.dgvsummary.Location = New System.Drawing.Point(3, 3)
        Me.dgvsummary.Name = "dgvsummary"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsummary.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvsummary.RowHeadersVisible = False
        Me.dgvsummary.Size = New System.Drawing.Size(240, 150)
        Me.dgvsummary.TabIndex = 0
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.dgvsummary)
        Me.pnlMain.Location = New System.Drawing.Point(8, 95)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1128, 648)
        Me.pnlMain.TabIndex = 31
        '
        'lbltotrec
        '
        Me.lbltotrec.AutoSize = True
        Me.lbltotrec.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotrec.ForeColor = System.Drawing.Color.Green
        Me.lbltotrec.Location = New System.Drawing.Point(761, 22)
        Me.lbltotrec.Name = "lbltotrec"
        Me.lbltotrec.Size = New System.Drawing.Size(0, 25)
        Me.lbltotrec.TabIndex = 33
        '
        'btnbatchtally
        '
        Me.btnbatchtally.Location = New System.Drawing.Point(465, 37)
        Me.btnbatchtally.Name = "btnbatchtally"
        Me.btnbatchtally.Size = New System.Drawing.Size(75, 23)
        Me.btnbatchtally.TabIndex = 32
        Me.btnbatchtally.Text = "Re&batch"
        Me.btnbatchtally.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnbatchtally)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboproduct)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.btnclear)
        Me.Panel1.Controls.Add(Me.btnrefresh)
        Me.Panel1.Controls.Add(Me.dtpcycledate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(8, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 69)
        Me.Panel1.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(199, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Product"
        '
        'cboproduct
        '
        Me.cboproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(244, 10)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(121, 21)
        Me.cboproduct.TabIndex = 27
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
        Me.btnclear.Location = New System.Drawing.Point(386, 37)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(75, 23)
        Me.btnclear.TabIndex = 4
        Me.btnclear.Text = "C&lear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(307, 37)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 3
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'dtpcycledate
        '
        Me.dtpcycledate.CustomFormat = "dd-MM-yyyy"
        Me.dtpcycledate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpcycledate.Location = New System.Drawing.Point(75, 9)
        Me.dtpcycledate.Name = "dtpcycledate"
        Me.dtpcycledate.Size = New System.Drawing.Size(112, 20)
        Me.dtpcycledate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cycle Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(852, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 32
        '
        'frmrebatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(727, 350)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lbltotrec)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Name = "frmrebatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Re Batch"
        CType(Me.dgvsummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvsummary As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lbltotrec As System.Windows.Forms.Label
    Friend WithEvents btnbatchtally As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents dtpcycledate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
