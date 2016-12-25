<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0501_02.aspx.cs" Inherits="sys_e_e05_p_e0501_02" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                                <td style="height: 8px">
                                    <asp:Label ID="dwS_show" runat="server" Text="※請選擇欲修改之志工隊及年度服勤資料" Style="position: relative; left: 36px;" ForeColor="Purple" Font-Size="14pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
							<tr>
								<td style="height: 8px">
									<asp:DropDownList ID="lb_all" runat="server" CssClass="G" Style="position: relative; left: 3px;">
										<asp:ListItem Value="1">服勤與訓練皆全部合格</asp:ListItem>
										<asp:ListItem Value="2">服勤全部合格</asp:ListItem>
										<asp:ListItem Value="3">訓練全部合格</asp:ListItem>
									</asp:DropDownList>
									<asp:Button ID="bt_Select" runat="server" CssClass="Bt_SearchQ" OnClick="bt_Select_Click" Style="position: relative; left: 6px; top: 0px;" Text="" Width="80px" />
								</td>
							</tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hle501_vid" HeaderText="志工代碼" SortExpression="hle501_vid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工手冊編號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_bookid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201_book" , DataBinder.Eval(Container, "DataItem.hle501_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="志工姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle501_vid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201" , DataBinder.Eval(Container, "DataItem.hle501_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="第一季服勤時數" Visible="false">
                                                    <ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_score1_c" runat="server" Enabled='<%# uf_get_EN("1") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_score1") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="第一季訓練時數" Visible="false">
													<ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_tscore1_c" runat="server" Enabled='<%# uf_get_EN("1") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_tscore1") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
													</ItemTemplate>
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="第二季服勤時數" Visible="false">
                                                    <ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_score2_c" runat="server" Enabled='<%# uf_get_EN("2") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_score2") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
                                                        <%--<asp:TextBox ID="dwG_hle501_score2_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_score2") %>' Style="text-align: right;" Width="50px" ReadOnly='<%# uf_get_RO("2") %>' BorderStyle='<%# uf_get_BS("2") %>'>
                                                        </asp:TextBox>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="第二季訓練時數" Visible="false">
													<ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_tscore2_c" runat="server" Enabled='<%# uf_get_EN("2") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_tscore2") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
														<%--<asp:TextBox ID="dwG_hle501_score2_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_score2") %>' Style="text-align: right;" Width="50px" ReadOnly='<%# uf_get_RO("2") %>' BorderStyle='<%# uf_get_BS("2") %>'>
                                                        </asp:TextBox>--%>
													</ItemTemplate>
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="第三季服勤時數" Visible="false">
                                                    <ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_score3_c" runat="server" Enabled='<%# uf_get_EN("3") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_score3") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
                                                        <%--<asp:TextBox ID="dwG_hle501_score3_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_score3") %>' Style="text-align: right;" Width="50px" ReadOnly='<%# uf_get_RO("3") %>' BorderStyle='<%# uf_get_BS("3") %>'>
                                                        </asp:TextBox>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="第三季訓練時數" Visible="false">
													<ItemTemplate>
														<asp:DropDownList ID="dwG_hle501_tscore3_c" runat="server" Enabled='<%# uf_get_EN("3") %>' SelectedValue='<%# DataBinder.Eval(Container, "DataItem.hle501_tscore3") %>'>
															<asp:ListItem Value="100">合格</asp:ListItem>
															<asp:ListItem Value="0">不合格</asp:ListItem>
														</asp:DropDownList>
														<%--<asp:TextBox ID="dwG_hle501_score3_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_score3") %>' Style="text-align: right;" Width="50px" ReadOnly='<%# uf_get_RO("3") %>' BorderStyle='<%# uf_get_BS("3") %>'>
                                                        </asp:TextBox>--%>
													</ItemTemplate>
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="全年度服勤表現" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dwG_hle501_score4_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_score4") %>' Style="text-align: right;" Width="50px" ReadOnly='<%# uf_get_RO("4") %>' BorderStyle='<%# uf_get_BS("4") %>'>
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="全年度訓練表現" Visible="false">
													<ItemTemplate>
														<asp:TextBox ID="dwG_hle501_tscore4_c" runat="server" BorderStyle='<%# uf_get_BS("4") %>' ReadOnly='<%# uf_get_RO("4") %>' Style="text-align: right;" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_tscore4") %>' Width="50px">
														</asp:TextBox>
													</ItemTemplate>
													<ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="備註">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dwG_hle501_ps_c" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hle501_ps") %>' Width="200px">
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                    <asp:Button ID="Bt_Conf" runat="server" CssClass="Bt_Conf" Style="position: relative; left: 347px; top: 0px;" Text="" Width="80px" OnClick="bt_Conf_Click" />
									<asp:Button ID="Bt_Print" runat="server" CssClass="Bt_Print" OnClick="Bt_Print_Click" Style="left: 346px; position: relative; top: 0px" /></td>
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
