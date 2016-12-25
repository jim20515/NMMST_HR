
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
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

public partial class sys_g_g02_p_g0202 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

	/// <summary>變數描述：公告管理資料元件</summary>
    //protected ndb_aec02 indb_aec02 = new ndb_aec02();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        DataSet lds_data;
        DataView ldv_dataview;

        string ls_query = "";
        ls_query = @"select * , dbo.uf_getvyearplus(hmd201_vid) as getvyear , (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND SDT > IsNull(hmd201_lappdt,'') ) as onduty
                    From hmd201 Inner Join hmd101 ON hmd201_tid = hmd101_tid 
                    Where dbo.uf_getvyearplus(hmd201_vid) >= 3
                    AND (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND SDT > IsNull(hmd201_lappdt,'') )  >= 300";

        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_query);
        ldv_dataview = lds_data.Tables[0].DefaultView;
        dgG.DataSource = ldv_dataview;
        dgG.DataBind();
      
	}
    protected void Bt_Print_Click(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_g0202&format=PDF','',1024,768,'no','no');");
    }
}
