<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_i0101_02.aspx.cs" Inherits="sys_i_i01_p_i0101_02" %>
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
					    ◎員工聯絡簿明細資料：
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="311px" Style="position: relative" Width="820px">
							<asp:Label ID="dwF_hmc101_id_t" runat="server" CssClass="D" Style="z-index:99; left:4px; position: absolute; top:8px" Width="100px">成員代碼：</asp:Label>
							<asp:Label ID="dwF_hmc101_id" runat="server" CssClass="G"  Style="z-index:100; left:104px; position: absolute; top:4px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmc101_cname_t" runat="server" CssClass="D" Style="z-index:104; left:4px; position: absolute; top:34px" Width="100px">成員姓名：</asp:Label>
							<asp:Label ID="dwF_hmc101_cname" runat="server" CssClass="G" Style="z-index: 105; left:104px; position: absolute; top: 30px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmc101_gent_t" runat="server" CssClass="D" Style="z-index:109; left:4px; position: absolute; top:60px" Width="100px">性別：</asp:Label>
							<asp:Label ID="dwF_hmc101_gent" runat="server" CssClass="G" Style="z-index: 110; left:104px; position: absolute; top: 56px" Width="150px"></asp:Label>
                            <asp:Label ID="dwF_hmc101_bday_t" runat="server" CssClass="D" Style="z-index:114; left:4px; position: absolute; top: 86px" Width="100px">生日：</asp:Label>
							<asp:Label ID="dwF_hmc101_bday" runat="server" CssClass="G" Style="z-index:115; left:104px; position: absolute; top:82px" Width="132px"></asp:Label>
							<asp:Label ID="dwF_hmc101_deptid_t" runat="server" CssClass="D" Style="z-index:119; left:4px; position: absolute; top:112px" Width="100px">部門：</asp:Label>
							<asp:Label ID="dwF_hmc101_deptid" runat="server" CssClass="G" Style="z-index: 120; left:104px; position: absolute; top: 108px" Width="150px"></asp:Label>
							<asp:Label ID="dwF_hmc101_jobtitle_t" runat="server" CssClass="D" Style="z-index:124; left:4px; position: absolute; top:138px" Width="100px">職位：</asp:Label>
							<asp:Label ID="dwF_hmc101_jobtitle" runat="server" CssClass="G"  Style="z-index:125; left:104px; position: absolute; top:134px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmc101_addid_t" runat="server" CssClass="D" Style="z-index:129; left:4px; position: absolute; top:164px" Width="100px">區碼：</asp:Label>
							<asp:Label ID="dwF_hmc101_addid" runat="server" Style="z-index:130; left:104px; position: absolute; top:160px" Width="105px" ></asp:Label>
							<asp:Label ID="dwF_hmc101_addot_t" runat="server" CssClass="D" Style="z-index:134; left:4px; position: absolute; top:190px" Width="100px">地址：</asp:Label>
							<asp:Label ID="dwF_hmc101_addot" runat="server" CssClass="G"  Style="z-index:135; left:104px; position: absolute; top:186px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmc101_email_t" runat="server" CssClass="D" Style="z-index:139; left:4px; position: absolute; top:216px" Width="100px">E-Mail：</asp:Label>
							<a href="mailto://<%=dwF_hmc101_email.Text %>"  ><asp:Label ID="dwF_hmc101_email" runat="server" CssClass="G"  Style="z-index:140; left:104px; position: absolute; top:212px" Width="200px"></asp:Label></a>
							<asp:Label ID="dwF_hmc101_phnow_t" runat="server" CssClass="D" Style="z-index:144; left:4px; position: absolute; top:242px" Width="100px">工作電話：</asp:Label>
							<asp:Label ID="dwF_hmc101_phnow" runat="server" CssClass="G"  Style="z-index:145; left:104px; position: absolute; top:238px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_hmc101_phnowex_t" runat="server" CssClass="D" Style="z-index:149; left:4px; position: absolute; top:268px" Width="100px">分機：</asp:Label>
							<asp:Label ID="dwF_hmc101_phnowex" runat="server" CssClass="G"  Style="z-index:150; left:104px; position: absolute; top:264px" Width="200px"></asp:Label>

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
							<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" Visible = "false" />
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
