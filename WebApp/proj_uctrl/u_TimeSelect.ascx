<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_TimeSelect.ascx.cs" Inherits="proj_uctrl_u_TimeSelect" %>
<div style="position: relative; text-align: left">
	<input id="YMD" runat="server" name="Hidden1" style="z-index: 101; left: 0px; width: 100px; position: absolute; top: 0px" type="hidden" />
	<asp:DropDownList ID="hh" runat="server" CssClass="G" Style="z-index: 102; left: 0px; position: absolute; top: 0px" Width="40px" OnSelectedIndexChanged="time_SelectedIndexChanged"></asp:DropDownList>
	<div class="G" style="display: inline; z-index: 103; left: 40px; letter-spacing: 13px; position: absolute; top: 4px; text-align: center">：</div>
	<asp:DropDownList ID="mm" runat="server" CssClass="G" Style="z-index: 104; left: 56px; position: absolute; top: 0px" Width="40px" OnSelectedIndexChanged="time_SelectedIndexChanged"></asp:DropDownList>
</div>
