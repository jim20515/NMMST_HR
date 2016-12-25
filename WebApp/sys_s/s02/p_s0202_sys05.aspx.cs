// *********************************************************************************
// 1. 程式描述：系統選單管理–系統設定
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

public partial class sys_s_s02_p_s0202_sys05 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：系統系統資料元件</summary>
	protected ndb_sys05 indb_sys05 = new ndb_sys05();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys05, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
	}
}
