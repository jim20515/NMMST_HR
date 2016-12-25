<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>自訂錯誤頁</title>
	<link href="proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<table border="0" cellpadding="0" cellspacing="0" style="height: 100%" width="100%">
			<tr align="center">
				<td valign="middle">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td align="center">
								<table border="0" cellpadding="4" cellspacing="0">
									<tr>
										<td>
											<asp:Literal ID="litr_Msg" runat="server"></asp:Literal>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
    </form>
</body>
</html>
