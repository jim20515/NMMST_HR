<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0202_sys05.aspx.cs" Inherits="sys_s_s02_p_s0202_sys05" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系統設定</title>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="108px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_s05_sys_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="88px">系統代碼：</asp:Label>
							<asp:TextBox ID="dwF_s05_sys_id" runat="server" CssClass="G" Style="z-index: 102; left: 96px; position: absolute; top: 8px" Width="100px"></asp:TextBox>
							<asp:Label ID="dwF_s05_sys_text_t" runat="server" CssClass="N" Style="z-index: 103; left: 4px; position: absolute; top: 36px" Width="88px">系統名稱：</asp:Label>
							<asp:TextBox ID="dwF_s05_sys_text" runat="server" CssClass="G" Style="z-index: 104; left: 96px; position: absolute; top: 32px" Width="400px"></asp:TextBox>
							<asp:Label ID="dwF_s05_sys_url_t" runat="server" CssClass="N" Style="z-index: 105; left: 4px; position: absolute; top: 60px" Width="88px">系統URL：</asp:Label>
							<asp:TextBox ID="dwF_s05_sys_url" runat="server" CssClass="G" Style="z-index: 106; left: 96px; position: absolute; top: 56px" Width="492px"></asp:TextBox>
							<asp:Label ID="dwF_s05_mod_id_t" runat="server" CssClass="N" Style="z-index: 107; left: 4px; position: absolute; top: 84px" Width="88px">系統模組：</asp:Label>
							<asp:DropDownList ID="dwF_s05_mod_id" runat="server" CssClass="G" DataMember="sys06" Style="z-index: 108; left: 96px; position: absolute; top: 80px" Width="300px"></asp:DropDownList>
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
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="168px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s05_sys_id" DataMember="sys05" DataSource="<%# indb_sys05.dv_View %>" Width="780px">
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
									<asp:BoundColumn DataField="s05_sys_id" HeaderText="代碼" SortExpression="s05_sys_id">
										<HeaderStyle Width="60px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="s05_sys_text" HeaderText="系統名稱" SortExpression="s05_sys_text"></asp:BoundColumn>
									<asp:BoundColumn DataField="s05_sys_url" HeaderText="系統 URL" SortExpression="s05_sys_url"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="系統模組">
										<ItemTemplate>
											<asp:Label ID="dwG_s05_mod_id" runat="server" Text='<%# uf_Dg_Bind(dwF_s05_mod_id.Items, DataBinder.Eval(Container, "DataItem.s05_mod_id")) %>'></asp:Label>
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
