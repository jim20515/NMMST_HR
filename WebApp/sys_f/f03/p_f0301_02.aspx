<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0301_02.aspx.cs" Inherits="sys_f_f03_p_f0301_02" %>

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
                                <td style="height: 8px">
                                    <asp:Label ID="dwS_show" runat="server" Text="※" Style="position: relative; left: 0px; top: 0px;" ForeColor="Purple" Font-Size="14pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmf302_vid" HeaderText="志工代碼" SortExpression="hmf302_vid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmf302_vid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201" , DataBinder.Eval(Container, "DataItem.hmf302_vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="成績">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dwG_hmf302_score" runat="server" Style="text-align: right;" Text='<%# DataBinder.Eval(Container, "DataItem.hmf302_score") %>' Visible='<%# uf_get_visible( DataBinder.Eval(Container, "DataItem.hmf302_vid")) %>' Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                
                                                <asp:TemplateColumn HeaderText="是否通過">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="dwG_hmf302_passed" runat="server" Checked='<%# uf_Dg_BindBool("Y", DataBinder.Eval(Container, "DataItem.hmf302_passed")) %>'  Style="text-align: right;" Width="50px">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                
                                                <asp:TemplateColumn HeaderText="備註">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dwG_hmf302_ps" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hmf302_ps") %>' Width="200px" >
                                                        </asp:TextBox>
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
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                    <asp:Button ID="Bt_Conf" runat="server" CssClass="Bt_Conf" Style="position: relative; left: 347px; top: 0px;" Text="" Width="80px" OnClick="bt_Conf_Click" />
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
