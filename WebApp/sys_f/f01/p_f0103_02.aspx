<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0103_02.aspx.cs" Inherits="sys_f_f01_p_f0103_02" %>

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
                                <td style="width: 605px;">
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
                                    <asp:Button ID="Button3" runat="server" CssClass="B" Style="position: relative; left: 11px;
                                        top: 0px;" Text="列印報表名冊" Width="98px" />
                                    <asp:Button ID="Button7" runat="server" CssClass="B" Style="position: relative; left: 16px;
                                        top: 0px;" Text="批次刪除" Width="75px" />
                                    <asp:Button ID="Button6" runat="server" CssClass="B" Style="position: relative; left: 190px;
                                        top: 0px;" Text="新增" Width="55px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="B" Style="position: relative; left: 191px;
                                        top: 0px;" Text="修改" Width="55px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="B" Style="position: relative; left: 191px;
                                        top: 0px;" Text="刪除" Width="55px" />
                                    <asp:Button ID="Button5" runat="server" CssClass="B" Style="position: relative; left: 191px;
                                        top: 0px;" Text="清除" Width="55px" />
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
