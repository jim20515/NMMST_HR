<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_i0101_01.aspx.cs" Inherits="sys_i_i01_p_i0101_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>查詢及清單</title>
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
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="77px" Style="position: relative" Width="820px">
							<asp:Label ID="dwQ_hmc101_cname_t" runat="server" CssClass="Q" Style="z-index: 99; left:4px; position: absolute; top:12px" Width="100px">成員姓名：</asp:Label>
							<asp:TextBox ID="dwQ_hmc101_cname" CssClass="G" runat="server" Style="z-index: 100; left:104px; position: absolute; top:8px" Width="200px"></asp:TextBox>
							<asp:Label ID="dwQ_hmc101_deptid_t" runat="server" CssClass="Q" Style="z-index: 104; left:408px; position: absolute; top:12px" Width="100px">部門：</asp:Label>
							<asp:TextBox ID="dwQ_hmc101_deptid" CssClass="G" runat="server" Style="z-index: 105; left:508px; position: absolute; top:8px" Width="200px"></asp:TextBox>
							<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left:728px; position: absolute; top:38px" Text="" Width="80px" />
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
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmc101_id" DataMember="hmc101" DataSource="<%# indb_hmc101.dv_View %>" Width="800px">
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
				<asp:BoundColumn DataField="hmc101_id" HeaderText="成員代碼" SortExpression="hmc101_id"></asp:BoundColumn>
				<asp:BoundColumn DataField="hmc101_cname" HeaderText="成員姓名" SortExpression="hmc101_cname"></asp:BoundColumn>
				<asp:TemplateColumn HeaderText="部門">
				    <ItemTemplate>
				         <asp:Label ID="dwG_hmc101_deptid" runat="server" Text='<%# uf_Dg_Bind("hca202", DataBinder.Eval(Container, "DataItem.hmc101_deptid")) %>'></asp:Label>
				    </ItemTemplate>
				</asp:TemplateColumn>
				<asp:BoundColumn DataField="hmc101_jobtitle" HeaderText="職位" SortExpression="hmc101_jobtitle"></asp:BoundColumn>
				<asp:BoundColumn DataField="hmc101_addot" HeaderText="地址" SortExpression="hmc101_addot"></asp:BoundColumn>
				<asp:BoundColumn DataField="hmc101_email" HeaderText="E-Mail" SortExpression="hmc101_email"></asp:BoundColumn>
				<asp:BoundColumn DataField="hmc101_phnowex" HeaderText="分機" SortExpression="hmc101_phnowex"></asp:BoundColumn>

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
