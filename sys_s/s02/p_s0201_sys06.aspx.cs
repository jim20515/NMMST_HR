// *********************************************************************************
// 1. 程式描述：系統選單管理–系統模組設定
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

public partial class sys_s_s02_p_s0201_sys06 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：系統模組資料元件</summary>
	protected ndb_sys06 indb_sys06 = new ndb_sys06();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys06, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
	}
}
