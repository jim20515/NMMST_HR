<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0203_sys04.aspx.cs" Inherits="sys_s_s02_p_s0203_sys04" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系統功能設定</title>
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
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="132px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_s04_sys_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">系統：</asp:Label>
							<asp:DropDownList ID="dwF_s04_sys_id" runat="server" AutoPostBack="True" CssClass="G" DataMember="sys05" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="200px" OnSelectedIndexChanged="dwF_s04_sys_id_SelectedIndexChanged"></asp:DropDownList>
							<asp:Label ID="dwF_s04_func_id_t" runat="server" CssClass="N" Style="z-index: 103; left: 312px; position: absolute; top: 12px" Width="80px">功能代碼：</asp:Label>
							<asp:TextBox ID="dwF_s04_func_id" runat="server" CssClass="G" Style="z-index: 104; left: 392px; position: absolute; top: 8px" Width="100px"></asp:TextBox>
							<asp:Label ID="dwF_s04_func_text_t" runat="server" CssClass="N" Style="z-index: 105; left: 4px; position: absolute; top: 36px" Width="80px">功能名稱：</asp:Label>
							<asp:TextBox ID="dwF_s04_func_text" runat="server" CssClass="G" Style="z-index: 106; left: 88px; position: absolute; top: 32px" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_s04_func_url_t" runat="server" CssClass="I" Style="z-index: 107; left: 4px; position: absolute; top: 60px" Width="80px">功能URL：</asp:Label>
							<asp:TextBox ID="dwF_s04_func_url" runat="server" CssClass="G" Style="z-index: 108; left: 88px; position: absolute; top: 56px" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_s04_func_parent_t" runat="server" CssClass="I" Style="z-index: 109; left: 4px; position: absolute; top: 84px" Width="80px">父層功能：</asp:Label>
							<asp:DropDownList ID="dwF_s04_func_parent" runat="server" AutoPostBack="True" CssClass="G" DataMember="sys04_p" Style="z-index: 110; left: 88px; position: absolute; top: 80px" Width="200px" OnSelectedIndexChanged="dwF_s04_func_parent_SelectedIndexChanged"></asp:DropDownList>
							<asp:Label ID="dwF_s04_func_flag_t" runat="server" CssClass="I" Style="z-index: 111; left: 312px; position: absolute; top: 84px" Width="80px">功能註記：</asp:Label>
							<asp:CheckBox ID="dwF_s04_func_flag" runat="server" CssClass="G" Style="z-index: 112; left: 392px; position: absolute; top: 80px" />
							<asp:Label ID="dwF_s04_func_seq_t" runat="server" CssClass="N" Style="z-index: 113; left: 452px; position: absolute; top: 84px" Width="80px">功能序號：</asp:Label>
							<asp:DropDownList ID="dwF_s04_func_seq" runat="server" Style="z-index: 114; left: 532px; position: absolute; top: 80px" Width="60px"></asp:DropDownList>
							<asp:Label ID="dwF_s04_func_item_t" runat="server" CssClass="I" Style="z-index: 115; left: 4px; position: absolute; top: 108px" Width="80px">功能分頁：</asp:Label>
							<asp:TextBox ID="dwF_s04_func_item" runat="server" CssClass="G" Style="z-index: 116; left: 88px; position: absolute; top: 104px" Width="320px"></asp:TextBox>
							<div class="RT" style="display: inline; z-index: 117; left: 416px; position: absolute; top: 108px">ex. 查詢=query|清單=list|明細=edit;1|</div>
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td style="position: relative">
						<div class="RI" style="display: inline; position: absolute; top: 4px">
							☆ 注意：功能序號必須要在父層功能序號之後 ☆</div>
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
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="148px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s04_func_seq" DataMember="sys04" DataSource="<%# indb_sys04.dv_View %>" Width="780px">
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
									<asp:TemplateColumn HeaderText="系統">
										<ItemTemplate>
											<asp:Label ID="dwG_s04_sys_id" runat="server" Text='<%# uf_Dg_Bind(dwF_s04_sys_id.Items, DataBinder.Eval(Container, "DataItem.s04_sys_id")) %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="s04_func_id" HeaderText="功能<br />代碼" SortExpression="s04_func_id"></asp:BoundColumn>
									<asp:BoundColumn DataField="s04_func_text" HeaderText="功能名稱" SortExpression="s04_func_text"></asp:BoundColumn>
									<asp:BoundColumn DataField="s04_func_url" HeaderText="功能 URL" SortExpression="s04_func_url"></asp:BoundColumn>
									<asp:BoundColumn DataField="s04_func_parent" HeaderText="父層<br />代碼" SortExpression="s04_func_parent"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="功能<br />註記">
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_s04_func_flag" runat="server" Visible='<%# uf_Dg_BindBool("Y", DataBinder.Eval(Container, "DataItem.s04_func_flag")) %>'>ˇ</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="s04_func_seq" HeaderText="功能<br />序號" SortExpression="s04_func_seq">
										<ItemStyle HorizontalAlign="Center" />
									</asp:BoundColumn>
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
