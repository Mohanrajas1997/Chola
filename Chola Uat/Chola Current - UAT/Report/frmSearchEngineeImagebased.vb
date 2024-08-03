Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Public Class frmSearchEngineeImagebased
    Dim count As Integer = 0
    Dim prvvalue As String = ""
    Dim Scangid As New Integer
    Dim lsPacketGid As Integer = 0
    Dim lsagreementno As String = ""
    Dim lnCyclegid As Integer = 0
    Private Sub frmImageBaseEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CboPcktMode.Items.Add("PDC")
        'CboPcktMode.Items.Add("SPDC")
        'CboPcktMode.Items.Add("Mandate")
        'CboPcktMode.Items.Add("Others")
        Me.KeyPreview = True

        RdiChqYes.Checked = True

        mstchqdate.Enabled = False
        txtchqamt.Enabled = False
        TxtBankCode.Enabled = False
        TxtBankName.Enabled = False
        txtaccno.Enabled = False
        txtaccno.Clear()

        PnlMandate.Visible = False
        PnlPdcEntry.Visible = True



    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
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
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtMicrCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Micr Code").Value.ToString

        TxtPayMode.Text = gvmChkrEntry.Rows(rowindex).Cells("Pay_Mode").Value.ToString
        TxtRemarks.Text = gvmChkrEntry.Rows(rowindex).Cells("Reason").Value.ToString
        mstchqdate.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq Date").Value.ToString
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        txtchqamt.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque Amount").Value.ToString
        txtaccno.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq_Accno").Value.ToString
        TxtBankCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Bank Code").Value.ToString
        TxtBankName.Text = gvmChkrEntry.Rows(rowindex).Cells("Bank Name").Value.ToString


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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtBankCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    End Sub

    Private Sub frmImageBaseEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Dim lsSql As String
        Dim lnAgrId As Long = 0
        Dim lnPktId As Long = 0
        Dim ds As New DataSet

        ' Find Agreement Id
        If TxtAgreementNo.Text <> "" Then
            lsSql = ""
            lsSql &= " select agreement_gid from chola_mst_tagreement "
            lsSql &= " where shortagreement_no = '" & QuoteFilter(TxtAgreementNo.Text) & "' "

            lnAgrId = Val(gfExecuteScalar(lsSql, gOdbcConn))
        End If
        ' Find Packet Id
        If TxtGnsaRefNo.Text <> "" Then
            lsSql = ""
            lsSql &= " select packet_gid,packet_agreement_gid from chola_trn_tpacket "
            lsSql &= " where packet_gnsarefno = '" & QuoteFilter(TxtGnsaRefNo.Text) & "' "

            Call gpDataSet(lsSql, "pkt", gOdbcConn, ds)

            With ds.Tables("pkt")
                If .Rows.Count > 0 Then
                    lnPktId = .Rows(0).Item("packet_gid")
                    If lnAgrId = 0 Then lnAgrId = .Rows(0).Item("packet_agreement_gid")
                Else
                    MsgBox("Invalid packet no !", MsgBoxStyle.Critical, gProjectName)
                    Exit Sub
                End If
                .Rows.Clear()
            End With
        End If

        If lnAgrId = 0 Then
            MsgBox("Invalid agreement no !", MsgBoxStyle.Critical, gProjectName)
            Exit Sub
        End If

        lsCond = ""
        If lnPktId > 0 Then lsCond &= " and b.packet_gid = " & lnPktId & " "
        If lnAgrId > 0 Then lsCond &= " and d.agreement_gid = " & lnAgrId & " "


        lsSql = ""
        lsSql &= "  select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,c.chq_no as 'Cheque No',c.chq_amount as 'Cheque Amount',"
        lsSql &= "  scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,date_format(chq_date,'%d/%m/%Y') as 'Chq Date',"
        lsSql &= " 'PDC' AS 'Pay_Mode',chq_accno as 'Chq_Accno', "
        lsSql &= "  scan_remark as 'Reason',chq_bankcode as 'Bank Code',chq_bankname as 'Bank Name',scan_chq_gid"
        lsSql &= " from chola_trn_tscan as a"
        lsSql &= " inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid"
        lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
        lsSql &= " and scan_status & " & GCSCANRESCAN & "= 0 "
        lsSql &= " inner join chola_trn_tpdcentry as c on a.scan_chq_gid=c.entry_gid and b.packet_gid=c.chq_packet_gid"
        lsSql &= " left join chola_mst_tagreement d on b.packet_agreement_gid = d.agreement_gid "
        lsSql &= " cross join (select @rownr:=0) as t "
        lsSql &= " where true"
        lsSql &= lsCond
        lsSql &= " union "
        lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,c.chqentry_chqno as 'Cheque No','' as 'Cheque Amount',"
        lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,"
        lsSql &= " date_format(scan_chq_date,'%d/%m/%Y') as 'Chq Date','SPDC' AS 'Pay_Mode',chqentry_accno as 'Chq_Accno',"
        lsSql &= " scan_remark as 'Reason',chqentry_bankcode as 'Bank Code',chqentry_bankname as 'Bank Name',scan_chq_gid "
        lsSql &= " from chola_trn_tscan as a "
        lsSql &= " inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
        lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
        lsSql &= " and scan_status & " & GCSCANRESCAN & "= 0 "
        lsSql &= " inner join chola_trn_tspdcchqentry as c on a.scan_chq_gid=c.chqentry_gid and b.packet_gid=c.chqentry_packet_gid"
        lsSql &= " left join chola_mst_tagreement d on b.packet_agreement_gid = d.agreement_gid "
        lsSql &= " cross join (select @rownr:=0) as t "
        lsSql &= " where true"
        lsSql &= lsCond
        lsSql &= " union "
        lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No','' as 'Cheque Amount',"
        lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,"
        lsSql &= " date_format(scan_chq_date,'%d/%m/%Y') as 'Chq Date',case when scan_chq_type='M' then 'Mandate'"
        lsSql &= " when scan_chq_type='O' then 'Others' else '' end as 'Pay_Mode',scan_chq_accno as 'Chq_Accno',"
        lsSql &= " scan_remark as 'Reason','' as 'Bank Code','' as 'Bank Name',scan_chq_gid"
        lsSql &= " from chola_trn_tscan as a "
        lsSql &= " inner join chola_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
        lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
        lsSql &= " and scan_status & " & GCSCANRESCAN & "= 0 "
        lsSql &= " and scan_chq_type in ('M','O')"
        lsSql &= " left join chola_mst_tagreement d on b.packet_agreement_gid = d.agreement_gid "
        lsSql &= " cross join (select @rownr:=0) as t "
        lsSql &= " where true"
        lsSql &= lsCond

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
                .Columns("Bank Code").Visible = False
                .Columns("Bank Name").Visible = False
            End With
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TxtAgreementNo.Text = ""
        TxtGnsaRefNo.Text = ""
    End Sub
End Class