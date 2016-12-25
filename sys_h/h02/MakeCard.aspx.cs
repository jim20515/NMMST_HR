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

public partial class MakeCard : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
		// 當第一次執行此網頁時
		if (!this.IsPostBack)
		{
			//if (Invoke.Setup.LastError == null) return;

			// ##### 宣告變數 #####
			StringBuilder lsb_html = new StringBuilder();
			StringBuilder lsb_msg = new StringBuilder();
			string ls_html_tr = "	<tr>\n		<td width=\"80px\" valign=\"top\">{0}</td>\n		<td><span style=\"color: {2}; font-size: {3}px; font-family: 新細明體;\">{1}</span></td>\n	</tr>\n";

			// 取得錯誤訊息
			lsb_html.Append("<table>\n");
			//lsb_html.AppendFormat(ls_html_tr, "錯誤頁面：", this.Request["aspxerrorpath"].ToString(), "blue", "16");
			//Exception ErrorEx = Invoke.Setup.LastError.InnerException;
			//lsb_msg.Append(ErrorEx.Message.Replace("\n", "<br />"));
			//ErrorEx = ErrorEx.InnerException;
			//while (ErrorEx != null)
			//{
			//	lsb_msg.Append("<br />" + ErrorEx.Message.Replace("\n", "<br />"));
			//	ErrorEx = ErrorEx.InnerException;
			//}
			//lsb_html.AppendFormat(ls_html_tr, "錯誤訊息：", lsb_msg.ToString(), "red", "20");
			//lsb_html.AppendFormat(ls_html_tr, "錯誤範圍：", Invoke.Setup.LastError.InnerException.Source, "black", "16");
			lsb_html.Append("</table>\n");

			// 清除錯誤訊息
			//Invoke.Setup.LastError = null;

			try
			{

                string PWidth = "450";
                string PHeight = "600";
                string PICUrl = "http://10.100.1.195/NMMST_HR/WebApp/sys_h/h02/01.jpg";
                string Ax = "40";
                string Ay = "50";
                string STitle = "這是標題唷";
                string SName = "王先生";
                string SContent = "值此佳節，海科館全體工作人員祝您全家平安\n，連粽三元。";
                string MailList = "QFLin@edinet.com.tw";

                string MailBody = "<html>\n <head>		"
                                    + "		<STYLE type=\"text/css\">" + "\r\n"
                                    + "          Bt_Card {  "
                                     + "                	border:0;"
                                     +"           }" 
			                        + "		</STYLE>" + "\r\n"
                                    + "</head><body>\n"
                                    + "  親愛的"+SName+"：<BR><BR>"
                                    + "  <pre>" + SContent + "</pre><BR>"
                                    + "<IMG class=\"Bt_Card\" src=\"" + PICUrl + "\"></IMG>"
									+ "</body>\n</html>\n";

                Email.uf_SendMail(MailList ,STitle,MailBody);

			}
			catch
			{
				litr_Msg.Text = lsb_html.ToString();
			}
		}
	}
}
