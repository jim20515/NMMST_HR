<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0103_01.aspx.cs" Inherits="sys_g_g01_p_g0103_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="103px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hmg101a_ktype_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">考核類別：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmg101a_ktype" runat="server" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px" CssClass="B">
                                            <asp:ListItem Value="">《全部》</asp:ListItem>
                                            <asp:ListItem Value="1">實習志工考核</asp:ListItem>
                                            <asp:ListItem Value="2">正式志工季考核</asp:ListItem>
                                            <asp:ListItem Value="3">正式志工年考核</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmg101a_syear_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 12px" Width="100px">年度：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmg101a_syear" runat="server" Style="z-index: 105; left: 508px; position: absolute; top: 8px" Width="200px" CssClass="B" DataMember="YY_dc">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmg101a_sseason_t" runat="server" CssClass="Q" Style="z-index: 109; left: 4px; position: absolute; top: 38px" Width="100px">季：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmg101a_sseason" runat="server" Style="z-index: 110; left: 104px; position: absolute; top: 34px" Width="200px" CssClass="B">
                                            <asp:ListItem Value="">《全部》</asp:ListItem>
                                            <asp:ListItem Value="0">-</asp:ListItem>
                                            <asp:ListItem Value="1">第一季</asp:ListItem>
                                            <asp:ListItem Value="2">第二季</asp:ListItem>
                                            <asp:ListItem Value="3">第三季</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmg101a_name_t" runat="server" CssClass="Q" Style="z-index: 114; left: 408px; position: absolute; top: 38px" Width="100px">考核名稱：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmg101a_name" CssClass="G" runat="server" Style="z-index: 115; left: 508px; position: absolute; top: 34px" Width="200px"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 64px" Text="" Width="80px" />
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmg101a_kid" DataMember="hmg101a" DataSource="<%# indb_hmg101a.dv_View %>" Width="800px">
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
                                                <asp:BoundColumn DataField="hmg101a_kid" HeaderText="考核基本檔ID" SortExpression="hmg101a_kid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="考核類別">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmg101a_ktype" runat="server" Text='<%# uf_Dg_Bind(dwQ_hmg101a_ktype.Items, DataBinder.Eval(Container, "DataItem.hmg101a_ktype"))  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmg101a_syear" HeaderText="年度" SortExpression="hmg101a_syear"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="季">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmg101a_sseason" runat="server" Text='<%# uf_Dg_Bind(dwQ_hmg101a_sseason.Items, DataBinder.Eval(Container, "DataItem.hmg101a_sseason"))  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmg101a_name" HeaderText="考核名稱" SortExpression="hmg101a_name"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="考核人數">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmg101a_pcount" runat="server" Text='<%# uf_PCount(DataBinder.Eval(Container, "DataItem.hmg101a_kid"))  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                 <asp:TemplateColumn HeaderText="考核狀況">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmg101a_status" runat="server" Text='<%# uf_PStatus(DataBinder.Eval(Container, "DataItem.hmg101a_kid"))  %>'></asp:Label>
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
