<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0303_01.aspx.cs" Inherits="sys_d_d03_p_d0303_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>教育訓練時數匯出清冊</title>
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
								<td style="height: 95px; width: 605px;">
									<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="104px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
										<asp:Label ID="dwQ_hmf102_trainid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">訓練代號：</asp:Label>
										<asp:TextBox ID="dwQ_hmf102_trainid" runat="server" CssClass="G" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
										<asp:Label ID="dwQ_hmf102_courseid_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 12px" Width="100px">課程：</asp:Label>
										<asp:DropDownList ID="dwQ_hmf102_courseid" runat="server" CssClass="B" DataMember="hmf101" Style="z-index: 105; left: 508px; position: absolute; top: 8px" Width="200px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmf102_teacher_t" runat="server" CssClass="Q" Style="z-index: 109; left: 4px; position: absolute; top: 38px" Width="100px">授課講師：</asp:Label>
										<asp:TextBox ID="dwQ_hmf102_teacher" runat="server" CssClass="G" Style="z-index: 110; left: 104px; position: absolute; top: 34px" Width="200px"></asp:TextBox>
										<asp:Label ID="dwQ_hmf102_tid_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 38px" Width="100px">志工隊：</asp:Label>
										<asp:DropDownList ID="dwQ_hmf102_tid" runat="server" CssClass="B" DataMember="hmd101" Style="z-index: 105; left: 508px; position: absolute; top: 34px" Width="200px">
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmf102_sdate_t" runat="server" CssClass="N" Style="z-index: 117; left: -1px; position: absolute; top: 62px" Width="104px">訓練班日期：</asp:Label>
										<asp:Panel ID="dwQ_hmf102_sdate" runat="server" CssClass="G" Style="z-index: 109; left: 104px; position: absolute; top: 60px" Width="132px">
											<uc1:u_DateSelect_ROC ID="u_hmf102_sdate" runat="server" />
										</asp:Panel>
										<asp:Label ID="dwQ_hmf102_edate_t" runat="server" CssClass="N" Style="z-index: 117; left: 211px; position: absolute; top: 62px" >～</asp:Label>
										<asp:Panel ID="dwQ_hmf102_edate" runat="server" CssClass="G" Style="z-index: 109; left: 236px; position: absolute; top: 60px" Width="132px">
											<uc1:u_DateSelect_ROC ID="u_hmf102_edate" runat="server" />
										</asp:Panel>
										<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 716px; position: absolute; top: 68px" Text="" Width="80px" />
									</witc:DWPanel>
								</td>
							</tr>
							<tr>
								<td style="height: 4px; width: 605px;">
								</td>
							</tr>
							<tr>
								<td style="height: 300px; width: 605px;">
									<witc:ScrollGrid ID="dwG" runat="server" AJAXScript="Yes" CssClass="Grid" Height="250px" Width="800px">
										<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmf102_trainid" DataMember="hmf102" DataSource="<%# indb_hmf102.dv_View %>" Width="780px">
											<SelectedItemStyle CssClass="Grid_Select" />
											<ItemStyle CssClass="Grid_Detail" />
											<HeaderStyle CssClass="Grid_Head" />
											<FooterStyle CssClass="Grid_Footer" />
											<Columns>
												<asp:TemplateColumn HeaderText="勾選">
										            <HeaderStyle Width="30px" />
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:CheckBox ID="dwg_check" runat="server" CausesValidation="False" Checked='<%# this.uf_Check_List(DataBinder.Eval(Container, "DataItem.hmf102_trainid")) %>' />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hmf102_trainid" HeaderText="訓練代號" SortExpression="hmf102_trainid"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="課程">
													<ItemTemplate>
														<asp:Label ID="dwG_hmf102_courseid" runat="server" Text='<%# uf_Dg_Bind("hmf101", DataBinder.Eval(Container, "DataItem.hmf102_courseid")) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hmf102_teacher" HeaderText="授課講師" SortExpression="hmf102_teacher"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="訓練班日期">
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:Label ID="dwG_hmf102_date" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmf102_sdate"), false) + "~" + DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmf102_edate"), false)%>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
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
