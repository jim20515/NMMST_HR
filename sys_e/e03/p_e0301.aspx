<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0301.aspx.cs" Inherits="sys_e_e03_p_e0301" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查詢及清單</title>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="70px" Style="position: relative" Width="820px">
                                        &nbsp;
                                        <asp:Label ID="dwQ_hmd201_vid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 13px" Width="100px">志工代碼：</asp:Label>
                                        <asp:Label ID="dwQ_hmd201_tid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 42px" Width="100px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmd201_tid" runat="server" CssClass="G" DataMember="hmd101" Style="left: 104px; position: absolute; top: 39px">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmd201_cname_t" runat="server" CssClass="Q" Style="z-index: 99; left: 377px; position: absolute; top: 13px" Width="100px">志工姓名：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmd201_vid" runat="server" CssClass="G" Style="z-index: 100; left: 104px; position: absolute; top: 10px" Width="161px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmd201_cname" CssClass="G" runat="server" Style="z-index: 100; left: 479px; position: absolute; top: 10px" Width="163px"></asp:TextBox>
                                        &nbsp; &nbsp;
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 717px; position: absolute; top: 19px" Text="" Width="80px" />
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
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="300px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="795px">
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
                                                        <%--<asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>' />--%>
                                                        <asp:CheckBox ID="dwg_check" runat="server" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd201_bookid" HeaderText="志工手冊編號" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_tid_c" runat="server" Text='<%# uf_Dg_Bind( dwQ_hmd201_tid.Items , DataBinder.Eval(Container, "DataItem.hmd201_tid")) %>'>
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
                                    <asp:Button ID="bt_print" runat="server" CssClass="Bt_Print" Style="position: relative; left: 361px; top: -2px;" Text="" Width="80px" OnClick="bt_print_Click" />
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
