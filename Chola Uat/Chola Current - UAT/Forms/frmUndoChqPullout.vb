Imports System.IO

Public Class frmUndoChqPullout
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
        Dim lnpulloutId As Long = 0
        Dim lnentryId As Long = 0
        Dim lsmadatepullout_count As Long = 0
        Dim lsspdcentry_ecsmandatecount As Long = 0
        Dim lssumpullout_count As Long = 0
        Dim lsDisc As String = ""
        Dim lsSheetName As String = SheetName
        Dim lsFileName As String
        Dim lsFieldName() As String
        Dim lsFldNmesInfo As String = ""
        Dim lsPulloutChequedate As String = ""
        Dim lsPulloutChequeNo As Long = 0
        Dim lsPulloutChequeAmount As Double = 0.0
        Dim lsAgreementNo As String = ""
        Dim lsShortAgreementNo As String = ""
        Dim lsPktNo As String = ""
        Dim lsReason As String = ""
        Dim lsRemark As String = ""
        Dim n As Long = 0
        Dim lnPktPulloutId As Long = 0
        Dim lnResult As Long = 0

        lsFldNmesInfo = "SNo|Agreement No|Short Agreement No|Pullout Cheque No|Pullout Cheque Date|Pullout Cheque Amount"

        lsFieldName = Split(lsFldNmesInfo, "|")

        'Open Error Log File
        If File.Exists(lsErrorLogPath) Then
            FileOpen(1, lsErrorLogPath, OpenMode.Output)
        Else
            File.Create(lsErrorLogPath)
        End If

        Try
            lsFileName = Path.GetFileName(FilePath).ToUpper

            PrintLine(1, "SNo|Agreement No|Short Agreement No|Pullout Cheque No|Pullout Cheque Date|Pullout Cheque Amount|Error")

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

                lsAgreementNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Agreement No").ToString.Trim)
                lsShortAgreementNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Short Agreement No").ToString.Trim)
                lsPulloutChequeNo = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Pullout Cheque No").ToString().PadLeft(6, "0").Trim)
                lsPulloutChequedate = Format(CDate(QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Pullout Cheque Date").ToString.Trim)), "yyyy-MM-dd")
                lsPulloutChequeAmount = QuoteFilter(lExcelDatatable.Rows(liIndex).Item("Pullout Cheque Amount").ToString.Trim)

                If lsAgreementNo = "" And lsShortAgreementNo = "" Then
                    GoTo GoNext
                End If

                If lsAgreementNo = "" Or lsShortAgreementNo = "" Then
                    lidup += 1
                    liIsDuplicate += 1

                    Select Case ""
                        Case lsAgreementNo
                            lsDisc = "Blank Agreement No"
                        Case lsShortAgreementNo
                            lsDisc = "Blank Short Agreement No"
                    End Select

                    lsDuplicatedtl = n & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPulloutChequeNo & "|" & lsPulloutChequedate & "|" & lsPulloutChequeAmount & "|" & lsReason & "|" & lsRemark & "|" & lsDisc
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                ' get agreement_gid

                lssql = ""
                lssql &= " select agreement_gid from chola_mst_tagreement "
                lssql &= " where agreement_no = '" & lsAgreementNo & "' "

                lnAgreementId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnAgreementId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPulloutChequeNo & "|" & lsPulloutChequedate & "|" & lsPulloutChequeAmount & "|" & lsReason & "|" & lsRemark & "|Invalid Agreement"
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                ' get entry_gid

                lssql = ""
                lssql &= " select pullout_entrygid from chola_trn_tpullout "
                lssql &= " where pullout_agreementno = '" & lsAgreementNo & "' "
                lssql &= " and pullout_chqno = '" & lsPulloutChequeNo.ToString().PadLeft(6, "0") & "' "
                lssql &= " and pullout_chqdate = '" & lsPulloutChequedate & "' "
                lssql &= " and pullout_chqamount = '" & lsPulloutChequeAmount & "' "

                lnentryId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnentryId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPulloutChequeNo & "|" & lsPulloutChequedate & "|" & lsPulloutChequeAmount & "|Invalid Record"
                    PrintLine(1, lsDuplicatedtl)

                    GoTo GoNext
                End If

                ' get pullout id

                lssql = ""
                lssql &= " select pullout_gid from chola_trn_tpullout "
                lssql &= " where pullout_agreementno = '" & lsAgreementNo & "' "
                lssql &= " and pullout_chqno = '" & lsPulloutChequeNo.ToString().PadLeft(6, "0") & "' "
                lssql &= " and pullout_chqdate = '" & lsPulloutChequedate & "' "
                lssql &= " and pullout_chqamount = '" & lsPulloutChequeAmount & "' "

                lnpulloutId = Val(gfExecuteScalar(lssql, gOdbcConn))

                If lnpulloutId = 0 Then
                    liIsDuplicate += 1

                    lsDuplicatedtl = n & "|" & lsAgreementNo & "|" & lsShortAgreementNo & "|" & lsPulloutChequeNo & "|" & lsPulloutChequedate & "|" & lsPulloutChequeAmount & "|This Record status Not in pullout status"
                    PrintLine(1, lsDuplicatedtl)

                    GoTo GoNext
                End If

                Try
                    'Reverse Pulout Entry
                    lssql = ""
                    lssql &= " update chola_trn_tpdcentry "
                    lssql &= " set chq_status = ( chq_status | 256 |64 | 32 ) ^ (256 | 64 | 32) "
                    lssql &= " where entry_gid = " & lnentryId

                    Call gfInsertQry(lssql, gOdbcConn)

                    'Copy to Pullout delete table
                    lssql = ""
                    lssql &= " insert into chola_trn_tpulloutdel "
                    lssql &= " select * from chola_trn_tpullout "
                    lssql &= " where pullout_gid = " & lnPulloutId

                    Call gfInsertQry(lssql, gOdbcConn)

                    'Reverse From Pullout Table
                    lssql = ""
                    lssql &= " delete from chola_trn_tpullout "
                    lssql &= " where pullout_gid = " & lnPulloutId

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