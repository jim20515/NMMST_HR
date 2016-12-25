// *********************************************************************************
// 1. 程式描述：志工管理–刷卡外網相關–教育訓練刷卡頁面
// 2. 撰寫人員：rong
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

public partial class sys_d_d04_p_d0402_01 : p_hrBase
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.uf_AddJavaScript("window.open(\"" + this.Request.ApplicationPath + "/SignPage2.htm\");");
	}
}

