<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0201.aspx.cs" Inherits="sys_e_e02_p_e0201" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
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
					<td style="height: 35px; width: 605px;">
						<witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="96px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
							<asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="Q" Style="z-index: 101; left: 7px; position: absolute; top: 10px" Width="100px" ForeColor="Blue">志工代碼：</asp:Label>
                            
							<asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 448px; position: absolute; top: 61px" Text="查詢" Width="56px" />
                            &nbsp; &nbsp;
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="G" Style="z-index: 108; left: 111px;
                                position: absolute; top: 7px" Width="100px"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" CssClass="Q" ForeColor="Blue" Style="z-index: 101;
                                left: 233px; position: absolute; top: 10px" Width="100px">志工姓名：</asp:Label>
                        
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="G" Style="z-index: 108; left: 337px;
                                position: absolute; top: 7px" Width="100px"></asp:TextBox>
                            <asp:Label ID="dwF_s07_pdate_t" runat="server" CssClass="N" Style="z-index: 113;
                                left: 7px; position: absolute; top: 59px" Width="100px">收入申請日期：</asp:Label>
                            <asp:Label ID="Label9" runat="server" CssClass="I" Style="z-index: 113; left: 7px;
                                position: absolute; top: 35px" Width="100px" ForeColor="Blue">志工隊：</asp:Label>
                            &nbsp;&nbsp;
                            <asp:Panel ID="dwQ_edate" runat="server" CssClass="G" Style="z-index: 109; left: 248px; position: absolute; top: 58px" Width="132px" TabIndex="4">
								<uc1:u_DateSelect_ROC ID="u_Date4" runat="server" OnLoad="u_Date4_Load" />
							</asp:Panel>
                            <asp:Label style="Z-INDEX: 115; LEFT: 220px; POSITION: absolute; TOP: 61px" id="dwF_s07_edate_t" runat="server" Width="18px" CssClass="Q">～</asp:Label>
                             <asp:Panel ID="dwQ_sdate" runat="server" CssClass="G" Style="z-index: 109; left: 112px; position: absolute; top: 58px" Width="132px" TabIndex="3">
								<uc1:u_DateSelect_ROC ID="U_DateSelect_ROC1" runat="server" />
							</asp:Panel>
                            <asp:DropDownList ID="DropDownList3" runat="server" Style="left: 111px; position: absolute;
                                top: 32px">
                                <asp:ListItem>行政志工</asp:ListItem>
                                <asp:ListItem>技術志工</asp:ListItem>
                                <asp:ListItem>活動及導覽志工</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 5px; width: 605px;">
					</td>
				</tr>
				<tr>
					<td style="height: 195px; width: 605px;">
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="213px" Style="position: relative; left: 3px; top: 10px;" Width="800px">
                            &nbsp;
                            <asp:Label ID="Label21" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 9px; position: absolute; top: 37px" Width="100px">記錄日期：</asp:Label>
                            <asp:Label ID="Label1" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 9px; position: absolute; top: 64px" Width="100px">刷卡種類：</asp:Label>
                            <asp:Label ID="Label4" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 9px; position: absolute; top: 89px" Width="100px">刷卡時間：</asp:Label>
                            <asp:Label ID="Label11" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 9px; position: absolute; top: 112px" Width="100px">備註：</asp:Label>
                            <asp:Label ID="Label5" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 9px; position: absolute; top: 170px" Width="100px">是否取消：</asp:Label>
                            <asp:Label ID="Label7" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 142px; position: absolute; top: 88px" Width="12px">：</asp:Label>
                            <asp:Label ID="Label3" runat="server" CssClass="N" ForeColor="Blue" Height="16px"
                                Style="z-index: 113; left: 288px; position: absolute; top: 65px" Width="100px">刷卡機：</asp:Label>
                            &nbsp;
                            &nbsp;&nbsp;
                            <asp:Panel ID="Panel2" runat="server" CssClass="G" Style="z-index: 109; left: 112px; position: absolute; top: 35px" Width="132px" TabIndex="4">
                                <uc1:u_DateSelect_ROC ID="U_DateSelect_ROC3" runat="server" />
                            </asp:Panel>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Label ID="dwF_aec02_name_t" runat="server" CssClass="D" Style="z-index: 109;
                                left: 9px; position: absolute; top: 10px" Width="100px" ForeColor="Blue">志工代碼：</asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" CssClass="D" Style="z-index: 123; left: 9px;
                                position: absolute; top: 195px" Width="100px" ForeColor="Gray">異動人員：</asp:Label>
                           
							<asp:Label ID="dwF_aec02_user" runat="server" CssClass="G" Style="z-index: 124; left: 109px; position: absolute; top: 195px" ForeColor="Gray"></asp:Label>
							<asp:Label ID="dwF_aec02_date_t" runat="server" CssClass="D" Style="z-index: 125; left: 290px; position: absolute; top: 195px" Width="80px" ForeColor="Gray">異動時間：</asp:Label>
							<asp:Label ID="dwF_aec02_date" runat="server" CssClass="G" Style="z-index: 126; left: 372px; position: absolute; top: 195px" ForeColor="Gray"></asp:Label>
                            &nbsp;<br />
                            <br />
                            &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="G" Style="z-index: 108; left: 112px;
                                position: absolute; top: 7px" Width="63px"></asp:TextBox>
                            <asp:TextBox ID="TextBox11" runat="server" CssClass="G" Style="z-index: 108; left: 183px;
                                position: absolute; top: 7px" Width="63px"></asp:TextBox>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="G" Style="z-index: 108; left: 389px;
                                position: absolute; top: 62px" Width="63px"></asp:TextBox>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="G" Style="z-index: 108; left: 112px;
                                position: absolute; top: 85px" Width="24px"></asp:TextBox>
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="G" Style="z-index: 108; left: 158px;
                                position: absolute; top: 85px" Width="24px"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="G" Style="z-index: 108; left: 111px;
                                position: absolute; top: 109px" Width="333px" Height="50px"></asp:TextBox>
                            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" Text="Q" Style="z-index: 123;
                                            left: 255px; position: absolute; top: 6px" Width="27px" OnClick="Button4_Click" />
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                Style="left: 104px; position: absolute; top: 58px">
                                <asp:ListItem>上班</asp:ListItem>
                                <asp:ListItem>下班</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:CheckBox ID="CheckBox1" runat="server" Style="left: 108px; position: absolute;
                                top: 168px" />
                             </witc:DWPanel>
                             
					</td>
				</tr>
				<tr>
					<td style="width: 605px;">
                        <br />
					</td>
				</tr>
				<tr>
					<td style="position: relative; height: 31px; width: 605px;">
						<%--<asp:Button ID="Button2" runat="server" CssClass="B" Style="z-index: 114; left: 379px; position: absolute; top: 3px" Text="列印" Width="50px" OnClick="Button2_Click" />
						<asp:Button ID="Button3" runat="server" CssClass="B" Style="z-index: 114; left: 437px; position: absolute; top: 3px" Text="新增" Width="50px" />--%>
                        <asp:Button ID="Button5" runat="server" CssClass="B" Style="z-index: 114; left: 478px; position: absolute; top: 3px" Text="手動補登" Width="68px" />
                        <asp:Button ID="Button6" runat="server" CssClass="B" Style="z-index: 114; left: 550px; position: absolute; top: 3px" Text="清除" Width="50px" />
					</td>
				</tr>
				<tr>
					<td style="height: 4px; width: 605px;">
					</td>
				</tr>
				<tr>
					<td style="height: 215px; width: 605px;">
						<witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="200px" Width="800px" AJAXScript="Yes">
                            <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="780px" TabIndex="1" OnSelectedIndexChanged="dgG_SelectedIndexChanged">
								<SelectedItemStyle CssClass="Grid_Select" />
								<ItemStyle CssClass="Grid_Detail" />
								<HeaderStyle CssClass="Grid_Head" />
								<FooterStyle CssClass="Grid_Footer" />
								<Columns>
									<asp:TemplateColumn HeaderText="序號">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
											</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<%--<asp:TemplateColumn HeaderText="勾選">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Checkbox ID="dwG_CHECK" runat="server" CausesValidation="False" >
											</asp:Checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>--%>
									
									<asp:BoundColumn DataField="志工代碼" HeaderText="志工代碼" SortExpression="志工代碼"></asp:BoundColumn>	
									<asp:BoundColumn DataField="姓名" HeaderText="姓名" SortExpression="姓名"></asp:BoundColumn>	
									<asp:BoundColumn DataField="記錄日期" HeaderText="記錄日期" SortExpression="記錄日期"></asp:BoundColumn>	
									<asp:BoundColumn DataField="種類" HeaderText="種類" SortExpression="種類" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	
									<asp:BoundColumn DataField="刷卡時間" HeaderText="刷卡時間" SortExpression="刷卡時間" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	
									<asp:BoundColumn DataField="補登方式" HeaderText="補登方式" SortExpression="補登方式" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	
									<asp:BoundColumn DataField="是否取消" HeaderText="是否取消" SortExpression="是否取消" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>			
									<%--<asp:BoundColumn DataField="保固年限" HeaderText="保固年限" SortExpression="保固年限" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	--%>
									<%--<asp:BoundColumn DataField="銀行帳號" HeaderText="銀行帳號" SortExpression="銀行帳號" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	--%>
									
									 

								</Columns>
							</asp:DataGrid>
						</witc:ScrollGrid>
					</td>
				</tr>
				<tr>
					<td style="height: 8px; width: 605px;">
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
        &nbsp;
	</form>
    

    
</body>
</html>