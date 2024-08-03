Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Public Class frmFinnOneImageEntry
    Dim count As Integer = 0
    Dim prvvalue As String = ""
    Dim Scangid As New Integer
    Dim lsPacketGid As Integer = 0
    Dim lsagreementno As String = ""
    Dim lnCyclegid As Integer = 0
    Private Sub frmImageBaseEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        Dim lsSql As String
        RdiChqYes.Checked = True

        lsSql = " select disc_gid,disc_desc from chola_mst_tfinnonedisc  order by disc_gid "
        gpBindCombo(lsSql, "disc_desc", "disc_gid", CboFinnoneDisc, gOdbcConn)
        CboFinnoneDisc.Enabled = False
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
            TxtAgreementId.Text = ds.Tables("PacketInward").Rows(0).Item("inward_agreementno").ToString
            TxtPayMode.Text = ds.Tables("PacketInward").Rows(0).Item("inward_paymode").ToString
            TxtCustomerName.Text = ds.Tables("PacketInward").Rows(0).Item("inward_customername").ToString
            TxtTenureCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_tenure").ToString
            TxtPdcCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_pdc").ToString
            TxtSpdcCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_spdc").ToString
            TxtMandateCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_mandate").ToString
            dtpStartDate.Text = ds.Tables("PacketInward").Rows(0).Item("StartDate").ToString
        End If

        lsSql = ""
        lsSql &= " Update chola_trn_tpacket set"
        lsSql &= " fin_lock_flag='Y' ,"
        lsSql &= " fin_lock_date=now(),"
        lsSql &= " fin_lock_by='" & gUserName & "'"
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
        If lsPacketGid > 0 Then

            lsSql = ""
            lsSql &= " select inward_agreementno "
            lsSql &= " from chola_trn_tinward where inward_parent_agreementno='" & TxtAgreementId.Text & "'"
            gvmChildAgreement.Columns.Clear()
            gpPopGridView(gvmChildAgreement, lsSql, gOdbcConn)
            If gvmChildAgreement.Rows.Count > 0 Then
                With (gvmChildAgreement)
                    .Columns("inward_agreementno").Width = 150
                End With
            End If

            If rdoPending.Checked = True Then
                lsSql = ""
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
                lsSql &= " from chola_trn_tscan as a inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
                lsSql &= " and packet_status & " & GCPACKETSCANCOMPLETED & " = " & GCPACKETSCANCOMPLETED & " and packet_status & " & GCPACKETFINONEAUDITED & " = 0  "
                lsSql &= " and scan_status & " & GCSCANFINONEAUDITED & " = 0"
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

            ElseIf rdoCompleted.Checked = True Then

                lsSql = ""
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
                lsSql &= " from chola_trn_tscan cross join (select @rownr:=0) as t "
                lsSql &= " where scan_status & " & GCSCANFINONEAUDITED & " = " & GCSCANFINONEAUDITED & " and scan_packet_gid='" & lsPacketGid & "'"
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
                lsSql &= " where scan_packet_gid=" & lsPacketGid & " and scan_status & " & GCSCANFINONEAUDITED & " =0  "
                lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"

                lnPacketAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

                If lnPacketAuditCount = 0 Then
                    MsgBox("FinnOne Image Based Entry Completed Moved to Next Queue", MsgBoxStyle.Information, gProjectName)
                    Close()
                End If

            End If
        End If
    End Sub

    Private Sub gvmChkrEntry_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvmChkrEntry.SelectionChanged

        Dim rowindex As New Integer

        Dim ScanImageGid As New Integer
        Dim ScanImageSide As String
        Dim lsSql As String
        Dim ds As New DataSet
        Dim ObjScanImage As New ScanEntryModel
        Dim lsMicrCode As String = ""



        rowindex = gvmChkrEntry.CurrentCell.RowIndex
        Scangid = gvmChkrEntry.Rows(rowindex).Cells("scan_gid").Value.ToString

        TxtChequeNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtMicrCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Micr Code").Value.ToString


        If TxtMicrCode.Text <> "" Then
            If TxtMicrCode.Text.Trim.Length >= 6 Then
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
                        gpDataSet(lsSql, "ScanImage", gOdbcConn, ds)

                        If ds.Tables("ScanImage").Rows.Count > 0 Then

                            ScanImageGid = ds.Tables("ScanImage").Rows(0).Item("scanimage_gid").ToString()
                            ScanImageSide = ds.Tables("ScanImage").Rows(0).Item("scanimage_side").ToString()
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

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim lssql As String
        If MsgBox("Are you sure you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        lssql = ""
        lssql &= " Update chola_trn_tpacket set"
        lssql &= " fin_lock_flag='N' ,"
        lssql &= " fin_lock_date=now(),"
        lssql &= " fin_lock_by='" & gUserName & "'"
        lssql &= " where packet_gid=" & lsPacketGid
        gfExecuteQry(lssql, gOdbcConn)

        Me.Close()
    End Sub
    Private Function CallCholaApi(ByVal ObjScanImage As ScanEntryModel) As String

        Dim reqString() As Byte
        Dim resByte As Byte()
        Dim responseFromApi As String
        ' Dim endPoint As String = "http://169.38.77.190:105/api/Scan/viewimage"
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
        pnlEntry.Width = 264

        'pnlHeader.Width = Me.Width - pnlHeader.Left * 2 - 8

        PicFrontSide.Top = pnlHeader.Top + pnlHeader.Height + 8
        PicFrontSide.Left = pnlHeader.Left
        PicFrontSide.Width = Me.Width - pnlEntry.Width - 48
        PicFrontSide.Height = Me.Height - PicFrontSide.Top - pnlChq.Height - 40

        pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8
        pnlEntry.Top = PicFrontSide.Top

        pnlChq.Left = pnlHeader.Left

        pnlChq.Top = PicFrontSide.Top + PicFrontSide.Height + 8
        pnlChq.Width = Me.Width - 32

        gvmChkrEntry.Height = pnlChq.Height - 32
        gvmChkrEntry.Width = pnlChq.Width
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

        Dim n As Integer

        Dim lnFinnOneStatus As Long
        Dim lnInvaliCount As Long = 0

        If MsgBox("Are you sure you want to Submit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        If RdoYetConfirm.Checked = True Then
            MsgBox("Please Confirm Disc Mode..!", MsgBoxStyle.Critical, gProjectName)
            RdoYetConfirm.Focus()
            Exit Sub
        End If

        If RdiChqNo.Checked = True Then
            lsScanVisibility = "N"
        ElseIf RdiChqYes.Checked = True Then
            lsScanVisibility = "Y"
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
        If RdiYes.Checked = True Then
            If CboFinnoneDisc.Text.Trim = "" Or CboFinnoneDisc.SelectedIndex = -1 Then
                MsgBox("Please select the Disc list", MsgBoxStyle.Information, gProjectName)
                CboFinnoneDisc.Focus()
                Exit Sub
            End If
        End If

        If RdiNo.Checked = True Then
            lnFinnOneStatus = GCSCANFINONEVALID
        ElseIf RdiYes.Checked = True Then
            lnFinnOneStatus = GCSCANFINONEINVALID
        End If

        'Update Scan Table
        If RdiChqYes.Checked = True Then
            lsSql = ""
            lsSql &= " update chola_trn_tscan set"
            lsSql &= " scan_visibility='" & lsScanVisibility & "',"
            lsSql &= " scan_status= scan_status | " & GCSCANFINONEAUDITED & " |" & lnFinnOneStatus & ","
            lsSql &= " scan_finnone_disc='" & CboFinnoneDisc.Text & "',"
            lsSql &= " scan_entry_date= now() "
            lsSql &= " where scan_gid=" & Scangid
            lsSql &= " and scan_packet_gid=" & lnPacketGid

            gfExecuteQry(lsSql, gOdbcConn)

        ElseIf RdiChqNo.Checked = True Then
            lsSql = ""
            lsSql &= " update chola_trn_tscan set"
            lsSql &= " scan_visibility='" & lsScanVisibility & "',"
            lsSql &= " scan_status= scan_status | " & GCSCANFINONEAUDITED & " | " & GCSCANRESCAN & ","
            lsSql &= " scan_entry_date= now()"
            lsSql &= " where scan_gid=" & Scangid
            lsSql &= " and scan_packet_gid=" & lnPacketGid

            gfExecuteQry(lsSql, gOdbcConn)
        End If


        lsSql = ""
        lsSql &= " select count(*) from chola_trn_tscan "
        lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANFINONEAUDITED & " =0  "
        lsSql &= " and scan_status & " & GCSCANCANCELED & " =0 "
        lnAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If lnAuditCount = 0 Then
            lsSql = ""
            lsSql &= " select count(*) from chola_trn_tscan "
            lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANRESCAN & " >0  "
            lnReScanCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            'lsSql = ""
            'lsSql &= " select count(*) from chola_trn_tscan "
            'lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANFINONEINVALID & " >0 "
            'lnInvaliCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

        End If

        If RdiYes.Checked = True Then
            lsSql = ""
            lsSql &= " Update chola_trn_tpacket set"
            lsSql &= " packet_status=(packet_status | " & GCPACKETFINONEDISC & " | " & GCPACKETCHEQUEENTRY & " | " & GCPACKETDISC & ") ^ " & GCPACKETCHEQUEENTRY & ""
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)
        End If


        If lnAuditCount = 0 And lnReScanCount > 0 Then
            lsSql = ""
            lsSql &= " Update chola_trn_tpacket set"
            lsSql &= " packet_status=(packet_status | " & GCPACKETRESCAN & ") ^ " & GCPACKETSCANCOMPLETED & ","
            lsSql &= " fin_lock_flag='N' ,"
            lsSql &= " fin_lock_date=now(),"
            lsSql &= " fin_lock_by='" & gUserName & "'"
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)

        End If

        If lnAuditCount = 0 And lnReScanCount = 0 Then
            lsSql = ""
            lsSql &= " Update chola_trn_tpacket set"
            lsSql &= " packet_status=packet_status | " & GCPACKETFINONEAUDITED & ","
            lsSql &= " fin_lock_flag='N' ,"
            lsSql &= " fin_lock_date=now(),"
            lsSql &= " fin_lock_by='" & gUserName & "'"
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)

        End If
        RdoYetConfirm.Checked = True
        CboFinnoneDisc.Text = ""
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub RdiChqYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqYes.CheckedChanged

    End Sub

    Private Sub RdiChqNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqNo.CheckedChanged
        btnSave.Focus()
    End Sub

    Private Sub rdoPending_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPending.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub rdoCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCompleted.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub


    Private Sub RdiNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiNo.CheckedChanged
        If RdiNo.Checked = True Then
            CboFinnoneDisc.Text = ""
            CboFinnoneDisc.Enabled = False
        End If
    End Sub

    Private Sub RdiYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiYes.CheckedChanged
        If RdiYes.Checked = True Then
            CboFinnoneDisc.Enabled = True
            CboFinnoneDisc.Focus()
        End If
    End Sub

    Private Sub frmFinnOneImageEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.F1
                RdiNo.Checked = True
            Case Keys.F2
                RdiYes.Checked = True
            Case Keys.S
                btnSave_Click(sender, e)
            Case Keys.X
                btnCancel_Click(sender, e)
        End Select
        'If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub TxtPdcCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPdcCount.TextChanged

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub pnlEntry_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlEntry.Paint

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub TxtBranchName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBranchName.TextChanged

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TxtBankName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankName.TextChanged

    End Sub

    Private Sub RdoYetConfirm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoYetConfirm.CheckedChanged

    End Sub

    Private Sub CboFinnoneDisc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFinnoneDisc.SelectedIndexChanged

    End Sub
End Class