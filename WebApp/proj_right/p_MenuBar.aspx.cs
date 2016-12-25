// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者權限系統功能選單
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

public partial class proj_right_p_MenuBar : p_MenuPage
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：驗證登入資訊正確所要做的處理（覆蓋上層）
	/// </summary>
	protected override void uf_CheckLogin_Success()
	{
		u_Menu.uf_Build(LoginUser.ID);

		// 在最後增加顯示 MenuTree 的語法
		this.uf_AddJavaScript("top.menutreeFrame.location = \"" + this.Request.ApplicationPath + "/proj_right/p_MenuTree.aspx\";");
	}
}
