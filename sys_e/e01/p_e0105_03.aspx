<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="p_e0105_03.aspx.cs" Inherits="sys_e_e01_p_e0105_03" %>

<%@ Register Src="../u_e_month_view.ascx" TagName="u_e_month_view" TagPrefix="uc2" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="400px" Style="position: relative" Width="820px">
                                        <asp:Label Style="z-index: 101; left: 38px; position: absolute; top: 7px; text-align: left" ID="dwF_YM_t" runat="server" CssClass="D"></asp:Label>
                                        <asp:RadioButtonList Style="left: 32px; position: absolute; top: 24px" ID="dwF_hme105b_type" runat="server" Width="369px" OnSelectedIndexChanged="dwF_hme105b_type_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">每週：</asp:ListItem>
                                            <asp:ListItem Value="2">特定日期：</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;
                                        <asp:DropDownList Style="left: 272px; position: absolute; top: 28px" ID="dwF_hme105b_sdate" runat="server" DataMember="DD">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList Style="left: 93px; position: absolute; top: 28px" ID="dwF_hme105b_weekday" runat="server">
                                            <asp:ListItem Value="">《請選擇》</asp:ListItem>
                                            <asp:ListItem Value="1">禮拜一</asp:ListItem>
                                            <asp:ListItem Value="2">禮拜二</asp:ListItem>
                                            <asp:ListItem Value="3">禮拜三</asp:ListItem>
                                            <asp:ListItem Value="4">禮拜四</asp:ListItem>
                                            <asp:ListItem Value="5">禮拜五</asp:ListItem>
                                            <asp:ListItem Value="6">禮拜六</asp:ListItem>
                                            <asp:ListItem Value="0">禮拜日</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 101; left: 14px; position: absolute; top: 62px" ID="dwF_time_t" runat="server" Width="80px" CssClass="N">時間：</asp:Label>
                                        <asp:Label Style="z-index: 103; left: 475px; position: absolute; top: 19px" ID="dwF_hme105b_starttime_t" runat="server" Width="80px" CssClass="N" Visible="False">開始時間：</asp:Label>
                                        <asp:Label Style="z-index: 103; left: 441px; position: absolute; top: 34px" ID="dwF_hme105b_type_t" runat="server" Width="80px" CssClass="N" Visible="False">需求類型：</asp:Label>
                                        <asp:Panel Style="z-index: 104; left: 96px; position: absolute; top: 60px" ID="dwF_hme105b_starttime" runat="server" Width="110px" CssClass="G">
                                            <uc1:u_TimeSelect ID="u_Time1" runat="server"></uc1:u_TimeSelect>
                                        </asp:Panel>
                                        <asp:Label Style="z-index: 106; left: 578px; position: absolute; top: 26px" ID="dwF_hme105b_endtime_t" runat="server" Width="80px" CssClass="N" Visible="False">結束時間：</asp:Label>
                                        <asp:Panel Style="z-index: 107; left: 228px; position: absolute; top: 60px" ID="dwF_hme105b_endtime" runat="server" Width="132px" CssClass="G">
                                            <uc1:u_TimeSelect ID="u_Time2" runat="server"></uc1:u_TimeSelect>
                                        </asp:Panel>
                                        <asp:TextBox Style="left: 237px; position: absolute; top: 85px" ID="dwF_addtext" runat="server" Width="324px" Visible="False"></asp:TextBox>
                                        <asp:Label Style="z-index: 101; left: 14px; position: absolute; top: 88px" ID="dwF_hme105b_addtext_t" runat="server" Width="80px" CssClass="N">報到點：</asp:Label>
                                        <asp:DropDownList Style="left: 96px; position: absolute; top: 85px" ID="dwF_hme105b_addtext" runat="server" Width="137px" OnSelectedIndexChanged="dwF_hme105b_addtext_SelectedIndexChanged" AutoPostBack="True" DataMember="hca209">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 101; left: 14px; position: absolute; top: 113px" ID="dwF_hme105b_needno_t" runat="server" Width="80px" CssClass="N">需要人數：</asp:Label>
                                        <asp:Label Style="z-index: 101; left: 175px; position: absolute; top: 113px" ID="dwF_needno_t" runat="server" Width="19px">人</asp:Label>
                                        <asp:Label Style="z-index: 101; left: 204px; position: absolute; top: 62px" ID="dwF_stime_t" runat="server" Width="19px">～</asp:Label>
                                        <asp:Label Style="z-index: 101; left: 98px; position: absolute; top: 264px" ID="dwF_note_t" runat="server" Width="84px" CssClass="D">(最多1000字)</asp:Label>
                                        <asp:TextBox Style="left: 97px; position: absolute; top: 110px" ID="dwF_hme105b_needno" runat="server" Width="70px"></asp:TextBox>
                                        <asp:Label Style="z-index: 101; left: 14px; position: absolute; top: 137px" ID="dwF_hme105b_note_t" runat="server" Width="80px" CssClass="N">工作說明：</asp:Label>
                                        <asp:TextBox Style="left: 97px; position: absolute; top: 135px" ID="dwF_hme105b_note" runat="server" Width="467px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Label Style="z-index: 101; left: 132px; position: absolute; top: 319px" ID="dwF_food1_t" runat="server" CssClass="I">次</asp:Label>
                                        <asp:CheckBox Style="left: 98px; position: absolute; top: 286px" ID="dwF_hme105b_fooda" runat="server" CssClass="I" Text="提供午餐"></asp:CheckBox>
                                        <asp:CheckBox Style="left: 250px; position: absolute; top: 286px" ID="dwF_hme105b_foodb" runat="server" CssClass="I" Text="提供晚餐"></asp:CheckBox>
                                        <asp:DropDownList Style="left: 97px; position: absolute; top: 316px" ID="dwF_hme105b_foodct" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                        </asp:DropDownList>
										<asp:Label ID="dwF_hme105b_hca213id_t" runat="server" CssClass="N" Style="z-index: 101; left: 389px; position: absolute; top: 319px">服務項目：</asp:Label>
										<asp:DropDownList ID="dwF_hme105b_hca213id" runat="server" DataMember="hca213" Style="left: 458px; position: absolute; top: 316px">
										</asp:DropDownList>
										<asp:Label Style="z-index: 101; left: 3px; position: absolute; top: 319px" ID="dwF_hme105b_foodct_t" runat="server" CssClass="N">加計誤餐次數：</asp:Label>
                                        <asp:Label ID="dwF_hme105b_hour_t" runat="server" CssClass="D" Style="z-index: 103; left: 374px; position: absolute; top: 62px" Width="80px">總時數：</asp:Label>
                                        <asp:Label ID="dwF_hme105b_hour" runat="server" CssClass="I" Style="z-index: 103; left: 463px; position: absolute; top: 61px"></asp:Label>
                                        <asp:Label ID="dwF_show_t" runat="server" CssClass="D" Style="z-index: 103; left: 501px; position: absolute; top: 62px">小時</asp:Label>
                                        <asp:Label ID="dwF_hme105b_aid_t" runat="server" CssClass="D" Style="z-index: 101; left: 29px; position: absolute; top: 345px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hme105b_aid" runat="server" CssClass="I" Style="z-index: 101; left: 98px; position: absolute; top: 345px"></asp:Label>
                                        <asp:Label ID="dwF_hme105b_uid" runat="server" CssClass="I" Style="z-index: 101; left: 98px; position: absolute; top: 371px"></asp:Label>
                                        <asp:Label ID="dwF_hme105b_uid_t" runat="server" CssClass="D" Style="z-index: 101; left: 29px; position: absolute; top: 371px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_hme105b_adt_t" runat="server" CssClass="D" Style="z-index: 101; left: 389px; position: absolute; top: 345px">新增時間：</asp:Label>
                                        <asp:Label ID="dwF_hme105b_adt" runat="server" CssClass="I" Style="z-index: 101; left: 458px; position: absolute; top: 345px"></asp:Label>
                                        <asp:Label ID="dwF_hme105b_udt" runat="server" CssClass="I" Style="z-index: 101; left: 458px; position: absolute; top: 371px"></asp:Label>
                                        <asp:Label ID="dwF_hme105b_udt_t" runat="server" CssClass="D" Style="z-index: 101; left: 389px; position: absolute; top: 371px">異動時間：</asp:Label>
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
                            <tr>
                                <td>
                                    <uc2:u_e_month_view ID="u_Show" runat="server" />
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
