
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

public partial class sys_g_g01_p_g0201 : p_sBase
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
        dwQ_year.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_year.ClientID + ");";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            int li_year = DbMethods.uf_GetDate().Year - 1911;
            this.dwQ_year.Text = li_year.ToString("000");
            this.bt_Query_Click(sender, EventArgs.Empty);
        }

	}
    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (dwQ_year.Text.Trim() == "")
        {
            this.uf_Msg("請輸入查詢年度！");
            return;
        }

        DataSet lds_data, lds_data1, lds_data2;
        DataView ldv_dataview, ldv_dataview1, ldv_dataview2;

        string ls_query = "", ls_query1 = "", ls_query2 = "" , ls_year = Convert.ToString(Convert.ToInt16(dwQ_year.Text) + 1911);
        ls_query = "select * , dbo.uf_getvyearplus(hmd201_vid) as getvyear , (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ")  as onduty";
        ls_query += " From hmd201 Inner Join hmd101 ON hmd201_tid = hmd101_tid"; 
        ls_query += " Where dbo.uf_getvyearplus(hmd201_vid) >= 3";
		ls_query += " AND (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") >= 600 ";
		ls_query += " AND NOT ( (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") >= 1000 AND dbo.uf_getvyearplus(hmd201_vid) >= 5 ) ";

        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_query);
        ldv_dataview = lds_data.Tables[0].DefaultView;
        dgG.DataSource = ldv_dataview;
        dgG.DataBind();

		ls_query1 = "select * , dbo.uf_getvyearplus(hmd201_vid) as getvyear , (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") as onduty";
		ls_query1 += " From hmd201 Inner Join hmd101 ON hmd201_tid = hmd101_tid";
		ls_query1 += " Where dbo.uf_getvyearplus(hmd201_vid) >= 5";
		ls_query1 += " AND (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") >= 1000 ";
		ls_query1 += " AND NOT ( (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") >= 1800 AND dbo.uf_getvyearplus(hmd201_vid) >= 10 ) ";

        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data1, ls_query1);
        ldv_dataview1 = lds_data1.Tables[0].DefaultView;
        dgG1.DataSource = ldv_dataview1;
        dgG1.DataBind();

        ls_query2 = "select * , dbo.uf_getvyearplus(hmd201_vid) as getvyear , (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") as onduty";
        ls_query2 += " From hmd201 Inner Join hmd101 ON hmd201_tid = hmd101_tid";
		ls_query2 += " Where dbo.uf_getvyearplus(hmd201_vid) >= 10";
		ls_query2 += " AND (SELECT IsNUll(SUM(onduty),0) FROM hme101bc WHERE vid = hmd201_vid AND NOT(Onduty is null) AND year(SDT) =" + ls_year + ") >= 1800 ";
        ls_query2 += " AND hmd201_vid in ( SELECT hme101c_vid FROM hme101c Inner Join hme101b ON hme101c_pdid = hme101b_pdid WHERE hme101c_onduty > 0 AND Year(hme101b_sdate) = " + ls_year + " )  ";
		ls_query2 += " AND ( SELECT ISNULL(SUM(hme101c_onduty),0) From hme101c Inner Join hme101b ON hme101c_pdid = hme101b_pdid Where hme101c_vid = hmd201_vid AND Year(hme101b_sdate) = " + ls_year + "  ) = ( SELECT ISNULL(SUM(hme101b_hour),0) From hme101c Inner Join hme101b ON hme101c_pdid = hme101b_pdid Where hme101c_vid = hmd201_vid AND Year(hme101b_sdate) = " + ls_year + " )  ";


        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data2, ls_query2);
        ldv_dataview2 = lds_data2.Tables[0].DefaultView;
        dgG2.DataSource = ldv_dataview2;
        dgG2.DataBind();


    }
    protected void Bt_Print_Click(object sender, EventArgs e)
    {
        if (dwQ_year.Text.Trim() == "")
        {
            this.uf_Msg("請輸入查詢年度！");
            return;
        }

        string ls_year = Convert.ToString(Convert.ToInt16(dwQ_year.Text) + 1911);

        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_g0201&format=PDF&query=as_year=" + ls_year + "','',1024,768,'no','no');");

    }
}
