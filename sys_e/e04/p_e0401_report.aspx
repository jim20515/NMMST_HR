<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0401_report.aspx.cs" Inherits="sys_e_e04_p_e0401_report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>刷卡條碼印製</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" AsyncRendering="False" SizeToReportContent="true" ZoomMode="FullPage" ShowBackButton="True" Width="100%" DocumentMapWidth="100%" Height="768px">
                <ServerReport ReportPath="/NMMST_HR_Report/rs_e0401" ReportServerUrl="http://localhost/reportserver" DisplayName="誤餐費時數表" Timeout="60000000" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
