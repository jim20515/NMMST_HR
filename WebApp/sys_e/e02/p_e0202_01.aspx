<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0202_01.aspx.cs" Inherits="sys_e_e02_p_e0202_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>批次匯入</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:Panel ID="pn_Contain" runat="server">
				<table class="G">
					<tr>
						<td>
							<br />
							<span class="RH">步驟一：請下載服勤刷卡紀錄批次匯入格式 Excel 檔案範本。</span>
							<br />
							<br />
							<asp:Button ID="bt_Download" runat="server" CssClass="B" Height="22px" OnClick="bt_Download_Click" Text="下載" Width="52px" />
							<span class="RI">&nbsp;(version 1.0)</span>
							<br />
							<iframe frameborder="0" height="0" name="downloadFrame" scrolling="no" src="" width="100%"></iframe>
						</td>
					</tr>
					<tr>
						<td>
							<br />
							<hr class="G" />
							<br />
							<span class="RH">步驟二：依照 Excel 檔案的工作表「匯入資料格式說明」將資料輸入到工作表「服勤刷卡紀錄批次匯入資料」中，</span>
							<br />
							<span class="RH">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;輸入完成後請儲存。（其中必要輸入欄位請確實輸入）</span>
							<br />
						</td>
					</tr>
					<tr>
						<td>
							<br />
							<hr class="G" />
							<br />
							<span class="RH">步驟三：輸入以下欄位資料，《瀏覽》步驟二儲存之 Excel 檔案並按下《匯入》。</span>
							<br />
							<span class="RH">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;（系統會將 Excel 檔案中所列之基本資料儲存至資料庫《服勤刷卡紀錄》中）</span>
							<br />
							<table class="G" style="margin-left: 4px">
								<tr style="height: 20px" valign="top">
									<td>
										<span class="N" style="background-color: #d6e2fd; color: Maroon; font-size: 12pt">匯入檔案&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
									</td>
									<td>
										<asp:FileUpload ID="dwU_filepath" runat="server" BackColor="#ffffdd" CssClass="G" Width="360" />
										<asp:Button ID="bt_Upload" runat="server" Height="22px" OnClick="bt_Upload_Click" Text="匯入" Width="52px" />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<br />
							<asp:GridView ID="dgG" runat="server" BorderColor="#5D7B9D" BorderStyle="Double" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="None">
								<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
								<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
								<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
								<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
								<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
								<EditRowStyle BackColor="#999999" />
								<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
							</asp:GridView>
						</td>
					</tr>
				</table>
			</asp:Panel>
		</div>
	</form>
	<asp:Literal ID="litr_Body" runat="server"></asp:Literal>

	<script language="JavaScript" src="j_e0202_01.js" type="text/javascript"></script>

</body>
</html>
