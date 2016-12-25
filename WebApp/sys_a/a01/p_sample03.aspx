<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_sample03.aspx.cs" Inherits="sys_a_p_sample03" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>頁面到訪次數分析測試項目</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pn_Contain" runat="server">
                <table class="G">
                    <tr>
                        <td>
                            <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="50px" Style="position: relative;
                                left: 0px; top: 0px;" Width="800px">
                                <asp:Label ID="dwQ_s07_spdate_t" runat="server" CssClass="Q" Style="z-index: 105;
                                    left: 4px; position: absolute; top: 17px" Width="40px">從</asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="Q" Style="z-index: 105; left: 317px;
                                    position: absolute; top: 17px" Width="40px">種類：</asp:Label>
                                <asp:Label ID="Label2" runat="server" CssClass="Q" Style="z-index: 105; left: 492px;
                                    position: absolute; top: 18px" Width="40px">排序：</asp:Label>
                                <asp:Panel ID="dwQ_s07_spdate" runat="server" CssClass="G" Style="z-index: 106; left: 49px;
                                    position: absolute; top: 15px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
                                </asp:Panel>
                                <div class="G" style="display: inline; left: 157px; position: absolute; top: 17px;
                                    z-index: 105;">
                                    至</div>
                                <asp:Panel ID="dwQ_s07_epdate" runat="server" CssClass="G" Style="z-index: 109; left: 179px;
                                    position: absolute; top: 14px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date4" runat="server" />
                                </asp:Panel>
                                <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 673px;
                                    position: absolute; top: 14px" Text="查詢" Width="56px" OnClick="bt_Query_Click" />
                                <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 105;
                                    left: 357px; position: absolute; top: 14px" Width="109px" >
                                    <asp:ListItem Value="1">《全部》</asp:ListItem>
                                    <asp:ListItem Value="0">TOP 10</asp:ListItem>
                                </asp:DropDownList><asp:DropDownList ID="DropDownList2" runat="server" Style="z-index: 105;
                                    left: 532px; position: absolute; top: 14px" Width="109px" >
                                    <asp:ListItem Value="1">到訪次數</asp:ListItem>
                                    <asp:ListItem Value="0">頻道號碼</asp:ListItem>
                                </asp:DropDownList>
                            </witc:DWPanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                ProcessingMode="Remote" AsyncRendering="False" ShowBackButton="True"
                                SizeToReportContent="true" ZoomMode="FullPage">
                                <ServerReport ReportPath="/HDHDM_Reprot/Sample03" ReportServerUrl="http://10.100.1.126/reportserver"
                                    DisplayName="用戶來源分析測試項目" Timeout="60000000" />
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
