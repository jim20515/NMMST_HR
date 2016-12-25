<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_a0205_02.aspx.cs" Inherits="sys_a_a02_p_a0205_02" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明細</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server" />
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div>
		<asp:Panel ID="pn_Contain" runat="server">
			<table class="G">
				<tr>
					<td>
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="233px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hca205_id_t" runat="server" CssClass="N" Style="z-index: 99; left: 4px; position: absolute; top: 6px" Width="100px">郵遞區號：</asp:Label>
							<asp:TextBox ID="dwF_hca205_id" runat="server" CssClass="G" Style="z-index: 100; left: 105px; position: absolute; top: 2px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hca205_hca212id_t" runat="server" CssClass="N" Style="z-index: 99; left: 4px; position: absolute; top: 33px" Width="100px">縣市：</asp:Label>
							<asp:DropDownList ID="dwF_hca205_hca212id" runat="server" CssClass="G" DataMember="hca212" Style="z-index: 100; left: 104px; position: absolute; top: 29px">
							</asp:DropDownList>
							<asp:Label ID="dwF_hca205_name_t" runat="server" CssClass="I" Style="z-index:104; left:4px; position: absolute; top:59px" Width="100px">名稱：</asp:Label>
							<asp:TextBox ID="dwF_hca205_name" runat="server" CssClass="G"  Style="z-index:105; left:104px; position: absolute; top:55px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hca205_sort_t" runat="server" CssClass="I" Style="z-index:109; left:4px; position: absolute; top:85px" Width="100px">排序：</asp:Label>
							<asp:TextBox ID="dwF_hca205_sort" runat="server" CssClass="G"  Style="z-index:110; left:104px; position: absolute; top:81px" Width="200px"></asp:TextBox>
							<asp:CheckBox ID="dwF_hca205_stop" runat="server" Style="z-index:115; left:104px; position: absolute; top: 111px" Text="停用" />
							<asp:Label ID="dwF_hca205_aid_t" runat="server" CssClass="D" Style="z-index:119; left:4px; position: absolute; top:137px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hca205_aid" runat="server" CssClass="G" Style="z-index: 120; left:104px; position: absolute; top: 133px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hca205_adt_t" runat="server" CssClass="D" Style="z-index:124; left:4px; position: absolute; top:163px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hca205_adt" runat="server" CssClass="G" Style="z-index: 125; left:104px; position: absolute; top: 159px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hca205_uid_t" runat="server" CssClass="D" Style="z-index:129; left:4px; position: absolute; top:189px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hca205_uid" runat="server" CssClass="G" Style="z-index: 130; left:104px; position: absolute; top: 185px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hca205_udt_t" runat="server" CssClass="D" Style="z-index:134; left:4px; position: absolute; top:215px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hca205_udt" runat="server" CssClass="G" Style="z-index: 135; left:104px; position: absolute; top: 211px" Width="150px"></asp:Label>

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
