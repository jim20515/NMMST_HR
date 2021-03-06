﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="p_d0100_03.aspx.cs" Inherits="sys_d_d01_p_d0100_03" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>幹部任命</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pn_Contain" runat="server">
                        <asp:Label ID="dwF_name_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: -14px; position: absolute; top: 8px" Width="144px">任命的職位名：</asp:Label>
                        <asp:Label ID="dwF_name" runat="server" CssClass="G" Style="z-index: 124; left: 128px; position: absolute; top: 5px" ForeColor="SlateGray" Width="408px"></asp:Label>
                        <asp:Label ID="dwF_belone_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 110; left: -14px; position: absolute; top: 27px" Width="144px">編制來源：</asp:Label>
                        <asp:Label ID="dwF_belone" runat="server" CssClass="G" Style="z-index: 125; left: 128px; position: absolute; top: 24px" ForeColor="SlateGray" Width="408px"></asp:Label>
                        <asp:Label ID="dwF_posno_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 111; left: -14px; position: absolute; top: 46px" Width="144px">編制總數：</asp:Label>
                        <asp:Label ID="dwF_posno" runat="server" CssClass="G" Style="z-index: 126; left: 128px; position: absolute; top: 43px" ForeColor="SlateGray" Width="408px"></asp:Label>
                        <witc:DWPanel ID="dwS" runat="server" CssClass="Form" Height="400px" Style="position: relative; top: 0px; left: 0px;" Width="820px">
                            <asp:Label ID="Label6" runat="server" ForeColor="Purple" Height="19px" Style="left: 32px; position: relative; top: 56px" Font-Size="10pt">◎設定本職位的成員</asp:Label>
                            <asp:Label ID="Label1" runat="server" ForeColor="Blue" Height="12px" Style="left: -86px; position: relative; top: 72px" Font-Size="10pt">可任命候選人</asp:Label>
                            <asp:Label ID="Label2" runat="server" ForeColor="Blue" Height="12px" Style="left: 184px; position: relative; top: 72px" Font-Size="10pt">已任命成員</asp:Label>
                            <asp:Button ID="bt_toright" runat="server" Style="left: 320px; position: absolute; top: 136px" Width="80px" OnClick="bt_toright_Click" CssClass="Bt_ToRight" />
                            <asp:Button ID="bt_toleft" runat="server" Style="left: 320px; position: absolute; top: 192px" Width="80px" OnClick="bt_toleft_Click" CssClass="Bt_ToLeft" />
                            <asp:Button ID="bt_toreset" runat="server" Style="left: 320px; position: absolute; top: 248px" Width="80px" OnClick="bt_toreset_Click" CssClass="Bt_ToReset" />
                            <asp:ListBox ID="lb_all" runat="server" Height="247px" Style="left: 40px; position: absolute; top: 96px" Width="272px"></asp:ListBox>
                            <asp:ListBox ID="lb_go" runat="server" Height="247px" Style="left: 408px; position: absolute; top: 96px" Width="296px"></asp:ListBox>
                            <asp:Button ID="bt_confirm" runat="server" Style="left: 320px; position: absolute; top: 358px" Width="80px" OnClick="bt_confirm_Click" CssClass="Bt_Conf" />
                        </witc:DWPanel>
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
