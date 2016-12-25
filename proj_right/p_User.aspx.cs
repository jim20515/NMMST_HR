// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者名稱部門
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;

public partial class proj_right_p_User : p_MenuPage
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// Put user name into cell "User".
		litr_User.Text = "	<table border=\"0\" style=\"border-collapse: collapse; padding: 0 0 0 0; margin: 0 0 0 0;\">" + "\n";
		litr_User.Text += "		<tr>" + "\n";
		//litr_User.Text += "			<td><img alt=\"\" src=\"" + this.Request.ApplicationPath + "/proj_img/User.gif\" style=\"cursor=hand\" title=\"變更使用者密碼\" onclick=\"uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_right/p_Passwd.aspx?ReturnFormID=" + this.uf_GetFormID() + "', '', 296, 156, 'no', 'no')\"></td>" + "\n";
		litr_User.Text += "			<td><img alt=\"\" src=\"" + this.Request.ApplicationPath + "/proj_img/User.gif\" style=\"cursor=hand\" title=\"變更使用者密碼\" onclick=\"window.showModalDialog('" + this.Request.ApplicationPath + "/proj_right/p_Passwd.aspx?ReturnFormID=" + this.uf_GetFormID() + "', window, 'dialogHeight:' + uf_FixHeight(156) + 'px;dialogWidth:' + uf_FixWidth(296) + 'px;resizable:yes;status:no;')\"></td>" + "\n";
		litr_User.Text += "			<td class=\"Frame_User\" valign=\"middle\">" + LoginUser.Name + "&nbsp;&nbsp;<span style=\"font-size: 12px\">(" + LoginUser.ID + ")</span></td>" + "\n";
		litr_User.Text += "		</tr>" + "\n";
		litr_User.Text += "	</table>";
		litr_User.Text += "<script language=\"javascript\">top.document.title = \"" + WIT.Template.Project.Invoke.Setup.is_AppName + "\";</script>";
	}
}
