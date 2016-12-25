<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0102.aspx.cs" Inherits="sys_f_f01_p_f0102" %>

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
                                <td style="height: 35px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="60px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 11px" Width="80px" ForeColor="Blue">開課代碼：</asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 36px" Width="80px">開課時間：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 238px; position: absolute; top: 11px" Width="80px">授課人：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 8px" Text="查詢" Width="56px" />
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 318px; position: absolute;
                                            top: 8px" Width="175px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 87px; position: absolute;
                                            top: 8px" Width="114px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 87px; position: absolute;
                                            top: 33px" Width="114px"></asp:TextBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 83px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="260px" Style="position: relative;
                                        left: 0px; top: 0px;" Width="800px">
                                        <br />
                                        <br />
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 14px; position: absolute; top: 7px">課程主檔代碼： C097_0001</asp:Label>
                                        <asp:Label ID="Label7" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 133px">訓練代碼： T097_0001_01</asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 30px">課程名稱：  基本餵魚教學</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 46px; position: absolute; top: 156px">*授課人：</asp:Label>
                                        <asp:Label ID="Label8" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 279px; position: absolute; top: 180px">～</asp:Label>
                                        <asp:Label ID="Label16" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 211px; position: absolute; top: 234px">～</asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 180px">*開課時間：</asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 207px">*授課地點：</asp:Label>
                                        <asp:Label ID="Label15" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 233px">*開放報名時間：</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 53px">課程類別：  在職訓練</asp:Label>
                                        <asp:Label ID="Label11" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 247px; position: absolute; top: 30px">參加人設定：  全部</asp:Label>
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 76px">報名方式：  強制參加</asp:Label>
                                        <asp:Label ID="Label13" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 99px">課程時數：  3  小時</asp:Label>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 260px; position: absolute; top: 99px">及格分數：  60  分</asp:Label>
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 107px; position: absolute;
                                            top: 153px" Width="119px">海公公</asp:TextBox>
                                        <asp:TextBox ID="TextBox5" runat="server" Style="left: 126px; position: absolute;
                                            top: 204px" Width="119px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 227px; position: absolute;
                                            top: 177px" Width="41px">09:00</asp:TextBox>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 304px; position: absolute;
                                            top: 177px" Width="41px">12:00</asp:TextBox>
                                        <hr style="z-index: 129; left: 0px; position: absolute; top: 122px" />
                                        <asp:Panel ID="dwQ_edate" runat="server" CssClass="G" Style="z-index: 109; left: 107px;
                                            position: absolute; top: 178px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date4" runat="server" />
                                        </asp:Panel><asp:Panel ID="Panel1" runat="server" CssClass="G" Style="z-index: 109; left: 107px;
                                            position: absolute; top: 232px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="U_DateSelect_ROC1" runat="server" />
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" CssClass="G" Style="z-index: 109; left: 231px;
                                            position: absolute; top: 232px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="U_DateSelect_ROC2" runat="server" />
                                        </asp:Panel>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Style="z-index: 129; left: 250px;
                                            position: absolute; top: 201px" RepeatDirection="Horizontal" ForeColor="Blue">
                                            <asp:ListItem Selected="True">魚池邊</asp:ListItem>
                                            <asp:ListItem>志工教室A</asp:ListItem>
                                            <asp:ListItem>志工教室B</asp:ListItem>
                                            <asp:ListItem>志工休息室</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;
                                        <asp:RadioButton ID="RadioButton1" runat="server" Style="z-index: 129; left: 105px;
                                            position: absolute; top: 205px" />
                                        <asp:Button ID="Button4" runat="server" CssClass="B" Style="z-index: 129; left: 407px;
                                            position: absolute; top: 4px" Text="尋找課程主檔" Width="116px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px;
                                        top: 0px;" Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="刪除" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="清除" Width="55px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 605px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="100px" Width="800px"
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
                                                <asp:BoundColumn DataField="訓練代碼" HeaderText="訓練代碼" SortExpression="訓練代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="訓練名稱" HeaderText="訓練名稱" SortExpression="訓練名稱"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="訓練類別" HeaderText="訓練類別" SortExpression="訓練類別"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="參加別" HeaderText="參加別" SortExpression="參加別"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="地點" HeaderText="地點" SortExpression="地點"></asp:BoundColumn>
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
    </form>
</body>
</html>
