<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="p_e0102_03.aspx.cs" Inherits="sys_e_e01_p_e0102_03" %>

<%@ Register Src="../u_e_month_view.ascx" TagName="u_e_month_view" TagPrefix="uc2" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班表需求設定</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

    function printout() {
    if (!window.print){alert("列印功能暫時停用，請按 Ctrl-P 來列印"); return;}
    window.print();}
    function MM_openBrWindow(theURL,winName,features) {
    window.open(theURL,winName,features);}

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
                                <td style="height: 4px">
                                        <asp:Label ID="dwF_YM_t" runat="server" Style="position: relative; left: 10px;" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc2:u_e_month_view ID="u_Show" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ◎聯絡電話與目前排班數一覽：
                                    <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="700px">
                                        <ItemStyle CssClass="Grid_Detail" />
                                        <HeaderStyle CssClass="Grid_Head" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="序號">
                                                <HeaderStyle Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="dwG_seq_c" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="志工姓名">
                                                <ItemTemplate>
                                                    <asp:Label ID="dwG_name_c" runat="server" Text='<%# uf_Dg_Bind( "hmd201" , DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="已排班數">
                                                <ItemTemplate>
                                                    <asp:Label ID="dwG_pc_c" runat="server" Text='<%# uf_show_pc( DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="已排班時數">
                                                <ItemTemplate>
                                                    <asp:Label ID="dwG_ts_c" runat="server" Text='<%# uf_show_ts( DataBinder.Eval(Container, "DataItem.hmd201_vid")) %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="聯絡電話">
                                                <ItemTemplate>
                                                    <asp:Label ID="dwG_phone_c" runat="server" Text='<%# uf_show_phone( DataBinder.Eval(Container, "DataItem.hmd201_id")) %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 15px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="bt_print" runat="server" Style="position: relative; left: 317px;" Width="80px" OnClientClick="printout()" CssClass="Bt_Print" Text="　" />
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
