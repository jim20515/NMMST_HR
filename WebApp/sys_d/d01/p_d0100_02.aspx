<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0100_02.aspx.cs" Inherits="sys_d_d01_p_d0100_02" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>����</title>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="285px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmd100a_posid_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">¾��N�X�G</asp:Label>
							<asp:Label ID="dwF_hmd100a_posid" runat="server" CssClass="G"  Style="z-index:100; left:104px; position: absolute; top:6px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmd100a_posname_t" runat="server" CssClass="N" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">¾��W�١G</asp:Label>
							<asp:TextBox ID="dwF_hmd100a_posname" runat="server" CssClass="G"  Style="z-index:105; left:104px; position: absolute; top:30px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmd100a_belon_t" runat="server" CssClass="I" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">�s��ӷ��G</asp:Label>
							<asp:RadioButtonList ID="dwF_hmd100a_belon" runat="server" RepeatDirection="Horizontal" Style="left:104px; position: relative; top:56px">
							    <asp:ListItem Selected="True" Value="E">���u</asp:ListItem>
							    <asp:ListItem Value="V">�Ӥu</asp:ListItem>
							</asp:RadioButtonList>
							<asp:Label ID="dwF_hmd100a_poslv_t" runat="server" CssClass="N" Style="z-index:114; left:4px; position: absolute; top:86px" Width="100px">¾���m�G</asp:Label>
							<asp:DropDownList ID="dwF_hmd100a_poslv" runat="server" Style="z-index:115; left:104px; position: absolute; top:82px" Width="105px" DataMember="hmd101"></asp:DropDownList>
							<asp:Label ID="dwF_hmd100a_posno_t" runat="server" CssClass="N" Style="z-index:119; left:4px; position: absolute; top:112px" Width="100px">¾��H�ơG</asp:Label>
							<asp:TextBox ID="dwF_hmd100a_posno" runat="server" CssClass="G"  Style="z-index:120; left:104px; position: absolute; top:108px" Width="200px"></asp:TextBox>
							<asp:CheckBox ID="dwF_hmd100a_stop" runat="server" Style="z-index:125; left:104px; position: absolute; top: 138px" Text="����" />
							<asp:Label ID="dwF_hmd100a_aid_t" runat="server" CssClass="D" Style="z-index:129; left:4px; position: absolute; top:164px" Width="100px">�s�W�H���G</asp:Label>
							<asp:Label ID="dwF_hmd100a_aid" runat="server" CssClass="G" Style="z-index: 130; left:104px; position: absolute; top: 163px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmd100a_adt_t" runat="server" CssClass="D" Style="z-index:134; left:4px; position: absolute; top:190px" Width="100px">�s�W�ɶ��G</asp:Label>
							<asp:Label ID="dwF_hmd100a_adt" runat="server" CssClass="G" Style="z-index: 135; left:104px; position: absolute; top: 189px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmd100a_uid_t" runat="server" CssClass="D" Style="z-index:139; left:4px; position: absolute; top:216px" Width="100px">���ʤH���G</asp:Label>
							<asp:Label ID="dwF_hmd100a_uid" runat="server" CssClass="G" Style="z-index: 140; left:104px; position: absolute; top: 215px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmd100a_udt_t" runat="server" CssClass="D" Style="z-index:144; left:4px; position: absolute; top:242px" Width="100px">���ʮɶ��G</asp:Label>
							<asp:Label ID="dwF_hmd100a_udt" runat="server" CssClass="G" Style="z-index: 145; left:104px; position: absolute; top: 241px" Width="150px"></asp:Label>

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
