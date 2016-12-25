<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0103.aspx.cs" Inherits="sys_e_e01_p_e0103" %>

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
                                <td style="height: 43px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 10px" Width="80px" ForeColor="Blue">志工隊：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 282px; position: absolute; top: 10px" Width="80px">查詢日期：</asp:Label>
                                        <asp:Label ID="Label22" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 412px; position: absolute; top: 9px" Width="18px">年</asp:Label>
                                        <asp:Label ID="Label23" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 480px; position: absolute; top: 9px" Width="18px">月</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 7px" Text="查詢" Width="56px" />
                                        &nbsp;
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 368px; position: absolute;
                                            top: 7px" Width="33px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 438px; position: absolute;
                                            top: 6px" Width="33px"></asp:TextBox>
                                        <asp:DropDownList ID="DropDownList7" runat="server" Style="left: 86px; position: absolute;
                                            top: 6px">
                                            <asp:ListItem>行政志工</asp:ListItem>
                                            <asp:ListItem>技術志工</asp:ListItem>
                                            <asp:ListItem>導覽及活動志工</asp:ListItem>
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Purple" Style="font-size: 16pt"
                                        Text="◎行政志工隊097年11月排班表"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 83px; width: 605px;">
                                    <img src="../../proj_img/calendar3.bmp" /></td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    <%--<asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px; top: 0px;"
                                        Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="刪除" Width="55px" />--%>
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 279px; top: 2px;"
                                        Text="列印" Width="55px" />
                                 
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
                                                <asp:BoundColumn DataField="志工隊" HeaderText="志工隊" SortExpression="志工隊"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="年" HeaderText="年" SortExpression="年"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="月" HeaderText="月" SortExpression="月"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="班次" HeaderText="班次" SortExpression="班次"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="人次" HeaderText="人次" SortExpression="人次"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="開放" HeaderText="開放" SortExpression="開放"></asp:BoundColumn>--%>
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
