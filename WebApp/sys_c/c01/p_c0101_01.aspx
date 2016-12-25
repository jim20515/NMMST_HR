<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0101_01.aspx.cs" Inherits="sys_c_c01_p_c0101_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
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
                                <td style="height: 35px; width: 604px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="237px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_hmc101_id_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 10px" Width="80px" >成員代碼：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_type_t" runat="server" CssClass="Q"  Style="z-index: 101; left: 4px; position: absolute; top: 93px" Width="80px">分類：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_cname_t" runat="server" CssClass="Q"  Style="z-index: 101; left: 266px; position: absolute; top: 10px" Width="104px">成員姓名：</asp:Label>
										<asp:Label ID="dwQ_hmc101_joborg_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 36px" Width="80px">服務單位：</asp:Label>
										<asp:TextBox ID="dwQ_hmc101_joborg" runat="server" CssClass="G" Style="left: 87px; position: absolute; top: 33px" Width="143px"></asp:TextBox>
										<asp:Label ID="dwQ_hmc101_type1_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 63px" Width="80px">成員分類：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_type1" AutoPostBack="TRUE" OnSelectedIndexChanged="dwQ_hmc101_type1_SelectedIndexChanged" runat="server" CssClass="G" Style="left: 87px; position: absolute; top: 59px" Width="143px">
											<asp:ListItem Selected="True" Value="Y">已分類</asp:ListItem>
											<asp:ListItem Value="N">未分類</asp:ListItem>
										</asp:DropDownList>
										<asp:Label ID="dwQ_hmc101_stop_c_t" runat="server" CssClass="Q" Style="z-index: 101; left: 266px; position: absolute; top: 64px" Width="104px">成員停用：</asp:Label>
										<asp:DropDownList ID="dwQ_hmc101_stop_c" runat="server" CssClass="G" Style="left: 368px; position: absolute; top: 60px" Width="143px">
											<asp:ListItem Value="ALL">全部</asp:ListItem>
											<asp:ListItem Value="Y">停用</asp:ListItem>
											<asp:ListItem Selected="True" Value="N">未停用</asp:ListItem>
										</asp:DropDownList>
                                        <asp:TextBox ID="dwQ_hmc101_id" runat="server" Style="left: 87px; position: absolute; top: 7px" Width="143px" CssClass="G"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmc101_cname" runat="server" Style="left: 368px; position: absolute; top: 7px" CssClass="G"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 689px; position: absolute; top: 4px" Text="" Width="80px" />
                                        <asp:CheckBoxList ID="dwQ_hmc101_type" runat="server" Style="z-index: 101; left: 87px; position: absolute; top: 87px" Width="684px" DataMember="hmc102" DataTextField="hmc102_name" DataValueField="hmc102_id" RepeatColumns="6" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
										</witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 604px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="400px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmc101_id" DataMember="hmc101" DataSource="<%# indb_hmc101.dv_View %>" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_id" HeaderText="成員代碼" SortExpression="hmc101_id"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmc101_cname" HeaderText="成員姓名" SortExpression="hmc101_cname"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px;" align="center">
									<asp:Label ID="dwS_RowCount" runat="server" CssClass="D" Text="共0筆資料"></asp:Label></td>
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
