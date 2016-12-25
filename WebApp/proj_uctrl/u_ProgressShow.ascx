<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_ProgressShow.ascx.cs" Inherits="proj_uctrl_u_ProgressShow" %>
<asp:Panel ID="pn_Progress" runat="server" Style="z-index: 999">
	<div class="Frame_Progress">
		<table style="height: 100%; width: 100%">
			<tr>
				<td align="center" style="width: 40px" valign="middle">
					<asp:Image ID="img_Load" runat="server" ImageUrl="~/proj_img/Load.gif" />
				</td>
				<td style="width: 60%">
					<span>處理中，請稍候</span>
				</td>
				<td>
					&nbsp;
				</td>
			</tr>
		</table>
	</div>
</asp:Panel>
<ajaxToolkit:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExt" runat="server" TargetControlID="pn_Progress" VerticalSide="Middle">
</ajaxToolkit:AlwaysVisibleControlExtender>
