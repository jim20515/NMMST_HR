<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0104_03.aspx.cs" Inherits="sys_e_e01_p_e0104_03" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="400px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwF_YM_t" runat="server" CssClass="D" Style="z-index: 101; left: 99px; position: absolute; top: 7px; text-align: left"></asp:Label>
                                        <asp:Label ID="dwF_hme101b_sdate_t" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 32px" Width="80px">日期：</asp:Label>
                                        <asp:Panel ID="dwF_hme101b_sdate" runat="server" CssClass="G" Style="z-index: 109; left: 97px; position: absolute; top: 29px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        <asp:Label ID="dwF_hme101b_edate_t" runat="server" CssClass="I" Style="z-index: 101; left: 204px; position: absolute; top: 32px" Width="19px">～</asp:Label>
                                        <asp:Panel ID="dwF_hme101b_edate" runat="server" CssClass="G" Style="z-index: 109; left: 235px; position: absolute; top: 29px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
                                        </asp:Panel>
                                        <asp:CheckBox ID="dwF_repeat" runat="server" Style="left: 357px; position: absolute; top: 29px" Text="每週重複" CssClass="I" />
                                        <asp:Label ID="dwF_time_t" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 62px" Width="80px">時間：</asp:Label>
                                        <asp:Label ID="dwF_SHour_t" Style="z-index: 103; left: 597px; position: absolute; top: 11px" runat="server" Width="80px" CssClass="N" Visible="False">開始時間：</asp:Label>
                                        <asp:Label ID="dwF_SMin_t" runat="server" CssClass="N" Style="z-index: 103; left: 488px; position: absolute; top: 14px" Visible="False" Width="80px">開始時間：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="dwF_EHour_t" runat="server" CssClass="N" Style="z-index: 106; left: 713px; position: absolute; top: 43px" Visible="False" Width="80px">結束時間：</asp:Label>
                                        <asp:Label ID="dwF_EMin_t" runat="server" CssClass="N" Style="z-index: 106; left: 704px; position: absolute; top: 17px" Visible="False" Width="80px">結束時間：</asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="dwF_addtext" runat="server" Style="left: 237px; position: absolute; top: 85px" Visible="False" Width="324px"></asp:TextBox>
                                        <asp:Label ID="dwF_hme101b_addtext_t" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 88px" Width="80px">報到點：</asp:Label>
                                        <asp:DropDownList ID="dwF_hme101b_addtext" runat="server" Style="left: 96px; position: absolute; top: 85px" AutoPostBack="True" OnSelectedIndexChanged="dwF_hme101b_addtext_SelectedIndexChanged" Width="137px" DataMember="hca209">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_hme101b_needno_t" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 113px" Width="80px">需要人數：</asp:Label>
                                        <asp:Label ID="dwF_needno_t" runat="server" Style="z-index: 101; left: 175px; position: absolute; top: 113px" Width="19px">人</asp:Label>
                                        <asp:Label ID="dwF_stime_t" runat="server" Style="z-index: 101; left: 204px; position: absolute; top: 62px" Width="19px">～</asp:Label>
                                        <asp:Label ID="dwF_1_t" runat="server" Style="z-index: 101; left: 142px; position: absolute; top: 62px">：</asp:Label>
                                        <asp:Label ID="dwF_2_t" runat="server" Style="z-index: 101; left: 279px; position: absolute; top: 62px">：</asp:Label>
                                        <asp:Label ID="dwF_note_t" runat="server" CssClass="D" Style="z-index: 101; left: 98px; position: absolute; top: 264px" Width="73px">(最多1000字)</asp:Label>
                                        <asp:TextBox ID="dwF_hme101b_needno" runat="server" Style="left: 97px; position: absolute; top: 110px" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="dwF_hme101b_endtime" runat="server" Style="left: 720px; position: absolute; top: 139px" Width="70px" Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="dwF_hme101b_starttime" runat="server" Style="left: 711px; position: absolute; top: 171px" Width="70px" Visible="False"></asp:TextBox>
                                        <asp:Label ID="dwF_hme101b_note_t" runat="server" CssClass="N" Style="z-index: 101; left: 14px; position: absolute; top: 137px" Width="80px">工作說明：</asp:Label>
                                        <asp:TextBox ID="dwF_hme101b_note" runat="server" Height="120px" Style="left: 97px; position: absolute; top: 135px" Width="467px" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Label ID="dwF_food1_t" runat="server" CssClass="I" Style="z-index: 101; left: 132px; position: absolute; top: 319px">次</asp:Label>
                                        <asp:CheckBox ID="dwF_hme101b_fooda" runat="server" Style="left: 98px; position: absolute; top: 286px" Text="提供午餐" CssClass="I" />
                                        <asp:CheckBox ID="dwF_hme101b_foodb" runat="server" Style="left: 250px; position: absolute; top: 286px" Text="提供晚餐" CssClass="I" />
                                        <asp:DropDownList ID="dwF_hme101b_foodct" runat="server" Style="left: 97px; position: absolute; top: 316px">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_SHour" runat="server" Style="left: 99px; position: absolute; top: 59px" Width="40px" AutoPostBack="true" OnSelectedIndexChanged="u_Time_ue_TimeChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_EHour" runat="server" Style="left: 234px; position: absolute; top: 59px" Width="40px" AutoPostBack="true" OnSelectedIndexChanged="u_Time_ue_TimeChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_SMin" runat="server" Style="left: 160px; position: absolute; top: 59px" Width="40px" AutoPostBack="true" OnSelectedIndexChanged="u_Time_ue_TimeChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_EMin" runat="server" Style="left: 300px; position: absolute; top: 59px" Width="40px" AutoPostBack="true" OnSelectedIndexChanged="u_Time_ue_TimeChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_hme101b_foodct_t" runat="server" CssClass="N" Style="z-index: 101; left: 3px; position: absolute; top: 319px">加計誤餐次數：</asp:Label>
                                        <asp:Label ID="dwF_hme101b_hour_t" runat="server" CssClass="D" Style="z-index: 103; left: 374px; position: absolute; top: 62px" Width="80px">總時數：</asp:Label>
                                        <asp:Label ID="dwF_hme101b_hour" runat="server" CssClass="I" Style="z-index: 103; left: 463px; position: absolute; top: 61px"></asp:Label>
                                        <asp:Label ID="dwF_show_t" runat="server" CssClass="D" Style="z-index: 103; left: 501px; position: absolute; top: 62px">小時</asp:Label>
										<asp:Label ID="dwF_hme101b_hca213id_t" runat="server" CssClass="N" Style="z-index: 101; left: 389px; position: absolute; top: 319px">服務項目：</asp:Label>
										<asp:DropDownList ID="dwF_hme101b_hca213id" runat="server" DataMember="hca213" Style="left: 458px; position: absolute; top: 316px">
										</asp:DropDownList>
                                        <asp:Label ID="dwF_hmd101b_aid_t" runat="server" CssClass="D" Style="z-index: 101; left: 29px; position: absolute; top: 345px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hmd101b_aid" runat="server" CssClass="I" Style="z-index: 101; left: 98px; position: absolute; top: 345px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101b_uid" runat="server" CssClass="I" Style="z-index: 101; left: 98px; position: absolute; top: 371px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101b_uid_t" runat="server" CssClass="D" Style="z-index: 101; left: 29px; position: absolute; top: 371px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hmd101b_adt_t" runat="server" CssClass="D" Style="z-index: 101; left: 389px; position: absolute; top: 345px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hmd101b_adt" runat="server" CssClass="I" Style="z-index: 101; left: 458px; position: absolute; top: 345px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101b_udt" runat="server" CssClass="I" Style="z-index: 101; left: 458px; position: absolute; top: 371px"></asp:Label>
                                        <asp:Label ID="dwF_hmd101b_udt_t" runat="server" CssClass="D" Style="z-index: 101; left: 389px; position: absolute; top: 371px">異動時間：</asp:Label>
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
