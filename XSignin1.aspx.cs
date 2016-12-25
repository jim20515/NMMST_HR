// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 登出頁（Session 不存在時利用此頁導到登入頁）
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
using System.Text;

public partial class XSignin1 : p_BasePage
{
    // =========================================================================
    /// <summary>
    /// 事件描述：網頁初始化
    /// </summary>
    protected void Page_Init(object sender, EventArgs e)
    {
        // 不驗證使用者
        this.IsCheckUser = false;
        // 不執行 KeyDown 事件
        this.IsOnKeyDown = false;
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;
    }


	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.IsAJAXScript = true;

        Label1.Text = DbMethods.uf_GetDateTime().ToString("yyyy/MM/dd HH:mm:ss");
    }
}
