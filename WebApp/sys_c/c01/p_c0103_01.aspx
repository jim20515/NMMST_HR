<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0103_01.aspx.cs" Inherits="sys_c_c01_p_c0103_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>匯入作業</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>

<script language="JavaScript" type="text/javascript">

function uf_Upload()
{
	// Check Input
	var ls_data = "";
	ls_data = document.getElementById("dwU_filepath").value.Trim();
	if (ls_data == "")
	{
		alert("請先選擇匯入檔案！");
		return false;
	}
	if (ls_data.substr(ls_data.length - 4).toLowerCase() != ".xls")
	{
		alert("匯入檔案類型需為 Excel 97-2003 活頁簿 (*.xls)！");
		return false;
	}

	return true;
}

</script>

<body>
    <%--    <form method="post"  id="form1" enctype="multipart/form-data" runat="server">
--%>
    <form id="form1" method="post" runat="server" enctype="multipart/form-data">
        <%--        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
--%>
        <div>
            <asp:Panel ID="pn_Contain" runat="server">
                <table class="G">
                    <tr>
                        <td>
                            <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="260px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
                                <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101; left: 16px; position: absolute; top: 18px" ForeColor="Blue">步驟一：請下載人力資源基本資料批次匯入格式 Excel 檔案範本。 </asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="G" ForeColor="Blue" Style="z-index: 101; left: 16px; position: absolute; top: 104px" Width="634px">步驟二：依照 Excel 檔案的工作表「匯入資料格式說明」將資料輸入到工作表「人力資源批次匯入資料」中，<br />　　　　輸入完成後請儲存。（其中必要輸入欄位請確實輸入） </asp:Label>
                                <asp:Label ID="Label2" runat="server" CssClass="G" ForeColor="Blue" Style="z-index: 101; left: 16px; position: absolute; top: 177px" Width="634px">步驟三：《瀏覽》步驟二儲存之 Excel 檔案並按下《匯入》。 <br />　　　　（系統會將 Excel 檔案中所列之基本資料儲存至資料庫《人力資源基本資料》中） </asp:Label>
                                <asp:Label ID="dwF_show1" runat="server" ForeColor="#804000" Style="z-index: 101; left: 115px; position: absolute; top: 48px" Width="80px">(version 1.0) </asp:Label>
                                <asp:Label ID="Label3" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 224px" Width="80px">匯入檔案：</asp:Label>
                                <asp:Button ID="bt_Download" runat="server" CssClass="Bt_Download" OnClick="bt_Download_Click" Width="80px" Style="z-index: 101; left: 20px; position: absolute; top: 41px" />
                                <hr class="G" style="z-index: 101; left: 0px; position: absolute; top: 83px" />
                                <hr class="G" style="z-index: 101; left: 0px; position: absolute; top: 155px" />
                                <asp:Button ID="Bt_Import" Style="z-index: 100; left: 642px; position: absolute; top: 217px" runat="server" Width="80px" CssClass="Bt_Import" OnClick="Bt_Import_Click"></asp:Button>
                                <asp:FileUpload ID="dwU_filepath" runat="server" BackColor="#ffffdd" CssClass="G" Width="360" Style="z-index: 102; left: 96px; width: 524px; position: absolute; top: 221px; height: 22px" />
                                &nbsp;
                            </witc:DWPanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:GridView ID="dgG" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#5D7B9D" BorderStyle="Double" BorderWidth="1px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <%--                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <uc1:u_ProgressShow ID="u_Progress" runat="server" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
--%>
    </form>
</body>
</html>
