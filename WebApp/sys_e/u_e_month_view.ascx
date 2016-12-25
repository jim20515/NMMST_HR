<%@ Control Language="C#" AutoEventWireup="true" CodeFile="u_e_month_view.ascx.cs" Inherits="sys_e_u_e_month_view" %>
<%@ Register Src="../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>

<script src="../../wz_tooltip.js" type="text/javascript"></script>

<table class="G" cellspacing="0" cellpadding="0" border="0">
    <tr style="padding-bottom: 8px" valign="top">
        <td>
            <asp:Calendar ID="MyCalendar" TabIndex="-1" runat="server" Width="700px" Enabled="False" ForeColor="#515128" NextPrevFormat="FullMonth" BackColor="#FFFFD8" Font-Size="8pt" Font-Names="Verdana" BorderColor="CornflowerBlue" BorderWidth="1px" ShowGridLines="True" SelectionMode="None" ShowNextPrevMonth="False">
                <TodayDayStyle ForeColor="#512700" BackColor="#FFD7AA"></TodayDayStyle>
                <SelectorStyle Font-Size="5pt" Width="1%" BackColor="#D6E7FC"></SelectorStyle>
                <DayStyle Wrap="False" HorizontalAlign="Left" Height="52px" VerticalAlign="Top"></DayStyle>
                <NextPrevStyle Font-Size="10pt" ForeColor="White" VerticalAlign="Middle"></NextPrevStyle>
                <DayHeaderStyle Height="1px" ForeColor="#0000C0" BackColor="#D6E7FC"></DayHeaderStyle>
                <SelectedDayStyle Font-Bold="True" ForeColor="#0000C0" BackColor="#D6E7FC"></SelectedDayStyle>
                <TitleStyle Font-Size="10pt" Font-Bold="True" Height="20px" ForeColor="White" BackColor="CornflowerBlue"></TitleStyle>
                <WeekendDayStyle ForeColor="#400000" BackColor="#FFE7F4"></WeekendDayStyle>
                <OtherMonthDayStyle ForeColor="DimGray" BackColor="White"></OtherMonthDayStyle>
            </asp:Calendar>
        </td>
    </tr>
    <tr style="padding-bottom: 8px" valign="top">
        <td>
            <asp:Table ID="MyWeek" runat="server" Width="600px" Enabled="False" Visible="False" CssClass="Calendar">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="8" CssClass="CTitle">
                        <asp:Table runat="server" CssClass="Hide" ID="MyWeekTitle">
                            <asp:TableRow>
                                <%--         <asp:TableCell CssClass="CNextPrew">
                                    <asp:LinkButton runat="server" Enabled="False" ForeColor="White" ID="lbt_PriorWeek">上週</asp:LinkButton>
                                </asp:TableCell>--%>
                                <asp:TableCell CssClass="CTitle" Style="width: 90%;">
                                    <asp:Label runat="server" ID="lb_WeekTitle"></asp:Label>
                                </asp:TableCell>
                                <%--<asp:TableCell HorizontalAlign="Right" CssClass="CNextPrew">
                                    <asp:LinkButton runat="server" Enabled="False" ForeColor="White" ID="lbt_NextWeek">下週</asp:LinkButton>
                                </asp:TableCell>--%>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <witc:DWPanel ID="dwX" runat="server" Height="30px" Style="position: relative" Width="820px">
                <asp:Label ID="X1" Style="z-index: 0; left: 171px; position: absolute; top: 5px" runat="server" Width="15px" BackColor="#FFD7AA" BorderColor="Silver" BorderWidth="1px"></asp:Label>
                <asp:Label ID="X2" runat="server" BackColor="#FFFFD8" BorderColor="Silver" BorderWidth="1px" Style="left: 265px; position: absolute; top: 6px" Width="15px"></asp:Label>
                <asp:Label ID="X2_t" runat="server" Font-Size="13px" ForeColor="DimGray" Style="left: 296px; position: absolute; top: 8px">工作日</asp:Label>
                <asp:Label ID="X3" runat="server" BackColor="#FFE7F4" BorderColor="Silver" BorderWidth="1px" Style="left: 378px; position: absolute; top: 6px" Width="15px"></asp:Label>
                <asp:Label ID="X3_t" runat="server" Font-Size="13px" ForeColor="DimGray" Style="left: 409px; position: absolute; top: 8px">例假日</asp:Label>
                <asp:Label ID="X4" runat="server" BackColor="White" BorderColor="Silver" BorderWidth="1px" Style="left: 488px; position: absolute; top: 6px" Width="15px"></asp:Label>
                <asp:Label ID="X4_t" runat="server" Font-Size="13px" ForeColor="DimGray" Style="left: 519px; position: absolute; top: 8px">非本月</asp:Label>
                <asp:Label ID="X1_t" runat="server" Font-Size="13px" Style="left: 202px; position: absolute; top: 7px" ForeColor="DimGray">今天</asp:Label>
            </witc:DWPanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Table ID="MyShowDate" runat="server" Width="600px" Enabled="False" Visible="False" >
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="1">
                        <asp:Table runat="server" ID="Table2">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 90%;" Font-Size="11px">
                                    <asp:Label runat="server" ID="lb_DateTitle"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <asp:LinkButton ID="lbt_Change" runat="server"></asp:LinkButton></td>
    </tr>
</table>

<script type="text/javascript">
	function uf_Tip(as_Text, as_Title)
	{
		if (as_Title != "")
			Tip(as_Text, BGCOLOR, '#EFF7FF', BORDERCOLOR, 'CornflowerBlue', WIDTH, -500, TITLE, as_Title);
		else
			Tip(as_Text, BGCOLOR, '#EFF7FF', BORDERCOLOR, 'CornflowerBlue', WIDTH, -500);
	}
</script>

