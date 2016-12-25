<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_s0303.aspx.cs" Inherits="sys_s_s03_p_s0303" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="80px" Style="position: relative" Width="820px">
                            <asp:Label ID="delete_time_s_t" runat="server" CssClass="N" Style="z-index: 104; left:6px; position: absolute; top:8px" Width="100px">刪除區間：</asp:Label>
							<asp:Panel ID="delete_time_s" runat="server" CssClass="G" Style="z-index: 99; left: 107px; position: absolute; top: 4px" Width="132px">
							    <uc1:u_DateSelect_ROC ID="u_Date1" runat="server"/>
						    </asp:Panel>
						    <asp:Label ID="Label1" runat="server" CssClass="Q" Style="z-index: 104; left:210px; position: absolute; top:8px" Width="20px">～</asp:Label>
							<asp:Panel ID="delete_time__e" runat="server" CssClass="G" Style="z-index: 99; left: 240px; position: absolute; top: 4px" Width="132px">
							    <uc1:u_DateSelect_ROC ID="u_Date2" runat="server"/>
						    </asp:Panel>
						    <asp:Label ID="delete_type_t" runat="server" CssClass="Q" Style="z-index: 104; left:400px; position: absolute; top:8px" Width="100px">刪除類型：</asp:Label>
                            <asp:RadioButtonList ID="delete_type" runat="server" CssClass="G" RepeatColumns="1" Style="z-index: 104; left: 500px; position: absolute; top: 4px">
                                <asp:ListItem Selected="True" Value="1">全部</asp:ListItem>
                                <asp:ListItem Value="2">登入登出紀錄</asp:ListItem>
                                <asp:ListItem Value="3">操作紀錄</asp:ListItem>
                            </asp:RadioButtonList>
							<asp:Button ID="bt_Delete" runat="server" CssClass="Bt_Del" Style="z-index: 999; left:680px; position: absolute; top:40px" Text="" Width="80px" OnClick="bt_Delete_Click"/>
						</witc:DWPanel>
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
