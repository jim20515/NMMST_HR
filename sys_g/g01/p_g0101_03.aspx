<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0101_03.aspx.cs" Inherits="sys_g_g01_p_g0101_03" %>

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
                                        <asp:Button ID="Bt_SendMessage" CssClass="Bt_Conf" runat="server" Style="left: 543px; position: absolute; top: 4px" Text="" OnClick="Bt_SendMessage_Click" />
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwQ_hmd101_tid_t" runat="server" CssClass="G" Style="z-index: 101; left: 67px; position: absolute; top: 13px">請選擇欲考核資料！</asp:Label>
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="785px">
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
                                                        <asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼" SortExpression="hmd201_vid" ></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname" ></asp:BoundColumn>
                                               <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hmd201_tid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="志工階級">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_lvid_c" runat="server" Text='<%# uf_Dg_Bind( "hca206" , DataBinder.Eval(Container, "DataItem.hmd201_lvid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
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
