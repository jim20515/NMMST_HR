<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_05.aspx.cs" Inherits="sys_d_d02_p_d0201_05" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出勤/年資/服勤</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table class="G" >
                        <tr>
                            <td>
                                <asp:Label ID="dwF_hmd201_vid_t" runat="server" CssClass="D" Style="position: relative; top: 0px;" Width="100px">◎志工姓名：</asp:Label>
                                <asp:Label ID="dwF_hmd201_vid" runat="server" CssClass="G" Style="position: relative; left: 0px; top: 0px;" Width="168px"></asp:Label>
                                <witc:DWPanel ID="DWPanel2" runat="server" CssClass="Form" Height="112px" Style="position: relative;" Width="800px">
                                    <asp:Label ID="dwF_Show" runat="server" CssClass="I" ForeColor="Purple" Style="left: 8px; position: relative; top: 8px;" Text="◎離歸隊維護" Font-Size="10pt"></asp:Label>
                                    <asp:Label ID="dwF_Reason_t" runat="server" CssClass="G" Height="16px" Style="z-index: 113; left: 536px; position: absolute; top: 8px" Width="72px">離隊原因：</asp:Label>
									<asp:DropDownList ID="DDL_Reason" runat="server" CssClass="N" Style="left: 552px; position: absolute; top: 24px" Width="144px">
									</asp:DropDownList>
                                    <asp:Button ID="Bt_Leave" runat="server" CssClass="Bt_B9002" Style="z-index: 999; left: 704px; position: absolute; top: 24px" Text="" Width="80px" OnClick="Bt_Leave_Click" />
                                    <asp:Button ID="Bt_Back" runat="server" CssClass="Bt_B9003" Style="z-index: 999; left: 704px; position: absolute; top: 64px" Text="" Width="80px" OnClick="Bt_Back_Click" />
                                    <asp:Label ID="dwF_Lv_t" runat="server" CssClass="I" Height="16px" Style="z-index: 109; left: 32px; position: absolute; top: 32px" Width="96px">目前志工階級：</asp:Label>
                                    <asp:Label ID="dwF_Lv" runat="server" CssClass="G" ForeColor="SlateGray" Height="16px" Style="z-index: 110; left: 136px; position: absolute; top: 32px" Width="104px"></asp:Label>
                                    <asp:Label ID="dwF_Stutas_t" runat="server" CssClass="I" Height="16px" Style="z-index: 111; left: 32px; position: absolute; top: 56px" Width="96px">目前志工狀態：</asp:Label>
                                    <asp:Label ID="dwF_Stutas" runat="server" CssClass="G" ForeColor="SlateGray" Height="16px" Style="z-index: 112; left: 136px; position: absolute; top: 56px" Width="104px"></asp:Label>
                                </witc:DWPanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" ForeColor="Purple" Style="position: relative;" Text="◎執勤紀錄"></asp:Label>
                                <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="48px" Style="position: relative;" Width="800px">
                                    <asp:Label ID="dwQ_Year_t" runat="server" CssClass="Q" Style="z-index: 114; left: 11px; position: absolute; top: 16px" Width="100px">年度：</asp:Label>
                                    <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 704px; position: absolute; top: 8px" Text="" Width="80px" OnClick="bt_Query_Click" />
                                    <asp:TextBox ID="dwQ_year" runat="server" Style="left: 120px; position: absolute; top: 13px" Width="80px"></asp:TextBox>
                                </witc:DWPanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 41px">
                                <witc:DWPanel ID="DWPanel1" runat="server" CssClass="Form" Height="144px" Style="position: relative; left: 0px; top: 0px;" Width="800px">
                                    <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Black" Style="z-index: 109; left: 8px; position: absolute; top: 8px">累積總服務時數：</asp:Label>
                                    <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Black" Style="z-index: 109; left: 8px; position: absolute; top: 56px">本年度服務狀況：</asp:Label>
                                    <asp:Label ID="dwF_TotalHours" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 8px" Width="304px"></asp:Label>
                                    <asp:Label ID="dwF_TotalFromThatDay" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 32px" Width="304px">最近榮譽卡申請後累積：298  小時</asp:Label>
                                    <asp:Label ID="dwF_ThisYear1" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 64px" Width="216px">實際服務時數：90  小時</asp:Label>
                                    <asp:Label ID="dwF_ThisYear2" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 88px" Width="216px">服勤率：83%</asp:Label>
                                    <asp:Label ID="dwF_ThisYear3" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 112px" Width="216px">累積服務次數：80次</asp:Label>
                                    <br />
                                    <br />
                                </witc:DWPanel>
                            </td>
                        </tr>
						<tr>
							<td>
								<asp:Label ID="Label1" runat="server" ForeColor="Purple" Style="position: relative;" Text="◎年資"></asp:Label>
							</td>
						</tr>
						<tr>
						</tr>
							<td style="height: 41px">
								<witc:DWPanel ID="DWPanel4" runat="server" CssClass="Form" Height="40px" Style="position: relative; left: 0px; top: 0px;" Width="800px">
									<asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Black" Style="z-index: 109; left: 48px; position: absolute; top: 8px">累積年資：</asp:Label>
									<asp:Label ID="dwF_TotalYear" runat="server" CssClass="G" ForeColor="SlateGray" Style="z-index: 124; left: 120px; position: absolute; top: 8px" Width="304px"></asp:Label>
								</witc:DWPanel>
							</td>
                        <tr>
                            <td style="height: 8px">
                                <br />
                            </td>
                        </tr>
                    </table>
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
