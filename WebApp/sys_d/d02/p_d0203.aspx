<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0203.aspx.cs" Inherits="sys_d_d02_p_d0203" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
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
                                <td>
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="Bt_SendMessage" CssClass="Bt_Conf" runat="server" Style="left: 359px; position: absolute; top: 4px" Text="" OnClick="Bt_SendMessage_Click" />
                                        <asp:Button ID="bt_delete" CssClass="Bt_Del" runat="server" Style="left: 453px; position: absolute; top: 4px" Text="" OnClick="bt_delete_Click" />
                                        <asp:Label ID="dwF_hmd201_tid_t" runat="server" CssClass="N" Style="z-index: 101; left: 102px; position: absolute; top: 11px" Width="80px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwF_hmd201_tid" runat="server" CssClass="B" DataMember="hmd101" Style="left: 184px; position: absolute; top: 8px">
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                    <asp:LinkButton ID="lb_all" runat="server" Style="position: relative; left: 26px;" CssClass="G" OnClick="lb_all_Click">全選</asp:LinkButton>
                                    <asp:LinkButton ID="lb_unall" runat="server" Style="position: relative; left: 27px;" CssClass="G" OnClick="lb_unall_Click">全不選</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="360px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_no" DataMember="hmd201_t" DataSource="<%# indb_hmd201_t.dv_View %>" Width="785px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="勾選">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmd201_SSN")) %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd201_SSN" HeaderText="身分證字號" SortExpression="hmd201_SSN">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="性別">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_gent_c" runat="server" Text='<%# uf_Dg_Bind( dwF_show.Items , DataBinder.Eval(Container, "DataItem.hmd201_gent")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="生日">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_bday_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hmd201_bday") , false) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="教育程度">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_eduid_c" runat="server" Text='<%# uf_Dg_Bind( "hca203" , DataBinder.Eval(Container, "DataItem.hmd201_eduid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="欲加入志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_tid_c" runat="server" Text='<%# d02Project.uf_ShowTids( DataBinder.Eval(Container, "DataItem.hmd201_tid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px">
                                    <%--<asp:Button ID="Bt_SendMessage" CssClass="Bt_Conf" runat="server" Style="position: relative; left: 354px; top: 0px;" Text="" OnClick="Bt_SendMessage_Click" />--%>
                                    <asp:DropDownList ID="dwF_show" Style="left: 569px; position: absolute; top: 8px" runat="server" Visible="False">
                                        <asp:ListItem Value="M">男</asp:ListItem>
                                        <asp:ListItem Value="F">女</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
							<tr>
								<td >
									<asp:Button ID="dwF_report2" runat="server" CssClass="Bt_Print" OnClick="dwF_report2_Click" Style="left: 312px; position: relative; top: 1px" Width="80px" /></td>
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
