// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 進階管理者功能導引頁
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

public partial class proj_right_p_SuperLead : p_SuperPage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：要寫出的 HTML 語法</summary>
	private string is_Html;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：產生功能導引頁
	/// </summary>
	/// <param name="ab_IsTrue">密碼是否正確</param>
	private void uf_BuildFrame(bool ab_IsTrue)
	{
		// ##### 宣告變數 #####
		string ls_ret = "";

		// 功能導引頁
		ls_ret += "<html>" + "\r\n";
		ls_ret += "<head>" + "\r\n";
		ls_ret += "	<title>環域科技共用函式庫–進階管理者選單</title>" + "\r\n";
		ls_ret += "	<script language=\"javascript\">" + "\r\n";
		ls_ret += "		if (top.opener == null)" + "\r\n";
		if (LoginUser.ID == null)
			ls_ret += "			top.location = \"" + this.Request.ApplicationPath + "/Login.aspx\";" + "\r\n";
		else
			ls_ret += "			top.location = \"" + this.Request.ApplicationPath + "/frame.htm\";" + "\r\n";
		ls_ret += "		else if (top.opener.top.location.toString().indexOf(\"frame.htm\") == -1)" + "\r\n";
		ls_ret += "			top.close();" + "\r\n";
		ls_ret += "	</script>" + "\r\n";
		ls_ret += "</head>" + "\r\n";
		if (ab_IsTrue)
		{
			ls_ret += "<frameset rows=\"60px,20px,*\" frameborder=\"no\" framespacing=\"0\" border=\"0\">" + "\r\n";
			ls_ret += "	<frame name=\"topFrame\" src=\"" + this.Request.ApplicationPath + "/top.htm\" scrolling=\"no\" noresize=\"noresize\">" + "\r\n";
			ls_ret += "	<frame name=\"menuFrame\" src=\"p_SuperBar.aspx" + ((this.Request["key"] != null) ? "?key=" + this.Request["key"].Trim() : "") + "\" scrolling=\"no\" noresize=\"noresize\" datafld=\"contentFrame\">" + "\r\n";
			ls_ret += "	<frame name=\"contentFrame\" src=\"about:blank\" scrolling=\"auto\" marginheight=\"0\">" + "\r\n";
			ls_ret += "</frameset>" + "\r\n";
			ls_ret += "<noframes>" + "\r\n";
			ls_ret += "</noframes>" + "\r\n";
		}
		else
		{
			ls_ret += "<script language=\"javascript\">" + "\r\n";
			ls_ret += "	alert(\"您所輸入的通關密碼不正確\");" + "\r\n";
			ls_ret += "	top.close();" + "\r\n";
			ls_ret += "</script>" + "\r\n";
		}
		ls_ret += "</html>";

		is_Html = ls_ret;
	}

	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 事件描述：指定輸出的 HTML（覆蓋上層）
	/// </summary>
	/// <param name="output">指定要輸出的 HTML 寫入器 (HTMLTextWriter)</param>
	protected override void Render(System.Web.UI.HtmlTextWriter output)
	{
		if (is_Html == "")
			base.Render(output);
		else
			output.Write(is_Html);

		if (LoginUser.ID == null)
		{
			output.WriteLine("	<script language=\"javascript\">" + "\r\n");
			output.WriteLine("		if (top.opener == null)" + "\r\n");
			output.WriteLine("			top.location = \"" + this.Request.ApplicationPath + "/Login.aspx" + "\";" + "\r\n");
			output.WriteLine("		else" + "\r\n");
			output.WriteLine("		{" + "\r\n");
			output.WriteLine("			top.close();" + "\r\n");
			output.WriteLine("			top.opener.top.location = \"" + this.Request.ApplicationPath + "/Login.aspx" + "\";" + "\r\n");
			output.WriteLine("		}" + "\r\n");
			output.WriteLine("	</script>" + "\r\n");
		}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：驗證登入資訊正確所要做的處理（覆蓋上層）
	/// </summary>
	protected override void uf_CheckLogin_Success()
	{
		// 產生操作功能導引頁
		this.uf_BuildFrame(this.IsKeyCorrect);
	}

	#endregion

}
