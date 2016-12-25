<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0201.aspx.cs" Inherits="sys_g_g01_p_g0201" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                <td style="position: relative; height: 50px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="left: 1px; position: relative; top: 2px" Width="800px">
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 114; left: 496px; position: absolute; top: 5px" OnClick="bt_Query_Click" />
                                        <asp:Label ID="dwQ_year_t" runat="server" CssClass="N" Style="z-index: 101; left: 43px; position: absolute; top: 12px" Width="62px">年度：</asp:Label>
                                        <asp:TextBox ID="dwQ_year" runat="server" Style="left: 105px; position: absolute; top: 9px" Width="56px"></asp:TextBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 2px;">
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="◎符合申請二級海科榮譽獎：(年資3年且實務時數600小時以上)" Style="position: relative; left: 26px; top: -4px;" ForeColor="Purple"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="120px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="780px" TabIndex="1">
                                            <SelectedItemStyle CssClass="Grid_Select" />
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
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="getvyear" HeaderText="年資" SortExpression="getvyear">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="onduty" HeaderText="時數" SortExpression="onduty">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 30px;">
                                    <asp:Label ID="Label2" runat="server" Text="◎符合申請一級海科榮譽獎：(年資5年且實務時數1000小時以上)" Style="position: relative; left: 29px; top: 12px;" ForeColor="Purple"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="">
                                    <witc:ScrollGrid ID="dwG1" runat="server" CssClass="Grid" Height="120px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG1" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="780px" TabIndex="1">
                                            <SelectedItemStyle CssClass="Grid_Select" />
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
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="getvyear" HeaderText="年資" SortExpression="getvyear">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="onduty" HeaderText="時數" SortExpression="onduty">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 50px;">
                                    <asp:Label ID="Label3" runat="server" Text="◎符合申請特級海科榮譽獎：(年資10年且實務時數1800小時以上)" Style="position: relative; left: 26px; top: 10px;" ForeColor="Purple"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="Purple" Style="left: -346px; position: relative; top: 31px" Text="◎PS：當年尚須全勤服務獎"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="">
                                    <witc:ScrollGrid ID="dwG2" runat="server" CssClass="Grid" Height="120px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG2" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="780px" TabIndex="1">
                                            <SelectedItemStyle CssClass="Grid_Select" />
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
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="getvyear" HeaderText="年資" SortExpression="getvyear">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="onduty" HeaderText="時數" SortExpression="onduty">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px;">
                                    &nbsp;<asp:Button ID="Bt_Print" runat="server" CssClass="Bt_Print" OnClick="Bt_Print_Click" Style="left: 323px; position: relative; top: 0px" /></td>
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
