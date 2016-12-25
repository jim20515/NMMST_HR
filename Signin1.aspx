<%@ Page AutoEventWireup="true" CodeFile="Signin1.aspx.cs" Inherits="Signin1" Language="C#" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>主機時間</title>
    <link href="proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div>
        <asp:Timer ID="Timer1" runat="server" Interval="1000">
        </asp:Timer>
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="20pt" ForeColor="#A0A0FF"></asp:Label>
    </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                </uc1:u_progressshow>
                </ProgressTemplate>
            </asp:UpdateProgress>
            </ContentTemplate> 
         </asp:UpdatePanel>
    </form>
</body>
</html>
