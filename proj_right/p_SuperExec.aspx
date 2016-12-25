<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_SuperExec.aspx.cs" Inherits="proj_right_p_SuperExec" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>動態語法執行</title>
	<link href="../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Panel ID="pn_Contain" runat="server" Height="420px" Style="z-index: 101; left: 20px; position: absolute; top: 20px" Width="780px">
			<table border="0" cellpadding="0" cellspacing="0" class="G" style="z-index: 101; left: 8px; position: absolute; top: 8px">
				<tr style="padding-bottom: 8px" valign="top">
					<td>
						<table border="0" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px; border-collapse: collapse">
							<tr>
								<td class="Frame_SysImg" valign="middle"><img alt="" align="absMiddle" src="../proj_img/Funcname.gif" /></td>
								<td class="Frame_SysName" valign="middle">動態語法執行</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="padding-bottom: 8px" valign="top">
					<td>
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="144px" Style="position: relative" Width="760px">
							<asp:Label ID="dwQ_sql_t" runat="server" CssClass="N" Style="z-index: 101; left: 4px; position: absolute; top: 12px" Width="80px">執行語法：</asp:Label>
							<asp:TextBox ID="dwQ_sql" runat="server" CssClass="G" Height="100px" Style="z-index: 102; left: 88px; position: absolute; top: 8px" TextMode="MultiLine" Width="664px"></asp:TextBox>
							<asp:Label ID="dwQ_pwd_t" runat="server" CssClass="N" Style="z-index: 103; left: 4px; position: absolute; top: 116px" Width="80px">執行密碼：</asp:Label>
							<asp:TextBox ID="dwQ_pwd" runat="server" CssClass="G" Style="z-index: 104; left: 88px; position: absolute; top: 112px" Width="160px"></asp:TextBox>
							<asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 105; left: 696px; position: absolute; top: 112px" Text="執行" Width="56px" OnClick="bt_Query_Click" />
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td>
						<div class="RT">注意：請考量語法執行的時間，不要造成系統癱瘓！</div>
					</td>
				</tr>
				<tr style="padding-bottom: 20px" valign="top">
					<td>
						<witc:DWPanel ID="dwG" runat="server" CssClass="Grid" Height="200px" Visible="False" Width="760px" AJAXScript="Yes" ScrollBar="automatic">
							<asp:DataGrid ID="dgG" runat="server" CssClass="Grid" Width="740px">
								<SelectedItemStyle CssClass="Grid_Select" />
								<ItemStyle CssClass="Grid_Detail" Wrap="False" />
								<HeaderStyle CssClass="Grid_Head" Wrap="False" />
								<FooterStyle CssClass="Grid_Footer" Wrap="False" />
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
											</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</witc:DWPanel>
					</td>
				</tr>
			</table>
		</asp:Panel>
	</div>
    </form>
</body>
</html>
