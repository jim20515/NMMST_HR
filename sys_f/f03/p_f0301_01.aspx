<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0301_01.aspx.cs" Inherits="sys_f_f03_p_f0301_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                                <td>
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="74px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hmf102_trainid_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">訓練代號：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmf102_trainid" CssClass="G" runat="server" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
                                        <asp:Label ID="dwQ_hmf102_courseid_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 12px" Width="100px">課程：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmf102_courseid" runat="server" Style="z-index: 105; left: 508px; position: absolute; top: 8px" Width="200px" CssClass="B" DataMember="hmf101">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmf102_teacher_t" runat="server" CssClass="Q" Style="z-index: 109; left: 4px; position: absolute; top: 38px" Width="100px">授課講師：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmf102_teacher" CssClass="G" runat="server" Style="z-index: 110; left: 104px; position: absolute; top: 34px" Width="200px"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 729px; position: absolute; top: 38px" Text="" Width="80px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmf102_trainid" DataMember="hmf102" DataSource="<%# indb_hmf102.dv_View %>" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmf102_trainid" HeaderText="訓練代號" SortExpression="hmf102_trainid"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="課程">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmf102_courseid" runat="server" Text='<%# uf_Dg_Bind("hmf101", DataBinder.Eval(Container, "DataItem.hmf102_courseid")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmf102_teacher" HeaderText="授課講師" SortExpression="hmf102_teacher"></asp:BoundColumn>
                                                <%--<asp:TemplateColumn HeaderText="開課日期">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmf102_sdate" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container,"DataItem.hmf102_sdate") , false) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>--%>
                                                <asp:TemplateColumn HeaderText="修課人數">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmf102_pno" runat="server" Text='<%# f01Project.uf_count1( DataBinder.Eval(Container, "DataItem.hmf102_trainid")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="已輸入人數">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmf102_pno2" runat="server" Text='<%# f01Project.uf_count2( DataBinder.Eval(Container, "DataItem.hmf102_trainid")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
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
