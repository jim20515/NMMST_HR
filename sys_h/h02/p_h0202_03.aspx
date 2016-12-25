<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0202_03.aspx.cs" Inherits="sys_h_h02_p_h0202_03" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名單與寄送</title>
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
                                <td style="height: 181px; width: 604px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="375px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 249px; position: absolute; top: 8px; font-size: 25pt;" Width="274px" ForeColor="Blue">新春賀喜 牛轉乾坤</asp:Label>
                                        &nbsp; &nbsp; &nbsp;
                                        &nbsp;&nbsp;
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="332px" TabIndex="1" style="left: 376px; position: absolute; top: 86px" Height="98px">
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="姓名" HeaderText="姓名" SortExpression="姓名"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="email" HeaderText="email" SortExpression="email"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                        &nbsp;&nbsp;
                                        <img id="IMG1" src="../../proj_img/card.jpg" style="left: 69px; width: 205px; position: absolute; top: 65px; height: 259px; border-top-style: solid; border-right-style: solid; border-left-style: solid; border-bottom-style: solid;" />
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/proj_img/ButtonImg/BEditNList_w.gif" Style="left: 425px; position: absolute; top: 262px" />
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/proj_img/ButtonImg/BConf_w.gif" Style="left: 558px; position: absolute; top: 262px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; width: 604px;">
                                 
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 604px;">
                                        &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 604px;">
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
