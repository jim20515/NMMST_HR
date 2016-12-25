<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_c0104_02.aspx.cs" Inherits="sys_c_c01_p_c0104_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明細</title>
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
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 108px; width: 604px;">
                                    <asp:Label ID="Label18" runat="server" ForeColor="Purple" Style="left: 1px; position: relative;
                                        top: 7px" Text="◎基本資料"></asp:Label>
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="339px" Style="position: relative;
                                        left: 3px; top: 11px;" Width="800px">
                                        <asp:Label ID="dwF_aec02_name_t" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 10px" Width="80px">人員代碼：</asp:Label>
                                        <asp:Label ID="Label2" runat="server" CssClass="N" Style="z-index: 109; left: 37px;
                                            position: absolute; top: 33px" Width="80px">*人員姓名：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label5" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 60px" Width="80px">性別：</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 86px" Width="80px">生日：</asp:Label>
                                        <asp:Label ID="Label8" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 136px" Width="80px">職業：</asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 111px" Width="80px">學歷：</asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 163px" Width="80px">通訊地址：</asp:Label>
                                        <asp:Label ID="Label11" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 190px" Width="80px">E-mail：</asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 190px" Width="80px">E-mail：</asp:Label>
                                        <asp:Label ID="Label15" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 214px" Width="80px">任教單位：</asp:Label>
                                        <asp:Label ID="Label16" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 241px" Width="80px">專長：</asp:Label>
                                        <asp:Label ID="Label17" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 37px; position: absolute; top: 289px" Width="80px">備註：</asp:Label>
                                        <asp:Label ID="Label12" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 308px; position: absolute; top: 65px" Width="80px">工作電話：</asp:Label>
                                        <asp:Label ID="Label13" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 308px; position: absolute; top: 89px" Width="80px">住址電話：</asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 308px; position: absolute; top: 112px" Width="80px">行動電話：</asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label7" runat="server" CssClass="G" Style="z-index: 124; left: 119px;
                                            position: absolute; top: 10px" ForeColor="Blue">S097-00000003</asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBox3" runat="server" Style="left: 121px; position: absolute;
                                            top: 30px" Width="117px">王專家</asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" Style="left: 120px; position: absolute;
                                            top: 211px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox11" runat="server" Font-Bold="True" Height="35px" Style="left: 118px;
                                            position: absolute; top: 287px" Width="277px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox12" runat="server" Height="35px" Style="left: 119px; position: absolute;
                                            top: 238px" Width="277px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" Style="left: 121px; position: absolute;
                                            top: 83px" Width="117px">083/11/11</asp:TextBox>
                                        <asp:TextBox ID="TextBox8" runat="server" Style="left: 388px; position: absolute;
                                            top: 62px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox9" runat="server" Style="left: 388px; position: absolute;
                                            top: 85px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox10" runat="server" Style="left: 388px; position: absolute;
                                            top: 110px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox13" runat="server" Style="left: 388px; position: absolute;
                                            top: 135px" Width="117px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox5" runat="server" Style="left: 248px; position: absolute;
                                            top: 161px" Width="223px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 121px; position: absolute;
                                            top: 187px" Width="226px"></asp:TextBox>
                                        &nbsp;&nbsp;<br />
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                                            Style="left: 119px; position: relative; top: 28px">
                                            <asp:ListItem Selected="True">男</asp:ListItem>
                                            <asp:ListItem>女</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="left: 121px; position: absolute;
                                            top: 134px" Width="105px">
                                            <asp:ListItem>公教人員</asp:ListItem>
                                            <asp:ListItem>醫生</asp:ListItem>
                                            <asp:ListItem>律師</asp:ListItem>
                                            <asp:ListItem Selected="True">服務業</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 305px; position: absolute; top: 137px" Width="80px">職稱：</asp:Label>
                                        &nbsp;
                                        <asp:DropDownList ID="DropDownList2" runat="server" Style="left: 121px; position: absolute;
                                            top: 108px" Width="105px">
                                            <asp:ListItem>小學</asp:ListItem>
                                            <asp:ListItem>國中</asp:ListItem>
                                            <asp:ListItem>大學</asp:ListItem>
                                            <asp:ListItem Selected="True">研究所</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList3" runat="server" Style="left: 121px; position: absolute;
                                            top: 162px" Width="127px">
                                            <asp:ListItem Selected="True">105台北市松山區</asp:ListItem>
                                            <asp:ListItem>551台北市南港區</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="Label20" runat="server" CssClass="D" ForeColor="Blue" Style="z-index: 109;
                                            left: 515px; position: absolute; top: 65px" Width="26px">分機</asp:Label>
                                        <asp:TextBox ID="TextBox14" runat="server" Style="left: 542px; position: absolute;
                                            top: 62px" Width="48px"></asp:TextBox>
                                        
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="position: relative; height: 15px; width: 604px;">
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
                                <td style="height: 4px; width: 604px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 604px;">
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
