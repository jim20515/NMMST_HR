<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0302_01.aspx.cs" Inherits="sys_d_d03_p_d0302_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>服勤時數匯出清冊</title>
	<link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
	<link href="../../proj_css/s_webstyle.css" rel="stylesheet" type="text/css" />
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
									<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="70px" Style="position: relative" Width="820px">
										<asp:Label ID="dwQ_hme101a_tid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 35px; position: absolute; top: 11px" Width="80px">排班志工隊：</asp:Label>
										<asp:DropDownList ID="dwQ_hme101a_tid" runat="server" CssClass="B" DataMember="hmd101" Style="left: 117px; position: absolute; top: 8px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hme101a_ym_t" runat="server" CssClass="Q" Style="z-index: 101; left: 282px; position: absolute; top: 11px" Width="80px">查詢年月：</asp:Label>
										<asp:Label ID="dwQ_hme101a_syear_t" runat="server" CssClass="Q" Style="z-index: 101; left: 405px; position: absolute; top: 11px" Width="18px">年</asp:Label>
										<asp:Label ID="dwQ_hme101a_smonth_t" runat="server" CssClass="Q" Style="z-index: 101; left: 466px; position: absolute; top: 11px" Width="18px">月</asp:Label>
										<asp:TextBox ID="dwQ_hme101a_syear" runat="server" Style="left: 364px; position: absolute; top: 8px" Width="33px"></asp:TextBox>
										<asp:TextBox ID="dwQ_hme101a_smonth" runat="server" Style="left: 425px; position: absolute; top: 8px" Width="33px"></asp:TextBox>
										<asp:Label ID="dwQ_hme101_tid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 35px; position: absolute; top: 38px" Width="80px">所屬志工隊：</asp:Label>
										<asp:DropDownList ID="dwQ_hme101_tid" runat="server" CssClass="B" DataMember="hmd101" Style="left: 117px; position: absolute; top: 34px">
										</asp:DropDownList>
										<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 728px; position: absolute; top: 35px" Text="" Width="80px" />
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
										<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme101a_psid" DataMember="hme101a" DataSource="<%# indb_hme101a.dv_View %>" Width="800px">
											<ItemStyle CssClass="Grid_Detail" />
											<HeaderStyle CssClass="Grid_Head" />
											<FooterStyle CssClass="Grid_Footer" />
											<Columns>
												<asp:TemplateColumn HeaderText="勾選">
													<HeaderStyle Width="30px" />
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:CheckBox ID="dwg_check" runat="server" CausesValidation="False" Checked='<%# this.uf_Check_List(DataBinder.Eval(Container, "DataItem.hme101a_psid")) %>' />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="排班志工隊">
													<ItemTemplate>
														<asp:Label ID="dwG_hme101a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hme101a_tid")) %>'>
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hme101a_syear" HeaderText="年" SortExpression="hme101a_syear">
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
												</asp:BoundColumn>
												<asp:BoundColumn DataField="hme101a_smonth" HeaderText="月" SortExpression="hme101a_smonth">
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Justify" />
												</asp:BoundColumn>
											</Columns>
										</asp:DataGrid>
									</witc:ScrollGrid>
								</td>
							</tr>
							<tr>
								<td style="height: 40px">
									<asp:Button ID="bt_Export" runat="server" CssClass="Bt_Export" OnClick="bt_Export_Click" Style="position: relative; left: 361px; top: -2px;" Text="" Width="80px" />
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
