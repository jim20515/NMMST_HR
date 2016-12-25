<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0101A.aspx.cs" Inherits="sys_f_f01_p_f0101A" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                <td style="height: 35px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 11px" Width="80px" ForeColor="Blue">�{�ҥN�X�G</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 238px; position: absolute; top: 11px" Width="80px">�{�ҦW�١G</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 8px" Text="�d��" Width="56px" />
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 318px; position: absolute;
                                            top: 8px" Width="175px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 87px; position: absolute;
                                            top: 8px" Width="114px"></asp:TextBox>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 83px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="260px" Style="position: relative;
                                        left: 0px; top: 0px;" Width="800px">
                                        <br />
                                        <br />
                                        &nbsp;
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 32px; position: absolute; top: 16px">*�{�ҥN�X�G</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 32px; position: absolute; top: 40px">*�{�ҦW�١G</asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 106px; position: absolute;
                                            top: 16px" Width="48px">01</asp:TextBox>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 106px; position: absolute;
                                            top: 40px" Width="405px">�鶡�a�M�~�{��</asp:TextBox>
                                             <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                                left: 38px; position: absolute; top: 80px">�]�t�ҵ{�G</asp:Label>
                                            <asp:Button ID="Button4" runat="server" CssClass="B" Style="position: absolute; 
                                                top: 74px; left: 392px;" Text="�s�W" Width="55px" />
                                            <asp:Button ID="Button6" runat="server" CssClass="B" Style="position: absolute; 
                                                top: 74px; left: 456px;" Text="�ק�" Width="55px" />
                                        <witc:ScrollGrid ID="ScrollGrid1" runat="server" CssClass="Grid" Height="120px" Width="550px"
                                            AJAXScript="Yes" Style="z-index: 101; position: absolute; top: 104px; left: 16px;">
                                           
                                            <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                                Width="520px" TabIndex="1" >
                                                <SelectedItemStyle CssClass="Grid_Select" />
                                                <ItemStyle CssClass="Grid_Detail" />
                                                <HeaderStyle CssClass="Grid_Head" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="�Ǹ�">
                                                        <HeaderStyle Width="30px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                                TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="�ҵ{�D�ɥN�X" HeaderText="�ҵ{�D�ɥN�X" SortExpression="�ҵ{�D�ɥN�X"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="�ҵ{�W��" HeaderText="�ҵ{�W��" SortExpression="�ҵ{�W��"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="���O" HeaderText="���O" SortExpression="���O"></asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="�R��">
                                                        <HeaderStyle Width="30px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </witc:ScrollGrid>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px;
                                        top: 0px;" Text="�s�W" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="�ק�" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="�R��" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 366px;
                                        top: 0px;" Text="�M��" Width="55px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 150px; width: 605px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="100px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1">
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="�Ǹ�">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="�{�ҥN�X" HeaderText="�{�ҥN�X" SortExpression="�{�ҥN�X"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="�{�ҦW��" HeaderText="�{�ҦW��" SortExpression="�{�ҦW��"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="�ҵ{��" HeaderText="�ҵ{��" SortExpression="�ҵ{��"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 605px;">
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
