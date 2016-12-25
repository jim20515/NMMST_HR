Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.IO
Imports System.Text

Partial Class WebApp_sys_d_d02_choosexls
    Inherits System.Web.UI.Page
    'Public erpobj As New funGetData
    'Public conn As SqlConnection
    Public cid As Integer
    Public aid As String = ""
    Public eid As String = ""
    '存檔路徑
    Public filepatch As String = "../d02/"
    Dim returnpath As String = ""

    'C:\NMMST_HR\WebApp\sys_d\d02\choosexls.aspx.vb

    'Public Sub New()
    '    Dim tmpconnstr As String = "Data Source=192.168.0.103\sqlexpress;Initial Catalog=NMMST_BU;User ID=NMS;Password=04271129"
    '    'conn = erpobj.get_conn("conn")
    '    Dim conn As System.Data.SqlClient.SqlConnection
    '    conn = New System.Data.SqlClient.SqlConnection(tmpconnstr)
    '    conn.Open()
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.BufferOutput = True

        'Javascript加入()
        jsscript.InnerHtml += "<script language='javascript'>" & vbCrLf
        jsscript.InnerHtml += "function checkdata(){" & vbCrLf
        jsscript.InnerHtml += " var errmsg ="""";" & vbCrLf
        jsscript.InnerHtml += " if(document." & form1.ClientID & "." & wfile.ClientID & ".value=='')" & vbCrLf
        jsscript.InnerHtml += " errmsg = errmsg + '請選擇檔案\n'" & vbCrLf

        jsscript.InnerHtml += "if(errmsg!=''){alert(errmsg);return false;}" & vbCrLf
        jsscript.InnerHtml += "}</script>" & vbCrLf

        form1.Action = aid
        '送出
        btnsent.Attributes.Add("onClick", "return checkdata();")

    End Sub

    Public Function FunUpLoadPic(ByVal Up As System.Web.UI.WebControls.FileUpload, ByVal SaveStr As String, ByVal FName As String, ByVal Page As Page) As String()
        '===本函數需傳入6個參數
        '===1.System.Web.UI.WebControls.FileUpload檔案上傳物件
        '===2.儲存路徑
        '===3.檔名
        '===4.整個Page
        Dim tmparr() As String = {"", ""}
        ' MsgBox(Up.PostedFile.FileName)

        If Up.PostedFile.FileName <> Nothing Then
            Dim Fs As System.IO.Stream = Up.PostedFile.InputStream '===宣告資料流
            'Dim PicValue As Decimal '===宣告縮放比例
            Up.PostedFile.SaveAs(SaveStr & "\B" & FName) '===儲存原始圖
            tmparr(0) = "B" & FName
            'End If
        End If
        FunUpLoadPic = tmparr
    End Function

    Public Sub adddofunction()

        Dim tmpconnstr As String = "Data Source=ES;Initial Catalog=NMMST_HR;User ID=sa;Password=fujitsu"
        Dim conn As System.Data.SqlClient.SqlConnection
        conn = New System.Data.SqlClient.SqlConnection(tmpconnstr)
        conn.Open()

        Dim conn1 As System.Data.SqlClient.SqlConnection
        conn1 = New System.Data.SqlClient.SqlConnection(tmpconnstr)
        conn1.Open()

        Dim conn2 As System.Data.SqlClient.SqlConnection
        conn2 = New System.Data.SqlClient.SqlConnection(tmpconnstr)
        conn2.Open()

        Dim smd As New System.Data.SqlClient.SqlCommand()
        Dim smd1 As New System.Data.SqlClient.SqlCommand()

        Dim dr1 As System.Data.SqlClient.SqlDataReader
        Dim dr2 As System.Data.SqlClient.SqlDataReader

        '上傳資料至主機
        Dim BasicPath As String = Server.MapPath(filepatch) '主機放圖檔路徑 
        Dim upfile1 As FileUpload = form1.FindControl("wfile") '取得控制項代號
        Dim tmpfilename As String = ""
        Dim timgsno As String = "sample"
        If upfile1.PostedFile.ContentLength <> 0 Then
            'Dim timgsno As String = Trim(Session("md201vid"))
            Dim tfile = Trim(upfile1.FileName)
            Dim FileName As String = timgsno & tfile.Substring(InStrRev(tfile, ".") - 1)
            Dim tmparr As String() = FunUpLoadPic(upfile1, BasicPath, FileName, Me)
            tmpfilename = Trim(tmparr(0))
            'Response.Write(filepatch)
            'Response.End()
        End If

        Dim rootPath As String = Server.MapPath("~")
        'C:\NMMST_HR\WebApp\sys_d\d02\choosexls.aspx.vb
        Dim tmpall As String = ""
        '讀檔路徑
        rootPath += "..\sys_d\d02\" & tmpfilename
        tmpall = readfile(rootPath)
        'Response.End()
        'Dim conn1 As New SqlConnection
        'conn1 = erpobj.get_conn("conn")        

        Dim tmpstridno As Array
        Dim tmparry As Array
        tmpstridno = Split(tmpall, vbCrLf)

        Dim nowyear As String = ""
        nowyear = Year(Now()) - 1911

        Dim defnum1 As Integer
        Dim defnum3 As Integer

        Dim hmd201_id As String = ""
        Dim hmd201_vid As String = ""

        Dim i As Integer
        For i = 1 To tmpstridno.Length - 1

            tmparry = Split(tmpstridno(i), ",")
            If Trim(tmparry(0)) <> "" Then

                Dim sqlstr As String = ""
                Dim sqlstr1 As String = ""
                Dim sqlstr2 As String = ""

                sqlstr = "Select * from hmd201 where 1 <> 1"

                '新增資料的語法
                Dim sd As SqlDataAdapter = New SqlDataAdapter(sqlstr, conn)
                'Response.Write(sd)
                'Response.End()
                'sd.SelectCommand = erpobj.get_cmd(conn, "select * from NMS_ORG_Hour where NMS_Eid =" & eid & " and NMS_MUnit='" & Trim(Session("Studyoid")) & "' and NMS_OMid='" & Trim(tmparry(0)) & "'")
                'sd.SelectCommand = (conn,"select * from hmd201 where 1 <> 1 ")
                Dim dset As DataSet = New DataSet()
                sd.Fill(dset)

                If dset.Tables(0).Rows().Count = 0 Then

                    Dim dt As DataTable
                    dt = dset.Tables(0)
                    Dim dr As DataRow
                    dr = dt.NewRow()


                    sqlstr2 = "SELECT  TOP (1) hmd201_vid FROM hmd201 ORDER BY hmd201_vid DESC"
                    'Response.Write(sqlstr1)
                    'Response.End()
                    smd1.CommandText = sqlstr2
                    smd1.Connection = conn2
                    dr2 = smd1.ExecuteReader()
                    dr2.Read()
                    If DBNull.Value.Equals(dr2("hmd201_vid")) = False Then
                        'If Trim(dr1("hmc101_id")) <> "" Then
                        Dim vyear As String = ""
                        'Dim nowyear As String = ""
                        Dim defnum2 As String = ""

                        defnum2 = "00001"

                        vyear = (dr2("hmd201_vid")).Substring(1, 3)


                        'Response.Write(fyear)
                        'Response.End()

                        If vyear < nowyear Then

                            hmd201_vid = "V" & nowyear & "-" & defnum2

                            dr("hmd201_vid") = hmd201_vid

                        ElseIf vyear = nowyear Then

                            defnum3 = (dr2("hmd201_vid")).Substring(5, 5)
                            'Int32.Parse(defnum1)
                            defnum3 += 1
                            hmd201_vid = "V" & nowyear & "-" & defnum3.ToString("00000")

                            dr("hmd201_vid") = hmd201_vid

                        End If

                        'Response.Write(vyear)
                        'Response.End()
                        'Response.Write(dr1("hmc101_id"))
                        '如果為空的處理
                        'Else
                        'Response.Write("0")
                    End If


                    dr2.Dispose()
                    dr2.Close()

                    'dr("hmd201_vid") = "V104-00001"

                    'ls_id = c01Project.uf_Get_SystemNo("hmc101.hmc101_id", "")

                    sqlstr1 = "SELECT  TOP (1) hmc101_id FROM hmc101 ORDER BY hmc101_id DESC"
                    'Response.Write(sqlstr1)
                    'Response.End()
                    smd.CommandText = sqlstr1
                    smd.Connection = conn1
                    dr1 = smd.ExecuteReader()
                    dr1.Read()
                    If DBNull.Value.Equals(dr1("hmc101_id")) = False Then
                        'If Trim(dr1("hmc101_id")) <> "" Then
                        Dim fyear As String = ""
                        'Dim nowyear As String = ""
                        Dim defnum As String = ""

                        defnum = "000001"

                        fyear = (dr1("hmc101_id")).Substring(1, 3)


                        'Response.Write(fyear)
                        'Response.End()

                        If fyear < nowyear Then

                            hmd201_id = "F" & nowyear & "-" & defnum

                            dr("hmd201_id") = hmd201_id

                        ElseIf fyear = nowyear Then

                            defnum1 = (dr1("hmc101_id")).Substring(5, 6)
                            'Int32.Parse(defnum1)
                            defnum1 += 1
                            hmd201_id = "F" & nowyear & "-" & defnum1.ToString("000000")

                            dr("hmd201_id") = hmd201_id

                        End If

                        'Response.Write(hmd201_id)
                        'Response.End()
                        'Response.Write(dr1("hmc101_id"))
                        '如果為空的處理
                        'Else
                        'Response.Write("0")
                    End If
                    dr1.Dispose()
                    dr1.Close()

                    dr("hmd201_bookid") = Trim(tmparry(0))
                    dr("hmd201_SSN") = Trim(tmparry(1))
                    dr("hmd201_cname") = Trim(tmparry(2))
                    dr("hmd201_ename") = Trim(tmparry(3))

                    '性別代碼轉換
                    If Trim(tmparry(4)) = "男" Then
                        dr("hmd201_gent") = "M"
                    ElseIf Trim(tmparry(4)) = "女" Then
                        dr("hmd201_gent") = "F"
                    Else
                        dr("hmd201_gent") = ""
                    End If

                    dr("hmd201_bday") = Trim(tmparry(5))

                    '學歷代碼轉換
                    If Trim(tmparry(6)) = "博士" Then
                        dr("hmd201_eduid") = 1
                    ElseIf Trim(tmparry(6)) = "碩士" Then
                        dr("hmd201_eduid") = 2
                    ElseIf Trim(tmparry(6)) = "大學" Then
                        dr("hmd201_eduid") = 3
                    ElseIf Trim(tmparry(6)) = "專科" Then
                        dr("hmd201_eduid") = 4
                    ElseIf Trim(tmparry(6)) = "高中" Then
                        dr("hmd201_eduid") = 5
                    ElseIf Trim(tmparry(6)) = "職校" Then
                        dr("hmd201_eduid") = 6
                    ElseIf Trim(tmparry(6)) = "國中" Then
                        dr("hmd201_eduid") = 7
                    ElseIf Trim(tmparry(6)) = "國小" Then
                        dr("hmd201_eduid") = 8
                    ElseIf Trim(tmparry(6)) = "其他" Then
                        dr("hmd201_eduid") = 9
                    Else
                        dr("hmd201_eduid") = ""
                    End If

                    dr("hmd201_email") = Trim(tmparry(7))
                    dr("hmd201_addid") = Trim(tmparry(8))
                    dr("hmd201_addot") = Trim(tmparry(9))
                    dr("hmd201_phnoa") = Trim(tmparry(10))
                    dr("hmd201_phnom") = Trim(tmparry(11))
                    dr("hmd201_aid") = "user"
                    dr("hmd201_adt") = Now()
                    dr("hmd201_uid") = "user"
                    dr("hmd201_udt") = Now()
                    'Response.Write(Trim(tmparry(0)))
                    'Response.Write(Trim(tmparry(11)))
                    'Response.End()
                    dt.Rows.Add(dr)
                    Dim smdbuilder As New SqlCommandBuilder(sd)
                    sd.Update(dset)
                End If


            End If

        Next

        conn.Close()
        conn.Dispose()

        conn1.Close()
        conn1.Dispose()

        conn2.Close()
        conn2.Dispose()
        '{alert("匯入完成");return true;}
        Me.Page.Controls.Add(New LiteralControl("<script>self.opener.location.reload();alert('匯入完成');window.close();</script>"))


    End Sub

    Public Function readfile(ByVal tmppath As String) As String
        Dim file1 As Stream = File.Open(tmppath, FileMode.Open)
        Dim encode As System.Text.Encoding = System.Text.Encoding.GetEncoding("big5")
        Dim sr As StreamReader = New StreamReader(file1, encode)
        Dim allstr As String = sr.ReadToEnd
        readfile = allstr
        sr.Close()
        file1.Close()
        sr = Nothing
        file1 = Nothing
        encode = Nothing

    End Function

    Protected Sub btnsent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsent.Click
        Call adddofunction()
    End Sub
End Class