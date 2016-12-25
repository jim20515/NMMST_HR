<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_Symbol.ascx.cs" Inherits="proj_right_u_Symbol" %>
<asp:Literal ID="litr_Img" runat="server" EnableViewState="False"></asp:Literal>
<div id="Symbol_Out" class="Symbol_Out" onmouseout="uf_SetSymbolVisible(false);" onmouseover="uf_SetSymbolVisible(true);" style="display: none">
	<asp:Literal ID="litr_Symbol" runat="server" EnableViewState="False"></asp:Literal>
</div>
