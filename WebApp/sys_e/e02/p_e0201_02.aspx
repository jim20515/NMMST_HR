<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0201_02.aspx.cs" Inherits="sys_e_e02_p_e0201_02" %>

<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
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
                                        <asp:Label ID="dwF_hle201_lid_t" runat="server" CssClass="D" Style="z-index: 99; left: 5px; position: absolute; top: 12px" Width="120px">刷卡紀錄檔代碼：</asp:Label>
                                        <asp:Label ID="dwF_hle201_cway_c_t" runat="server" CssClass="D" Style="z-index: 99; left: 25px; position: absolute; top: 119px" Width="100px">建檔方式：</asp:Label>
                                        <asp:Label ID="dwF_hle201_uid_t" runat="server" CssClass="D" Style="z-index: 99; left: 25px; position: absolute; top: 172px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="hle201_cdt_t" runat="server" CssClass="D" Style="z-index: 99; left: 469px; position: absolute; top: 119px" Width="100px">建檔時間：</asp:Label>
                                        <asp:Label ID="dwF_hle201_cway_c" runat="server" CssClass="D" Style="z-index: 99; left: 127px; position: absolute; top: 119px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_uid" runat="server" CssClass="I" Style="z-index: 99; left: 127px; position: absolute; top: 172px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_udt_t" runat="server" CssClass="D" Style="z-index: 99; left: 469px; position: absolute; top: 172px" Width="100px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hle201_udt" runat="server" CssClass="I" Style="z-index: 99; left: 571px; position: absolute; top: 172px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_aid_t" runat="server" CssClass="D" Style="z-index: 99; left: 25px; position: absolute; top: 146px" Width="100px">新增人員：</asp:Label>
                                        <asp:Label ID="dwF_hle201_aid" runat="server" CssClass="I" Style="z-index: 99; left: 127px; position: absolute; top: 146px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_adt_t" runat="server" CssClass="D" Style="z-index: 99; left: 469px; position: absolute; top: 146px" Width="100px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_hle201_adt" runat="server" CssClass="I" Style="z-index: 99; left: 571px; position: absolute; top: 146px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_cdt" runat="server" CssClass="D" Style="z-index: 99; left: 571px; position: absolute; top: 119px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_lid" runat="server" CssClass="D" Style="z-index: 100; left: 127px; position: absolute; top: 12px"></asp:Label>
                                        <asp:Label ID="dwF_hle201_vid_t" runat="server" CssClass="N" Style="z-index: 104; left: 25px; position: absolute; top: 35px" Width="100px">志工代碼：</asp:Label>
                                        <asp:Label ID="dwF_hle201_sdatetime_t" runat="server" CssClass="N" Style="z-index: 104; left: 25px; position: absolute; top: 66px" Width="100px">刷卡時間：</asp:Label>
                                        <asp:TextBox ID="dwF_hle201_vid" runat="server" CssClass="G" Style="z-index: 105; left: 127px; position: absolute; top: 32px" Width="89px" Enabled="False"></asp:TextBox>
                                        <asp:TextBox ID="dwF_hle201_vname" runat="server" CssClass="G" Style="z-index: 105; left: 225px; position: absolute; top: 32px" Width="138px" Enabled="False"></asp:TextBox>
                                        <asp:Button ID="bt_choose1" runat="server" Style="z-index: 123; left: 373px; position: absolute; top: 28px" Width="80px" CssClass="Bt_SearchQ" />
                                        <asp:TextBox ID="dwF_hle201_ip" runat="server" CssClass="G" Style="z-index: 105; left: 127px; position: absolute; top: 91px" Width="217px"></asp:TextBox>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_hle201_type_t" runat="server" CssClass="N" Style="z-index: 114; left: 469px; position: absolute; top: 35px" Width="100px">刷卡種類：</asp:Label>
                                        <asp:Label ID="dwF_hle201_cancel_t" runat="server" CssClass="N" Style="z-index: 114; left: 469px; position: absolute; top: 66px" Width="100px">是否取消：</asp:Label>
                                        <asp:Label ID="dwF_SMin_t" runat="server" CssClass="N" Style="z-index: 114; left: 469px; position: absolute; top: 12px" Visible="False" Width="100px">刷卡時間：</asp:Label>
                                        <asp:Label ID="dwF_SHour_t" runat="server" CssClass="N" Style="z-index: 114; left: 469px; position: absolute; top: 12px" Visible="False" Width="100px">刷卡時間：</asp:Label>
                                        <asp:Label ID="dwF_hle201_ip_t" runat="server" CssClass="I" Style="z-index: 114; left: 25px; position: absolute; top: 94px" Width="100px">刷卡機IP：</asp:Label>
                                        <asp:RadioButtonList ID="dwF_hle201_type" Style="z-index: 145; left: 571px; position: absolute; top: 29px" runat="server" RepeatDirection="Horizontal" Width="122px">
                                            <asp:ListItem Value="1">上班</asp:ListItem>
                                            <asp:ListItem Value="2">下班</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RadioButtonList ID="dwF_hle201_cancel" Style="z-index: 145; left: 571px; position: absolute; top: 60px" runat="server" RepeatDirection="Horizontal" Width="122px">
                                            <asp:ListItem Value="Y">是</asp:ListItem>
                                            <asp:ListItem Value="N">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:Label ID="dwF_1_t" runat="server" Style="z-index: 101; left: 292px; position: absolute; top: 66px">：</asp:Label>
                                        <asp:Label ID="dwF_2_t" runat="server" Style="z-index: 101; left: 352px; position: absolute; top: 66px">：</asp:Label>
                                        <asp:DropDownList ID="dwF_SHour" runat="server" Style="left: 249px; position: absolute; top: 63px" Width="40px" DataMember="hh" DataTextFormatString="00">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_SMin" runat="server" Style="left: 310px; position: absolute; top: 63px" Width="40px" DataMember="mm" DataTextFormatString="00">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_SSec" runat="server" Style="left: 371px; position: absolute; top: 63px" Width="40px" DataMember="ss" DataTextFormatString="00">
                                        </asp:DropDownList>
                                        <asp:Panel ID="dwF_hle201_sdatetime" runat="server" CssClass="G" Style="z-index: 110; left: 127px; position: absolute; top: 63px" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        &nbsp;
                                         
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                    <asp:RadioButtonList ID="dwF_hle201_cway" runat="server" RepeatDirection="Horizontal" Style="position: relative" Visible="False" Width="181px">
                                        <asp:ListItem Value="1">刷卡機</asp:ListItem>
                                        <asp:ListItem Value="2">手動補登</asp:ListItem>
                                    </asp:RadioButtonList></td>
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
