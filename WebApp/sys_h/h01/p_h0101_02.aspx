<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0101_02.aspx.cs" Inherits="sys_h_h01_p_h0101_02" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="36px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hlh101_tolist_t" runat="server" CssClass="Q" Style="z-index: 101; left: 35px; position: absolute; top: 11px">收件者門號：</asp:Label>
                                        <asp:TextBox ID="dwQ_hlh101_tolist" runat="server" Style="left: 118px; position: absolute; top: 8px" Width="142px"></asp:TextBox>
                                        &nbsp;
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 728px; position: absolute; top: 4px" Text="" Width="80px" />
                                        <asp:Label ID="dwQ_hlh101_adt_t" runat="server" CssClass="Q" Style="z-index: 101; left: 330px; position: absolute; top: 11px" Width="80px">發送日期：</asp:Label>
                                        <asp:Panel ID="dwF_hme101b_sdate" runat="server" CssClass="G" Style="z-index: 109; left: 553px; position: absolute; top: 10px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        <asp:Label ID="dwF_hme101b_edate_t" runat="server" CssClass="I" Style="z-index: 101; left: 504px; position: absolute; top: 11px" Width="19px">～</asp:Label>
                                        <asp:Panel ID="dwQ_hlh101_adt" runat="server" CssClass="G" Style="z-index: 109; left: 412px; position: absolute; top: 8px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
                                        </asp:Panel>
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hlh101_logid" DataMember="hlh101" DataSource="<%# indb_hlh101.dv_View %>" Width="794px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_s_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="檢視">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='檢視'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="發送人員">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "user01" , DataBinder.Eval(Container, "DataItem.hlh101_uid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="發送時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_pcount_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hlh101_udt") , true) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="收件人">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_c" runat="server" Text='<%# uf_cutNum(DataBinder.Eval(Container, "DataItem.hlh101_ToList")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="簡訊內容">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_1c" runat="server" Text='<%# uf_cut(DataBinder.Eval(Container, "DataItem.hlh101_Message")) %>'>
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
