<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0105_01.aspx.cs" Inherits="sys_e_e01_p_e0105_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="36px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hme105a_tid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 432px; position: absolute; top: 11px" Width="80px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hme105a_tid" runat="server" Style="left: 514px; position: absolute; top: 8px" CssClass="B" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hm105a_name_t" runat="server" CssClass="Q" Style="z-index: 101; left: 73px; position: absolute; top: 11px" Width="80px">樣板名稱：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="dwQ_hm105a_name" runat="server" Style="left: 155px; position: absolute; top: 8px" Width="222px"></asp:TextBox>
                                        &nbsp;
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 728px; position: absolute; top: 4px" Text="" Width="80px" />
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme105a_ssid" DataMember="hme105a" DataSource="<%# indb_hme105a.dv_View %>" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hme105a_name" HeaderText="樣版名稱" SortExpression="hme105a_name"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hme105a_tid" HeaderText="志工隊代碼" SortExpression="hme105a_tid" Visible="false"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme105a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hme105a_tid")) %>'>
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
