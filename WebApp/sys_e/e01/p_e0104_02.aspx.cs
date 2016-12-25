// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理– 臨時排班調整–列印
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

public partial class sys_e_e01_p_e0104_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

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
        //u_Show.ReadOnly = "False";
        u_Show.ShowPeople = "True";
        u_Show.OKFlag = "True";

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
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }
		}

        this.uf_MyCalendar_ShowOtherMonth();

        // 註冊執行事件
        u_Show.ue_EventEditChanged += new sys_e_u_e_month_view.BtChangedHandler(this.MyCalendar_EventEditChanged);
	}

    // =========================================================================
    // 事件
    // =========================================================================
    /// <summary>
    /// 事件描述：按下 編輯 所做的處理
    /// </summary>
    private void MyCalendar_EventEditChanged(string as_pdid)
    {
        if (as_pdid == null) return;

        string[] lsa_args = as_pdid.Trim().Split('|');

        if (lsa_args.Length < 2) return;

        switch (lsa_args[0].Trim())
        {
                case "3" :
                    this.uf_AddJavaScript("uf_LinkFrame('p_e0104_03.aspx', '03Frame', '" + lsa_args[1].Trim() + "|" + this.StoredKey + "|" + ViewState["Year"] + "|" + ViewState["Month"] + "|" + ViewState["tid"] + "' )");
                    break;

				case "2" :
                    this.uf_AddJavaScript("uf_LinkFrame('p_e0104_04.aspx', '04Frame', '" + lsa_args[1].Trim() + "' )");
                    break;

				default :
					break;
        }

    }	// End of MyCalendar_EventEditChanged
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
