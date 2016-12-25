<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0200_02.aspx.cs" Inherits="sys_g_g01_p_g0200_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>服務獎</title>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        &nbsp;
                                        <asp:Label ID="dwQ_score4_t" runat="server" CssClass="N" Style="z-index: 101;
                                            left: 192px; position: absolute; top: 12px" Width="123px">最低列表服務分數：</asp:Label>
                                        <asp:Label ID="dwQ_score1_t" runat="server" CssClass="Q" Style="z-index: 101;
                                            left: 378px; position: absolute; top: 12px" Width="19px">分</asp:Label>
                                        &nbsp;
                                        <asp:TextBox ID="dwQ_score4" runat="server" Style="left: 315px; position: absolute;
                                            top: 9px" Width="56px">90</asp:TextBox>
                                        <asp:Label ID="dwQ_year_t" runat="server" CssClass="N" Style="z-index: 101;
                                            left: 12px; position: absolute; top: 12px" Width="62px">年度：</asp:Label>
                                        <asp:TextBox ID="dwQ_year" runat="server" Style="left: 74px; position: absolute;
                                            top: 9px" Width="56px"></asp:TextBox>
                                        &nbsp; &nbsp;&nbsp; &nbsp;
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" OnClick="bt_Query_Click" Style="z-index: 114; left: 601px; position: absolute; top: 5px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Purple" Style="left: 0px; position: relative;
                                        top: 5px" Text="◎符合可申請志工服務獎志工"></asp:Label></td>
                                <tr>
                                    <td>
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
                                                                TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="hle501_score4" HeaderText="分數" SortExpression="hle501_score4"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="hle501_ps" HeaderText="備註" SortExpression="hle501_ps"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </witc:ScrollGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 50px;">
                                        <asp:Button ID="Bt_Print" runat="server" CssClass="Bt_Print" OnClick="Bt_Print_Click" Style="left: 323px; position: relative; top: 0px" /></td>
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
