<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_crReport.aspx.cs" Inherits="proj_uctrl_p_crReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>報表</title>
	<link href="../proj_css/s_crDefault.css" rel="stylesheet" type="text/css" />
	<script language="javascript" type="text/javascript">
		if (opener == null && top.location.toString().indexOf("frame.htm") == -1)
			top.location = "about:blank";
		else if (opener != null && opener.top.location.toString().indexOf("frame.htm") == -1)
			top.location = "about:blank";
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Panel ID="pn_Contain" runat="server">
			<asp:Label ID="lb_Msg" runat="server" EnableViewState="False" ForeColor="Olive"></asp:Label>
			<CR:CrystalReportViewer ID="crViewer" runat="server" AutoDataBind="True" Visible="False" DisplayGroupTree="False" HasToggleGroupTreeButton="False" EnableDatabaseLogonPrompt="False" EnableDrillDown="False" EnableParameterPrompt="False" Height="50px" ReuseParameterValuesOnRefresh="True" Width="350px" GroupTreeImagesFolderUrl="../proj_img/crTree/" ToolbarImagesFolderUrl="../proj_img/crToolBar/" CssFilename="../proj_css/s_crDefault.css" />
		</asp:Panel>
	</div>
    </form>
</body>
</html>
