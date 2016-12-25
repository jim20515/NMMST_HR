<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0102_01.aspx.cs" Inherits="sys_d_d01_p_d0102_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>查詢及清單</title>
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div>
					<asp:Panel ID="pn_Contain" runat="server">
						<table class="G">
							<tr>
								<td>
									<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="103px" Style="position: relative" Width="820px">
										<asp:Label ID="dwQ_hmd102_year_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">年度：</asp:Label>
										<asp:DropDownList ID="dwQ_hmd102_year" runat="server" CssClass="B" DataMember="YY_dc" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmd102_season_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 12px" Width="100px">季：</asp:Label>
										<asp:DropDownList ID="dwQ_hmd102_season" runat="server" CssClass="B" DataMember="YY_dc" Style="z-index: 105; left: 508px; position: absolute; top: 8px" Width="200px">
											<asp:ListItem Value="">《全部》</asp:ListItem>
											<asp:ListItem Value="0">-</asp:ListItem>
											<asp:ListItem Value="1">第一季</asp:ListItem>
											<asp:ListItem Value="2">第二季</asp:ListItem>
											<asp:ListItem Value="3">第三季</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmd102_tid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 38px" Width="100px">志工隊：</asp:Label>
										<asp:DropDownList ID="dwQ_hmd102_tid" runat="server" CssClass="B" DataMember="hmd101" Style="z-index: 100; left: 104px; position: absolute; top: 34px" Width="200px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmd102_ktype_t" runat="server" CssClass="Q" Style="z-index: 99; left: 408px; position: absolute; top: 38px" Width="100px">考核類別：</asp:Label>
										<asp:DropDownList ID="dwQ_hmd102_ktype" runat="server" CssClass="B" Style="z-index: 100; left: 508px; position: absolute; top: 34px" Width="200px">
											<asp:ListItem Value="">《全部》</asp:ListItem>
											<asp:ListItem Value="1">實習志工考核</asp:ListItem>
											<asp:ListItem Value="2">正式志工季考核</asp:ListItem>
											<asp:ListItem Value="3">正式志工年考核</asp:ListItem>
										</asp:DropDownList>
										<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 64px" Text="" Width="80px" />
									</witc:DWPanel>
								</td>
							</tr>
							<tr>
								<td style="height: 4px">
								</td>
							</tr>
							<tr>
								<td>
									<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
										<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd102_year" DataMember="hmd102" DataSource="<%# indb_hmd102.dv_View %>" Width="800px">
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
												<asp:BoundColumn DataField="hmd102_year" HeaderText="年度" SortExpression="hmd102_year"></asp:BoundColumn>
												<asp:BoundColumn DataField="hmd102_season" HeaderText="季" SortExpression="hmd102_season" Visible="false"></asp:BoundColumn>
												<asp:BoundColumn DataField="hmd102_tid" HeaderText="志工隊" SortExpression="hmd102_tid" Visible="false"></asp:BoundColumn>
												<asp:BoundColumn DataField="hmd102_ktype" HeaderText="考核類別" SortExpression="hmd102_ktype" Visible="false"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="季">
													<ItemTemplate>
														<asp:Label ID="dwG_hmd102_season" runat="server" Text='<%# uf_Dg_Bind(dwQ_hmd102_season.Items, DataBinder.Eval(Container, "DataItem.hmd102_season"))  %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="志工隊">
													<ItemTemplate>
														<asp:Label ID="dwG_hmd102_tid" runat="server" Text='<%# uf_Dg_Bind("hmd101", DataBinder.Eval(Container, "DataItem.hmd102_tid"))  %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="考核類別">
													<ItemTemplate>
														<asp:Label ID="dwG_hmd102_ktype" runat="server" Text='<%# uf_Dg_Bind(dwQ_hmd102_ktype.Items, DataBinder.Eval(Container, "DataItem.hmd102_ktype"))  %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hmd102_epass" HeaderText="服勤合格時數" SortExpression="hmd102_epass"></asp:BoundColumn>
												<asp:BoundColumn DataField="hmd102_fpass" HeaderText="訓練合格時數" SortExpression="hmd102_fpass"></asp:BoundColumn>
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
