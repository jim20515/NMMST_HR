<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_SysFunc.aspx.cs" Inherits="proj_right_p_SysFunc" %>

<%@ Register Src="u_Symbol.ascx" TagName="u_Symbol" TagPrefix="uc1" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>使用者權限操作功能標題頁</title>
</head>
<body class="Page">
    <form id="form1" runat="server">
    <div class="Frame_Sys">
		<asp:Literal ID="litr_SysFunc" runat="server" EnableViewState="False"></asp:Literal>
		<uc1:u_Symbol id="u_Symbol" runat="server"></uc1:u_Symbol>
	</div>
    </form>
</body>
</html>
