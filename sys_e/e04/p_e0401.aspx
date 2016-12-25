<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0401.aspx.cs" Inherits="sys_e_e04_p_e0401" %>

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
                                <td>
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="50px" Style="position: relative" Width="820px">
                                        <asp:Label Style="z-index: 101; left: 24px; position: absolute; top: 18px" ID="dwQ_ym_t" runat="server" Width="80px" CssClass="N">查詢年月：</asp:Label>
                                        <asp:Label Style="z-index: 101; left: 159px; position: absolute; top: 18px" ID="dwQ_year_t" runat="server" Width="18px" CssClass="Q">年</asp:Label>
                                        <asp:Label Style="z-index: 101; left: 229px; position: absolute; top: 18px" ID="dwQ_month_t" runat="server" Width="18px" CssClass="Q">月</asp:Label>
                                        <asp:TextBox Style="left: 106px; position: absolute; top: 15px" ID="dwQ_year" runat="server" Width="42px"></asp:TextBox>
                                        <asp:TextBox Style="left: 184px; position: absolute; top: 15px" ID="dwQ_month" runat="server" Width="33px"></asp:TextBox>
										<asp:Label ID="dwQ_yme_t" runat="server" CssClass="N" Style="z-index: 101; left: 252px; position: absolute; top: 18px" Width="13px">～</asp:Label>
										<asp:Label ID="dwQ_yeare_t" runat="server" CssClass="Q" Style="z-index: 101; left: 320px; position: absolute; top: 18px" Width="18px">年</asp:Label>
										<asp:Label ID="dwQ_monthe_t" runat="server" CssClass="Q" Style="z-index: 101; left: 390px; position: absolute; top: 18px" Width="18px">月</asp:Label>
										<asp:TextBox ID="dwQ_yeare" runat="server" Style="left: 267px; position: absolute; top: 15px" Width="42px"></asp:TextBox>
										<asp:TextBox ID="dwQ_monthe" runat="server" Style="left: 345px; position: absolute; top: 15px" Width="33px"></asp:TextBox>
                                        <asp:Button Style="z-index: 999; left: 417px; position: absolute; top: 10px" ID="bt_Query" OnClick="bt_Query_Click" runat="server" Width="80px" CssClass="Bt_Search" Text=""></asp:Button>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="300px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="795px">
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
                                                <asp:BoundColumn DataField="vid" HeaderText="志工代碼" SortExpression="vid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工手冊編號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_bookid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201_book" , DataBinder.Eval(Container, "DataItem.vid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="vname" HeaderText="志工姓名" SortExpression="vname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="foodCT" HeaderText="誤餐次數" SortExpression="foodCT"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="foodMoney" HeaderText="誤餐費用" SortExpression="foodMoney"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px">
                                    <asp:Button ID="bt_print" runat="server" CssClass="Bt_Print" Style="position: relative; left: 361px; top: -2px;" Text="" Width="80px" OnClick="bt_print_Click" />
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
