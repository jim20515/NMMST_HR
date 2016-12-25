<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_04.aspx.cs" Inherits="sys_d_d02_p_d0201_04" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC"
    TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow"
    TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教育訓練</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pn_Contain" runat="server">
                    
                    		<asp:Label ID="dwF_hmd201_vid_t" runat="server" CssClass="D" Style="z-index:99; left:0px; position: absolute; top:16px" Width="100px">◎志工姓名：</asp:Label>
							<asp:Label ID="dwF_hmd201_vid" runat="server" CssClass="G" Style="z-index: 100; left:104px; position: absolute; top: 16px" Width="150px"></asp:Label>
                            <br />
                    <br />
                        <table class="G" style="height: 489px">
                        <tr>
                                <td style="height: 18px; width: 605px;">
                                    <witc:DWPanel ID="dwQ" runat="server" CssClass="Query" Height="38px" Style="position: relative; left: 1px; top: 2px;" Width="800px">

                                      	<asp:Label ID="dwQ_Year_t" runat="server" CssClass="Q" Style="z-index: 114; left:8px; position: absolute; top:10px" Width="100px">年度：</asp:Label>
                                        <asp:TextBox ID="dwQ_Year" runat="server" Style="z-index: 115; left:112px; position: absolute; top:6px"  Width="100px" >098</asp:TextBox>
                                        &nbsp;
							           <asp:Button ID="bt_Query" runat="server" CssClass="Bt_Search" Style="z-index: 999; left:712px; position: absolute; top:4px" Text="" Width="80px" OnClick="bt_Query_Click" />

                                        &nbsp;
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 106px; width: 605px;">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="415px" Style="position: relative;left: 3px; top: 11px;" Width="800px">

										<asp:Literal ID="Literal1" runat="server"></asp:Literal><br /> 
                                    </witc:DWPanel>
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
