<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_VistedNoByServer.aspx.cs"
    Inherits="sys_a_p_VistedNoByServer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全域訪問數量，依不同Server(IIS_Name)分類</title>
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pn_Contain" runat="server" Height="200px" Width="800px">
                <table class="G">
                    <tr>
                        <td>
                            <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="84px" Style="position: relative"
                                Width="800px">
                                <asp:Label ID="dwQ_s07_unit_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px;
                                    position: absolute; top: 12px" Width="80px">公告部門：</asp:Label>
                                <asp:DropDownList ID="dwQ_s07_unit" runat="server" CssClass="G" DataMember="para20"
                                    Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="200px">
                                </asp:DropDownList>
                                <asp:Label ID="dwQ_s07_stop_t" runat="server" CssClass="Q" Style="z-index: 103; left: 292px;
                                    position: absolute; top: 12px" Width="80px">暫停：</asp:Label>
                                <asp:RadioButtonList ID="dwQ_s07_stop" runat="server" CssClass="G" RepeatColumns="3"
                                    Style="z-index: 104; left: 376px; position: absolute; top: 8px">
                                    <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                                    <asp:ListItem Value="Y">是</asp:ListItem>
                                    <asp:ListItem Value="N">否</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="dwQ_s07_spdate_t" runat="server" CssClass="Q" Style="z-index: 105;
                                    left: 4px; position: absolute; top: 36px" Width="80px">公告日期：</asp:Label>
                                <asp:Panel ID="dwQ_s07_spdate" runat="server" CssClass="G" Style="z-index: 106; left: 88px;
                                    position: absolute; top: 32px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
                                </asp:Panel>
                                <div class="G" style="display: inline; left: 200px; position: absolute; top: 36px;
                                    z-index: 100;">
                                    ～</div>
                                <asp:Label ID="dwQ_s07_epdate_t" runat="server" CssClass="Q" Style="z-index: 108;
                                    left: 4px; position: absolute; top: 40px" Visible="False" Width="80px">公告日期：</asp:Label>
                                <asp:Panel ID="dwQ_s07_epdate" runat="server" CssClass="G" Style="z-index: 109; left: 224px;
                                    position: absolute; top: 32px" Width="132px">
                                    <uc1:u_DateSelect_ROC ID="u_Date4" runat="server" />
                                </asp:Panel>
                                <asp:Label ID="dwQ_s07_title_t" runat="server" CssClass="Q" Style="z-index: 110;
                                    left: 4px; position: absolute; top: 60px" Width="80px">公告標題：</asp:Label>
                                <asp:TextBox ID="dwQ_s07_title" runat="server" CssClass="G" Style="z-index: 111;
                                    left: 88px; position: absolute; top: 56px" Width="200px"></asp:TextBox>
                                <asp:Label ID="dwQ_s07_content_t" runat="server" CssClass="Q" Style="z-index: 112;
                                    left: 292px; position: absolute; top: 60px" Width="80px">公告內容：</asp:Label>
                                <asp:TextBox ID="dwQ_s07_content" runat="server" CssClass="G" Style="z-index: 113;
                                    left: 376px; position: absolute; top: 56px" Width="200px"></asp:TextBox>
                                <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 536px;
                                    position: absolute; top: 8px" Text="查詢" Width="56px" />
                            </witc:DWPanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 693px">
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                Height="673px" ProcessingMode="Remote" Width="800px">
                                <ServerReport ReportPath="/HDHDM_Reprot/VistedNoByServer" ReportServerUrl="http://10.100.1.27/reportserver" />
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
