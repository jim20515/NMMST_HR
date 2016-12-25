<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0201_04.aspx.cs" Inherits="sys_h_h02_p_h0201_04" %>

<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>請選擇要用的圖檔</title>
    <style type="text/css">
    TABLE.content_Blue   {
                           font-size:10pt;
                           color: #727272;                     
                           border-color:#000040;
                           border-style:solid;
                           border-width:1px;
                           border-collapse:collapse;
                font-family:"Calibri", "mingliu", "taipei"}
    </style>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />

    <script language="JavaScript" type="text/javascript">
        function uf_Sender(as_msg)
		{
			if (opener.document.getElementById("dwF_hmh201a_picurl") != null)
			    opener.document.all.dwF_hmh201a_picurl.value = as_msg;
			if (opener.document.getElementById("dwF_hmh201a_picurl_hf") != null)
			    opener.document.all.dwF_hmh201a_picurl_hf.value = as_msg;
			close();
		}
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
                                <td>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px">
                                    &nbsp;</td>
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
