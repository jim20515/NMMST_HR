<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_h0101_01.aspx.cs" Inherits="sys_h_h01_p_h0101_01" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
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
                                <td>
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="600px" Style="position: relative; left: 1px; top: 2px;" Width="800px">
                                        <asp:Label ID="dwQ_hmh101_epyear_t" runat="server" CssClass="N" Style="z-index: 101; left: 39px; position: absolute; top: 15px">簡訊內容：</asp:Label>
                                        <asp:Label ID="Label2" runat="server" CssClass="D" ForeColor="Black" Style="z-index: 101; left: 108px; position: absolute; top: 200px">提醒您純英文數字超過 160 字元或中英文數字混合超過 70 個字元，將以長簡訊發送。</asp:Label>
                                        <asp:Label ID="Label3" runat="server" CssClass="D" ForeColor="Black" Style="z-index: 101; left: 108px; position: absolute; top: 525px">按 Enter 或逗號可輸入更多門號 </asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="dwF_show1" runat="server" Style="z-index: 101; left: 108px; position: absolute; top: 180px">目前輸入</asp:Label>
                                        <asp:Label ID="dwF_show3" runat="server" Style="z-index: 101; left: 239px; position: absolute; top: 180px">字元，則數</asp:Label>
                                        <asp:Label ID="Label1" runat="server" Style="z-index: 101; left: 357px; position: absolute; top: 180px">則</asp:Label>
                                        <asp:TextBox ID="dwF_show2" runat="server" ForeColor="Red" Style="z-index: 101; left: 184px; position: absolute; top: 176px" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" Width="79px"></asp:TextBox>
                                        <asp:TextBox ID="dwF_show4" runat="server" ForeColor="Red" Style="z-index: 101; left: 321px; position: absolute; top: 176px" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"></asp:TextBox>
                                        <asp:TextBox ID="dwF_msg" runat="server" Style="left: 107px; position: absolute; top: 12px" Width="566px" Height="156px" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Label ID="dwQ_hmh101_pno_t" runat="server" CssClass="N" Style="z-index: 101; left: 36px; position: absolute; top: 366px">接收門號 ：</asp:Label>
                                        <asp:Label ID="dwF_list_t" runat="server" CssClass="N" Style="z-index: 101; left: 36px; position: absolute; top: 225px">接收人員 ：</asp:Label>
                                        <asp:TextBox ID="dwF_num" runat="server" Height="147px" Style="left: 107px; position: absolute; top: 366px" TextMode="MultiLine" Width="566px"></asp:TextBox>
                                        <asp:TextBox ID="dwF_list" runat="server" Style="left: 107px; position: absolute; top: 225px" Width="566px" Height="125px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                        <asp:Button ID="bt_Conf" runat="server" CssClass="Bt_Conf" Style="z-index: 114; left: 341px; position: absolute; top: 554px" Width="83px" OnClick="bt_Conf_Click" />
                                        <asp:Button ID="bt_list" runat="server" CssClass="Bt_EditNList" Style="z-index: 114; left: 697px; position: absolute; top: 228px" Width="83px" OnClick="bt_list_Click" />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 8px; width: 605px;">
                                    <asp:HiddenField ID="dwF_list_hf" runat="server" />
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

<script type="text/javascript">      

function uf_ShowCount(ao_value)
{
	 var li_count = ao_value.value.length;
	 var li_msgcount = uf_CountMsg(ao_value);
	 
	 var lo_obj;
    document.getElementById("dwF_show2").value = li_count;
	document.getElementById("dwF_show4").value = li_msgcount;	
}

</script>


</html>
