<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_DateSelect.ascx.cs" Inherits="proj_uctrl_u_DateSelect" %>
<div style="position: relative; text-align: left">
	<asp:TextBox ID="tbx_Input" runat="server" BackColor="White" CssClass="G" OnTextChanged="tbx_Input_TextChanged" Style="z-index: 101; left: 0px; position: absolute; top: 0px" Width="72px"></asp:TextBox>
	<input id="bt_Select" runat="server" class="G" name="bt_Select" src="../proj_img/Calendar.gif" style="z-index: 102; left: 78px; position: absolute; top: 0px; width: 17px; height: 17px; border: 2px outset; background-color: silver" tabindex="-1" type="image" />
</div>
