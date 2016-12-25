// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 自訂錯誤頁
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
using Invoke = WIT.Template.Project.Invoke;
using System.Text;

public partial class ErrorPage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
		// 當第一次執行此網頁時
		if (!this.IsPostBack)
		{
			if (Invoke.Setup.LastError == null) return;

			// ##### 宣告變數 #####
			StringBuilder lsb_html = new StringBuilder();
			StringBuilder lsb_msg = new StringBuilder();
			string ls_html_tr = "	<tr>\n		<td width=\"80px\" valign=\"top\">{0}</td>\n		<td><span style=\"color: {2}; font-size: {3}px; font-family: 新細明體;\">{1}</span></td>\n	</tr>\n";

			// 取得錯誤訊息
			lsb_html.Append("<table>\n");
			lsb_html.AppendFormat(ls_html_tr, "錯誤頁面：", this.Request["aspxerrorpath"].ToString(), "blue", "16");
			Exception ErrorEx = Invoke.Setup.LastError.InnerException;
			lsb_msg.Append(ErrorEx.Message.Replace("\n", "<br />"));
			ErrorEx = ErrorEx.InnerException;
			while (ErrorEx != null)
			{
				lsb_msg.Append("<br />" + ErrorEx.Message.Replace("\n", "<br />"));
				ErrorEx = ErrorEx.InnerException;
			}
			lsb_html.AppendFormat(ls_html_tr, "錯誤訊息：", lsb_msg.ToString(), "red", "20");
			lsb_html.AppendFormat(ls_html_tr, "錯誤範圍：", Invoke.Setup.LastError.InnerException.Source, "black", "16");
			lsb_html.AppendFormat(ls_html_tr, "堆疊追蹤：", Invoke.Setup.LastError.InnerException.StackTrace.Replace("\n", "<br />"), "black", "12");
			lsb_html.Append("</table>\n");

			// 清除錯誤訊息
			Invoke.Setup.LastError = null;

			try
			{
				if (Email.uf_SendMail(DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SMTP", "MailSysop", ""),
									"系統發生錯誤回報",
									"<html>\n<body>\n"
									+ (LoginUser.ID != null ? "<table><tr><td width=\"112px\" style=\"color: green\">回報人員帳號：</td><td>" + LoginUser.ID + "</td></tr><tr><td width=\"112px\" style=\"color: green\">回報人員姓名：</td><td>" + LoginUser.Name + "</td></tr><tr><td width=\"112px\" style=\"color: green\">回報人員信箱：</td><td>" + Email.uf_GetMailAddr(LoginUser.ID) + "</td></tr></table>\n" : "<span style=\"color: green\">使用者未登入</span><br />")
									+ "<br />" + lsb_html.ToString() + "</body>\n</html>\n"))
					litr_Msg.Text = "<span style=\"color: red; font-size: 20px; font-family: 新細明體;\">系統發生錯誤，已回報相關人員處理！</span>";
				else
					litr_Msg.Text = lsb_html.ToString();
			}
			catch
			{
				litr_Msg.Text = lsb_html.ToString();
			}
		}
	}
}
