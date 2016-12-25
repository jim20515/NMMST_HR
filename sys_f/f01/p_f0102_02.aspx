<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0102_02.aspx.cs" Inherits="sys_f_f01_p_f0102_02" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>訓練班明細</title>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="368px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmf102_trainid_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">訓練代號：</asp:Label>
							<asp:Label ID="dwF_hmf102_trainid" runat="server" CssClass="G" Style="z-index: 100; left:104px; position: absolute; top: 4px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf102_courseid_t" runat="server" CssClass="N" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">課程：</asp:Label>
							<asp:DropDownList ID="dwF_hmf102_courseid" runat="server" Style="z-index:105; left:104px; position: absolute; top:30px" Width="416px" DataMember="hmf101"></asp:DropDownList>
							<asp:Label ID="dwF_hmf102_teacher_t" runat="server" CssClass="I" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">授課講師：</asp:Label>
							<asp:TextBox ID="dwF_hmf102_teacher" runat="server" CssClass="G"  Style="z-index:110; left:104px; position: absolute; top:56px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmf102_hours_t" runat="server" CssClass="N" Style="z-index:124; left:4px; position: absolute; top:89px" Width="100px">課程總時數：</asp:Label>
							<asp:TextBox ID="dwF_hmf102_hours" runat="server" Style="z-index: 125; left: 104px; position: absolute; top: 85px" Width="60px"></asp:TextBox>
							<asp:Label ID="dwF_hmf102_placeid_t" runat="server" CssClass="N" Style="z-index:129; left:4px; position: absolute; top:115px" Width="100px">開課地點：</asp:Label>
							<asp:DropDownList ID="dwF_hmf102_placeid" runat="server" Style="z-index:130; left:104px; position: absolute; top:111px" Width="105px" DataMember="hca209"></asp:DropDownList>
							<asp:Label ID="dwF_hmf102_maxno_t" runat="server" CssClass="N" Style="z-index:134; left:4px; position: absolute; top:141px" Width="100px">開課人數：</asp:Label>
							<asp:TextBox ID="dwF_hmf102_maxno" runat="server" CssClass="G"  Style="z-index:135; left:104px; position: absolute; top:137px" Width="60px"></asp:TextBox>
                            <asp:Label ID="dwF_hmf102_rstime_t" runat="server" CssClass="I" Style="z-index:139; left:4px; position: absolute; top: 167px" Width="100px">開始報名時間：</asp:Label>
							<asp:Panel ID="dwF_hmf102_rstime" runat="server" CssClass="G" Style="z-index: 140; left: 107px; position: absolute; top: 164px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
							</asp:Panel>
                            <asp:Label ID="dwF_hmf102_retime_t" runat="server" CssClass="I" Style="z-index:144; left:4px; position: absolute; top: 193px" Width="100px">停止報名時間：</asp:Label>
							<asp:Panel ID="dwF_hmf102_retime" runat="server" CssClass="G" Style="z-index:145; left:107px; position: absolute; top:191px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwF_hmf102_ps_t" runat="server" CssClass="I" Style="z-index:149; left:15px; position: absolute; top:222px" Width="88px">備註：</asp:Label>
							<asp:TextBox ID="dwF_hmf102_ps" runat="server" CssClass="G"  Style="z-index:150; left:106px; position: absolute; top: 220px" Height="88px" Width="448px" TextMode="MultiLine" ></asp:TextBox>
							<asp:Label ID="dwF_hmf102_aid_t" runat="server" CssClass="D" Style="z-index:154; left:0px; position: absolute; top:319px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hmf102_aid" runat="server" CssClass="G" Style="z-index: 155; left:96px; position: absolute; top: 319px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf102_adt_t" runat="server" CssClass="D" Style="z-index:159; left:0px; position: absolute; top:343px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hmf102_adt" runat="server" CssClass="G" Style="z-index: 160; left:96px; position: absolute; top: 343px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf102_uid_t" runat="server" CssClass="D" Style="z-index:164; left:408px; position: absolute; top:319px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hmf102_uid" runat="server" CssClass="G" Style="z-index: 165; left:512px; position: absolute; top: 319px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmf102_udt_t" runat="server" CssClass="D" Style="z-index:169; left:408px; position: absolute; top:343px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hmf102_udt" runat="server" CssClass="G" Style="z-index: 170; left:512px; position: absolute; top: 343px" Width="150px"></asp:Label>

                            <asp:Button ID="bt_NListEdit" runat="server" Style="left: 728px; position: absolute; top: 16px" Width="80px" OnClick="bt_NListEdit_Click" CssCLASS="Bt_EditNList"  />
							<asp:Label ID="dwF_hmf102_hca214id_t" runat="server" CssClass="N" Style="z-index: 134; left: 405px; position: absolute; top: 141px" Width="100px">課程領域：</asp:Label>
							<asp:DropDownList ID="dwF_hmf102_hca214id" runat="server" DataMember="hca214" Style="z-index: 130; left: 512px; position: absolute; top: 137px" Width="105px">
							</asp:DropDownList>

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
