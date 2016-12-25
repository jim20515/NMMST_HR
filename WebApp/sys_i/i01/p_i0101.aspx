﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_i0101.aspx.cs" Inherits="sys_i_i01_p_i0101" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="58px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_hmc101_id_t" runat="server" CssClass="G" Style="z-index: 101; left: 4px; position: absolute; top: 10px; text-align: right;" Width="104px" ForeColor="Blue">員工代號：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_deptid_t" runat="server" CssClass="G" ForeColor="Blue" Style="z-index: 101; left: 3px; position: absolute; top: 36px; text-align: right" Width="104px">部門：</asp:Label>
                                        <asp:Label ID="dwQ_hmc101_cname_t" runat="server" CssClass="G" ForeColor="Blue" Style="z-index: 101; left: 266px; position: absolute; top: 10px; text-align: right;" Width="104px">員工姓名：</asp:Label>
                                        <asp:TextBox ID="dwQ_hmc101_id" runat="server" Style="left: 109px; position: absolute; top: 7px" Width="143px" CssClass="G"></asp:TextBox>
                                        <asp:TextBox ID="dwQ_hmc101_cname" runat="server" Style="left: 368px; position: absolute; top: 7px" CssClass="G"></asp:TextBox>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 103; left: 573px; position: absolute; top: 15px" Text="" Width="80px" />
                                        <asp:DropDownList ID="dwQ_hmc101_deptid" runat="server" DataMember="hca202" Style="left: 108px; position: absolute; top: 33px" Width="152px">
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 161px; width: 604px;">
                                    <table class="G">
                                        <tr>
                                            <td style="height: 149px">
                                                <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="132px" Style="left: 0px; position: relative; top: 0px" Width="800px">
                                                    <asp:Label ID="dwF_hmc101_id_t" runat="server" CssClass="D" Style="z-index: 103; left: 4px; position: absolute; top: 9px" Width="84px">員工代號：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_id" runat="server" CssClass="G" Style="z-index: 104; left: 92px; position: absolute; top: 9px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_PhNoW_t" runat="server" CssClass="D" Style="z-index: 105; left: 300px; position: absolute; top: 9px" Width="84px">工作電話：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_PhNoW" runat="server" CssClass="G" Style="z-index: 106; left: 388px; position: absolute; top: 9px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_cname_t" runat="server" CssClass="D" Style="z-index: 107; left: 4px; position: absolute; top: 33px" Width="84px">員工姓名：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_cname" runat="server" CssClass="G" Style="z-index: 108; left: 92px; position: absolute; top: 33px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_deptname" runat="server" CssClass="G" Style="z-index: 108; left: 92px; position: absolute; top: 57px" Width="200px"></asp:Label>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="dwF_hmc101_PhNoA_t" runat="server" CssClass="D" Style="z-index: 109; left: 300px; position: absolute; top: 33px" Width="84px">住址電話：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_PhNoM_t" runat="server" CssClass="D" Style="z-index: 109; left: 300px; position: absolute; top: 56px" Width="84px">行動電話：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_addid_addot_t" runat="server" CssClass="D" Style="z-index: 109; left: 300px; position: absolute; top: 79px" Width="84px">通訊住址：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_email_t" runat="server" CssClass="D" Style="z-index: 109; left: 300px; position: absolute; top: 103px" Width="84px">Email：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_PhNoA" runat="server" CssClass="G" Style="z-index: 110; left: 388px; position: absolute; top: 33px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_PhNoM" runat="server" CssClass="G" Style="z-index: 110; left: 388px; position: absolute; top: 57px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_addid_addot" runat="server" CssClass="G" Style="z-index: 110; left: 388px; position: absolute; top: 79px" Width="367px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_email" runat="server" CssClass="G" Style="z-index: 110; left: 388px; position: absolute; top: 102px" Width="200px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_deptname_t" runat="server" CssClass="D" Style="z-index: 111; left: 4px; position: absolute; top: 57px" Width="84px">部門：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_bday_t" runat="server" CssClass="D" Style="z-index: 113; left: 4px; position: absolute; top: 102px" Width="84px">生日：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_bday" runat="server" CssClass="G" Style="z-index: 114; left: 92px; position: absolute; top: 102px" Width="196px"></asp:Label>
                                                    <asp:Label ID="dwF_hmc101_jobtitle_t" runat="server" CssClass="D" Style="z-index: 113; left: 4px; position: absolute; top: 80px" Width="84px">職稱：</asp:Label>
                                                    <asp:Label ID="dwF_hmc101_jobtitle" runat="server" CssClass="G" Style="z-index: 114; left: 92px; position: absolute; top: 80px" Width="196px"></asp:Label>
                                                </witc:DWPanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 604px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="150px" Width="800px" AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyField="hmc101_id" DataMember="hmi101" DataSource="<%# indb_hmi101.dv_View %>" Width="800px">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select" TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_cname" HeaderText="姓名"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="hmc101_deptid" HeaderText="部門"></asp:BoundColumn>--%>
                                                <asp:TemplateColumn HeaderText="部門">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmc101_deptid_c" runat="server" Text='<%# uf_Dg_Bind( "hca202" , DataBinder.Eval(Container, "DataItem.hmc101_deptid")) %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:BoundColumn DataField="hmc101_jobtitle" HeaderText="職稱"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="hmc101_PhNoM" HeaderText="行動電話"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="hmc101_addid" HeaderText="住址"></asp:BoundColumn>--%>
                                                <asp:TemplateColumn HeaderText="住址">
                                                    <ItemTemplate>
                                                        <asp:Label ID="dwG_hmc101_addid_c" runat="server" Text='<%# uf_Dg_Bind( "hca205" , DataBinder.Eval(Container, "DataItem.hmc101_addid"))+ DataBinder.Eval(Container, "DataItem.hmc101_addot")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="hmc101_email" HeaderText="Email"></asp:BoundColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="Grid_Head" />
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 604px;">
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
