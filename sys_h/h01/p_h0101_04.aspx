<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0101_04.aspx.cs" Inherits="sys_h_h01_p_h0101_04" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="60px" Style="position: relative" Width="620px">
                                        <asp:Label ID="dwQ_hmc101_cname_t" Style="z-index: 100; left: 254px; position: absolute; top: 13px" runat="server" Width="90px" CssClass="Q">姓名：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_ssn_t" runat="server" CssClass="Q" Style="z-index: 100; left: 254px; position: absolute; top: 38px" Width="90px">身分證字號：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_tid_t" Style="z-index: 101; left: 19px; position: absolute; top: 38px" runat="server" Width="76px" CssClass="Q">志工隊：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_deptid_t" Style="z-index: 102; left: 19px; position: absolute; top: 13px" runat="server" Width="76px" CssClass="Q">部門：</asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="dwQ_hmc101_cname" runat="server" CssClass="G" Style="z-index: 104; left: 344px; position: absolute; top: 10px" Width="134px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmc101_ssn" runat="server" CssClass="G" Style="z-index: 104; left: 344px; position: absolute; top: 35px" Width="134px"></asp:TextBox>
                                        <asp:DropDownList ID="dwQ_hmc101_tid" Style="z-index: 100; left: 95px; position: absolute; top: 35px" runat="server" DataMember="hmd101">
                                        </asp:DropDownList><asp:DropDownList ID="dwQ_hmc101_deptid" Style="z-index: 100; left: 95px; position: absolute; top: 10px" runat="server" DataMember="hca202">
                                        </asp:DropDownList>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 505px; position: absolute; top: 17px" Text="" Width="80px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                    <asp:LinkButton ID="lb_all" runat="server" CssClass="G" OnClick="lb_all_Click" Style="left: 26px; position: relative">全選</asp:LinkButton>
                                    <asp:LinkButton ID="lb_unall" runat="server" CssClass="G" OnClick="lb_unall_Click" Style="left: 31px; position: relative">全不選</asp:LinkButton>
                                    <asp:Label ID="show_t" Style="left: 51px; position: relative" runat="server" CssClass="N">※ 查詢清單只列出已填寫行動電話的人員清單 </asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="290px" Width="620px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmc101_id" DataMember="hmc101" DataSource="<%# indb_hmc101.dv_View %>" Width="592px">
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
                                                        <asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmc101_cname")) %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_id" HeaderText="編號"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmc101_cname" HeaderText="姓名"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmc101_phnom" HeaderText="行動電話"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px">
                                    <asp:Button ID="Bt_Conf" CssCLASS="Bt_Conf" runat="server" Style="left: 256px; position: relative; top: 0px" Text="" OnClick="Bt_Conf_Click" />
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
