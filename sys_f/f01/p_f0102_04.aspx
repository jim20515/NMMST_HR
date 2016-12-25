<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0102_04.aspx.cs" Inherits="sys_f_f01_p_f0102_04" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_TimeSelect.ascx" TagName="u_TimeSelect" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>訓練班時間設定</title>
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
									<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="163px" Style="position: relative; left: 0px; top: 0px;" Width="820px">
										<asp:Label ID="dwF_hmf102a_trainid_t" runat="server" CssClass="D" Style="z-index: 117; left: 18px; position: absolute; top: 6px" Width="80px">訓練班名稱：</asp:Label>
										<asp:Label ID="dwF_hmf102a_trainid" runat="server" CssClass="G" Style="z-index: 108; left: 99px; position: absolute; top: 5px" Width="120px"></asp:Label>
										<asp:Label ID="dwF_hmf102a_trainid_c" runat="server" CssClass="G" Style="z-index: 108; left: 219px; position: absolute; top: 5px" ></asp:Label>
										<asp:Label ID="dwF_hmf102a_seq_t" runat="server" CssClass="D" Style="z-index: 117; left: 520px; position: absolute; top: 6px" Width="80px">序號：</asp:Label>
										<asp:Label ID="dwF_hmf102a_seq" runat="server" CssClass="G" Style="z-index: 117; left: 604px; position: absolute; top: 6px" Width="111px"></asp:Label>
										<asp:Label ID="dwF_hmf102a_date_t" runat="server" CssClass="N" Style="z-index: 117; left: -4px; position: absolute; top: 30px" Width="104px">訓練班日期：</asp:Label>
										<asp:Panel ID="dwF_hmf102a_date" runat="server" CssClass="G" Style="z-index: 109; left: 99px; position: absolute; top: 28px" Width="132px">
											<uc1:u_DateSelect_ROC ID="u_hmf102a_date" runat="server" />
										</asp:Panel>
										<asp:Label ID="dwF_hmf102a_stime_t" runat="server" CssClass="N" Style="z-index: 117; left: 21px; position: absolute; top: 57px" Width="80px">開始時間：</asp:Label>
										<asp:Panel ID="dwF_hmf102a_stime" runat="server" CssClass="G" Style="z-index: 122; left: 102px; position: absolute; top: 54px" Width="110px">
											<uc1:u_TimeSelect ID="u_Time1" runat="server">
											</uc1:u_TimeSelect>
										</asp:Panel>
										<asp:Label ID="dwF_hmf102a_etime_t" runat="server" CssClass="N" Style="z-index: 117; left: 21px; position: absolute; top: 87px" Width="80px">結束時間：</asp:Label>
										<asp:Panel ID="dwF_hmf102a_etime" runat="server" CssClass="G" Style="z-index: 122; left: 102px; position: absolute; top: 84px" Width="132px">
											<uc1:u_TimeSelect ID="u_Time2" runat="server">
											</uc1:u_TimeSelect>
										</asp:Panel>
										<asp:Label ID="dwF_hmf102a_aid_t" runat="server" CssClass="D" Style="z-index: 117; left: 22px; position: absolute; top: 114px" Width="80px">新增人員：</asp:Label>
										<asp:Label ID="dwF_hmf102a_aid" runat="server" CssClass="G" Style="z-index: 117; left: 103px; position: absolute; top: 114px" Width="128px"></asp:Label>
										<asp:Label ID="dwF_hmf102a_adt_t" runat="server" CssClass="D" Style="z-index: 117; left: 519px; position: absolute; top: 114px" Width="80px">新增時間：</asp:Label>
										<asp:Label ID="dwF_hmf102a_adt" runat="server" CssClass="G" Style="z-index: 117; left: 603px; position: absolute; top: 114px" Width="111px"></asp:Label>
										<asp:Label ID="dwF_hmf102a_uid_t" runat="server" CssClass="D" Style="z-index: 117; left: 23px; position: absolute; top: 138px" Width="80px">異動人員：</asp:Label>
										<asp:Label ID="dwF_hmf102a_uid" runat="server" CssClass="G" Style="z-index: 117; left: 104px; position: absolute; top: 138px" Width="128px"></asp:Label>
										<asp:Label ID="dwF_hmf102a_udt_t" runat="server" CssClass="D" Style="z-index: 117; left: 520px; position: absolute; top: 138px" Width="80px">異動時間：</asp:Label>
										<asp:Label ID="dwF_hmf102a_udt" runat="server" CssClass="G" Style="z-index: 117; left: 604px; position: absolute; top: 138px" Width="111px"></asp:Label>
									</witc:DWPanel>
								</td>
							</tr>
							<tr>
								<td>
									<div style="position: relative; float: right; left: 0px; top: 0px;">
										<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
									</div>
								</td>
							</tr>
							<tr>
								<td style="height: 4px; width: 823px;">
								</td>
							</tr>
							<tr>
								<td style="width: 823px; height: 215px">
									<witc:ScrollGrid ID="dwG" runat="server" AJAXScript="Yes" CssClass="Grid" Height="200px" Width="820px">
										<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataMember="hmf102a" DataSource="<%# indb_hmf102a.dv_View %>" Width="800px">
											<SelectedItemStyle CssClass="Grid_Select" />
											<ItemStyle CssClass="Grid_Detail" />
											<HeaderStyle CssClass="Grid_Head" />
											<FooterStyle CssClass="Grid_Footer" />
											<Columns>
												<asp:TemplateColumn HeaderText="項次">
													<HeaderStyle Width="30px" />
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="訓練班日期">
													<ItemStyle HorizontalAlign="Center" />
													<ItemTemplate>
														<asp:Label ID="dwG_hmf102a_date" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmf102a_date"), false) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="hmf102a_stime" HeaderText="開始時間" ></asp:BoundColumn>
												<asp:BoundColumn DataField="hmf102a_etime" HeaderText="結束時間"></asp:BoundColumn>
											</Columns>
										</asp:DataGrid>
									</witc:ScrollGrid>
								</td>
							</tr>
							<tr>
								<td style="height: 4px; width: 823px;">
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
