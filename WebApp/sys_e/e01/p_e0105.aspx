<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_e0105.aspx.cs" Inherits="sys_e_e01_p_e0105" %>

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
                                <td style="height: 54px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="40px" Style="position: relative;
                                        left: 1px; top: -3px;" Width="800px">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:Label ID="dwQ_aec02_code_t" runat="server" CssClass="D" ForeColor="Blue" Height="16px"
                                            Style="z-index: 101; left: 272px; position: absolute; top: 13px" Width="80px">志工隊：</asp:Label>
                                        <asp:Label ID="Label1" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 13px" Width="80px">樣板名稱：</asp:Label>
                                        <asp:Button ID="bt_Query" runat="server" CssClass="B" Style="z-index: 114; left: 534px;
                                            position: absolute; top: 11px" Text="查詢" Width="56px" />
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 96px; position: absolute;
                                            top: 10px" Width="128px"></asp:TextBox>
                                        <asp:DropDownList ID="DropDownList7" runat="server" Style="left: 360px; position: absolute;
                                            top: 10px">
                                            <asp:ListItem>行政志工</asp:ListItem>
                                            <asp:ListItem>技術志工</asp:ListItem>
                                            <asp:ListItem>導覽及活動志工</asp:ListItem>
                                        </asp:DropDownList>
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 73px;">
                                    <img src="../../proj_img/calendar4.bmp" style="width: 602px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 55px; width: 605px;">
                                    &nbsp;<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="169px" Style="position: relative;
                                        left: 3px; top: -10px;" Width="800px">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                                        &nbsp; &nbsp;&nbsp;<br />
                                        
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 73px" Width="80px">報到點：</asp:Label>
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 95px" Width="80px">需要人數：</asp:Label>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 119px" Width="80px">事由：</asp:Label>
                                        <asp:Label ID="Label13" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 172px; position: absolute; top: 95px" Width="19px">人</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 23px" Width="80px">日期：</asp:Label>
                                        <asp:Label ID="Label7" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 16px; position: absolute; top: 49px" Width="80px">時間：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label9" runat="server" CssClass="D" Style="z-index: 101; left: 16px;
                                            position: absolute; top: 0px; text-align: left" Width="130px">97年11月 行政志工</asp:Label>
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 356px; position: absolute;
                                            top: 68px" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox8" runat="server" Style="left: 97px; position: absolute;
                                            top: 92px" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 97px; position: absolute;
                                            top: 116px" Width="278px"></asp:TextBox>
                                        <asp:Label ID="Label8" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 135px; position: absolute; top: 49px" Width="18px">：</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 197px; position: absolute; top: 49px" Width="18px">～</asp:Label>
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 95px; position: absolute;
                                            top: 47px" Width="33px">08</asp:TextBox>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 156px; position: absolute;
                                            top: 46px" Width="33px">00</asp:TextBox>
                                        <asp:Label ID="Label11" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 101;
                                            left: 260px; position: absolute; top: 49px" Width="18px">：</asp:Label>
                                        <asp:TextBox ID="TextBox5" runat="server" Style="left: 220px; position: absolute;
                                            top: 47px" Width="33px">12</asp:TextBox>
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 281px; position: absolute;
                                            top: 46px" Width="33px">00</asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:Panel ID="dwQ_edate" runat="server" CssClass="G" Style="z-index: 109; left: 96px;
                                            position: absolute; top: 20px" TabIndex="4" Width="132px">
                                            <uc1:u_DateSelect_ROC ID="u_Date4" runat="server" OnLoad="u_Date4_Load" />
                                        </asp:Panel>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                            Style="left: 93px; position: absolute; top: 67px">
                                            <asp:ListItem>辦公室</asp:ListItem>
                                            <asp:ListItem>魚池</asp:ListItem>
                                            <asp:ListItem>工作站</asp:ListItem>
                                            <asp:ListItem>休息室</asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:CheckBox ID="CheckBox1" runat="server" ForeColor="Blue" Style="left: 97px; position: absolute;
                                            top: 143px" Text="訂便當" />
                                        <asp:CheckBox ID="CheckBox2" runat="server" ForeColor="Blue" Style="left: 213px;
                                            position: absolute; top: 20px" Text="每週重複" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
                                    </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 365px; top: 0px;"
                                        Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="刪除" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 366px; top: 0px;"
                                        Text="清除" Width="55px" />
                                 
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px; width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px;">
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
