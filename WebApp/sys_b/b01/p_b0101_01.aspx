<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_b0101_01.aspx.cs" Inherits="sys_b_b01_p_b0101_01" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="330px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_condition_t" runat="server" CssClass="N" ForeColor="Purple" Style="z-index: 101; left: 20px; position: absolute; top: 12px" Width="80px">◎快選條件：</asp:Label>
                                        <asp:RadioButtonList ID="dwQ_condition" runat="server" Style="left: 103px; position: absolute; top: 7px">
                                            <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                                            <asp:ListItem Value="1">當月壽星</asp:ListItem>
                                            <asp:ListItem Value="2">下月壽星</asp:ListItem>
                                            <asp:ListItem Value="3">男性</asp:ListItem>
                                            <asp:ListItem Value="4">女性</asp:ListItem>
                                        </asp:RadioButtonList>
										<asp:Label ID="dwQ_hmc101_type1_t" runat="server" CssClass="Q" Style="z-index: 101; left: 21px; position: absolute; top: 148px" Width="80px">人員分類：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_type1" runat="server" AutoPostBack="TRUE" CssClass="G" OnSelectedIndexChanged="dwQ_hmc101_type1_SelectedIndexChanged" Style="left: 104px; position: absolute; top: 145px" Width="143px">
											<asp:ListItem Selected="True" Value="Y">已分類</asp:ListItem>
											<asp:ListItem Value="N">未分類</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmc101_stop_t" runat="server" CssClass="Q" Style="z-index: 101; left: 266px; position: absolute; top: 148px" Width="104px">人員停用：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_stop" runat="server" CssClass="G" Style="left: 368px; position: absolute; top: 145px" Width="143px">
											<asp:ListItem Value="">全部</asp:ListItem>
											<asp:ListItem Value="Y">停用</asp:ListItem>
											<asp:ListItem Selected="True" Value="N">未停用</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmc101_type_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 178px" Width="80px">分類：</asp:Label>
										<asp:CheckBoxList ID="dwQ_hmc101_type" runat="server" DataMember="hmc102" DataTextField="hmc102_name" DataValueField="hmc102_id" RepeatColumns="6" RepeatDirection="Horizontal" Style="z-index: 101; left: 103px; position: absolute; top: 172px" Width="684px">
										</asp:CheckBoxList>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 672px; position: absolute; top: 12px" Text="" Width="80px" OnClick="bt_Query_Click" />
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
