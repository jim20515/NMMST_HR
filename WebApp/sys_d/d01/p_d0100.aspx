<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0100.aspx.cs" Inherits="sys_d_d01_p_d0100" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>幹部職位</title>
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
                                <td style="width: 605px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 605px; height: 18px;">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Purple" Text="◎主要幹部："></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 110px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="111px" Style="position: relative;
                                        left: 3px; top: 10px;" Width="800px">
                                        &nbsp;
                                        <asp:Label ID="Label2" runat="server" CssClass="N" ForeColor="Blue" Style="z-index: 109;
                                            left: 16px; position: absolute; top: 9px" Width="101px">志工督導：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 1px; position: absolute; top: 33px" Width="116px">總幹事：</asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 0px; position: absolute; top: 56px" Width="116px">副總幹事：</asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <br />
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 117px; position: absolute;
                                            top: 6px" Width="117px">員工1</asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 117px; position: absolute;
                                            top: 30px" Width="117px">海大志</asp:TextBox>
                                        <asp:TextBox ID="TextBox5" runat="server" Style="left: 117px; position: absolute;
                                            top: 55px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 117px; position: absolute;
                                            top: 81px" Width="117px"></asp:TextBox>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Button1" runat="server" OnClick="Button4_Click" Style="left: 244px;
                                            position: absolute; top: 5px" Text="Q" Width="29px" />
                                        &nbsp;
                                        <asp:Button ID="Button2" runat="server" Style="left: 244px; position: absolute; top: 29px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" />
                                        <asp:Button ID="Button4" runat="server" Style="left: 244px; position: absolute; top: 54px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" /><asp:Button ID="Button11" runat="server" Style="left: 244px; position: absolute; top: 80px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 1px; width: 605px;">
                                    <br />
                                    <asp:Label ID="Label16" runat="server" ForeColor="Purple" Text="◎志工隊："></asp:Label>
                                    <witc:DWPanel ID="DWPanel1" runat="server" CssClass="Form" Height="199px" Style="position: relative;
                                        left: 3px; top: 0px;" Width="800px">
                                        &nbsp;
                                        <asp:Label ID="Label7" runat="server" CssClass="N" ForeColor="Blue" Style="z-index: 109;
                                            left: 8px; position: absolute; top: 7px" Width="173px">行政志工隊 主辦人：</asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 65px; position: absolute; top: 32px" Width="116px">小隊長：</asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="N" ForeColor="Blue" Style="z-index: 109;
                                            left: 8px; position: absolute; top: 73px" Width="173px">技術志工隊 主辦人：</asp:Label>
                                        <asp:Label ID="Label8" runat="server" CssClass="N" ForeColor="Blue" Style="z-index: 109;
                                            left: 8px; position: absolute; top: 139px" Width="173px">活動及導覽志工隊 主辦人：</asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 65px; position: absolute; top: 164px" Width="116px">小隊長：</asp:Label>
                                        <asp:TextBox ID="TextBox9" runat="server" Style="left: 186px; position: absolute;
                                            top: 136px" Width="117px">員工4</asp:TextBox>
                                        <asp:TextBox ID="TextBox10" runat="server" Style="left: 186px; position: absolute;
                                            top: 163px" Width="117px">海蜇皮</asp:TextBox>
                                        <asp:Button ID="Button8" runat="server" OnClick="Button4_Click" Style="left: 314px;
                                            position: absolute; top: 135px" Text="Q" Width="29px" />
                                        <asp:Button ID="Button10" runat="server" Style="left: 314px; position: absolute; top: 162px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" />
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 65px; position: absolute; top: 98px" Width="116px">小隊長：</asp:Label>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 186px; position: absolute;
                                            top: 70px" Width="117px">員工3</asp:TextBox>
                                        <asp:TextBox ID="TextBox8" runat="server" Style="left: 186px; position: absolute;
                                            top: 97px" Width="117px">海瓜籽</asp:TextBox>
                                        <asp:Button ID="Button3" runat="server" OnClick="Button4_Click" Style="left: 314px;
                                            position: absolute; top: 69px" Text="Q" Width="29px" />
                                        <asp:Button ID="Button6" runat="server" Style="left: 314px; position: absolute; top: 96px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <br />
                                        <asp:TextBox ID="TextBox6" runat="server" Style="left: 186px; position: absolute;
                                            top: 4px" Width="117px">員工2</asp:TextBox>
                                        <asp:TextBox ID="TextBox7" runat="server" Style="left: 186px; position: absolute;
                                            top: 31px" Width="117px">海大志</asp:TextBox>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Button7" runat="server" OnClick="Button4_Click" Style="left: 314px;
                                            position: absolute; top: 3px" Text="Q" Width="29px" />
                                        &nbsp;
                                        <asp:Button ID="Button9" runat="server" Style="left: 314px; position: absolute; top: 30px"
                                            Text="Q" Width="29px" OnClick="Button6_Click" Height="24px" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 9px; width: 605px;">
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 533px; top: 0px;"
                                        Text="確認" Width="55px" />
                                 
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
