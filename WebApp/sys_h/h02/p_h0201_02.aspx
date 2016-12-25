<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0201_02.aspx.cs" Inherits="sys_h_h02_p_h0201_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="77px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hmh201a_picurl_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">賀卡種類：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmh201a_picurl" runat="server" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px" CssClass="B" DataMember="hmh200">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmh201a_stitle_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 12px" Width="100px">賀卡標題：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmh201a_stitle" CssClass="G" runat="server" Style="z-index: 105; left: 508px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 38px" Text="" Width="80px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmh201a_cid" DataMember="hmh201a" DataSource="<%# indb_hmh201a.dv_View %>" Width="790px">
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
                                                <asp:BoundColumn DataField="hmh201a_cid" HeaderText="賀卡寄件代碼" SortExpression="hmh201a_cid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="賀卡種類">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmh201a_picurl" runat="server" Text='<%# uf_Dg_Bind("hmh200", DataBinder.Eval(Container, "DataItem.hmh201a_picurl")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="發送人員">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "user01" , DataBinder.Eval(Container, "DataItem.hmh201a_uid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="發送時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_pcount_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hmh201a_udt") , true) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="收件人">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_c" runat="server" Text='<%# uf_cutNum(DataBinder.Eval(Container, "DataItem.hmh201a_mlist")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmh201a_stitle" HeaderText="賀卡標題" SortExpression="hmh201a_stitle"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="賀卡內容">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_1c" runat="server" Text='<%# uf_cut(DataBinder.Eval(Container, "DataItem.hmh201a_scontent")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
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
