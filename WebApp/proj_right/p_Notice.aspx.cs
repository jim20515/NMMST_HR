// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者公告訊息
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

public partial class proj_right_p_Notice : p_BasePage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：公告管理資料集</summary>
	protected DataSet ids_sys07;
	/// <summary>變數描述：公告管理資料介面</summary>
	protected DataView idv_sys07;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 取出符合條件的公告資料
		DbMethods.uf_Retrieve_FromSQL(out this.ids_sys07, "SELECT * FROM sys07 WHERE s07_pdate <= GetDate() AND IsNull(s07_edate, Convert(datetime, '9999/12/31')) >= GetDate() AND IsNull(s07_stop, 'N') = 'N' AND IsNull(RTrim(s07_tounit), '0') in ('0', '" + LoginUser.DeptID + "')");
		this.idv_sys07 = this.ids_sys07.Tables[0].DefaultView;
		this.idv_sys07.Sort = "s07_pdate DESC, s07_sort, s07_no DESC";

		// 繫結資料
		if (this.idv_sys07.Count > 0)
			dlG.DataBind();
		else
			dlG.Visible = false;
	}

	#region ☆ DataList Bind Methods ---------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：資料繫結–利用公告日期判斷是否為一週內的公告，是則顯示 New 的圖
	/// </summary>
	/// <param name="ao_Value">資料值</param>
	/// <returns>顯示的圖所在位置</returns>
	protected string uf_Dg_BindIMG(object ao_Value)
	{
		if (Convert.ToInt32(Convert.ToDateTime(ao_Value).ToString("yyyyMMdd")) > Convert.ToInt32(DateTime.Now.AddDays(-7).ToString("yyyyMMdd")))
			return this.Request.ApplicationPath + "/proj_img/NoticeNew.gif";
		else
			return this.Request.ApplicationPath + "/proj_img/Notice.gif";
	}

	#endregion

}
