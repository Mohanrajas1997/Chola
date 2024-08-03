Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class frmImageBaseEntry
    Dim count As Integer = 0
    Dim prvvalue As String = ""
    Dim Scangid As New Integer
    Dim lsPacketGid As Integer = 0
    Dim lsagreementno As String = ""
    Dim lnCyclegid As Integer = 0
    Private Sub frmImageBaseEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'CboPcktMode.Items.Add("PDC")
        'CboPcktMode.Items.Add("SPDC")
        'CboPcktMode.Items.Add("Mandate")
        'CboPcktMode.Items.Add("Others")
        Me.KeyPreview = True
        RdoYetConfirm.Checked = True
        RdiChqYes.Checked = True

        mstchqdate.Enabled = False
        txtchqamt.Enabled = False
        TxtBankCode.Enabled = False
        TxtBankName.Enabled = False
        txtaccno.Enabled = False
        txtaccno.Clear()

        PnlMandate.Visible = False
        PnlPdcEntry.Visible = True

        If RdiDiscNo.Checked = True Then
            btnAdd.Enabled = False
        ElseIf RdoYetConfirm.Checked = True Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If

    End Sub
    Public Sub New(ByVal GnsaRefNo As String, ByVal ShortAgreementNo As String)

        ' This call is required by the designer.
        InitializeComponent()
        TxtGnsaRefNo.Text = GnsaRefNo
        TxtAgreementNo.Text = ShortAgreementNo
        lsagreementno = ShortAgreementNo
        ' Add any initialization after the InitializeComponent() call.
        LoadData()
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub LoadData()
        Dim lsSql As String
        Dim ds As New DataSet


        lsSql = ""
        lsSql &= " select packet_gid,packet_gnsarefno,Date_format(packet_receiveddate,'%d-%m-%Y') as packetrecvdate,packet_remarks "
        lsSql &= " from chola_trn_tpacket "
        lsSql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
        lsSql &= " where shortagreement_no='" & TxtAgreementNo.Text & "'"
        lsSql &= " and packet_gnsarefno= '" & TxtGnsaRefNo.Text & "'"

        gpDataSet(lsSql, "Packet", gOdbcConn, ds)

        If ds.Tables("Packet").Rows.Count = 1 Then
            TxtPacketRmk.Text = ds.Tables("Packet").Rows(0).Item("packet_remarks").ToString
            dtbPacketRecv.Text = ds.Tables("Packet").Rows(0).Item("packetrecvdate").ToString
            TxtPacketId.Text = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
            lsPacketGid = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
        End If

        lsSql = ""
        lsSql &= " select inward_agreementno,inward_paymode,inward_customername,inward_tenure,inward_pdc,inward_spdc,inward_mandate,"
        lsSql &= " Date_format(inward_firstemidate,'%d-%m-%Y') as StartDate"
        lsSql &= " from chola_trn_tinward where inward_packet_gid=" & lsPacketGid & ""
        gpDataSet(lsSql, "PacketInward", gOdbcConn, ds)

        If ds.Tables("PacketInward").Rows.Count = 1 Then
            TxtTenorCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_tenure").ToString
        End If

        lsSql = ""
        lsSql &= " Update chola_trn_tpacket set"
        lsSql &= " gnsa_lock_flag='Y' ,"
        lsSql &= " gnsa_lock_date=now(),"
        lsSql &= " gnsa_lock_by='" & gUserName & "'"
        lsSql &= " where packet_gid=" & lsPacketGid
        gfExecuteQry(lsSql, gOdbcConn)

    End Sub
    Private Sub LoadGridData(ByVal lsPacketGid As Integer)
        Dim lsSql As String
        Dim lsScanStatusCode As String
        Dim lnPacketAuditCount As Long


        If rdoPending.Checked = True Then
            lsScanStatusCode = "P"
        Else
            lsScanStatusCode = "C"
        End If

        If rdoPending.Checked = True Then
            lsSql = ""
            lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
            lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
            lsSql &= " from chola_trn_tscan as a inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
            lsSql &= " and packet_status & " & GCPACKETSCANCOMPLETED & " = " & GCPACKETSCANCOMPLETED & " and packet_status & " & GCPACKETSCANAUDITED & " = 0  "
            lsSql &= " and scan_status & " & GCSCANAUDITED & " = 0"
            lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
            lsSql &= " cross join (select @rownr:=0) as t "
            lsSql &= " where scan_packet_gid='" & lsPacketGid & "'"
            gvmChkrEntry.Columns.Clear()
            gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)
            If gvmChkrEntry.Rows.Count > 0 Then
                With gvmChkrEntry
                    .Columns("scan_gid").Visible = False
                    .Columns("scan_packet_gid").Visible = False
                    .Columns("scan_status").Visible = False
                End With
            End If
            CboPcktMode.Focus()
        ElseIf rdoCompleted.Checked = True Then

            lsSql = ""
            lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
            lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
            lsSql &= " from chola_trn_tscan cross join (select @rownr:=0) as t "
            lsSql &= " where scan_status & " & GCSCANAUDITED & " = " & GCSCANAUDITED & " and scan_packet_gid='" & lsPacketGid & "'"
            lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
            gvmChkrEntry.Columns.Clear()
            gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)
            With gvmChkrEntry
                .Columns("scan_gid").Visible = False
                .Columns("scan_packet_gid").Visible = False
                .Columns("scan_status").Visible = False
            End With

        End If

        If lsPacketGid > 0 Then

            lsSql = ""
            lsSql &= " select count(*) from chola_trn_tscan "
            lsSql &= " where scan_packet_gid=" & lsPacketGid & " and scan_status & " & GCSCANAUDITED & " =0  "
            lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"

            lnPacketAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            If lnPacketAuditCount = 0 Then
                MsgBox("Scan Audit Entry Completed Moved to Next Queue", MsgBoxStyle.Information, gProjectName)
                Close()
            End If
        End If
    End Sub

    Private Sub gvmChkrEntry_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvmChkrEntry.SelectionChanged

        Dim rowindex As New Integer

        Dim ScanImageGid As New Integer
        Dim ScanImageSide As String
        Dim lsSql As String
        Dim ds As New DataSet
        Dim dsb As New DataSet
        Dim ObjScanImage As New ScanEntryModel
        Dim lsMicrCode As String = ""



        rowindex = gvmChkrEntry.CurrentCell.RowIndex

        Scangid = gvmChkrEntry.Rows(rowindex).Cells("scan_gid").Value.ToString
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtMicrCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Micr Code").Value.ToString

        If TxtMicrCode.Text <> "" Then
            If TxtMicrCode.Text.Length > 6 Then
                lsMicrCode = TxtMicrCode.Text.Substring(3, 3)
            Else
                TxtMicrCode.Text = ""
            End If
        End If

        lsSql = ""
        lsSql &= " select scanimage_gid,scanimage_side from chola_trn_tscanimage "
        lsSql &= " where scanimage_scan_gid='" & Scangid & "'"
        lsSql &= " and scanimage_type='G' and scanimage_side ='F'"
        gpDataSet(lsSql, "ScanImage", gOdbcConn, ds)

        If ds.Tables("ScanImage").Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ScanImageGid = ds.Tables("ScanImage").Rows(i).Item("scanimage_gid").ToString()
                ScanImageSide = ds.Tables("ScanImage").Rows(i).Item("scanimage_side").ToString()
                ObjScanImage.scanimage_gid = ScanImageGid
                If ScanImageSide = "F" Then

                    ObjScanImage.scanImage_dtls = CallCholaApi(ObjScanImage)

                    If ObjScanImage.scanImage_dtls <> "" Then

                        Dim bytes() As Byte = Convert.FromBase64String(ObjScanImage.scanImage_dtls)
                        Dim MS As New System.IO.MemoryStream(bytes)
                        Dim bmp As Image = Image.FromStream(MS)
                        PicFrontSide.Image = bmp

                    Else

                        lsSql = ""
                        lsSql &= " select scanimage_gid,scanimage_side from chola_trn_tscanimage "
                        lsSql &= " where scanimage_scan_gid='" & Scangid & "'"
                        lsSql &= " and scanimage_type='B' and scanimage_side ='F'"
                        gpDataSet(lsSql, "ScanImage_black", gOdbcConn, dsb)

                        If dsb.Tables("ScanImage_black").Rows.Count > 0 Then

                            ScanImageGid = dsb.Tables("ScanImage_black").Rows(0).Item("scanimage_gid").ToString()
                            ScanImageSide = dsb.Tables("ScanImage_black").Rows(0).Item("scanimage_side").ToString()
                            ObjScanImage.scanimage_gid = ScanImageGid
                            If ScanImageSide = "F" Then
                                ObjScanImage.scanImage_dtls = CallCholaApi(ObjScanImage)
                                If ObjScanImage.scanImage_dtls <> "" Then
                                    Dim bytes() As Byte = Convert.FromBase64String(ObjScanImage.scanImage_dtls)
                                    Dim MS As New System.IO.MemoryStream(bytes)
                                    Dim bmp As Image = Image.FromStream(MS)
                                    PicFrontSide.Image = bmp
                                Else
                                    PicFrontSide.Image = Nothing
                                End If
                            End If
                        End If


                    End If
                    PicBackSide.Image = Nothing
                   

                End If

            Next
        End If

        lsSql = ""
        lsSql &= " select bank_bankcode,bank_bankname from chola_mst_tbank "
        lsSql &= " where bank_micrcode='" & lsMicrCode & "'"
        gpDataSet(lsSql, "BankMaster", gOdbcConn, ds)

        If ds.Tables("BankMaster").Rows.Count > 0 Then
            TxtBankCode.Text = ds.Tables("BankMaster").Rows(0).Item("bank_bankcode").ToString
            TxtBankName.Text = ds.Tables("BankMaster").Rows(0).Item("bank_bankname").ToString
            TxtBankName.Enabled = False
        Else
            TxtBankCode.Text = ""
            TxtBankName.Text = ""
        End If
        CboPcktMode.Focus()

    End Sub


    Private Sub CboPcktMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPcktMode.SelectedIndexChanged
        If CboPcktMode.Text = "SPDC" Then
            mstchqdate.Enabled = False
            txtchqamt.Enabled = True
            TxtBankCode.Enabled = True
            txtaccno.Enabled = True
            'TxtBankCode.Focus()
            txtaccno.ReadOnly = False
            PnlMandate.Visible = False
            PnlPdcEntry.Visible = True
        ElseIf CboPcktMode.Text = "PDC" Then
            mstchqdate.Enabled = True
            txtchqamt.Enabled = True
            TxtBankCode.Enabled = True
            txtaccno.Enabled = True
            PnlMandate.Visible = False
            PnlPdcEntry.Visible = True
            'mstchqdate.Focus()
        ElseIf CboPcktMode.Text = "Others" Then
            mstchqdate.Enabled = False
            txtchqamt.Enabled = False
            TxtBankCode.Enabled = False
            TxtBankName.Enabled = False
            txtaccno.Enabled = False
            PnlMandate.Visible = False
            PnlPdcEntry.Visible = True
            PnlMandate.Visible = False
            PnlPdcEntry.Visible = True
            'TxtRemarks.Focus()
        ElseIf CboPcktMode.Text = "Mandate" Then
            mstchqdate.Enabled = False
            txtchqamt.Enabled = False
            TxtBankCode.Enabled = False
            TxtBankName.Enabled = False
            txtaccno.Enabled = False
            PnlMandate.Visible = True
            PnlPdcEntry.Visible = False
            Pnlchqdtls.Visible = False
            TxtChqNo.Text = ""
            txtchqamt.Text = ""
            'mtxtstartdate.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim lsSql As String
        If MsgBox("Are you sure you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        lsSql = ""
        lsSql &= " Update chola_trn_tpacket set"
        lsSql &= " gnsa_lock_flag='N' ,"
        lsSql &= " gnsa_lock_date=now(),"
        lsSql &= " gnsa_lock_by='" & gUserName & "'"
        lsSql &= " where packet_gid=" & lsPacketGid
        gfExecuteQry(lsSql, gOdbcConn)

        Me.Close()
    End Sub

    Private Sub txtchqamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchqamt.KeyPress
        If e.KeyChar = "13" Then
            SendKeys.Send("{tab}")
            Exit Sub
        End If
        If CboPcktMode.Text = "PDC" Then
            If Not IsDate(mstchqdate.Text) Then
                e.Handled = True
                MsgBox("Please Enter Cheque Date", MsgBoxStyle.Critical, gProjectName)
                ' MessageBox.Show("Please Enter Cheque Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtchqamt.Text = ""
                mstchqdate.Focus()
                Exit Sub
            End If
        End If

        e.Handled = gfAmountEntryOnly(e, txtchqamt)

    End Sub

    Private Sub txtchqamt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtchqamt.Text.ToString() <> "" Then
            Dim currentvalue As String = ""
            If Convert.ToDouble(txtchqamt.Text) > 0 Then
                count += 1
                If count = 1 Then
                    prvvalue = txtchqamt.Text
                    txtchqamt.Clear()
                    txtchqamt.Focus()
                ElseIf count = 2 Then
                    currentvalue = txtchqamt.Text
                    If prvvalue.Equals(currentvalue) Then
                        count = 0
                        prvvalue = ""
                        currentvalue = ""
                    Else
                        count = 0
                        txtchqamt.Clear()
                        txtchqamt.Focus()
                        MsgBox("Amount mismatch ! Reenter the amount", MsgBoxStyle.Critical, gProjectName)

                    End If
                Else
                    count = 0
                    txtchqamt.Clear()
                    txtchqamt.Focus()
                    MsgBox("Reenter The Amount", MsgBoxStyle.MsgBoxHelp, gProjectName)
                End If
            Else

                If CboPcktMode.Text = "PDC" Then
                    MsgBox("Amount Cannot Be Empty", MsgBoxStyle.Critical, gProjectName)
                    txtchqamt.Focus()
                End If
            End If
        Else
            If CboPcktMode.Text = "PDC" Then
                MsgBox("Invalid cheque amount !", MsgBoxStyle.Exclamation, gProjectName)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub TxtBankCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankCode.Leave
        Dim lsSql As String = ""
        Dim ds As New DataSet
        If TxtBankCode.Text <> "" Then
            If TxtBankCode.Text.ToUpper = "XXX" Then
                TxtBankName.Enabled = True
                TxtBankName.Focus()
            ElseIf TxtBankCode.Text <> "" Then
                lsSql = ""
                lsSql &= " select bank_bankcode,bank_bankname from chola_mst_tbank"
                lsSql &= " where bank_bankcode='" & TxtBankCode.Text & "'"
                gpDataSet(lsSql, "BankMaster", gOdbcConn, ds)

                If ds.Tables("BankMaster").Rows.Count > 0 Then
                    TxtBankCode.Text = ds.Tables("BankMaster").Rows(0).Item("bank_bankcode").ToString
                    TxtBankName.Text = ds.Tables("BankMaster").Rows(0).Item("bank_bankname").ToString
                    TxtBankName.Enabled = False
                Else
                    MsgBox("Bank Code not there in Bank Master!", MsgBoxStyle.Critical, gProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
            End If
            'Else
            '    MsgBox("Bank Code Cannot Be Empty", MsgBoxStyle.Critical, gProjectName)
            '    txtchqamt.Focus()
            '    Exit Sub
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If CboPcktMode.Text <> "" Then
            Dim frmDiscEntry As New frmDiscAdd(CboPcktMode.Text)
            frmDiscEntry.ShowDialog()
            TxtDiscValue.Text = GCScanDiscValue
            btnSave.Focus()
        Else
            MsgBox("Packet Mode Cannot Be Empty", MsgBoxStyle.Critical, gProjectName)
        End If

    End Sub

    Private Sub RdiNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiDiscNo.CheckedChanged
        If RdiDiscNo.Checked = True Then
            btnAdd.Enabled = False
            TxtDiscValue.Text = "0"
        End If
    End Sub

    Private Sub RdiYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiDiscYes.CheckedChanged
        If RdiDiscYes.Checked = True Then
            btnAdd.Enabled = True
        End If
    End Sub

    Private Function CallCholaApi(ByVal ObjScanImage As ScanEntryModel) As String

        Dim reqString() As Byte
        Dim resByte As Byte()
        Dim responseFromApi As String
        '  Dim endPoint As String = "http://169.38.77.190:105/api/Scan/viewimage"
        'Dim endPoint As String = "http://192.168.0.154:8503/api/Scan/viewimage"
        Dim endPoint As String = "http://192.168.0.22:105/api/Scan/viewimage"
        Dim client As WebClient = New WebClient()
        client.Headers("Content-type") = "application/json"
        client.Encoding = System.Text.Encoding.UTF8
        Dim jsonReq = JsonConvert.SerializeObject(ObjScanImage, Formatting.Indented)
        reqString = System.Text.Encoding.Default.GetBytes(jsonReq)

        resByte = client.UploadData(endPoint, "post", reqString)
        responseFromApi = System.Text.Encoding.Default.GetString(resByte)
        Dim tempPost = New With {Key .scanImage_dtls = ""}
        Dim post = JsonConvert.DeserializeAnonymousType(responseFromApi, tempPost)
        Dim scandetails As String = post.scanImage_dtls
        Return scandetails

    End Function

    Private Sub frmImageBaseEntry_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'pnlHeader.Width = Me.Width - pnlHeader.Left * 2 - 8

        pnlEntry.Width = 264
        Pnlchqdtls.Width = 264
        PnlPdcEntry.Width = 264
        PnlMandate.Width = 264
        PnlBankdtls.Width = 264

        PicFrontSide.Top = pnlHeader.Top + pnlHeader.Height + 8
        PicFrontSide.Left = pnlHeader.Left
        PicFrontSide.Width = Me.Width - pnlEntry.Width - 48
        PicFrontSide.Height = Me.Height - PicFrontSide.Top - pnlChq.Height - 40

        pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8
        Pnlchqdtls.Left = pnlEntry.Left
        PnlPdcEntry.Left = pnlEntry.Left
        PnlMandate.Left = pnlEntry.Left
        PnlBankdtls.Left = pnlEntry.Left

        pnlChq.Top = PicFrontSide.Top + PicFrontSide.Height + 8
        pnlChq.Width = Me.Width - 20

        gvmChkrEntry.Height = pnlChq.Height - 32

        'pnlChq.Top =
        'pnlChq.Left = pnlHeader.Left
        'pnlChq.Width = Me.Width - pnlChq.Left * 2
        'pnlChq.Height = Me.Height - pnlChq.Top - 56

        'gvmChkrEntry.Height = pnlChq.Height - gvmChkrEntry.Top
        'gvmChkrEntry.Left = 0
        'gvmChkrEntry.Width = pnlChq.Width

        'pnlEntry.Top = PicFrontSide.Top
        'pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8

        'Pnlchqdtls.Top = PicFrontSide.Top
        'Pnlchqdtls.Left = PicFrontSide.Left + PicFrontSide.Width + 8

        'PnlPdcEntry.Top = PicFrontSide.Top
        'PnlPdcEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8

        'PnlMandate.Top = PicFrontSide.Top
        'PnlMandate.Left = PicFrontSide.Left + PicFrontSide.Width + 8

        'PnlBankdtls.Top = PicFrontSide.Top
        'PnlBankdtls.Left = PicFrontSide.Left + PicFrontSide.Width + 8


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim drpacket As Odbc.OdbcDataReader
        Dim drpdc As Odbc.OdbcDataReader

        Dim lnAgreementGid As Long
        Dim lnPacketGid As Long
        Dim lnpdcgid As Long
        Dim lnMicrGid As Long
        Dim lnEntryGid As Long

        Dim lsScanStatus As Long = 0
        Dim lsSql As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqAmount As Long = 0
        Dim lsPacketMode As String = ""
        Dim lsScanVisibility As String = ""
        Dim lsScanDiscFlag As String = ""
        Dim lnAuditCount As Long = 0
        Dim lnReScanCount As Long = 0
        Dim lsEntryMode As String = ""

        Dim lschqdisc As String = ""
        Dim lsiscts As Char = ""
        Dim liProduct As Integer
        Dim lcPacketDisc As String = ""

        Dim lspap As String = ""
        Dim lsMicrCode As String = ""

        Dim lsChqMode As String = ""
        Dim lcChqDisc As String = ""

        Dim lsismicr As String = ""
        Dim liType As Integer
        Dim lnTenorCycle As Integer

        Dim lsStartDate As String = ""
        Dim lsEndDate As String = ""

        Dim lnChqNo As Long = 0
        Dim lnAccNo As Long = 0

        Dim n As Integer


        If MsgBox("Are you sure you want to Submit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtchqamt.Text <> "" Then
            lsChqAmount = txtchqamt.Text
        End If

        If RdiChqYes.Checked = True Then

            If CboPcktMode.Text = "" Then
                MsgBox("Please Select Packet Mode..!", MsgBoxStyle.Critical, gProjectName)
                CboPcktMode.Focus()
                Exit Sub
            End If

            If RdoYetConfirm.Checked = True Then
                MsgBox("Please Confirm Disc Mode..!", MsgBoxStyle.Critical, gProjectName)
                RdoYetConfirm.Focus()
                Exit Sub
            End If

            If CboPcktMode.Text.ToUpper = "PDC" Then

                If TxtChqNo.Text = "" Then
                    MsgBox("Please Enter the Cheque No..!", MsgBoxStyle.Critical, gProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtMicrCode.Text = "" Then
                    MsgBox("Please Enter the Micr Code..!", MsgBoxStyle.Critical, gProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If Not IsDate(mstchqdate.Text) Then
                    MsgBox("Please Enter the Cheque Date..!", MsgBoxStyle.Critical, gProjectName)
                    mstchqdate.Focus()
                    Exit Sub
                End If
                If Convert.ToDouble(txtchqamt.Text) = 0 Then
                    MsgBox("Cheque Amount Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    txtchqamt.Focus()
                    Exit Sub
                End If
                If TxtBankCode.Text = "" Then
                    MsgBox("Bank Code Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
                If TxtBankName.Text = "" Then
                    MsgBox("Bank Name Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    TxtBankName.Focus()
                    Exit Sub
                End If
                If txtaccno.Text = "" Then
                    MsgBox("Acc No Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    txtaccno.Focus()
                    Exit Sub
                End If
                If lnCyclegid < 0 Then
                    RdiDiscYes.Checked = True
                    If RdiDiscYes.Checked = True Then
                        If TxtDiscValue.Text = "" Or TxtDiscValue.Text = "0" Then
                            MsgBox("Invalid Cycle date Cheque date. Please select disc list.!", MsgBoxStyle.Critical, gProjectName)
                            Exit Sub
                        End If
                    End If
                End If

            ElseIf CboPcktMode.Text.ToUpper = "SPDC" Then
                If TxtChqNo.Text = "" Then
                    MsgBox("Please Enter the Cheque No..!", MsgBoxStyle.Critical, gProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtMicrCode.Text = "" Then
                    MsgBox("Please Enter the Micr Code..!", MsgBoxStyle.Critical, gProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtBankCode.Text = "" Then
                    MsgBox("Bank Code Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
                If TxtBankName.Text = "" Then
                    MsgBox("Bank Name Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    TxtBankName.Focus()
                    Exit Sub
                End If
                If txtaccno.Text = "" Then
                    MsgBox("Acc No Cannot be empty..!", MsgBoxStyle.Critical, gProjectName)
                    txtaccno.Focus()
                    Exit Sub
                End If
                If txtchqamt.Text = "" Then
                    lsChqAmount = 0
                End If
            End If
            lsScanStatus = GCSCANVALID
        End If



        If RdiDiscYes.Checked = True Then
            If TxtDiscValue.Text = "" Or TxtDiscValue.Text = "0" Then
                MsgBox("Please Select Disc List..!", MsgBoxStyle.Critical, gProjectName)
                btnAdd.Focus()
                Exit Sub
            End If

            If txtchqamt.Text = "" Then
                lsChqAmount = 0
            End If
            lsScanStatus = GCSCANINVALID
        End If

        If CboPcktMode.Text.ToUpper = "PDC" Then
            lsPacketMode = "P"
        ElseIf CboPcktMode.Text = "SPDC" Then
            lsPacketMode = "S"
        ElseIf CboPcktMode.Text.ToUpper = "OTHERS" Then
            lsPacketMode = "O"
        ElseIf CboPcktMode.Text.ToUpper = "MANDATE" Then
            lsPacketMode = "M"
        End If

        If RdiChqNo.Checked = True Then
            lsScanVisibility = "N"
        ElseIf RdiChqYes.Checked = True Then
            lsScanVisibility = "Y"
        End If

        If RdiDiscNo.Checked = True Then
            lsScanDiscFlag = "N"
        ElseIf RdiDiscYes.Checked = True Then
            lsScanDiscFlag = "Y"
        End If

        If Not IsDate(mstchqdate.Text) Then
            lsChqDate = "null"
        Else
            lsChqDate = Format(CDate(mstchqdate.Text.Trim), "yyyy-MM-dd")
        End If

        If Not IsDate(mtxtstartdate.Text) Then
            lsStartDate = "null"
        Else
            lsStartDate = Format(CDate(mtxtstartdate.Text.Trim), "yyyy-MM-dd")
        End If

        If Not IsDate(mtxtenddate.Text) Then
            lsEndDate = "null"
        Else
            lsEndDate = Format(CDate(mtxtenddate.Text.Trim), "yyyy-MM-dd")
        End If




        lsSql = " select * from chola_trn_tpacket"
        lsSql &= " where packet_gnsarefno='" & TxtGnsaRefNo.Text & "'"

        drpacket = gfExecuteQry(lsSql, gOdbcConn)

        If drpacket.HasRows Then
            While drpacket.Read
                lnAgreementGid = Val(drpacket.Item("packet_agreement_gid").ToString)
                lnPacketGid = Val(drpacket.Item("packet_gid").ToString)
            End While
        Else
            MsgBox("Invalid Packet", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, gProjectName)
            Exit Sub
        End If

        lsSql = ""
        lsSql &= " select agreement_prodtype "
        lsSql &= " from chola_mst_tagreement "
        lsSql &= " where agreement_gid=" & lnAgreementGid

        liProduct = Val(gfExecuteScalar(lsSql, gOdbcConn))

        lsSql = ""
        lsSql &= " select pdc_mode "
        lsSql &= " from chola_trn_tpdcfile "
        lsSql &= " where pdc_shortpdc_parentcontractno='" & lsagreementno & "'"

        lsEntryMode = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If (lsEntryMode = "PDC" Or lsEntryMode = "RPDC") And CboPcktMode.Text.ToUpper = "PDC" Then
            lcPacketDisc = "N"
        ElseIf (lsEntryMode = "ECS" Or lsEntryMode = "NPDC") And CboPcktMode.Text.ToUpper = "SPDC" Then
            lcPacketDisc = "N"
        Else
            lcPacketDisc = "Y"
        End If

        'Update Scan Table
        lnChqNo = Val(TxtChqNo.Text.Trim)
        lnAccNo = Val(txtaccno.Text.Trim)

        If RdiChqNo.Checked = True Then
            If txtchqamt.Text = "" Then
                lsChqAmount = 0
            End If
            lsScanStatus = GCSCANRESCAN
        End If

        lsSql = ""
        lsSql &= " update chola_trn_tscan set"
        lsSql &= " scan_chq_no='" & lnChqNo & "',"
        lsSql &= " scan_micr_code='" & TxtMicrCode.Text & "',"
        lsSql &= " scan_chq_date='" & lsChqDate & "',"
        lsSql &= " scan_chq_amount='" & lsChqAmount & "',"
        lsSql &= " scan_chq_accno='" & lnAccNo & "',"
        lsSql &= " scan_bank_code='" & TxtBankCode.Text & "',"
        lsSql &= " scan_bank_name='" & TxtBankName.Text & "',"
        lsSql &= " scan_chq_type='" & lsPacketMode & "',"
        lsSql &= " scan_visibility='" & lsScanVisibility & "',"
        lsSql &= " disc_flag='" & lsScanDiscFlag & "',"
        lsSql &= " scan_disc_value='" & TxtDiscValue.Text & "',"
        lsSql &= " scan_status= scan_status | " & GCSCANAUDITED & " |" & lsScanStatus & ","
        lsSql &= " scan_start_date='" & lsStartDate & "',"
        lsSql &= " scan_end_date='" & lsEndDate & "',"
        lsSql &= " scan_tenor_count=" & lnTenorCycle & ","
        lsSql &= " scan_remark='" & TxtRemarks.Text & "',"
        lsSql &= " scan_entry_date=now()"
        lsSql &= " where scan_gid=" & Scangid
        lsSql &= " and scan_packet_gid=" & lnPacketGid

        gfExecuteQry(lsSql, gOdbcConn)


        lsSql = ""
        lsSql &= " select count(*) from chola_trn_tscan "
        lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANAUDITED & " =0 "
        lsSql &= " and scan_status & " & GCSCANCANCELED & " =0 "

        lnAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If lnAuditCount = 0 Then
            lsSql = ""
            lsSql &= " select count(*) from chola_trn_tscan "
            lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANRESCAN & " >0  "
            lnReScanCount = Val(gfExecuteScalar(lsSql, gOdbcConn))
        End If

        If lnAuditCount = 0 And lnReScanCount > 0 Then
            lsSql = ""
            lsSql &= " Update chola_trn_tpacket set"
            lsSql &= " packet_status=(packet_status | " & GCPACKETRESCAN & ") ^ " & GCPACKETSCANCOMPLETED & ","
            lsSql &= " gnsa_lock_flag='N' ,"
            lsSql &= " gnsa_lock_date=now(),"
            lsSql &= " gnsa_lock_by='" & gUserName & "'"
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)

        End If

        If RdiDiscYes.Checked = True Then
            lsSql = ""
            lsSql &= " Update chola_trn_tpacket set"
            lsSql &= " packet_status=(packet_status | " & GCPACKETDISC & " | " & GCPACKETCHEQUEENTRY & ") ^ " & GCPACKETCHEQUEENTRY & ""
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)


        End If

        If lnReScanCount = 0 Then
            If RdiChqYes.Checked = True Then
                If CboPcktMode.Text.ToUpper = "PDC" Then

                    'Cheque Disc
                    lsSql = ""
                    lsSql = " select pdc_gid,atpar_flag,pdc_chqdate,pdc_micrcode,pdc_mode,pdc_type from chola_trn_tpdcfile where chq_rec_slno=1 "
                    lsSql &= " and pdc_chqno = " & Val(TxtChqNo.Text.ToString) & " "
                    lsSql &= " and pdc_shortpdc_parentcontractno='" & lsagreementno & "'"

                    lsSql &= " and pdc_ecsentry_gid = 0 "
                    lsSql &= " and (entry_gid is null or entry_gid = 0) "
                    lsSql &= " and pdc_spdcentry_gid = 0 "
                    lsSql &= " and chq_rec_slno = 1 "

                    drpdc = gfExecuteQry(lsSql, gOdbcConn)

                    If drpdc.HasRows Then
                        While drpdc.Read
                            lnpdcgid = drpdc.Item("pdc_gid").ToString
                            lspap = drpdc.Item("atpar_flag").ToString
                            lsMicrCode = drpdc.Item("pdc_micrcode").ToString
                            lsChqMode = drpdc.Item("pdc_type").ToString

                            If lsChqDate <> "" Then
                                If Format(CDate(drpdc.Item("pdc_chqdate").ToString), "yyyy-MM-dd") <> lsChqDate Then
                                    lschqdisc = GCCHQDATENOTAVBL
                                End If
                            Else
                                lschqdisc = GCZERO
                            End If

                        End While
                    Else
                        lnpdcgid = GCZERO
                        lschqdisc = GCCHQNONOTAVBL
                    End If

                    If "EXTERNAL-NORMAL" <> lsChqMode.ToUpper Then
                        lcChqDisc = "Y"
                    Else
                        lcChqDisc = "N"
                    End If

                    'If lspap = "Y" And dtpdcentry.Rows(i).Item("PAP/NONPAP").ToString <> "PAP" Then   'Doubt
                    '    lschqdisc &= "|" & GCPAPCHANGED
                    'End If

                    lsismicr = "Y"

                    If lschqdisc = "" Then
                        lschqdisc = GCZERO
                    End If

                    lsiscts = "Y"

                    'MICR CODE
                    lsSql = " select micr_gid "
                    lsSql &= " from chola_mst_tspeedmicr "
                    lsSql &= " where micr_code='" & lsMicrCode & "'"

                    lnMicrGid = Val(gfExecuteScalar(lsSql, gOdbcConn))

                    liType = GCEXTERNALNORMAL

                    lspap = "Y"

                    'Product
                    If liProduct = 0 Then
                        liProduct = GCOTHERS
                    End If

                    lsSql = ""
                    lsSql &= " insert into chola_trn_tpdcentry(chq_packet_gid,chq_agreement_gid,chq_pdc_gid,"
                    lsSql &= " chq_no,chq_date,chq_amount,chq_type,chq_papflag,chq_prodtype,"
                    lsSql &= " chq_iscts,chq_ismicr,chq_paymodedisc,"
                    lsSql &= " chq_disc_value,chq_micrcode,chq_bankcode,chq_bankname,chq_accno,chq_status) values("
                    lsSql &= "" & lnPacketGid & ","
                    lsSql &= "" & lnAgreementGid & ","
                    lsSql &= "" & lnpdcgid & ","
                    lsSql &= "'" & lnChqNo & "',"
                    lsSql &= "'" & lsChqDate & "',"
                    lsSql &= "'" & lsChqAmount & "',"
                    lsSql &= "" & liType & ","
                    lsSql &= "'" & lspap & "',"
                    lsSql &= "" & liProduct & ","
                    lsSql &= "'" & lsiscts & "',"
                    lsSql &= "'" & lsismicr & "',"
                    lsSql &= "'" & lcChqDisc & "',"
                    lsSql &= " chq_disc_value|" & lschqdisc & ","
                    lsSql &= "'" & TxtMicrCode.Text & "',"
                    lsSql &= "'" & TxtBankCode.Text & "',"
                    lsSql &= "'" & TxtBankName.Text & "',"
                    lsSql &= "'" & lnAccNo & "',"
                    lsSql &= "chq_status|" & GCENTRY & ""
                    lsSql &= ")"

                    gfInsertQry(lsSql, gOdbcConn)

                    lsSql = " select entry_gid from chola_trn_tpdcentry "
                    lsSql &= " where chq_no='" & lnChqNo & "'"
                    lsSql &= " and chq_packet_gid=" & lnPacketGid & ""

                    lnEntryGid = Val(gfExecuteScalar(lsSql, gOdbcConn))

                    'Update in Base File
                    lsSql = ""
                    lsSql &= " UPDATE"
                    lsSql &= " chola_trn_tpdcfile"
                    lsSql &= " set"
                    lsSql &= " entry_gid=" & lnEntryGid & ","
                    lsSql &= " atpar_flag='" & lspap & "',"
                    lsSql &= " prod_type=" & liProduct & ","
                    lsSql &= " org_chqdate=" & lsChqDate & ","
                    lsSql &= " org_chqamount=" & Val(lsChqAmount) & ","
                    lsSql &= " pdc_status_flag=pdc_status_flag|" & GCENTRY & ","
                    lsSql &= " file_lock='N',lock_by=null "
                    lsSql &= " where pdc_gid = " & lnpdcgid
                    lsSql &= " and pdc_ecsentry_gid = 0 "
                    lsSql &= " and (entry_gid is null or entry_gid = 0) "
                    lsSql &= " and pdc_spdcentry_gid = 0 "

                    gfExecuteQry(lsSql, gOdbcConn)

                    'Update in Scan Table 
                    lsSql = ""
                    lsSql &= " Update chola_trn_tscan set "
                    lsSql &= " scan_chq_type='" & lsPacketMode & "',"
                    lsSql &= " scan_chq_gid=" & lnEntryGid & ""
                    lsSql &= " where scan_chq_no='" & lnChqNo & "'"
                    lsSql &= " and scan_packet_gid=" & lnPacketGid & ""
                    lsSql &= " and scan_gid=" & Scangid
                    gfInsertQry(lsSql, gOdbcConn)

                ElseIf CboPcktMode.Text.ToUpper = "SPDC" Then

                    Dim lnEPdcGid As Long
                    Dim lnEentryGid As Long

                    lsSql = ""
                    lsSql &= " select pdc_gid,pdc_type "
                    lsSql &= " from chola_trn_tpdcfile "
                    lsSql &= " where pdc_shortpdc_parentcontractno='" & lsagreementno & "'"
                    lsSql &= " and pdc_chqno = " & Val(TxtChqNo.Text.ToString)
                    lsSql &= " and pdc_ecsentry_gid = 0 "
                    lsSql &= " and (entry_gid is null or entry_gid = 0) "
                    lsSql &= " and pdc_spdcentry_gid = 0 "
                    lsSql &= " and chq_rec_slno = 1 "

                    drpdc = gfExecuteQry(lsSql, gOdbcConn)

                    If drpdc.HasRows Then
                        While drpdc.Read
                            lnEPdcGid = drpdc.Item("pdc_gid").ToString
                            lsChqMode = drpdc.Item("pdc_type").ToString
                        End While
                    Else
                        lnEPdcGid = 0
                        lsChqMode = ""
                    End If

                    If lsChqMode.ToUpper <> "EXTERNAL-SECURITY" Then
                        lcChqDisc = "Y"
                    Else
                        lcChqDisc = "N"
                    End If

                    lsiscts = "Y"

                    lsismicr = "Y"

                    lsSql = ""
                    lsSql &= " insert into chola_trn_tspdcchqentry(chqentry_packet_gid,chqentry_pdc_gid,chqentry_chqno,chqentry_micrcode,"
                    lsSql &= " chqentry_bankcode,chqentry_bankname,chqentry_accno,chqentry_iscts,chqentry_ismicr,chqentry_paymodedisc,"
                    lsSql &= " chqentry_entryby,chqentry_entryon,chqentry_remarks) values("
                    lsSql &= "" & lnPacketGid & ","
                    lsSql &= "" & lnEPdcGid & ","
                    lsSql &= "'" & lnChqNo & "',"
                    lsSql &= "'" & TxtMicrCode.Text & "',"
                    lsSql &= "'" & TxtBankCode.Text & "',"
                    lsSql &= "'" & TxtBankName.Text & "',"
                    lsSql &= "'" & lnAccNo & "',"
                    lsSql &= "'" & lsiscts & "',"
                    lsSql &= "'" & lsismicr & "',"
                    lsSql &= "'" & lcChqDisc & "',"
                    lsSql &= "'" & gUserName & "',"
                    lsSql &= " sysdate(),"
                    lsSql &= "'" & TxtRemarks.Text & "'"
                    lsSql &= ")"

                    gfInsertQry(lsSql, gOdbcConn)


                    lsSql = ""
                    lsSql &= " select chqentry_gid "
                    lsSql &= " from chola_trn_tspdcchqentry "
                    lsSql &= " where chqentry_packet_gid=" & lnPacketGid
                    lsSql &= " and chqentry_chqno='" & lnChqNo & "'"
                    lsSql &= " and chqentry_pdc_gid=" & lnEPdcGid

                    lnEentryGid = Val(gfExecuteScalar(lsSql, gOdbcConn))

                    lsSql = ""
                    lsSql &= " update chola_trn_tpdcfile "
                    lsSql &= " set pdc_spdcentry_gid=" & lnEentryGid
                    lsSql &= " where pdc_gid=" & lnEPdcGid
                    gfInsertQry(lsSql, gOdbcConn)

                    'Update in Scan Table 
                    lsSql = ""
                    lsSql &= " Update chola_trn_tscan set "
                    lsSql &= " scan_chq_type='" & lsPacketMode & "',"
                    lsSql &= " scan_chq_gid=" & lnEentryGid & ""
                    lsSql &= " where scan_chq_no='" & lnChqNo & "'"
                    lsSql &= " and scan_packet_gid=" & lnPacketGid & ""
                    lsSql &= " and scan_gid=" & Scangid
                    gfInsertQry(lsSql, gOdbcConn)

                End If
            End If
        End If

        If RdiChqYes.Checked = True Then
            If lnAuditCount = 0 And lnReScanCount = 0 Then

                lsSql = ""
                lsSql &= " Update chola_trn_tpacket set"
                lsSql &= " packet_status=packet_status | " & GCPACKETSCANAUDITED & " | " & GCPACKETCHEQUEENTRY & ", "
                lsSql &= " gnsa_lock_flag='N',"
                lsSql &= " gnsa_lock_date=now(),"
                lsSql &= " gnsa_lock_by='" & gUserName & "'"
                lsSql &= " where packet_gid=" & lnPacketGid
                gfExecuteQry(lsSql, gOdbcConn)

                'LogPacket("", GCPACKETCHEQUEENTRY, lnPacketGid, CboPcktMode.Text.ToUpper, , , "N", "N")
                UpdateAlmara(TxtGnsaRefNo.Text, CboPcktMode.Text.ToUpper)
                LogPacketHistory("", GCPACKETCHEQUEENTRY, lnPacketGid)

            End If
        End If


        TxtChqNo.Text = ""
        mstchqdate.Text = ""
        txtchqamt.Text = ""
        TxtBankCode.Text = ""
        TxtBankName.Text = ""
        'txtaccno.Text = ""
        TxtRemarks.Text = ""
        TxtDiscValue.Text = 0
        RdoYetConfirm.Checked = True
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub RdiChqYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqYes.CheckedChanged
        If RdiChqYes.Checked = True Then
            Pnlchqdtls.Enabled = True
            PnlPdcEntry.Enabled = True
            Panel2.Enabled = True
            PnlMandate.Enabled = True
        End If
    End Sub

    Private Sub RdiChqNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqNo.CheckedChanged
        If RdiChqNo.Checked = True Then
            Pnlchqdtls.Enabled = False
            PnlPdcEntry.Enabled = False
            Panel2.Enabled = False
            PnlMandate.Enabled = False
        End If
        TxtRemarks.Focus()
    End Sub

    Private Sub rdoPending_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPending.CheckedChanged
        LoadGridData(lsPacketGid)
        btnSave.Enabled = True
    End Sub

    Private Sub rdoCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCompleted.CheckedChanged
        LoadGridData(lsPacketGid)
        btnSave.Enabled = False
    End Sub

    Private Sub TxtTenorCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTenorCount.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub TxtChqNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChqNo.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub TxtMicrCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMicrCode.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub mstchqdate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstchqdate.Leave
        Dim lschqday As String
        Dim lsSql As String

        If CboPcktMode.Text = "PDC" Then
            If Not IsDate(mstchqdate.Text) Then
                Exit Sub
            Else
                lschqday = Format(CDate(mstchqdate.Text.Trim), "dd")

                lsSql = ""
                lsSql &= " select cycle_gid "
                lsSql &= " from chola_mst_tcycle "
                lsSql &= " where cycle_day=" & lschqday

                lnCyclegid = Val(gfExecuteScalar(lsSql, gOdbcConn))
                If lnCyclegid = 0 Then

                    If MsgBox("Invalid Cycle date ! Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
                        mstchqdate.Focus()
                    Else
                        RdiDiscNo.Checked = False
                        RdiDiscYes.Checked = True
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub frmImageBaseEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub pnlEntry_Paint(sender As Object, e As PaintEventArgs) Handles pnlEntry.Paint

    End Sub
End Class