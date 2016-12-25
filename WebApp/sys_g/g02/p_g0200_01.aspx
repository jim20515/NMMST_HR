<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0200_01.aspx.cs" Inherits="sys_g_g01_p_g0200_01" %>

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
                                        <asp:Label ID="dwQ_year_t" runat="server" CssClass="N" Style="z-index: 101; left: 35px; position: absolute; top: 12px" Width="62px">年度：</asp:Label>
                                        <asp:TextBox ID="dwQ_year" runat="server" Style="left: 97px; position: absolute; top: 9px" Width="56px"></asp:TextBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 2px;">
                                    <asp:Label ID="Label1" runat="server" Text="◎符合可申請志工全勤獎志工" Style="position: relative; left: 0px; top: 2px;" ForeColor="Purple"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="200px" Width="800px" AJAXScript="Yes">
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
                                                <asp:BoundColumn DataField="hmd101_tname" HeaderText="組別" SortExpression="hmd101_tname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="dutyhour" HeaderText="應服勤時數" SortExpression="dutyhour"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="onduty" HeaderText="實際服勤時數" SortExpression="onduty"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px;">
                                    &nbsp;<asp:Button ID="Bt_Print" runat="server" CssClass="Bt_Print" OnClick="Bt_Print_Click" Style="left: 331px; position: relative; top: 0px" /></td>
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
