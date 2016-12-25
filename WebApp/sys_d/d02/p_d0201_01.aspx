<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_01.aspx.cs" Inherits="sys_d_d02_p_d0201_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�d�ߤβM��</title>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="120px" Style="position: relative" Width="820px">
                                        <asp:Label ID="dwQ_hmd201_cname_t" runat="server" CssClass="Q" Style="z-index: 99; left: 4px; position: absolute; top: 12px" Width="100px">�m�W�G</asp:Label>
                                        <asp:TextBox ID="dwQ_hmd201_cname" CssClass="G" runat="server" Style="z-index: 100; left: 104px; position: absolute; top: 8px" Width="200px"></asp:TextBox>
                                        <asp:Label ID="dwQ_hmd201_bday_s_t" runat="server" CssClass="Q" Style="z-index: 104; left: 408px; position: absolute; top: 8px" Width="100px">�ͤ�G</asp:Label>
                                        <asp:Panel ID="dwQ_hmd201_bday_s" runat="server" CssClass="G" Style="z-index: 105; left: 508px; position: absolute; top: 4px" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date0" runat="server" />
                                        </asp:Panel>
                                        <asp:Label Style="z-index: 106; left: 618px; position: absolute; top: 8px" ID="dwQ_hmd201_bday_e_t" runat="server" Width="18px" CssClass="Q">��</asp:Label>
                                        <asp:Panel ID="dwQ_hmd201_bday_e" runat="server" CssClass="G" Style="z-index: 107; left: 653px; position: absolute; top: 4px" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        <asp:Label ID="dwQ_hmd201_account_t" runat="server" CssClass="Q" Style="z-index: 109; left: 4px; position: absolute; top: 38px" Width="100px">�Ӥu���b���G</asp:Label>
                                        <asp:TextBox ID="dwQ_hmd201_account" CssClass="G" runat="server" Style="z-index: 110; left: 104px; position: absolute; top: 34px" Width="200px"></asp:TextBox>
                                        <asp:Label ID="dwQ_hmd201_expert_t" runat="server" CssClass="Q" Style="z-index: 109; left: 4px; position: absolute; top: 94px" Width="100px">�M���G</asp:Label>
                                        <asp:TextBox ID="dwQ_hmd201_expert" runat="server" CssClass="G" Style="z-index: 110; left: 104px; position: absolute; top: 90px" Width="599px"></asp:TextBox>
                                        <asp:Label ID="dwQ_hmd201_lvid_t" runat="server" CssClass="Q" Style="z-index: 114; left: 408px; position: absolute; top: 38px" Width="100px">�Ӥu���šG</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmd201_lvid" runat="server" Style="z-index: 115; left: 508px; position: absolute; top: 34px" Width="200px" CssClass="B" DataMember="hca206">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hmd201_status_t" runat="server" CssClass="Q" Style="z-index: 119; left: 4px; position: absolute; top: 64px" Width="100px">�A�Ȫ��A�G</asp:Label>
                                        <asp:DropDownList ID="dwQ_hmd201_status" runat="server" Style="z-index: 120; left: 104px; position: absolute; top: 60px" Width="200px" CssClass="B" DataMember="hca207">
                                        </asp:DropDownList>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left: 728px; position: absolute; top: 79px" Text="" Width="80px" />
                                        <asp:Button ID="bt_Import" runat="server" CssClass="Bt_Import" Style="z-index: 999; left: 728px; position: absolute; top: 40px" Text="" Width="80px" OnClick="bt_Import_Click" />
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="800px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="�Ǹ�">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd201_bookid" HeaderText="�Ӥu��U�s��" SortExpression="hmd201_vid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="�m�W" SortExpression="hmd201_cname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_account" HeaderText="�Ӥu���b��" SortExpression="hmd201_account"></asp:BoundColumn>
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
