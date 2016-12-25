<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_b0201_01.aspx.cs" Inherits="sys_b_b02_p_b0201_01" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
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
                                    <witc:DWPanel ID="dwQ1" runat="server" CssClass="Query" Height="250px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_type1_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 6px" Width="80px" ForeColor="Purple">◎人員類別：</asp:Label>
                                        <asp:Label ID="Label3" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 87px" Width="80px">類別：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_deptid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 29px" Width="80px">員工部門：</asp:Label>
                                        <asp:Label ID="dwQ_tid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 323px; position: absolute; top: 29px">所屬志工隊名稱：</asp:Label>
                                        <asp:DropDownList ID="dwQ_tid" runat="server" Style="left: 430px; position: absolute; top: 26px" CssClass="B" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:CheckBoxList ID="dwQ_hmc101_type" runat="server" DataMember="hmc102" DataTextField="hmc102_name" DataValueField="hmc102_id" RepeatColumns="6" RepeatDirection="Horizontal" Style="z-index: 101; left: 103px; position: absolute; top: 81px" Width="684px">
                                        </asp:CheckBoxList>
                                        <asp:DropDownList ID="dwQ_hmc101_deptid" runat="server" Style="left: 104px; position: absolute; top: 26px" CssClass="B" DataMember="hca202">
                                        </asp:DropDownList>
										<asp:Label ID="dwQ_hmc101_type1_t" runat="server" CssClass="Q" Style="z-index: 101; left: 21px; position: absolute; top: 59px" Width="80px">人員分類：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_type1" runat="server" AutoPostBack="TRUE" CssClass="G" OnSelectedIndexChanged="dwQ_hmc101_type1_SelectedIndexChanged" Style="left: 104px; position: absolute; top: 56px" Width="143px">
											<asp:ListItem Selected="True" Value="Y">已分類</asp:ListItem>
											<asp:ListItem Value="N">未分類</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmc101_stop_t" runat="server" CssClass="Q" Style="z-index: 101; left: 322px; position: absolute; top: 59px" Width="104px">人員停用：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_stop" runat="server" CssClass="G" Style="left: 430px; position: absolute; top: 56px" Width="143px">
											<asp:ListItem Selected="True" Value="">全部</asp:ListItem>
											<asp:ListItem Value="Y">停用</asp:ListItem>
											<asp:ListItem Value="N">未停用</asp:ListItem>
										</asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:DWPanel ID="dwQ2" runat="server" CssClass="Query" Height="110px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_type2_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 8px" ForeColor="Purple">◎出生年月/年齡：</asp:Label>
                                        <asp:Label ID="dwQ_sage_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 32px" Width="80px">年齡：</asp:Label>
                                        <asp:Label ID="dwQ_month_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 58px" Width="80px">出生月份：</asp:Label>
                                        <asp:Label ID="dwF_bday_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 85px" Width="80px">特定日期：</asp:Label>
                                        <asp:Label ID="dwQ_eage_t" runat="server" CssClass="Q" Style="z-index: 101; left: 157px; position: absolute; top: 32px" Width="18px">～</asp:Label>
                                        <asp:Label ID="dwQ_smonth_t" runat="server" CssClass="Q" Style="z-index: 101; left: 234px; position: absolute; top: 32px" Width="18px">歲</asp:Label>
                                        <asp:Label ID="dwQ_month1_t" runat="server" CssClass="Q" Style="z-index: 101; left: 171px; position: absolute; top: 58px" Width="18px">月</asp:Label>
                                        <asp:TextBox ID="dwQ_sage" runat="server" Style="left: 103px; position: absolute; top: 29px" Width="45px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_eage" runat="server" Style="left: 179px; position: absolute; top: 29px" Width="45px"></asp:TextBox>
                                        <asp:DropDownList ID="dwQ_month" runat="server" Style="left: 104px; position: absolute; top: 55px" CssClass="B" DataMember="MM_ns" Width="70px">
                                        </asp:DropDownList>
                                        <asp:Panel ID="dwF_bday" runat="server" CssClass="G" Style="z-index: 109; left: 105px; position: absolute; top: 82px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:DWPanel ID="dwQ3" runat="server" CssClass="Query" Height="60px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_type3_t" runat="server" CssClass="Q" Style="z-index: 101; left: 20px; position: absolute; top: 7px" ForeColor="Purple">◎性別/學歷/職業：</asp:Label>
                                        <asp:Label ID="dwQ_gen_t" runat="server" CssClass="Q" Style="z-index: 101; left: 50px; position: absolute; top: 31px" Width="80px">性別：</asp:Label>
                                        <asp:Label ID="dwQ_eduid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 268px; position: absolute; top: 31px" Width="80px">學歷：</asp:Label>
                                        <asp:RadioButtonList ID="dwQ_gen" runat="server" Style="z-index: 101; left: 133px; position: absolute; top: 23px" RepeatDirection="Horizontal" Width="132px">
                                            <asp:ListItem Value="M">男性</asp:ListItem>
                                            <asp:ListItem Value="F">女性</asp:ListItem>
                                        </asp:RadioButtonList><asp:DropDownList ID="dwQ_eduid" runat="server" Style="left: 350px; position: absolute; top: 28px" CssClass="B" DataMember="hca203">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_jobid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 462px; position: absolute; top: 31px" Width="80px">職業：</asp:Label>
                                        <asp:DropDownList ID="dwQ_jobid" runat="server" Style="left: 544px; position: absolute; top: 28px" CssClass="B" DataMember="hca204">
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative">
                                    <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="position: relative; left: 358px;" Text="" Width="80px" OnClick="bt_Query_Click" />
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
