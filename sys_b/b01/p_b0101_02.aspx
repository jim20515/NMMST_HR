<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_b0101_02.aspx.cs" Inherits="sys_b_b01_p_b0101_02" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
									<asp:HyperLink ID="lb_all" runat="server" NavigateUrl="javascript:uf_select_all();" Style="position: relative; left: 26px;">全選</asp:HyperLink>
									<asp:HyperLink ID="lb_unall" runat="server" NavigateUrl="javascript:uf_cancel_all();" Style="position: relative; left: 26px;">全不選</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="360px" Width="820px">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmc101_id" DataMember="hmc101" DataSource="<%# indb_hmc101.dv_View %>" Width="785px">
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="勾選">
                                                    <ItemTemplate>
                                                       <%-- <asp:CheckBox ID="dwg_check" runat="server" AutoPostBack="true" Checked='<%# uf_check(DataBinder.Eval(Container, "DataItem.hmc101_id")) %>' />--%>
														<asp:CheckBox ID="dwg_check" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_id" HeaderText="代碼" SortExpression="hmc101_id" Visible="false"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="分類">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmc102_name_c" runat="server" Text='<%# e01Project.uf_get_hmc102( DataBinder.Eval(Container, "DataItem.hmc101_id")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_cname" HeaderText="姓名" SortExpression="hmc101_cname"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="生日">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmc101_bday" runat="server" Text='<%# DateMethods.uf_YYYY_To_YYY(DataBinder.Eval(Container, "DataItem.hmc101_bday"), false) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="性別">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmc101_gent" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hmc101_gent").ToString().Trim() == "M" ? "男" : "女"  %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_email" HeaderText="E-Mail" SortExpression="hmc101_email"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmc101_phnom" HeaderText="行動電話" SortExpression="hmc101_phnom"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px">
                                    <asp:Button ID="Bt_SelectFormat" CssClass="Bt_SelectFormat" runat="server" Style="left: 204px; position: relative; top: 2px" Text="" CommandName="go" EnableTheming="True" CausesValidation="False" UseSubmitBehavior="False" OnClick="Bt_SelectFormat_Click" />
                                    <asp:Button ID="Bt_SendMessage" CssCLASS="Bt_SendMessage" runat="server" Style="left: 234px; position: relative; top: 2px" Text=""  CommandName="go" EnableTheming="True" CausesValidation="False" UseSubmitBehavior="False" OnClick="Bt_SendMessage_Click" />
                                    <asp:Button ID="Bt_SendCard" CssCLASS="Bt_SendCard"  runat="server" Style="left: 271px; position: relative; top: 2px" Text="" CommandName="go" EnableTheming="True" CausesValidation="False" UseSubmitBehavior="False" OnClick="Bt_SendCard_Click" />
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
<script language="javascript" type="text/javascript">

function uf_select_all()
{
		var li_seq = 2;
		while (document.getElementById("dgG_ctl" + (li_seq >= 10 ? "" : "0") + li_seq + "_dwG_seq_c") != null)
		{
			document.getElementById("dgG_ctl" + (li_seq >= 10 ? "" : "0") + li_seq + "_dwg_check").checked = true;
			li_seq ++;
		}
}

function uf_cancel_all()
{
		var li_seq = 2;
		while (document.getElementById("dgG_ctl" + (li_seq >= 10 ? "" : "0") + li_seq + "_dwG_seq_c") != null)
		{
			document.getElementById("dgG_ctl" + (li_seq >= 10 ? "" : "0") + li_seq + "_dwg_check").checked = false;
			li_seq ++;
		}
}

</script>
</html>
