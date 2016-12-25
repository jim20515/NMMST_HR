<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_sample05.aspx.cs" Inherits="sys_a_p_sample05" %>

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
                                    left: 40px; position: absolute; top: 18px" Width="40px">從</asp:Label>
                                &nbsp;
                                <asp:Panel ID="dwQ_s07_spdate" runat="server" CssClass="G" Style="z-index: 106; left: 91px;
                                    position: absolute; top: 15px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
                                </asp:Panel>
                                <div class="G" style="display: inline; left: 201px; position: absolute; top: 18px;
                                    z-index: 105;">
                                    至</div>
                                <asp:Panel ID="dwQ_s07_epdate" runat="server" CssClass="G" Style="z-index: 109; left: 222px;
                                    position: absolute; top: 15px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date4" runat="server" />
                                </asp:Panel>
                                <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 404px;
                                    position: absolute; top: 15px" Text="查詢" Width="56px" OnClick="bt_Query_Click" />
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
                                <ServerReport ReportPath="/HDHDM_Reprot/Sample05_1" ReportServerUrl="http://10.100.1.126/reportserver"
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
