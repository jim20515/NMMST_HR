// *********************************************************************************
// 1. 程式描述：系統權限管理–使用者帳號管理
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

public partial class sys_s_s01_p_s0104_user01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：使用者帳號資料元件</summary>
	protected ndb_user01 indb_user01 = new ndb_user01();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_user01, bt_Query);
		this.uf_InitializeComponent(dwF, dgG, this.indb_user01, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		//this.dgG_Retrieve = " AND IsNull(user01_flag, 'N') = '1' ";

		// 設定資料初始值
		//this.indb_user01.dv_View.Table.Columns["user01_flag"].DefaultValue = "1";
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 dgG 某筆資料所做的處理
	/// </summary>
	protected void dgG_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
	{
		if (e.CommandName != "SelectPwd") return;

		// ##### 宣告變數 #####
		string ls_userid = dgG.DataKeys[e.Item.ItemIndex].ToString().Trim();

		// 判斷使用者是否有 Email，有則亂數產生密碼直接寄送
		int li_find = this.indb_user01.uf_FindSortIndex(ls_userid);
		if (li_find >= 0 && this.indb_user01[li_find]["user01_email"].ToString().Trim() != "")
		{
			WIT.Template.Project.Invoke.Setup.uf_SetPasswd(ls_userid);
			this.uf_Msg("密碼已自動產生，並寄發 Email 通知使用者");
			return;
		}

		// 將參數加密
		WITCrypto lo_Crypto = new WITCrypto();
		ls_userid = lo_Crypto.uf_Encrypt(ls_userid);

		// 開啟 p_s010401_pwd.aspx 並傳遞參數
		//this.uf_AddJavaScript("window.open(\"p_s010401_pwd.aspx?UserID=" + ls_userid + "\",\"\",\"top=200,left=220,height=156px,width=296px,status=no,toolbar=no,menubar=no,location=no\",\"\")");
		this.uf_AddJavaScript("window.showModalDialog('p_s010401_pwd.aspx?UserID=" + ls_userid + "', window, 'dialogHeight:' + uf_FixHeight(156) + 'px;dialogWidth:' + uf_FixWidth(296) + 'px;resizable:yes;status:no;')");
	}
}
