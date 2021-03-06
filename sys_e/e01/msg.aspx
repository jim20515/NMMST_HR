﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="msg.aspx.cs" Inherits="sys_e_e01_msg" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>專案計劃</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    </script>

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
                                <td style="height: 64px; width: 607px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="146px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="463px">
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_ybar_t" runat="server" CssClass="I" Style="z-index: 105;
                                            left: 80px; position: absolute; top: 23px; font-size: 18pt; text-align: center;" Width="299px">確定轉正式班表嗎</asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Button ID="Button3" runat="server" Style="z-index: 123; left: 148px; position: absolute;
                                            top: 82px" Text="確定" Width="70px" />
                                        <asp:Button ID="Button1" runat="server" Style="z-index: 123; left: 228px; position: absolute;
                                            top: 82px" Text="取消" Width="70px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td style="height: 5px; width: 607px;">
                                </td>
                            </tr>
--%>
                            <%--                           <tr>
                                <td style="height: 120px; width: 607px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="108px" Style="position: relative;
                                        left: 1px; top: 4px;" Width="599px">
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_ybar_t" runat="server" CssClass="N" Style="z-index: 105;
                                            left: 6px; position: absolute; top: 8px" Width="100px">預算年度：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="dwF_ema11_ybar" runat="server" CssClass="G" Style="z-index: 108;
                                            left: 109px; position: absolute; top: 5px" Width="80px"></asp:TextBox>
                                        &nbsp;
                                        <asp:Label ID="dwF_ema11_ec01code_t" runat="server" CssClass="N" Style="z-index: 109;
                                            left: 241px; position: absolute; top: 8px" Width="100px">工程科目：</asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_code_amt_t" runat="server" CssClass="N" Style="z-index: 113;
                                            left: 6px; position: absolute; top: 36px" Width="100px">預算金額：</asp:Label>
                                        &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="dwF_ema11_code_amt" runat="server" CssClass="G" MaxLength="100"
                                            Style="z-index: 118; left: 109px; position: absolute; top: 33px" Width="80px"></asp:TextBox>
                                        <asp:Label ID="dwF_aec01_user_t" runat="server" CssClass="D" Style="z-index: 123;
                                            left: 5px; position: absolute; top: 86px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_ema11_user" runat="server" CssClass="G" Style="z-index: 124; left: 109px;
                                            position: absolute; top: 86px"></asp:Label>
                                        <asp:Label ID="dwF_aec01_date_t" runat="server" CssClass="D" Style="z-index: 125;
                                            left: 261px; position: absolute; top: 86px" Width="80px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_ema11_date" runat="server" CssClass="G" Style="z-index: 126; left: 345px;
                                            position: absolute; top: 86px"></asp:Label>
                                        <asp:Label ID="dwF_ema11_ec03code_t" runat="server" CssClass="N" Style="z-index: 113;
                                            left: 241px; position: absolute; top: 36px" Width="100px">資金來源：</asp:Label>
                                        <asp:DropDownList ID="dwF_ema11_ec01code" runat="server" Style="z-index: 108; left: 345px;
                                            position: absolute; top: 5px" CssClass="D" DataMember="aec01" Width="172px">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_ema11_ec03code" runat="server" Style="z-index: 108; left: 345px;
                                            position: absolute; top: 33px" CssClass="D" DataMember="aec03" Width="172px">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_aema11_ec03code_ps_t" runat="server" CssClass="D" Style="z-index: 123;
                                            left: 195px; position: absolute; top: 36px" Width="17px">元</asp:Label>
                                        <asp:Label ID="total_t" runat="server" CssClass="D" Style="z-index: 123; left: 11px;
                                            position: absolute; top: 60px" Width="95px">該年度總金額：</asp:Label>
                                    </witc:DWPanel>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="height: 4px; width: 607px;">
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="position: relative; height: 9px; width: 607px;">
                                    <div style="position: relative; float: right; left: 0px; top: 0px;" id="DIV1" onclick="return DIV1_onclick()">
                                        <uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="height: 4px; width: 607px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 607px">
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
