Public Class frmUpdatePktEntryForScanCases
    Dim mnPktId As Long = 0

    Private Sub frmOldSwapPktEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOldSwapPktEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpSwapDate.Value = Now
        KeyPreview = True
        txtPktNo.Focus()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim lsSql As String
        Dim lnResult As Long
        Dim lnOldPktSlNo As Long
        Dim lnSwapId As Long
        Dim ds As New DataSet

        If MessageBox.Show("Are you sure to update ?", gProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
            Return
        End If

        ' chk with packet
        lsSql = ""
        lsSql &= " select p.packet_gid,a.agreement_no,p.packet_mode from chola_trn_tpacket as p "
        lsSql &= " inner join chola_mst_tagreement as a on a.agreement_gid = p.packet_agreement_gid "
        lsSql &= " where p.packet_gnsarefno = '" & QuoteFilter(txtPktNo.Text) & "' "
        lsSql &= " and p.packet_status & " & GCPACKETSCANAUDITED & " > 0 "
        lsSql &= " and p.packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT Or GCPKTOLDSWAP Or GCPACKETCHEQUEENTRY) & " = 0 "

        Call gpDataSet(lsSql, "pkt", gOdbcConn, ds)

        If ds.Tables("pkt").Rows.Count > 0 Then
            ' update in packet table
            lsSql = ""
            lsSql &= " update chola_trn_tpacket set "
            lsSql &= " packet_status = packet_status | " & GCPACKETCHEQUEENTRY & " "
            lsSql &= " where packet_gid = " & mnPktId & " "
            lsSql &= " and packet_status & " & GCPACKETSCANAUDITED & " > 0 "
            lsSql &= " and packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT Or GCPKTOLDSWAP Or GCPACKETCHEQUEENTRY) & " = 0 "

            lnResult = gfInsertQry(lsSql, gOdbcConn)

            MsgBox("Packet status updated successfully !", MsgBoxStyle.Information, gProjectName)

            mnPktId = 0
            txtPktNo.Text = ""
            txtAgmntNo.Text = ""
            txtPayMode.Text = ""

            txtPktNo.Focus()
        Else
            mnPktId = 0
            txtAgmntNo.Text = ""
            txtPayMode.Text = ""

            MsgBox("Invalid packet !", MsgBoxStyle.Information, gProjectName)
            Exit Sub
        End If

        ds.Tables("pkt").Rows.Clear()
    End Sub

    Private Function RetrievePktInfo() As Boolean
        Dim lsSql As String
        Dim ds As New DataSet

        ' chk with packet
        lsSql = ""
        lsSql &= " select p.packet_gid,a.agreement_no,p.packet_mode from chola_trn_tpacket as p "
        lsSql &= " inner join chola_mst_tagreement as a on a.agreement_gid = p.packet_agreement_gid "
        lsSql &= " where p.packet_gnsarefno = '" & QuoteFilter(txtPktNo.Text) & "' "
        lsSql &= " and p.packet_status & " & GCPACKETSCANAUDITED & " > 0 "
        lsSql &= " and p.packet_status & " & (GCPACKETCHEQUEENTRY Or GCPACKETRETRIEVAL Or GCIPACKETPULLOUT Or GCPKTOLDSWAP) & " = 0 "

        Call gpDataSet(lsSql, "pkt", gOdbcConn, ds)

        If ds.Tables("pkt").Rows.Count > 0 Then
            mnPktId = ds.Tables("pkt").Rows(0).Item("packet_gid")
            txtAgmntNo.Text = ds.Tables("pkt").Rows(0).Item("agreement_no").ToString
            txtPayMode.Text = ds.Tables("pkt").Rows(0).Item("packet_mode").ToString
        Else
            mnPktId = 0
            txtAgmntNo.Text = ""
            txtPayMode.Text = ""

            MsgBox("Invalid packet !", MsgBoxStyle.Information, gProjectName)
            Return False
        End If

        ds.Tables("pkt").Rows.Clear()
        Return True
    End Function

    Private Sub txtPktNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPktNo.Validating
        If txtPktNo.Text <> "" Then
            If RetrievePktInfo() = False Then e.Cancel = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub txtPktNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPktNo.TextChanged

    End Sub
End Class