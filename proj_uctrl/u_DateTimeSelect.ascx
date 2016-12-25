<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_DateTimeSelect.ascx.cs" Inherits="proj_uctrl_u_DateTimeSelect" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div style="position: relative; text-align: left">
	<asp:TextBox ID="YMD" runat="server" BackColor="White" CssClass="G" Style="z-index: 101; left: 0px; position: absolute; top: 0px" Width="72px"></asp:TextBox>
	<asp:DropDownList ID="hh" runat="server" CssClass="G" Style="z-index: 102; left: 78px; position: absolute; top: 0px" Width="40px"></asp:DropDownList>
	<div class="G" style="display: inline; z-index: 103; left: 118px; letter-spacing: 13px; position: absolute; top: 4px; text-align: center">：</div>
	<asp:DropDownList ID="mm" runat="server" CssClass="G" Style="z-index: 104; left: 134px; position: absolute; top: 0px" Width="40px"></asp:DropDownList>
	<input id="bt_Select" runat="server" class="G" name="bt_Select" src="../proj_img/Calendar.gif" style="z-index: 105; left: 174px; position: absolute; top: 0px; width: 17px; height: 17px; border: 2px outset; background-color: silver" tabindex="-1" type="image" />
	<ajaxToolkit:MaskedEditExtender ID="MEditExt" runat="server" ClearMaskOnLostFocus="False" Mask="9999/99/99" TargetControlID="YMD" UserDateFormat="YearMonthDay" />
</div>
