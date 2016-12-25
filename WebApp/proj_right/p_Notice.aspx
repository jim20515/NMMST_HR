<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_Notice.aspx.cs" Inherits="proj_right_p_Notice" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>公告</title>
	<link href="../proj_css/s_Frame.css" rel="stylesheet" type="text/css" />
	<link href="../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Panel ID="pn_Contain" runat="server">
			<asp:DataList ID="dlG" runat="server" DataSource="<%# idv_sys07 %>" Width="98%" EnableViewState="False">
				<HeaderTemplate>
					<table class="Frame_NoticeTable">
						<tr>
							<td class="Frame_NoticeHeader" style="width: 60">公告日期</td>
							<td class="Frame_NoticeHeader">公告標題</td>
							<td class="Frame_NoticeHeader" style="width: 100">公告單位</td>
						</tr>
					</table>
				</HeaderTemplate>
				<ItemTemplate>
					<table class="Frame_NoticeTable">
						<tr>
							<td class="Frame_NoticeIMG" colspan="3">
								<img alt="" align="absMiddle" src='<%# uf_Dg_BindIMG(DataBinder.Eval(Container, "DataItem.s07_pdate")) %>' />
							</td>
						</tr>
						<tr>
							<td class="Frame_NoticeDate" style="width: 60" valign="top">
								<asp:Label ID="dlG_s07_pdate" runat="server" Text='<%# "[" + WIT.Template.Project.DateMethods.uf_YYYY_To_YYY(Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.s07_pdate")).ToString("yyyy/MM/dd")) + "]" %>'></asp:Label>
							</td>
							<td class="Frame_NoticeTitle" valign="top">
								<asp:Label ID="dlG_s07_title" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s07_title") %>'></asp:Label>
								<asp:HyperLink ID="dlG_s07_title_show" runat="server" CssClass="Frame_NoticeShow" NavigateUrl='<%# "javascript:uf_doSwitch(\"pn_" + DataBinder.Eval(Container, "DataItem.s07_no").ToString() + "\");" %>' Text="&nbsp;&nbsp;(詳見／隱藏)" Visible='<%# uf_Dg_BindBool("Y,", DataBinder.Eval(Container, "DataItem.s07_content")) %>'></asp:HyperLink>
								<asp:HyperLink ID="dlG_s07_url" runat="server" CssClass="Frame_NoticeUrl" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.s07_url") %>' Target="_blank" Text="&nbsp;&nbsp;(相關連結)" Visible='<%# uf_Dg_BindBool("Y,", DataBinder.Eval(Container, "DataItem.s07_url")) %>'></asp:HyperLink>
							</td>
							<td class="Frame_NoticeUnit" style="width: 100" valign="top">
								<asp:Label ID="dlG_s07_unit" runat="server" Text='<%# uf_Dg_Bind("hca202", DataBinder.Eval(Container, "DataItem.s07_unit")) %>'></asp:Label>
							</td>
						</tr>
					</table>
					<div id='<%# "pn_" + DataBinder.Eval(Container, "DataItem.s07_no").ToString() %>' class="Frame_NoticeContent" style="display: none">
						<asp:Label ID="dlG_s07_content" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s07_content").ToString().Replace(Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(), "<br>").Replace(Convert.ToChar(10).ToString(), "<br>").Replace(Convert.ToChar(13).ToString(), "<br>") %>'></asp:Label>
					</div>
				</ItemTemplate>
			</asp:DataList>
		</asp:Panel>
		<script language="JavaScript" type="text/javascript">
				function uf_doSwitch(as_ObjName)
				{
					var lo_obj;

					lo_obj = document.getElementById(as_ObjName);
					if (lo_obj == null) return;

					if (lo_obj.style.display == "none")
						lo_obj.style.display = "block";
					else
						lo_obj.style.display = "none";
				}
		</script>
	</div>
    </form>
</body>
</html>
