<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0102_sys03.aspx.cs" Inherits="sys_s_s01_p_s0102_sys03" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系統群組權限設定</title>
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
							<asp:Label ID="dwQ_s01_grp_id_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">群組代碼：</asp:Label>
							<asp:TextBox ID="dwQ_s01_grp_id" runat="server" CssClass="G" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="160px"></asp:TextBox>
							<asp:Label ID="dwQ_s01_grp_name_t" runat="server" CssClass="Q" Style="z-index: 103; left: 272px; position: absolute; top: 12px" Width="80px">群組名稱：</asp:Label>
							<asp:TextBox ID="dwQ_s01_grp_name" runat="server" CssClass="G" Style="z-index: 104; left: 356px; position: absolute; top: 8px" Width="160px"></asp:TextBox>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="36px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_s01_grp_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">群組：</asp:Label>
							<asp:DropDownList ID="dwF_s01_grp_id" runat="server" AutoPostBack="True" CssClass="G" DataMember="sys01" DataSource="<%# indb_sys01.dv_View %>" DataTextField="s01_grp_name_c" DataValueField="s01_grp_id" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="428px" OnSelectedIndexChanged="dwF_s01_grp_id_SelectedIndexChanged"></asp:DropDownList>
							<asp:Button ID="bt_Save" runat="server" CssClass="Bt_Save" Enabled="False" Style="z-index: 103; left: 536px; position: absolute; top: 4px" Text="" Width="80px" OnClick="bt_Save_Click" />
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="232px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s04_func_seq" DataMember="sys04" DataSource="<%# indb_sys04.dv_View %>" Width="780px" OnItemCommand="dgG_ItemCommand">
								<SelectedItemStyle CssClass="Grid_Select" />
								<ItemStyle CssClass="Grid_Detail" />
								<HeaderStyle CssClass="Grid_Head" />
								<FooterStyle CssClass="Grid_Footer" />
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="系統">
										<ItemTemplate>
											<asp:Label ID="dwG_s04_sys_id" runat="server" Text='<%# uf_Dg_Bind("sys05", DataBinder.Eval(Container, "DataItem.s04_sys_id")) %>' Visible='<%# uf_Dg_BindFirstBool(true, false, DataBinder.Eval(Container, "DataItem.s04_sys_id")) %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="功能名稱">
										<ItemTemplate>
											<asp:Label ID="dwG_s04_func_text" runat="server" Text='<%# uf_Dg_Bind("sys04_pn", DataBinder.Eval(Container, "DataItem.s04_func_parent")) + DataBinder.Eval(Container, "DataItem.s04_func_text").ToString() %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="系統全部">
										<HeaderStyle Width="80px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwQ_sys_check_c" runat="server" CausesValidation="False" CommandName="CheckSysAll" CssClass="B" TabIndex="-1" Text="選擇" Visible='<%# uf_Dg_BindFirstBool(false, false, DataBinder.Eval(Container, "DataItem.s04_sys_id")) %>'>選擇</asp:LinkButton>&nbsp;&nbsp;&nbsp;
											<asp:LinkButton ID="dwQ_sys_uncheck_c" runat="server" CausesValidation="False" CommandName="UnCheckSysAll" CssClass="B" TabIndex="-1" Text="不選" Visible='<%# uf_Dg_BindFirstBool(false, true, DataBinder.Eval(Container, "DataItem.s04_sys_id")) %>'>不選</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="群組權限">
										<HeaderStyle Width="60px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:CheckBox ID="dwG_s04_in_s03_c" runat="server" Checked='<%# uf_Dg_BindExistBool(indb_sys03.dv_View, DataBinder.Eval(Container, "DataItem.s04_sys_id"), DataBinder.Eval(Container, "DataItem.s04_func_id")) %>' TabIndex="-1" Visible='<%# uf_Dg_BindBool(",0", dwF_s01_grp_id.Items.Count) %>' />
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
