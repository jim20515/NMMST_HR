<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0203_02.aspx.cs" Inherits="sys_g_g02_p_g0203_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明細</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../proj_css/s_webstyle.css" rel="stylesheet" type="text/css" />
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
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="156px" Style="position: relative; left: 0px; top: 0px;" Width="820px">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:Label Style="z-index: 124; left: 346px; position: absolute; top: 14px" ID="dwF_hlg203_mdate_t" runat="server" Width="100px" CssClass="N">得獎日期：</asp:Label>
                                        <asp:Panel Style="z-index: 125; left: 450px; position: absolute; top: 11px" ID="dwF_hlg203_mdate" runat="server" Width="240px" Height="16px" CssClass="G">
                                            <uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
                                        </asp:Panel>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList Style="z-index: 130; left: 104px; position: absolute; top: 11px" ID="dwF_hlg203_vid" runat="server" Width="105px" DataMember="hmd201">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 134; left: 0px; position: absolute; top: 41px" ID="dwF_hlg203_metalname_t" runat="server" Width="100px" CssClass="N">獎項名稱：</asp:Label>
                                        <asp:Label ID="dwF_hlg203_vid_t" runat="server" CssClass="N" Style="z-index: 134; left: 0px; position: absolute; top: 14px" Width="100px">志工：</asp:Label>
                                        <asp:TextBox Style="z-index: 135; left: 216px; position: absolute; top: 38px" ID="dwF_hlg203_metalname_s" runat="server" Width="331px" CssClass="G" Visible="False"></asp:TextBox>
                                        <asp:DropDownList ID="dwF_hlg203_metalname" runat="server" AutoPostBack="True" CssClass="B" OnSelectedIndexChanged="dwF_hlg203_metalname_SelectedIndexChanged" Style="z-index: 115; left: 104px; position: absolute; top: 38px" Width="108px">
                                            <asp:ListItem>全勤獎</asp:ListItem>
                                            <asp:ListItem>服務獎</asp:ListItem>
                                            <asp:ListItem>一級海科獎</asp:ListItem>
                                            <asp:ListItem>二級海科獎</asp:ListItem>
                                            <asp:ListItem>三級海科獎</asp:ListItem>
                                            <asp:ListItem>其他</asp:ListItem>
                                        </asp:DropDownList>
										<asp:Label ID="dwF_hlg203_appno_t" runat="server" CssClass="N" Style="z-index: 289; left: 0px; position: absolute; top: 69px" Width="100px">核淮字號：</asp:Label>
										<asp:TextBox ID="dwF_hlg203_appno" runat="server" CssClass="G" Style="z-index: 290; left: 103px; position: absolute; top: 66px" Width="150px"></asp:TextBox>
										<asp:Label ID="dwF_hlg203_app_date_t" runat="server" CssClass="N" Style="z-index: 294; left: 345px; position: absolute; top: 67px" Width="100px">核淮時間：</asp:Label>
										<asp:Panel ID="dwF_hlg203_app_date" runat="server" CssClass="G" Height="16px" Style="z-index: 295; left: 450px; position: absolute; top: 64px" Width="240px">
											<uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
										</asp:Panel>
                                        <asp:Label Style="z-index: 289; left: 0px; position: absolute; top: 95px" ID="dwF_hlg203_aid_t" runat="server" Width="100px" CssClass="D">新增人員：</asp:Label>
                                        <asp:Label Style="z-index: 290; left: 103px; position: absolute; top: 95px" ID="dwF_hlg203_aid" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 294; left: 345px; position: absolute; top: 95px" ID="dwF_hlg203_adt_t" runat="server" Width="100px" CssClass="D">新增時間：</asp:Label>
                                        <asp:Label Style="z-index: 295; left: 449px; position: absolute; top: 95px" ID="dwF_hlg203_adt" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 299; left: 0px; position: absolute; top: 123px" ID="dwF_hlg203_uid_t" runat="server" Width="100px" CssClass="D">異動人員：</asp:Label>
                                        <asp:Label Style="z-index: 300; left: 103px; position: absolute; top: 123px" ID="dwF_hlg203_uid" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 304; left: 345px; position: absolute; top: 123px" ID="dwF_hlg203_udt_t" runat="server" Width="100px" CssClass="D">異動時間：</asp:Label>
                                        <asp:Label Style="z-index: 305; left: 449px; position: absolute; top: 123px" ID="dwF_hlg203_udt" runat="server" Width="150px" CssClass="G"></asp:Label>
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
