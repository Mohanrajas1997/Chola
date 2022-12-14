Public Class frmTransferCheque
    Dim lssql As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call LoadData()
    End Sub

    Private Sub LoadData()
        Dim lnPktId As Long = 0
        Dim lnAgmntId As Long = 0
        Dim ds As New DataSet

        lssql = ""
        lssql &= " select packet_agreement_gid,oldswappacket_gid,packet_gnsarefno,agreement_no,shortagreement_no,packet_mode,packet_gid from chola_trn_toldswappacket "
        lssql &= " inner join chola_trn_tpacket on packet_gid = oldpacket_gid "
        lssql &= " and packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT) & " = 0 "
        lssql &= " and packet_status & " & GCPKTOLDSWAP & " > 0 "
        lssql &= " inner join chola_mst_tagreement on agreement_gid = packet_agreement_gid "
        lssql &= " where oldpacket_slno = '" & Val(txtOldSwapNo.Text) & "' "
        lssql &= " and oldpacket_status & " & (GCOLDSWAPPKTCANCELLED Or GCOLDSWAPPKTPULLOUT) & " = 0 "

        Call gpDataSet(lssql, "pkt", gOdbcConn, ds)

        With ds.Tables("pkt")
            If .Rows.Count > 0 Then
                lnPktId = .Rows(0).Item("packet_gid")
                lnAgmntId = .Rows(0).Item("packet_agreement_gid")
                txtPktNo.Text = .Rows(0).Item("packet_gnsarefno").ToString
                txtAgmntNo.Text = .Rows(0).Item("agreement_no").ToString
                txtShortAgreementNo.Text = .Rows(0).Item("shortagreement_no").ToString
                txtPayMode.Text = .Rows(0).Item("packet_mode").ToString
            Else
                MsgBox("Invalid old swap no !", MsgBoxStyle.Critical, gProjectName)
            End If
        End With

        If lnPktId > 0 Then
            Call LoadPdc(lnPktId)
            Call LoadSpdc(lnPktId)
        End If

        ' load new packet
        lssql = ""
        lssql &= " select packet_gid,packet_gnsarefno from chola_trn_tpacket "
        lssql &= " where packet_agreement_gid = " & lnAgmntId & " "
        lssql &= " and packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT) & " = 0 "
        lssql &= " and packet_status & " & GCPKTOLDSWAP & " = 0 "
        lssql &= " order by packet_gid desc "

        Call gpBindCombo(lssql, "packet_gnsarefno", "packet_gid", cboNewPkt, gOdbcConn)
    End Sub

    Private Sub LoadPdc(ByVal PktId As Long)
        Dim i As Integer
        Dim n As Integer
        Dim dgChkBox As DataGridViewCheckBoxColumn

        lssql = " set @slno:=0 "
        gfInsertQry(lssql, gOdbcConn)

        lssql = ""
        lssql &= " select entry_gid,@slno:= @slno + 1 as 'SL No',packet_gnsarefno as 'GNSAREF#',chq_no as 'Cheque No',date_format(chq_date,'%d-%m-%Y') as 'Cheque Date', "
        lssql &= " chq_amount  as 'Amount' "
        lssql &= " from chola_trn_tpdcentry "
        lssql &= " inner join chola_trn_tpacket on packet_gid=chq_packet_gid "
        lssql &= " where packet_gid = " & PktId & " "
        lssql &= " and chq_status & " & (GCCLOSURE Or GCPACKETPULLOUT Or GCPULLOUT Or GCCHQRETRIEVAL Or GCPRESENTATIONDE) & " = 0 "

        dgvPdc.Columns.Clear()
        gpPopGridView(dgvPdc, lssql, gOdbcConn)
        dgvPdc.Columns(0).Visible = False

        n = dgvPdc.Columns.Count

        dgChkBox = New DataGridViewCheckBoxColumn
        dgChkBox.HeaderText = "Select"

        dgvPdc.Columns.Add(dgChkBox)

        For i = 0 To dgvPdc.Rows.Count - 1
            dgvPdc.Rows(i).Cells(n).Value = False
        Next i
    End Sub

    Private Sub LoadSpdc(ByVal PktId As Long)
        Dim i As Integer
        Dim n As Integer
        Dim lsSql As String
        Dim dgChkBox As DataGridViewCheckBoxColumn

        n = gfInsertQry("set @a := 0", gOdbcConn)

        lsSql = ""
        lsSql &= " select chqentry_gid,@a:=@a+1 as 'SNo',chqentry_gid as 'Spdc Id',chqentry_chqno as 'Chq No' from chola_trn_tspdcchqentry "
        lsSql &= " where chqentry_packet_gid = " & PktId & " "
        lsSql &= " and chqentry_status & " & (GCCLOSURE Or GCPACKETPULLOUT Or GCPULLOUT Or GCCHQRETRIEVAL Or GCPRESENTATIONDE) & " = 0 "
        lsSql &= " order by chqentry_gid "

        dgvSpdc.Columns.Clear()

        Call gpPopGridView(dgvSpdc, lsSql, gOdbcConn)

        With dgvSpdc
            For i = 0 To .Columns.Count - 1
                .Columns(i).ReadOnly = True
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            n = .ColumnCount

            dgChkBox = New DataGridViewCheckBoxColumn
            dgChkBox.HeaderText = "Select"

            .Columns.Add(dgChkBox)
            .Columns(0).Visible = False

            For i = 0 To .Rows.Count - 1
                .Rows(i).Cells(n).Value = False
            Next i
        End With
    End Sub

    Private Sub frmupdatepacket_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtOldSwapNo.Text = ""
        dgvPdc.DataSource = Nothing
        dgvPdc.Columns.Clear()
        txtOldSwapNo.Focus()
    End Sub

    Private Sub frmupdatepacket_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim lnHeight As Long

        grpMain.Top = 0
        grpMain.Left = 6

        With dgvPdc
            .Top = grpMain.Top + grpMain.Height + 6
            .Left = grpMain.Left

            lnHeight = (Me.Height - .Top - grpNewPacket.Height - 6 * 3 - 27) \ 2
            .Height = lnHeight
            .Width = Me.Width - 30

            dgvSpdc.Top = .Top + .Height + 6
            dgvSpdc.Left = .Left
            dgvSpdc.Height = .Height
            dgvSpdc.Width = .Width

            grpNewPacket.Top = dgvSpdc.Top + dgvSpdc.Height + 6
            grpNewPacket.Left = 6
        End With
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtOldSwapNo.Text = "" Then
            MsgBox("Please select old packet serial no !", MsgBoxStyle.Information, gProjectName)
            txtOldSwapNo.Focus()
            Exit Sub
        End If

        If cboNewPkt.SelectedIndex = -1 Then
            MsgBox("Please select new packet !", MsgBoxStyle.Information, gProjectName)
            cboNewPkt.Focus()
            Exit Sub
        End If

        If MsgBox("Are you sure to update ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gProjectName) = MsgBoxResult.Yes Then
            Call UpdateSwapPacket()
        End If
    End Sub

    Private Sub UpdateSwapPacket()
        Dim lnSwapId As Long = 0
        Dim lnOldPktId As Long = 0
        Dim lnNewPktId As Long = 0
        Dim lnAgmntId As Long = 0
        Dim ds As New DataSet
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim lnPdcId As Long
        Dim lnSpdcId As Long
        Dim lnResult As Long

        lssql = ""
        lssql &= " select packet_agreement_gid,oldswappacket_gid,packet_gid from chola_trn_toldswappacket "
        lssql &= " inner join chola_trn_tpacket on packet_gid = oldpacket_gid"
        lssql &= " and packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT) & " = 0 "
        lssql &= " and packet_status & " & GCPKTOLDSWAP & " > 0 "
        lssql &= " where oldpacket_slno = '" & Val(txtOldSwapNo.Text) & "' "
        lssql &= " and oldpacket_status & " & (GCOLDSWAPPKTCANCELLED Or GCOLDSWAPPKTPULLOUT) & " = 0 "

        Call gpDataSet(lssql, "pkt", gOdbcConn, ds)

        With ds.Tables("pkt")
            If .Rows.Count > 0 Then
                lnSwapId = .Rows(0).Item("oldswappacket_gid")
                lnOldPktId = .Rows(0).Item("packet_gid")
                lnAgmntId = .Rows(0).Item("packet_agreement_gid")
            Else
                MsgBox("Invalid record !", MsgBoxStyle.Critical, gProjectName)
                Exit Sub
            End If

            .Rows.Clear()
        End With

        ' load new packet
        lssql = ""
        lssql &= " select packet_gid from chola_trn_tpacket "
        lssql &= " where packet_gid = " & Val(cboNewPkt.SelectedValue.ToString) & " "
        lssql &= " and packet_agreement_gid = " & lnAgmntId & " "
        lssql &= " and packet_status & " & (GCPACKETRETRIEVAL Or GCIPACKETPULLOUT) & " = 0 "
        lssql &= " and packet_status & " & GCPKTOLDSWAP & " = 0 "
        lssql &= " order by packet_gid desc "

        lnNewPktId = Val(gfExecuteScalar(lssql, gOdbcConn))

        If lnNewPktId > 0 Then
            ' Pdc
            For i = 0 To dgvPdc.Rows.Count - 1
                If dgvPdc.Rows(i).Cells(dgvPdc.Columns.Count - 1).Value = True Then
                    lnPdcId = dgvPdc.Rows(i).Cells("entry_gid").Value

                    lssql = ""
                    lssql &= " update chola_trn_tpdcentry set "
                    lssql &= " chq_packet_gid = " & lnNewPktId & " "
                    lssql &= " where entry_gid = " & lnPdcId & " "
                    lssql &= " and chq_status & " & (GCCLOSURE Or GCPACKETPULLOUT Or GCPULLOUT Or GCCHQRETRIEVAL Or GCPRESENTATIONDE) & " = 0 "
                    lssql &= " and chq_packet_gid = " & lnOldPktId & " "

                    lnResult = gfInsertQry(lssql, gOdbcConn)

                    n += 1
                End If
            Next i

            ' Spdc
            For i = 0 To dgvSpdc.Rows.Count - 1
                If dgvSpdc.Rows(i).Cells(dgvSpdc.Columns.Count - 1).Value = True Then
                    lnSpdcId = dgvSpdc.Rows(i).Cells("chqentry_gid").Value

                    lssql = ""
                    lssql &= " update chola_trn_tspdcchqentry set "
                    lssql &= " chqentry_packet_gid = " & lnNewPktId & " "
                    lssql &= " where chqentry_gid = " & lnSpdcId & " "
                    lssql &= " and chqentry_status & " & (GCCLOSURE Or GCPACKETPULLOUT Or GCPULLOUT Or GCCHQRETRIEVAL Or GCPRESENTATIONDE) & " = 0 "
                    lssql &= " and chqentry_packet_gid = " & lnOldPktId & " "

                    lnResult = gfInsertQry(lssql, gOdbcConn)

                    n += 1
                End If
            Next i

            If n > 0 Then
                ' swap table
                lssql = ""
                lssql &= " update chola_trn_toldswappacket set "
                lssql &= " newpacket_gid = " & lnNewPktId & ","
                lssql &= " oldpacket_status = oldpacket_status | " & GCOLDSWAPCHQTRANSFERED & " "
                lssql &= " where oldswappacket_gid = " & lnSwapId & " "

                lnResult = gfInsertQry(lssql, gOdbcConn)

                ' old packet table
                lssql = ""
                lssql &= " update chola_trn_tpacket set "
                lssql &= " packet_status = packet_status | " & GCPKTOLDSWAPCHQTRAN & " "
                lssql &= " where packet_gid = " & lnOldPktId & " "

                lnResult = gfInsertQry(lssql, gOdbcConn)

                ' new packet table
                lssql = ""
                lssql &= " update chola_trn_tpacket set "
                lssql &= " packet_status = packet_status | " & GCPKTOLDSWAPCHQRCVD & " "
                lssql &= " where packet_gid = " & lnNewPktId & " "

                lnResult = gfInsertQry(lssql, gOdbcConn)
            End If

            MsgBox("Cheques transferred successfully !", MsgBoxStyle.Information, gProjectName)

            dgvPdc.Columns.Clear()
            dgvSpdc.Columns.Clear()

            Call frmCtrClear(Me)

            ' load new packet
            lssql = ""
            lssql &= " select packet_gid,packet_gnsarefno from chola_trn_tpacket "
            lssql &= " where 1 = 2 "

            Call gpBindCombo(lssql, "packet_gnsarefno", "packet_gid", cboNewPkt, gOdbcConn)
        Else
            MsgBox("Invalid new packet !", MsgBoxStyle.Critical, gProjectName)
        End If
    End Sub
End Class