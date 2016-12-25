<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_DateSelect1.ascx.cs" Inherits="proj_uctrl_u_DateSelect1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<table cellpadding="0" cellspacing="0"><tr><td><asp:TextBox ID="tbx_Input" runat="server" BackColor="White" CssClass="G" OnTextChanged="tbx_Input_TextChanged" Width="72px"></asp:TextBox></td>
		<td><input id="bt_Select" runat="server" class="G" name="bt_Select" src="../proj_img/Calendar.gif" style="width: 17px; height: 17px; border: 2px outset; background-color: silver" tabindex="-1" type="image" /></td></tr></table>
<ajaxToolkit:MaskedEditExtender ID="MEditExt" runat="server" ClearMaskOnLostFocus="False" Mask="9999/99/99" TargetControlID="tbx_Input" UserDateFormat="YearMonthDay" />
