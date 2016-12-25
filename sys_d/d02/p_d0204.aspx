<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0204.aspx.cs" Inherits="sys_d_d02_p_d0204" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title></title>
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
	<link href="../../proj_css/s_webstyle.css" rel="stylesheet" type="text/css" />
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
									<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="136px" Style="position: relative; left: 0px; top: 0px;" Width="820px">
										<asp:Label ID="dwF_hmd202_open_t" runat="server" CssClass="I" Style="z-index: 289; left: 7px; position: absolute; top: 11px" Width="100px">外網開放報名：</asp:Label>
										<asp:CheckBox ID="dwF_hmd202_open" runat="server" Style="z-index: 220; left: 112px; position: absolute; top: 7px" />
										<asp:Label ID="dwF_hmd202_aid_t" runat="server" CssClass="D" Style="z-index: 289; left: 7px; position: absolute; top: 34px" Width="100px">新增人員：</asp:Label>
										<asp:Label ID="dwF_hmd202_aid" runat="server" CssClass="G" Style="z-index: 290; left: 111px; position: absolute; top: 34px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd202_adt_t" runat="server" CssClass="D" Style="z-index: 294; left: 7px; position: absolute; top: 58px" Width="100px">新增時間：</asp:Label>
										<asp:Label ID="dwF_hmd202_adt" runat="server" CssClass="G" Style="z-index: 295; left: 111px; position: absolute; top: 58px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd202_uid_t" runat="server" CssClass="D" Style="z-index: 299; left: 7px; position: absolute; top: 82px" Width="100px">異動人員：</asp:Label>
										<asp:Label ID="dwF_hmd202_uid" runat="server" CssClass="G" Style="z-index: 300; left: 111px; position: absolute; top: 82px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd202_udt_t" runat="server" CssClass="D" Style="z-index: 304; left: 7px; position: absolute; top: 106px" Width="100px">異動時間：</asp:Label>
										<asp:Label ID="dwF_hmd202_udt" runat="server" CssClass="G" Style="z-index: 305; left: 111px; position: absolute; top: 106px" Width="150px"></asp:Label>
									</witc:DWPanel>
								</td>
							</tr>
							<tr>
								<td style="height: 4px">
								</td>
							</tr>
							<tr>
								<td>
									<div style="position: relative; float: right">
										<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server">
										</uc1:u_BtSet_iduc>
									</div>
									</td>
							</tr>
							<tr>
								<td style="height: 8px">
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
