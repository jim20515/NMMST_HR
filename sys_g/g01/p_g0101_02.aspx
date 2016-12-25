<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0101_02.aspx.cs" Inherits="sys_g_g01_p_g0101_02" %>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="259px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmg101a_kid_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">考核基本檔ID：</asp:Label>
							<asp:Label ID="dwF_hmg101a_kid" runat="server" CssClass="G" Style="z-index: 100; left:104px; position: absolute; top: 4px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmg101a_ktype_t" runat="server" CssClass="N" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">考核類別：</asp:Label>
							<asp:DropDownList ID="dwF_hmg101a_ktype" runat="server" Style="z-index:105; left:104px; position: absolute; top:30px" Width="153px" >							    <asp:ListItem Value="1">實習志工考核</asp:ListItem>
							    <asp:ListItem Value="2">正式志工季考核</asp:ListItem>
							    <asp:ListItem Value="3">正式志工年考核</asp:ListItem>
							</asp:DropDownList>
							<asp:Label ID="dwF_hmg101a_syear_t" runat="server" CssClass="N" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">年度：</asp:Label>
							<asp:DropDownList ID="dwF_hmg101a_syear" runat="server" Style="z-index:110; left:104px; position: absolute; top:56px" Width="105px" DataMember="YY_dc"></asp:DropDownList>
							<asp:Label ID="dwF_hmg101a_sseason_t" runat="server" CssClass="N" Style="z-index:114; left:4px; position: absolute; top:86px" Width="100px">季：</asp:Label>
							<asp:DropDownList ID="dwF_hmg101a_sseason" runat="server" Style="z-index:115; left:104px; position: absolute; top:82px" Width="153px" >							    <asp:ListItem Value="0">-</asp:ListItem>
							    <asp:ListItem Value="1">第一季</asp:ListItem>
							    <asp:ListItem Value="2">第二季</asp:ListItem>
							    <asp:ListItem Value="3">第三季</asp:ListItem>
							</asp:DropDownList>
							<asp:Label ID="dwF_hmg101a_name_t" runat="server" CssClass="N" Style="z-index:119; left:4px; position: absolute; top:112px" Width="100px">考核名稱：</asp:Label>
							<asp:TextBox ID="dwF_hmg101a_name" runat="server" CssClass="G"  Style="z-index:120; left:104px; position: absolute; top:108px" Width="359px"></asp:TextBox>
							<asp:Label ID="dwF_hmg101a_aid_t" runat="server" CssClass="D" Style="z-index:124; left:4px; position: absolute; top:138px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hmg101a_aid" runat="server" CssClass="G" Style="z-index: 125; left:104px; position: absolute; top: 134px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmg101a_adt_t" runat="server" CssClass="D" Style="z-index:129; left:4px; position: absolute; top:164px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hmg101a_adt" runat="server" CssClass="G" Style="z-index: 130; left:104px; position: absolute; top: 160px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmg101a_uid_t" runat="server" CssClass="D" Style="z-index:134; left:4px; position: absolute; top:190px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hmg101a_uid" runat="server" CssClass="G" Style="z-index: 135; left:104px; position: absolute; top: 186px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmg101a_udt_t" runat="server" CssClass="D" Style="z-index:139; left:4px; position: absolute; top:216px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hmg101a_udt" runat="server" CssClass="G" Style="z-index: 140; left:104px; position: absolute; top: 212px" Width="150px"></asp:Label>

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
