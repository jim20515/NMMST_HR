<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0102_02.aspx.cs" Inherits="sys_c_c01_p_c0102_02" %>

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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="250px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_hmc102_id_t" runat="server" CssClass="D" Style="z-index: 101; left: 13px; position: absolute; top: 12px" Width="100px">分類階層代碼：</asp:Label>
                                        <asp:Label ID="dwF_hmc102_id" runat="server" CssClass="G" Style="z-index: 102; left: 119px; position: absolute; top: 12px" Width="60px"></asp:Label>
                                        <asp:Label ID="dwF_hmc102_name_t" runat="server" CssClass="N" Style="z-index: 103; left: 13px; position: absolute; top: 38px" Width="100px" Height="16px">*分類階層名稱：</asp:Label>
                                        <asp:TextBox ID="dwF_hmc102_name" runat="server" Style="z-index: 104; left: 119px; position: absolute; top: 33px" Width="200px"></asp:TextBox>
                                        <asp:Label ID="dwF_hmc102_parentid_t" runat="server" CssClass="Q" Height="16px" Style="z-index: 103; left: 0px; position: absolute; top: 64px" Width="115px">上層分類階層：</asp:Label>
                                        <asp:DropDownList ID="dwF_hmc102_parentid" runat="server" Style="z-index: 104; left: 119px; position: absolute; top: 61px"></asp:DropDownList>
                                        <asp:CheckBox ID="dwF_hmc102_stop" runat="server" Style="z-index: 105; left: 108px; position: absolute; top: 89px" Text="停用" />
                                        <asp:Label ID="dwF_hmc102_aid_t" runat="server" CssClass="D" Style="z-index: 219; left: 15px; position: absolute; top: 120px" Width="100px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hmc102_aid" runat="server" CssClass="G" Style="z-index: 220; left: 119px; position: absolute; top: 120px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmc102_adt_t" runat="server" CssClass="D" Style="z-index: 224; left: 15px; position: absolute; top: 144px" Width="100px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hmc102_adt" runat="server" CssClass="G" Style="z-index: 225; left: 119px; position: absolute; top: 144px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmc102_uid_t" runat="server" CssClass="D" Style="z-index: 229; left: 15px; position: absolute; top: 168px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hmc102_uid" runat="server" CssClass="G" Style="z-index: 230; left: 119px; position: absolute; top: 168px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmc102_udt_t" runat="server" CssClass="D" Style="z-index: 234; left: 15px; position: absolute; top: 192px" Width="100px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hmc102_udt" runat="server" CssClass="G" Style="z-index: 235; left: 119px; position: absolute; top: 192px" Width="150px"></asp:Label>
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
