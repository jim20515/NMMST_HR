// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排轉正式班表–志願月曆參考表
// 2. 撰寫人員：demon
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

public partial class sys_e_e01_p_e0102_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.IsQuery_UseSession = false;
		this.IsQuery_SessionRemove = false;
        u_Show.i_CalendarSelectionMode = CalendarSelectionMode.None;
        u_Show.ReadOnly = "True";
        u_Show.ShowPeople = "True";
        u_Show.CountPeople = "True";

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
            if (this.Request["args"] != null) //0:hme101a_psid 1:hme101a_syear 2:hme101a_smonth 3:hme101a_tid
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["Year"] = lsa_Arguments[1];
                ViewState["Month"] = lsa_Arguments[2];
                ViewState["tid"] = lsa_Arguments[3];

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(4);");
            }
		}

        this.uf_MyCalendar_ShowOtherMonth();
	}

    // =========================================================================
    // 函式
    // =========================================================================
    /// <summary>
    /// 函式描述：顯示班表月份的月曆控制項資料
    /// </summary>
    protected void uf_MyCalendar_ShowOtherMonth()
    {
        if (ViewState["Year"] != null && ViewState["Month"] != null && ViewState["tid"] != null)
        {
            this.dgG_Retrieve = " AND hmd201_tid = '" + ViewState["tid"].ToString() + "' ";

            dwF_YM_t.Text = "★ " + uf_Dg_Bind("hmd101", ViewState["tid"]) + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月排班班表";
            u_Show.Year = ViewState["Year"].ToString();
            u_Show.Month = ViewState["Month"].ToString();
            u_Show.Tid = this.StoredKey;

            // 需求班次查詢
            string ls_AddSQL = "";
            ls_AddSQL += " AND hme101b_sdate >= '" + Convert.ToDateTime(u_Show.YearE + "/" + u_Show.Month + "/01").AddMonths(-1).ToString("yyyy/MM/dd") + "' ";
            ls_AddSQL += " AND hme101b_sdate <  '" + Convert.ToDateTime(u_Show.YearE + "/" + u_Show.Month + "/01").AddMonths(2).ToString("yyyy/MM/dd") + "' ";
            u_Show.indb_hme101a_hme101b.uf_Retrieve(ls_AddSQL);

            // 產生出月曆
            u_Show.uf_BuildMonth();

            indb_hmd201.uf_Retrieve(dgG_Retrieve);
            dgG.DataBind();
        }
    }	// End of uf_MyCalendar_ShowOtherMonth

    protected string uf_show_pc(object ao_vid)
    {
        string ls_return = "";
        if (ao_vid != null)
        {
            ls_return = e01Project.uf_pc_vid_all(ao_vid.ToString(), this.StoredKey) + "班";
        }
        return ls_return;
    }

    protected string uf_show_ts(object ao_vid)
    {
        string ls_return = "";
        if (ao_vid != null)
        {
            ls_return = e01Project.uf_ts_vid_all(ao_vid.ToString(), this.StoredKey) + "小時";
        }
        return ls_return;
    }

    protected string uf_show_phone(object ao_id)
    {
        string ls_return = "";
        
        if (ao_id != null)
        {
            DbMethods.uf_ExecSQL(" Select hmc101_phnom From hmc101 Where hmc101_id = '" + ao_id.ToString() + "' ", ref ls_return);
        }
        return ls_return;
    }
}
