Imports Microsoft.VisualBasic

Public Class ADUtility
    Function GetADEntry(ByVal ADDomain As String, ByVal ADUser As String, ByVal ADPWD As String) As Integer
        Try
            Dim ADEntry As System.DirectoryServices.DirectoryEntry
            Dim DC_StrAry As Array
            Dim DC_Str As String
            Dim i_Num As Integer
            Dim path As String
            Dim GetADEntry_tempstr As String

            GetADEntry = 0
            If InStr(ADDomain, ".") = 0 Or Len(ADUser) = 0 Then
                GetADEntry = Nothing
                Exit Function
            Else
                DC_Str = ""
                DC_StrAry = Split(ADDomain, ".")

                For i_Num = 0 To UBound(DC_StrAry)
                    DC_Str = DC_Str & "DC=" & Trim(DC_StrAry(i_Num)) & ","
                Next

                Erase DC_StrAry
                DC_Str = Left(DC_Str, Len(DC_Str) - 1)
            End If

            path = "LDAP://" & ADDomain & "/" & DC_Str

            ADEntry = New System.DirectoryServices.DirectoryEntry(path, ADUser, ADPWD)
            GetADEntry_tempstr = ADEntry.Guid.ToString
            ADEntry = Nothing
            GetADEntry = 1
        Catch ex As Exception
            GetADEntry = 0
        End Try

    End Function

End Class
