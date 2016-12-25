<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0101_01.aspx.cs" Inherits="sys_d_d01_p_d0101_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
	TagPrefix="uc1" %>
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
									<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
										left: 1px; top: 2px;" Width="800px">
										<asp:Label ID="dwQ_hmd101_tid_t" runat="server" CssClass="Q" Style="z-index: 101;
											left: 7px; position: absolute; top: 10px" Width="80px" >志工隊代碼：</asp:Label>
										<asp:Label ID="dwQ_hmd101_tname_t" runat="server" CssClass="Q"  Style="z-index: 101;
											left: 321px; position: absolute; top: 10px" Width="80px">志工隊名稱：</asp:Label>
										<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 114;
											left: 716px; position: absolute; top: 4px" />
										<asp:TextBox ID="dwQ_hmd101_tid" runat="server" Style="left: 91px; position: absolute;
											top: 7px" Width="178px"></asp:TextBox>
										<asp:TextBox ID="dwQ_hmd101_tname" runat="server" Style="left: 407px; position: absolute;
											top: 7px" Width="249px"></asp:TextBox>
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
										<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
											DataKeyField="hmd101_tid" DataMember="hmd101" DataSource="<%# indb_hmd101.dv_View %>"
											Width="800px">
											<ItemStyle CssClass="Grid_Detail" />
											<HeaderStyle CssClass="Grid_Head" />
											<FooterStyle CssClass="Grid_Footer" />
											<Columns>
												<asp:TemplateColumn HeaderText="序號">
													<HeaderStyle Width="30px" />
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
															TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hmd101_tid" HeaderText="志工隊代碼" SortExpression="hmd101_tid">
												</asp:BoundColumn>
												<asp:BoundColumn DataField="hmd101_tname" HeaderText="志工隊名稱" SortExpression="hmd101_tname">
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
