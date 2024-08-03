<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageBaseEntry
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
        Me.RdiChqNo = New System.Windows.Forms.RadioButton()
        Me.RdiChqYes = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CboPcktMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDiscValue = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoYetConfirm = New System.Windows.Forms.RadioButton()
        Me.RdiDiscYes = New System.Windows.Forms.RadioButton()
        Me.RdiDiscNo = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TxtRemarks = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mstchqdate = New System.Windows.Forms.MaskedTextBox()
        Me.TxtBankName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtBankCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtMicrCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCtsChqAmt = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtaccno = New System.Windows.Forms.TextBox()
        Me.txtchqamt = New System.Windows.Forms.TextBox()
        Me.lblaccno = New System.Windows.Forms.Label()
        Me.lblchqamt = New System.Windows.Forms.Label()
        Me.lblchqdate = New System.Windows.Forms.Label()
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
        Me.PnlMandate = New System.Windows.Forms.Panel()
        Me.TxtTenorCount = New System.Windows.Forms.TextBox()
        Me.mtxtenddate = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtstartdate = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Pnlchqdtls = New System.Windows.Forms.Panel()
        Me.PnlPdcEntry = New System.Windows.Forms.Panel()
        Me.PnlBankdtls = New System.Windows.Forms.Panel()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntry.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlChq.SuspendLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMandate.SuspendLayout()
        Me.Pnlchqdtls.SuspendLayout()
        Me.PnlPdcEntry.SuspendLayout()
        Me.PnlBankdtls.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.TxtPacketId)
        Me.pnlHeader.Controls.Add(Me.TxtPacketRmk)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.TxtAgreementNo)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.TxtGnsaRefNo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.dtbPacketRecv)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Enabled = False
        Me.pnlHeader.Location = New System.Drawing.Point(12, 16)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1059, 39)
        Me.pnlHeader.TabIndex = 0
        '
        'TxtPacketId
        '
        Me.TxtPacketId.Location = New System.Drawing.Point(3, 28)
        Me.TxtPacketId.Name = "TxtPacketId"
        Me.TxtPacketId.Size = New System.Drawing.Size(21, 21)
        Me.TxtPacketId.TabIndex = 10
        Me.TxtPacketId.Visible = False
        '
        'TxtPacketRmk
        '
        Me.TxtPacketRmk.Location = New System.Drawing.Point(755, 9)
        Me.TxtPacketRmk.Name = "TxtPacketRmk"
        Me.TxtPacketRmk.ReadOnly = True
        Me.TxtPacketRmk.Size = New System.Drawing.Size(293, 21)
        Me.TxtPacketRmk.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(650, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Packet Remarks"
        '
        'TxtAgreementNo
        '
        Me.TxtAgreementNo.Location = New System.Drawing.Point(517, 8)
        Me.TxtAgreementNo.Name = "TxtAgreementNo"
        Me.TxtAgreementNo.ReadOnly = True
        Me.TxtAgreementNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtAgreementNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Agreement No"
        '
        'TxtGnsaRefNo
        '
        Me.TxtGnsaRefNo.Location = New System.Drawing.Point(279, 8)
        Me.TxtGnsaRefNo.Name = "TxtGnsaRefNo"
        Me.TxtGnsaRefNo.ReadOnly = True
        Me.TxtGnsaRefNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtGnsaRefNo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 12)
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
        Me.Label1.Location = New System.Drawing.Point(13, 0)
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
        Me.PicFrontSide.Location = New System.Drawing.Point(213, 86)
        Me.PicFrontSide.Name = "PicFrontSide"
        Me.PicFrontSide.Size = New System.Drawing.Size(123, 212)
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
        Me.PicBackSide.Location = New System.Drawing.Point(47, 86)
        Me.PicBackSide.Name = "PicBackSide"
        Me.PicBackSide.Size = New System.Drawing.Size(133, 223)
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
        Me.pnlEntry.Controls.Add(Me.RdiChqNo)
        Me.pnlEntry.Controls.Add(Me.RdiChqYes)
        Me.pnlEntry.Controls.Add(Me.Label14)
        Me.pnlEntry.Controls.Add(Me.CboPcktMode)
        Me.pnlEntry.Controls.Add(Me.Label7)
        Me.pnlEntry.Location = New System.Drawing.Point(887, 61)
        Me.pnlEntry.Name = "pnlEntry"
        Me.pnlEntry.Size = New System.Drawing.Size(253, 56)
        Me.pnlEntry.TabIndex = 1
        '
        'RdiChqNo
        '
        Me.RdiChqNo.AutoSize = True
        Me.RdiChqNo.Location = New System.Drawing.Point(166, 7)
        Me.RdiChqNo.Name = "RdiChqNo"
        Me.RdiChqNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiChqNo.TabIndex = 1
        Me.RdiChqNo.TabStop = True
        Me.RdiChqNo.Text = "No"
        Me.RdiChqNo.UseVisualStyleBackColor = True
        '
        'RdiChqYes
        '
        Me.RdiChqYes.AutoSize = True
        Me.RdiChqYes.Checked = True
        Me.RdiChqYes.Location = New System.Drawing.Point(116, 7)
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
        Me.Label14.Location = New System.Drawing.Point(4, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Cheque Visible"
        '
        'CboPcktMode
        '
        Me.CboPcktMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboPcktMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboPcktMode.FormattingEnabled = True
        Me.CboPcktMode.Items.AddRange(New Object() {"PDC", "SPDC", "Mandate", "Others"})
        Me.CboPcktMode.Location = New System.Drawing.Point(116, 29)
        Me.CboPcktMode.Name = "CboPcktMode"
        Me.CboPcktMode.Size = New System.Drawing.Size(131, 21)
        Me.CboPcktMode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Pay Mode"
        '
        'TxtDiscValue
        '
        Me.TxtDiscValue.Location = New System.Drawing.Point(43, 213)
        Me.TxtDiscValue.Name = "TxtDiscValue"
        Me.TxtDiscValue.Size = New System.Drawing.Size(24, 21)
        Me.TxtDiscValue.TabIndex = 7
        Me.TxtDiscValue.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoYetConfirm)
        Me.Panel2.Controls.Add(Me.RdiDiscYes)
        Me.Panel2.Controls.Add(Me.RdiDiscNo)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Location = New System.Drawing.Point(2, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(247, 49)
        Me.Panel2.TabIndex = 4
        '
        'RdoYetConfirm
        '
        Me.RdoYetConfirm.AutoSize = True
        Me.RdoYetConfirm.Checked = True
        Me.RdoYetConfirm.ForeColor = System.Drawing.Color.Blue
        Me.RdoYetConfirm.Location = New System.Drawing.Point(95, 26)
        Me.RdoYetConfirm.Name = "RdoYetConfirm"
        Me.RdoYetConfirm.Size = New System.Drawing.Size(106, 17)
        Me.RdoYetConfirm.TabIndex = 2
        Me.RdoYetConfirm.TabStop = True
        Me.RdoYetConfirm.Text = "Yet to Confirm"
        Me.RdoYetConfirm.UseVisualStyleBackColor = True
        '
        'RdiDiscYes
        '
        Me.RdiDiscYes.AutoSize = True
        Me.RdiDiscYes.ForeColor = System.Drawing.Color.Red
        Me.RdiDiscYes.Location = New System.Drawing.Point(5, 26)
        Me.RdiDiscYes.Name = "RdiDiscYes"
        Me.RdiDiscYes.Size = New System.Drawing.Size(45, 17)
        Me.RdiDiscYes.TabIndex = 0
        Me.RdiDiscYes.Text = "&Yes"
        Me.RdiDiscYes.UseVisualStyleBackColor = True
        '
        'RdiDiscNo
        '
        Me.RdiDiscNo.AutoSize = True
        Me.RdiDiscNo.ForeColor = System.Drawing.Color.ForestGreen
        Me.RdiDiscNo.Location = New System.Drawing.Point(52, 26)
        Me.RdiDiscNo.Name = "RdiDiscNo"
        Me.RdiDiscNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiDiscNo.TabIndex = 1
        Me.RdiDiscNo.Text = "&No"
        Me.RdiDiscNo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label12.Location = New System.Drawing.Point(2, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Disc"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(205, 23)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(37, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TxtRemarks
        '
        Me.TxtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRemarks.Location = New System.Drawing.Point(4, 181)
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(243, 21)
        Me.TxtRemarks.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Remarks"
        '
        'mstchqdate
        '
        Me.mstchqdate.Location = New System.Drawing.Point(115, 5)
        Me.mstchqdate.Mask = "00/00/0000"
        Me.mstchqdate.Name = "mstchqdate"
        Me.mstchqdate.Size = New System.Drawing.Size(131, 21)
        Me.mstchqdate.TabIndex = 0
        Me.mstchqdate.ValidatingType = GetType(Date)
        '
        'TxtBankName
        '
        Me.TxtBankName.Location = New System.Drawing.Point(3, 46)
        Me.TxtBankName.Name = "TxtBankName"
        Me.TxtBankName.Size = New System.Drawing.Size(241, 21)
        Me.TxtBankName.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label11.Location = New System.Drawing.Point(4, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Bank Name"
        '
        'TxtBankCode
        '
        Me.TxtBankCode.Location = New System.Drawing.Point(116, 2)
        Me.TxtBankCode.Name = "TxtBankCode"
        Me.TxtBankCode.Size = New System.Drawing.Size(131, 21)
        Me.TxtBankCode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label9.Location = New System.Drawing.Point(4, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Bank Code"
        '
        'TxtMicrCode
        '
        Me.TxtMicrCode.Location = New System.Drawing.Point(116, 34)
        Me.TxtMicrCode.Name = "TxtMicrCode"
        Me.TxtMicrCode.Size = New System.Drawing.Size(131, 21)
        Me.TxtMicrCode.TabIndex = 1
        Me.TxtMicrCode.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label8.Location = New System.Drawing.Point(4, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Micr Code"
        '
        'TxtChqNo
        '
        Me.TxtChqNo.Location = New System.Drawing.Point(116, 5)
        Me.TxtChqNo.Name = "TxtChqNo"
        Me.TxtChqNo.Size = New System.Drawing.Size(131, 21)
        Me.TxtChqNo.TabIndex = 0
        Me.TxtChqNo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label5.Location = New System.Drawing.Point(4, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Cheque No"
        '
        'txtCtsChqAmt
        '
        Me.txtCtsChqAmt.Location = New System.Drawing.Point(4, 213)
        Me.txtCtsChqAmt.Name = "txtCtsChqAmt"
        Me.txtCtsChqAmt.Size = New System.Drawing.Size(28, 21)
        Me.txtCtsChqAmt.TabIndex = 6
        Me.txtCtsChqAmt.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(167, 208)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 28)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(80, 208)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 28)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtaccno
        '
        Me.txtaccno.BackColor = System.Drawing.SystemColors.Window
        Me.txtaccno.Location = New System.Drawing.Point(3, 88)
        Me.txtaccno.Name = "txtaccno"
        Me.txtaccno.Size = New System.Drawing.Size(241, 21)
        Me.txtaccno.TabIndex = 3
        '
        'txtchqamt
        '
        Me.txtchqamt.Location = New System.Drawing.Point(115, 32)
        Me.txtchqamt.Name = "txtchqamt"
        Me.txtchqamt.Size = New System.Drawing.Size(131, 21)
        Me.txtchqamt.TabIndex = 1
        '
        'lblaccno
        '
        Me.lblaccno.AutoSize = True
        Me.lblaccno.Location = New System.Drawing.Point(4, 72)
        Me.lblaccno.Name = "lblaccno"
        Me.lblaccno.Size = New System.Drawing.Size(91, 13)
        Me.lblaccno.TabIndex = 2
        Me.lblaccno.Text = "Drawee A/C No"
        '
        'lblchqamt
        '
        Me.lblchqamt.AutoSize = True
        Me.lblchqamt.Location = New System.Drawing.Point(4, 36)
        Me.lblchqamt.Name = "lblchqamt"
        Me.lblchqamt.Size = New System.Drawing.Size(97, 13)
        Me.lblchqamt.TabIndex = 23
        Me.lblchqamt.Text = "Cheque Amount"
        '
        'lblchqdate
        '
        Me.lblchqdate.AutoSize = True
        Me.lblchqdate.BackColor = System.Drawing.SystemColors.Control
        Me.lblchqdate.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.lblchqdate.Location = New System.Drawing.Point(4, 9)
        Me.lblchqdate.Name = "lblchqdate"
        Me.lblchqdate.Size = New System.Drawing.Size(79, 13)
        Me.lblchqdate.TabIndex = 21
        Me.lblchqdate.Text = "Cheque Date"
        '
        'pnlChq
        '
        Me.pnlChq.Controls.Add(Me.rdoCompleted)
        Me.pnlChq.Controls.Add(Me.rdoPending)
        Me.pnlChq.Controls.Add(Me.gvmChkrEntry)
        Me.pnlChq.Controls.Add(Me.label10)
        Me.pnlChq.Location = New System.Drawing.Point(3, 523)
        Me.pnlChq.Name = "pnlChq"
        Me.pnlChq.Size = New System.Drawing.Size(1146, 227)
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
        Me.gvmChkrEntry.Size = New System.Drawing.Size(1137, 206)
        Me.gvmChkrEntry.TabIndex = 99
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
        Me.label10.TabIndex = 3
        Me.label10.Text = "Cheque Details"
        '
        'PnlMandate
        '
        Me.PnlMandate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlMandate.Controls.Add(Me.TxtTenorCount)
        Me.PnlMandate.Controls.Add(Me.mtxtenddate)
        Me.PnlMandate.Controls.Add(Me.mtxtstartdate)
        Me.PnlMandate.Controls.Add(Me.Label17)
        Me.PnlMandate.Controls.Add(Me.Label16)
        Me.PnlMandate.Controls.Add(Me.Label15)
        Me.PnlMandate.Location = New System.Drawing.Point(887, 123)
        Me.PnlMandate.Name = "PnlMandate"
        Me.PnlMandate.Size = New System.Drawing.Size(253, 79)
        Me.PnlMandate.TabIndex = 2
        '
        'TxtTenorCount
        '
        Me.TxtTenorCount.Location = New System.Drawing.Point(116, 55)
        Me.TxtTenorCount.Name = "TxtTenorCount"
        Me.TxtTenorCount.Size = New System.Drawing.Size(131, 21)
        Me.TxtTenorCount.TabIndex = 2
        '
        'mtxtenddate
        '
        Me.mtxtenddate.Location = New System.Drawing.Point(116, 30)
        Me.mtxtenddate.Mask = "00/00/0000"
        Me.mtxtenddate.Name = "mtxtenddate"
        Me.mtxtenddate.Size = New System.Drawing.Size(131, 21)
        Me.mtxtenddate.TabIndex = 1
        Me.mtxtenddate.ValidatingType = GetType(Date)
        '
        'mtxtstartdate
        '
        Me.mtxtstartdate.Location = New System.Drawing.Point(116, 5)
        Me.mtxtstartdate.Mask = "00/00/0000"
        Me.mtxtstartdate.Name = "mtxtstartdate"
        Me.mtxtstartdate.Size = New System.Drawing.Size(131, 21)
        Me.mtxtstartdate.TabIndex = 0
        Me.mtxtstartdate.ValidatingType = GetType(Date)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Tenure Count"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "End Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Start Date"
        '
        'Pnlchqdtls
        '
        Me.Pnlchqdtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnlchqdtls.Controls.Add(Me.Label5)
        Me.Pnlchqdtls.Controls.Add(Me.TxtChqNo)
        Me.Pnlchqdtls.Controls.Add(Me.Label8)
        Me.Pnlchqdtls.Controls.Add(Me.TxtMicrCode)
        Me.Pnlchqdtls.Location = New System.Drawing.Point(887, 118)
        Me.Pnlchqdtls.Name = "Pnlchqdtls"
        Me.Pnlchqdtls.Size = New System.Drawing.Size(253, 58)
        Me.Pnlchqdtls.TabIndex = 2
        '
        'PnlPdcEntry
        '
        Me.PnlPdcEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPdcEntry.Controls.Add(Me.mstchqdate)
        Me.PnlPdcEntry.Controls.Add(Me.txtchqamt)
        Me.PnlPdcEntry.Controls.Add(Me.lblchqamt)
        Me.PnlPdcEntry.Controls.Add(Me.lblchqdate)
        Me.PnlPdcEntry.Location = New System.Drawing.Point(886, 181)
        Me.PnlPdcEntry.Name = "PnlPdcEntry"
        Me.PnlPdcEntry.Size = New System.Drawing.Size(253, 59)
        Me.PnlPdcEntry.TabIndex = 3
        '
        'PnlBankdtls
        '
        Me.PnlBankdtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBankdtls.Controls.Add(Me.btnCancel)
        Me.PnlBankdtls.Controls.Add(Me.btnSave)
        Me.PnlBankdtls.Controls.Add(Me.Panel2)
        Me.PnlBankdtls.Controls.Add(Me.txtCtsChqAmt)
        Me.PnlBankdtls.Controls.Add(Me.txtaccno)
        Me.PnlBankdtls.Controls.Add(Me.TxtDiscValue)
        Me.PnlBankdtls.Controls.Add(Me.Label9)
        Me.PnlBankdtls.Controls.Add(Me.Label13)
        Me.PnlBankdtls.Controls.Add(Me.TxtBankCode)
        Me.PnlBankdtls.Controls.Add(Me.TxtRemarks)
        Me.PnlBankdtls.Controls.Add(Me.lblaccno)
        Me.PnlBankdtls.Controls.Add(Me.Label11)
        Me.PnlBankdtls.Controls.Add(Me.TxtBankName)
        Me.PnlBankdtls.Location = New System.Drawing.Point(887, 241)
        Me.PnlBankdtls.Name = "PnlBankdtls"
        Me.PnlBankdtls.Size = New System.Drawing.Size(253, 239)
        Me.PnlBankdtls.TabIndex = 4
        '
        'frmImageBaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1154, 749)
        Me.Controls.Add(Me.Pnlchqdtls)
        Me.Controls.Add(Me.pnlChq)
        Me.Controls.Add(Me.pnlEntry)
        Me.Controls.Add(Me.PicFrontSide)
        Me.Controls.Add(Me.PicBackSide)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.PnlPdcEntry)
        Me.Controls.Add(Me.PnlBankdtls)
        Me.Controls.Add(Me.PnlMandate)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmImageBaseEntry"
        Me.Text = "Image Base Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntry.ResumeLayout(False)
        Me.pnlEntry.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlChq.ResumeLayout(False)
        Me.pnlChq.PerformLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMandate.ResumeLayout(False)
        Me.PnlMandate.PerformLayout()
        Me.Pnlchqdtls.ResumeLayout(False)
        Me.Pnlchqdtls.PerformLayout()
        Me.PnlPdcEntry.ResumeLayout(False)
        Me.PnlPdcEntry.PerformLayout()
        Me.PnlBankdtls.ResumeLayout(False)
        Me.PnlBankdtls.PerformLayout()
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
    Private WithEvents txtCtsChqAmt As System.Windows.Forms.TextBox
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents txtaccno As System.Windows.Forms.TextBox
    Private WithEvents txtchqamt As System.Windows.Forms.TextBox
    Private WithEvents lblaccno As System.Windows.Forms.Label
    Private WithEvents lblchqamt As System.Windows.Forms.Label
    Private WithEvents lblchqdate As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboPcktMode As System.Windows.Forms.ComboBox
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
    Private WithEvents TxtChqNo As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents TxtMicrCode As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents TxtBankCode As System.Windows.Forms.TextBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents TxtBankName As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents RdiDiscYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtDiscValue As System.Windows.Forms.TextBox
    Friend WithEvents mstchqdate As System.Windows.Forms.MaskedTextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents TxtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RdiChqNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiDiscNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiChqYes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoYetConfirm As System.Windows.Forms.RadioButton
    Friend WithEvents PnlMandate As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents mtxtstartdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtenddate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTenorCount As System.Windows.Forms.TextBox
    Friend WithEvents Pnlchqdtls As System.Windows.Forms.Panel
    Friend WithEvents PnlPdcEntry As System.Windows.Forms.Panel
    Friend WithEvents PnlBankdtls As System.Windows.Forms.Panel
End Class
