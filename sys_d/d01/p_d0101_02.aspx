<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0101_02.aspx.cs" Inherits="sys_d_d01_p_d0101_02" %>

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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="280px" Style="position: relative; left: 0px; top: 8px;" Width="800px">
                                        <asp:Label ID="dwF_hmd101_tid_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 37px; position: absolute; top: 10px" Width="80px">志工隊代碼：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_tname_t" runat="server" CssClass="N" Style="z-index: 109; left: 16px; position: absolute; top: 36px" Width="101px">*志工隊名稱：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_tmission_t" runat="server" CssClass="I" Style="z-index: 109; left: 1px; position: absolute; top: 60px" Width="116px">志工隊任務說明：</asp:Label>
                                        <asp:Label ID="dwF_vcount_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 8px; position: absolute; top: 147px" Width="112px">目前隊員數：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_tid" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 119px; position: absolute; top: 10px"></asp:Label>
                                        <asp:Label ID="dwF_vcount" runat="server" CssClass="G" Style="z-index: 124; left: 120px; position: absolute; top: 147px" ForeColor="SlateGray" Width="55px"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="dwF_hmd101_tname" runat="server" Style="left: 117px; position: absolute; top: 33px" Width="279px"></asp:TextBox>
                                        <asp:TextBox ID="dwF_hmd101_tmission" runat="server" Style="left: 117px; position: absolute; top: 60px" Width="516px" Height="49px"></asp:TextBox>
                                        <br />
										<asp:Label ID="dwF_hmd101_stop_t" runat="server" CssClass="I" Style="z-index: 289; left: 19px; position: absolute; top: 123px" Width="100px">停用：</asp:Label>
										<asp:CheckBox ID="dwF_hmd101_stop" runat="server" Style="z-index: 220; left: 119px; position: absolute; top: 120px" />
                                        <asp:Label ID="dwF_hmd101_aid_t" runat="server" CssClass="D" Style="z-index: 129; left: 17px; position: absolute; top: 172px" Width="100px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_aid" runat="server" CssClass="G" Style="z-index: 130; left: 117px; position: absolute; top: 171px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101_adt_t" runat="server" CssClass="D" Style="z-index: 134; left: 17px; position: absolute; top: 198px" Width="100px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_adt" runat="server" CssClass="G" Style="z-index: 135; left: 117px; position: absolute; top: 197px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101_uid_t" runat="server" CssClass="D" Style="z-index: 139; left: 17px; position: absolute; top: 224px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_uid" runat="server" CssClass="G" Style="z-index: 140; left: 117px; position: absolute; top: 223px" Width="150px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101_udt_t" runat="server" CssClass="D" Style="z-index: 144; left: 17px; position: absolute; top: 250px" Width="100px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hmd101_udt" runat="server" CssClass="G" Style="z-index: 145; left: 117px; position: absolute; top: 249px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_service_t" runat="server" CssClass="D" Style="z-index: 109; left: 470px; position: absolute; top: 33px">服務項目：0240 教育服務</asp:Label>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="position: relative; float: right">
                                        <uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
                                    </div>
                                    <asp:Button ID="dwF_report1" runat="server" CssClass="Bt_B9006" Width="80px" Style="position: relative; left: 114px; top: 8px;" OnClick="dwF_report1_Click" /></td>
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
