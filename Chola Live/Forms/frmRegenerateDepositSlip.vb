Imports System.IO

Public Class frmRegenerateDepositSlip
    Dim lssql As String
    Private Sub frmRegenerateDepositSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lssql = " select type_flag,type_name from chola_mst_ttype where type_deleteflag='N' "
        gpBindCombo(lssql, "type_name", "type_flag", cboproduct, gOdbcConn)
        cboproduct.SelectedIndex = -1

        Me.KeyPreview = True
        MyBase.WindowState = FormWindowState.Maximized
        dtpcycledate.Focus()
    End Sub

    Private Sub frmRegenerateDepositSlip_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        With dgvDepositslipList
            pnlMain.Width = Me.Width - 30
            pnlMain.Height = Me.Height - 140
            .Height = pnlMain.Height - 10
            .Width = pnlMain.Width - 10

            lblTotRec.Top = pnlMain.Top + pnlMain.Height + 8
            lblTotRec.Left = pnlMain.Left
        End With
    End Sub

    Private Sub LoadData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsCond As String = ""

        lsSql = ""
        lsSql &= " select a.batchdepositslip_gid as 'Deposit Slip No', "
        'lsSql &= " group_concat(b.batch_no) as 'Batch No',a.batchdepositslip_tot_chq_count as 'Total Cheque Count', "
        lsSql &= " a.batchdepositslip_tot_chq_count as 'Total Cheque Count', "
        lsSql &= " Date_format(a.batchdepositslip_chq_date,'%d-%m-%Y') as 'Cycle Date',"
        lsSql &= " a.batchdepositslip_tot_chq_amount as 'Total Cheque Amount',a.batchdepositslip_type_name as 'Product', "
        lsSql &= " a.batchdepositslip_pdc_pickuplocation as 'Location' "
        lsSql &= " from chola_trn_tbatchdepositslip as a "
        'lsSql &= " inner join chola_trn_tbatch as b on a.batchdepositslip_gid = b.batchdepositslip_gid and b.batch_deleteflag = 'N' "
        lsSql &= " where a.batchdepositslip_deleteflag = 'N' and 1 = 1 "

        If txtDepositslipno.Text <> "" Then
            lsSql &= " and a.batchdepositslip_gid='" & txtDepositslipno.Text & "'"
        End If

        If cboproduct.Text.Trim <> "" Then
            lsSql &= " and a.batchdepositslip_type_name='" & cboproduct.Text & "'"
        End If

        If dtpcycledate.Checked Then
            lsSql &= " and a.batchdepositslip_chq_date='" & Format(dtpcycledate.Value, "yyyy-MM-dd") & "'"
        End If

        lsSql &= " order by a.batchdepositslip_gid"

        With dgvDepositslipList
            .Columns.Clear()
            gpPopGridView(dgvDepositslipList, lsSql, gOdbcConn)
            Dim dgButtonColumn2, dgButtonColumn3 As New DataGridViewButtonColumn
            dgButtonColumn2.HeaderText = "Deposit Slip"
            dgButtonColumn2.UseColumnTextForButtonValue = True
            dgButtonColumn2.Text = "Regenerate"
            dgButtonColumn2.Name = "Regenerate"
            dgButtonColumn2.ToolTipText = "Regenerate"
            dgButtonColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            dgButtonColumn2.FlatStyle = FlatStyle.System
            dgButtonColumn2.DefaultCellStyle.BackColor = Color.Gray
            dgButtonColumn2.DefaultCellStyle.ForeColor = Color.White
            .Columns.Add(dgButtonColumn2)

            dgButtonColumn3.HeaderText = "Action"
            dgButtonColumn3.UseColumnTextForButtonValue = True
            dgButtonColumn3.Text = "Delete"
            dgButtonColumn3.Name = "Delete"
            dgButtonColumn3.ToolTipText = "Delete"
            dgButtonColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            dgButtonColumn3.FlatStyle = FlatStyle.System
            dgButtonColumn3.DefaultCellStyle.BackColor = Color.Gray
            dgButtonColumn3.DefaultCellStyle.ForeColor = Color.White
            .Columns.Add(dgButtonColumn3)
            '.Columns(0).Visible = False
            lblTotRec.Text = "Total Records : " & (.RowCount).ToString
        End With
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Call LoadData()
        If dgvDepositslipList.Rows.Count <= 0 Then
            MsgBox("No records found", MsgBoxStyle.OkOnly, gProjectName)
            Exit Sub
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvDepositslipList.Rows.Count <= 0 Then
            Exit Sub
        End If
        Call PrintDGridXML(dgvDepositslipList, gsReportPath & "\BatchWiseDepositSlip.xls", "BatchDepositSlip")
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        dtpcycledate.Value = Now()
        dtpcycledate.Checked = False
        txtDepositslipno.Text = ""
        cboproduct.SelectedIndex = -1
        dgvDepositslipList.DataSource = Nothing
        dgvDepositslipList.Columns.Clear()
        lblTotRec.Text = ""
    End Sub


    Private Sub dgvDepositslipList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepositslipList.CellContentClick
        Dim lsbatchdepositslip_gid As Long
        Dim lnResult As Long
        Dim lsbatchdepositslip_chq_date As String
        Dim lsbatchdepositslip_tot_chq_amount, lsbatchdepositslip_tot_chq_count, lsbatchdepositslip_pdc_pickuplocation, lsProduct As String

        Select Case e.ColumnIndex
            Case Is > -1
                If sender.Columns(e.ColumnIndex).Name = "Delete" Then
                    If MsgBox("Are you sure want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.Yes Then

                        lsbatchdepositslip_gid = dgvDepositslipList.CurrentRow.Cells("Deposit Slip No").Value.ToString

                        'Update in Deposit slip table
                        lssql = ""
                        lssql &= " update chola_trn_tbatchdepositslip "
                        lssql &= " set batchdepositslip_deleteflag = 'Y' "
                        lssql &= " where batchdepositslip_gid = " & lsbatchdepositslip_gid & " and batchdepositslip_deleteflag = 'N' "

                        lnResult = gfInsertQry(lssql, gOdbcConn)

                        'Unlink the deposit slip no in batch table
                        lssql = ""
                        lssql &= " update chola_trn_tbatch "
                        lssql &= " set batchdepositslip_gid = '0' "
                        lssql &= " where batchdepositslip_gid = " & lsbatchdepositslip_gid & ""

                        lnResult = gfInsertQry(lssql, gOdbcConn)

                        dgvDepositslipList.DataSource = Nothing
                        dgvDepositslipList.Columns.Clear()
                    Else
                        Exit Sub
                    End If
                ElseIf sender.Columns(e.ColumnIndex).Name = "Regenerate" Then
                    'Generate Deposit Slip
                    Dim fileReader As String
                    Dim inputFile As String = "c:\temp\BDS_Template.rtf"


                    If dgvDepositslipList.Rows.Count > 0 Then
                        lsbatchdepositslip_gid = dgvDepositslipList.CurrentRow.Cells("Deposit Slip No").Value.ToString
                        lsProduct = dgvDepositslipList.CurrentRow.Cells("Product").Value.ToString
                        lsbatchdepositslip_chq_date = dgvDepositslipList.CurrentRow.Cells("Cycle Date").Value.ToString
                        lsbatchdepositslip_tot_chq_amount = dgvDepositslipList.CurrentRow.Cells("Total Cheque Amount").Value.ToString
                        lsbatchdepositslip_tot_chq_count = dgvDepositslipList.CurrentRow.Cells("Total Cheque Count").Value.ToString
                        lsbatchdepositslip_pdc_pickuplocation = dgvDepositslipList.CurrentRow.Cells("Location").Value.ToString

                        fileReader = My.Computer.FileSystem.ReadAllText(inputFile)
                        fileReader = fileReader.Replace("<<Deposit Slip No>>", lsbatchdepositslip_gid)
                        fileReader = fileReader.Replace("<<Product Code>>", lsProduct)
                        fileReader = fileReader.Replace("<<Cycle Date>>", lsbatchdepositslip_chq_date)
                        fileReader = fileReader.Replace("<<Deposit Amount>>", lsbatchdepositslip_tot_chq_amount)
                        fileReader = fileReader.Replace("<<Cheque Count>>", lsbatchdepositslip_tot_chq_count)
                        fileReader = fileReader.Replace("<<Location>>", lsbatchdepositslip_pdc_pickuplocation)
                    End If

                    Dim outputFile As String = "C:\BatchDepositSlip"

                    ' If folder doesnot exists means create a directory folder
                    If Not System.IO.Directory.Exists(outputFile) Then
                        System.IO.Directory.CreateDirectory(outputFile)
                    End If

                    Dim filename As String
                    filename = lsbatchdepositslip_gid.ToString + "_" + lsbatchdepositslip_pdc_pickuplocation

                    outputFile = Path.ChangeExtension(outputFile + "\" + filename + ".rtf", ".rtf")

                    ' Read our HTML file a string.
                    Dim htmlString As String = File.ReadAllText(inputFile)

                    ' Open the result for demonstration purposes.
                    If Not String.IsNullOrEmpty(outputFile) Then
                        File.WriteAllText(outputFile, fileReader)
                        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outputFile) With {.UseShellExecute = True})
                    End If

                End If
        End Select
    End Sub

End Class