<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0203_01.aspx.cs" Inherits="sys_g_g02_p_g0203_01" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="80px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hlg203_vid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">志工姓名：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="dwQ_hlg203_metalname_t" runat="server" CssClass="Q" Style="z-index: 104; left: 250px; position: absolute; top: 12px" Width="100px">獎項名稱：</asp:Label>
                                        &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:DropDownList ID="dwQ_hlg203_metalname" runat="server" Style="z-index: 115; left: 350px; position: absolute; top: 9px" Width="108px" CssClass="B" AutoPostBack="True" OnSelectedIndexChanged="dwQ_hlg203_metalname_SelectedIndexChanged">
                                            <asp:ListItem Value="">《全部》</asp:ListItem>
                                            <asp:ListItem>全勤獎</asp:ListItem>
                                            <asp:ListItem>服務獎</asp:ListItem>
                                            <asp:ListItem>一級海科獎</asp:ListItem>
                                            <asp:ListItem>二級海科獎</asp:ListItem>
                                            <asp:ListItem>三級海科獎</asp:ListItem>
                                            <asp:ListItem>其他</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList ID="dwQ_hlg203_vid" runat="server" Style="z-index: 120; left: 104px; position: absolute; top: 9px" Width="118px" CssClass="B" DataMember="hmd201">
                                        </asp:DropDownList>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 35px" Text="" Width="80px" />
                                        <asp:TextBox ID="dwQ_hlg203_metalname_s" runat="server" CssClass="G" Style="z-index: 238; left: 470px; position: absolute; top: 9px" Width="241px" Visible="False"></asp:TextBox>
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hlg203_kid" DataMember="hlg203" DataSource="<%# indb_hlg203.dv_View %>" Width="800px">
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
                                                <asp:TemplateColumn HeaderText="志工手冊編號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_bookid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201_book" , DataBinder.Eval(Container, "DataItem.hlg203_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="志工姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_cname_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201" , DataBinder.Eval(Container, "DataItem.hlg203_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hlg203_metalname" HeaderText="獎項名稱" SortExpression="hlg203_metalname"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="得獎日期">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_dm_run_edt" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hlg203_mdate"), false) %>'>
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
