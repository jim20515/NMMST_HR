<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="p_f0101A_03.aspx.cs" Inherits="sys_f_f01_p_f0101A_03" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="u_TimeSelect" Src="../../proj_uctrl/u_TimeSelect.ascx" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>認證包含課程</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pn_Contain" runat="server">
 
                                         <asp:Label ID="dwF_name_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: -22px; position: absolute; top: 8px" Width="144px">認證名稱資訊：</asp:Label>
                                        <asp:Label ID="dwF_name" runat="server" CssClass="G" Style="z-index: 124; left: 128px; position: absolute; top: 8px" ForeColor="SlateGray" Width="408px"></asp:Label>
           
                                    <witc:DWPanel ID="dwS" runat="server" CssClass="Form" Height="400px" Style="position: relative; top: 0px; left: 0px;" Width="820px">
                                        <asp:Label ID="Label6" runat="server" ForeColor="Purple" Height="19px" Style="left: 32px; position: relative; top: 21px" Font-Size="10pt">◎選取認證包含的課程</asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Height="12px" Style="left: -94px; position: relative; top: 32px" Font-Size="10pt">未選擇的課程</asp:Label>
                                        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Height="12px" Style="left: 216px; position: relative; top: 32px" Font-Size="10pt">此認證包含課程</asp:Label>
                                        <asp:Button ID="bt_toright" runat="server" Style="left: 320px; position: absolute; top: 96px" Width="80px" OnClick="bt_toright_Click" CssClass="Bt_ToRight" />
                                        <asp:Button ID="bt_toleft" runat="server" Style="left: 320px; position: absolute; top: 152px" Width="80px" OnClick="bt_toleft_Click" CssClass="Bt_ToLeft" />
                                        <asp:Button ID="bt_toreset" runat="server" Style="left: 320px; position: absolute; top: 208px" Width="80px" OnClick="bt_toreset_Click" CssClass="Bt_ToReset" />
                                        <asp:ListBox ID="lb_all" runat="server" Height="247px" Style="left: 39px; position: absolute; top: 56px" Width="272px">
                                        </asp:ListBox>
                                        <asp:ListBox ID="lb_go" runat="server" Height="247px" Style="left: 408px; position: absolute; top: 56px" Width="296px">
                                        </asp:ListBox>
                                    </witc:DWPanel>
          
                                  <asp:Button ID="bt_confirm" runat="server" Style="left: 500px; position: absolute; top: 320px" Width="80px" OnClick="bt_confirm_Click" CssClass="Bt_Conf" />
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
