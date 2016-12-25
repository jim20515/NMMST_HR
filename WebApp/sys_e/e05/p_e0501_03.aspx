<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0501_03.aspx.cs" Inherits="sys_e_e05_p_e0501_03" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>成績附註登錄</title>
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
                                <td style="height: 29px; width: 605px;">
                                    &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Purple" Text="◎097年度行政志工隊 第一季服務表現登錄" style="font-size: 16pt"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td style="position: relative; width: 605px;">
                                    <%--<asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px; top: 0px;"
                                        Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="刪除" Width="55px" />--%>
                                    &nbsp;</td>
                          
                            <tr>
                                <td style="height: 192px; width: 605px;">
                                    <witc:ScrollGrid ID="dwG" runat="server" CssClass="Grid" Height="153px" Width="800px"
                                        AJAXScript="Yes">
                                        <asp:DataGrid ID="dgG" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="780px" TabIndex="1" Height="129px">
                                            <SelectedItemStyle CssClass="Grid_Select" />
                                            <ItemStyle CssClass="Grid_Detail" />
                                            <HeaderStyle CssClass="Grid_Head" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>' OnClientClick="uf_SelectFrame(2)">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="志工代碼" HeaderText="志工代碼" SortExpression="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工姓名" HeaderText="志工姓名" SortExpression="志工姓名"></asp:BoundColumn>
                                                  <asp:TemplateColumn HeaderText="第一季">
                                                    <HeaderStyle Width="35px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dgG_ema11_de" runat="server" Style= "text-align: right;" Text='' Width="35px"></asp:TextBox>
                                                         
                                                    </ItemTemplate>
                                                </asp:TemplateColumn> 
                                                <asp:BoundColumn DataField="第二季" HeaderText="第二季" SortExpression="第二季"></asp:BoundColumn>  
                                                <asp:BoundColumn DataField="第三季" HeaderText="第三季" SortExpression="第三季"></asp:BoundColumn>  
                                                <asp:BoundColumn DataField="第四季" HeaderText="第四季" SortExpression="第四季"></asp:BoundColumn> 
                                                <asp:BoundColumn DataField="服勤時數" HeaderText="服勤時數" SortExpression="服勤時數"></asp:BoundColumn>
                                                 <asp:BoundColumn DataField="缺勤時數" HeaderText="缺勤時數" SortExpression="缺勤時數"></asp:BoundColumn>
                                                  <asp:BoundColumn DataField="連續不及格" HeaderText="連續不及格" SortExpression="連續不及格" ></asp:BoundColumn>
                                                
                                                  
                                                  
                                   
                                                <asp:TemplateColumn HeaderText="備註">
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="dgG_ema11_de" runat="server" Style= "text-align: right;" Text='' Width="40px"></asp:TextBox>
                                                         
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </witc:ScrollGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 605px;">
                                    <asp:Button ID="Button1" runat="server" Style="left: 481px; position: relative; top: 2px"
                                        Text="儲存" Width="58px" />
                                    <asp:Button ID="Button2" runat="server" Style="left: 481px; position: relative; top: 2px"
                                        Text="取消" Width="58px" /></td>
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
