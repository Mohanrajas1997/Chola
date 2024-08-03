<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinnOneImageEntry
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.TxtTenureCount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPayMode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtAgreementId = New System.Windows.Forms.TextBox()
        Me.TxtPacketId = New System.Windows.Forms.TextBox()
        Me.TxtPacketRmk = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAgreementNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtGnsaRefNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtbPacketRecv = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicFrontSide = New System.Windows.Forms.PictureBox()
        Me.PicBackSide = New System.Windows.Forms.PictureBox()
        Me.pnlEntry = New System.Windows.Forms.Panel()
        Me.gvmChildAgreement = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CboFinnoneDisc = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.RdoYetConfirm = New System.Windows.Forms.RadioButton()
        Me.RdiYes = New System.Windows.Forms.RadioButton()
        Me.RdiNo = New System.Windows.Forms.RadioButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtBranchName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtBankName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtBankCode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtMicrCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtChequeNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtMandateCount = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtSpdcCount = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPdcCount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.RdiChqNo = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.RdiChqYes = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlChq = New System.Windows.Forms.Panel()
        Me.rdoCompleted = New System.Windows.Forms.RadioButton()
        Me.rdoPending = New System.Windows.Forms.RadioButton()
        Me.gvmChkrEntry = New System.Windows.Forms.DataGridView()
        Me.Chq_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Serial_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheque_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Micr_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tran_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Base_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label10 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntry.SuspendLayout()
        CType(Me.gvmChildAgreement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlChq.SuspendLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.TxtTenureCount)
        Me.pnlHeader.Controls.Add(Me.Label9)
        Me.pnlHeader.Controls.Add(Me.TxtCustomerName)
        Me.pnlHeader.Controls.Add(Me.Label8)
        Me.pnlHeader.Controls.Add(Me.TxtPayMode)
        Me.pnlHeader.Controls.Add(Me.Label7)
        Me.pnlHeader.Controls.Add(Me.TxtAgreementId)
        Me.pnlHeader.Controls.Add(Me.TxtPacketId)
        Me.pnlHeader.Controls.Add(Me.TxtPacketRmk)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.TxtAgreementNo)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.TxtGnsaRefNo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.dtbPacketRecv)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Location = New System.Drawing.Point(8, 16)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(963, 66)
        Me.pnlHeader.TabIndex = 0
        '
        'TxtTenureCount
        '
        Me.TxtTenureCount.Location = New System.Drawing.Point(824, 38)
        Me.TxtTenureCount.Name = "TxtTenureCount"
        Me.TxtTenureCount.Size = New System.Drawing.Size(130, 21)
        Me.TxtTenureCount.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(756, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Tenure"
        '
        'TxtCustomerName
        '
        Me.TxtCustomerName.Location = New System.Drawing.Point(83, 38)
        Me.TxtCustomerName.Name = "TxtCustomerName"
        Me.TxtCustomerName.Size = New System.Drawing.Size(322, 21)
        Me.TxtCustomerName.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Customer"
        '
        'TxtPayMode
        '
        Me.TxtPayMode.Location = New System.Drawing.Point(824, 8)
        Me.TxtPayMode.Name = "TxtPayMode"
        Me.TxtPayMode.Size = New System.Drawing.Size(130, 21)
        Me.TxtPayMode.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(756, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Pay Mode"
        '
        'TxtAgreementId
        '
        Me.TxtAgreementId.Location = New System.Drawing.Point(605, 8)
        Me.TxtAgreementId.Name = "TxtAgreementId"
        Me.TxtAgreementId.Size = New System.Drawing.Size(145, 21)
        Me.TxtAgreementId.TabIndex = 3
        '
        'TxtPacketId
        '
        Me.TxtPacketId.Location = New System.Drawing.Point(3, 36)
        Me.TxtPacketId.Name = "TxtPacketId"
        Me.TxtPacketId.Size = New System.Drawing.Size(21, 21)
        Me.TxtPacketId.TabIndex = 10
        Me.TxtPacketId.Visible = False
        '
        'TxtPacketRmk
        '
        Me.TxtPacketRmk.Location = New System.Drawing.Point(488, 38)
        Me.TxtPacketRmk.Name = "TxtPacketRmk"
        Me.TxtPacketRmk.Size = New System.Drawing.Size(262, 21)
        Me.TxtPacketRmk.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(411, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Remarks"
        '
        'TxtAgreementNo
        '
        Me.TxtAgreementNo.Location = New System.Drawing.Point(488, 8)
        Me.TxtAgreementNo.Name = "TxtAgreementNo"
        Me.TxtAgreementNo.Size = New System.Drawing.Size(111, 21)
        Me.TxtAgreementNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(411, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Agreement"
        '
        'TxtGnsaRefNo
        '
        Me.TxtGnsaRefNo.Location = New System.Drawing.Point(275, 8)
        Me.TxtGnsaRefNo.Name = "TxtGnsaRefNo"
        Me.TxtGnsaRefNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtGnsaRefNo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gnsa Ref No"
        '
        'dtbPacketRecv
        '
        Me.dtbPacketRecv.CustomFormat = "dd-MM-yyyy"
        Me.dtbPacketRecv.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtbPacketRecv.Location = New System.Drawing.Point(83, 8)
        Me.dtbPacketRecv.Name = "dtbPacketRecv"
        Me.dtbPacketRecv.Size = New System.Drawing.Size(107, 21)
        Me.dtbPacketRecv.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Rcvd Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Packet Details"
        '
        'PicFrontSide
        '
        Me.PicFrontSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFrontSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFrontSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFrontSide.ErrorImage = Nothing
        Me.PicFrontSide.Location = New System.Drawing.Point(277, 150)
        Me.PicFrontSide.Name = "PicFrontSide"
        Me.PicFrontSide.Size = New System.Drawing.Size(125, 212)
        Me.PicFrontSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFrontSide.TabIndex = 22
        Me.PicFrontSide.TabStop = False
        '
        'PicBackSide
        '
        Me.PicBackSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicBackSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicBackSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBackSide.ErrorImage = Nothing
        Me.PicBackSide.Location = New System.Drawing.Point(47, 150)
        Me.PicBackSide.Name = "PicBackSide"
        Me.PicBackSide.Size = New System.Drawing.Size(130, 223)
        Me.PicBackSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBackSide.TabIndex = 23
        Me.PicBackSide.TabStop = False
        Me.PicBackSide.Visible = False
        '
        'pnlEntry
        '
        Me.pnlEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEntry.Controls.Add(Me.gvmChildAgreement)
        Me.pnlEntry.Controls.Add(Me.Label5)
        Me.pnlEntry.Controls.Add(Me.Panel2)
        Me.pnlEntry.Controls.Add(Me.TxtBranchName)
        Me.pnlEntry.Controls.Add(Me.Label20)
        Me.pnlEntry.Controls.Add(Me.TxtBankName)
        Me.pnlEntry.Controls.Add(Me.Label19)
        Me.pnlEntry.Controls.Add(Me.TxtBankCode)
        Me.pnlEntry.Controls.Add(Me.Label18)
        Me.pnlEntry.Controls.Add(Me.TxtMicrCode)
        Me.pnlEntry.Controls.Add(Me.Label17)
        Me.pnlEntry.Controls.Add(Me.TxtChequeNo)
        Me.pnlEntry.Controls.Add(Me.Label16)
        Me.pnlEntry.Controls.Add(Me.dtpStartDate)
        Me.pnlEntry.Controls.Add(Me.Label15)
        Me.pnlEntry.Controls.Add(Me.TxtMandateCount)
        Me.pnlEntry.Controls.Add(Me.Label13)
        Me.pnlEntry.Controls.Add(Me.TxtSpdcCount)
        Me.pnlEntry.Controls.Add(Me.Label12)
        Me.pnlEntry.Controls.Add(Me.TxtPdcCount)
        Me.pnlEntry.Controls.Add(Me.Label11)
        Me.pnlEntry.Controls.Add(Me.btnCancel)
        Me.pnlEntry.Controls.Add(Me.RdiChqNo)
        Me.pnlEntry.Controls.Add(Me.btnSave)
        Me.pnlEntry.Controls.Add(Me.RdiChqYes)
        Me.pnlEntry.Controls.Add(Me.Label14)
        Me.pnlEntry.Location = New System.Drawing.Point(614, 89)
        Me.pnlEntry.Name = "pnlEntry"
        Me.pnlEntry.Size = New System.Drawing.Size(271, 415)
        Me.pnlEntry.TabIndex = 1
        '
        'gvmChildAgreement
        '
        Me.gvmChildAgreement.AllowUserToAddRows = False
        Me.gvmChildAgreement.AllowUserToDeleteRows = False
        Me.gvmChildAgreement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvmChildAgreement.ColumnHeadersVisible = False
        Me.gvmChildAgreement.Location = New System.Drawing.Point(3, 292)
        Me.gvmChildAgreement.Name = "gvmChildAgreement"
        Me.gvmChildAgreement.ReadOnly = True
        Me.gvmChildAgreement.Size = New System.Drawing.Size(259, 88)
        Me.gvmChildAgreement.TabIndex = 68
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label5.Location = New System.Drawing.Point(3, 276)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Child Agreement No"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CboFinnoneDisc)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.RdoYetConfirm)
        Me.Panel2.Controls.Add(Me.RdiYes)
        Me.Panel2.Controls.Add(Me.RdiNo)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Location = New System.Drawing.Point(4, 218)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 55)
        Me.Panel2.TabIndex = 11
        '
        'CboFinnoneDisc
        '
        Me.CboFinnoneDisc.FormattingEnabled = True
        Me.CboFinnoneDisc.Location = New System.Drawing.Point(65, 28)
        Me.CboFinnoneDisc.Name = "CboFinnoneDisc"
        Me.CboFinnoneDisc.Size = New System.Drawing.Size(198, 21)
        Me.CboFinnoneDisc.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label22.Location = New System.Drawing.Point(1, 31)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 13)
        Me.Label22.TabIndex = 43
        Me.Label22.Text = "Reason"
        '
        'RdoYetConfirm
        '
        Me.RdoYetConfirm.AutoSize = True
        Me.RdoYetConfirm.Checked = True
        Me.RdoYetConfirm.ForeColor = System.Drawing.Color.Blue
        Me.RdoYetConfirm.Location = New System.Drawing.Point(147, 5)
        Me.RdoYetConfirm.Name = "RdoYetConfirm"
        Me.RdoYetConfirm.Size = New System.Drawing.Size(106, 17)
        Me.RdoYetConfirm.TabIndex = 0
        Me.RdoYetConfirm.TabStop = True
        Me.RdoYetConfirm.Text = "Yet to Confirm"
        Me.RdoYetConfirm.UseVisualStyleBackColor = True
        '
        'RdiYes
        '
        Me.RdiYes.AutoSize = True
        Me.RdiYes.ForeColor = System.Drawing.Color.Red
        Me.RdiYes.Location = New System.Drawing.Point(40, 5)
        Me.RdiYes.Name = "RdiYes"
        Me.RdiYes.Size = New System.Drawing.Size(45, 17)
        Me.RdiYes.TabIndex = 2
        Me.RdiYes.Text = "&Yes"
        Me.RdiYes.UseVisualStyleBackColor = True
        '
        'RdiNo
        '
        Me.RdiNo.AutoSize = True
        Me.RdiNo.ForeColor = System.Drawing.Color.ForestGreen
        Me.RdiNo.Location = New System.Drawing.Point(96, 5)
        Me.RdiNo.Name = "RdiNo"
        Me.RdiNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiNo.TabIndex = 1
        Me.RdiNo.Text = "&No"
        Me.RdiNo.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label21.Location = New System.Drawing.Point(1, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Disc"
        '
        'TxtBranchName
        '
        Me.TxtBranchName.Location = New System.Drawing.Point(65, 191)
        Me.TxtBranchName.Name = "TxtBranchName"
        Me.TxtBranchName.Size = New System.Drawing.Size(198, 21)
        Me.TxtBranchName.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(1, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Branch"
        '
        'TxtBankName
        '
        Me.TxtBankName.Location = New System.Drawing.Point(65, 164)
        Me.TxtBankName.Name = "TxtBankName"
        Me.TxtBankName.Size = New System.Drawing.Size(198, 21)
        Me.TxtBankName.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(1, 164)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Bank Name"
        '
        'TxtBankCode
        '
        Me.TxtBankCode.Location = New System.Drawing.Point(65, 137)
        Me.TxtBankCode.Name = "TxtBankCode"
        Me.TxtBankCode.Size = New System.Drawing.Size(198, 21)
        Me.TxtBankCode.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "Bank Code"
        '
        'TxtMicrCode
        '
        Me.TxtMicrCode.Location = New System.Drawing.Point(65, 110)
        Me.TxtMicrCode.Name = "TxtMicrCode"
        Me.TxtMicrCode.Size = New System.Drawing.Size(198, 21)
        Me.TxtMicrCode.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Micr Code"
        '
        'TxtChequeNo
        '
        Me.TxtChequeNo.Location = New System.Drawing.Point(65, 83)
        Me.TxtChequeNo.Name = "TxtChequeNo"
        Me.TxtChequeNo.Size = New System.Drawing.Size(198, 21)
        Me.TxtChequeNo.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Chq No"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(173, 55)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(90, 21)
        Me.dtpStartDate.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(124, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Start Dt"
        '
        'TxtMandateCount
        '
        Me.TxtMandateCount.Location = New System.Drawing.Point(65, 56)
        Me.TxtMandateCount.Name = "TxtMandateCount"
        Me.TxtMandateCount.Size = New System.Drawing.Size(58, 21)
        Me.TxtMandateCount.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Mandate"
        '
        'TxtSpdcCount
        '
        Me.TxtSpdcCount.Location = New System.Drawing.Point(173, 28)
        Me.TxtSpdcCount.Name = "TxtSpdcCount"
        Me.TxtSpdcCount.Size = New System.Drawing.Size(58, 21)
        Me.TxtSpdcCount.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(124, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "SPDC"
        '
        'TxtPdcCount
        '
        Me.TxtPdcCount.Location = New System.Drawing.Point(65, 28)
        Me.TxtPdcCount.Name = "TxtPdcCount"
        Me.TxtPdcCount.Size = New System.Drawing.Size(58, 21)
        Me.TxtPdcCount.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "PDC"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(182, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 28)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'RdiChqNo
        '
        Me.RdiChqNo.AutoSize = True
        Me.RdiChqNo.Location = New System.Drawing.Point(153, 7)
        Me.RdiChqNo.Name = "RdiChqNo"
        Me.RdiChqNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiChqNo.TabIndex = 1
        Me.RdiChqNo.TabStop = True
        Me.RdiChqNo.Text = "No"
        Me.RdiChqNo.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(95, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 28)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'RdiChqYes
        '
        Me.RdiChqYes.AutoSize = True
        Me.RdiChqYes.Checked = True
        Me.RdiChqYes.Location = New System.Drawing.Point(99, 7)
        Me.RdiChqYes.Name = "RdiChqYes"
        Me.RdiChqYes.Size = New System.Drawing.Size(45, 17)
        Me.RdiChqYes.TabIndex = 0
        Me.RdiChqYes.TabStop = True
        Me.RdiChqYes.Text = "Yes"
        Me.RdiChqYes.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Cheque Visible"
        '
        'pnlChq
        '
        Me.pnlChq.Controls.Add(Me.rdoCompleted)
        Me.pnlChq.Controls.Add(Me.rdoPending)
        Me.pnlChq.Controls.Add(Me.gvmChkrEntry)
        Me.pnlChq.Controls.Add(Me.label10)
        Me.pnlChq.Location = New System.Drawing.Point(3, 510)
        Me.pnlChq.Name = "pnlChq"
        Me.pnlChq.Size = New System.Drawing.Size(1182, 201)
        Me.pnlChq.TabIndex = 25
        '
        'rdoCompleted
        '
        Me.rdoCompleted.AutoSize = True
        Me.rdoCompleted.ForeColor = System.Drawing.Color.DarkGreen
        Me.rdoCompleted.Location = New System.Drawing.Point(142, 0)
        Me.rdoCompleted.Name = "rdoCompleted"
        Me.rdoCompleted.Size = New System.Drawing.Size(86, 17)
        Me.rdoCompleted.TabIndex = 6
        Me.rdoCompleted.Text = "Completed"
        Me.rdoCompleted.UseVisualStyleBackColor = True
        '
        'rdoPending
        '
        Me.rdoPending.AutoSize = True
        Me.rdoPending.Checked = True
        Me.rdoPending.ForeColor = System.Drawing.Color.Red
        Me.rdoPending.Location = New System.Drawing.Point(249, 0)
        Me.rdoPending.Name = "rdoPending"
        Me.rdoPending.Size = New System.Drawing.Size(70, 17)
        Me.rdoPending.TabIndex = 5
        Me.rdoPending.TabStop = True
        Me.rdoPending.Text = "Pending"
        Me.rdoPending.UseVisualStyleBackColor = True
        '
        'gvmChkrEntry
        '
        Me.gvmChkrEntry.AllowUserToAddRows = False
        Me.gvmChkrEntry.AllowUserToDeleteRows = False
        Me.gvmChkrEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvmChkrEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvmChkrEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvmChkrEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chq_id, Me.Serial_no, Me.Cheque_No, Me.Micr_Code, Me.Tran_code, Me.Base_Code})
        Me.gvmChkrEntry.Location = New System.Drawing.Point(0, 18)
        Me.gvmChkrEntry.MultiSelect = False
        Me.gvmChkrEntry.Name = "gvmChkrEntry"
        Me.gvmChkrEntry.ReadOnly = True
        Me.gvmChkrEntry.Size = New System.Drawing.Size(1173, 182)
        Me.gvmChkrEntry.TabIndex = 0
        '
        'Chq_id
        '
        Me.Chq_id.HeaderText = "ChqId"
        Me.Chq_id.Name = "Chq_id"
        Me.Chq_id.ReadOnly = True
        Me.Chq_id.Visible = False
        '
        'Serial_no
        '
        Me.Serial_no.HeaderText = "Serial No"
        Me.Serial_no.Name = "Serial_no"
        Me.Serial_no.ReadOnly = True
        '
        'Cheque_No
        '
        Me.Cheque_No.HeaderText = "Cheque No"
        Me.Cheque_No.Name = "Cheque_No"
        Me.Cheque_No.ReadOnly = True
        '
        'Micr_Code
        '
        Me.Micr_Code.HeaderText = "Micr Code"
        Me.Micr_Code.Name = "Micr_Code"
        Me.Micr_Code.ReadOnly = True
        '
        'Tran_code
        '
        Me.Tran_code.HeaderText = "Tran Code"
        Me.Tran_code.Name = "Tran_code"
        Me.Tran_code.ReadOnly = True
        '
        'Base_Code
        '
        Me.Base_Code.HeaderText = "Base Code"
        Me.Base_Code.Name = "Base_Code"
        Me.Base_Code.ReadOnly = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(3, -1)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(91, 13)
        Me.label10.TabIndex = 4
        Me.label10.Text = "Cheque Details"
        '
        'frmFinnOneImageEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1028, 749)
        Me.Controls.Add(Me.pnlChq)
        Me.Controls.Add(Me.pnlEntry)
        Me.Controls.Add(Me.PicFrontSide)
        Me.Controls.Add(Me.PicBackSide)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmFinnOneImageEntry"
        Me.Text = "FinnOne Image Based Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntry.ResumeLayout(False)
        Me.pnlEntry.PerformLayout()
        CType(Me.gvmChildAgreement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlChq.ResumeLayout(False)
        Me.pnlChq.PerformLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtbPacketRecv As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtGnsaRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAgreementNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPacketRmk As System.Windows.Forms.TextBox
    Private WithEvents PicFrontSide As System.Windows.Forms.PictureBox
    Private WithEvents PicBackSide As System.Windows.Forms.PictureBox
    Private WithEvents pnlEntry As System.Windows.Forms.Panel
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents pnlChq As System.Windows.Forms.Panel
    Private WithEvents rdoCompleted As System.Windows.Forms.RadioButton
    Private WithEvents rdoPending As System.Windows.Forms.RadioButton
    Private WithEvents gvmChkrEntry As System.Windows.Forms.DataGridView
    Private WithEvents Chq_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Serial_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Cheque_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Micr_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Tran_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Base_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents TxtPacketId As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RdiChqNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiChqYes As System.Windows.Forms.RadioButton
    Friend WithEvents TxtAgreementId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtPayMode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTenureCount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPdcCount As System.Windows.Forms.TextBox
    Friend WithEvents TxtSpdcCount As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtMandateCount As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtMicrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoYetConfirm As System.Windows.Forms.RadioButton
    Friend WithEvents RdiYes As System.Windows.Forms.RadioButton
    Private WithEvents RdiNo As System.Windows.Forms.RadioButton
    Private WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CboFinnoneDisc As System.Windows.Forms.ComboBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gvmChildAgreement As System.Windows.Forms.DataGridView
End Class
