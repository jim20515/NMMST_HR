<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_DateSelect.aspx.cs" Inherits="proj_uctrl_p_DateSelect" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>選擇日期</title>
	<base target="_self" />
	<meta content="no-cache" http-equiv="Pragma" />
</head>
<body style="background-color: #e8f0ff">
    <form id="form1" runat="server">
    <div>
		<asp:Label ID="lb_Year_t" runat="server" Font-Size="13px" ForeColor="#0000c0" Style="z-index: 101; left: 4px; position: absolute; top: 8px">西元年：</asp:Label>
		<asp:DropDownList ID="ddl_Year" runat="server" AutoPostBack="True" Font-Size="13px" Style="z-index: 102; left: 56px; position: absolute; top: 5px" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged"></asp:DropDownList>
		<asp:Label ID="lb_Month_t" runat="server" Font-Size="13px" ForeColor="#0000c0" Style="z-index: 103; left: 124px; position: absolute; top: 8px">月：</asp:Label>
		<asp:DropDownList ID="ddl_Month" runat="server" AutoPostBack="True" Font-Size="13px" Style="z-index: 104; left: 148px; position: absolute; top: 5px" Width="44px" OnSelectedIndexChanged="ddl_Month_SelectedIndexChanged">
			<asp:ListItem Value="1">1</asp:ListItem>
			<asp:ListItem Value="2">2</asp:ListItem>
			<asp:ListItem Value="3">3</asp:ListItem>
			<asp:ListItem Value="4">4</asp:ListItem>
			<asp:ListItem Value="5">5</asp:ListItem>
			<asp:ListItem Value="6">6</asp:ListItem>
			<asp:ListItem Value="7">7</asp:ListItem>
			<asp:ListItem Value="8">8</asp:ListItem>
			<asp:ListItem Value="9">9</asp:ListItem>
			<asp:ListItem Value="10">10</asp:ListItem>
			<asp:ListItem Value="11">11</asp:ListItem>
			<asp:ListItem Value="12">12</asp:ListItem>
		</asp:DropDownList>
		<asp:Calendar ID="MyCalendar" runat="server" BackColor="#deffff" BorderColor="#0000c0" BorderWidth="1px" Font-Names="Verdana" Font-Size="11px" ForeColor="#0000c0" Height="180px" NextPrevFormat="FullMonth" ShowGridLines="True" Style="z-index: 105; left: 4px; position: absolute; top: 32px" Width="216px" OnDayRender="MyCalendar_DayRender" OnSelectionChanged="MyCalendar_SelectionChanged" OnVisibleMonthChanged="MyCalendar_VisibleMonthChanged">
			<TodayDayStyle BackColor="CornflowerBlue" ForeColor="White" />
			<SelectorStyle BackColor="#FFCC66" />
			<NextPrevStyle Font-Size="8px" ForeColor="White" VerticalAlign="Middle" />
			<DayHeaderStyle BackColor="#C0FFC0" Height="1px" Width="24px" />
			<SelectedDayStyle BackColor="#C0FFC0" Font-Bold="True" ForeColor="#0000C0" />
			<TitleStyle BackColor="CornflowerBlue" Font-Bold="True" Font-Size="12px" ForeColor="White" Height="20px" />
			<WeekendDayStyle BackColor="#FFDDFF" ForeColor="Red" />
			<OtherMonthDayStyle ForeColor="Orange" />
		</asp:Calendar>
		<asp:LinkButton ID="lbt_Today" runat="server" Font-Size="11px" Style="z-index: 106; left: 196px; position: absolute; top: 9px" Width="28px" OnClick="lbt_Today_Click">今天</asp:LinkButton>
	</div>
    </form>
</body>
</html>
