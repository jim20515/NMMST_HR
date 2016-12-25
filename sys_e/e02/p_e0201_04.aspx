<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0201_04.aspx.cs" Inherits="sys_e_e02_p_e0201_04" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="60px" Style="position: relative" Width="620px">
                                        <asp:Label ID="dwQ_hme101a_tid_t" runat="server" CssClass="Q" Style="z-index: 101; left: 4px; position: absolute; top: 11px" Width="80px">志工隊：</asp:Label>
                                        <asp:DropDownList ID="dwQ_hme101a_tid" runat="server" Style="left: 86px; position: absolute; top: 8px" CssClass="B" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Label ID="dwQ_hme101a_ym_t" runat="server" CssClass="Q" Style="z-index: 101; left: 203px; position: absolute; top: 11px" Width="80px">查詢年月：</asp:Label>
                                        <asp:Label ID="dwQ_hme101a_syear_t" runat="server" CssClass="Q" Style="z-index: 101; left: 326px; position: absolute; top: 11px" Width="18px">年</asp:Label>
                                        <asp:Label ID="dwQ_hme101a_smonth_t" runat="server" CssClass="Q" Style="z-index: 101; left: 387px; position: absolute; top: 11px" Width="18px">月</asp:Label>
                                        <asp:TextBox ID="dwQ_hme101a_syear" runat="server" Style="left: 285px; position: absolute; top: 8px" Width="33px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hme101a_smonth" runat="server" Style="left: 346px; position: absolute; top: 8px" Width="33px"></asp:TextBox>
                                        &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:Label ID="dwQ_hme101b_sdate_t" runat="server" CssClass="Q" Style="z-index: 104; left: 4px; position: absolute; top: 37px" Width="80px">需求日期：</asp:Label>
                                        <asp:Panel ID="dwQ_hme101b_sdate" runat="server" CssClass="G" Style="z-index: 104; left: 84px; position: absolute; top: 34px" Width="100px">
                                            <uc1:u_DateSelect_ROC ID="u_Date1" runat="server" />
                                        </asp:Panel>
                                        <asp:Label ID="dwQ_hme101b_addtext_t" runat="server" CssClass="Q" Style="z-index: 101; left: 203px; position: absolute; top: 37px" Width="80px">報到地點：</asp:Label>
                                        <asp:TextBox ID="dwQ_hme101b_addtext" runat="server" Style="left: 285px; position: absolute; top: 34px" Width="233px"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 534px; position: absolute; top: 14px" Text="" Width="80px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="272px" Width="620px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme101b_pdid" DataMember="hme101b" DataSource="<%# indb_hme101a_hme101b.dv_View %>" Width="600px" OnItemDataBound="dgG_ItemDataBound">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dgG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101a_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hme101a_tid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hme101a_syear" HeaderText="年" SortExpression="hme101a_syear">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="hme101a_smonth" HeaderText="月" SortExpression="hme101a_smonth">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Justify" />
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="需求時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_sdate_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY( DataBinder.Eval(Container, "DataItem.hme101b_sdate"), false ) + " " + Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_starttime")).ToString("HHmm") + " ~ " + Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_endtime")).ToString("HHmm") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hme101b_note" HeaderText="活動事由" SortExpression="hme101b_note"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hme101b_addtext" HeaderText="報到地點" SortExpression="hme101b_addtext"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hme101b_needno" HeaderText="需要人數" SortExpression="hme101b_needno"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="現有人數">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_pcount_actual_c" runat="server" Text='<%# e01Project.uf_pcount_hme101c( DataBinder.Eval(Container, "DataItem.hme101b_pdid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hme101b_pdid" HeaderText="已排姓名" SortExpression="hme101b_pdid"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hme101b_pdid" HeaderText="需求班表代碼" SortExpression="hme101b_pdid" Visible="false"></asp:BoundColumn>
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

    <script src="../../wz_tooltip.js" type="text/javascript"></script>

    <script type="text/javascript">
		//function uf_Tip(as_Text) { Tip(as_Text, BGCOLOR, '#ffffd8', BORDERCOLOR, 'Black', WIDTH, -500); }
		
		function uf_Tip(as_Text)
        {
		        Tip(as_Text, BGCOLOR, '#EFF7FF', BORDERCOLOR, 'CornflowerBlue', WIDTH, -500);
        }

    </script>

</body>
</html>
