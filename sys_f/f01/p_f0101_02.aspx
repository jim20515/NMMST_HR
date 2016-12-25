<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0101_02.aspx.cs" Inherits="sys_f_f01_p_f0101_02" %>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="400px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmf101_courseid_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">課程代碼：</asp:Label>
							<asp:Label ID="dwF_hmf101_courseid" runat="server" CssClass="G" Style="z-index: 100; left:104px; position: absolute; top: 4px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf101_name_t" runat="server" CssClass="I" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">課程名稱：</asp:Label>
							<asp:TextBox ID="dwF_hmf101_name" runat="server" CssClass="G"  Style="z-index:105; left:104px; position: absolute; top:30px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmf101_coursetype_t" runat="server" CssClass="I" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">課程種類：</asp:Label>
							<asp:RadioButtonList ID="dwF_hmf101_coursetype" runat="server" RepeatDirection="Horizontal" Style="left:104px; position: relative; top:56px" DataMember="hca215">
							</asp:RadioButtonList>
							<asp:Label ID="dwF_hmf101_hourse_t" runat="server" CssClass="I" Style="z-index:114; left:4px; position: absolute; top:86px" Width="100px">課程時數：</asp:Label>
							<asp:TextBox ID="dwF_hmf101_hourse" runat="server" CssClass="G"  Style="z-index:115; left:104px; position: absolute; top:82px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmf101_openfor_t" runat="server" CssClass="I" Style="z-index:119; left:4px; position: absolute; top:112px" Width="100px">開放給：</asp:Label>
							<asp:DropDownList ID="dwF_hmf101_openfor" runat="server" Style="z-index:120; left:104px; position: absolute; top:108px" Width="105px" DataMember="hmd101"></asp:DropDownList>
							<asp:CheckBox ID="dwF_hmf101_force" runat="server" Style="z-index:125; left:104px; position: absolute; top: 138px" Text="強制參加" />
							<asp:Label ID="dwF_hmf101_ps_t" runat="server" CssClass="I" Style="z-index:129; left:0px; position: absolute; top:168px" Width="100px">課程簡介：</asp:Label>
							<asp:TextBox ID="dwF_hmf101_ps" runat="server" CssClass="G"  Style="z-index:130; left:104px; position: absolute; top: 168px" Height="152px" Width="544px" TextMode="MultiLine"></asp:TextBox>
							<asp:Label ID="dwF_hmf101_aid_t" runat="server" CssClass="D" Style="z-index:134; left:8px; position: absolute; top:344px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hmf101_aid" runat="server" CssClass="G" Style="z-index: 135; left:112px; position: absolute; top: 344px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf101_adt_t" runat="server" CssClass="D" Style="z-index:139; left:8px; position: absolute; top:368px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hmf101_adt" runat="server" CssClass="G" Style="z-index: 140; left:112px; position: absolute; top: 368px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf101_uid_t" runat="server" CssClass="D" Style="z-index:144; left:400px; position: absolute; top:344px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hmf101_uid" runat="server" CssClass="G" Style="z-index: 145; left:504px; position: absolute; top: 344px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf101_udt_t" runat="server" CssClass="D" Style="z-index:149; left:400px; position: absolute; top:368px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hmf101_udt" runat="server" CssClass="G" Style="z-index: 150; left:504px; position: absolute; top: 368px" Width="150px"></asp:Label>

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
