// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者名稱部門
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

public partial class proj_right_p_Ver : p_MenuPage
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        litr_Ver.Text = "	<span style=\"font-size: 14px;  text-align: center; width: 100%; padding: 2px\">VER：2011.0715.1</span>" + "\n";
   	}
}
