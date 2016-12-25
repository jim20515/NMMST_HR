<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_06.aspx.cs" Inherits="sys_d_d02_p_d0201_06" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>轉正式班表</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pn_Contain" runat="server" Height="488px">
                        <table class="G">
                            <tr>
                                <td style="height: 37px">
                                <asp:Label ID="Label1" runat="server" Style="position: relative; left: 9px; top: 1px;" CssClass="D">◎志工姓名：</asp:Label>
                                    <asp:Label ID="dwG_ShowMsg" runat="server" Style="position: relative; left: 9px; top: 1px;" CssClass="I"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="dwG_msg1" runat="server" ForeColor="Purple" Style="left: 10px; position: relative">◎請先點選排班表</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG1" runat="server" CssClass="Grid" Height="150px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG1" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataSource="<%# indb_hlg203.dv_View %>" Width="770px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_seq_c" runat="server" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="得獎日期">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_sday_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hlg203_mdate"), false) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hlg203_metalname" HeaderText="得獎名稱" SortExpression="hlg203_metalname"></asp:BoundColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="Grid_Head" />
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">
                                    <asp:Label ID="dwG_msg2" runat="server" ForeColor="Purple" Style="left: 10px; position: relative">◎請先點選排班表</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG2" runat="server" CssClass="Grid" Height="150px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG2" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="770px" >
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmd100a_posname" HeaderText="職位名稱" SortExpression="hmd100a_posname"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="depname" HeaderText="志工隊/部門名稱" SortExpression="depname"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="任命時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_ttt_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmd100b_sdt"), true) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="停止時間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_ttt1_c" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmd100b_tdt"), true) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="是否上任中">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_ttt2_c" runat="server" Text='<%# uf_Dg_BindBool("是,否", uf_Dg_BindBool("Y", DataBinder.Eval(Container, "DataItem.hmd100b_active"))) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="Grid_Head" />
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
