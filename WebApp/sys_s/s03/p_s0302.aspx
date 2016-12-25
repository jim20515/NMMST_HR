<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0302.aspx.cs" Inherits="sys_s_s03_p_s0302" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="55px" Style="position: relative" Width="820px">
							<asp:Label ID="dwQ_UName_t" runat="server" CssClass="Q" Style="z-index: 99; left:4px; position: absolute; top:15px" Width="100px">操作者姓名：</asp:Label>
							<asp:TextBox ID="dwQ_UName" CssClass="G" runat="server" Style="z-index: 100; left:104px; position: absolute; top:12px" Width="150px"></asp:TextBox>
							<asp:Label ID="dwQ_LDate_t" runat="server" CssClass="Q" Style="z-index: 104; left:295px; position: absolute; top:15px" Width="100px">操作時間區間：</asp:Label>
							<asp:Panel ID="dwQ_LDate_s" runat="server" CssClass="G" Style="z-index: 99; left: 401px; position: absolute; top: 12px" Width="132px">
							    <uc1:u_DateSelect_ROC ID="u_Date1" runat="server"/>
						    </asp:Panel>
						    <asp:Label ID="Label1" runat="server" CssClass="Q" Style="z-index: 104; left:506px; position: absolute; top:16px" Width="20px">～</asp:Label>
							<asp:Panel ID="dwQ_LDate_e" runat="server" CssClass="G" Style="z-index: 99; left: 535px; position: absolute; top: 12px" Width="132px">
							    <uc1:u_DateSelect_ROC ID="u_Date2" runat="server"/>
						    </asp:Panel>
							<asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left:729px; position: absolute; top:12px" Text="" Width="80px" OnClick="bt_Query_Click"/>
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px" AJAXScript="Yes">
							<asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="800px" AllowSorting="True" OnSortCommand="dgG_SortCommand">
								<ItemStyle CssClass="Grid_Detail" />
								<HeaderStyle CssClass="Grid_Head" />
								<FooterStyle CssClass="Grid_Footer" />
								<SelectedItemStyle CssClass="Grid_Select" />
								<Columns>
									<asp:BoundColumn DataField="UID" HeaderText="操作帳號" SortExpression="UID"></asp:BoundColumn>
				                    <asp:BoundColumn DataField="UName" HeaderText="操作者姓名" SortExpression="UName"></asp:BoundColumn>
				                    <asp:BoundColumn DataField="LIP" HeaderText="操作者IP" SortExpression="LIP"></asp:BoundColumn>
				                    <asp:TemplateColumn HeaderText="操作時間" SortExpression="LDate">
										<ItemTemplate>
											<asp:Label ID="dwG_LDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LDate").ToString().Trim() == "" ? "" : DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.LDate"), true)  %>'></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
                                    <asp:BoundColumn DataField="PRG_DESC" HeaderText="操作記錄" SortExpression="PRG_DESC"></asp:BoundColumn>
				                    <asp:BoundColumn DataField="Keys" HeaderText="操作Key值" SortExpression="Keys"></asp:BoundColumn>
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
