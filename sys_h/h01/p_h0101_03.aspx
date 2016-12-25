<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0101_03.aspx.cs" Inherits="sys_h_h01_p_h0101_03" %>

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
                                <td style="width: 825px">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Query" Height="150px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_hlh101_uid_t" runat="server" CssClass="D" Style="z-index: 101; left: 35px; position: absolute; top: 11px" Width="80px">發送人員：</asp:Label>
                                        <asp:Label ID="dwF_hlh101_udt_t" runat="server" CssClass="D" Style="z-index: 101; left: 348px; position: absolute; top: 11px" Width="80px">發送時間：</asp:Label>
                                        <asp:Label ID="dwF_hlh101_udt" runat="server" CssClass="G" Style="z-index: 101; left: 431px; position: absolute; top: 11px"></asp:Label>
                                        <asp:Label ID="dwF_hlh101_ToList_t" runat="server" CssClass="D" Style="z-index: 101; left: 63px; position: absolute; top: 34px">收件人：</asp:Label>
                                        <asp:Label ID="dwF_hlh101_ToList" runat="server" CssClass="G" Height="41px" Style="z-index: 101; left: 118px; position: absolute; top: 34px" Width="693px"></asp:Label>
                                        <asp:Label ID="dwF_hlh101_Message_t" runat="server" CssClass="D" Style="z-index: 101; left: 50px; position: absolute; top: 83px">簡訊內容：</asp:Label>
                                        <asp:Label ID="dwF_hlh101_Message" runat="server" CssClass="G" Height="60px" Style="z-index: 101; left: 118px; position: absolute; top: 83px" Width="695px"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="dwF_hlh101_uid" runat="server" CssClass="G" Style="z-index: 101; left: 118px; position: absolute; top: 11px"></asp:Label>
                                        &nbsp; &nbsp; &nbsp;
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 825px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 825px">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hlh102_MessageID" DataMember="hlh102" DataSource="<%# indb_hlh102.dv_View %>" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_s_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="發送人員">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "user01" , DataBinder.Eval(Container, "DataItem.hlh102_uid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hlh102_cname" HeaderText="收件人" SortExpression="hlh102_cname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hlh102_to" HeaderText="接收電話" SortExpression="hlh102_to"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="發送時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_pcount_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hlh102_udt") , true) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hlh102_status" HeaderText="發送狀態" SortExpression="hlh102_status"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 825px;">
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
