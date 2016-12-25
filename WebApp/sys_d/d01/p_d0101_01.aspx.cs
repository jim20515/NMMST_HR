// *********************************************************************************
// 1. 程式描述：志工資料管理﹒志工隊管理﹒查詢及清單
// 2. 撰寫人員：QFLin
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

public partial class sys_d_d01_p_d0101_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hmd101 indb_hmd101 = new ndb_hmd101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_hmd101, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hmd101, null);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：dgG 選擇某筆資料所要做的處理
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
		this.uf_AddJavaScript("uf_LinkFrame('p_d0101_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "')");
	}
}
