<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_g0102_02.aspx.cs" Inherits="sys_g_g01_p_g0102_02" %>
<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
					<td>
						<witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="415px" Style="position: relative" Width="820px">

                                        <br />
                                        <br />
                                         <asp:Label ID="dwF_name_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 0px; position: absolute; top: 8px" Width="144px">要列印的考核名稱：</asp:Label>
                                        <asp:Label ID="dwF_name" runat="server" CssClass="G" Style="z-index: 124; left: 152px; position: absolute; top: 8px" ForeColor="SlateGray" Width="368px"></asp:Label>
                                        <asp:Label ID="dwF_ktype_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 32px; position: absolute; top: 32px" Width="112px">考核種類：</asp:Label>
                                        <asp:Label ID="dwF_ktype" runat="server" CssClass="G" Style="z-index: 124; left: 152px; position: absolute; top: 32px" ForeColor="SlateGray" Width="136px"></asp:Label>                       
                                        
                                        <asp:Label ID="dwF_vcount_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 32px; position: absolute; top: 56px" Width="112px">此次應考核人數：</asp:Label>
                                        <asp:Label ID="dwF_vcount" runat="server" CssClass="G" Style="z-index: 124; left: 160px; position: absolute; top: 56px" ForeColor="SlateGray" Width="136px"></asp:Label>

                                        <asp:Label ID="dwF_KTime_t" runat="server" CssClass="D" ForeColor="SlateGray" Style="z-index: 109; left: 8px; position: absolute; top: 80px" Width="136px">此次考核時間基準：</asp:Label>
                                        <asp:Label ID="dwF_KTime" runat="server" CssClass="G" Style="z-index: 124; left: 152px; position: absolute; top: 80px" ForeColor="SlateGray" Width="544px"></asp:Label>
                                        
                                        <asp:Button ID="bt_report1" runat="server" CssClass="B" Style="position: absolute; left: 104px; top: 120px;" Text="全員年考核表產出" Width="137px" CausesValidation="False" OnClick="bt_report1_Click" />
                                        <asp:Button ID="bt_report2" runat="server" CssClass="B" Style="position: absolute; left: 256px; top: 120px;" Text="一覽表產出" Width="137px" OnClick="bt_report2_Click" />

						</witc:DWPanel>
					</td>
				</tr>
				<tr>
					<td style="height: 4px">
					</td>
				</tr>
				<tr>
					<td>
						<div style="position: relative; float: right">
							<uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
						</div>
					</td>
				</tr>
				<tr>
					<td style="height: 8px">
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
