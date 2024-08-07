﻿Public Class frmPouchInwardAuth

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtagreementno.Text = ""
        txtgnsarefno.Text = ""
        txtagreementno.Focus()
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Dim lssql As String
        Dim lnAgreementGid As Long
        Dim lnPacketGid As Long
        Dim ds As New DataSet
        Dim lsRecvdDate As String = ""
        Dim lsinputdate As String


        If txtagreementno.Text.Trim = "" Then
            MsgBox("Please enter Agreement No", MsgBoxStyle.Critical, gProjectName)
            txtagreementno.Focus()
            Exit Sub
        End If

        If txtagreementno.Text.Length <> 6 And txtagreementno.Text.Length <> 7 Then
            MsgBox("Invalid Agreement No", MsgBoxStyle.Critical, gProjectName)
            txtgnsarefno.Focus()
            Exit Sub
        End If

        If txtgnsarefno.Text.Trim = "" Then
            MsgBox("Please enter GNSA REF No", MsgBoxStyle.Critical, gProjectName)
            txtgnsarefno.Focus()
            Exit Sub
        End If

        If (txtgnsarefno.Text.Length > 12 Or txtgnsarefno.Text.Length < 11) Then
            MsgBox("Invalid GNSA REF No", MsgBoxStyle.Critical, gProjectName)
            txtgnsarefno.Focus()
            Exit Sub
        End If

        If txtgnsarefno.Text.Length = 12 Then
            If IsNumeric(txtgnsarefno.Text.Substring(0, 1)) Then
                MsgBox("Invalid GNSA REF No", MsgBoxStyle.Critical, gProjectName)
                txtgnsarefno.Focus()
                Exit Sub
            End If
        End If

        If txtgnsarefno.Text.Length = 11 Then
            If Not IsNumeric(txtgnsarefno.Text.Substring(0, 1)) Then
                MsgBox("Invalid GNSA REF No", MsgBoxStyle.Critical, gProjectName)
                txtgnsarefno.Focus()
                Exit Sub
            End If
        End If

        lssql = ""
        lssql &= " select packet_gid from chola_trn_tpacket "
        lssql &= " where packet_gnsarefno='" & txtgnsarefno.Text.Trim & "'"
        lnPacketGid = Val(gfExecuteScalar(lssql, gOdbcConn))

        If lnPacketGid > 0 Then
            MsgBox("Duplicate GNSA REF No", MsgBoxStyle.Critical, gProjectName)
            txtgnsarefno.Focus()
            Exit Sub
        End If

        lssql = ""
        lssql &= " select * from chola_trn_tinward "
        lssql &= " where inward_shortagreementno='" & txtagreementno.Text.Trim & "'"
        lssql &= " and inward_packet_gid=0 "
        lssql &= " and inward_status & " & GCNEWFILE & " > 0"
        lssql &= " and inward_status & " & GCNOTRECEIVED & " = 0"
        lssql &= " and inward_status & " & GCRECEIVED & " = 0"
        lssql &= " and inward_status & " & GCCOMBINED & " = 0"

        gpDataSet(lssql, "Inward", gOdbcConn, ds)

        If ds.Tables("Inward").Rows.Count > 1 Then
            With ds.Tables("Inward")
                For i As Integer = 0 To .Rows.Count - 1
                    lsRecvdDate &= Format(CDate(.Rows(i).Item("inward_receiveddate").ToString), "dd-MM-yyyy") & ","
                Next
                MsgBox("More than one record found !", MsgBoxStyle.Critical, gProjectName)
                Do
                    lsinputdate = InputBox("Enter One Received Date: " & lsRecvdDate, gProjectName)
                Loop Until IsDate(lsinputdate) And InStr(lsRecvdDate, lsinputdate) > 0
            End With

            lssql = ""
            lssql &= " select * from chola_trn_tinward "
            lssql &= " where inward_shortagreementno='" & txtagreementno.Text.Trim & "'"
            lssql &= " and inward_receiveddate='" & Format(CDate(lsinputdate), "yyyy-MM-dd") & "'"
            lssql &= " and inward_packet_gid=0 "
            ds.Tables.Clear()
            gpDataSet(lssql, "Inward", gOdbcConn, ds)
        End If

        With ds.Tables("Inward")
            Select Case .Rows.Count
                Case 1

                    If (.Rows(0).Item("inward_paymode").ToString.ToUpper = "ECS" _
                        Or .Rows(0).Item("inward_paymode").ToString.ToUpper = "NPDC") _
                            And InStr(txtgnsarefno.Text.Trim.ToUpper, "P") > 0 Then
                        If MsgBox("This Agreement Marked as SPDC in Dump..!" & vbCrLf & " Do You Want to Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    If (.Rows(0).Item("inward_paymode").ToString.ToUpper = "PDC" _
                      Or .Rows(0).Item("inward_paymode").ToString.ToUpper = "RPDC") _
                          And InStr(txtgnsarefno.Text.Trim.ToUpper, "P") = 0 Then
                        If MsgBox("This Agreement Marked as PDC in Dump..!" & vbCrLf & " Do You Want to Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gProjectName) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    'Getting Agreement Gid
                    lssql = ""
                    lssql &= " select agreement_gid from chola_mst_tagreement "
                    lssql &= " where shortagreement_no='" & .Rows(0).Item("inward_shortagreementno").ToString & "'"

                    lnAgreementGid = Val(gfExecuteScalar(lssql, gOdbcConn))

                    If lnAgreementGid = 0 Then

                        lssql = ""
                        lssql &= " insert into chola_mst_tagreement(agreement_no,shortagreement_no) values( "
                        lssql &= "'" & .Rows(0).Item("inward_agreementno").ToString & "',"
                        lssql &= "'" & .Rows(0).Item("inward_shortagreementno").ToString & "')"

                        gfInsertQry(lssql, gOdbcConn)

                        lssql = ""
                        lssql &= " select agreement_gid from chola_mst_tagreement "
                        lssql &= " where shortagreement_no='" & .Rows(0).Item("inward_shortagreementno").ToString & "'"

                        lnAgreementGid = Val(gfExecuteScalar(lssql, gOdbcConn))
                    End If

                    'Insert into Packet Table
                    lssql = ""
                    lssql &= " insert into chola_trn_tpacket("
                    lssql &= " packet_agreement_gid,packet_inward_gid,packet_gnsarefno,packet_mode,packet_status,packet_entryby,packet_entryon,packet_receiveddate)"
                    lssql &= " values ("
                    lssql &= "" & lnAgreementGid & ","
                    lssql &= "" & .Rows(0).Item("inward_gid").ToString & ","
                    lssql &= "'" & txtgnsarefno.Text & "',"
                    lssql &= "'',"
                    lssql &= (GCINWARDENTRY Or GCAUTHENTRY) & ","
                    lssql &= "'" & gUserName & "',"
                    lssql &= " sysdate(),sysdate())"
                    gfInsertQry(lssql, gOdbcConn)

                    lssql = ""
                    lssql &= " select packet_gid from chola_trn_tpacket "
                    lssql &= " where packet_gnsarefno='" & txtgnsarefno.Text.Trim & "'"
                    lnPacketGid = gfExecuteScalar(lssql, gOdbcConn)

                    'Update in Inward Table
                    lssql = ""
                    lssql &= " update chola_trn_tinward "
                    lssql &= " set inward_packet_gid=" & lnPacketGid & ","
                    lssql &= " inward_status= inward_status | " & GCRECEIVED
                    lssql &= " where inward_gid=" & .Rows(0).Item("inward_gid").ToString
                    gfInsertQry(lssql, gOdbcConn)

                    'Log Packet
                    LogPacketHistory(txtgnsarefno.Text.Trim, (GCINWARDENTRY Or GCAUTHENTRY), lnPacketGid)

                    MsgBox("Record updated successfully !", MsgBoxStyle.Information, gProjectName)

                    btnclear.PerformClick()
                    txtagreementno.Focus()

                Case 0
                    MsgBox("Invalid Agreement No", MsgBoxStyle.Critical, gProjectName)
            End Select
            .Rows.Clear()
        End With
    End Sub

    Private Sub frmpouchinward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtgnsarefno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgnsarefno.GotFocus
        txtgnsarefno.SelectionStart = 7
        txtgnsarefno.SelectionLength = 5
        txtgnsarefno.Select()
    End Sub
End Class