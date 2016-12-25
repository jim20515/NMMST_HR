<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_MenuBar.aspx.cs" Inherits="proj_right_p_MenuBar" %>

<%@ Register Src="u_MenuBar.ascx" TagName="u_MenuBar" TagPrefix="uc1" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>使用者權限系統功能選單</title>
</head>
<body class="Frame_Top">
    <form id="form1" runat="server">
	<div class="Frame_Top">
		<uc1:u_MenuBar id="u_Menu" runat="server"></uc1:u_MenuBar>
	</div>
    </form>
</body>
</html>
