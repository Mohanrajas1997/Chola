Public Class frmInwardTallyReport

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        btnRefresh.Enabled = False

        Call LoadData()

        btnRefresh.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadData()
        Dim lsSql As String
        Dim lsTxt As String
        Dim lsCond As String = ""

        If dtpInwdFrom.Checked Then lsCond &= " and a.inward_receiveddate >= '" & Format(dtpInwdFrom.Value, "yyyy-MM-dd") & "'"
        If dtpInwdTo.Checked Then lsCond &= " and a.inward_receiveddate < '" & Format(DateAdd(DateInterval.Day, 1, dtpInwdTo.Value), "yyyy-MM-dd") & "'"

        If txtagreementno.Text.Trim <> "" Then lsCond &= " and c.agreement_no like '" & QuoteFilter(txtagreementno.Text.Trim) & "%'"

        If txtgnsarefno.Text <> "" Then
            lsCond &= " and b.packet_gnsarefno ='" & txtgnsarefno.Text.Trim & "'"
        End If

        If lsCond = "" Then lsCond &= " and 1 = 2 "

        Try
            lsSql = " "
            lsSql &= " select distinct a.inward_receiveddate,b.packet_gnsarefno,c.agreement_no,a.inward_pdc,a.inward_spdc,a.inward_mandate, "
            lsSql &= " fn_get_packetpdc(b.packet_gid) as pdc_count, "
            lsSql &= " fn_get_packetspdc(b.packet_gid) as spdc_count, "
            lsSql &= " fn_get_packetmandate(b.packet_gid) as mandate_count, "
            lsSql &= " case when a.inward_pdc <> fn_get_packetpdc(b.packet_gid) then "
            lsSql &= " 'Inward PDC is Not Matched With PDC Count' "
            lsSql &= " when a.inward_spdc <> fn_get_packetspdc(b.packet_gid) then "
            lsSql &= " 'Inward SPDC is Not Matched With SPDC Count' "
            lsSql &= " when a.inward_mandate <> fn_get_packetmandate(b.packet_gid) then "
            lsSql &= " 'Inward Mandate is Not Matched With Mandate Count' "
            lsSql &= " else '' end as remarks "
            lsSql &= " from chola_trn_tinward a"
            lsSql &= " inner join chola_trn_tpacket b on a.inward_packet_gid=b.packet_gid"
            lsSql &= " inner join chola_mst_tagreement c on b.packet_agreement_gid=c.agreement_gid "
            lsSql &= " where "
            lsSql &= " (a.inward_pdc <> fn_get_packetpdc(b.packet_gid) or "
            lsSql &= " a.inward_spdc <> fn_get_packetspdc(b.packet_gid) or "
            lsSql &= " a.inward_mandate <> fn_get_packetmandate(b.packet_gid)) "
            lsSql &= lsCond
            lsSql &= " order by b.packet_gnsarefno"

            Call gpPopGridView(dgvRpt, lsSql, gOdbcConn)

            For i = 0 To dgvRpt.Columns.Count - 1
                dgvRpt.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            lblRecCount.Text = "Record Count: " & dgvRpt.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gProjectName)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnRefresh.Enabled = True
        dtpInwdFrom.Checked = False
        dtpInwdTo.Checked = False
        txtagreementno.Text = ""
        txtgnsarefno.Text = ""
        dgvRpt.DataSource = Nothing
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
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

    Private Sub frmInwardTallyReport_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            With dgvRpt
                .Width = Me.Width - 30
                .Height = Me.Height - pnlinwardTally.Height - 90
                pnlDisplay.Width = Me.Width - 30
                pnlDisplay.Top = pnlinwardTally.Top + pnlinwardTally.Height + dgvRpt.Height + 15
                btnExport.Left = pnlDisplay.Width - (btnExport.Width + 10)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class