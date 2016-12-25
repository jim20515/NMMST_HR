<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0101.aspx.cs" Inherits="sys_c_c01_p_c0101" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
                                <td style="height: 35px; width: 604px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 4px; position: absolute; top: 10px" Width="104px" ForeColor="Blue">博物館之友代碼：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 258px; position: absolute; top: 10px" Width="104px">博物館之友姓名：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 7px" Text="查詢" Width="56px" />
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 109px; position: absolute;
                                            top: 7px" Width="143px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 368px; position: absolute;
                                            top: 7px"></asp:TextBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 108px; width: 604px;">
                                    <asp:Label ID="Label18" runat="server" ForeColor="Purple" Style="left: 1px; position: relative;
                                        top: 7px" Text="◎基本資料"></asp:Label>
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="339px" Style="position: relative;
                                        left: 3px; top: 11px;" Width="800px">
                                        &nbsp;
                                        <asp:Label ID="Label7" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: -7px; position: absolute; top: 7px" Width="126px">博物館之友代碼：</asp:Label>
                                        <asp:Label ID="Label19" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 121px; position: absolute; top: 7px; text-align: left" Width="118px">F097-00000001</asp:Label>
                                        <asp:Label ID="Label2" runat="server" CssClass="N" Style="z-index: 109; left: 37px;
                                            position: absolute; top: 33px" Width="80px">*會員姓名：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 60px" Width="80px">性別：</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 86px" Width="80px">生日：</asp:Label>
                                        <asp:Label ID="Label8" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 136px" Width="80px">職業：</asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 111px" Width="80px">學歷：</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 163px" Width="80px">通訊地址：</asp:Label>
                                        <asp:Label ID="Label11" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 190px" Width="80px">E-mail：</asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 190px" Width="80px">E-mail：</asp:Label>
                                        <asp:Label ID="Label15" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 214px" Width="80px">服務單位：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label17" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 240px" Width="80px">備註：</asp:Label>
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 326px; position: absolute; top: 65px" Width="80px">工作電話：</asp:Label>
                                        <asp:Label ID="Label13" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 326px; position: absolute; top: 89px" Width="80px">住址電話：</asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 326px; position: absolute; top: 112px" Width="80px">行動電話：</asp:Label>
                                        &nbsp; &nbsp;
                                        <br />
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 121px; position: absolute;
                                            top: 30px" Width="117px">王博友</asp:TextBox>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 120px; position: absolute;
                                            top: 211px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox11" runat="server" Font-Bold="True" Height="35px" Style="left: 118px;
                                            position: absolute; top: 238px; font-weight: normal;" Width="277px">股市大亨</asp:TextBox>
                                        <asp:Label ID="Label16" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 285px" Width="80px">重要事蹟：</asp:Label>
                                        <asp:TextBox ID="TextBox16" runat="server" Font-Bold="True" Height="35px" Style="left: 118px;
                                            position: absolute; top: 283px; font-weight: normal;" Width="277px">捐了一條活跳跳的大白鯊</asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 121px; position: absolute;
                                            top: 83px" Width="117px">083/11/11</asp:TextBox>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox9" runat="server" Style="left: 406px; position: absolute;
                                            top: 85px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox15" runat="server" Style="left: 406px; position: absolute;
                                            top: 58px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox10" runat="server" Style="left: 406px; position: absolute;
                                            top: 110px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox12" runat="server" Style="left: 406px; position: absolute;
                                            top: 134px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox5" runat="server" Style="left: 248px; position: absolute;
                                            top: 161px" Width="223px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 121px; position: absolute;
                                            top: 187px" Width="226px"></asp:TextBox>
                                        &nbsp;&nbsp;<br />
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                                            Style="left: 119px; position: relative; top: 28px">
                                            <asp:ListItem Selected="True">男</asp:ListItem>
                                            <asp:ListItem>女</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp; &nbsp;
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="left: 121px; position: absolute;
                                            top: 134px" Width="105px">
                                            <asp:ListItem>公教會員</asp:ListItem>
                                            <asp:ListItem>醫生</asp:ListItem>
                                            <asp:ListItem>律師</asp:ListItem>
                                            <asp:ListItem Selected="True">服務業</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 323px; position: absolute; top: 137px" Width="80px">職稱：</asp:Label>
                                        &nbsp;
                                        <asp:DropDownList ID="DropDownList2" runat="server" Style="left: 121px; position: absolute;
                                            top: 108px" Width="105px">
                                            <asp:ListItem>小學</asp:ListItem>
                                            <asp:ListItem>國中</asp:ListItem>
                                            <asp:ListItem>大學</asp:ListItem>
                                            <asp:ListItem Selected="True">研究所</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList3" runat="server" Style="left: 121px; position: absolute;
                                            top: 162px" Width="127px">
                                            <asp:ListItem Selected="True">105台北市松山區</asp:ListItem>
                                            <asp:ListItem>551台北市南港區</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px; height: 18px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 15px; width: 604px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px; top: 0px;"
                                        Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="刪除" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="清除" Width="55px" />
                                 
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 604px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="150px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1">
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <%--	<asp:TemplateColumn HeaderText="勾選">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Checkbox ID="dwG_CHECK" runat="server" CausesValidation="False" >
											</asp:Checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>--%>
                                                <asp:BoundColumn DataField="博物館之友代碼" HeaderText="博物館之友代碼" SortExpression="博物館之友代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="博物館之友姓名" HeaderText="博物館之友姓名" SortExpression="博物館之友姓名"></asp:BoundColumn>
                                                
                                                <%--<asp:BoundColumn DataField="支票開立日期" HeaderText="支票開立日期" SortExpression="支票開立日期"  ></asp:BoundColumn>	
									<asp:BoundColumn DataField="受(繳)款人" HeaderText="受(繳)款人" SortExpression="受(繳)款人" ></asp:BoundColumn>	
									<asp:BoundColumn DataField="支票金額" HeaderText="支票金額" SortExpression="支票金額" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	
									<asp:BoundColumn DataField="支票兌現到期日" HeaderText="支票兌現到期日" SortExpression="支票兌現到期日"  ></asp:BoundColumn>		
									<asp:BoundColumn DataField="劃線" HeaderText="劃線" SortExpression="劃線" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	
									<asp:BoundColumn DataField="禁背" HeaderText="禁背" SortExpression="禁背" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	
									<asp:BoundColumn DataField="郵寄日期" HeaderText="郵寄日期" SortExpression="郵寄日期" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	--%>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 604px;">
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
