<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0103.aspx.cs" Inherits="sys_f_f01_p_f0103" %>

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
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="150px" Style="position: relative;
                                        left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 33px" Width="80px" ForeColor="Blue">訓練代碼：</asp:Label>
                                        <asp:Label ID="Label19" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 120px" Width="80px">志工代碼：</asp:Label>
                                        <asp:Label ID="Label20" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 238px; position: absolute; top: 120px" Width="80px">志工姓名：</asp:Label>
                                        <asp:Label ID="Label16" runat="server" CssClass="D" ForeColor="Purple" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 9px">◎從訓練查詢：</asp:Label>
                                        <asp:Label ID="Label18" runat="server" CssClass="D" ForeColor="Purple" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 95px">◎從參加人員查詢：</asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 7px; position: absolute; top: 58px" Width="80px">授課人：</asp:Label>
                                        <asp:Label ID="Label17" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 238px; position: absolute; top: 58px" Width="80px">開課時間：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 238px; position: absolute; top: 33px" Width="80px">課程名稱：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 525px;
                                            position: absolute; top: 117px" Text="查詢" Width="56px" />
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 318px; position: absolute;
                                            top: 30px" Width="175px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 87px; position: absolute;
                                            top: 30px" Width="114px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox9" runat="server" Style="left: 87px; position: absolute;
                                            top: 117px" Width="114px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox10" runat="server" Style="left: 318px; position: absolute;
                                            top: 117px" Width="114px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 87px; position: absolute;
                                            top: 55px" Width="114px"></asp:TextBox>
                                        &nbsp;
                                        <asp:Panel ID="Panel1" runat="server" CssClass="G" Style="z-index: 109; left: 318px;
                                            position: absolute; top: 55px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="U_DateSelect_ROC1" runat="server" />
                                        </asp:Panel>
                                        <hr style="z-index: 129; left: 0px; position: absolute; top: 85px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 83px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="135px" Style="position: relative;
                                        left: 0px; top: 0px;" Width="800px">
                                        <br />
                                        <br />
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 14px; position: absolute; top: 7px">*訓練代碼：</asp:Label>
                                        <asp:Label ID="Label21" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 266px; position: absolute; top: 7px">*課程名稱：</asp:Label>
                                        <asp:Label ID="Label7" runat="server" CssClass="D" ForeColor="Purple" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 86px">◎參加人：</asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 33px; position: absolute; top: 30px">授課人：  海大志</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 27px; position: absolute; top: 111px">*志工代碼：</asp:Label>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 266px; position: absolute; top: 111px">*志工姓名：</asp:Label>
                                        &nbsp; &nbsp;&nbsp;
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 47px; position: absolute; top: 53px">時間： 097年12月13日  09:00 ~ 12:00</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 101;
                                            left: 273px; position: absolute; top: 53px">現有修課人數：  2人</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 98px; position: absolute;
                                            top: 108px" Width="119px">V097_00000002</asp:TextBox>
                                        <asp:TextBox ID="TextBox12" runat="server" Style="left: 337px; position: absolute;
                                            top: 108px" Width="119px">海中天</asp:TextBox>
                                        <asp:TextBox ID="TextBox8" runat="server" Style="left: 85px; position: absolute;
                                            top: 4px" Width="119px">T097_0001_001</asp:TextBox>
                                        <asp:TextBox ID="TextBox11" runat="server" Style="left: 337px; position: absolute;
                                            top: 4px" Width="119px">基本餵魚教學</asp:TextBox>
                                        &nbsp; &nbsp;
                                        <hr style="z-index: 129; left: 0px; position: absolute; top: 78px" />
                                        &nbsp; &nbsp;
                                        <asp:Button ID="Button4" runat="server" CssClass="B" Style="z-index: 129; left: 501px;
                                            position: absolute; top: 4px" Text="Q" Width="24px" />
                                        <asp:Button ID="Button8" runat="server" CssClass="B" Style="z-index: 129; left: 501px;
                                            position: absolute; top: 108px" Text="Q" Width="24px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 15px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 34px;
                                        top: 0px;" Text="批次刪除" Width="75px" />
                                    <asp:Button ID="Button6" runat="server" CssClass="B" Style="position: relative; left: 271px;
                                        top: 0px;" Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 272px;
                                        top: 0px;" Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 272px;
                                        top: 0px;" Text="刪除" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 272px;
                                        top: 0px;" Text="清除" Width="55px" />
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
                                                <asp:TemplateColumn HeaderText="序號">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="dwG_seq_c" runat="server" CausesValidation="False" CommandName="Select"
                                                            TabIndex="-1" Text='<%# Convert.ToInt32(DataBinder.Eval(Container, "ItemIndex")) + 1 %>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="刪除">
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="dwG_CHECK" runat="server" CausesValidation="False"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="訓練代碼" HeaderText="訓練代碼" SortExpression="訓練代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="訓練名稱" HeaderText="訓練名稱" SortExpression="訓練名稱"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工代碼" HeaderText="志工代碼" SortExpression="志工代碼"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="志工名稱" HeaderText="志工名稱" SortExpression="志工名稱"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="加入法" HeaderText="加入法" SortExpression="加入法"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="支票開立日期" HeaderText="支票開立日期" SortExpression="支票開立日期"  ></asp:BoundColumn>	
									<asp:BoundColumn DataField="受(繳)款人" HeaderText="受(繳)款人" SortExpression="受(繳)款人" ></asp:BoundColumn>	
									<asp:BoundColumn DataField="支票金額" HeaderText="支票金額" SortExpression="支票金額" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	
									<asp:BoundColumn DataField="支票兌現到期日" HeaderText="支票兌現到期日" SortExpression="支票兌現到期日"  ></asp:BoundColumn>		
									<asp:BoundColumn DataField="劃線" HeaderText="劃線" SortExpression="劃線" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	
									<asp:BoundColumn DataField="禁背" HeaderText="禁背" SortExpression="禁背" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>	
									<asp:BoundColumn DataField="郵寄日期" HeaderText="郵寄日期" SortExpression="郵寄日期" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>	--%>
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
