<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0401_02.aspx.cs" Inherits="sys_f_f04_p_f0401_02" %>

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
                                <td style="height: 35px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="160px" Style="position: relative; left: 1px; top: 2px; background-color: transparent;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" Style="z-index: 101; left: 38px; position: absolute; top: 26px" Width="674px" ForeColor="Gray">潮間帶認證：需曾通過以下訓練：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Gray" Style="z-index: 101; left: 69px; position: absolute; top: 47px; text-align: left" Width="646px" Height="69px"></asp:Label>
                                        <asp:Label ID="Label16" runat="server" CssClass="D" ForeColor="Purple" Style="z-index: 101; left: 7px; position: absolute; top: 6px">◎認證名稱：</asp:Label>
                                        <asp:Label ID="dwF_hmf401_appid_t" runat="server" CssClass="N" Style="z-index: 99; left: 4px; position: absolute; top: 130px" Width="100px">核定文號：</asp:Label>
                                        <asp:TextBox ID="dwF_hmf401_appid" runat="server" CssClass="G" Style="z-index: 100; left: 104px; position: absolute; top: 127px" Width="200px"></asp:TextBox>
                                        <asp:Button ID="Bt_Conf" CssClass="Bt_Conf" runat="server" Style="z-index: 100; left: 372px; position: absolute; top: 123px" Text="" OnClick="Bt_Conf_Click" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                    <asp:LinkButton ID="lb_all" runat="server" Style="position: relative; left: 26px;" CssClass="G" OnClick="lb_all_Click">全選</asp:LinkButton>
                                    <asp:LinkButton ID="lb_unall" runat="server" Style="position: relative; left: 27px;" CssClass="G" OnClick="lb_unall_Click">全不選</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="250px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="785px">
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
                                                        <asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_bookid" HeaderText="志工手冊編號" SortExpression="hmd201_bookid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_ssn" HeaderText="身分證字號"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hmd201_tid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
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
