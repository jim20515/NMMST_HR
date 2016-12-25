<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_f0302_02.aspx.cs" Inherits="sys_f_f03_p_f0302_02" %>

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
                                <td style="width: 605px; height: 188px;">
                                    
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="171px" Style="position: relative;
                                        left: 3px; top: 5px;" Width="800px">
                                        <asp:Label ID="Label5" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 10px; text-align: right" Text="課名：" Width="65px"></asp:Label>
                                        <asp:Label ID="Label11" runat="server" ForeColor="Gray" Style="left: 95px; position: absolute;
                                            top: 10px; text-align: left" Text="基本養魚教學" Width="102px"></asp:Label>
                                        <asp:Label ID="Label12" runat="server" ForeColor="Gray" Style="left: 95px; position: absolute;
                                            top: 35px; text-align: left" Text="T097_0001_01" Width="102px"></asp:Label>
                                        <asp:Label ID="Label13" runat="server" ForeColor="Gray" Style="left: 95px; position: absolute;
                                            top: 60px; text-align: left" Text="32 人" Width="102px"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" ForeColor="Gray" Style="left: 96px; position: absolute;
                                            top: 85px; text-align: left" Text="32 人" Width="102px"></asp:Label>
                                        <asp:Label ID="Label15" runat="server" ForeColor="Gray" Style="left: 97px; position: absolute;
                                            top: 111px; text-align: left" Text="28 人" Width="102px"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 34px; text-align: right" Text="訓練代碼：" Width="65px"></asp:Label>
                                        <asp:Label ID="Label7" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 60px; text-align: right" Text="參加人數：" Width="65px"></asp:Label>
                                        <asp:Label ID="Label8" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 85px; text-align: right" Text="到課人數：" Width="65px"></asp:Label>
                                        <asp:Label ID="Label9" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 112px; text-align: right" Text="通過人數：" Width="65px"></asp:Label>
                                        <asp:Label ID="Label10" runat="server" ForeColor="Blue" Style="left: 21px; position: absolute;
                                            top: 140px; text-align: right" Text="文號：" Width="65px"></asp:Label>
                                        <asp:TextBox ID="TextBox4" runat="server" Style="left: 97px; position: absolute;
                                            top: 136px"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" OnClientClick="location.href='p_f0301.aspx'"
                                            Style="left: 189px; position: absolute; top: 108px" Text="查看通過名單" Width="100px" />
                                        
                                        
                                        </witc:DWPanel>
                                </td>
                            </tr>
                          
                        
                           
                                <td style="height: 16px; width: 605px;">
                                    &nbsp;<asp:Button ID="Button2" runat="server" Style="left: 518px; position: relative;
                                        top: 2px" Text="核定認證" />
                                    <asp:Button ID="Button3" runat="server" Style="left: 313px; position: relative; top: 3px"
                                        Text="列印認證貼紙" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table></asp:Panel>
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
