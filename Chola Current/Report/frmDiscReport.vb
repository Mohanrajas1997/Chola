Public Class frmDiscReport
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        btnRefresh.Enabled = True
        dtpEntryFrom.Checked = False
        dtpEntryTo.Checked = False
        dtpRcvdFrom.Checked = False
        dtpRcvdTo.Checked = False
        txtagreementno.Text = ""
        txtgnsarefno.Text = ""
        
        dgvRpt.DataSource = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub frmPacketReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmPacketReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpRcvdFrom.Value = Now
        dtpRcvdTo.Value = Now

        dtpRcvdFrom.Checked = False
        dtpRcvdTo.Checked = False

        dtpEntryFrom.Value = Now
        dtpEntryTo.Value = Now

        dtpEntryFrom.Checked = False
        dtpEntryTo.Checked = False

        

        Me.KeyPreview = True
        MyBase.WindowState = FormWindowState.Maximized
        txtagreementno.Focus()
        txtagreementno.Text = ""
    End Sub


    Private Sub frmPacketReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            With dgvRpt
                .Width = Me.Width - 30
                .Height = Me.Height - Panel1.Height - 90
                pnlDisplay.Width = Me.Width - 30
                pnlDisplay.Top = Panel1.Top + Panel1.Height + dgvRpt.Height + 15
                btnExport.Left = pnlDisplay.Width - (btnExport.Width + 10)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        btnRefresh.Enabled = False

        Call PdcData()

        'Select Case True
        '    Case rdoPdc.Checked
        '        Call PdcData()
        '    Case rdoSpdc.Checked
        '        Call SpdcData()
        '    Case rdoOthers.Checked
        '        Call OthersData()
        'End Select

        btnRefresh.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PdcData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsTxt As String
        Dim lsDisc As String
        Dim lnResult As Long
        Dim lsCond As String = ""
        Dim lsFld As String = ""

        Try
            If dtpEntryFrom.Checked Then lsCond &= " and s.scan_entry_date >= '" & Format(dtpEntryFrom.Value, "yyyy-MM-dd") & "'"
            If dtpEntryTo.Checked Then lsCond &= " and s.scan_entry_date <= '" & Format(DateAdd(DateInterval.Day, 1, dtpEntryTo.Value), "yyyy-MM-dd") & "'"

            If dtpRcvdFrom.Checked Then lsCond &= " and p.packet_receiveddate >= '" & Format(dtpRcvdFrom.Value, "yyyy-MM-dd") & "'"
            If dtpRcvdTo.Checked Then lsCond &= " and p.packet_receiveddate < '" & Format(DateAdd(DateInterval.Day, 1, dtpRcvdTo.Value), "yyyy-MM-dd") & "'"



            If txtagreementno.Text <> "" Then
                If IsNumeric(txtagreementno.Text) Then
                    lsCond &= " and a.shortagreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%' "
                Else
                    lsCond &= " and a.agreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%'"
                End If
            End If

            If txtgnsarefno.Text <> "" Then
                lsCond &= " and p.packet_gnsarefno ='" & txtgnsarefno.Text.Trim & "'"
            End If


            If txtChqNo.Text <> "" Then
                lsCond &= " and s.scan_chq_no like '" & QuoteFilter(txtChqNo.Text) & "%' "
            End If

            If Val(txtChqAmt.Text) > 0 Then
                lsCond &= " and s.scan_chq_amount = " & Val(txtChqAmt.Text) & " "
            End If

            lnResult = gfInsertQry("set @sno := 0", gOdbcConn)

            lsFld = ""
            lsFld &= " @sno := @sno + 1 as 'SNo',date_format(p.packet_receiveddate,'%d/%m/%Y') as 'Packet Received Date',"
            lsFld &= " a.shortagreement_no as 'Short Agreement No',"
            lsFld &= " p.packet_gnsarefno as 'GNSA Ref No',a.agreement_no as 'Agreement No',"
            lsFld &= " date_format(s.scan_chq_date,'%d/%m/%Y') as 'Chq Date',"
            lsFld &= " s.scan_chq_no as 'Chq No',s.scan_chq_amount as 'Chq Amount',"
            lsFld &= " case when s.scan_chq_type='P' then 'PDC' when scan_chq_type='S' then 'SPDC' when  scan_chq_type='M' then 'Mandate' when  scan_chq_type='O' then 'Others' else ''  end as 'Chq Type',"
            lsFld &= " s.scan_finnone_disc as 'FinnOne Chq Desc',"
            lsFld &= " p.fin_lock_by as 'FinnOne Entry By',"
            lsFld &= " date_format(p.fin_lock_date,'%d/%m/%Y') as 'FinnOne Entry date',"
            lsFld &= " fn_get_disc_desc(s.scan_disc_value,s.scan_chq_type) as 'VMC Chq Desc',"
            lsFld &= " gnsa_lock_by as 'VMS Entry by',"
            lsFld &= " date_format(p.gnsa_lock_date,'%d/%m/%Y') as 'VMS Entry date',"
            lsFld &= " s.scan_chq_accno as 'A/C No',"
            lsFld &= " s.scan_micr_code as 'Micr Code',"
            lsFld &= " s.scan_bank_code as 'Bank Code',"
            lsFld &= " s.scan_bank_name as 'Bank Name',"
            lsFld &= " b.box_no as 'Box No',p.packet_ismultiplebank as 'Multiple Bank',"
            lsFld &= " p.packet_gid as 'Packet Id',p.packet_inward_gid as 'Inward Id',a.agreement_gid as 'Agreement Id',"
            lsFld &= " b.box_gid as 'Box Id',"
            lsFld &= " s.scan_gid as 'Scan Id',"
            lsFld &= " disc_flag as 'Chq Disc Flag',"
            lsFld &= " p.packet_mode as 'Packet Pay Mode', "
            lsFld &= " p.packet_status as 'Packet Status',"
            lsFld &= " p.packet_remarks as 'Remark',p.packet_entryon as 'Packet Entry Date',p.packet_entryby as 'Packet Entry By'"

            lsSql = ""
            lsSql &= " select "
            lsSql &= lsFld
            lsSql &= " from chola_trn_tscan s  "
            lsSql &= " inner join chola_trn_tpdcentry c on s.scan_chq_gid=c.entry_gid"
            lsSql &= " inner join chola_trn_tpacket p on s.scan_packet_gid = p.packet_gid and c.chq_packet_gid=p.packet_gid "
            lsSql &= " left join chola_trn_tbox b on p.packet_box_gid = b.box_gid "
            lsSql &= " left join chola_mst_tagreement a on p.packet_agreement_gid = a.agreement_gid "
            lsSql &= " where true "
            lsSql &= " and (s.disc_flag='Y' or s.scan_finnone_disc <> '') "
            lsSql &= " and c.chq_status & (" & GCPACKETPULLOUT & " | " & GCPULLOUT & ") = 0 "
            lsSql &= lsCond


            lsSql &= " union "


            lsFld = ""
            lsFld &= " @sno := @sno + 1 as 'SNo',p.packet_receiveddate as 'Packet Received Date',"
            lsFld &= " a.shortagreement_no as 'Short Agreement No',"
            lsFld &= " p.packet_gnsarefno as 'GNSA Ref No',a.agreement_no as 'Agreement No',"
            lsFld &= " date_format(s.scan_chq_date,'%d/%m/%Y') as 'Chq Date',"
            lsFld &= " s.scan_chq_no as 'Chq No',s.scan_chq_amount as 'Chq Amount',"
            lsFld &= " case when s.scan_chq_type='P' then 'PDC' when scan_chq_type='S' then 'SPDC' when  scan_chq_type='M' then 'Mandate' when  scan_chq_type='O' then 'Others' else ''  end as 'Chq Type',"
            lsFld &= " s.scan_finnone_disc as 'FinnOne Chq Desc',"
            lsFld &= " p.fin_lock_by as 'FinnOne Entry By',"
            lsFld &= " date_format(p.fin_lock_date,'%d/%m/%Y') as 'FinnOne Entry date',"
            lsFld &= " fn_get_disc_desc(s.scan_disc_value,s.scan_chq_type) as 'VMC Chq Desc',"
            lsFld &= " gnsa_lock_by as 'VMS Entry by',"
            lsFld &= " date_format(p.gnsa_lock_date,'%d/%m/%Y') as 'VMS Entry date',"
            lsFld &= " s.scan_chq_accno as 'A/C No',"
            lsFld &= " s.scan_micr_code as 'Micr Code',"
            lsFld &= " s.scan_bank_code as 'Bank Code',"
            lsFld &= " s.scan_bank_name as 'Bank Name',"
            lsFld &= " b.box_no as 'Box No',p.packet_ismultiplebank as 'Multiple Bank',"
            lsFld &= " p.packet_gid as 'Packet Id',p.packet_inward_gid as 'Inward Id',a.agreement_gid as 'Agreement Id',"
            lsFld &= " b.box_gid as 'Box Id',"
            lsFld &= " s.scan_gid as 'Scan Id',"
            lsFld &= " disc_flag as 'Chq Disc Flag',"
            lsFld &= " p.packet_mode as 'Packet Pay Mode', "
            lsFld &= " p.packet_status as 'Packet Status',"
            lsFld &= " p.packet_remarks as 'Remark',p.packet_entryon as 'Packet Entry Date',p.packet_entryby as 'Packet Entry By'"

            lsSql &= " select "
            lsSql &= lsFld
            lsSql &= " from chola_trn_tscan s  "
            lsSql &= " inner join chola_trn_tspdcchqentry c on s.scan_chq_gid=c.chqentry_gid"
            lsSql &= " inner join chola_trn_tpacket p on s.scan_packet_gid = p.packet_gid "
            lsSql &= " left join chola_trn_tbox b on p.packet_box_gid = b.box_gid "
            lsSql &= " left join chola_mst_tagreement a on p.packet_agreement_gid = a.agreement_gid "
            lsSql &= " where true "
            lsSql &= " and (s.disc_flag='Y' or s.scan_finnone_disc <> '') "
            lsSql &= " and c.chqentry_status & (" & GCPACKETPULLOUT & " | " & GCPULLOUT & ") = 0 "
            lsSql &= lsCond


            lsSql &= " union "

            lsFld = ""
            lsFld &= " @sno := @sno + 1 as 'SNo',p.packet_receiveddate as 'Packet Received Date',"
            lsFld &= " a.shortagreement_no as 'Short Agreement No',"
            lsFld &= " p.packet_gnsarefno as 'GNSA Ref No',a.agreement_no as 'Agreement No',"
            lsFld &= " date_format(s.scan_chq_date,'%d/%m/%Y') as 'Chq Date',"
            lsFld &= " s.scan_chq_no as 'Chq No',s.scan_chq_amount as 'Chq Amount',"
            lsFld &= " case when s.scan_chq_type='P' then 'PDC' when scan_chq_type='S' then 'SPDC' when  scan_chq_type='M' then 'Mandate' when  scan_chq_type='O' then 'Others' else ''  end as 'Chq Type',"
            lsFld &= " s.scan_finnone_disc as 'FinnOne Chq Desc',"
            lsFld &= " p.fin_lock_by as 'FinnOne Entry By',"
            lsFld &= " date_format(p.fin_lock_date,'%d/%m/%Y') as 'FinnOne Entry date',"
            lsFld &= " fn_get_disc_desc(s.scan_disc_value,s.scan_chq_type) as 'VMC Chq Desc',"
            lsFld &= " gnsa_lock_by as 'VMS Entry by',"
            lsFld &= " date_format(p.gnsa_lock_date,'%d/%m/%Y') as 'VMS Entry date',"
            lsFld &= " s.scan_chq_accno as 'A/C No',"
            lsFld &= " s.scan_micr_code as 'Micr Code',"
            lsFld &= " s.scan_bank_code as 'Bank Code',"
            lsFld &= " s.scan_bank_name as 'Bank Name',"
            lsFld &= " b.box_no as 'Box No',p.packet_ismultiplebank as 'Multiple Bank',"
            lsFld &= " p.packet_gid as 'Packet Id',p.packet_inward_gid as 'Inward Id',a.agreement_gid as 'Agreement Id',"
            lsFld &= " b.box_gid as 'Box Id',"
            lsFld &= " s.scan_gid as 'Scan Id',"
            lsFld &= " disc_flag as 'Chq Disc Flag',"
            lsFld &= " p.packet_mode as 'Packet Pay Mode', "
            lsFld &= " p.packet_status as 'Packet Status',"
            lsFld &= " p.packet_remarks as 'Remark',p.packet_entryon as 'Packet Entry Date',p.packet_entryby as 'Packet Entry By'"

            lsSql &= " select "
            lsSql &= lsFld
            lsSql &= " from chola_trn_tscan s  "
            lsSql &= " inner join chola_trn_tpacket p on s.scan_packet_gid = p.packet_gid "
            lsSql &= " left join chola_trn_tbox b on p.packet_box_gid = b.box_gid "
            lsSql &= " left join chola_mst_tagreement a on p.packet_agreement_gid = a.agreement_gid "
            lsSql &= " where true "
            lsSql &= " and (s.disc_flag='Y' or s.scan_finnone_disc <> '') "
            lsSql &= " and packet_status & " & GCIPACKETPULLOUT & " = 0 "
            lsSql &= " and scan_chq_type not in ('S','P')"
            lsSql &= lsCond


            Call gpPopGridView(dgvRpt, lsSql, gOdbcConn)

            For i = 0 To dgvRpt.Columns.Count - 1
                dgvRpt.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            lblRecCount.Text = "Record Count: " & dgvRpt.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gProjectName)
        End Try
    End Sub


    Private Sub SpdcData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsTxt As String
        Dim lsDisc As String
        Dim lnResult As Long
        Dim lsCond As String = ""
        Dim lsFld As String = ""

        Try
            If dtpEntryFrom.Checked Then lsCond &= " and s.scan_entry_date >= '" & Format(dtpEntryFrom.Value, "yyyy-MM-dd") & "'"
            If dtpEntryTo.Checked Then lsCond &= " and s.scan_entry_date <= '" & Format(DateAdd(DateInterval.Day, 1, dtpEntryTo.Value), "yyyy-MM-dd") & "'"

            If dtpRcvdFrom.Checked Then lsCond &= " and p.packet_receiveddate >= '" & Format(dtpRcvdFrom.Value, "yyyy-MM-dd") & "'"
            If dtpRcvdTo.Checked Then lsCond &= " and p.packet_receiveddate < '" & Format(DateAdd(DateInterval.Day, 1, dtpRcvdTo.Value), "yyyy-MM-dd") & "'"



            If txtagreementno.Text <> "" Then
                If IsNumeric(txtagreementno.Text) Then
                    lsCond &= " and a.shortagreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%' "
                Else
                    lsCond &= " and a.agreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%'"
                End If
            End If

            If txtgnsarefno.Text <> "" Then
                lsCond &= " and p.packet_gnsarefno ='" & txtgnsarefno.Text.Trim & "'"
            End If


            If txtChqNo.Text <> "" Then
                lsCond &= " and s.scan_chq_no like '" & QuoteFilter(txtChqNo.Text) & "%' "
            End If

            If Val(txtChqAmt.Text) > 0 Then
                lsCond &= " and s.scan_chq_amount = " & Val(txtChqAmt.Text) & " "
            End If

            lnResult = gfInsertQry("set @sno := 0", gOdbcConn)

            lsFld = ""
            lsFld &= " @sno := @sno + 1 as 'SNo',s.scan_gid as 'Scan Id',"
            lsFld &= " s.scan_chq_date as 'Chq Date',s.scan_chq_no as 'Chq No',s.scan_chq_amount as 'Chq Amount',"
            lsFld &= " disc_flag as 'Chq Disc Flag',"
            lsFld &= " fn_get_disc_desc(s.scan_disc_value,s.scan_chq_type) as 'VMC Chq Desc',"
            lsFld &= " s.scan_finnone_disc as 'FinnOne Chq Desc',"
            lsFld &= " s.scan_chq_accno as 'A/C No',"
            lsFld &= " s.scan_micr_code as 'Micr Code',"
            lsFld &= " s.scan_bank_code as 'Bank Code',"
            lsFld &= " s.scan_bank_name as 'Bank Name',"
            lsFld &= " case when s.scan_chq_type='P' then 'PDC' when scan_chq_type='S' then 'SPDC' when  scan_chq_type='M' then 'Mandate' when  scan_chq_type='O' then 'Others' else ''  end as 'Chq Type',"
            lsFld &= " p.packet_gnsarefno as 'GNSA Ref No',a.agreement_no as 'Agreement No',"
            lsFld &= " a.shortagreement_no as 'Short Agreement No',"
            lsFld &= " p.packet_mode as 'Packet Pay Mode', "
            lsFld &= " p.packet_status as 'Packet Status',"
            lsFld &= " p.packet_paymodedisc as 'Packet Paymode Disc',p.packet_remarks as 'Remark',p.packet_receiveddate as 'Packet Received Date',p.packet_entryon as 'Packet Entry Date',p.packet_entryby as 'Packet Entry By',"
            lsFld &= " b.box_no as 'Box No',p.packet_ismultiplebank as 'Multiple Bank',"
            lsFld &= " p.packet_gid as 'Packet Id',p.packet_inward_gid as 'Inward Id',a.agreement_gid as 'Agreement Id',"
            lsFld &= " b.box_gid as 'Box Id',c.chqentry_gid as 'SPDC Id'"

            lsSql = ""
            lsSql &= " select "
            lsSql &= lsFld
            lsSql &= " from chola_trn_tscan s  "
            lsSql &= " inner join chola_trn_tspdcchqentry c on s.scan_chq_gid=c.chqentry_gid"
            lsSql &= " inner join chola_trn_tpacket p on s.scan_packet_gid = p.packet_gid "
            lsSql &= " left join chola_trn_tbox b on p.packet_box_gid = b.box_gid "
            lsSql &= " left join chola_mst_tagreement a on p.packet_agreement_gid = a.agreement_gid "
            lsSql &= " where true "
            lsSql &= " and (s.disc_flag='Y' or s.scan_finnone_disc <> '') "
            lsSql &= " and c.chqentry_status & (" & GCPACKETPULLOUT & " | " & GCPULLOUT & ") = 0 "
            lsSql &= lsCond
            lsSql &= " order by s.scan_packet_gid"

            Call gpPopGridView(dgvRpt, lsSql, gOdbcConn)

            For i = 0 To dgvRpt.Columns.Count - 1
                dgvRpt.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            lblRecCount.Text = "Record Count: " & dgvRpt.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gProjectName)
        End Try
    End Sub

    Private Sub OthersData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsTxt As String
        Dim lsDisc As String
        Dim lnResult As Long
        Dim lsCond As String = ""
        Dim lsFld As String = ""

        Try
            If dtpEntryFrom.Checked Then lsCond &= " and s.scan_entry_date >= '" & Format(dtpEntryFrom.Value, "yyyy-MM-dd") & "'"
            If dtpEntryTo.Checked Then lsCond &= " and s.scan_entry_date <= '" & Format(DateAdd(DateInterval.Day, 1, dtpEntryTo.Value), "yyyy-MM-dd") & "'"

            If dtpRcvdFrom.Checked Then lsCond &= " and p.packet_receiveddate >= '" & Format(dtpRcvdFrom.Value, "yyyy-MM-dd") & "'"
            If dtpRcvdTo.Checked Then lsCond &= " and p.packet_receiveddate < '" & Format(DateAdd(DateInterval.Day, 1, dtpRcvdTo.Value), "yyyy-MM-dd") & "'"



            If txtagreementno.Text <> "" Then
                If IsNumeric(txtagreementno.Text) Then
                    lsCond &= " and a.shortagreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%' "
                Else
                    lsCond &= " and a.agreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%'"
                End If
            End If

            If txtgnsarefno.Text <> "" Then
                lsCond &= " and p.packet_gnsarefno ='" & txtgnsarefno.Text.Trim & "'"
            End If


            If txtChqNo.Text <> "" Then
                lsCond &= " and s.scan_chq_no like '" & QuoteFilter(txtChqNo.Text) & "%' "
            End If

            If Val(txtChqAmt.Text) > 0 Then
                lsCond &= " and s.scan_chq_amount = " & Val(txtChqAmt.Text) & " "
            End If

            lnResult = gfInsertQry("set @sno := 0", gOdbcConn)

            lsFld = ""
            lsFld &= " @sno := @sno + 1 as 'SNo',s.scan_gid as 'Scan Id',"
            lsFld &= " s.scan_chq_date as 'Chq Date',s.scan_chq_no as 'Chq No',s.scan_chq_amount as 'Chq Amount',"
            lsFld &= " disc_flag as 'Chq Disc Flag',"
            lsFld &= " fn_get_disc_desc(s.scan_disc_value,s.scan_chq_type) as 'VMC Chq Desc',"
            lsFld &= " s.scan_finnone_disc as 'FinnOne Chq Desc',"
            lsFld &= " s.scan_chq_accno as 'A/C No',"
            lsFld &= " s.scan_micr_code as 'Micr Code',"
            lsFld &= " s.scan_bank_code as 'Bank Code',"
            lsFld &= " s.scan_bank_name as 'Bank Name',"
            lsFld &= " case when s.scan_chq_type='P' then 'PDC' when scan_chq_type='S' then 'SPDC' when  scan_chq_type='M' then 'Mandate' when  scan_chq_type='O' then 'Others' else ''  end as 'Chq Type',"
            lsFld &= " p.packet_gnsarefno as 'GNSA Ref No',a.agreement_no as 'Agreement No',"
            lsFld &= " a.shortagreement_no as 'Short Agreement No',"
            lsFld &= " p.packet_mode as 'Packet Pay Mode', "
            lsFld &= " p.packet_status as 'Packet Status',"
            lsFld &= " p.packet_paymodedisc as 'Packet Paymode Disc',p.packet_remarks as 'Remark',p.packet_receiveddate as 'Packet Received Date',p.packet_entryon as 'Packet Entry Date',p.packet_entryby as 'Packet Entry By',"
            lsFld &= " b.box_no as 'Box No',p.packet_ismultiplebank as 'Multiple Bank',"
            lsFld &= " p.packet_gid as 'Packet Id',p.packet_inward_gid as 'Inward Id',a.agreement_gid as 'Agreement Id',"
            lsFld &= " b.box_gid as 'Box Id'"

            lsSql = ""
            lsSql &= " select "
            lsSql &= lsFld
            lsSql &= " from chola_trn_tscan s  "
            lsSql &= " inner join chola_trn_tpacket p on s.scan_packet_gid = p.packet_gid "
            lsSql &= " left join chola_trn_tbox b on p.packet_box_gid = b.box_gid "
            lsSql &= " left join chola_mst_tagreement a on p.packet_agreement_gid = a.agreement_gid "
            lsSql &= " where true "
            lsSql &= " and (s.disc_flag='Y' or s.scan_finnone_disc <> '') "
            lsSql &= " and packet_status & " & GCIPACKETPULLOUT & " = 0 "
            lsSql &= " and scan_chq_type not in ('S','P')"
            lsSql &= lsCond
            lsSql &= " order by s.scan_packet_gid"

            Call gpPopGridView(dgvRpt, lsSql, gOdbcConn)

            For i = 0 To dgvRpt.Columns.Count - 1
                dgvRpt.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            lblRecCount.Text = "Record Count: " & dgvRpt.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gProjectName)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            If dgvRpt.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gProjectName)
                Exit Sub
            End If

            Call PrintDGViewXML(dgvRpt, gsReportPath & "Packet Report.xls", "Packet Details")

            MsgBox(" Exported to Excel !!" & Chr(13) & _
                   " Saved Path : " & gsReportPath & "Packet Report", MsgBoxStyle.Information, gProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    

    
End Class