<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0101_new_02.aspx.cs" Inherits="sys_d_d01_p_d0101_new_02" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>專案計劃</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    </script>

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
                                <td style="height: 64px; width: 607px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="60px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_ybar_t" runat="server" CssClass="I" Style="z-index: 105;
                                            left: 26px; position: absolute; top: 23px" Width="100px">志工代號：</asp:Label>
                                        <asp:TextBox ID="dwF_ema11_ybar" runat="server" CssClass="G" Style="z-index: 108;
                                            left: 129px; position: absolute; top: 20px" Width="80px"></asp:TextBox>
                                        <asp:Label ID="dwF_ema11_code_amt_t" runat="server" CssClass="I" Style="z-index: 113;
                                            left: 238px; position: absolute; top: 23px" Width="68px">志工姓名：</asp:Label>
                                        <asp:TextBox ID="dwF_ema11_code_amt" runat="server" CssClass="G" MaxLength="100"
                                            Style="z-index: 118; left: 309px; position: absolute; top: 20px" Width="135px"></asp:TextBox>
                                        <asp:Button ID="Button3" runat="server" Style="z-index: 123; left: 497px; position: absolute;
                                            top: 20px" Text="查詢" Width="70px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td style="height: 5px; width: 607px;">
                                </td>
                            </tr>
--%>
                            <%--                           <tr>
                                <td style="height: 120px; width: 607px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="108px" Style="position: relative;
                                        left: 1px; top: 4px;" Width="599px">
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_ybar_t" runat="server" CssClass="N" Style="z-index: 105;
                                            left: 6px; position: absolute; top: 8px" Width="100px">預算年度：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="dwF_ema11_ybar" runat="server" CssClass="G" Style="z-index: 108;
                                            left: 109px; position: absolute; top: 5px" Width="80px"></asp:TextBox>
                                        &nbsp;
                                        <asp:Label ID="dwF_ema11_ec01code_t" runat="server" CssClass="N" Style="z-index: 109;
                                            left: 241px; position: absolute; top: 8px" Width="100px">工程科目：</asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_ema11_code_amt_t" runat="server" CssClass="N" Style="z-index: 113;
                                            left: 6px; position: absolute; top: 36px" Width="100px">預算金額：</asp:Label>
                                        &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="dwF_ema11_code_amt" runat="server" CssClass="G" MaxLength="100"
                                            Style="z-index: 118; left: 109px; position: absolute; top: 33px" Width="80px"></asp:TextBox>
                                        <asp:Label ID="dwF_aec01_user_t" runat="server" CssClass="D" Style="z-index: 123;
                                            left: 5px; position: absolute; top: 86px" Width="100px">異動人員：</asp:Label>
                                        <asp:Label ID="dwF_ema11_user" runat="server" CssClass="G" Style="z-index: 124; left: 109px;
                                            position: absolute; top: 86px"></asp:Label>
                                        <asp:Label ID="dwF_aec01_date_t" runat="server" CssClass="D" Style="z-index: 125;
                                            left: 261px; position: absolute; top: 86px" Width="80px">異動時間：</asp:Label>
                                        <asp:Label ID="dwF_ema11_date" runat="server" CssClass="G" Style="z-index: 126; left: 345px;
                                            position: absolute; top: 86px"></asp:Label>
                                        <asp:Label ID="dwF_ema11_ec03code_t" runat="server" CssClass="N" Style="z-index: 113;
                                            left: 241px; position: absolute; top: 36px" Width="100px">資金來源：</asp:Label>
                                        <asp:DropDownList ID="dwF_ema11_ec01code" runat="server" Style="z-index: 108; left: 345px;
                                            position: absolute; top: 5px" CssClass="D" DataMember="aec01" Width="172px">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dwF_ema11_ec03code" runat="server" Style="z-index: 108; left: 345px;
                                            position: absolute; top: 33px" CssClass="D" DataMember="aec03" Width="172px">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwF_aema11_ec03code_ps_t" runat="server" CssClass="D" Style="z-index: 123;
                                            left: 195px; position: absolute; top: 36px" Width="17px">元</asp:Label>
                                        <asp:Label ID="total_t" runat="server" CssClass="D" Style="z-index: 123; left: 11px;
                                            position: absolute; top: 60px" Width="95px">該年度總金額：</asp:Label>
                                    </witc:DWPanel>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="height: 4px; width: 607px;">
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="position: relative; height: 9px; width: 607px;">
                                    <div style="position: relative; float: right; left: 0px; top: 0px;" id="DIV1" onclick="return DIV1_onclick()">
                                        <uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="height: 4px; width: 607px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 607px">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="200px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1" OnSelectedIndexChanged="dgG_SelectedIndexChanged">
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="志工代號">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CommandName="Select" Text='<%# DataBinder.Eval(Container, "DataItem.志工代號") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="志工姓名" HeaderText="志工姓名" SortExpression="志工姓名"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
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
