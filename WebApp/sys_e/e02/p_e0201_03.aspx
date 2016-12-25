<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0201_03.aspx.cs" Inherits="sys_e_e02_p_e0201_03" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
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
                                        <asp:Label ID="dwQ_hmd201_vname_t" Style="z-index: 100; left: 254px; position: absolute; top: 13px" runat="server" Width="90px" CssClass="I">志工姓名：</asp:Label>
                                        <asp:Label ID="dwQ_hmd201_ssn_t" runat="server" CssClass="I" Style="z-index: 100; left: 254px; position: absolute; top: 38px" Width="90px">身分證字號：</asp:Label>
                                        <asp:Label ID="dwQ_hmd201_tid_t" Style="z-index: 101; left: 19px; position: absolute; top: 38px" runat="server" Width="76px" CssClass="I">志工隊：</asp:Label>
                                        <asp:Label ID="dwQ_hmd201_vid_t" Style="z-index: 102; left: 19px; position: absolute; top: 13px" runat="server" Width="76px" CssClass="I">員工編號：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmd201_vid" runat="server" CssClass="G" Style="z-index: 103; left: 95px; position: absolute; top: 10px" Width="134px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmd201_vname" runat="server" CssClass="G" Style="z-index: 104; left: 344px; position: absolute; top: 10px" Width="134px"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmd201_ssn" runat="server" CssClass="G" Style="z-index: 104; left: 344px; position: absolute; top: 35px" Width="134px"></asp:TextBox>
                                        <asp:DropDownList ID="dwQ_hmd201_tid" Style="z-index: 100; left: 95px; position: absolute; top: 35px" runat="server" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 505px; position: absolute; top: 17px" Text="" Width="80px" />
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
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmd201_vid" DataMember="hmd201" DataSource="<%# indb_hmd201.dv_View %>" Width="600px">
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
                                                <asp:BoundColumn DataField="hmd201_vid" HeaderText="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_ssn" HeaderText="身分證字號"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmd201_cname" HeaderText="志工姓名"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="志工隊">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmd201_tid_c" runat="server" Text='<%# uf_Dg_Bind( "hmd101" , DataBinder.Eval(Container, "DataItem.hmd201_tid")) %>'>
                                                        </asp:Label>
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
