<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0105_02.aspx.cs" Inherits="sys_e_e01_p_e0105_02" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明細</title>
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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="100px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_hme105a_tid_t" runat="server" CssClass="N" Style="z-index: 101; left: 411px; position: absolute; top: 18px" Width="80px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwF_hme105a_tid" runat="server" Style="left: 493px; position: absolute; top: 15px" CssClass="G" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_hme105a_name_t" runat="server" CssClass="N" Style="z-index: 101; left: 41px; position: absolute; top: 18px" Width="80px">樣板名稱：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="dwF_hme105a_name" runat="server" Style="left: 123px; position: absolute; top: 15px" Width="261px" CssClass="G"></asp:TextBox>
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:Label ID="dwF_hme105a_uid_t" runat="server" CssClass="D" Style="z-index: 123; left: 21px; position: absolute; top: 73px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hme105a_uid" runat="server" CssClass="I" Style="z-index: 124; left: 123px; position: absolute; top: 73px"></asp:Label>
                                        <asp:Label ID="dwF_hme105a_aid_t" runat="server" CssClass="D" Style="z-index: 123; left: 21px; position: absolute; top: 47px" Width="100px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hme105a_aid" runat="server" CssClass="I" Style="z-index: 124; left: 123px; position: absolute; top: 47px"></asp:Label>
                                        <asp:Label ID="dwF_hme105a_udt_t" runat="server" CssClass="D" Style="z-index: 125; left: 411px; position: absolute; top: 73px" Width="80px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hme105a_udt" runat="server" CssClass="I" Style="z-index: 126; left: 493px; position: absolute; top: 73px"></asp:Label>
                                        <asp:Label ID="dwF_hme105a_cdt_t" runat="server" CssClass="D" Style="z-index: 125; left: 411px; position: absolute; top: 47px" Width="80px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hme105a_cdt" runat="server" CssClass="I" Style="z-index: 126; left: 493px; position: absolute; top: 47px"></asp:Label>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="position: relative; float: right">
                                        <uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
                                    </div>
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
