// *********************************************************************************
// 1. 程式描述：系統權限管理–使用者帳號管理–變更使用者密碼
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

public partial class sys_s_s01_p_s010401_pwd : p_WebPage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：使用者帳號</summary>
	private string is_UserID = "";

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		if (this.Request["UserID"] != null)
			this.is_UserID = this.Request["UserID"].Trim();

		// 將參數解密
		WITCrypto lo_Crypto = new WITCrypto();
		this.is_UserID = lo_Crypto.uf_Decrypt(this.is_UserID);

		// 如果沒有傳入使用者帳號則離開不處理
		if (this.is_UserID == "") goto Exit_Close;

		return;

	Exit_Close:
		this.uf_AddJavaScript("close();");
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Sure 《確定》按鈕所做的處理
	/// </summary>
	protected void bt_Sure_Click(object sender, System.EventArgs e)
	{
		if (dwF_new.Text.IndexOfAny(new char[3] { '\'', '"', '\\' }) >= 0)
		{
			this.uf_Msg("輸入不合法的字元「' \" \\\\」！");
			this.uf_SetFocus(dwF_new);
			return;
		}
		if (dwF_renew.Text.IndexOfAny(new char[3] { '\'', '"', '\\' }) >= 0)
		{
			this.uf_Msg("輸入不合法的字元「' \" \\\\」！");
			this.uf_SetFocus(dwF_renew);
			return;
		}

		// 判斷輸入的密碼是否相合
		if (dwF_new.Text.Trim() != dwF_renew.Text.Trim())
		{
			this.uf_Msg("新密碼不一致！");
			dwF_new.Text = "";
			dwF_renew.Text = "";
			this.uf_SetFocus(dwF_new);
			return;
		}

		// 修改使用者密碼
		if (Invoke.Setup.uf_SetPasswd(this.is_UserID, dwF_new.Text.Trim()))
			this.uf_AddJavaScript("window.alert(\"密碼已更改！\\n請自行通知使用者！\"); close();");
		else
			this.uf_Msg("密碼變更失敗！");
	}
}
