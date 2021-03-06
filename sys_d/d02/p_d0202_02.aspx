﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0202_02.aspx.cs" Inherits="sys_d_d02_p_d0202_02" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="57px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="N" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 10px" Width="80px">*篩選條件：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 36px" Width="80px">志工代碼：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 30px" Text="列表" Width="56px" />
                                        &nbsp;
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 91px; position: absolute;
                                            top: 33px"></asp:TextBox>
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 270px; position: absolute; top: 36px" Width="80px">志工姓名：</asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server"  Style="left: 356px;
                                            position: absolute; top: 33px"></asp:TextBox>
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="left: 92px; position: absolute;
                                            top: 5px" Width="188px">
                                            <asp:ListItem>所有正式志工</asp:ListItem>
                                            <asp:ListItem Selected="True">符合可轉講師資格之志工</asp:ListItem>
                                            <asp:ListItem>本年度正式志工</asp:ListItem>
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 18px; width: 605px;">
                                    &nbsp; &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server">全選</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server">全不選</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 138px; width: 605px;">
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
                                               	<asp:TemplateColumn HeaderText="勾選">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Checkbox ID="dwG_CHECK" runat="server" CausesValidation="False" >
											</asp:Checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									             <asp:BoundColumn DataField="志工代碼" HeaderText="志工代碼" SortExpression="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工姓名" HeaderText="志工姓名" SortExpression="志工姓名"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工隊名稱" HeaderText="志工隊名稱" SortExpression="志工隊名稱"></asp:BoundColumn>
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
                                    <asp:Button ID="Button1" runat="server" Style="left: 264px; position: relative; top: 0px"
                                        Text="確定" Width="72px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 9px; width: 605px;">
                                    &nbsp;</td>
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
