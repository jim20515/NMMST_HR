<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0102_01.aspx.cs" Inherits="sys_e_e01_p_e0102_01" %>

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
                                <td>
                                    <asp:Label ID="dwG_ShowMsg" runat="server" ForeColor="#FF8000" Style="font-size: 14pt">請先點選排班表</asp:Label>
                                    <br />
                                    <asp:Button ID="Bt_VRef" runat="server" Style="left: 452px; position: relative; top: -23px" CssClass="Bt_VRef" OnClick="Bt_VRef_Click" Width="80px" /><br />
                                    <asp:Label ID="dwG_msg1" runat="server" ForeColor="Purple" Style="left: 10px; position: relative">◎請先點選排班表</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG1" runat="server" CssClass="Grid" Height="150px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG1" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme101b_pdid" DataMember="hme101b" DataSource="<%# indb_hme101b_1.dv_View %>" Width="770px" OnSelectedIndexChanged="dgG1_SelectedIndexChanged" OnItemDataBound="dgG1_ItemDataBound">
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
                                                <asp:TemplateColumn HeaderText="日">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_sday_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_sdate")).ToString("dd") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="起">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_stime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_starttime")).ToString("HH:mm") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="迄">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_etime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_endtime")).ToString("HH:mm") %>'>
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
                                                <asp:TemplateColumn HeaderText="功能">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_change" runat="server" Width="80px" CssClass="Bt_EditNList" CommandName="Select" CausesValidation="False" UseSubmitBehavior="False" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
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
                                        <asp:DataGrid ID="dgG2" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme101b_pdid" DataMember="hme101b" DataSource="<%# indb_hme101b_2.dv_View %>" Width="770px" OnSelectedIndexChanged="dgG2_SelectedIndexChanged" OnItemDataBound="dgG2_ItemDataBound">
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
                                                <asp:TemplateColumn HeaderText="日">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_sday_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_sdate")).ToString("dd") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="起">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_stime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_starttime")).ToString("HH:mm") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="迄">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_etime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_endtime")).ToString("HH:mm") %>'>
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
                                                <asp:TemplateColumn HeaderText="功能">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_change" runat="server" Width="80px" CssClass="Bt_EditNList" CommandName="Select" CausesValidation="False" UseSubmitBehavior="False" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="Grid_Head" />
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">
                                    <asp:Label ID="dwG_msg3" runat="server" ForeColor="Purple" Style="left: 10px; position: relative">◎請先點選排班表</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG3" runat="server" CssClass="Grid" Height="150px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG3" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hme101b_pdid" DataMember="hme101b" DataSource="<%# indb_hme101b_3.dv_View %>" Width="770px" OnSelectedIndexChanged="dgG3_SelectedIndexChanged" OnItemDataBound="dgG3_ItemDataBound">
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
                                                <asp:TemplateColumn HeaderText="日">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_sday_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_sdate")).ToString("dd") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="起">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_stime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_starttime")).ToString("HH:mm") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="迄">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hme101b_etime_c" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.hme101b_endtime")).ToString("HH:mm") %>'>
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
                                                <asp:TemplateColumn HeaderText="功能">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_change" runat="server" Width="80px" CssClass="Bt_EditNList" CommandName="Select" CausesValidation="False" UseSubmitBehavior="False" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="Grid_Head" />
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px;">
                                    <asp:Button ID="bt_check" runat="server" Style="left: 339px; position: relative;" Width="80px" CssClass="Bt_Conf" OnClientClick="javascript:if(confirm('確定轉為正試式表??')!=1){return false;}"  OnClick="bt_check_Click" /></td>
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
