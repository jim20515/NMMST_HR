// *********************************************************************************
// 1. 程式描述：系統權限管理–系統群組設定
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

public partial class sys_s_s01_p_s0101_sys01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：系統權限群組資料元件</summary>
	protected ndb_sys01 indb_sys01 = new ndb_sys01();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_sys01, bt_Query);
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys01, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
	}
}
