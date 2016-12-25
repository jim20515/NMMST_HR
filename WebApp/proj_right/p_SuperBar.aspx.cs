// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 進階管理者功能選單
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

public partial class proj_right_p_SuperBar : p_SuperPage
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 不允許使用鍵盤
		this.IsCheckKeyin = true;
    }

	// =========================================================================
	/// <summary>
	/// 函式描述：驗證登入資訊正確所要做的處理（覆蓋上層）
	/// </summary>
	protected override void uf_CheckLogin_Success()
	{
		// ##### 宣告變數 #####
		string ls_ret = "";

		// 進階管理者 MenuBar
		ls_ret += "		<table class=\"MenuBar\" id=\"MenuBar\">" + "\r\n";
		ls_ret += "			<tr>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\" style=\"width:100px;\"><a tabindex=\"-1\" class=\"MBILink\" href=\"javascript:uf_Link('p_SuperQuery.aspx')\">動態語法查詢</a></td>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\" style=\"width:100px;\"><a tabindex=\"-1\" class=\"MBILink\" href=\"javascript:uf_Link('p_SuperExec.aspx')\">動態語法執行</a></td>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\" style=\"width:116px;\"><a tabindex=\"-1\" class=\"MBILink\" href=\"javascript:uf_Link('p_SuperDbcollength.aspx')\">產生欄位長度清單</a></td>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\" style=\"width:100px;\"><a tabindex=\"-1\" class=\"MBILink\" href=\"javascript:uf_Link('p_SuperWITCrypto.aspx')\">字串加解密</a></td>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\"></td>" + "\r\n";
		ls_ret += "				<td class=\"MBItem\" style=\"width:50px;\"><a tabindex=\"-1\" class=\"MBILink\" href=\"javascript:top.window.close()\">離開</a></td>" + "\r\n";
		ls_ret += "			</tr>" + "\r\n";
		ls_ret += "		</table>" + "\r\n";
		ls_ret += "		<script language=\"javascript\">" + "\r\n";
		ls_ret += "			function uf_Link(as_Url)" + "\r\n";
		ls_ret += "			{" + "\r\n";
		ls_ret += "				top.contentFrame.location = as_Url + \"" + ((this.Request["key"] != null) ? "?key=" + this.Request["key"].Trim() : "") + "\";" + "\r\n";
		ls_ret += "			}" + "\r\n";
		ls_ret += "		</script>" + "\r\n";

		litr_MenuBar.Text = ls_ret;
	}
}
