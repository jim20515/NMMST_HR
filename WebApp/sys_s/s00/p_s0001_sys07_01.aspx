<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0001_sys07_01.aspx.cs" Inherits="sys_s_s00_p_s0001_sys07_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect.ascx" TagName="u_DateSelect" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最新公告</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <asp:Panel ID="pn_Contain" runat="server">
                <table class="G">
                    <tr>
                        <td>
                            <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="85px" Style="position: relative" Width="600px">
                                <asp:Label ID="dwF_s07_fname_t" Style="z-index: 103; left: 24px; position: absolute; top: 49px" runat="server" Width="71px" CssClass="N">檔案名稱：</asp:Label>
                                <asp:Label ID="dwF_msg_t" runat="server" CssClass="RI" Style="z-index: 103; left: 31px; position: absolute; top: 15px"></asp:Label>
                                <input id="dwF_s07_fname" style="z-index: 104; left: 99px; position: absolute; top: 45px" type="file" size="55" name="dwF_s07_fname" runat="server" />
                                <asp:Button ID="bt_Upload" Style="z-index: 105; left: 530px; position: absolute; top: 45px" runat="server" Width="56px" Text="上傳" Font-Size="10pt" BorderStyle="Outset" BorderWidth="1px" OnClick="bt_Upload_Click"></asp:Button>
                            </witc:DWPanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                    </tr>
                    <tr>
                        <td style="position: relative">
                            <div class="RI" style="display: inline; position: absolute; top: 4px">
                                ★ 注意：不可於同一公告重覆上傳同名稱附件。</div>
                            <div style="position: relative; float: right">
                                <asp:Button ID="bt_back" runat="server" CssClass="B" Text="回上一頁" OnClick="bt_back_Click"></asp:Button>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="200px" Width="600px" AJAXScript="Yes">
                                <asp:DataGrid ID="dgG" runat="server" Width="580px" CssClass="Grid" DataKeyField="s071_sno" AutoGenerateColumns="False" DataSource="<%# indb_sys071.dv_View %>" OnDeleteCommand="dgG_DeleteCommand">
                                    <SelectedItemStyle CssClass="Grid_Select"></SelectedItemStyle>
                                    <ItemStyle CssClass="Grid_Detail"></ItemStyle>
                                    <HeaderStyle CssClass="Grid_Head"></HeaderStyle>
                                    <FooterStyle CssClass="Grid_Footer"></FooterStyle>
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="序號">
                                            <HeaderStyle Width="30px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="dwG_seq_c" TabIndex="-1" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="刪除">
                                            <HeaderStyle Width="40px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Button ID="dwG_Delete" runat="server" CssClass="B" Text="刪除" CommandName="Delete"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="檔案名稱">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="dwG_s071_fname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s071_fname") %>' Target="_blank" NavigateUrl='<%# this.Request.ApplicationPath + "/app_file/sys07/" + DataBinder.Eval(Container, "DataItem.s071_s07_no").ToString().Trim() + "/" + DataBinder.Eval(Container, "DataItem.s071_fname").ToString() %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="420px" />
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
    </form>
</body>
</html>--%>
