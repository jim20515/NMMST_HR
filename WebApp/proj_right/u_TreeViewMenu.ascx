<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_TreeViewMenu.ascx.cs" Inherits="proj_right_u_TreeViewMenu" %>
<asp:TreeView ID="tv_Menu" Target="menuleadFrame" runat="server" ExpandDepth="1" Width="200px" CssClass="tree_menu">
	<HoverNodeStyle BackColor="#46366b" ForeColor="#ffff33" />
	<SelectedNodeStyle BackColor="#46366b" ForeColor="#ffff33" />
	<NodeStyle Font-Size="13px" ForeColor="#46366b" />
</asp:TreeView>
