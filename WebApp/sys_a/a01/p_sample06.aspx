<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_sample06.aspx.cs" Inherits="sys_a_p_sample01" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用戶來源分析測試項目</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pn_Contain" runat="server">
                <table class="G">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                ProcessingMode="Remote" AsyncRendering="False" SizeToReportContent="true" ZoomMode="FullPage" ShowBackButton="True"
                                >
                                <ServerReport ReportPath="/HDHDM_Reprot/TimeXUser_Month_B" ReportServerUrl="http://10.100.1.126/reportserver"
                                    DisplayName="使用者在線人數分析" Timeout="60000000" />
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
