<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVMSCorrenctionEntry
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
        Me.mstchqdate = New System.Windows.Forms.MaskedTextBox()
        Me.TxtReason = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtAccNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAmount = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtChequeNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPayMode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoYetConfirm = New System.Windows.Forms.RadioButton()
        Me.RdiFinnOne = New System.Windows.Forms.RadioButton()
        Me.RdiVMS = New System.Windows.Forms.RadioButton()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntry.SuspendLayout()
        Me.pnlChq.SuspendLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.TxtTenureCount)
        Me.pnlHeader.Controls.Add(Me.Label9)
        Me.pnlHeader.Controls.Add(Me.TxtCustomerName)
        Me.pnlHeader.Controls.Add(Me.Label8)
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
        Me.TxtTenureCount.Location = New System.Drawing.Point(824, 7)
        Me.TxtTenureCount.Name = "TxtTenureCount"
        Me.TxtTenureCount.Size = New System.Drawing.Size(130, 21)
        Me.TxtTenureCount.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(756, 11)
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
        Me.pnlEntry.Controls.Add(Me.Panel2)
        Me.pnlEntry.Controls.Add(Me.mstchqdate)
        Me.pnlEntry.Controls.Add(Me.TxtReason)
        Me.pnlEntry.Controls.Add(Me.Label7)
        Me.pnlEntry.Controls.Add(Me.TxtAccNo)
        Me.pnlEntry.Controls.Add(Me.Label5)
        Me.pnlEntry.Controls.Add(Me.TxtAmount)
        Me.pnlEntry.Controls.Add(Me.Label17)
        Me.pnlEntry.Controls.Add(Me.TxtChequeNo)
        Me.pnlEntry.Controls.Add(Me.Label16)
        Me.pnlEntry.Controls.Add(Me.Label15)
        Me.pnlEntry.Controls.Add(Me.TxtPayMode)
        Me.pnlEntry.Controls.Add(Me.Label13)
        Me.pnlEntry.Controls.Add(Me.btnCancel)
        Me.pnlEntry.Controls.Add(Me.btnSave)
        Me.pnlEntry.Location = New System.Drawing.Point(614, 89)
        Me.pnlEntry.Name = "pnlEntry"
        Me.pnlEntry.Size = New System.Drawing.Size(271, 415)
        Me.pnlEntry.TabIndex = 1
        '
        'mstchqdate
        '
        Me.mstchqdate.Location = New System.Drawing.Point(66, 94)
        Me.mstchqdate.Mask = "00/00/0000"
        Me.mstchqdate.Name = "mstchqdate"
        Me.mstchqdate.Size = New System.Drawing.Size(198, 21)
        Me.mstchqdate.TabIndex = 3
        Me.mstchqdate.ValidatingType = GetType(Date)
        '
        'TxtReason
        '
        Me.TxtReason.Location = New System.Drawing.Point(65, 37)
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.Size = New System.Drawing.Size(198, 21)
        Me.TxtReason.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Reason"
        '
        'TxtAccNo
        '
        Me.TxtAccNo.Location = New System.Drawing.Point(65, 149)
        Me.TxtAccNo.Name = "TxtAccNo"
        Me.TxtAccNo.Size = New System.Drawing.Size(198, 21)
        Me.TxtAccNo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Acc No"
        '
        'TxtAmount
        '
        Me.TxtAmount.Location = New System.Drawing.Point(65, 121)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(198, 21)
        Me.TxtAmount.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Amount"
        '
        'TxtChequeNo
        '
        Me.TxtChequeNo.Location = New System.Drawing.Point(65, 64)
        Me.TxtChequeNo.Name = "TxtChequeNo"
        Me.TxtChequeNo.Size = New System.Drawing.Size(198, 21)
        Me.TxtChequeNo.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Chq No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Chq Dt"
        '
        'TxtPayMode
        '
        Me.TxtPayMode.Location = New System.Drawing.Point(65, 9)
        Me.TxtPayMode.Name = "TxtPayMode"
        Me.TxtPayMode.Size = New System.Drawing.Size(198, 21)
        Me.TxtPayMode.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Pay Mode"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(182, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 28)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(95, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 28)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoYetConfirm)
        Me.Panel2.Controls.Add(Me.RdiFinnOne)
        Me.Panel2.Controls.Add(Me.RdiVMS)
        Me.Panel2.Location = New System.Drawing.Point(2, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 29)
        Me.Panel2.TabIndex = 62
        '
        'RdoYetConfirm
        '
        Me.RdoYetConfirm.AutoSize = True
        Me.RdoYetConfirm.Checked = True
        Me.RdoYetConfirm.ForeColor = System.Drawing.Color.Blue
        Me.RdoYetConfirm.Location = New System.Drawing.Point(4, 6)
        Me.RdoYetConfirm.Name = "RdoYetConfirm"
        Me.RdoYetConfirm.Size = New System.Drawing.Size(106, 17)
        Me.RdoYetConfirm.TabIndex = 0
        Me.RdoYetConfirm.TabStop = True
        Me.RdoYetConfirm.Text = "Yet to Confirm"
        Me.RdoYetConfirm.UseVisualStyleBackColor = True
        '
        'RdiFinnOne
        '
        Me.RdiFinnOne.AutoSize = True
        Me.RdiFinnOne.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.RdiFinnOne.Location = New System.Drawing.Point(114, 6)
        Me.RdiFinnOne.Name = "RdiFinnOne"
        Me.RdiFinnOne.Size = New System.Drawing.Size(70, 17)
        Me.RdiFinnOne.TabIndex = 2
        Me.RdiFinnOne.Text = "FinnOne"
        Me.RdiFinnOne.UseVisualStyleBackColor = True
        '
        'RdiVMS
        '
        Me.RdiVMS.AutoSize = True
        Me.RdiVMS.ForeColor = System.Drawing.Color.ForestGreen
        Me.RdiVMS.Location = New System.Drawing.Point(190, 6)
        Me.RdiVMS.Name = "RdiVMS"
        Me.RdiVMS.Size = New System.Drawing.Size(49, 17)
        Me.RdiVMS.TabIndex = 1
        Me.RdiVMS.Text = "VMS"
        Me.RdiVMS.UseVisualStyleBackColor = True
        '
        'frmVMSCorrenctionEntry
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
        Me.Name = "frmVMSCorrenctionEntry"
        Me.Text = "VMS Correction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntry.ResumeLayout(False)
        Me.pnlEntry.PerformLayout()
        Me.pnlChq.ResumeLayout(False)
        Me.pnlChq.PerformLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents TxtAgreementId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTenureCount As System.Windows.Forms.TextBox
    Friend WithEvents TxtPayMode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mstchqdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoYetConfirm As System.Windows.Forms.RadioButton
    Friend WithEvents RdiFinnOne As System.Windows.Forms.RadioButton
    Private WithEvents RdiVMS As System.Windows.Forms.RadioButton
End Class
