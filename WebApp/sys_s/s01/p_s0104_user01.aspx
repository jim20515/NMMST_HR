<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0104_user01.aspx.cs" Inherits="sys_s_s01_p_s0104_user01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>使用者帳號管理</title>
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
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="36px" Style="position: relative" Width="800px">
							<asp:Label ID="dwQ_user01_id_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">帳號：</asp:Label>
							<asp:TextBox ID="dwQ_user01_id" runat="server" CssClass="G" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="160px"></asp:TextBox>
							<asp:Label ID="dwQ_user01_name_t" runat="server" CssClass="Q" Style="z-index: 103; left: 272px; position: absolute; top: 12px" Width="80px">姓名：</asp:Label>
							<asp:TextBox ID="dwQ_user01_name" runat="server" CssClass="G" Style="z-index: 104; left: 356px; position: absolute; top: 8px" Width="160px"></asp:TextBox>
							<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 105; left: 536px; position: absolute; top: 4px" Text="" Width="80px" />
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="132px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_user01_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">帳號：</asp:Label>
							<asp:TextBox ID="dwF_user01_id" runat="server" CssClass="G" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_user01_name_t" runat="server" CssClass="N" Style="z-index: 103; left: 292px; position: absolute; top: 12px" Width="80px">姓名：</asp:Label>
							<asp:TextBox ID="dwF_user01_name" runat="server" CssClass="G" Style="z-index: 104; left: 376px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwF_user01_dept_t" runat="server" CssClass="I" Style="z-index: 105; left: 4px; position: absolute; top: 36px" Width="80">部門：</asp:Label>
							<asp:DropDownList ID="dwF_user01_dept" runat="server" CssClass="G" DataMember="hca202" Style="z-index: 106; left: 88px; position: absolute; top: 32px" Width="200px"></asp:DropDownList>
							<asp:Label ID="dwF_user01_email_t" runat="server" CssClass="I" Style="z-index: 109; left: 4px; position: absolute; top: 60px" Width="80px">電子信箱：</asp:Label>
							<asp:TextBox ID="dwF_user01_email" runat="server" CssClass="G" Style="z-index: 110; left: 88px; position: absolute; top: 56px" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_user01_sdate_t" runat="server" CssClass="I" Style="z-index: 111; left: 4px; position: absolute; top: 84px" Width="80px">停用日期：</asp:Label>
							<asp:Panel ID="dwF_user01_sdate" runat="server" CssClass="G" Style="z-index: 112; left: 88px; position: absolute; top: 80px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwF_user01_uid_t" runat="server" CssClass="D" Style="z-index: 113; left: 4px; position: absolute; top: 108px" Width="80px">異動人員：</asp:Label>
							<asp:Label ID="dwF_user01_uid" runat="server" CssClass="G" Style="z-index: 114; left: 88px; position: absolute; top: 108px"></asp:Label>
							<asp:Label ID="dwF_user01_udt_t" runat="server" CssClass="D" Style="z-index: 115; left: 292px; position: absolute; top: 108px" Width="80px">異動時間：</asp:Label>
							<asp:Label ID="dwF_user01_udt" runat="server" CssClass="G" Style="z-index: 116; left: 376px; position: absolute; top: 108px"></asp:Label>
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
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="104px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="user01_id" DataSource="<%# indb_user01.dv_View %>" Width="780px" OnItemCommand="dgG_ItemCommand">
								<SelectedItemStyle CssClass="Grid_Select" />
								<ItemStyle CssClass="Grid_Detail" />
								<HeaderStyle CssClass="Grid_Head" />
								<FooterStyle CssClass="Grid_Footer" />
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="user01_id" HeaderText="帳號" SortExpression="user01_id">
										<HeaderStyle Width="60px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="user01_name" HeaderText="姓名" SortExpression="user01_name">
										<HeaderStyle Width="80px" />
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="部門">
										<ItemTemplate>
											<asp:Label ID="dwG_user01_dept" runat="server" Text='<%# uf_Dg_Bind("hca202", DataBinder.Eval(Container, "DataItem.user01_dept")) %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="停用日期">
										<HeaderStyle Width="80px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_user01_sdate" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.user01_sdate"), false) %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="功能選項">
										<HeaderStyle Width="88px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwG_select_pwd_c" runat="server" CommandName="SelectPwd" Text='<%# DataBinder.Eval(Container, "DataItem.user01_email").ToString().Trim() != "" ? "產生亂數密碼" : "重設指定密碼" %>'></asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</witc:ScrollGrid>
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
