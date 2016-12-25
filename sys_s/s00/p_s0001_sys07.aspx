<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0001_sys07.aspx.cs" Inherits="sys_s_s00_p_s0001_sys07" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>最新公告</title>
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
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="84px" Style="position: relative" Width="800px">
							<asp:Label ID="dwQ_s07_unit_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">公告部門：</asp:Label>
							<asp:DropDownList ID="dwQ_s07_unit" runat="server" CssClass="G" DataMember="hca202" Style="z-index: 102; left: 88px; position: absolute; top: 8px" Width="200px"></asp:DropDownList>
							<asp:Label ID="dwQ_s07_stop_t" runat="server" CssClass="Q" Style="z-index: 103; left: 292px; position: absolute; top: 12px" Width="80px">暫停：</asp:Label>
							<asp:RadioButtonList ID="dwQ_s07_stop" runat="server" CssClass="G" RepeatColumns="3" Style="z-index: 104; left: 376px; position: absolute; top: 8px">
								<asp:ListItem Selected="True" Value="">全部</asp:ListItem>
								<asp:ListItem Value="Y">是</asp:ListItem>
								<asp:ListItem Value="N">否</asp:ListItem>
							</asp:RadioButtonList>
							<asp:Label ID="dwQ_s07_spdate_t" runat="server" CssClass="Q" Style="z-index: 105; left: 4px; position: absolute; top: 36px" Width="80px">公告日期：</asp:Label>
							<asp:Panel ID="dwQ_s07_spdate" runat="server" CssClass="G" Style="z-index: 106; left: 88px; position: absolute; top: 32px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
							</asp:Panel>
							<div class="G" style="display: inline; left: 200px; position: absolute; top: 36px; z-index: 100;">
								～</div>
							<asp:Label ID="dwQ_s07_epdate_t" runat="server" CssClass="Q" Style="z-index: 108; left: 4px; position: absolute; top: 40px" Visible="False" Width="80px">公告日期：</asp:Label>
							<asp:Panel ID="dwQ_s07_epdate" runat="server" CssClass="G" Style="z-index: 109; left: 224px; position: absolute; top: 32px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date4" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwQ_s07_title_t" runat="server" CssClass="Q" Style="z-index: 110; left: 4px; position: absolute; top: 60px" Width="80px">公告標題：</asp:Label>
							<asp:TextBox ID="dwQ_s07_title" runat="server" CssClass="G" Style="z-index: 111; left: 88px; position: absolute; top: 56px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwQ_s07_content_t" runat="server" CssClass="Q" Style="z-index: 112; left: 292px; position: absolute; top: 60px" Width="80px">公告內容：</asp:Label>
							<asp:TextBox ID="dwQ_s07_content" runat="server" CssClass="G" Style="z-index: 113; left: 376px; position: absolute; top: 56px" Width="200px"></asp:TextBox>
							<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 114; left: 536px; position: absolute; top: 4px" Text="" Width="80px" />
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="228px" Style="position: relative" Width="800px">
							<asp:Label ID="dwF_s07_no_t" runat="server" CssClass="D" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">公告編號：</asp:Label>
							<asp:Label ID="dwF_s07_no" runat="server" CssClass="G" Style="z-index: 102; left: 88px; position: absolute; top: 12px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_s07_man_t" runat="server" CssClass="D" Style="z-index: 103; left: 292px; position: absolute; top: 12px" Width="80px">公告人員：</asp:Label>
							<asp:Label ID="dwF_s07_man" runat="server" CssClass="G" Style="z-index: 104; left: 376px; position: absolute; top: 12px" Width="200px"></asp:Label>
							<asp:Label ID="dwF_s07_unit_t" runat="server" CssClass="I" Style="z-index: 105; left: 4px; position: absolute; top: 36px" Width="80px">公告部門：</asp:Label>
							<asp:DropDownList ID="dwF_s07_unit" runat="server" CssClass="G" DataMember="hca202" Style="z-index: 106; left: 88px; position: absolute; top: 32px" Width="200px"></asp:DropDownList>
							<asp:Label ID="dwF_s07_sort_t" runat="server" CssClass="I" Style="z-index: 107; left: 292px; position: absolute; top: 36px" Width="80px">排序：</asp:Label>
							<asp:TextBox ID="dwF_s07_sort" runat="server" CssClass="G" Style="z-index: 108; left: 376px; position: absolute; top: 32px" Width="60px"></asp:TextBox>
							<asp:Label ID="dwF_s07_tounit_t" runat="server" CssClass="I" Style="z-index: 109; left: 4px; position: absolute; top: 60px" Width="80px">公告對象：</asp:Label>
							<asp:DropDownList ID="dwF_s07_tounit" runat="server" CssClass="G" DataMember="hca202" Style="z-index: 110; left: 88px; position: absolute; top: 56px" Width="200px"></asp:DropDownList>
							<asp:Label ID="dwF_s07_stop_t" runat="server" CssClass="I" Style="z-index: 111; left: 292px; position: absolute; top: 60px" Width="80px">暫停：</asp:Label>
							<asp:CheckBox ID="dwF_s07_stop" runat="server" CssClass="G" Style="z-index: 112; left: 376px; position: absolute; top: 58px" />
							<asp:Label ID="dwF_s07_pdate_t" runat="server" CssClass="N" Style="z-index: 113; left: 4px; position: absolute; top: 84px" Width="80px">公告日期：</asp:Label>
							<asp:Panel ID="dwF_s07_pdate" runat="server" CssClass="G" Style="z-index: 114; left: 88px; position: absolute; top: 80px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwF_s07_edate_t" runat="server" CssClass="I" Style="z-index: 115; left: 284px; position: absolute; top: 84px" Width="88px">公告到期日：</asp:Label>
							<asp:Panel ID="dwF_s07_edate" runat="server" CssClass="G" Style="z-index: 116; left: 376px; position: absolute; top: 80px" Width="132px">
								<uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
							</asp:Panel>
							<asp:Label ID="dwF_s07_title_t" runat="server" CssClass="N" Style="z-index: 117; left: 4px; position: absolute; top: 108px" Width="80px">公告標題：</asp:Label>
							<asp:TextBox ID="dwF_s07_title" runat="server" CssClass="G" MaxLength="100" Style="z-index: 118; left: 88px; position: absolute; top: 104px" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_s07_content_t" runat="server" CssClass="I" Style="z-index: 119; left: 4px; position: absolute; top: 132px" Width="80px">公告內容：</asp:Label>
							<asp:TextBox ID="dwF_s07_content" runat="server" CssClass="G" Height="48px" Style="z-index: 120; left: 88px; position: absolute; top: 128px" TextMode="MultiLine" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_s07_url_t" runat="server" CssClass="I" Style="z-index: 121; left: 4px; position: absolute; top: 180px" Width="80px">相關連結：</asp:Label>
							<asp:TextBox ID="dwF_s07_url" runat="server" CssClass="G" MaxLength="100" Style="z-index: 122; left: 88px; position: absolute; top: 176px" Width="500px"></asp:TextBox>
							<asp:Label ID="dwF_s07_uid_t" runat="server" CssClass="D" Style="z-index: 123; left: 4px; position: absolute; top: 204px" Width="80px">異動人員：</asp:Label>
							<asp:Label ID="dwF_s07_uid" runat="server" CssClass="G" Style="z-index: 124; left: 88px; position: absolute; top: 204px"></asp:Label>
							<asp:Label ID="dwF_s07_udt_t" runat="server" CssClass="D" Style="z-index: 125; left: 292px; position: absolute; top: 204px" Width="80px">異動時間：</asp:Label>
							<asp:Label ID="dwF_s07_udt" runat="server" CssClass="G" Style="z-index: 126; left: 376px; position: absolute; top: 204px"></asp:Label>
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
							★ 注意：公告內容不可包含單引號或雙引號。</div>
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
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="200px" Width="800px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="s07_no" DataSource="<%# indb_sys07.dv_View %>" Width="780px">
								<SelectedItemStyle CssClass="Grid_Select" />
								<ItemStyle CssClass="Grid_Detail" />
								<HeaderStyle CssClass="Grid_Head" />
								<FooterStyle CssClass="Grid_Footer" />
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
											</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="s07_no" HeaderText="公告編號" SortExpression="s07_no">
										<HeaderStyle Width="60px" />
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="公告日期">
										<HeaderStyle Width="80px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_s07_pdate" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.s07_pdate"), false) %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="公告到期日">
										<HeaderStyle Width="80px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_s07_edate" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.s07_edate"), false) %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="s07_title" HeaderText="公告標題" SortExpression="s07_title"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="暫停">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="dwG_s07_stop" runat="server" Text='<%# uf_Dg_BindBool("ˇ", uf_Dg_BindBool("Y,N", DataBinder.Eval(Container, "DataItem.s07_stop"))) %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="s07_sort" HeaderText="排序" SortExpression="s07_sort">
										<HeaderStyle Width="30px" />
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
