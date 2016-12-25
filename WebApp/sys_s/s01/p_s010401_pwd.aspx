<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s010401_pwd.aspx.cs" Inherits="sys_s_s01_p_s010401_pwd" %>

<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>變更使用者密碼</title>
	<base target="_self" />
	<meta content="no-cache" http-equiv="Pragma" />
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
	<script language="JavaScript" src="../../j_Frame.js" type="text/javascript"></script>
	<script language="JavaScript" src="../../j_Project.js" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server" />
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div>
		<asp:Panel ID="pn_Contain" runat="server">
			<table class="G" style="margin: 5px">
				<tr>
					<td>
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="100px" Style="position: relative" Width="280px">
							<asp:Label ID="dwF_new_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 28px" Width="100px">新的密碼：</asp:Label>
							<asp:TextBox ID="dwF_new" runat="server" CssClass="G" Style="z-index: 102; left: 108px; position: absolute; top: 24px" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
							<asp:Label ID="dwF_renew_t" runat="server" CssClass="N" Style="z-index: 103; left: 4px; position: absolute; top: 60px" Width="100px">確認新的密碼：</asp:Label>
							<asp:TextBox ID="dwF_renew" runat="server" CssClass="G" Style="z-index: 104; left: 108px; position: absolute; top: 56px" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button ID="bt_Sure" runat="server" CssClass="B" Text="確定" Width="56px" OnClick="bt_Sure_Click" />
						<input class="B" onclick="window.close();" style="width: 56px" type="button" value="離開">
					</td>
				</tr>
				<tr>
					<td style="height: 8px">
					</td>
				</tr>
			</table>
		</asp:Panel>
	</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</form>
</body>
</html>
