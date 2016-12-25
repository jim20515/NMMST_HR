<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0201_01.aspx.cs" Inherits="sys_h_h02_p_h0201_01" %>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="500px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmh201a_cid_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">賀卡寄件代碼：</asp:Label>
							<asp:Label ID="dwF_hmh201a_cid" runat="server" CssClass="G" Style="z-index: 100; left:104px; position: absolute; top: 8px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmh201a_picurl_t" runat="server" CssClass="N" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">賀卡底圖：</asp:Label>
                            &nbsp;
							<asp:Label ID="dwF_hmh201a_stitle_t" runat="server" CssClass="N" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">賀卡標題：</asp:Label>
							<asp:TextBox ID="dwF_hmh201a_stitle" runat="server" CssClass="G"  Style="z-index:110; left:104px; position: absolute; top:57px" Width="328px"></asp:TextBox>
                            <asp:TextBox ID="dwF_hmh201a_picurl" runat="server" CssClass="G" Style="z-index: 110; left: 104px; position: absolute; top: 31px" Width="328px" ReadOnly="True"></asp:TextBox>
							<asp:Label ID="dwF_hmh201a_scontent_t" runat="server" CssClass="N" Style="z-index:114; left:0px; position: absolute; top:88px" Width="100px">賀卡內容：</asp:Label>
							<asp:TextBox ID="dwF_hmh201a_scontent" runat="server" CssClass="G"  Style="z-index:115; left:104px; position: absolute; top: 88px" Height="120px" Width="592px" TextMode="MultiLine"></asp:TextBox>
							<asp:Label ID="dwF_hmh201a_aid_t" runat="server" CssClass="D" Style="z-index:119; left:8px; position: absolute; top:389px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hmh201a_aid" runat="server" CssClass="G" Style="z-index: 120; left:112px; position: absolute; top: 389px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmh201a_adt_t" runat="server" CssClass="D" Style="z-index:124; left:409px; position: absolute; top:389px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hmh201a_adt" runat="server" CssClass="G" Style="z-index: 125; left:513px; position: absolute; top: 389px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmh201a_uid_t" runat="server" CssClass="D" Style="z-index:129; left:8px; position: absolute; top:417px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hmh201a_uid" runat="server" CssClass="G" Style="z-index: 130; left:112px; position: absolute; top: 417px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmh201a_udt_t" runat="server" CssClass="D" Style="z-index:134; left:409px; position: absolute; top:417px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hmh201a_udt" runat="server" CssClass="G" Style="z-index: 135; left:513px; position: absolute; top: 417px" Width="150px"></asp:Label>
                            <asp:Label ID="dwF_hmh201a_mlist_t" runat="server" CssClass="N" Style="z-index: 114; left: 0px;
                                position: absolute; top: 232px" Width="100px">郵寄名單：</asp:Label>
                            <asp:TextBox ID="dwF_hmh201a_mlist" runat="server" CssClass="G" Height="136px" Style="z-index: 115;
                                left: 104px; position: absolute; top: 232px" TextMode="MultiLine" Width="592px"></asp:TextBox>
                            <asp:Button ID="bt_list" runat="server" CssClass="Bt_EditNList" OnClick="bt_list_Click"
                                Style="z-index: 114; left: 720px; position: absolute; top: 232px" Width="83px" /><asp:Button ID="bt_choose" runat="server" CssClass="Bt_Browser" OnClick="bt_choose_Click"
                                Style="z-index: 114; left: 450px; position: absolute; top: 27px" Width="83px" />
                            <asp:Button ID="bt_Conf" runat="server" CssClass="Bt_Conf" OnClick="bt_Conf_Click" Style="z-index: 114; left: 321px; position: absolute; top: 454px" Width="83px" />
                            <asp:HiddenField ID="dwF_hmh201a_picurl_hf" runat="server" />
						</witc:DWPanel>
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
