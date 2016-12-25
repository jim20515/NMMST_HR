<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0103_sys02.aspx.cs" Inherits="sys_s_s01_p_s0103_sys02" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>使用者權限設定</title>
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
							<asp:Label ID="dwQ_user01_id_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="84px">使用者帳號：</asp:Label>
							<asp:TextBox ID="dwQ_user01_id" runat="server" CssClass="G" Style="z-index: 102; left: 92px; position: absolute; top: 8px" Width="100px"></asp:TextBox>
							<asp:Label ID="dwQ_user01_name_t" runat="server" CssClass="Q" Style="z-index: 103; left: 196px; position: absolute; top: 12px" Width="84px">使用者姓名：</asp:Label>
							<asp:TextBox ID="dwQ_user01_name" runat="server" CssClass="G" Style="z-index: 104; left: 284px; position: absolute; top: 8px" Width="140px"></asp:TextBox>
							<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 105; left: 536px; position: absolute; top: 4px" Text="" Width="80px" />
							<asp:CheckBox ID="dwQ_notset_c" runat="server" CssClass="G" ForeColor="Blue" Style="z-index: 106; left: 436px; position: absolute; top: 8px" Text="未設定權限" />
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:DWPanel ID="dwS" runat="server" CssClass="Form" Height="132px" Style="position: relative" Width="800px">
							<asp:Label ID="dwS_user01_select_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="84px">使用者：</asp:Label>
							<asp:DropDownList ID="dwS_user01_select" runat="server" AutoPostBack="True" CssClass="G" DataMember="user01" DataSource="<%# indb_user01.dv_View %>" DataTextField="user01_name_c" DataValueField="user01_id" Style="z-index: 102; left: 92px; position: absolute; top: 8px" Width="500px" OnSelectedIndexChanged="dwS_user01_select_SelectedIndexChanged"></asp:DropDownList>
							<asp:Label ID="dwS_user01_id_t" runat="server" CssClass="D" Style="z-index: 103; left: 4px; position: absolute; top: 36px" Width="84px">使用者帳號：</asp:Label>
							<asp:Label ID="dwS_user01_id" runat="server" CssClass="G" Style="z-index: 104; left: 92px; position: absolute; top: 36px" Width="200px"></asp:Label>
							<asp:Label ID="dwS_user01_name_t" runat="server" CssClass="D" Style="z-index: 105; left: 300px; position: absolute; top: 36px" Width="84px">使用者姓名：</asp:Label>
							<asp:Label ID="dwS_user01_name" runat="server" CssClass="G" Style="z-index: 106; left: 388px; position: absolute; top: 36px" Width="200px"></asp:Label>
							<asp:Label ID="dwS_user01_dept_t" runat="server" CssClass="D" Style="z-index: 107; left: 4px; position: absolute; top: 60px" Width="84px">部門：</asp:Label>
							<asp:Label ID="dwS_user01_dept" runat="server" CssClass="G" Style="z-index: 108; left: 92px; position: absolute; top: 60px" Width="200px"></asp:Label>
							<asp:Label ID="dwS_user01_sdate_t" runat="server" CssClass="D" Style="z-index: 111; left: 4px; position: absolute; top: 84px" Width="84px">停用日期：</asp:Label>
							<asp:Label ID="dwS_user01_sdate" runat="server" CssClass="G" Style="z-index: 112; left: 92px; position: absolute; top: 84px" Width="200px"></asp:Label>
							<asp:Label ID="dwS_user01_email_t" runat="server" CssClass="D" Style="z-index: 113; left: 4px; position: absolute; top: 108px" Width="84px">電子信箱：</asp:Label>
							<asp:Label ID="dwS_user01_email" runat="server" CssClass="G" Style="z-index: 114; left: 92px; position: absolute; top: 108px" Width="498px"></asp:Label>
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
							<asp:Label ID="dwF_s02_grp_id_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="84px">群組：</asp:Label>
							<asp:DropDownList ID="dwF_s02_grp_id" runat="server" CssClass="G" DataMember="sys01" Style="z-index: 102; left: 92px; position: absolute; top: 8px" Width="500px"></asp:DropDownList>
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
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="84px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s02_grp_id" DataMember="sys02" DataSource="<%# indb_sys02.dv_View %>" Width="780px">
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
									<asp:TemplateColumn HeaderText="群組名稱">
										<ItemTemplate>
											<asp:Label ID="dwG_grp_name_c" runat="server" Text='<%# uf_Dg_Bind(dwF_s02_grp_id.Items, DataBinder.Eval(Container, "DataItem.s02_grp_id")) %>'></asp:Label>
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
