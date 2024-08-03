Imports System.IO

Public Class frmMandatecountUpdation
    Dim lival, lidup, litotal As Integer
    Dim lsErrorLogPath As String = Application.StartupPath & "\errorlog.txt"
    Dim lsagreementno As String = ""
    Dim lsgnsarefno As String = ""
    Private Sub frmMandatecountUpdation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotal.Visible = False
        Me.KeyPreview = True
        txtFileName.Focus()
        txtFileName.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
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

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog.Filter = "Excel Files|*.xls"
        OpenFileDialog.ShowDialog()

        If OpenFileDialog.FileName.Length <> 0 Then
            txtFileName.Text = OpenFileDialog.FileName
        End If
        Call LoadSheet()
        Exit Sub
    End Sub

    Private Sub frmMandatecountUpdation_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub Importexcel(ByVal FilePath As String, ByVal SheetName As String)
        Dim drpacket As Odbc.OdbcDataReader
        Dim lExcelDatatable As New DataTable
        Dim lssql As String = ""
        Dim liIsDuplicate As Integer = 0
        Dim lsFileMstGid As String
        Dim lsDuplicatedtl As String = ""
        Dim lsSheetName As String = SheetName
        Dim lsFileName As String
        Dim lsFieldName() As String
        Dim lsFldNmesInfo As String = ""

        Dim lnAgreementGid As Long
        Dim lnPacketGid As Long
        Dim liProduct As Integer
        Dim lsEntryMode As String = ""
        Dim lcPacketDisc As String = ""
        Dim lsmandatecount As String = ""

        lsFldNmesInfo = "SLNo|GNSAREFNO|AGREEMENTNO|MANDATECOUNT"

        lsFieldName = Split(lsFldNmesInfo, "|")

        'Open Error Log File
        If File.Exists(lsErrorLogPath) Then
            FileOpen(1, lsErrorLogPath, OpenMode.Output)
        Else
            File.Create(lsErrorLogPath)
        End If

        Try
            lsFileName = Path.GetFileName(FilePath).ToUpper

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
                litotal = lExcelDatatable.Rows.Count
                lblTotal.Text = "Processing " & liIndex + 1 & "/" & lExcelDatatable.Rows.Count
                Application.DoEvents()

                lsagreementno = lExcelDatatable.Rows(liIndex).Item("AGREEMENTNO").ToString.Trim()
                lsgnsarefno = lExcelDatatable.Rows(liIndex).Item("GNSAREFNO").ToString.Trim()
                lsmandatecount = lExcelDatatable.Rows(liIndex).Item("MANDATECOUNT").ToString.Trim()

                If lsgnsarefno = "" Then
                    lidup += 1
                    liIsDuplicate += 1
                    lsDuplicatedtl = Now() & "  Gnsa Refno Empty.. "
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                If lsagreementno = "" Or lsagreementno = "0" Then
                    lidup += 1
                    liIsDuplicate += 1
                    lsDuplicatedtl = Now() & "  Agreement No Empty.. "
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If


                lssql = " select * from chola_trn_tpacket"
                lssql &= " where packet_gnsarefno='" & lsgnsarefno & "'"

                drpacket = gfExecuteQry(lssql, gOdbcConn)

                If drpacket.HasRows Then
                    While drpacket.Read
                        lnAgreementGid = Val(drpacket.Item("packet_agreement_gid").ToString)
                        lnPacketGid = Val(drpacket.Item("packet_gid").ToString)
                    End While
                Else
                    lidup += 1
                    liIsDuplicate += 1
                    lsDuplicatedtl = Now() & "  Invalid Packet "
                    PrintLine(1, lsDuplicatedtl)
                    GoTo GoNext
                End If

                'lssql = ""
                'lssql &= " select agreement_prodtype "
                'lssql &= " from chola_mst_tagreement "
                'lssql &= " where agreement_gid=" & lnAgreementGid

                'liProduct = Val(gfExecuteScalar(lssql, gOdbcConn))

                'lssql = ""
                'lssql &= " select pdc_mode "
                'lssql &= " from chola_trn_tpdcfile "
                'lssql &= " where pdc_shortpdc_parentcontractno='" & lsagreementno & "'"

                'lsEntryMode = Val(gfExecuteScalar(lssql, gOdbcConn))

                lcPacketDisc = "Y"

                lssql = ""
                lssql &= "insert into chola_trn_tspdcentry ("
                lssql &= " spdcentry_packet_gid,spdcentry_spdccount,spdcentry_ecsmandatecount,"
                lssql &= " spdcentry_ctschqcount,spdcentry_nonctschqcount,spdcentry_remarks,"
                lssql &= " spdcentry_accountno,spdcentry_micrcode,spdcentry_startdate,spdcentry_enddate,spdcentry_ecsamount)"
                lssql &= " values ("
                lssql &= "" & lnPacketGid & ","
                lssql &= "0,"
                lssql &= "" & lsmandatecount & ","
                lssql &= "0,"
                lssql &= "0,"
                lssql &= "'',"
                lssql &= "'',"
                lssql &= "'',"
                lssql &= "null,"
                lssql &= "null,"
                lssql &= "null)"
                gfInsertQry(lssql, gOdbcConn)

                LogPacket("", GCPACKETCHEQUEENTRY, lnPacketGid, "SPDC", , , lcPacketDisc, "N")
                UpdateAlmara(lsgnsarefno, "SPDC")
                LogPacketHistory("", GCPACKETCHEQUEENTRY, lnPacketGid)

                lival += 1

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

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
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
            MessageBox.Show("Total Records:" & litotal & " ;Valid Records:" & lival & " ;Duplicate/Invalid Record:" & lidup & vbCrLf & "Please review the Error Log in the path " & lsErrorLogPath, "CHOLA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlWrapper.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gProjectName)
            pnlWrapper.Enabled = True
            Me.Cursor = Cursors.Default
            Application.UseWaitCursor = False
            FileClose(1)
            Exit Sub
        End Try
    End Sub
End Class