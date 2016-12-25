<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0301.aspx.cs" Inherits="sys_f_f03_p_f0301" %>

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
                                        &nbsp;
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 8px" Width="80px">代碼：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 30px" Text="查詢" Width="56px" />
                                        &nbsp;
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 91px; position: absolute;
                                            top: 5px"></asp:TextBox>
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 270px; position: absolute; top: 8px" Width="80px">授課人：</asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server"  Style="left: 356px;
                                            position: absolute; top: 5px"></asp:TextBox>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 34px" Width="80px">開課時間：</asp:Label>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 91px; position: absolute;
                                            top: 31px"></asp:TextBox>
                                        <asp:Label ID="Label4" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 270px; position: absolute; top: 34px" Width="80px">課名：</asp:Label>
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 356px; position: absolute;
                                            top: 31px"></asp:TextBox>
                                        &nbsp;
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
                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label5" runat="server" Text="◎基本養魚教學(T097_0001_01)成績單" ForeColor="Purple"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 138px; width: 605px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="150px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1" OnSelectedIndexChanged="dgG_SelectedIndexChanged">
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
                                               	<%--<asp:TemplateColumn HeaderText="勾選">
										<HeaderStyle Width="30px" />
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Checkbox ID="dwG_CHECK" runat="server" CausesValidation="False" >
											</asp:Checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>--%>
									             <asp:BoundColumn DataField="志工代碼" HeaderText="志工代碼" SortExpression="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工姓名" HeaderText="志工姓名" SortExpression="志工姓名"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="成績" HeaderText="成績" SortExpression="成績"></asp:BoundColumn>--%>
                                                <asp:TemplateColumn HeaderText="成績">
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dgG_ema11_ec01code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.成績") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <%--<asp:BoundColumn DataField="備註" HeaderText="備註" SortExpression="備註"></asp:BoundColumn>--%>
                                                <asp:TemplateColumn HeaderText="備註">
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dgG_ema11_ec01code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.備註") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                    &nbsp;
                                    <asp:Button ID="Button1" runat="server" Style="left: 492px; position: relative; top: 1px"
                                        Text="列印整班成績" Width="93px" />
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="left: 325px;
                                        position: relative; top: 2px" Text="確定" Width="64px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 9px; width: 605px;">
                                    &nbsp;</td>
                            </tr>
                        </table><asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="594px" TabIndex="1" Height="84px">
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
                                <asp:BoundColumn DataField="課名" HeaderText="志工姓名" SortExpression="志工姓名"></asp:BoundColumn>
                                <asp:BoundColumn DataField="日期" HeaderText="日期" SortExpression="日期"></asp:BoundColumn>
                                <asp:BoundColumn DataField="時間" HeaderText="時間" SortExpression="時間"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="修課人數" HeaderText="修課人數" SortExpression="修課人數"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="是否登錄成績" HeaderText="是否登錄成績" SortExpression="是否登錄成績"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="是否核定" HeaderText="是否核定" SortExpression="是否核定"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid></asp:Panel>
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
