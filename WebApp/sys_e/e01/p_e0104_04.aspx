<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0104_04.aspx.cs" Inherits="sys_e_e01_p_e0104_04" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>編輯名單</title>
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
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="150px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_hme101b_note" runat="server" ForeColor="Gray" Style="left: 86px; position: absolute; top: 24px; text-align: left" Height="52px" Width="728px"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_time_c" runat="server" ForeColor="Gray" Style="left: 86px; position: absolute; top: 84px; text-align: left"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_addtext" runat="server" ForeColor="Gray" Style="left: 86px; position: absolute; top: 104px; text-align: left"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="dwF_hme101b_needno_c" runat="server" ForeColor="Red" Style="left: 86px; position: absolute; top: 125px; text-align: left"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_note_t" runat="server" ForeColor="Gray" Style="left: 11px; position: absolute; top: 24px; text-align: right" Text="工作說明：" Width="70px" CssClass="I" Height="16px"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_time_c_t" runat="server" ForeColor="Gray" Style="left: 11px; position: absolute; top: 86px; text-align: right" Text="時間：" Width="70px" CssClass="I" Height="16px"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_addtext_t" runat="server" ForeColor="Gray" Style="left: 11px; position: absolute; top: 106px; text-align: right" Text="報到地點：" Width="70px" CssClass="I"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_needno_t" runat="server" ForeColor="Gray" Style="left: 11px; position: absolute; top: 127px; text-align: right" Text="需要人數：" Width="70px" CssClass="I" Height="16px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_tid_c_t" runat="server" ForeColor="Gray" Style="left: 11px; position: absolute; top: 5px; text-align: right" Text="志工隊：" Width="70px" CssClass="I" Height="16px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_tid_c" runat="server" ForeColor="Gray" Style="left: 86px; position: absolute; top: 5px; text-align: left"></asp:Label>
                                        &nbsp;
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:DWPanel ID="dwS" runat="server" CssClass="Form" Height="300px" Style="position: relative" Width="820px">
                                        <asp:Label ID="Label6" runat="server" ForeColor="Purple" Height="19px" Style="left: 30px; position: relative; top: 10px">◎名單</asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Height="19px" Style="left: 118px; position: relative; top: 18px">所有隊員</asp:Label>
                                        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Height="19px" Style="left: 411px; position: relative; top: 18px">名單</asp:Label>
                                        <asp:Button ID="bt_toright" runat="server" Style="left: 316px; position: absolute; top: 76px" Width="80px" OnClick="bt_toright_Click" CssClass="Bt_ToRight" />
                                        <asp:Button ID="bt_toleft" runat="server" Style="left: 316px; position: absolute; top: 142px" Width="80px" OnClick="bt_toleft_Click" CssClass="Bt_ToLeft" />
                                        <asp:Button ID="bt_toreset" runat="server" Style="left: 316px; position: absolute; top: 210px" Width="80px" OnClick="bt_toreset_Click" CssClass="Bt_ToReset" />
                                        <asp:ListBox ID="lb_all" runat="server" Height="247px" Style="left: 84px; position: absolute; top: 40px" Width="223px">
                                        </asp:ListBox>
                                        <asp:ListBox ID="lb_go" runat="server" Height="247px" Style="left: 412px; position: absolute; top: 40px" Width="223px">
                                        </asp:ListBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 15px">
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="bt_confirm" runat="server" Style="position: relative; left: 317px;" Width="80px" OnClick="bt_confirm_Click" CssClass="Bt_Conf" /></asp:Panel>
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
