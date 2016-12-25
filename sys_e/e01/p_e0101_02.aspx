<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0101_02.aspx.cs" Inherits="sys_e_e01_p_e0101_02" %>

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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="200px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_hme101a_tid_t" runat="server" CssClass="N" Style="z-index: 101; left: 62px; position: absolute; top: 40px" Width="80px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwF_hme101a_tid" runat="server" Style="left: 146px; position: absolute; top: 37px" CssClass="G" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_date_t" runat="server" CssClass="N" Style="z-index: 101; left: 347px; position: absolute; top: 40px" Width="80px">班表日期：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_syear_t" runat="server" CssClass="N" Style="z-index: 101; left: 469px; position: absolute; top: 40px" Width="18px">年</asp:Label>
                                        <asp:Label ID="dwF_hme101a_smonth_t" runat="server" CssClass="N" Style="z-index: 101; left: 530px; position: absolute; top: 40px" Width="18px">月</asp:Label>
                                        <asp:TextBox ID="dwF_hme101a_syear" runat="server" Style="left: 428px; position: absolute; top: 37px" Width="33px" CssClass="G" MaxLength="3"></asp:TextBox>
                                        <asp:TextBox ID="dwF_hme101a_smonth" runat="server" Style="left: 489px; position: absolute; top: 37px" Width="33px" CssClass="G" MaxLength="2"></asp:TextBox>
                                        <asp:Label ID="dwF_rcount" runat="server" CssClass="D" Style="z-index: 101; left: 104px; position: absolute; top: 66px; text-align: left">班次：已安排 0 班次</asp:Label>
                                        <asp:Label ID="dwF_hme101a_hrneedno_t" runat="server" CssClass="N" Style="z-index: 125; left: 343px; position: absolute; top: 66px">志工排班次數：</asp:Label>
                                        <asp:TextBox ID="dwF_hme101a_hrneedno" runat="server" Style="left: 436px; position: absolute; top: 66px" Width="60px" CssClass="G" MaxLength="3"></asp:TextBox>
                                        <asp:Label ID="dwF_pcount" runat="server" CssClass="D" Style="z-index: 101; left: 104px; position: absolute; top: 89px; text-align: left">人次：需 0 人次</asp:Label>
                                        <asp:CheckBox ID="dwF_hme101a_makeflag" runat="server" CssClass="G" Style="left: 143px; position: absolute; top: 113px" Text="開放填寫" Checked="True" />
										<asp:CheckBox ID="dwF_hme101a_openflag" runat="server" CssClass="G" Style="left: 429px; position: absolute; top: 113px" Text="開放其它小隊報名" />
                                        <asp:Label ID="dwF_msg_t" runat="server" CssClass="N" Style="z-index: 101; left: 63px; position: absolute; top: 11px; text-align: left" Width="181px">※ 同志工隊同月僅能填寫一張</asp:Label>
                                        <asp:Label ID="dwF_hme101a_uid_t" runat="server" CssClass="D" Style="z-index: 123; left: 42px; position: absolute; top: 172px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_uid" runat="server" CssClass="I" Style="z-index: 124; left: 144px; position: absolute; top: 172px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_aid_t" runat="server" CssClass="D" Style="z-index: 123; left: 42px; position: absolute; top: 146px" Width="100px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_aid" runat="server" CssClass="I" Style="z-index: 124; left: 144px; position: absolute; top: 146px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_udt_t" runat="server" CssClass="D" Style="z-index: 125; left: 347px; position: absolute; top: 172px" Width="80px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_udt" runat="server" CssClass="I" Style="z-index: 126; left: 429px; position: absolute; top: 172px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_cdt_t" runat="server" CssClass="D" Style="z-index: 125; left: 347px; position: absolute; top: 146px" Width="80px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_okflag_t" runat="server" CssClass="D" Style="z-index: 125; left: 323px; position: absolute; top: 89px">是否為正式班表：</asp:Label>
                                        <asp:Label ID="dwF_hme101a_cdt" runat="server" CssClass="I" Style="z-index: 126; left: 429px; position: absolute; top: 146px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_okflag_c" runat="server" CssClass="I" Style="z-index: 126; left: 429px; position: absolute; top: 89px"></asp:Label>
                                        <asp:Label ID="dwF_hme101a_okflag" runat="server" CssClass="I" Style="z-index: 126; left: 429px; position: absolute; top: 89px" Visible="false"></asp:Label>
                                        <asp:Button ID="Bt_VRef" runat="server" CssClass="Bt_VRef" OnClientClick="uf_SelectFrame(3);" Style="left: 618px; position: relative; top: 11px" Width="80px" /></witc:DWPanel>
                                        
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
