Imports System.IO
Public Class frmMandatePullout
    Dim lival, lidup, litotal As Integer
    Dim lsErrorLogPath As String = Application.StartupPath & "\errorlog.txt"
    Dim msSql As String = ""

    Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            If txtFileName.Text.Trim = "" Then
                MessageBox.Show("File path should not be empty", gProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFileName.Focus()
                Exit Sub
            End If

            If cboSheetName.Text.Trim = "" Then
                MessageBox.Show("Sheet name should not be empty ", gProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                cboSheetName.Focus()
                Exit Sub
            End If

            lival = 0
            lidup = 0
            litotal = 0
            pnlWrapper.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            lblTotal.Visible = True
            Importexcel(txtFileName.Text, cboSheetName.Text)
            MessageBox.Show("Total Records:" & litotal & " ;Valid Records:" & lival & " ;Duplicate Record:" & lidup & vbCrLf & "Please review the Error Log in the path " & lsErrorLogPath, "CHOLA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlWrapper.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CHOLA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pnlWrapper.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub LoadSheet()
        Dim objXls As New Microsoft.Office.Interop.Excel.Application
        Dim objBook As Microsoft.Office.Interop.Excel.Workbook

        If Trim(txtFileName.Text) <> "" Then
            If File.Exists(txtFileName.Text) Then
                objBook = objXls.Workbooks.Open(txtFileName.Text)
                cboSheetName.Items.Clear()
                For i As Integer = 1 To objXls.ActiveWorkbook.Worksheets.Count
                    cboSheetName.Items.Add(objXls.ActiveWorkbook.Worksheets(i).Name)
                Next i
                objXls.Workbooks.Close()
            End If
        End If
        objXls.Quit()
        ' KillProcess(objXls.Hwnd)
    End Sub

    Private Sub Importexcel(ByVal FilePath As String, ByVal SheetName As String)
        Dim lExcelDatatable As New DataTable
        Dim ds As New DataSet
        Dim lssql As String = ""
        Dim liIsDuplicate As Integer = 0
        Dim lsFileMstGid As String
        Dim lsDuplicatedtl As String = ""
        Dim lnAgreementId As Long = 0
        Dim lnReasonId As Long = 0
        Dim lnPacketId As Long = 0
        Dim lnSpdcentryId As Long = 0
        Dim lsmadatepullout_count As Long = 0
        Dim lsspdcentry_ecsmandatecount As Long = 0
        Dim lssumpullout_count As Long = 0
        Dim lsDisc As String = ""
        Dim lsSheetName As String = SheetName
        Dim lsFileName As String
        Dim lsFieldName() As String
        Dim lsFldNmesInfo As String = ""
        Dim lsPulloutdate As String = ""
        Dim lsAgreementNo As String = ""
        Dim lsShortAgreementNo As String = ""
        Dim lsPktNo As String = ""
        Dim lsPulloutCount As Long
        Dim lsReason As String = ""
        Dim n As Long = 0
        Dim lnPktPulloutId As Long = 0
        Dim lnResult As Long = 0

        lsFldNmesInfo = "SNo|Pullout Date|Pullout Count|Agreement No|Short Agreement No|GNSA Ref No|Reason"

        lsFieldName = Split(lsFldNmesInfo, "|")

        'Open Error Log File
        If File.Exists(lsErrorLogPath) Then
            FileOpen(1, lsErrorLogPath, OpenMode.Output)
        Else
            File.Create(lsErrorLogPath)
        End If

        Try
            lsFileName = Path.GetFileName(FilePath).ToUpper

            PrintLine(1, "SNo|Pullout Date|Pullout Count|Agreement No|Short Agreement No|GNSA Ref No|Reason|Error")

            'Retrive Datas From Excel Sheet
            lExcelDatatable = gpExcelDataset("SELECT * FROM [" & lsSheetName & "$]", FilePath)

            'Checking Column Header
            For liIndex As Integer = 0 To lExcelDatatable.Columns.Count - 1
                If (lsFieldName(liIndex).Trim.ToUpper <> lExcelDatatable.Columns(liIndex).ColumnName.ToString.ToUpper) Then
                    MessageBox.Show("Invalid File Header, Correct Header is " & lsFldNmesInfo, "CHOLA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    FileClose(1)
                    Exit Sub
                End If
            Next

            lssql = " select file_gid from chola_mst_tfile where file_name='" & lsFileName & "' and file_sheetname='" & SheetName & "'"

            If Val(gfExecuteScalar(lssql, gOdbcConn)) <> 0 Then
                MsgBox("File Name Already Imported", MsgBoxStyle.Information)
                Me.Cursor = Cursors.Default
                btnImport.Enabled = True
                lblTotal.Visible = False
                FileClose(1)
                Exit Sub
            End If

            Try
                lssql = " insert into chola_mst_tfile(file_name,file_sheetname,import_by,import_on)"
                lssql &= " values"
                lssql &= "("
                lssql &= "'" & lsFileName & "',"
                lssql &= "'" & SheetName & "',"
                lssql &= "'" & gUserName & "',"
                lssql &= "'" & Format(CDate(Now()), "yyyy-MM-dd") & "'"
                lssql &= ")"

                lssql = gfInsertQry(lssql, gOdbcConn)
                If lssql = "" Then
                    MsgBox("Error occured in insertion", MsgBoxStyle.Information, gProjectName)
                    Application.UseWaitCursor = False
                    FileClose(1)
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox("Error occured in insertion", MsgBoxStyle.Information, gProjectName)
                Application.UseWaitCursor = False
                FileClose(1)
                Exit Sub
            End Try

            lssql = " select file_gid from chola_mst_tfile where file_name='" & lsFileName & "' and file_sheetname='" & SheetName & "'"

            lsFileMstGid = gfExecuteScalar(lssql, gOdbcConn)

            'Insert Record to the Table
            For liIndex As Integer = 0 To lExcelDatatable.Rows.Count - 1
                n += 1
                litotal = lExcelDatatable.Rows.Count
                lblTotal.Text = "Processing " & liIndex + 1 & "/" & lExcelDatatable.Rows.Count
                Application.DoEvents()

                lsPulloutdate = Format(CDate(QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Pullout Date").ToString.Trim)), "yyyy-MM-dd")
                lsPulloutCount = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Pullout Count").ToString.Trim)
                lsAgreementNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Agreement No").ToString.Trim)
                lsShortAgreementNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Short Agreement No").ToString.Trim)
                lsPktNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("GNSA Ref No").ToString.Trim)
                lsReason = Mid(QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Reason").ToString.Trim), 1, 125)


                If lsPktNo = "" And lsAgreementNo = "" And lsReason = "" Then
                    GoTo GoNext
                End If

                If lsPktNo = "" Or lsReason = "" Or lsAgreementNo = "" Then
                    lidup += 1
                    liIsDuplicate += 1

                    Select Case ""
                        Case lsPktNo
                            lsDisc = "Blank Gnsa Ref No"
                        Case lsAgreementNo
                            lsDisc = "Blank Agreement No"
                        Case lsReason
                            lsDisc = "Blank Reason"
                    End Select

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|" & lsDisc
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                ' get agreement_gid

                lssql = ""
                lssql &= " select agreement_gid from chola_mst_tagreement "
                lssql &= " where agreement_no = '" & lsAgreementNo & "' "
                lssql &= " and shortagreement_no = '" & lsShortAgreementNo & "' "

                lnAgreementId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnAgreementId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Invalid Agreement"
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                ' get reason_gid

                lssql = ""
                lssql &= " select reason_gid from chola_mst_tpulloutreason "
                lssql &= " where reason_name = '" & lsReason & "' "

                lnReasonId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnReasonId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Invalid Reason"
                    PrintLine(1, lsDuplicatedtl)

                    GoTo GoNext
                End If

                ' get packet_gid

                lssql = ""
                lssql &= " select packet_gid from chola_trn_tpacket "
                lssql &= " where packet_gnsarefno = '" & lsPktNo & "' "
                lssql &= " and packet_agreement_gid = '" & lnAgreementId & "' "

                lnPacketId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnPacketId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Invalid GNSA Ref No"
                    PrintLine(1, lsDuplicatedtl)

                    GoTo GoNext
                End If

                ' get spdcentry_gid

                lssql = ""
                lssql &= " select spdcentry_gid from chola_trn_tspdcentry "
                lssql &= " where spdcentry_packet_gid = '" & lnPacketId & "' "
                lssql &= " and spdcentry_ecsmandatecount > 0 "

                lnSpdcentryId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnSpdcentryId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Invalid spdc Entry"
                    PrintLine(1, lsDuplicatedtl)

                    GoTo GoNext
                End If


                'Duplicate check

                lssql = ""
                lssql &= " select count(*) from chola_trn_tmandatepullout "
                lssql &= " where mandatepullout_gnsarefno = '" & lsPktNo & "' "
                lssql &= " and mandatepulloutdate = '" & lsPulloutdate & "' "

                lnResult = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnResult > 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Duplicate Record"
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If


                If lsPulloutCount <= 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsPulloutdate & "|" & lsPulloutCount & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPktNo & "|" & lsReason & "|Mandate Pullout Count should be greater than zero"
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                Else
                    ' get madatepullout_count in spdc entry table

                    lssql = ""
                    lssql &= " select ecsmandatepulloutcount from chola_trn_tspdcentry "
                    lssql &= " where spdcentry_gid = '" & lnSpdcentryId & "' "

                    lsmadatepullout_count = Val(gfExecuteScalar(lssql, gOdbcConn))

                    ' get spdcentry_ecsmandatecount in spdc entry table

                    lssql = ""
                    lssql &= " select spdcentry_ecsmandatecount from chola_trn_tspdcentry "
                    lssql &= " where spdcentry_gid = '" & lnSpdcentryId & "' "

                    lsspdcentry_ecsmandatecount = Val(gfExecuteScalar(lssql, gOdbcConn))
                    lssumpullout_count = lsmadatepullout_count + lsPulloutCount

                    If lsspdcentry_ecsmandatecount >= lssumpullout_count Then
                        lssql = ""
                        lssql = " update chola_trn_tspdcentry set ecsmandatepulloutcount = "
                        lssql &= "" & lssumpullout_count & ""
                        lssql &= " where spdcentry_gid = '" & lnSpdcentryId & "' "

                        Call gfInsertQry(lssql, gOdbcConn)
                    Else
                        liIsDuplicate += 1

                        lsDuplicatedtl = n & "|" & lsReason & "|Mandate count is : " + lsspdcentry_ecsmandatecount.ToString() + " But Pullout count is : " + lssumpullout_count.ToString()
                        PrintLine(1, lsDuplicatedtl)
                        GoTo GoNext
                    End If
                End If

                Try
                    lssql = ""
                    lssql = " Insert into chola_trn_tmandatepullout (mandatepullout_filegid,mandatepulloutdate,mandatepullout_count,mandatepullout_agreementno,mandatepullout_shortagreementno,mandatepullout_gnsarefno,spdcentry_gid,mandatepullout_reasongid,mandatepullout_insertby,mandatepullout_insertdate)"
                    lssql &= " values ("
                    lssql &= lsFileMstGid & ","
                    lssql &= "'" & lsPulloutdate & "',"
                    lssql &= "'" & lsPulloutCount & "',"
                    lssql &= "'" & lsAgreementNo & "',"
                    lssql &= "'" & lsShortAgreementNo & "',"
                    lssql &= "'" & lsPktNo & "',"
                    lssql &= "'" & lnSpdcentryId & "',"
                    lssql &= "'" & lnReasonId & "',"
                    lssql &= "'" & gUserName & "',"
                    lssql &= "'" & Format(CDate(Now()), "yyyy-MM-dd") & "')"

                    Call gfInsertQry(lssql, gOdbcConn)

                    lival += 1
                Catch ex As Exception
                    MsgBox("Error occured in inserting", MsgBoxStyle.Information, gProjectName)
                    Application.UseWaitCursor = False
                    FileClose(1)
                    Exit Sub
                End Try
GoNext:
            Next

            FileClose(1)

            If liIsDuplicate > 0 Then
                System.Diagnostics.Process.Start(lsErrorLogPath)
            End If

        Catch ex As Exception
            FileClose(1)
            MessageBox.Show(ex.Message, "CHOLA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Excel Files|*.xls"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName.Length <> 0 Then
            txtFileName.Text = OpenFileDialog1.FileName
        End If
        Call LoadSheet()
        Exit Sub
    End Sub

    Private Sub frmpacketpullout_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmpacketpullout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblTotal.Visible = False
        Me.KeyPreview = True
        txtFileName.Focus()
        txtFileName.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class