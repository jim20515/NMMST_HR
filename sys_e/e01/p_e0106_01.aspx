<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0106_01.aspx.cs" Inherits="sys_e_e01_p_e0106_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>報表列印</title>
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div>
					<asp:Panel ID="pn_Contain" runat="server">
						<table class="G">
							<tr>
								<td>
									<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="70px" Style="position: relative" Width="820px">
										<asp:Panel ID="dwQ_hle201_sdatetime_e" runat="server" CssClass="G" Style="z-index: 104; left: 249px; position: absolute; top: 6px" Width="132px">
											<uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
										</asp:Panel>
										<asp:Label ID="dwQ_hle201_tid_t" runat="server" CssClass="N" Style="z-index: 99; left: 4px; position: absolute; top: 33px" Width="100px">志工隊：</asp:Label>
										<asp:DropDownList ID="dwQ_hle201_tid" runat="server" CssClass="G" DataMember="hmd101" Style="left: 106px; position: absolute; top: 30px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hle201_sdatetime_s_t" runat="server" CssClass="N" Style="z-index: 104; left: 4px; position: absolute; top: 10px" Width="100px">刷卡日期：</asp:Label>
										<asp:Panel ID="dwQ_hle201_sdatetime_s" runat="server" CssClass="G" Style="z-index: 104; left: 104px; position: absolute; top: 6px" Width="132px">
											<uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
										</asp:Panel>
										<asp:Label ID="dwQ_hle201_sdatetime_e_t" runat="server" CssClass="N" Style="z-index: 104; left: 214px; position: absolute; top: 10px" Width="18px">～</asp:Label>
										<asp:Button ID="bt_Print" runat="server" CssClass="Bt_Print" OnClick="bt_Print_Click" Style="z-index: 999; left: 728px; position: absolute; top: 36px" Text="" Width="80px" />
									</witc:DWPanel>
								</td>
							</tr>
							<tr>
								<td style="height: 4px">
								</td>
							</tr>
						</table>
					</asp:Panel>
				</div>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
					<ProgressTemplate>
						<uc1:u_ProgressShow ID="u_Progress" runat="server" />
					</ProgressTemplate>
				</asp:UpdateProgress>
			</ContentTemplate>
		</asp:UpdatePanel>
	</form>
</body>
</html>
