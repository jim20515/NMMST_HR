<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0101_02.aspx.cs" Inherits="sys_c_c01_p_c0101_02" %>
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
					<td style="width: 799px">
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="870px" Style="position: relative" Width="820px" HeaderWrap="True" HorizontalAlign="Left">
							<asp:Label ID="dwF_hmc101_id_t" runat="server" CssClass="I" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">成員代碼：</asp:Label>
							<asp:Label ID="dwF_hmc101_id" runat="server" CssClass="G"  Style="z-index:100; left:104px; position: absolute; top:8px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmc101_cname_t" runat="server" CssClass="N" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">成員姓名：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_cname" runat="server" CssClass="G"  Style="z-index:105; left:104px; position: absolute; top:30px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_gent_t" runat="server" CssClass="I" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">性別：</asp:Label>
							<asp:RadioButtonList ID="dwF_hmc101_gent" runat="server" RepeatDirection="Horizontal" Style="left:104px; position: relative; top:56px">
							    <asp:ListItem Selected="True" Value="M">男</asp:ListItem>
							    <asp:ListItem Value="F">女</asp:ListItem>
							</asp:RadioButtonList>
                            <asp:Label ID="dwF_hmc101_bday_t" runat="server" CssClass="I" Style="z-index:114; left:4px; position: absolute; top: 86px" Width="100px">生日：</asp:Label>
							<asp:Panel ID="dwF_hmc101_bday" runat="server" CssClass="G" Style="z-index:115; left:104px; position: absolute; top:82px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date0" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwF_hmc101_SSN_t" runat="server" CssClass="I" Style="z-index:119; left:4px; position: absolute; top:112px" Width="100px">身份證字號：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_SSN" runat="server" CssClass="G" onblur="uf_Check_Id(this)" Style="z-index: 120; left: 104px; position: absolute; top: 108px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_deptid_t" runat="server" CssClass="I" Style="z-index:124; left:4px; position: absolute; top:138px" Width="100px">本館部門：</asp:Label>
							<asp:DropDownList ID="dwF_hmc101_deptid" runat="server" Style="z-index:125; left:104px; position: absolute; top:134px" Width="105px" DataMember="hca202"></asp:DropDownList>
							<asp:Label ID="dwF_hmc101_eduid_t" runat="server" CssClass="I" Style="z-index:129; left:4px; position: absolute; top:164px" Width="100px">學歷：</asp:Label>
							<asp:DropDownList ID="dwF_hmc101_eduid" runat="server" Style="z-index:130; left:104px; position: absolute; top:160px" Width="105px" DataMember="hca203"></asp:DropDownList>
							<asp:Label ID="dwF_hmc101_jobid_t" runat="server" CssClass="I" Style="z-index:134; left:4px; position: absolute; top:190px" Width="100px">職業：</asp:Label>
							<asp:DropDownList ID="dwF_hmc101_jobid" runat="server" Style="z-index:135; left:104px; position: absolute; top:186px" Width="105px" DataMember="hca204"></asp:DropDownList>
							<asp:Label ID="dwF_hmc101_joborg_t" runat="server" CssClass="I" Style="z-index:139; left:4px; position: absolute; top:216px" Width="100px">服務機關：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_joborg" runat="server" CssClass="G"  Style="z-index:140; left:104px; position: absolute; top:212px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_jobdepartment_t" runat="server" CssClass="I" Style="z-index: 139; left: 334px; position: absolute; top: 216px" Width="100px">服務單位：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_jobdepartment" runat="server" CssClass="G" Style="z-index: 140; left: 434px; position: absolute; top: 212px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_jobtitle_t" runat="server" CssClass="I" Style="z-index:144; left:4px; position: absolute; top:242px" Width="100px">職位：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_jobtitle" runat="server" CssClass="G"  Style="z-index:145; left:104px; position: absolute; top:238px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_addid_t" runat="server" CssClass="I" Style="z-index:149; left:4px; position: absolute; top:268px" Width="100px">郵遞區號：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_addid" runat="server" AutoPostBack="true" CssClass="I" OnTextChanged="dwF_hmc101_addid_OnTextChanged" Style="z-index: 149; left: 105px; position: absolute; top: 264px" Width="35px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_addid_h_t" runat="server" CssClass="I" Style="z-index: 149; left: 154px; position: absolute; top: 267px" Width="31px">縣市</asp:Label>
							<asp:DropDownList ID="dwF_hmc101_addid_h" runat="server" AutoPostBack="true" DataMember="hca212" OnSelectedIndexChanged="dwF_hmc101_addid_h_OnSelectedIndexChanged" Style="z-index: 150; left: 191px; position: absolute; top: 263px"></asp:DropDownList>
							<asp:Label ID="dwF_hmc101_addid_b_t" runat="server" CssClass="I" Style="z-index: 149; left: 304px; position: absolute; top: 265px" Width="31px">鄉鎮</asp:Label>
							<asp:DropDownList ID="dwF_hmc101_addid_b" runat="server" AutoPostBack="true" DataMember="hca205" OnSelectedIndexChanged="dwF_hmc101_addid_b_OnSelectedIndexChanged" Style="z-index: 150; left: 341px; position: absolute; top: 262px">
							</asp:DropDownList>
							<asp:Label ID="dwF_hmc101_addot_t" runat="server" CssClass="I" Style="z-index:154; left:4px; position: absolute; top:294px" Width="100px">地址：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_addot" runat="server" CssClass="G"  Style="z-index:155; left:104px; position: absolute; top:290px" Width="424px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_email_t" runat="server" CssClass="I" Style="z-index:159; left:4px; position: absolute; top:320px" Width="100px">E-Mail：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_email" runat="server" CssClass="G"  Style="z-index:160; left:104px; position: absolute; top:316px" Width="424px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_phnow_t" runat="server" CssClass="I" Style="z-index:164; left:4px; position: absolute; top:346px" Width="100px">工作電話：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_phnow" runat="server" CssClass="G"  Style="z-index:165; left:104px; position: absolute; top:342px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_phnowex_t" runat="server" CssClass="I" Style="z-index:169; left:334px; position: absolute; top:345px" Width="100px">分機：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_phnowex" runat="server" CssClass="G"  Style="z-index:170; left:434px; position: absolute; top:341px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_fax_t" runat="server" CssClass="I" Style="z-index: 164; left: 4px; position: absolute; top: 372px" Width="100px">傳真：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_fax" runat="server" CssClass="G" Style="z-index: 165; left: 104px; position: absolute; top: 368px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_phnoa_t" runat="server" CssClass="I" Style="z-index:174; left:4px; position: absolute; top:398px" Width="100px">住家電話：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_phnoa" runat="server" CssClass="G"  Style="z-index:175; left:104px; position: absolute; top:394px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_phnom_t" runat="server" CssClass="I" Style="z-index:179; left:4px; position: absolute; top:424px" Width="100px">行動電話：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_phnom" runat="server" CssClass="G"  Style="z-index:180; left:104px; position: absolute; top:420px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_memberid_t" runat="server" CssClass="D" Style="z-index:184; left:4px; position: absolute; top:450px" Width="100px">會員帳號：</asp:Label>
							<asp:Label ID="dwF_hmc101_memberid" runat="server" CssClass="D" Style="z-index: 185; left: 104px; position: absolute; top: 450px"></asp:Label>
							<asp:Label ID="dwF_hmc101_memberpwd_t" runat="server" CssClass="D" Style="z-index:189; left:4px; position: absolute; top:476px" Width="100px">會員密碼：</asp:Label>
							<asp:Label ID="dwF_hmc101_memberpwd" runat="server" CssClass="D" Style="z-index: 190; left: 104px; position: absolute; top: 475px"></asp:Label>
							<asp:CheckBox ID="dwF_hmc101_passed" runat="server" Style="z-index:195; left:328px; position: absolute; top: 472px" Text="通過認証" />
							<asp:CheckBox ID="dwF_hmc101_rejectepaper" runat="server" Style="z-index:200; left:448px; position: absolute; top: 472px" Text="拒閱電子報" />
							<asp:Label ID="dwF_hmc101_ps_t" runat="server" CssClass="I" Style="z-index:204; left:8px; position: absolute; top:504px" Width="96px" Height="1px">備註：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_ps" runat="server" CssClass="G"  Style="z-index:205; left:104px; position: absolute; top: 504px" Height="72px" Width="672px" TextMode="MultiLine"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_notel_t" runat="server" CssClass="I" Style="z-index:209; left:0px; position: absolute; top:592px" Width="100px" Height="1px">重要原因：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_notel" runat="server" CssClass="G"  Style="z-index:210; left:104px; position: absolute; top: 584px" Height="80px" Width="672px" TextMode="MultiLine"></asp:TextBox>
							<asp:Label ID="dwF_hmc101_expert_t" runat="server" CssClass="I" Style="z-index:214; left:0px; position: absolute; top:680px" Width="104px" Height="1px">專長：</asp:Label>
							<asp:TextBox ID="dwF_hmc101_expert" runat="server" CssClass="G"  Style="z-index:215; left:104px; position: absolute; top: 672px" Height="80px" Width="672px" TextMode="MultiLine"></asp:TextBox>
							<asp:CheckBox ID="dwF_hmc101_stop" runat="server" Style="z-index: 200; left: 106px; position: absolute; top: 759px" Text="停用" />
							<asp:Label ID="dwF_hmc101_aid_t" runat="server" CssClass="D" Style="z-index:219; left:8px; position: absolute; top:782px" Width="100px">新增人員：</asp:Label>
							<asp:Label ID="dwF_hmc101_aid" runat="server" CssClass="G" Style="z-index: 220; left:104px; position: absolute; top: 782px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmc101_adt_t" runat="server" CssClass="D" Style="z-index:224; left:8px; position: absolute; top:806px" Width="100px">新增時間：</asp:Label>
							<asp:Label ID="dwF_hmc101_adt" runat="server" CssClass="G" Style="z-index: 225; left:104px; position: absolute; top: 806px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmc101_uid_t" runat="server" CssClass="D" Style="z-index:229; left:8px; position: absolute; top:830px" Width="100px">異動人員：</asp:Label>
							<asp:Label ID="dwF_hmc101_uid" runat="server" CssClass="G" Style="z-index: 230; left:104px; position: absolute; top: 830px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmc101_udt_t" runat="server" CssClass="D" Style="z-index:234; left:8px; position: absolute; top:854px" Width="100px">異動時間：</asp:Label>
							<asp:Label ID="dwF_hmc101_udt" runat="server" CssClass="G" Style="z-index: 235; left:104px; position: absolute; top: 854px" Width="150px"></asp:Label>
							</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px; width: 799px;">
					</td>
				</tr>
				<tr>
					<td style="width: 799px">
						<div style="position: relative; float: right">
							<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
						</div>
					</td>
				</tr>
				<tr>
					<td style="height: 8px; width: 799px;">
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
