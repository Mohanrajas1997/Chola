Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Public Class frmVMSCorrenctionEntry
    Dim count As Integer = 0
    Dim prvvalue As String = ""
    Dim Scangid As New Integer
    Dim ChqEntryGid As New Integer
    Dim lsPacketGid As Integer = 0
    Dim lsagreementno As String = ""
    Dim lnCyclegid As Integer = 0
    Private Sub frmImageBaseEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        Dim lsSql As String

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
            TxtCustomerName.Text = ds.Tables("PacketInward").Rows(0).Item("inward_customername").ToString
            TxtTenureCount.Text = ds.Tables("PacketInward").Rows(0).Item("inward_tenure").ToString
        End If
        TxtPayMode.Focus()
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

            If rdoPending.Checked = True Then
                lsSql = ""
                lsSql &= "  select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,c.chq_no as 'Cheque No',c.chq_amount as 'Cheque Amount',"
                lsSql &= "  scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,date_format(chq_date,'%d/%m/%Y') as 'Chq Date',"
                lsSql &= " 'PDC' AS 'Pay_Mode',chq_accno as 'Chq_Accno',case when chq_finnone_desc=1 then 'Chq Date Mismatch' "
                lsSql &= "  when chq_finnone_desc=2 then 'Chq No Mismatch' when chq_finnone_desc=4 then 'Amount Mismatch' when chq_finnone_desc=8 then 'Aggrement No Mismatch'"
                lsSql &= "  when chq_finnone_desc=16 then 'Acc No Mismatch' else '' end as 'Reason',scan_chq_gid"
                lsSql &= " from chola_trn_tscan as a"
                lsSql &= " inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid"
                lsSql &= " and packet_status & " & GCPACKETFINONECHQDISC & " = " & GCPACKETFINONECHQDISC & "  "
                lsSql &= " and scan_status & " & GCSCANFINONEAUDITED & " = " & GCSCANFINONEAUDITED & ""
                lsSql &= " inner join chola_trn_tpdcentry as c on a.scan_chq_gid=c.entry_gid and b.packet_gid=c.chq_packet_gid and c.chq_finnone_desc<>0"
                lsSql &= " cross join (select @rownr:=0) as t "
                lsSql &= " where scan_packet_gid='" & lsPacketGid & "'"
                lsSql &= " union "
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,c.chqentry_chqno as 'Cheque No','' as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,"
                lsSql &= " date_format(scan_chq_date,'%d/%m/%Y') as 'Chq Date','SPDC' AS 'Pay_Mode',chqentry_accno as 'Chq_Accno',"
                lsSql &= "  case when chqentry_finnone_desc=1 then 'Chq Date Mismatch'"
                lsSql &= " when chqentry_finnone_desc=2 then 'Chq No Mismatch'"
                lsSql &= " when chqentry_finnone_desc=4 then 'Amount Mismatch'"
                lsSql &= " when chqentry_finnone_desc=8 then 'Aggrement No Mismatch'"
                lsSql &= " when chqentry_finnone_desc=16 then 'Acc No Mismatch' else '' end as 'Reason',scan_chq_gid "
                lsSql &= " from chola_trn_tscan as a "
                lsSql &= " inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
                lsSql &= " and packet_status & " & GCPACKETFINONECHQDISC & " = " & GCPACKETFINONECHQDISC & "  "
                lsSql &= " and scan_status & " & GCSCANFINONEAUDITED & " = " & GCSCANFINONEAUDITED & ""
                lsSql &= " inner join chola_trn_tspdcchqentry as c on a.scan_chq_gid=c.chqentry_gid and b.packet_gid=c.chqentry_packet_gid"
                lsSql &= " and c.chqentry_finnone_desc<>0 "
                lsSql &= " cross join (select @rownr:=0) as t "
                lsSql &= " where scan_packet_gid='" & lsPacketGid & "'"

                gvmChkrEntry.Columns.Clear()
                gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)
                If gvmChkrEntry.Rows.Count > 0 Then
                    With gvmChkrEntry
                        .Columns("scan_gid").Visible = False
                        .Columns("scan_packet_gid").Visible = False
                        .Columns("scan_status").Visible = False
                        .Columns("Chq Date").Visible = False
                        .Columns("Pay_Mode").Visible = False
                        .Columns("Chq_Accno").Visible = False
                        .Columns("scan_chq_gid").Visible = False
                    End With
                End If

            ElseIf rdoCompleted.Checked = True Then

                lsSql = ""
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,date_format(scan_chq_date,'%d/%m/%Y') as 'Chq Date',scan_chq_type"
                lsSql &= " from chola_trn_tscan cross join (select @rownr:=0) as t "
                lsSql &= " where scan_status & " & GCSCANFINONEAUDITED & " = " & GCSCANFINONEAUDITED & " and scan_packet_gid='" & lsPacketGid & "'"
                gvmChkrEntry.Columns.Clear()
                gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)
                With gvmChkrEntry
                    .Columns("scan_gid").Visible = False
                    .Columns("scan_packet_gid").Visible = False
                    .Columns("scan_status").Visible = False
                    .Columns("Chq Date").Visible = False
                    .Columns("scan_chq_type").Visible = False
                End With

            End If

            If lsPacketGid > 0 Then

                lsSql = ""
                lsSql &= " select packet_gid from chola_trn_tpacket "
                lsSql &= " where packet_gid=" & lsPacketGid & " and packet_status & " & GCPACKETFINONECHQDISC & " =0  "

                lnPacketAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

                If lnPacketAuditCount > 0 Then
                    MsgBox("VMS Correction Entry Completed", MsgBoxStyle.Information, gProjectName)
                    Close()
                End If

            End If
        End If
    End Sub

    Private Sub gvmChkrEntry_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles gvmChkrEntry.SelectionChanged

        Dim rowindex As New Integer

        Dim ScanImageGid As New Integer
        Dim ScanImageSide As String
        Dim lsSql As String
        Dim ds As New DataSet
        Dim ObjScanImage As New ScanEntryModel
        Dim lsMicrCode As String = ""
        Dim Paymode As String


        rowindex = gvmChkrEntry.CurrentCell.RowIndex
        Scangid = gvmChkrEntry.Rows(rowindex).Cells("scan_gid").Value.ToString

        TxtPayMode.Text = gvmChkrEntry.Rows(rowindex).Cells("Pay_Mode").Value.ToString
        TxtReason.Text = gvmChkrEntry.Rows(rowindex).Cells("Reason").Value.ToString
        mstchqdate.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq Date").Value.ToString
        TxtChequeNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtAmount.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque Amount").Value.ToString
        TxtAccNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq_Accno").Value.ToString
        ChqEntryGid = gvmChkrEntry.Rows(rowindex).Cells("scan_chq_gid").Value.ToString

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

    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Dim lssql As String
        If MsgBox("Are you sure you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Close()
    End Sub
    Private Function CallCholaApi(ObjScanImage As ScanEntryModel) As String

        Dim reqString() As Byte
        Dim resByte As Byte()
        Dim responseFromApi As String
        ' Dim endPoint As String = "http://169.38.77.190:105/api/Scan/viewimage"
        ' Dim endPoint As String = "http://192.168.0.154:8503/api/Scan/viewimage"
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

    Private Sub frmImageBaseEntry_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim drpacket As Odbc.OdbcDataReader
        Dim drpdc As Odbc.OdbcDataReader

        Dim lnAgreementGid As Long
        Dim lnPacketGid As Long
        Dim lnpdcgid As Long
       

        Dim lsScanStatus As Long = 0
        Dim lsSql As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqAmount As Long = 0
        Dim lsPacketMode As String = ""
        Dim lsScanVisibility As String = ""
        Dim lsScanDiscFlag As String = ""
        Dim lnPDCCount As Long = 0
        Dim lnSPDCCount As Long = 0
        Dim lnReScanCount As Long = 0
        Dim lsEntryMode As String = ""

        Dim lschqdisc As String = ""
        Dim lsiscts As Char = ""

        Dim lcPacketDisc As String = ""

        Dim lspap As String = ""
        Dim lsMicrCode As String = ""

        Dim lsChqMode As String = ""
        Dim lcChqDisc As String = ""

        Dim lsismicr As String = ""
       

        Dim lsStartDate As String = ""
        Dim lsEndDate As String = ""

        Dim n As Integer
        Dim lnChqNo As Integer = 0

        Dim lnInvaliCount As Long = 0

        If MsgBox("Are you sure you want to Submit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        If RdoYetConfirm.Checked = True Then
            MsgBox("Please Select Entry Type..!", MsgBoxStyle.Critical, gProjectName)
            RdoYetConfirm.Focus()
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

        'Update Scan Table

        If TxtPayMode.Text = "" Then
            MsgBox("Please Enter the Pay Mode..!", MsgBoxStyle.Critical, gProjectName)
            TxtPayMode.Focus()
            Exit Sub
        End If

        lnChqNo = Val(TxtChequeNo.Text.Trim)

        If RdiVMS.Checked = True Then


            If TxtPayMode.Text = "PDC" Then

                lsSql = " select pdc_gid from chola_trn_tpdcfile "
                lsSql &= " where chq_rec_slno=1 "
                lsSql &= " and pdc_chqno = " & Val(TxtChequeNo.Text.ToString) & " "
                lsSql &= " and pdc_shortpdc_parentcontractno='" & TxtAgreementNo.Text.ToString & "' "
                lsSql &= " and pdc_acc_no ='" & TxtAccNo.Text.ToString & "' "
                lsSql &= " and pdc_chqamount = " & TxtAmount.Text & " "
                lsSql &= " and pdc_chqdate = '" & Format(CDate(mstchqdate.Text.Trim), "yyyy-MM-dd") & "' "
                lsSql &= " and (entry_gid = 0 or entry_gid is null) and pdc_spdcentry_gid = 0 and pdc_ecsentry_gid = 0 "

                drpdc = gfExecuteQry(lsSql, gOdbcConn)

                If drpdc.HasRows Then
                    While drpdc.Read
                        lnpdcgid = drpdc.Item("pdc_gid").ToString
                    End While
                Else
                    lnpdcgid = GCZERO
                End If

                drpdc.Close()

                If lnpdcgid > 0 Then

                    lsSql = ""
                    lsSql &= " update chola_trn_tpdcentry set "
                    lsSql &= " chq_pdc_gid=" & lnpdcgid & ","
                    lsSql &= " chq_agreement_gid=" & lnAgreementGid & ", "
                    lsSql &= " chq_no='" & lnChqNo & "',"
                    lsSql &= " chq_accno='" & TxtAccNo.Text & "',"
                    lsSql &= " chq_date='" & Format(CDate(mstchqdate.Text.Trim), "yyyy-MM-dd") & "',"
                    lsSql &= " chq_amount='" & TxtAmount.Text & "',"
                    lsSql &= " chq_finnone_desc=0"
                    lsSql &= " where entry_gid=" & ChqEntryGid
                    lsSql &= " and chq_pdc_gid=0"

                    gfInsertQry(lsSql, gOdbcConn)

                    lsSql = ""
                    lsSql &= " UPDATE"
                    lsSql &= " chola_trn_tpdcfile"
                    lsSql &= " set"
                    lsSql &= " entry_gid=" & ChqEntryGid & " "
                    lsSql &= " where 1=1"
                    lsSql &= " and pdc_gid=" & lnpdcgid
                    lsSql &= " and (entry_gid = 0 or entry_gid is null) and pdc_spdcentry_gid = 0 and pdc_ecsentry_gid = 0 "

                    gfInsertQry(lsSql, gOdbcConn)
                Else
                    MsgBox("UnMatched VMS Entry..!", MsgBoxStyle.Information, gProjectName)
                    Exit Sub
                End If
            End If

            If TxtPayMode.Text = "SPDC" Then

                lsSql = " select pdc_gid from chola_trn_tpdcfile "
                lsSql &= " where chq_rec_slno=1 "
                lsSql &= " and pdc_chqno = " & Val(TxtChequeNo.Text.ToString) & " "
                lsSql &= " and pdc_shortpdc_parentcontractno='" & TxtAgreementNo.Text.ToString & "' "
                lsSql &= " and pdc_acc_no ='" & TxtAccNo.Text.ToString & "' "
                lsSql &= " and (entry_gid = 0 or entry_gid is null) and pdc_spdcentry_gid = 0 and pdc_ecsentry_gid = 0 "

                drpdc = gfExecuteQry(lsSql, gOdbcConn)

                If drpdc.HasRows Then
                    While drpdc.Read
                        lnpdcgid = drpdc.Item("pdc_gid").ToString
                    End While
                Else
                    lnpdcgid = GCZERO
                End If

                drpdc.Close()


                If lnpdcgid > 0 Then
                    lsSql = ""
                    lsSql &= " update chola_trn_tspdcchqentry set "
                    lsSql &= " chqentry_pdc_gid=" & lnpdcgid & ", "
                    lsSql &= " chqentry_chqno='" & lnChqNo & "',"
                    lsSql &= " chqentry_accno='" & TxtAccNo.Text & "',"
                    lsSql &= " chqentry_finnone_desc=0 "
                    lsSql &= " where chqentry_gid = " & ChqEntryGid
                    lsSql &= " and chqentry_pdc_gid = 0"

                    gfInsertQry(lsSql, gOdbcConn)

                    lsSql = ""
                    lsSql &= " UPDATE"
                    lsSql &= " chola_trn_tpdcfile"
                    lsSql &= " set"
                    lsSql &= " pdc_spdcentry_gid =" & ChqEntryGid & " "
                    lsSql &= " where 1=1"
                    lsSql &= " and pdc_gid=" & lnpdcgid
                    lsSql &= " and (entry_gid = 0 or entry_gid is null) and pdc_spdcentry_gid = 0 and pdc_ecsentry_gid = 0 "

                    gfInsertQry(lsSql, gOdbcConn)
                Else

                    MsgBox("UnMatched VMS Entry..!", MsgBoxStyle.Information, gProjectName)
                    Exit Sub
                End If

            End If

            lsSql = ""
            lsSql &= " select count(*) from chola_trn_tpdcentry "
            lsSql &= " where chq_packet_gid=" & lnPacketGid & " and chq_finnone_desc >0 "
            lnPDCCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            lsSql = ""
            lsSql &= " select count(*) from chola_trn_tspdcchqentry "
            lsSql &= " where chqentry_packet_gid=" & lnPacketGid & " and chqentry_finnone_desc >0 "
            lnSPDCCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            If lnPDCCount = 0 And lnSPDCCount = 0 Then

                lsSql = ""
                lsSql &= " update chola_trn_tpacket set "
                lsSql &= " packet_status=(packet_status | " & GCPACKETFINONECHQDISC & " | " & GCPACKETVMSCORRECTION & " ) ^ " & GCPACKETFINONECHQDISC & " "
                lsSql &= " where packet_gid = " & lnPacketGid

                gfInsertQry(lsSql, gOdbcConn)

            End If
        End If

        If RdiFinnOne.Checked = True Then

            lsSql = ""
            lsSql &= " update chola_trn_tpacket set "
            lsSql &= " packet_status=(packet_status | " & GCPACKETFINONECHQDISC & " | " & GCPACKETFINONECORRECTION & " ) ^ " & GCPACKETFINONECHQDISC & " "
            lsSql &= " where packet_gid = " & lnPacketGid

            gfInsertQry(lsSql, gOdbcConn)
        End If

        TxtReason.Text = ""
        mstchqdate.Text = ""
        TxtPayMode.Text = ""
        TxtChequeNo.Text = ""
        TxtAmount.Text = ""
        TxtAccNo.Text = ""
        LoadGridData(lsPacketGid)
    End Sub

 

  

    Private Sub rdoPending_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoPending.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub rdoCompleted_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoCompleted.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub
    Private Sub frmFinnOneImageEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

  

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

  


    Private Sub TxtAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
        If e.KeyChar = "13" Then
            SendKeys.Send("{tab}")
            Exit Sub
        End If
        If TxtPayMode.Text = "PDC" Then
            If Not IsDate(mstchqdate.Text) Then
                e.Handled = True
                MsgBox("Please Enter Cheque Date", MsgBoxStyle.Critical, gProjectName)
                ' MessageBox.Show("Please Enter Cheque Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtAmount.Text = ""
                mstchqdate.Focus()
                Exit Sub
            End If
        End If

        e.Handled = gfAmountEntryOnly(e, TxtAmount)
    End Sub

    Private Sub TxtAmount_Leave(sender As System.Object, e As System.EventArgs) Handles TxtAmount.Leave
        If TxtAmount.Text.ToString() <> "" Then
            Dim currentvalue As String = ""
            If Convert.ToDouble(TxtAmount.Text) > 0 Then
                count += 1
                If count = 1 Then
                    prvvalue = TxtAmount.Text
                    TxtAmount.Clear()
                    TxtAmount.Focus()
                ElseIf count = 2 Then
                    currentvalue = TxtAmount.Text
                    If prvvalue.Equals(currentvalue) Then
                        count = 0
                        prvvalue = ""
                        currentvalue = ""
                    Else
                        count = 0
                        TxtAmount.Clear()
                        TxtAmount.Focus()
                        MsgBox("Amount mismatch ! Reenter the amount", MsgBoxStyle.Critical, gProjectName)

                    End If
                Else
                    count = 0
                    TxtAmount.Clear()
                    TxtAmount.Focus()
                    MsgBox("Reenter The Amount", MsgBoxStyle.MsgBoxHelp, gProjectName)
                End If
            Else

                If TxtPayMode.Text.ToUpper = "PDC" Then
                    MsgBox("Amount Cannot Be Empty", MsgBoxStyle.Critical, gProjectName)
                    TxtAmount.Focus()
                End If
            End If
        Else
            If TxtPayMode.Text.ToUpper = "PDC" Then
                MsgBox("Invalid cheque amount !", MsgBoxStyle.Exclamation, gProjectName)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub mstchqdate_Leave(sender As System.Object, e As System.EventArgs) Handles mstchqdate.Leave
        Dim lschqday As String
        Dim lsSql As String

        If TxtPayMode.Text = "PDC" Then
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
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtChequeNo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChequeNo.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub
End Class