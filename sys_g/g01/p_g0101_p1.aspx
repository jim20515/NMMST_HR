﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0101_p1.aspx.cs" Inherits="sys_g_g01_p_g0101_p1" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
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
                                <td style="height: 35px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 11px" Width="80px" ForeColor="Blue">考核類別：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 237px; position: absolute; top: 11px" Width="47px">年度：</asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 364px; position: absolute; top: 11px" Width="47px">季：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 8px" Text="查詢" Width="56px" />
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 284px; position: absolute;
                                            top: 8px" Width="56px"></asp:TextBox>
                                        &nbsp;
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="left: 90px; position: absolute;
                                            top: 8px" Width="103px">
                                            <asp:ListItem>實習志工</asp:ListItem>
                                            <asp:ListItem Selected="True">志工季考核</asp:ListItem>
                                            <asp:ListItem>志工年度考核</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList2" runat="server" Style="left: 411px; position: absolute;
                                            top: 8px" Width="35px">
                                            <asp:ListItem Selected="True">1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 83px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="150px" Style="position: relative;
                                        left: 0px; top: 0px;" Width="800px">
                                        <br />
                                        <br />
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 14px; position: absolute; top: 7px">考核主檔代碼： C097_0001</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 59px; position: absolute; top: 31px">*年度：</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 58px">*考核類別：</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 255px; position: absolute; top: 58px">季：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 85px">*考核名稱：</asp:Label>
                                        &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 107px; position: absolute;
                                            top: 82px" Width="421px">97年度海科館志工第1季考核</asp:TextBox>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 107px; position: absolute;
                                            top: 28px" Width="46px">097</asp:TextBox>
                                        <asp:DropDownList ID="DropDownList5" runat="server" Style="left: 281px; position: absolute;
                                            top: 55px" Width="35px">
                                            <asp:ListItem Selected="True">1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList3" runat="server" Style="left: 104px; position: absolute;
                                            top: 55px">
                                            <asp:ListItem>實習志工</asp:ListItem>
                                            <asp:ListItem Selected="True">志工季考核</asp:ListItem>
                                            <asp:ListItem>志工年度考核</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: absolute; left: 152px;
                                            top: 117px;" Text="應考核名單編輯" Width="137px" CausesValidation="False" OnClientClick="uf_SelectFrame(2)" />
                                        <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: absolute; left: 296px;
                                            top: 116px;" Text="確定" Width="55px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 605px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="100px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1">
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
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="名稱" HeaderText="名稱" SortExpression="名稱"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="年度" HeaderText="年度" SortExpression="年度">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="季" HeaderText="季" SortExpression="季">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="考核類別" HeaderText="考核類別" SortExpression="考核類別"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="狀況" HeaderText="狀況" SortExpression="狀況"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 605px;">
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
