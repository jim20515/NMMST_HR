// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–字串加解密
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

public partial class proj_right_p_SuperWITCrypto : p_SuperPage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：加解密服務元件</summary>
	private WITCrypto io_Crypto = new WITCrypto();

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
	/// 事件描述：按下 bt_Encrypt 《加密》按鈕所做的處理
	/// </summary>
	protected void bt_Encrypt_Click(object sender, EventArgs e)
	{
		if (tbx_Key.Text.Trim() != "")
			this.io_Crypto.HexKey = tbx_Key.Text.Trim();
		if (tbx_IV.Text.Trim() != "")
			this.io_Crypto.HexIV = tbx_IV.Text.Trim();
		tbx_After.Text = this.io_Crypto.uf_Encrypt(tbx_Before.Text);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Decrypt 《解密》按鈕所做的處理
	/// </summary>
	protected void bt_Decrypt_Click(object sender, EventArgs e)
	{
		if (tbx_Key.Text.Trim() != "")
			this.io_Crypto.HexKey = tbx_Key.Text.Trim();
		if (tbx_IV.Text.Trim() != "")
			this.io_Crypto.HexIV = tbx_IV.Text.Trim();
		tbx_Before.Text = this.io_Crypto.uf_Decrypt(tbx_After.Text);
	}
}
