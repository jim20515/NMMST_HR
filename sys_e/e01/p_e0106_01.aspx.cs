// *********************************************************************************
// 1. 程式描述：服務勤務管理–志工服勤統計表–列印
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

public partial class sys_e_e01_p_e0106_01 : p_hrBase
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>

	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeQuery(dwQ, null, null);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			u_Date1.Value = DbMethods.uf_GetDate().ToString();
			u_Date2.Value = DbMethods.uf_GetDate().ToString();
		}
	}

	protected void bt_Print_Click(object sender, EventArgs e)
	{
		//string ls_query = uf_getQuery();
		//if (ls_query == "")
		//{
		//    this.uf_Msg("請選擇欲列印志工！");
		//    return;
		//}

		//this.uf_AddJavaScript("uf_OpenWindow('p_e0106_report.aspx?query=" + ls_query + "','',1024,768,'no','no');");
		if (dwQ_hle201_tid.SelectedValue.Trim() == "")
		{
			uf_Msg("請選擇志工隊");
			return;
		}

		if (u_Date1.Value.Trim() == "" || u_Date2.Value.Trim() == "")
		{
			uf_Msg("請輸入日期區間！");
			return;
		}
		this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_e0601&format=PDF&query=tid=" + dwQ_hle201_tid.SelectedValue.Trim() + ";adt_s=" + u_Date1.Value + ";adt_e=" + u_Date2.Value + "','',1024,768,'no','no');");

	}

}
