<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_SuperBar.aspx.cs" Inherits="proj_right_p_SuperBar" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>進階管理者功能選單</title>
	<link href="../proj_css/s_Frame.css" rel="stylesheet" type="text/css" />
	<link href="../proj_css/s_MenuBar.css" rel="stylesheet" type="text/css" />
</head>
<body class="Frame_Top">
    <form id="form1" runat="server">
    <div class="Frame_Top">
		<asp:Literal ID="litr_MenuBar" runat="server" EnableViewState="False"></asp:Literal>
	</div>
    </form>
</body>
</html>
