<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_Passwd.aspx.cs" Inherits="proj_right_p_Passwd" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>變更使用者密碼</title>
	<base target="_self" />
	<meta content="no-cache" http-equiv="Pragma" />
	<link href="../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
	<script language="JavaScript" src="../j_Frame.js" type="text/javascript"></script>
	<script language="JavaScript" src="../j_Project.js" type="text/javascript"></script>

</head>
<body style="background-color: #def1ff">
    <form id="form1" runat="server">
    <div>
		<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="108px" Style="z-index: 101; left: 8px; position: absolute; top: 8px" Width="280px">
			<asp:TextBox ID="dwF_old" runat="server" CssClass="G" Style="z-index: 101; left: 108px; position: absolute; top: 12px" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
			<asp:Label ID="dwF_old_t" runat="server" CssClass="N" Style="z-index: 102; left: 4px; position: absolute; top: 16px" Width="100px">舊的密碼：</asp:Label>
			<asp:Label ID="dwF_new_t" runat="server" CssClass="N" Style="z-index: 103; left: 4px; position: absolute; top: 48px" Width="100px">新的密碼：</asp:Label>
			<asp:TextBox ID="dwF_new" runat="server" CssClass="G" Style="z-index: 104; left: 108px; position: absolute; top: 44px" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
			<asp:Label ID="dwF_renew_t" runat="server" CssClass="N" Style="z-index: 105; left: 4px; position: absolute; top: 80px" Width="100px">確認新的密碼：</asp:Label>
			<asp:TextBox ID="dwF_renew" runat="server" CssClass="G" Style="z-index: 106; left: 108px; position: absolute; top: 76px" TextMode="Password" Width="160px" MaxLength="20"></asp:TextBox>
		</witc:DWPanel>
		<asp:Button ID="bt_Sure" runat="server" CssClass="B" Style="z-index: 102; left: 88px; position: absolute; top: 124px" Text="確定" Width="56px" OnClick="bt_Sure_Click" />
		<input class="B" onclick="window.close();" style="z-index: 103; left: 148px; width: 56px; position: absolute; top: 124px" type="button" value="離開" />
	</div>
    </form>
</body>
</html>
