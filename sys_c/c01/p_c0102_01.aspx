<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0102_01.aspx.cs" Inherits="sys_c_c01_p_c0102_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
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
                                <td style="height: 4px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px;">
                                    <%--                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="600px" Width="800px" AJAXScript="Yes">
--%>
                                    <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataMember="hmc102_g8" DataSource="<%# indb_hmc102_g8.dv_View %>" Width="770px" OnItemCommand="dgG_ItemCommand">
                                        <FooterStyle CssClass="Grid_Footer" />
                                        <SelectedItemStyle CssClass="Grid_Select" />
                                        <ItemStyle CssClass="Grid_Detail" />
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="第1層">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="cb_g2" runat="server" CausesValidation="False" CommandName="lb_g2" TabIndex="-1" Text='<%# uf_get_name(DataBinder.Eval(Container, "DataItem.G2")) %>' Visible='<%# uf_visible(DataBinder.Eval(Container, "DataItem.G2"),"G2" , DataBinder.Eval(Container, "ItemIndex")) %>' Enabled='<%# uf_get_enable(DataBinder.Eval(Container, "DataItem.G2")) %>' ></asp:LinkButton>
                                                    <asp:Label ID="lb_g2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.G2") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="第2層">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="cb_g3" runat="server" CausesValidation="False" CommandName="lb_g3" TabIndex="-1" Text='<%# uf_get_name(DataBinder.Eval(Container, "DataItem.G3")) %>' Visible='<%# uf_visible(DataBinder.Eval(Container, "DataItem.G3"),"G3" , DataBinder.Eval(Container, "ItemIndex")) %>' Enabled='<%# uf_get_enable(DataBinder.Eval(Container, "DataItem.G3")) %>' ></asp:LinkButton>
                                                    <asp:Label ID="lb_g3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.G3") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="第3層">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="cb_g4" runat="server" CausesValidation="False" CommandName="lb_g4" TabIndex="-1" Text='<%# uf_get_name(DataBinder.Eval(Container, "DataItem.G4")) %>' Visible='<%# uf_visible(DataBinder.Eval(Container, "DataItem.G4"),"G4" , DataBinder.Eval(Container, "ItemIndex")) %>' Enabled='<%# uf_get_enable(DataBinder.Eval(Container, "DataItem.G4")) %>' ></asp:LinkButton>
                                                    <asp:Label ID="lb_g4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.G4") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="第4層">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="cb_g5" runat="server" CausesValidation="False" CommandName="lb_g5" TabIndex="-1" Text='<%# uf_get_name(DataBinder.Eval(Container, "DataItem.G5")) %>' Visible='<%# uf_visible(DataBinder.Eval(Container, "DataItem.G5"),"G5" , DataBinder.Eval(Container, "ItemIndex")) %>' Enabled='<%# uf_get_enable(DataBinder.Eval(Container, "DataItem.G5")) %>' ></asp:LinkButton>
                                                    <asp:Label ID="lb_g5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.G5") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="第5層">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="cb_g6" runat="server" CausesValidation="False" CommandName="lb_g6" TabIndex="-1" Text='<%# uf_get_name(DataBinder.Eval(Container, "DataItem.G6")) %>' Visible='<%# uf_visible(DataBinder.Eval(Container, "DataItem.G6"),"G6" , DataBinder.Eval(Container, "ItemIndex")) %>' Enabled='<%# uf_get_enable(DataBinder.Eval(Container, "DataItem.G6")) %>' ></asp:LinkButton>
                                                    <asp:Label ID="lb_g6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.G6") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <HeaderStyle CssClass="Grid_Head" />
                                    </asp:DataGrid>
                                    <%--                                    </witc:ScrollGrid>
--%>
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
