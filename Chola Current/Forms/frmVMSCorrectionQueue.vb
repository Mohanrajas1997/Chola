Public Class frmVMSCorrectionQueue
    Private Sub frminwardsummary_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If dgvsummary.RowCount > 0 Then Call LoadData()
    End Sub

    Private Sub frminwardsummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub frminwardsummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        MyBase.WindowState = FormWindowState.Maximized
        txtgnsarefno.Focus()
        txtgnsarefno.Text = ""
    End Sub

    Private Sub frminwardsummary_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With dgvsummary
            pnlMain.Width = Me.Width - 30
            pnlMain.Height = Me.Height - 140
            .Height = pnlMain.Height - 10
            .Width = pnlMain.Width - 10
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim lssql As String
        Dim lsPacketRef As String
        Dim ds As New DataSet
        Dim lsLockFlag As String
        Dim lsLockBy As String

        Call LoadData()
        If dgvsummary.Rows.Count <= 0 Then
            MsgBox("No records found", MsgBoxStyle.OkOnly, gProjectName)
            Exit Sub
        End If
        If txtgnsarefno.Text <> "" Then
            lssql = ""
            lssql &= " select packet_gnsarefno "
            lssql &= " from chola_trn_tpacket "
            lssql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
            lssql &= " where shortagreement_no='" & dgvsummary.Rows(0).Cells("Short Agreement No").Value.ToString & "'"
            lssql &= " and packet_gnsarefno <> '" & dgvsummary.Rows(0).Cells("GNSA REF#").Value.ToString & "'"

            lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

            If lsPacketRef <> "" Then
                If MsgBox("This Agreement Already have a packet:" & lsPacketRef & "..,Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            'lssql = ""
            'lssql &= " select gnsa_lock_flag,gnsa_lock_by "
            'lssql &= " from chola_trn_tpacket "
            'lssql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
            'lssql &= " where shortagreement_no='" & dgvsummary.Rows(0).Cells("Short Agreement No").Value.ToString & "'"
            'lssql &= " and packet_gnsarefno= '" & dgvsummary.Rows(0).Cells("GNSA REF#").Value.ToString & "'"

            'gpDataSet(lssql, "Packet", gOdbcConn, ds)

            'If ds.Tables("Packet").Rows.Count = 1 Then
            '    lsLockFlag = ds.Tables("Packet").Rows(0).Item("gnsa_lock_flag").ToString
            '    lsLockBy = ds.Tables("Packet").Rows(0).Item("gnsa_lock_by").ToString
            'End If

            'If lsLockFlag = "Y" And lsLockBy <> gUserName Then
            '    MsgBox("This Packet Already Opened by:" & lsLockBy & "", MsgBoxStyle.Information, gProjectName)
            '    Exit Sub
            'End If

            Dim frmImageEntry As New frmVMSCorrenctionEntry(dgvsummary.Rows(0).Cells("GNSA REF#").Value.ToString, dgvsummary.Rows(0).Cells("Short Agreement No").Value.ToString)
            frmImageEntry.ShowDialog()

            'txtgnsarefno.Text = ""
            dgvsummary.DataSource = Nothing
            lbltotrec.Text = ""
            txtgnsarefno.Focus()
        End If
    End Sub

    Private Sub LoadData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsCond As String = ""

        lsSql = ""
        lsSql &= " select packet_gnsarefno as 'GNSA REF#',agreement_no as 'Agreement No',shortagreement_no as 'Short Agreement No' "
        lsSql &= " from chola_trn_tpacket "
        lsSql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
        lsSql &= " where packet_status & " & GCPACKETFINONECHQDISC & " = " & GCPACKETFINONECHQDISC & " "
        lsSql &= " and packet_status & " & GCPACKETSCANCOMPLETED & " =" & GCPACKETSCANCOMPLETED & " "

        If dtpfrom.Checked Then
            lsSql &= " and  date_format(packet_receiveddate,'%Y-%m-%d') >='" & Format(dtpfrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpto.Checked Then
            lsSql &= " and  date_format(packet_receiveddate,'%Y-%m-%d') <='" & Format(dtpto.Value, "yyyy-MM-dd") & "'"
        End If

        If txtgnsarefno.Text.Trim <> "" Then
            lsSql &= " and packet_gnsarefno='" & txtgnsarefno.Text.Trim & "'"
        End If
        lsSql &= " order by packet_gnsarefno asc"

        With dgvsummary
            .Columns.Clear()
            gpPopGridView(dgvsummary, lsSql, gOdbcConn)
            lbltotrec.Text = "Total Records : " & (.RowCount).ToString
        End With
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        dtpfrom.Value = Now()
        dtpfrom.Checked = False
        dtpto.Value = Now()
        dtpto.Checked = False
        txtgnsarefno.Text = ""
        dgvsummary.DataSource = Nothing
        lbltotrec.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If dgvsummary.Rows.Count <= 0 Then
            Exit Sub
        End If
        Call PrintDGridXML(dgvsummary, gsReportPath & "\Summary.xls", "Summary")
    End Sub

    Private Sub dgvsummary_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvsummary.CellContentDoubleClick
        Dim lssql, lsPacketRef, lsLockFlag, lsLockBy As String
        Dim ds As New DataSet

        If e.RowIndex < 0 Then
            Exit Sub
        End If
        lssql = ""
        lssql &= " select packet_gnsarefno "
        lssql &= " from chola_trn_tpacket "
        lssql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
        lssql &= " where shortagreement_no='" & dgvsummary.Rows(e.RowIndex).Cells("Short Agreement No").Value.ToString & "'"
        lssql &= " and packet_gnsarefno <> '" & dgvsummary.Rows(e.RowIndex).Cells("GNSA REF#").Value.ToString & "'"
        lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

        'If lsPacketRef <> "" Then
        '    If MsgBox("This Agreement Already have a packet:" & lsPacketRef & "..,Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If

        'lssql = ""
        'lssql &= " select gnsa_lock_flag,gnsa_lock_by "
        'lssql &= " from chola_trn_tpacket "
        'lssql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
        'lssql &= " where shortagreement_no='" & dgvsummary.Rows(e.RowIndex).Cells("Short Agreement No").Value.ToString & "'"
        'lssql &= " and packet_gnsarefno= '" & dgvsummary.Rows(e.RowIndex).Cells("GNSA REF#").Value.ToString & "'"

        'gpDataSet(lssql, "Packet", gOdbcConn, ds)

        'If ds.Tables("Packet").Rows.Count = 1 Then
        '    lsLockFlag = ds.Tables("Packet").Rows(0).Item("gnsa_lock_flag").ToString
        '    lsLockBy = ds.Tables("Packet").Rows(0).Item("gnsa_lock_by").ToString
        'End If

        'If lsLockFlag = "Y" And lsLockBy <> gUserName Then
        '    MsgBox("This Packet Already Opened by:" & lsLockBy & "", MsgBoxStyle.Information, gProjectName)
        '    Exit Sub
        'End If

        Dim frmImageEntry As New frmVMSCorrenctionEntry(dgvsummary.Rows(e.RowIndex).Cells("GNSA REF#").Value.ToString, dgvsummary.Rows(e.RowIndex).Cells("Short Agreement No").Value.ToString)
        frmImageEntry.ShowDialog()
        'txtgnsarefno.Text = ""
        LoadData()
    End Sub


    Private Sub dgvsummary_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim lssql, lsPacketRef As String

        If dgvsummary.Columns(e.ColumnIndex).Name = "Physical" Then
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            lssql = ""
            lssql &= " select packet_gnsarefno "
            lssql &= " from chola_trn_tpacket "
            lssql &= " inner join chola_mst_tagreement on agreement_gid=packet_agreement_gid "
            lssql &= " where shortagreement_no='" & dgvsummary.Rows(0).Cells("Short Agreement No").Value.ToString & "'"
            lssql &= " and packet_gnsarefno <> '" & dgvsummary.Rows(0).Cells("GNSA REF#").Value.ToString & "'"
            lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

            If lsPacketRef <> "" Then
                If MsgBox("This Agreement Already have a packet:" & lsPacketRef & "..,Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim frmentry As New frminward(dgvsummary.Rows(e.RowIndex).Cells("Short Agreement No").Value.ToString, dgvsummary.Rows(e.RowIndex).Cells("GNSA REF#").Value.ToString)
            frmentry.ShowDialog()
            'txtgnsarefno.Text = ""
            LoadData()
        Else
            Dim frmImageEntry As New frmVMSCorrenctionEntry(dgvsummary.Rows(e.RowIndex).Cells("GNSA REF#").Value.ToString, dgvsummary.Rows(e.RowIndex).Cells("Short Agreement No").Value.ToString)
            frmImageEntry.ShowDialog()
        End If

    End Sub
End Class