<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0202_02.aspx.cs" Inherits="sys_h_h02_p_h0202_03" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>自訂</title>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="276px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 67px; position: absolute; top: 193px; font-size: large;" Width="133px" ForeColor="Blue">基本格式檔下載</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="font-size: large; z-index: 101; left: 67px; position: absolute; top: 231px" Width="133px">自訂模組上傳：</asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp;&nbsp;
                                        <img id="IMG1" style="left: 66px; width: 683px; position: absolute; top: 11px; height: 167px; border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid;" />
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/proj_img/ButtonImg/BSave_w(1).gif" Style="left: 207px; position: absolute; top: 191px" />
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/proj_img/ButtonImg/BBrowser_w.gif" Style="left: 362px; position: absolute; top: 227px" CssClass="Bt_Browser" OnClientClick="uf_SelectFrame(3)" />
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 204px; position: absolute; top: 231px"></asp:TextBox>
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
