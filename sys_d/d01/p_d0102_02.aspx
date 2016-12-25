<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0102_02.aspx.cs" Inherits="sys_d_d01_p_d0102_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>明細</title>
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
								<td style="height: 260px">
									<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="264px" Style="position: relative; left: -6px; top: 1px;" Width="820px">
										<asp:Label ID="dwF_hmd102_year_t" runat="server" CssClass="N" Style="z-index: 99; left: 4px; position: absolute; top: 8px" Width="100px">年度：</asp:Label>
										<asp:DropDownList ID="dwF_hmd102_year" runat="server" CssClass="G" DataMember="YY_dc" Style="z-index: 100; left: 104px; position: absolute; top: 6px" Width="200px" DataTextFormatString="000"></asp:DropDownList>
										<asp:Label ID="dwF_hmd102_season_t" runat="server" CssClass="N" Style="z-index: 104; left: 4px; position: absolute; top: 34px" Width="100px">季：</asp:Label>
										<asp:DropDownList ID="dwF_hmd102_season" runat="server" CssClass="G" Style="z-index: 105; left: 104px; position: absolute; top: 30px" Width="200px">
											<asp:ListItem Value="0">-</asp:ListItem>
											<asp:ListItem Value="1">第一季</asp:ListItem>
											<asp:ListItem Value="2">第二季</asp:ListItem>
											<asp:ListItem Value="3">第三季</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwF_hmd102_tid_t" runat="server" CssClass="N" Style="z-index: 109; left: 4px; position: absolute; top: 60px" Width="100px">志工隊：</asp:Label>
										<asp:DropDownList ID="dwF_hmd102_tid" runat="server" DataMember="hmd101" Style="left: 104px; position: relative; top: 56px">
										</asp:DropDownList>
										<asp:Label ID="dwF_hmd102_ktype_t" runat="server" CssClass="N" Style="z-index: 109; left: 4px; position: absolute; top: 86px" Width="100px">考核類別：</asp:Label>
										<asp:DropDownList ID="dwF_hmd102_ktype" runat="server" CssClass="G" Style="z-index: 105; left: 104px; position: absolute; top: 83px" Width="200px">
											<asp:ListItem Value="1">實習志工考核</asp:ListItem>
											<asp:ListItem Value="2">正式志工季考核</asp:ListItem>
											<asp:ListItem Value="3">正式志工年考核</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwF_hmd102_epass_t" runat="server" CssClass="N" Style="z-index: 114; left: 4px; position: absolute; top: 113px" Width="100px">服勤合格時數：</asp:Label>
										<asp:TextBox ID="dwF_hmd102_epass" runat="server" CssClass="G" Style="z-index: 115; left: 104px; position: absolute; top: 109px" Width="60px"></asp:TextBox>
										<asp:Label ID="dwF_hmd102_fpass_t" runat="server" CssClass="N" Style="z-index: 119; left: 4px; position: absolute; top: 139px" Width="100px">訓練合格時數：</asp:Label>
										<asp:TextBox ID="dwF_hmd102_fpass" runat="server" CssClass="G" Style="z-index: 120; left: 104px; position: absolute; top: 135px" Width="60px"></asp:TextBox>
										<asp:Label ID="dwF_hmd102_aid_t" runat="server" CssClass="D" Style="z-index: 129; left: 4px; position: absolute; top: 165px" Width="100px">新增人員：</asp:Label>
										<asp:Label ID="dwF_hmd102_aid" runat="server" CssClass="G" Style="z-index: 130; left: 104px; position: absolute; top: 164px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd102_adt_t" runat="server" CssClass="D" Style="z-index: 134; left: 4px; position: absolute; top: 191px" Width="100px">新增時間：</asp:Label>
										<asp:Label ID="dwF_hmd102_adt" runat="server" CssClass="G" Style="z-index: 135; left: 104px; position: absolute; top: 190px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd102_uid_t" runat="server" CssClass="D" Style="z-index: 139; left: 4px; position: absolute; top: 217px" Width="100px">異動人員：</asp:Label>
										<asp:Label ID="dwF_hmd102_uid" runat="server" CssClass="G" Style="z-index: 140; left: 104px; position: absolute; top: 216px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hmd102_udt_t" runat="server" CssClass="D" Style="z-index: 144; left: 4px; position: absolute; top: 243px" Width="100px">異動時間：</asp:Label>
										<asp:Label ID="dwF_hmd102_udt" runat="server" CssClass="G" Style="z-index: 145; left: 104px; position: absolute; top: 242px" Width="150px"></asp:Label>
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
										<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
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
