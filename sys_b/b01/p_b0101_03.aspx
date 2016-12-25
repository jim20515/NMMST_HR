<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_b0101_03.aspx.cs" Inherits="sys_b_b01_p_b0101_03" %>

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
                                <td>
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="200px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_type_t" runat="server" ForeColor="Purple" Style="left: 28px; position: absolute; top: 26px" Text="◎選擇格式：" CssClass="Q"></asp:Label>
                                        <asp:Label ID="dwQ_format_t" runat="server" ForeColor="Purple" Style="left: 292px; position: absolute; top: 26px" Text="◎選擇格式：" CssClass="Q"></asp:Label>
                                        <asp:RadioButtonList ID="dwQ_type" runat="server" Style="left: 110px; position: absolute; top: 19px" Height="131px">
                                            <asp:ListItem Value="1">電子郵件清單</asp:ListItem>
                                            <asp:ListItem Value="2">電話號碼清單</asp:ListItem>
                                            <asp:ListItem Value="3">地址條清單</asp:ListItem>
                                            <asp:ListItem Value="4">聯絡簿清單</asp:ListItem>
											<asp:ListItem Value="5">地址標籤</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;
                                        <asp:DropDownList ID="dwQ_format" runat="server" Style="left: 374px; position: absolute; top: 23px">
                                            <asp:ListItem Value="Excel">Excel</asp:ListItem>
                                            <asp:ListItem>Pdf</asp:ListItem>
                                            <asp:ListItem Value="HTML4.0">HTML</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="Bt_Export" runat="server" CssClass="Bt_Export" Style="z-index: 103; left: 557px; position: absolute; top: 19px" Text="" Width="80px" OnClick="Bt_Export_Click" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
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
