<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0302_01.aspx.cs" Inherits="sys_f_f03_p_f0302_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查詢及清單</title>
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
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                </td>
                            </tr>
                          
                        
                           
                                <td style="height: 16px; width: 605px;">
                                </td>
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
                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="課名" HeaderText="課名" SortExpression="課名"></asp:BoundColumn>
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
