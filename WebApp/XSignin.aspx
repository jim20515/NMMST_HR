<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XSignin.aspx.cs" Inherits="XSignin" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>國立海洋科技博物館 - 志工教育訓練刷卡系統</title>
	<link href="proj_css/s_GeneralStyle.css" type="text/css" rel="stylesheet" />
	<script language="JavaScript" src="j_XSignin.js" type="text/javascript"></script>
	<style type="text/css">
		INPUT.B1 {cursor: hand; font-size: 30pt; height: 72px; width: 50%; color: #400000; background-color: #ffd9ec; border-width: 4px; letter-spacing: 0.5em;}
		INPUT.B2 {cursor: hand; font-size: 30pt; height: 72px; width: 50%; color: #004000; background-color: #e2ffc6; border-width: 4px; letter-spacing: 0.5em;}
		DIV.V1   {padding: 20px; font-size: 20pt; width: 100%; height: 100%; color: #400000; background-color: #ffd9ec; border-width: 4px; border-color: black; border-style: dashed; border-bottom-style: none; padding-bottom: 0px; padding-top: 0px; font-family:微軟正黑體}
		DIV.V2   {padding: 20px; font-size: 20pt; width: 100%; height: 100%; color: #004000; background-color: #e2ffc6; border-width: 4px; border-color: black; border-style: dashed; border-bottom-style: none; padding-bottom: 0px; padding-top: 0px; font-family:微軟正黑體}
		INPUT.TG {font-size: 20pt; width: 90%}
	</style>
</head>

<body class="Frame">
	<form id="form1" runat="server">

	<asp:ScriptManager ID="ScriptManager1" runat="server" />

	<div>
	<!-- 整頁區域 Start -->
	<table cellspacing="0" cellpadding="0" width="100%" style="height: 100%" border="0">
		<tr align="center">
			<td valign="middle">
				<table cellspacing="0" cellpadding="0" width="100%" border="0">
					<tr>
						<!-- 白色線區域 Start
						<td align="center" bgcolor="#ffffff"><img height="1px" src="proj_img/free.gif" width="5px"></td> -->
					</tr>
					<tr>
						<!-- 淺橘色區域 -->
						<td align="center">
							<!-- 深橘色區域 Start -->
							<table cellspacing="0" cellpadding="4" width="800" style="background-color: #3030A0" border="0">
								<tr>
									<td style="width: 800px">
										<!-- 中間區域 Start -->
										<table cellspacing="0" cellpadding="0" width="790" border="0">
											<tr>
												<td align="right" style="background-color: #B0B0F0; background-image: url(proj_img/Sign.jpg); height: 150px; background-repeat: no-repeat">
													<table cellpadding="0" cellspacing="0" style="height: 100%" width="395">
														<tr>
															<td align="center">
																<asp:Label ID="lb_ShowDate" runat="server" Font-Bold="True" Font-Size="40pt" ForeColor="#3030A0" Text="0000/00/00"></asp:Label></td>
														</tr>
														<tr>
															<td align="center" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>  
																<asp:Label ID="lb_ShowTime" runat="server" Font-Bold="True" Font-Size="40pt" ForeColor="#3030A0" Text="00:00:00" Height="59px" Width="196px"></asp:Label>
                                                                <asp:Label ID="lb_realtime" runat="server" ForeColor="#F0F0FF" Style="z-index: 100;
                                                                    left: 0px; position: absolute; top: 0px" Width="0px"></asp:Label>
                                                                    </ContentTemplate> 
                                                                </asp:UpdatePanel> 
                                                            </td>
														</tr>
													</table>
                                                    <script language="javascript" type="text/javascript">uf_Timer1();</script>
												</td>
											</tr>

											<tr>
												<td align="right" style="background-color: #B0B0F0">
													<table cellpadding="0" cellspacing="0" style="height: 300px" width="790">
														<tr>
															<td valign="middle" align="center" style="background-color: #b0b0f0">
																<asp:Panel ID="dwS" runat="server" BackColor="#F5F5FF" Height="90%" Style="position: relative" Width="95%">
																	<table style="left: 0px; position: absolute; top: 0px; width: 100%; height: 188px">
																		<tr>
																			<td align="center" style="height: 40px; padding-top: 8px">
																				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
																					<ContentTemplate>
																				<div id="msg1" style="font-size: 30pt; font-weight: bold">
																					<asp:Literal ID="litr_ShowTitle" runat="server"></asp:Literal>
																				</div>
																					</ContentTemplate>
																				</asp:UpdatePanel>
																			</td>
																		</tr>
																		<tr>
																			<td align="center" valign="middle">
																				<table>
																					<tr>
																						<td>
																							<asp:UpdatePanel ID="UpdatePanel2" runat="server">
																								<ContentTemplate>
																							<div id="msg2" style="text-align: left; font-size: 20pt">
																								<asp:Literal ID="litr_ShowMsg" runat="server"></asp:Literal>
																							</div>
																								</ContentTemplate>
																							</asp:UpdatePanel>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</table>
																</asp:Panel>
																<ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExt" runat="server" Radius="50" TargetControlID="dwS" />
															</td>
															<td align="center" style="width: 394px" valign="middle">
																<asp:Panel ID="dwI" runat="server" Height="100%" Style="position: relative" Width="100%">
																	<div style="left: 0px; position: absolute; top: 0px; width: 100%; height: 230px">
																		<div id="view0" style="padding-top: 180px; width: 100%; height: 100%; background-color: #B0B0F0; font-size: 20pt; color: #3030A0; font-family:微軟正黑體">
																			<b>↓請先選擇《上班》或《下班》</b>
																		</div>
																		<div id="view1" class="V1" style="display: none" onclick="return view1_onclick()">
                                                                            歡迎！<br />
																			【刷<span style="color: blue; font-weight: bold">上班</span>卡】&nbsp;&nbsp;&nbsp;&nbsp; <img src="proj_img/checkin.png" alt="X" />
																			<asp:UpdatePanel ID="UpdatePanel3" runat="server">
																				<ContentTemplate>
																			<asp:TextBox ID="tbx_XSignin" runat="server" AutoPostBack="True" CssClass="TG" OnTextChanged="tbx_XSignin_TextChanged" TextMode="Password"></asp:TextBox>
																				</contenttemplate>
																			</asp:UpdatePanel>
																			<span style="color: Red; font-size: 10pt">** 刷卡時請注意游標是否在輸入框內 **</span>
																		</div>
																		<div id="view2" class="V2" style="display: none">
                                                                            辛苦了！<br />
																			【刷<span style="color: blue; font-weight: bold">下班</span>卡】&nbsp;&nbsp;&nbsp;&nbsp; <img src="proj_img/checkout.png" alt="X" />
																			<asp:UpdatePanel ID="UpdatePanel4" runat="server">
																				<ContentTemplate>
																			<asp:TextBox ID="tbx_SignOut" runat="server" AutoPostBack="True" CssClass="TG" OnTextChanged="tbx_SignOut_TextChanged" TextMode="Password"></asp:TextBox>
																				</ContentTemplate>
																			</asp:UpdatePanel>
																			<span style="color: Red; font-size: 10pt">** 刷卡時請注意游標是否在輸入框內 **</span>
																		</div>
																	</div>
																	<input id="bt_XSignin" accesskey="1" class="B1" onclick="uf_click(1);" style="left: 0px; position: absolute; top: 230px; font-family:微軟正黑體" tabindex="-1" type="button" value="上班" />
																	<input id="bt_SignOut" accesskey="2" class="B2" onclick="uf_click(2);" style="left: 197px; position: absolute; top: 230px; font-family:微軟正黑體" tabindex="-1" type="button" value="下班" />
																	<span onclick="uf_click(1);" style="cursor: hand; left: 150px; position: absolute; top: 280px; font-size: 8pt; color: Gray">(Alt+1)</span>
																	<span onclick="uf_click(2);" style="cursor: hand; left: 350px; position: absolute; top: 280px; font-size: 8pt; color: Gray">(Alt+2)</span>
																</asp:Panel>
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
							<!-- 深橘色區域 End -->
						</td>
						<!-- 淺橘色區域 End -->
					</tr>
					<tr>
						<!-- 白色線區域 Start 
						<td align="center" bgcolor="#ffffff"><IMG height="1px" src="proj_img/free.gif" width="5px"></td>-->
					</tr>
				</table>
			</td>
		</tr>
		<tr valign="bottom">
			<td align="center" style="height: 23px">
				<span class="RG" style="font-size: 8pt">Copyright &copy 2008 <span style="color: #4169e1">World Information Technology</span> All Rights Reserved 最佳瀏覽效果 800x600 (小字型)，IE6.0以上版本</span>
			</td>
		</tr>
	</table>
    <!-- 整頁區域 End -->
	</div>
    </form>
</body>
<script language="javascript" type="text/javascript">document.body.focus();function view1_onclick() {

}

</script>
</html>
