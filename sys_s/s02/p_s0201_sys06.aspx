<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0201_sys06.aspx.cs" Inherits="sys_s_s02_p_s0201_sys06" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系統模組設定</title>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="60px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_s06_mod_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">模組代碼：</asp:Label>
							<asp:TextBox ID="dwF_s06_mod_id" runat="server" CssClass="G" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="100px"></asp:TextBox>
							<asp:Label ID="dwF_s06_mod_text_t" runat="server" CssClass="N" Style="z-index: 103; left: 4px; position: absolute; top: 36px" Width="80px">模組名稱：</asp:Label>
							<asp:TextBox ID="dwF_s06_mod_text" runat="server" CssClass="G" Style="z-index: 104; left: 88px; position: absolute; top: 32px" Width="400px"></asp:TextBox>
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
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="220px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s06_mod_id" DataMember="sys06" DataSource="<%# indb_sys06.dv_View %>" Width="780px">
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
									<asp:BoundColumn DataField="s06_mod_id" HeaderText="代碼" SortExpression="s06_mod_id">
										<HeaderStyle Width="60px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="s06_mod_text" HeaderText="模組名稱" SortExpression="s06_mod_text"></asp:BoundColumn>
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
