<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="p_e0103_02.aspx.cs" Inherits="sys_e_e01_p_e0103_02" %>

<%@ Register Src="../u_e_month_view.ascx" TagName="u_e_month_view" TagPrefix="uc2" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>列印</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

    function printout() {
    if (!window.print){alert("列印功能暫時停用，請按 Ctrl-P 來列印"); return;}
    window.print();}
    function MM_openBrWindow(theURL,winName,features) {
    window.open(theURL,winName,features);}

    </script>

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
                                <td style="height: 4px">
                                        <asp:Label ID="dwF_YM_t" runat="server" Style="position: relative; left: 10px;" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc2:u_e_month_view ID="u_Show" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="bt_print" runat="server" Style="position: relative; left: 317px;" Width="80px" OnClientClick="printout()" CssClass="Bt_Print" Text="　" />
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
