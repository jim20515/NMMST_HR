<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_SuperQuery.aspx.cs" Inherits="proj_right_p_SuperQuery" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>動態語法查詢</title>
	<link href="../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Panel ID="pn_Contain" runat="server" Height="420px" Style="z-index: 101; left: 20px; position: absolute; top: 20px" Width="780px">
			<iframe frameborder="0" height="0" name="downloadFrame" scrolling="no" src="" width="100%"></iframe>
			<table border="0" cellpadding="0" cellspacing="0" class="G" style="z-index: 101; left: 8px; position: absolute; top: 8px">
				<tr style="padding-bottom: 8px" valign="top">
					<td>
						<table border="0" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px; border-collapse: collapse">
							<tr>
								<td class="Frame_SysImg" valign="middle"><img alt="" align="absMiddle" src="../proj_img/Funcname.gif" /></td>
								<td class="Frame_SysName" valign="middle">動態語法查詢</td>
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
							<asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 105; left: 636px; position: absolute; top: 112px" Text="查詢" Width="56px" OnClick="bt_Query_Click" />
							<asp:Button ID="bt_Export" runat="server" CssClass="B" Style="z-index: 106; left: 696px; position: absolute; top: 112px" Text="匯出" Width="56px" OnClick="bt_Export_Click" />
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
						<witc:DWPanel ID="dwG" runat="server" AJAXScript="Yes" CssClass="Grid" Height="200px" Visible="False" Width="760px" ScrollBar="automatic">
							<asp:DataGrid id="dgG" runat="server" Width="740px" CssClass="Grid">
								<SelectedItemStyle CssClass="Grid_Select"></SelectedItemStyle>
								<ItemStyle Wrap="False" CssClass="Grid_Detail"></ItemStyle>
								<HeaderStyle Wrap="False" CssClass="Grid_Head"></HeaderStyle>
								<FooterStyle Wrap="False" CssClass="Grid_Footer"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="dwG_seq_c" tabIndex="-1" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' CausesValidation="False" CommandName="Select">
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
