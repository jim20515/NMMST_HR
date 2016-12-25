<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="p_Login" %>

<%@ Register TagPrefix="uc1" TagName="u_Notice" Src="proj_right/u_Notice.ascx" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>國立海洋科技博物館-人力資源系統</title>
	<link href="proj_css/s_GeneralStyle.css" type="text/css" rel="stylesheet" />
<script language="javascript" type="text/javascript">

</script>
</head>
<body class="Frame">
	<form id="form1" runat="server">
	<div>
	<!-- 整頁區域 Start -->
	<table cellspacing="0" cellpadding="0" width="100%" style="height: 100%" border="0">
		<tr align="center">
			<td valign="middle">
				<table cellspacing="0" cellpadding="0" width="100%" border="0">
					<tr>
						<td align="center">
							<div style="width: 400px">
								<uc1:u_Notice ID="u_NoticeItem" runat="server" />
							</div>
						</td>
					</tr>
					<tr>
						<!-- 白色線區域 Start
						<td align="center" bgcolor="#ffffff"><img height="1px" src="proj_img/free.gif" width="5px"></td> -->
					</tr>
					<tr>
						<!-- 淺藍色區域 -->
						<td align="center">
							<!-- 深藍色區域 Start -->
							<table cellspacing="0" cellpadding="4" width="400" style="background-color: #4b53b4" border="0">
								<tr>
									<td style="width: 464px">
										<!-- 中間區域 Start -->
										<table cellspacing="0" cellpadding="0" width="400" border="0" id="TABLE1" onclick="return TABLE1_onclick()">
											<tr>
												<td align="center" style="background-color: #d6e2fd"><img alt="" src="proj_img/Logo.gif" /></td>
											</tr>
											<tr>
												<td style="height: 1px"></td>
											</tr>
											<tr>
												<td style="padding-bottom: 5px; padding-top: 10px; background-color: #eff7ff" align="center">
													<table width="100%">
														<tr>
															<td valign="middle" align="center">
																<witc:dwpanel id="dwF" style="position: relative; left: 0px; top: 0px;" runat="server" Width="100%" Height="96px">
                                                                    &nbsp;
																	<div class="I" style="display: inline; font-size: 16px; z-index: 102; left: 48px; width: 100px; position: absolute; top: 16px">
                                                                        Login：</div>
																	<asp:textbox id="dwF_UserID" style="z-index: 103; left: 152px; position: absolute; top: 16px" runat="server" Width="120px" CssClass="G" MaxLength="10"></asp:textbox>
																	<div class="I" style="display: inline; font-size: 16px; z-index: 104; left: 48px; width: 100px; position: absolute; top: 40px">
                                                                        Password：</div>
																	<asp:textbox id="dwF_UserPwd" style="z-index: 105; left: 152px; position: absolute; top: 40px" runat="server" Width="120px" CssClass="G" TextMode="Password" MaxLength="20"></asp:textbox>
																	<asp:CheckBox id="cbx_SaveID" style="z-index: 106; left: 280px; position: absolute; top: 16px" runat="server" CssClass="G" Text="記住帳號" Width="104px"></asp:CheckBox>
																	<asp:LinkButton id="lbt_SendPwd" style="z-index: 107; left: 320px; position: absolute; top: 64px" runat="server" CssClass="D" OnClick="lbt_SendPwd_Click">忘記密碼？</asp:LinkButton>
																	<asp:button id="bt_Login" style="z-index: 108; left: 144px; position: absolute; top: 72px" runat="server" Width="120px" Text="登入" OnClick="bt_Login_Click" CssClass="B"></asp:button>
																</witc:dwpanel>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
										<!-- 中間區域 End -->
									</td>
								</tr>
							</table>
							<!-- 深藍色區域 End -->
						</td>
						<!-- 淺藍色區域 End -->
					</tr>
					<tr>
						<!-- 白色線區域 Start 
						<td align="center" bgcolor="#ffffff"><IMG height="1px" src="proj_img/free.gif" width="5px"></td>-->
					</tr>
				</table>
			</td>
		</tr>
		<tr valign="bottom">
			<td align="center">
				<span class="RG" style="font-size: 11px">Copyright &copy 2008 <span style="color: #4169e1">World Information Technology</span> All Rights Reserved 最佳瀏覽效果 800x600 (小字型)，IE6.0以上版本</span>
			</td>
		</tr>
	</table>
    <!-- 整頁區域 End -->
	</div>
	</form>
</body>
</html>
