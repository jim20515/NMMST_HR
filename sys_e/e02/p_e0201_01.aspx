<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0201_01.aspx.cs" Inherits="sys_e_e02_p_e0201_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�d�ߤβM��</title>
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
                                        <asp:Panel ID="dwQ_hle201_sdatetime_e" runat="server" CssClass="G" Style="z-index: 104; left: 249px; position: absolute; top: 6px" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
                                        </asp:Panel>
                                        <asp:Label ID="dwQ_hle201_vid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 41px" Width="100px">�Ӥu�N�X�G</asp:Label>
                                        <asp:Label ID="dwQ_hle201_tid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 377px; position: absolute; top: 10px" Width="100px">�Ӥu���G</asp:Label>
                                        <asp:DropDownList ID="dwQ_hle201_tid" runat="server" CssClass="G" DataMember="hmd101" Style="left: 479px; position: absolute; top: 7px">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hle201_vname_t" runat="server" CssClass="Q" Style="z-index: 99; left: 377px; position: absolute; top: 41px" Width="100px">�Ӥu�m�W�G</asp:Label>
                                        <asp:TextBox ID="dwQ_hle201_vid" runat="server" CssClass="G" Style="z-index: 100; left: 104px; position: absolute; top: 38px" Width="161px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hle201_vname" CssClass="G" runat="server" Style="z-index: 100; left: 479px; position: absolute; top: 38px" Width="163px"></asp:TextBox>
                                        <asp:Label ID="dwQ_hle201_sdatetime_s_t" runat="server" CssClass="Q" Style="z-index: 104; left: 4px; position: absolute; top: 10px" Width="100px">��d����G</asp:Label>
                                        <asp:Panel ID="dwQ_hle201_sdatetime_s" runat="server" CssClass="G" Style="z-index: 104; left: 104px; position: absolute; top: 6px" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        <asp:Label Style="z-index: 104; left: 214px; position: absolute; top: 10px" ID="dwQ_hle201_sdatetime_e_t" runat="server" Width="18px" CssClass="Q">��</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 36px" Text="" Width="80px" />
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hle201_lid" DataMember="hle201" DataSource="<%# indb_hle201.dv_View %>" Width="785px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="�Ǹ�">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <%--                  <asp:BoundColumn DataField="hle201_vid" HeaderText="�Ӥu�N�X" SortExpression="hle201_vid">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:BoundColumn>--%>
                                                <asp:TemplateColumn HeaderText="�Ӥu��U�s��">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_bookid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201_book" , DataBinder.Eval(Container, "DataItem.hle201_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="�Ӥu�m�W">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle201_vid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201" , DataBinder.Eval(Container, "DataItem.hle201_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="��d�ɶ�">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle201_sdatetime_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hle201_sdatetime"), false ) + " " + Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hle201_sdatetime")).ToString("HH:mm:ss") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="��d����">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle201_type_c" runat="server" Text='<%# uf_Dg_Bind( dwF_hle201_type.Items , DataBinder.Eval(Container, "DataItem.hle201_type")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="�O�_����">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle201_cancel_c" runat="server" Text='<%# uf_Dg_Bind( dwF_hle201_cancel.Items , DataBinder.Eval(Container, "DataItem.hle201_cancel")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="���ɤ覡">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hle201_cway_c" runat="server" Text='<%# uf_Dg_Bind( dwF_hle201_cway.Items , DataBinder.Eval(Container, "DataItem.hle201_cway")) %>'>
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
                                <td style="height: 8px">
                                    <asp:RadioButtonList ID="dwF_hle201_type" runat="server" RepeatDirection="Horizontal" Style="position: relative" Width="122px" Visible="False">
                                        <asp:ListItem Value="1">�W�Z</asp:ListItem>
                                        <asp:ListItem Value="2">�U�Z</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="dwF_hle201_cway" runat="server" RepeatDirection="Horizontal" Style="position: relative" Width="181px" Visible="False">
                                        <asp:ListItem Value="1">��d��</asp:ListItem>
                                        <asp:ListItem Value="2">��ʸɵn</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="dwF_hle201_cancel" runat="server" RepeatDirection="Horizontal" Style="position: relative" Width="122px" Visible="False">
                                        <asp:ListItem Value="Y">�O</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="N">�_</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
								<td align="center">
									<asp:Button ID="bt_Print" runat="server" CssClass="Bt_Print" OnClick="bt_Print_Click" />
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
